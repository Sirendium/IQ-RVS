using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using iSpyApplication.Cloud;
using iSpyApplication.Controls;
using iSpyApplication.Kinect;
using iSpyApplication.Pelco;
using iSpyApplication.Realtime;
using iSpyApplication.Sources;
using iSpyApplication.Sources.Audio;
using iSpyApplication.Sources.Video;
using iSpyApplication.Utilities;
using iSpyPRO.DirectShow.Internals;


namespace iSpyApplication
{
    public partial class AddCamera : Form
    {
        private readonly string[] _alertmodes = {"movement", "nomovement", "objectcount"};

        private readonly object[] _detectortypes = { "Two Frames", "Custom Frame", "Background Modeling", "Two Frames (Color)", "Custom Frame (Color)", "Background Modeling (Color)", "None" };

        private readonly object[] _processortypes = {"Grid Processing", "Object Tracking", "Border Highlighting","Area Highlighting", "None"};

        private readonly object[] _actiontypes = {"Alert", "AlertStopped", "Connection Lost", "Reconnect", "ReconnectFailed","RecordingAlertStarted", "RecordingAlertStopped"};

        public CameraWindow CameraControl;
        public bool StartWizard;
        public bool IsNew;
        private HSLFilteringForm _filterForm;
        private bool _loaded;
        private ConfigureTripWires _ctw;
        private PiPConfig _pip;
        public MainForm MainClass;


        public AddCamera()
        {
            InitializeComponent();
            RenderResources();

            AreaControl.BoundsChanged += AsBoundsChanged;
            AreaControl.Invalidate();
        }

        private void AsBoundsChanged(object sender, EventArgs e)
        {
            if (CameraControl.Camera != null && CameraControl.Camera.MotionDetector != null)
            {
                CameraControl.Camera.SetMotionZones(AreaControl.MotionZones);
            }
            CameraControl.Camobject.detector.motionzones = AreaControl.MotionZones;
        }

        private void BtnSelectSourceClick(object sender, EventArgs e)
        {
            StartWizard = false;
            SelectSource();
        }

        private bool SelectSource()
        {
            bool success = false;
            FindCameras.LastConfig.PromptSave = false;
            
            var vs = new VideoSource { CameraControl = CameraControl, StartWizard = StartWizard };
            vs.ShowDialog(this);
            if (vs.DialogResult == DialogResult.OK)
            {
                CameraControl.Camobject.settings.videosourcestring = vs.VideoSourceString;
                CameraControl.Camobject.settings.sourceindex = vs.SourceIndex;
                CameraControl.Camobject.settings.login = vs.CameraLogin;
                CameraControl.Camobject.settings.password = vs.CameraPassword;
                CameraControl.Camobject.name = vs.FriendlyName;

                bool su = CameraControl.Camobject.resolution != vs.CaptureSize.Width + "x" + vs.CaptureSize.Height;
                if (vs.SourceIndex==3)
                {
                    CameraControl.Camobject.resolution = vs.CaptureSize.Width + "x" + vs.CaptureSize.Height;
                    CameraControl.Camobject.settings.framerate = vs.FrameRate;
                    CameraControl.Camobject.settings.crossbarindex = vs.VideoInputIndex;
                }
                
              
                Thread.Sleep(1000); //allows unmanaged code to complete shutdown
              

                CameraControl.NeedSizeUpdate = su;
                if (CameraControl.VolumeControl == null && CameraControl.Camera!=null)
                {
                    //do we need to add a paired volume control?
                    var c = CameraControl.Camera.VideoSource as ISupportsAudio;
                    if (c!=null)
                    {
                        c.HasAudioStream += AddCameraHasAudioStream;
                    }
                    if (FindCameras.LastConfig.PromptSave)
                    {
                        CameraControl.NewFrame -= NewCameraNewFrame;
                        CameraControl.NewFrame += NewCameraNewFrame;
                    }

                }
                LoadAlertTypes();
                success = true;

                
            }
            vs.Dispose();
            return success;
        }

        private delegate void ShareDelegate();
        void NewCameraNewFrame(object sender, NewFrameEventArgs e)
        {
            if (CameraControl == null)
                return;
            
            CameraControl.NewFrame -= NewCameraNewFrame;

            if (MainForm.Conf.Language != "en")
                return;

            if (IsDisposed || !Visible)
                return;
            if (InvokeRequired)
            {
                BeginInvoke(new ShareDelegate(DoShareCamera));
                return;
            }
            DoShareCamera();
        }

        void DoShareCamera()
        {
            if (FindCameras.LastConfig.PromptSave)
            {
                var sc = new ShareCamera();
                sc.ShowDialog(this);
                sc.Dispose();
            }
        }
            

        private delegate void EnableDelegate();

        void AddCameraHasAudioStream(object sender, EventArgs eventArgs)
        {
            if (IsDisposed || !Visible)
                return;
            if (InvokeRequired)
            {
                BeginInvoke(new EnableDelegate(AddAudioStream));
                return;
            }
            AddAudioStream();
        }

        private void AddAudioStream()
        {
            var m = MainForm.Microphones.SingleOrDefault(p => p.id == CameraControl.Camobject.settings.micpair);
            
            if (m!=null)
            {
                lblMicSource.Text = m.name;
            }
        }

        private bool _forceClose;
        private void AddCameraLoad(object sender, EventArgs e)
        {
            int j;
            if (CameraControl.Camobject.id == -1)
            {
                if (!SelectSource())
                {
                    _forceClose = true;
                    Close();
                    return;
                }
            }
            if (CameraControl.Camobject.id == -1)
            {
                CameraControl.Camobject.id = MainForm.NextCameraId;
                MainForm.AddObject(CameraControl.Camobject);
                
            }
            _loaded = false;
            CameraControl.NewFrame -= CameraNewFrame;
            CameraControl.Camobject.width = 230;
            CameraControl.Camobject.height = 175;
            CameraControl.NewFrame += CameraNewFrame;
            CameraControl.IsEdit = true;
            if (CameraControl.VolumeControl != null)
                CameraControl.VolumeControl.IsEdit = true;

            chkMovement.Checked = CameraControl.Camobject.alerts.active;
           
            
            foreach(string dt in _detectortypes)
            {
                ddlMotionDetector.Items.Add(LocRm.GetString(dt));
            }

            foreach (string dt in _processortypes)
            {
                ddlProcessor.Items.Add(LocRm.GetString(dt));
            }

            for (j = 0; j < _detectortypes.Length; j++)
            {
                if ((string) _detectortypes[j] == CameraControl.Camobject.detector.type)
                {
                    ddlMotionDetector.SelectedIndex = j;
                    break;
                }
            }
            for (j = 0; j < _processortypes.Length; j++)
            {
                if ((string) _processortypes[j] == CameraControl.Camobject.detector.postprocessor)
                {
                    ddlProcessor.SelectedIndex = j;
                    break;
                }
            }

            foreach (string dt in _actiontypes)
            {
                ddlActionType.Items.Add(LocRm.GetString(dt));
            }
            ddlActionType.SelectedIndex = 0;

            LoadAlertTypes();

            numProcessInterval.Value = CameraControl.Camobject.detector.processframeinterval;
            txtCameraName.Text = CameraControl.Camobject.name;

            ranger1.Maximum = 100;
            ranger1.Minimum = 0.001;
            ranger1.ValueMin = CameraControl.Camobject.detector.minsensitivity;
            ranger1.ValueMax = CameraControl.Camobject.detector.maxsensitivity;
            ranger1.Gain = CameraControl.Camobject.detector.gain;
            ranger1.ValueMinChanged += Ranger1ValueMinChanged;
            ranger1.ValueMaxChanged += Ranger1ValueMaxChanged;
            ranger1.GainChanged += Ranger1GainChanged;
            ranger1.SetText();
            
            rdoRecordDetect.Checked = CameraControl.Camobject.detector.recordondetect;
            rdoRecordAlert.Checked = CameraControl.Camobject.detector.recordonalert;
            rdoNoRecord.Checked = !rdoRecordDetect.Checked && !rdoRecordAlert.Checked;

          

            var feats = Enum.GetNames(typeof(RotateFlipType));

            int ind = 0;
            j = 0;

            foreach (var f in feats)
            {
              
                if (CameraControl.Camobject.rotateMode == f)
                    ind = j;
                j++;
                
            }
           
            
 
            chkColourProcessing.Checked = CameraControl.Camobject.detector.colourprocessingenabled;
            numMaxFR.Value = CameraControl.Camobject.settings.maxframerate;
            numMaxFRRecording.Value = CameraControl.Camobject.settings.maxframeraterecord;
            
          
            
            rdoContinuous.Checked = CameraControl.Camobject.alerts.processmode == "continuous";
            rdoMotion.Checked = CameraControl.Camobject.alerts.processmode == "motion";
            rdoTrigger.Checked = CameraControl.Camobject.alerts.processmode == "trigger";
       

           
            
            AreaControl.MotionZones = CameraControl.Camobject.detector.motionzones;

          
            
            
            Text = LocRm.GetString("EditCamera");
            if (CameraControl.Camobject.id > -1)
                Text += string.Format(" (ID: {0}, DIR: {1})", CameraControl.Camobject.id, CameraControl.Camobject.directory);


            
            pnlMovement.Enabled = chkMovement.Checked;
            chkSuppressNoise.Checked = CameraControl.Camobject.settings.suppressnoise;

           

       
            txtMaxRecordTime.Value = CameraControl.Camobject.recorder.maxrecordtime;
            numMinRecordTime.Value = CameraControl.Camobject.recorder.minrecordtime;
            btnBack.Enabled = false;
            
       
            
            
            LoadPTZs();
         
          
            

            var m = MainForm.Microphones.SingleOrDefault(p => p.id == CameraControl.Camobject.settings.micpair);
            lblMicSource.Text = m != null ? m.name : LocRm.GetString("None");

            PopulateTalkDevices();
        
            string t2 = CameraControl.Camobject.recorder.trigger ?? "";

         

           

            chkIgnoreAudio.Checked = CameraControl.Camobject.settings.ignoreaudio;


            actionEditor1.LoginRequested += ActionEditor1LoginRequested;

            //chkNotifyDisconnect.Checked = CameraControl.Camobject.settings.notifyondisconnect;

            numAutoOff.Value = CameraControl.Camobject.detector.autooff;
          
            chkMessaging.Checked = CameraControl.Camobject.settings.messaging;

            LoadMediaDirectories();
            PopFTPServers();
           
            intervalConfig1.Init(CameraControl);
            ptzui1.CameraControl = CameraControl;
           

         

            _loaded = true;
        }

        private void LoadMediaDirectories()
        {
          
          
        }

        void ActionEditor1LoginRequested(object sender, EventArgs e)
        {
            Login();
        }

        private void LoadAlertTypes()
        {
            ddlAlertMode.Items.Clear();
            int iMode = 0;

            var items = new List<string>();
            if (Helper.HasFeature(Enums.Features.Motion_Detection))
            {
                foreach (string s in _alertmodes)
                {
                    ddlAlertMode.Items.Add(LocRm.GetString(s));
                    items.Add(s);
                }
            }

            //provider specific alert options
            switch (CameraControl.Camobject.settings.sourceindex)
            {
                case 7:
                    ddlAlertMode.Items.Add("Virtual Trip Wires");
                    items.Add("Virtual Trip Wires");
                    break;
            }

            foreach (String plugin in MainForm.Plugins)
            {
                string name = plugin.Substring(plugin.LastIndexOf("\\", StringComparison.Ordinal) + 1);
                name = name.Substring(0, name.LastIndexOf(".", StringComparison.Ordinal));
                ddlAlertMode.Items.Add(name);
                items.Add(name);
            }


            int iCount = 0;
            if (CameraControl.Camobject.alerts.mode != null)
            {
                foreach (string name in items)
                {
                    if (name.ToLower() == CameraControl.Camobject.alerts.mode.ToLower())
                    {
                        iMode = iCount;
                        break;
                    }
                    iCount++;
                }
            }

            if (ddlAlertMode.Items.Count>0)
                ddlAlertMode.SelectedIndex = iMode;
        }

        void Ranger1ValueMinChanged()
        {
            if (_loaded)
            {
                CameraControl.Camobject.detector.minsensitivity = ranger1.ValueMin;
                if (CameraControl.Camera != null)
                {
                    CameraControl.Camera.AlarmLevel = Helper.CalculateTrigger(ranger1.ValueMin);
                }
            }

        }

        void Ranger1ValueMaxChanged()
        {
            if (_loaded)
            {
                CameraControl.Camobject.detector.maxsensitivity = ranger1.ValueMax;
                if (CameraControl.Camera != null)
                {
                    CameraControl.Camera.AlarmLevelMax = Helper.CalculateTrigger(ranger1.ValueMax);
                }
            }
        }

        void Ranger1GainChanged()
        {
            if (_loaded)
            {
                CameraControl.Camobject.detector.gain = ranger1.Gain;
            }
        }


        

        private void RenderResources()
        {
            btnBack.Text = LocRm.GetString("Back");
            btnFinish.Text = LocRm.GetString("Finish");
          
            btnNext.Text = LocRm.GetString("Next");
          
            llblClearAll.Text = LocRm.GetString("ClearAll");
         
            rdoMotion.Text = LocRm.GetString("WhenMotionDetected");
            rdoContinuous.Text = LocRm.GetString("Continuous");
            chkMovement.Text = LocRm.GetString("AlertsEnabled");
           
            rdoRecordDetect.Text = LocRm.GetString("RecordOnMovementDetection");
            rdoRecordAlert.Text = LocRm.GetString("RecordOnAlert");
            rdoNoRecord.Text = LocRm.GetString("NoRecord");
         
            chkSuppressNoise.Text = LocRm.GetString("SupressNoise");
       
            gbZones.Text = LocRm.GetString("DetectionZones");
         
            groupBox3.Text = LocRm.GetString("VideoSource");
            groupBox4.Text = LocRm.GetString("RecordingSettings");
            groupBox5.Text = LocRm.GetString("Detector");
        
            label1.Text = LocRm.GetString("Name");
         
            label12.Text = LocRm.GetString("UseDetector");
            label13.Text = LocRm.GetString("Seconds");
            label14.Text = LocRm.GetString("RecordTimelapse");
            label15.Text = LocRm.GetString("Intervals");
            label17.Text = LocRm.GetString("Frames");
            label19.Text = groupBox2.Text = LocRm.GetString("Microphone");
           
            label24.Text = LocRm.GetString("Seconds");
            label25.Text = LocRm.GetString("CalibrationDelay");
            label26.Text = LocRm.GetString("PrebufferFrames");
         
            label3.Text = LocRm.GetString("TriggerRange");
            label30.Text = LocRm.GetString("MaxRecordTime");
            label31.Text = LocRm.GetString("Seconds");
            label32.Text = LocRm.GetString("InactivityRecord");
            label34.Text = LocRm.GetString("MaxRecordTime");
            label53.Text = LocRm.GetString("MinRecordTime");
            label35.Text = LocRm.GetString("Seconds");
         
            label33.Text = LocRm.GetString("Seconds");
          
            label4.Text = LocRm.GetString("Mode");
      
            label41.Text = LocRm.GetString("Seconds");
          
            label46.Text = LocRm.GetString("DisplayStyle");
            label48.Text = LocRm.GetString("ColourFiltering");
            label51.Text = LocRm.GetString("ProcessEvery");
         
            label73.Text = LocRm.GetString("CameraModel");
            label75.Text = LocRm.GetString("ExtendedCommands");
        
            label83.Text = LocRm.GetString("ClickAndDragTodraw").Trim();
       
            tabPage1.Text = LocRm.GetString("Camera");
       
            tabPage4.Text = LocRm.GetString("Recording");
         
            tabPage8.Text = LocRm.GetString("Ptz");
         
            toolTip1.SetToolTip(txtCameraName, LocRm.GetString("ToolTip_CameraName"));
            toolTip1.SetToolTip(ranger1, LocRm.GetString("ToolTip_MotionSensitivity"));
          
            label16.Text = LocRm.GetString("PTZNote");
            //chkRotate90.Text = LocRm.GetString("Rotate90");
            
            label43.Text = LocRm.GetString("MaxFramerate");
            label47.Text = LocRm.GetString("WhenRecording");
           
            chkColourProcessing.Text = LocRm.GetString("Apply");
          
            Text = LocRm.GetString("AddCamera");
           
            groupBox6.Text = LocRm.GetString("RecordingMode");
            llblEditPTZ.Text = LocRm.GetString("Edit");
           
            
            linkLabel10.Text = LocRm.GetString("Reload");
          
            label72.Text = LocRm.GetString("AutoOff");
            label82.Text = LocRm.GetString("Seconds");
            groupBox9.Text = LocRm.GetString("Actions");
            label89.Text = LocRm.GetString("When");
            rdoTrigger.Text = LocRm.GetString("ExternalTrigger");
           


            LocRm.SetString(label3,"TriggerRange");
          
            LocRm.SetString(chkIgnoreAudio, "IgnoreAudio");
            
            LocRm.SetString(btnPTZTrack, "TrackObjects");
            LocRm.SetString(btnPTZSchedule, "Scheduler");
          

            HideTab(tabPage3, Helper.HasFeature(Enums.Features.Motion_Detection));
            HideTab(tabPage2, Helper.HasFeature(Enums.Features.Alerts));
            HideTab(tabPage4, Helper.HasFeature(Enums.Features.Recording));
            HideTab(tabPage8, Helper.HasFeature(Enums.Features.PTZ));
          

            if (!Helper.HasFeature(Enums.Features.Web_Settings))
            {
              
            }


        }
        private void HideTab(TabPage t, bool show)
        {
            if (!show)
            {
                tcCamera.TabPages.Remove(t);
            }
        }


        private void LoadPTZs()
        {
            ddlPTZ.Items.Clear();
            ddlPTZ.Items.Add(new ListItem(":: NONE", "-6"));
            ddlPTZ.Items.Add(new ListItem(":: DIGITAL", "-1"));
            ddlPTZ.Items.Add(new ListItem(":: IAM-CONTROL", "-2"));
            ddlPTZ.Items.Add(new ListItem(":: ONVIF", "-5"));
            ddlPTZ.Items.Add(new ListItem(":: PELCO-P", "-3"));
            ddlPTZ.Items.Add(new ListItem(":: PELCO-D", "-4"));


            foreach(ListItem li in ddlPTZ.Items)
            {
                if (li.Value == CameraControl.Camobject.ptz.ToString(CultureInfo.InvariantCulture))
                {
                    ddlPTZ.SelectedItem = li;
                    break;
                }
            }

            if (MainForm.PTZs != null)
            {
                var ptzEntries = new List<PTZEntry>();

                foreach (PTZSettings2Camera ptz in MainForm.PTZs)
                {
                    int j = 0;
                    foreach(var m in ptz.Makes)
                    {
                        string ttl = (m.Name+" "+m.Model).Trim();
                        var ptze = new PTZEntry(ttl,ptz.id,j);

                        if (!ptzEntries.Contains(ptze))
                            ptzEntries.Add(ptze);
                        j++;
                    }
                }
                foreach(var e in ptzEntries.OrderBy(p=>p.Entry))
                {
                    ddlPTZ.Items.Add(e);

                    if (CameraControl.Camobject.ptz == e.Id && CameraControl.Camobject.ptzentryindex==e.Index)
                    {
                        ddlPTZ.SelectedIndex = ddlPTZ.Items.Count-1;
                    }
                }
                if (ddlPTZ.SelectedIndex == -1)
                {
                    ddlPTZ.SelectedIndex = 0;
                }
            }
        }

        private struct PTZEntry
        {
            public readonly string Entry;
            public readonly int Id;
            public readonly int Index;
            public PTZEntry(string entry, int id, int index)
            {
                Id = id;
                Entry = entry;
                Index = index;
            }
            public override string ToString()
            {
                return Entry;
            }
        }
        
        private void CameraNewFrame(object sender, NewFrameEventArgs e)
        {
            AreaControl.LastFrame = e.Frame;
            try
            {
                if (_filterForm != null)
                    _filterForm.ImageProcess = (Bitmap) e.Frame.Clone();

                if (_ctw != null && _ctw.TripWireEditor1 != null)
                {
                    _ctw.TripWireEditor1.LastFrame = e.Frame;
                }
                if (_pip != null && _pip.areaSelector1 != null)
                {
                    _pip.areaSelector1.LastFrame = e.Frame;
                }
            }
            catch(Exception ex)
            {
                Logger.LogException(ex);
            }
        }

        private void BtnNextClick(object sender, EventArgs e)
        {
            GoNext();
        }

        private void GoNext()
        {
            tcCamera.SelectedIndex++;
        }

        private void GoPrevious()
        {
            tcCamera.SelectedIndex--;
        }

        private bool CheckStep1()
        {
            string err = "";
            string name = txtCameraName.Text.Trim();
            if (name == "")
                err += LocRm.GetString("Validate_Camera_EnterName") + Environment.NewLine;
            if (MainForm.Cameras.FirstOrDefault(p => p.name.ToLower() == name.ToLower() && p.id != CameraControl.Camobject.id) != null)
                err += LocRm.GetString("Validate_Camera_NameInUse") + Environment.NewLine;

            if (string.IsNullOrEmpty(CameraControl.Camobject.settings.videosourcestring))
            {
                err += LocRm.GetString("Validate_Camera_SelectVideoSource") + Environment.NewLine;
            }

            if (err != "")
            {
                MessageBox.Show(err, LocRm.GetString("Error"));
                tcCamera.SelectedIndex = 0;
                return false;
            }
            return true;
        }

        private void BtnFinishClick(object sender, EventArgs e)
        {
            if (Save())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool Save()
        {
            //validate page 0
            if (!CheckStep1())
                return false;
            string err = "";
                
           
            if (err != "")
            {
                MessageBox.Show(err, LocRm.GetString("Error"));
                return false;
            }

           
      
           

                
                
          

         
           

            int savemode = 0;
          
            CameraControl.Camobject.savelocal.mode = savemode;
          


            CameraControl.Camobject.detector.processframeinterval = (int)numProcessInterval.Value;
            CameraControl.Camobject.detector.motionzones = AreaControl.MotionZones;
            CameraControl.Camobject.detector.type = (string) _detectortypes[ddlMotionDetector.SelectedIndex];
            CameraControl.Camobject.detector.postprocessor = (string) _processortypes[ddlProcessor.SelectedIndex];
            CameraControl.Camobject.name = txtCameraName.Text.Trim();
            //update to plugin if connected and supported
            if (CameraControl.Camera != null && CameraControl.Camera.Plugin != null)
            {
                try
                {
                    var plugin = CameraControl.Camera.Plugin;
                    plugin.GetType().GetProperty("CameraName").SetValue(plugin, CameraControl.Camobject.name, null);
                }
                catch
                {
                }
            }

            CameraControl.Camobject.settings.ignoreaudio = chkIgnoreAudio.Checked;
            CameraControl.Camobject.alerts.active = chkMovement.Checked;
                
           
                
          
                      
            SetStorageManagement();

            CameraControl.Camobject.recorder.minrecordtime = (int)numMinRecordTime.Value;

            CameraControl.Camobject.detector.autooff = (int)numAutoOff.Value;
          
      


            string olddir = Helper.GetMediaDirectory(2, CameraControl.Camobject.id) + "video\\" + CameraControl.Camobject.directory + "\\";

            
                
            int tempidx = CameraControl.Camobject.settings.directoryIndex;
        

          

            if (IsNew)
            {
                try
                {
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, LocRm.GetString("Validate_Directory_String") + Environment.NewLine + ex.Message);
                    CameraControl.Camobject.settings.directoryIndex = tempidx;
                    return false;
                }
            }
            else
            {
              
            }

          
                
          

            int bufferseconds,
                calibrationdelay,
                inactiveRecord,
                maxrecord;
          
            int.TryParse(txtMaxRecordTime.Text, out maxrecord);

        

            var m = MainForm.Microphones.SingleOrDefault(p => p.id == CameraControl.Camobject.settings.micpair);
            if (m != null)
                m.settings.buffer = CameraControl.Camobject.recorder.bufferseconds;

        
          
            CameraControl.Camobject.alerts.processmode = "continuous";
            if (rdoMotion.Checked)
                CameraControl.Camobject.alerts.processmode = "motion";
            if (rdoTrigger.Checked)
                CameraControl.Camobject.alerts.processmode = "trigger";
            CameraControl.Camobject.recorder.maxrecordtime = maxrecord;
         
         
         
            int ftpmode = 0;
          
            CameraControl.Camobject.ftp.mode = ftpmode;

      
          

          
            CameraControl.Camobject.settings.maxframeraterecord = numMaxFRRecording.Value;

       
            CameraControl.Camobject.detector.recordonalert = rdoRecordAlert.Checked;
            CameraControl.Camobject.detector.recordondetect = rdoRecordDetect.Checked;

            CameraControl.UpdateFloorplans(false);


            CameraControl.SetVideoSize();

           
           

            if (CameraControl != null && CameraControl.Camera != null && CameraControl.Camera.VideoSource != null)
            {
                var vcd = CameraControl.Camera.VideoSource as VideoCaptureDevice;
                if (vcd != null && vcd.SupportsProperties)
                {
                    //save extended properties of local device
                    int b, c, h, s, sh, gam, ce, wb, bc, g;
                    VideoProcAmpFlags fb, fc, fh, fs, fsh, fgam, fce, fwb, fbc, fg;

                    vcd.GetProperty(VideoProcAmpProperty.Brightness, out b, out fb);
                    vcd.GetProperty(VideoProcAmpProperty.Contrast, out c, out fc);
                    vcd.GetProperty(VideoProcAmpProperty.Hue, out h, out fh);
                    vcd.GetProperty(VideoProcAmpProperty.Saturation, out s, out fs);
                    vcd.GetProperty(VideoProcAmpProperty.Sharpness, out sh, out fsh);
                    vcd.GetProperty(VideoProcAmpProperty.Gamma, out gam, out fgam);
                    vcd.GetProperty(VideoProcAmpProperty.ColorEnable, out ce, out fce);
                    vcd.GetProperty(VideoProcAmpProperty.WhiteBalance, out wb, out fwb);
                    vcd.GetProperty(VideoProcAmpProperty.BacklightCompensation, out bc, out fbc);
                    vcd.GetProperty(VideoProcAmpProperty.Gain, out g, out fg);
                            
                    string cfg = "";
                    cfg += "b=" + b + ",fb=" + (int) fb + ",";
                    cfg += "c=" + c + ",fc=" + (int) fc + ",";
                    cfg += "h=" + h + ",fh=" + (int) fh + ",";
                    cfg += "s=" + s + ",fs=" + (int) fs + ",";
                    cfg += "sh=" + sh + ",fsh=" + (int) fsh + ",";
                    cfg += "gam=" + gam + ",fgam=" + (int) fgam + ",";
                    cfg += "ce=" + ce + ",fce=" + (int) fce + ",";
                    cfg += "wb=" + wb + ",fwb=" + (int) fwb + ",";
                    cfg += "bc=" + bc + ",fbc=" + (int) fbc + ",";
                    cfg += "g=" + g + ",fg=" + (int) fg;

                    CameraControl.Camobject.settings.procAmpConfig = cfg;
                }
            }

           
            CameraControl.Camobject.settings.messaging = chkMessaging.Checked;
          

            MainForm.NeedsSync = true;
            IsNew = false;
           

            return true;
        }

        private void ChkMovementCheckedChanged(object sender, EventArgs e)
        {
            pnlMovement.Enabled = (chkMovement.Checked);
            CameraControl.Camobject.alerts.active = chkMovement.Checked;
        }

        
        private void ChkScheduleCheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void TxtCameraNameKeyUp(object sender, KeyEventArgs e)
        {
            CameraControl.Camobject.name = txtCameraName.Text;
        }


        private void ChkActiveCheckedChanged(object sender, EventArgs e)
        {
         


           
        }

        private void TxtCameraNameTextChanged(object sender, EventArgs e)
        {
            CameraControl.Camobject.name = txtCameraName.Text;
        }

        private void AddCameraFormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsNew)
            {
                if (!_forceClose && MessageBox.Show(this, LocRm.GetString("DiscardCamera"), LocRm.GetString("Confirm"), MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
                if (CameraControl.VolumeControl!=null)
                    MainClass.RemoveMicrophone(CameraControl.VolumeControl, false);
                    
            }
            CameraControl.NewFrame -= CameraNewFrame;
            AreaControl.Dispose();
            CameraControl.IsEdit = false;
            if (CameraControl.VolumeControl != null)
                CameraControl.VolumeControl.IsEdit = false;
        }

        private void DdlMovementDetectorSelectedIndexChanged1(object sender, EventArgs e)
        {
            ddlProcessor.Enabled = rdoMotion.Enabled = (string) _detectortypes[ddlMotionDetector.SelectedIndex] != "None";
            if (!rdoMotion.Enabled)
                rdoContinuous.Checked = true;
                        
            if ((string) _detectortypes[ddlMotionDetector.SelectedIndex] != CameraControl.Camobject.detector.type)
            {
                CameraControl.Camobject.detector.type = (string) _detectortypes[ddlMotionDetector.SelectedIndex];
                CameraControl.SetDetector();
            }
            
            CameraControl.Camobject.detector.type = (string) _detectortypes[ddlMotionDetector.SelectedIndex];
        }

        

        private void ChkSuppressNoiseCheckedChanged(object sender, EventArgs e)
        {
            if (CameraControl.Camera != null && CameraControl.Camera.VideoSource != null)
            {
                if (CameraControl.Camobject.settings.suppressnoise != chkSuppressNoise.Checked)
                {
                    CameraControl.Camobject.settings.suppressnoise = chkSuppressNoise.Checked;
                    CameraControl.SetDetector();
                }
            }
        }


        private void Button2Click(object sender, EventArgs e)
        {
            GoPrevious();
        }

        private void TcCameraSelectedIndexChanged(object sender, EventArgs e)
        {
            btnBack.Enabled = tcCamera.SelectedIndex != 0;

            btnNext.Enabled = tcCamera.SelectedIndex != tcCamera.TabCount - 1;
        }

        private void Button1Click1(object sender, EventArgs e)
        {
            
        }

        private void DdlProcessorSelectedIndexChanged(object sender, EventArgs e)
        {
            if (CameraControl.Camera != null && CameraControl.Camera.VideoSource != null &&
                CameraControl.Camera.MotionDetector != null)
            {
                if ((string) _processortypes[ddlProcessor.SelectedIndex] != CameraControl.Camobject.detector.postprocessor)
                {
                    CameraControl.Camobject.detector.postprocessor = (string) _processortypes[ddlProcessor.SelectedIndex];
                    CameraControl.SetProcessor();
                }
            }
            CameraControl.Camobject.detector.postprocessor = (string) _processortypes[ddlProcessor.SelectedIndex];
        }


        private void DdlHourStartSelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void LinkLabel1LinkClicked1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm.OpenUrl(MainForm.Website + "/userguide-motion-detection.aspx#2");
        }

        
        private void CheckBox1CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LinkLabel2LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm.OpenUrl( MainForm.Website+"/userguide-ftp.aspx");
        }


        private void Login()
        {
            MainClass.Connect(MainForm.Website + "/subscribe.aspx", false);
        }
        
        private void PnlPtzMouseDown(object sender, MouseEventArgs e)
        {
            

            ProcessPtzInput(e.Location);
        }


        private void ProcessPtzInput(Point p)
        {
            var comm = Enums.PtzCommand.Center;
            bool cmd = false;

            if (p.X > 170 && p.Y < 45)
            {
                comm = Enums.PtzCommand.ZoomIn;
                cmd = true;
            }
            if (p.X > 170 && p.Y > 45 && p.Y < 90)
            {
                comm = Enums.PtzCommand.ZoomOut;
                cmd = true;
            }

            if (cmd)
            {
                CameraControl.Calibrating = true;
                CameraControl.PTZ.SendPTZCommand(comm);
            }
            else
            {
                double angle = Math.Atan2(86 - p.Y, 86 - p.X);
                CameraControl.Calibrating = true;
                CameraControl.PTZ.SendPTZDirection(angle);
            }

            
        }

        private void DdlPtzSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPTZ.SelectedItem is ListItem)
            {
                var li = (ListItem) ddlPTZ.SelectedItem;
                CameraControl.Camobject.ptz = Convert.ToInt32(li.Value);
                CameraControl.Camobject.ptzentryindex = -1;
                CameraControl.PTZ.PTZSettings = null;
            }
            else
            {
                var entry = (PTZEntry)ddlPTZ.SelectedItem;
                CameraControl.Camobject.ptz = entry.Id;
                CameraControl.Camobject.ptzentryindex = entry.Index;
            }

            lbExtended.Items.Clear();
            btnAddPreset.Visible = btnDeletePreset.Visible = false;



            if (CameraControl.Camobject.ptz > -1)
            {
                PTZSettings2Camera ptz = MainForm.PTZs.Single(p => p.id == CameraControl.Camobject.ptz);
                CameraControl.PTZ.PTZSettings = ptz;
                if (ptz.ExtendedCommands?.Command != null)
                {
                    foreach (var extcmd in ptz.ExtendedCommands.Command)
                    {
                        lbExtended.Items.Add(new ListItem(extcmd.Name, extcmd.Value));
                    }
                }
                if (_loaded)
                {
                    if (ptz.portSpecified)
                        CameraControl.Camobject.settings.ptzport = ptz.port;
                }
            }
            if (CameraControl.Camobject.ptz==-3 || CameraControl.Camobject.ptz==-4)
            {
                foreach(string cmd in PTZController.PelcoCommands)
                {
                    lbExtended.Items.Add(new ListItem(cmd, cmd));
                }
                
            }

            if (CameraControl.Camobject.ptz == -5)
            {
                PopOnvifPresets();
            }
            switch (CameraControl.Camobject.ptz)
            {
                case -1:
                case -6:
                    tableLayoutPanel12.Enabled = false;
                    break;
                default:
                    tableLayoutPanel12.Enabled = true;
                    break;

            }
        }

        private void PopOnvifPresets()
        {
            lbExtended.Items.Clear();
            btnAddPreset.Visible = btnDeletePreset.Visible = true;
            foreach (var preset in CameraControl.PTZ.ONVIFPresets)
            {
                lbExtended.Items.Add(new ListItem(preset.Name, preset.token));
            }
        }

        private void PnlPtzPaint(object sender, PaintEventArgs e)
        {
        }

        private void LbExtendedClick(object sender, EventArgs e)
        {
            if (lbExtended.SelectedIndex > -1)
            {
                var li = ((ListItem) lbExtended.SelectedItem);
                SendPtzCommand(li.Name);
            }
        }


        private void PnlPtzMouseUp(object sender, MouseEventArgs e)
        {
            CameraControl.PTZ.CheckSendStop();            
        }

        private void SendPtzCommand(string cmd)
        {
            if (cmd == "")
            {
                MessageBox.Show(LocRm.GetString("CommandNotSupported"));
                return;
            }
            try
            {
                CameraControl.Calibrating = true;
                CameraControl.PTZ.SendPTZCommand(cmd);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                MessageBox.Show(ex.Message, LocRm.GetString("Error"));
            }
        }


        private void PnlPtzMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //todo: add drag to move cam around
            }
        }

        private void LbExtendedSelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void LinkLabel6LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            var d = new downloader
            {
                Url = MainForm.ContentSource + "/getcontent.aspx?name=PTZ2",
                SaveLocation = Program.AppDataPath + @"XML\PTZ2.xml"
            };
            d.ShowDialog(this);
            if (d.DialogResult == DialogResult.OK)
            {
                MainForm.PTZs = null;
                LoadPTZs();
            }
            d.Dispose();
        }

        private void TabPage9Click(object sender, EventArgs e)
        {
        }

        private void ShowSettings(int tabindex)
        {
            string lang = MainForm.Conf.Language;
            MainClass.ShowSettings(tabindex, this);
            if (lang != MainForm.Conf.Language)
                RenderResources();
        }


        private void DdlTimestampKeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void BtnMaskImageClick(object sender, EventArgs e)
        {
            ofdDetect.FileName = "";
            ofdDetect.InitialDirectory = Program.AppPath + @"backgrounds\";
            ofdDetect.Filter = "Image Files (*.png)|*.png";
            ofdDetect.ShowDialog(this);
            if (ofdDetect.FileName != "")
            {
               
            }
        }

        private void TxtMaskImageTextChanged(object sender, EventArgs e)
        {
          
          
        }


        //private void ChkFlipYCheckedChanged(object sender, EventArgs e)
        //{
        //    CameraControl.Camobject.flipy = chkFlipY.Checked;
        //}

        //private void ChkFlipXCheckedChanged(object sender, EventArgs e)
        //{
        //    CameraControl.Camobject.flipx = chkFlipX.Checked;
        //}
          
        private void LinkLabel8LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm.OpenUrl( MainForm.Website+"/userguide-pairing.aspx");
        }

        private void RdoFtpIntervalCheckedChanged(object sender, EventArgs e)
        {
      
        }

        private void rdoFTPAlerts_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void Button3Click3(object sender, EventArgs e)
        {
            if (Helper.HasFeature(Enums.Features.Motion_Detection))
            {
                ConfigureSeconds cf;
                switch (ddlAlertMode.SelectedIndex)
                {
                    case 0:
                        cf = new ConfigureSeconds
                                 {
                                     Seconds = CameraControl.Camobject.detector.movementintervalnew
                                 };
                        cf.ShowDialog(this);
                        if (cf.DialogResult == DialogResult.OK)
                            CameraControl.Camobject.detector.movementintervalnew = cf.Seconds;
                        cf.Dispose();
                        return;
                    case 1:
                        cf = new ConfigureSeconds
                                 {
                                     Seconds = CameraControl.Camobject.detector.nomovementintervalnew
                                 };
                        cf.ShowDialog(this);
                        if (cf.DialogResult == DialogResult.OK)
                            CameraControl.Camobject.detector.nomovementintervalnew = cf.Seconds;
                        cf.Dispose();
                        return;
                    case 2:
                        var coc = new ConfigureObjectCount
                                      {
                                          Objects = CameraControl.Camobject.alerts.objectcountalert
                                      };
                        coc.ShowDialog(this);

                        if (coc.DialogResult == DialogResult.OK)
                            CameraControl.Camobject.alerts.objectcountalert = coc.Objects;
                        coc.Dispose();
                        return;
                }
            }

            if (ddlAlertMode.SelectedIndex == -1)
                return;

            switch (ddlAlertMode.SelectedItem.ToString())
            {
                case "Virtual Trip Wires":
                    _ctw = new ConfigureTripWires();
                    _ctw.TripWireEditor1.Init(CameraControl.Camobject.alerts.pluginconfig);
                    _ctw.ShowDialog(this);
                    CameraControl.Camobject.alerts.pluginconfig = _ctw.TripWireEditor1.Config;
                    if (CameraControl.Camera != null && CameraControl.Camera.VideoSource is KinectStream)
                    {
                        ((KinectStream) CameraControl.Camera.VideoSource).InitTripWires(
                            CameraControl.Camobject.alerts.pluginconfig);
                    }
                    _ctw.Dispose();
                    _ctw = null;
                    break;
                default:
                    if (CameraControl.Camera != null && CameraControl.Camera.Plugin != null)
                    {
                        CameraControl.ConfigurePlugin();
                    }
                    else
                    {
                        MessageBox.Show(this,
                                        LocRm.GetString("Validate_Initialise_Camera"));
                    }
                    break;
            }


        }        

        private void DdlAlertModeSelectedIndexChanged(object sender, EventArgs e)
        {
            string last = CameraControl.Camobject.alerts.mode;
            flowLayoutPanel5.Enabled = Helper.HasFeature(Enums.Features.Motion_Detection);
            if (flowLayoutPanel5.Enabled)
                flowLayoutPanel5.Enabled = ddlAlertMode.SelectedIndex > _alertmodes.Length-1;
            if (!flowLayoutPanel5.Enabled)
                rdoContinuous.Checked = true;

            if (Helper.HasFeature(Enums.Features.Motion_Detection) && ddlAlertMode.SelectedIndex < _alertmodes.Length)
            {
                CameraControl.Camobject.alerts.mode = _alertmodes[ddlAlertMode.SelectedIndex];
                if (ddlAlertMode.SelectedIndex==2)
                {
                    ddlProcessor.SelectedIndex = 1;
                }
            }
            else
            {
                CameraControl.Camobject.alerts.mode = ddlAlertMode.SelectedItem.ToString();
            }

            if (last != ddlAlertMode.SelectedItem.ToString())
            {
                if (CameraControl.Camera != null && CameraControl.Camera.Plugin != null)
                {
                    CameraControl.Camera.Plugin = null;
                    CameraControl.Camobject.alerts.pluginconfig = "";
                }
            }
            button3.Enabled = true;
        }

        private void ChkTimelapseCheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void chkPublic_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void LinkLabel9LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login();
        }

        #region Nested type: ListItem

        private struct ListItem
        {
            private readonly string _name;
            internal readonly string Value;

            public ListItem(string name, string value)
            {
                _name = name;
                Value = value;
            }
            public override string ToString()
            {
                return _name;
            }

            public string Name
            {
                get { return _name; }
            }
        }

        #endregion

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void numMaxFR_ValueChanged(object sender, EventArgs e)
        {
            CameraControl.Camobject.settings.maxframerate = numMaxFR.Value;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var cp = new ConfigureProcessor(CameraControl);
            if (cp.ShowDialog(this)== DialogResult.OK)
            {
                if (CameraControl.Camera != null && CameraControl.Camera.MotionDetector != null)
                {
                    CameraControl.SetDetector();
                }
            }
            cp.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ConfigFilter();
        }

        private void chkColourProcessing_CheckedChanged(object sender, EventArgs e)
        {
            if (chkColourProcessing.Checked)
            {
                if (String.IsNullOrEmpty(CameraControl.Camobject.detector.colourprocessing))
                {
                    if (!ConfigFilter())
                        chkColourProcessing.Checked = false;
                }
            }
            CameraControl.Camobject.detector.colourprocessingenabled = chkColourProcessing.Checked;
        }

        private bool ConfigFilter()
        {
            _filterForm = new HSLFilteringForm(CameraControl.Camobject.detector.colourprocessing) { ImageProcess = CameraControl.Camera==null?null: CameraControl.LastFrame };
            _filterForm.ShowDialog(this);
            if (_filterForm.DialogResult == DialogResult.OK)
            {
                CameraControl.Camobject.detector.colourprocessing = _filterForm.Configuration;
                if (CameraControl.Camera!=null)
                    CameraControl.Camera.FilterChanged();
                _filterForm.Dispose();
                _filterForm = null;
                chkColourProcessing.Checked = true;
                return true;
            }

            _filterForm.Dispose();
            _filterForm = null;
            return false;
        }

        private void AddCamera_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainForm.OpenUrl( MainForm.Website+"/userguide-camera-settings.aspx");
        }

        private void llblHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = MainForm.Website+"/userguide-camera-settings.aspx";
            switch (tcCamera.SelectedTab.Name)
            {
                case "tabPage1":
                    url=MainForm.Website+"/userguide-camera-settings.aspx";
                    break;
                case "tabPage3":
                    url = MainForm.Website+"/userguide-motion-detection.aspx";
                    break;
                case "tabPage2":
                    url = MainForm.Website+"/userguide-alerts.aspx";
                    break;
                case "tabPage4":
                    url = MainForm.Website+"/userguide-recording.aspx";
                    break;
                case "tabPage8":
                    url = MainForm.Website+"/userguide-ptz.aspx";
                    break;
                case "tabPage7":
                case "tabPage10":
                    url = MainForm.Website+"/userguide-ftp.aspx";
                    break;
                case "tabPage9":
                    url = MainForm.Website+"/userguide-youtube.aspx";
                    break;
                case "tabPage5":
                    url = MainForm.Website+"/userguide-scheduling.aspx";
                    break;
            }
            MainForm.OpenUrl( url);
        }

        private void btnTimestamp_Click(object sender, EventArgs e)
        {
            var ct = new ConfigureTimestamp
                         {
                             TimeStampLocation = CameraControl.Camobject.settings.timestamplocation,
                             Offset = CameraControl.Camobject.settings.timestampoffset,
                             TimestampForeColor = CameraControl.Camobject.settings.timestampforecolor.ToColor(),
                             TimestampBackColor = CameraControl.Camobject.settings.timestampbackcolor.ToColor(),
                             CustomFont = FontXmlConverter.ConvertToFont(CameraControl.Camobject.settings.timestampfont),
                             TimestampShowBack = CameraControl.Camobject.settings.timestampshowback,
                             TagsNV =  CameraControl.Camobject.settings.tagsnv
                         };

            if (ct.ShowDialog(this)== DialogResult.OK)
            {
                CameraControl.Camobject.settings.timestamplocation = ct.TimeStampLocation;
                CameraControl.Camobject.settings.timestampfont = ct.CustomFont.SerializeFontAttribute;
                CameraControl.Camobject.settings.timestampoffset = ct.Offset;
                CameraControl.Camobject.settings.timestampforecolor = ct.TimestampForeColor.ToRGBString();
                CameraControl.Camobject.settings.timestampbackcolor = ct.TimestampBackColor.ToRGBString();
                CameraControl.Camobject.settings.timestampshowback = ct.TimestampShowBack;
                CameraControl.Camobject.settings.tagsnv = ct.TagsNV;
                

                if (CameraControl.Camera != null)
                {
                    CameraControl.Camera.DrawFont = null;
                    CameraControl.Camera.ForeBrush = CameraControl.Camera.BackBrush = null;
                    CameraControl.Camera.Tags = null;
                }
            }
            ct.Dispose();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm.OpenUrl(MainForm.Website+"/plugins.aspx");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rdoContinuous_CheckedChanged(object sender, EventArgs e)
        {
            CameraControl.Camobject.alerts.processmode = "continuous";
        }

        private void ddlCopyFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void llblEditPTZ_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("Notepad.exe", Program.AppDataPath + @"XML\PTZ2.xml");
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm.PTZs = null;
            LoadPTZs();
        }

        private void txtBuffer_ValueChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var dir = Helper.GetMediaDirectory(2, CameraControl.Camobject.id);
         
          
        }

        private void ddlProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            //not sure why i was doing this, must have been a reason...
            //numMaxFRRecording.Enabled = ddlProfile.SelectedIndex < 3;
        }

        private void btnAdvanced_Click(object sender, EventArgs e)
        {
            try
            {
                var vcd = CameraControl.Camera.VideoSource as VideoCaptureDevice;
                if (vcd!=null)
                {
                    vcd.DisplayPropertyPage(Handle);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCrossbar_Click(object sender, EventArgs e)
        {
            try {
                if (CameraControl.Camera!=null)
                    ((VideoCaptureDevice)CameraControl.Camera.VideoSource).DisplayCrossbarPropertyPage(Handle);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMic_Click(object sender, EventArgs e)
        {
            var cms = new CameraMicSource
                          {
                              CameraControl = this.CameraControl,
                              StartPosition = FormStartPosition.CenterParent
                          };
            cms.ShowDialog(this);

            CameraControl.SetVolumeLevel(CameraControl.Camobject.settings.micpair);

            if (CameraControl.Camobject.settings.micpair>-1)
            {
                var m = MainForm.Microphones.SingleOrDefault(p => p.id == CameraControl.Camobject.settings.micpair);
                if (m != null)
                {
                    lblMicSource.Text = m.name;
                    m.settings.buffer = CameraControl.Camobject.recorder.bufferseconds;
                    CameraControl.SetVolumeLevelLocation();
                    chkIgnoreAudio.Checked = false;
                }
            }
            else
            {
                lblMicSource.Text = LocRm.GetString("None");
            }

            
        }

        private void ddlTimestamp_SelectedIndexChanged(object sender, EventArgs e)
        {
       
        }

        private void chkLocalSaving_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void PopulateTalkDevices()
        {
            var models = new [] {"None", "Local Playback","Axis", "Foscam", "iSpyServer", "NetworkKinect", "IP Webcam (Android)", "Amcrest" };
          
        }

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string lang = MainForm.Conf.Language;
            MainClass.ShowSettings(6,this);
            if (lang != MainForm.Conf.Language)
                RenderResources();
        }

        private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm.OpenUrl(MainForm.Website + "/userguide-grant-access.aspx");
        }

        private void txtPTZPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label81_Click(object sender, EventArgs e)
        {

        }

        private void chkIgnoreAudio_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIgnoreAudio.Checked)
            {
                if (CameraControl.VolumeControl!=null)
                {
                    MainClass.RemoveMicrophone(CameraControl.VolumeControl, false);
                }
            }
        }

        private void linkLabel15_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AreaControl.ClearRectangles();
            CameraControl.Camobject.detector.motionzones = AreaControl.MotionZones;
            CameraControl.SetMotionZones();            
            AreaControl.Invalidate();
        }

       

        private void btnAddPreset_Click(object sender, EventArgs e)
        {
            var p = new Prompt(LocRm.GetString("EnterName"),"");
            if (p.ShowDialog(this)==DialogResult.OK)
            {
                var s = p.Val.Trim();
                if (!String.IsNullOrEmpty(s))
                {
                    if (CameraControl.PTZ != null)
                    {
                        try
                        {
                            CameraControl.PTZ.AddPreset(s,null);
                        }
                        catch (Exception ex)
                        {
                            //sometimes seems to return an invalid result (camera bug?)
                        }
                        Thread.Sleep(1000); //allows time to complete
                        PopOnvifPresets();
                    }
                }
            }
            p.Dispose();
        }

        private void btnDeletePreset_Click(object sender, EventArgs e)
        {
            var p = lbExtended.SelectedItem;
            if (p!=null)
            {
                if (CameraControl.PTZ != null)
                {
                    var li = (ListItem) p;
                    try
                    {
                        CameraControl.PTZ.DeletePreset(li.Value);
                    }
                    catch (Exception ex)
                    {

                    }
                    Thread.Sleep(1000);
                    PopOnvifPresets();
                }
            }

        }

        private void chkStorageManagement_CheckedChanged(object sender, EventArgs e)
        {
           

        }

        private void btnRunNow_Click(object sender, EventArgs e)
        {
            SetStorageManagement();

            MainClass.RunStorageManagement(true);
        }

        private void SetStorageManagement()
        {
            
        }

        private void rdoMotion_CheckedChanged(object sender, EventArgs e)
        {
            CameraControl.Camobject.alerts.processmode = "motion";
        }

        private void actionEditor1_Load(object sender, EventArgs e)
        {

        }

        private void ddlRotateFlip_SelectedIndexChanged(object sender, EventArgs e)
        {
          

           
            
                 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainClass.ShowSettings(2, this);
            LoadMediaDirectories();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var vsa = new VideoSourceAdvanced { Camobject = CameraControl.Camobject };
            vsa.ShowDialog(this);
            vsa.Dispose();
        }

        private void ddlEventType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlActionType.SelectedIndex > -1)
            {
                string at = "alert";
                switch (ddlActionType.SelectedIndex)
                {
                    case 1:
                        at = "alertstopped";
                        break;
                    case 2:
                        at = "disconnect";
                        break;
                    case 3:
                        at = "reconnect";
                        break;
                    case 4:
                        at = "reconnectfailed";
                        break;
                    case 5:
                        at = "recordingstarted";
                        break;
                    case 6:
                        at = "recordingstopped";
                        break;

                }
                
                actionEditor1.Init(at,CameraControl.Camobject.id,2);
            }
        }

        private void rdoSaveInterval_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void flowLayoutPanel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowSettings(3);
            PopFTPServers();
        }

        private void PopFTPServers()
        {
           
            int i = -1, j=0;
            foreach (var ftp in MainForm.Conf.FTPServers)
            {
              
                if (CameraControl.Camobject.ftp.ident == ftp.ident)
                {
                    i = j;
                }
                j++;
            }

           
            
        }

        private void btnAuthorise_Click(object sender, EventArgs e)
        {
           
            
        }

        private void ddlCloudProviders_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var t = new PTZTracking {CameraControl = CameraControl};
            t.ShowDialog(this);
            if (CameraControl.Camobject.settings.ptzautotrack)
            {
                ddlMotionDetector.SelectedIndex = 0;
                ddlProcessor.SelectedIndex = 1;
                CameraControl.SetDetector();
            }
            t.Dispose();

        }

        private void btnPTZSchedule_Click(object sender, EventArgs e)
        {
            var s = new PTZScheduler {CameraControl = CameraControl};
            s.ShowDialog(this);
            s.Dispose();
        }

        private void btnPiP_Click(object sender, EventArgs e)
        {
            _pip = new PiPConfig {pip = CameraControl.Camobject.settings.pip, CW = CameraControl};
            _pip.ShowDialog(this);
            _pip.Dispose();
            _pip = null;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Save())
            {
                using (var ct = new CopyTo {OC = CameraControl.Camobject})
                {
                    ct.ShowDialog(this);
                }
            }

        }

        private void btnAuthoriseYouTube_Click(object sender, EventArgs e)
        {
            Authorise("youtube");
            
        }

        private void Authorise(string provider)
        {
            string url = "";
            var rurl = "https://www.ispyconnect.com";
            switch (provider)
            {
                case "drive":
                    url =("https://accounts.google.com/o/oauth2/v2/auth?scope=https://www.googleapis.com/auth/drive&redirect_uri=urn:ietf:wg:oauth:2.0:oob&response_type=code&client_id=648753488389.apps.googleusercontent.com&access_type=offline");
                    break;
                case "youtube":
                    url =("https://accounts.google.com/o/oauth2/v2/auth?scope=https://www.googleapis.com/auth/youtube.upload&redirect_uri=urn:ietf:wg:oauth:2.0:oob&response_type=code&client_id=648753488389.apps.googleusercontent.com&access_type=offline");
                    break;
                case "dropbox":
                    url =("https://www.dropbox.com/oauth2/authorize?client_id=6k40bpqlz573mqt&redirect_uri=" + rurl + "/responsecode.aspx&response_type=code");
                    break;
                case "onedrive":
                    url = ("https://login.live.com/oauth20_authorize.srf?client_id=000000004C193719&scope=wl.offline_access wl.skydrive_update&response_type=code&redirect_uri=" + rurl + "/responsecode.aspx");
                    break;
                case "box":
                    url = ("https://account.box.com/api/oauth2/authorize?client_id=0uvr6c6kvl60p7725i62v9ua4k6bclpj&box_login=&response_type=code&redirect_uri=" + rurl + "/responsecode.aspx&state=" + new Random().NextDouble());
                    break;
                case "flickr":
                    var err = "";
                    url = Flickr.GetAuthoriseURL(out err);
                    if (err != "")
                    {
                        MessageBox.Show(err);
                        return;
                    }
                    break;
            }


            using (var auth = new Authorizer())
            {
                auth.URL = url;
                auth.ShowDialog(this);

                if (!string.IsNullOrEmpty(auth.AuthCode))
                {
                    bool b = false;
                    switch (provider)
                    {
                        case "drive":
                            b = Drive.Authorise(auth.AuthCode);
                            break;
                        case "youtube":
                            b = YouTubeUploader.Authorise(auth.AuthCode);
                            break;
                        case "dropbox":
                            b = Dropbox.Authorise(auth.AuthCode);
                            break;
                        case "onedrive":
                            b = OneDrive.Authorise(auth.AuthCode);
                            break;
                        case "flickr":
                            b = Flickr.Authorise(auth.AuthCode);
                            break;
                        case "box":
                            b = Box.Authorise(auth.AuthCode);
                            break;
                    }
                  

                    MessageBox.Show(this, b ? LocRm.GetString("OK") : LocRm.GetString("Failed")+": Please ensure your login details are correct and you don't have two factor authentication switched on for your cloud provider.");
                }
            }
        }

        private void flowLayoutPanel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            using (var pc = new PTZConfig())
            {
                pc.CameraControl = CameraControl;
                pc.ShowDialog(this);
            }
        }

        private void scheduleEditor1_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void chkFill_CheckedChanged(object sender, EventArgs e)
        {
           
            CameraControl.RC = Rectangle.Empty;
        }

        private void numProcessInterval_ValueChanged(object sender, EventArgs e)
        {
            CameraControl.Camobject.detector.processframeinterval = (int)numProcessInterval.Value;
        }

        private void rdoTrigger_CheckedChanged(object sender, EventArgs e)
        {
            CameraControl.Camobject.alerts.processmode = "trigger";
        }
        

        private void chkResize_CheckedChanged(object sender, EventArgs e)
        {
           
           
        }

        private void scheduleEditor1_Load(object sender, EventArgs e)
        {

        }
    }
}