using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Declarations;
using Declarations.Events;
using Declarations.Media;
using Declarations.Players;
using Implementation;
using iSpyApplication.Controls;
using iSpyApplication.Onvif;
using iSpyApplication.Sources.Video;
using iSpyApplication.Sources.Video.Ximea;
using iSpyApplication.Utilities;
using iSpyPRO.DirectShow;
using Microsoft.Kinect;
using Rectangle = System.Drawing.Rectangle;
using System.IO;

namespace iSpyApplication
{
    public partial class VideoSource : Form
    {
        private IVideoPlayer _player;
        private IMedia _media;
        private MediaPlayerFactory _factory;
        public CameraWindow CameraControl;
        public string CameraLogin;
        public string CameraPassword;
        public string FriendlyName = "";
        public int SourceIndex;
        public int VideoInputIndex = -1;
        public string VideoSourceString;
        public bool StartWizard = false;
        private bool _loaded;

        //do not put a comma in this description!
        public static string VideoFormatString = "{0} x {1} ({3} bit up to {2} fps)";
        public static string SnapshotFormatString = "{0} x {1} ({3} bit)";

        // collection of available video devices
        private readonly FilterInfoCollection _videoDevices;
        // selected video device
        private VideoCaptureDevice _videoCaptureDevice;

        // supported capabilities of video and snapshots
        private readonly Dictionary<string, VideoCapabilities> _videoCapabilitiesDictionary = new Dictionary<string, VideoCapabilities>();
        private readonly Dictionary<string, VideoCapabilities> _snapshotCapabilitiesDictionary = new Dictionary<string, VideoCapabilities>();

        // available video inputs
        private VideoInput[] _availableVideoInputs;

        // flag telling if user wants to configure snapshots as well
        private bool _configureSnapshots;

        public bool ConfigureSnapshots
        {
            get { return _configureSnapshots; }
            set
            {
                _configureSnapshots = value;
              
            }
        }

        /// <summary>
        /// Provides configured video device.
        /// </summary>
        /// 
        /// <remarks><para>The property provides configured video device if user confirmed
        /// the dialog using "OK" button. If user canceled the dialog, the property is
        /// set to <see langword="null"/>.</para></remarks>
        /// 
        internal VideoCaptureDevice VideoDevice => _videoCaptureDevice;

        private string _videoDeviceMoniker = string.Empty;
        private Size _captureSize = new Size(0, 0);
        private Size _snapshotSize = new Size(0, 0);
        public int FrameRate;
        private VideoInput _videoInput = VideoInput.Default;

        /// <summary>
        /// Moniker string of the selected video device.
        /// </summary>
        /// 
        /// <remarks><para>The property allows to get moniker string of the selected device
        /// on form completion or set video device which should be selected by default on
        /// form loading.</para></remarks>
        /// 
        public string VideoDeviceMoniker
        {
            get { return _videoDeviceMoniker; }
            set { _videoDeviceMoniker = value; }
        }

        /// <summary>
        /// Video frame size of the selected device.
        /// </summary>
        /// 
        /// <remarks><para>The property allows to get video size of the selected device
        /// on form completion or set the size to be selected by default on form loading.</para>
        /// </remarks>
        /// 
        public Size CaptureSize
        {
            get { return _captureSize; }
            set { _captureSize = value; }
        }

        /// <summary>
        /// Snapshot frame size of the selected device.
        /// </summary>
        /// 
        /// <remarks><para>The property allows to get snapshot size of the selected device
        /// on form completion or set the size to be selected by default on form loading
        /// (if <see cref="ConfigureSnapshots"/> property is set <see langword="true"/>).</para>
        /// </remarks>
        public Size SnapshotSize
        {
            get { return _snapshotSize; }
            set { _snapshotSize = value; }
        }

        public VideoSource()
        {
            InitializeComponent();
            RenderResources();

            bool empty = true;
            // show device list
            try
            {
                // enumerate video devices
                _videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (_videoDevices.Count > 0)
                {
                    foreach (iSpyPRO.DirectShow.FilterInfo device in _videoDevices)
                    {
                      
                    }
                    empty = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
            if (empty)
            {
                ListEmptyCaptureDevices();
            }

        }

        private void ListEmptyCaptureDevices()
        {
            
        }

        private object[] ObjectList(string str)
        {
            string[] ss = str.Split('|');
            var o = new object[ss.Length];
            int i = 0;
            foreach(string s in ss)
            {
                o[i] = s;
                i++;
            }
            return o;
        }

        private void VideoSourceLoad(object sender, EventArgs e)
        {
            UISync.Init(this);
         
            ConfigureSnapshots = true;

         

            VideoSourceString = CameraControl.Camobject.settings.videosourcestring;
            
            SourceIndex = CameraControl.Camobject.settings.sourceindex;
            if (SourceIndex == 3)
            {
                VideoDeviceMoniker = VideoSourceString;
                string[] wh= CameraControl.Camobject.resolution.Split('x');
                CaptureSize = new Size(Convert.ToInt32(wh[0]), Convert.ToInt32(wh[1]));
            }
            
           
            switch (SourceIndex)
            {
                case 0:
                  
                    break;
                case 1:
                   
                    break;
                case 2:
                   
                    break;
                case 3:
                  
                    break;
                case 5:
                  
                    break;
                case 8:
                  
                    switch (NV("custom"))
                    {
                        default:
                           
                            break;
                    }
                    break;
                case 10:
                    int id;
                    if (Int32.TryParse(VideoSourceString, out id))
                    {
                       
                    }
                    break;
            }
            onvifWizard1.CameraControl = CameraControl;

           

           
            int selectedCameraIndex = 0;

            for (int i = 0; i < _videoDevices.Count; i++)
            {
                if (_videoDeviceMoniker == _videoDevices[i].MonikerString)
                {
                    selectedCameraIndex = i;
                    break;
                }
            }

         


            SetSourceIndex(SourceIndex);

            if (CameraControl?.Camera?.VideoSource is VideoCaptureDevice)
            {
                _videoCaptureDevice = (VideoCaptureDevice)CameraControl.Camera.VideoSource;
                _videoInput = _videoCaptureDevice.CrossbarVideoInput;
                EnumeratedSupportedFrameSizes();
            }


            //ximea

            int deviceCount = 0;

            try
            {
                deviceCount = XimeaCamera.CamerasCount;
            }
            catch(Exception)
            {
                //Ximea DLL not installed
                //Logger.LogMessage("This is not a XIMEA device");
            }

         

       
        

        
        
         
           

            onvifWizard1.CameraControl = CameraControl;
            _loaded = true;
            if (StartWizard) Wizard();

        }


        private void SetSourceIndex(int sourceIndex)
        {
            switch (sourceIndex)
            {
                case 0:
                   
                    break;
                case 1:
                   
                    break;
                case 2:
     
                    break;
                case 3:
        
                    break;
                case 4:
            
                    break;
                case 5:
          
                    break;
                case 6:
              
                    break;
                case 7:
                 
                    break;
                case 8:
               
                    break;
                case 9:
                    tcSource.SelectedTab = tabPage10;
                    break;
                case 10:
               
                    break;
            }

            if (tcSource.SelectedTab==null)  {
                if (tcSource.TabCount == 0)
                {
                    MessageBox.Show(this,LocRm.GetString("CouldNotDisplayControls"));
                    Close();
                }
                else
                {
                    tcSource.SelectedIndex = 0;
                }
            }
        }
        
        private string NV(string name)
        {
            return Helper.NVLookup(CameraControl, name);
        }

        private void RenderResources()
        {
            Text = LocRm.GetString("VideoSource");
            button1.Text = LocRm.GetString("Ok");
            button2.Text = LocRm.GetString("Cancel");
         
            HideTab(tabPage10, Helper.HasFeature(Enums.Features.Source_ONVIF));
           
  
        }
        private void HideTab(TabPage t, bool show)
        {
            if (!show)
            {
                tcSource.TabPages.Remove(t);
            }
        }

        private void Button1Click(object sender, EventArgs e)
        {
            SetupVideoSource();
        }

        private void SetPTZPort()
        {
            try
            {
                var u = new Uri(VideoSourceString);
                if (u.Scheme.StartsWith("http"))
                {
                    CameraControl.Camobject.settings.ptzport = u.Port;
                }
            }
            catch
            {
                //invalid URI
            }

        }

        private void SetupVideoSource()
        {
            StopPlayer();
      
           
            string nv="";

            SourceIndex = GetSourceIndex();

            CameraLogin = CameraPassword = "";


            FriendlyName = "Camera " + MainForm.Cameras.Count;
            string url;
            switch (SourceIndex)
            {
                case 0:
                  
                    break;
                case 1:
                  
                    break;
                case 2:
                   
                    break;
                case 3:
                    
                    break;
                case 4:
                    
                  
                break;
                case 5:
                  
                    break;
                case 6:
                  
                    break;
                case 7:
                 
                    break;
                case 8:
                   
                    break;
                case 9:

                    var cfg = onvifWizard1.lbOnvifURLs.SelectedItem as ONVIFDevice.MediaEndpoint;
                    if (cfg == null)
                    {
                        MessageBox.Show(LocRm.GetString("Validate_SelectCamera"), LocRm.GetString("Note"));
                        return;
                    }

                    url = cfg.Uri.Uri;
                    string writePath = "Requst/source_selected.txt";
                    StreamWriter info_source = new StreamWriter(writePath);
                    info_source.WriteLine(url);
                    info_source.Close();
                    MessageBox.Show("fdf", url);

                    CameraLogin = onvifWizard1.txtOnvifUsername.Text;
                    CameraPassword = onvifWizard1.txtOnvifPassword.Text;
                    VideoSourceString = CameraControl.Camobject.settings.onvifident = onvifWizard1.ddlDeviceURL.Text;
                    nv = "profilename=" + onvifWizard1.lbOnvifURLs.SelectedIndex.ToString() + ",use=" + (onvifWizard1.ddlConnectWith.SelectedIndex == 0 ? "FFMPEG" : "VLC");
                    
                    CameraControl.Camobject.ptz = -5;//onvif
                    CameraControl.Camobject.settings.rtspmode = onvifWizard1.ddlTransport.SelectedIndex;
                    CameraControl.Camobject.settings.onvif.rtspport = (int)onvifWizard1.numRTSP.Value;
                    SetVideoSize(new Size(cfg.Width, cfg.Height));

             
                    break;
                case 10:
                    
                    break;
            }
            CameraControl.Camobject.settings.namevaluesettings = nv;

            if (!Helper.HasFeature(Enums.Features.Recording))
            {
                CameraControl.Camobject.detector.recordonalert = false;
                CameraControl.Camobject.detector.recordondetect = false;
            }

            string t = FriendlyName;
            int i = 1;
            while (MainForm.Cameras.FirstOrDefault(p => p.name == t) != null)
            {
                t = FriendlyName + " (" + i + ")";
                i++;
            }

            FriendlyName = t;
            

            if (string.IsNullOrEmpty(VideoSourceString))
            {
                MessageBox.Show(LocRm.GetString("Validate_SelectCamera"), LocRm.GetString("Note"));
                return;
            }

            if (!MainForm.Conf.RecentFileList.Contains(MainForm.Conf.AVIFileName) &&
                MainForm.Conf.AVIFileName != "")
            {
                MainForm.Conf.RecentFileList =
                    (MainForm.Conf.RecentFileList + "|" + MainForm.Conf.AVIFileName).Trim('|');
            }
            if (!MainForm.Conf.RecentJPGList.Contains(MainForm.Conf.JPEGURL) &&
                MainForm.Conf.JPEGURL != "")
            {
                MainForm.Conf.RecentJPGList =
                    (MainForm.Conf.RecentJPGList + "|" + MainForm.Conf.JPEGURL).Trim('|');
            }
            if (!MainForm.Conf.RecentMJPGList.Contains(MainForm.Conf.MJPEGURL) &&
                MainForm.Conf.MJPEGURL != "")
            {
                MainForm.Conf.RecentMJPGList =
                    (MainForm.Conf.RecentMJPGList + "|" + MainForm.Conf.MJPEGURL).Trim('|');
            }
            if (!MainForm.Conf.RecentVLCList.Contains(MainForm.Conf.VLCURL) &&
                MainForm.Conf.VLCURL != "")
            {
                MainForm.Conf.RecentVLCList =
                    (MainForm.Conf.RecentVLCList + "|" + MainForm.Conf.VLCURL).Trim('|');
            }
           
            

            DialogResult = DialogResult.OK;
            Close();
        }

        private void Button2Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cmbJPEGURL_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbJPEGURL_Click(object sender, EventArgs e)
        {
        }

        private void cmbMJPEGURL_Click(object sender, EventArgs e)
        {
        }

        private void cmbFile_TextChanged(object sender, EventArgs e)
        {
        }


        private void cmbFile_Click(object sender, EventArgs e)
        {
        }


        private void VideoSource_FormClosing(object sender, FormClosingEventArgs e)
        {
            onvifWizard1.Deinit();
        }


        private void cmbFile_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbMJPEGURL_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ddlScreen_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void LinkLabel2LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm.OpenUrl( MainForm.Website+"/sources.aspx");
        }

        private void LinkLabel1LinkClicked1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm.OpenUrl( MainForm.Website+"/sources.aspx");
        }

        private void LinkLabel3LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(this,
                Program.Platform == "x64"
                    ? LocRm.GetString("InstallVLCx64")
                        .Replace("[DIR]", Environment.NewLine + Program.AppPath + "VLC64" + Environment.NewLine)
                    : LocRm.GetString("InstallVLCx86"));
            MainForm.OpenUrl(Program.Platform == "x64" ? MainForm.VLCx64 : MainForm.VLCx86);
        }

        private void pnlVLC_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Button4Click(object sender, EventArgs e)
        {
            TestVLC();
        }

        private void TestVLC()
        {
           
          
         
            StopPlayer();
            try
            {
               
                _player.Open(_media);
                _player.Mute = true;
                _player.Events.PlayerPositionChanged += EventsPlayerPositionChanged;
                _player.Events.PlayerEncounteredError += EventsPlayerEncounteredError;
                _player.CustomRenderer.SetCallback(bmp => bmp.Dispose());
                _player.CustomRenderer.SetFormat(new BitmapFormat(100, 100, ChromaType.RV24));

                _player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, LocRm.GetString("Error"));
            }
        }

        private void EventsPlayerEncounteredError(object sender, EventArgs e)
        {
            _player.Events.PlayerPositionChanged -= EventsPlayerPositionChanged;
            _player.Events.PlayerEncounteredError -= EventsPlayerEncounteredError;
            UISync.Execute(StopPlayer);
            MessageBox.Show("VLC Error", LocRm.GetString("Error"));
        
        }

        private void SetVideoSize(Size size)
        {
            CameraControl.Camobject.settings.vlcWidth = size.Width;
            CameraControl.Camobject.settings.vlcHeight = size.Height;
            _vlcStreamSizeSet = true;
        }

        private bool _vlcStreamSizeSet = false;

        private void StopPlayer()
        {
            if (_player != null)
            {
                _player.Stop();
                _player.Dispose();
                _player = null;
            }
            if (_media!=null)
            {
                _media.Dispose();
                _media = null;
            }
            if (_factory != null)
            {
                _factory.Dispose();
                _factory = null;
            }

        }

        private void EventsPlayerPositionChanged(object sender, MediaPlayerPositionChanged e)
        {
            Size size = _player.GetVideoSize(0);
            if (!size.IsEmpty)
            {
                _player.Events.PlayerPositionChanged -= EventsPlayerPositionChanged;
                _player.Events.PlayerEncounteredError -= EventsPlayerEncounteredError;
                UISync.Execute(() => SetVideoSize(size));
                UISync.Execute(StopPlayer);
             
            }
        }

        #region Nested type: UISync

        private class UISync
        {
            private static ISynchronizeInvoke _sync;

            public static void Init(ISynchronizeInvoke sync)
            {
                _sync = sync;
            }

            public static void Execute(Action action)
            {
                try
                {
                    _sync.BeginInvoke(action, null);
                }
                catch
                {
                }
            }
        }

        #endregion

        private void ddlXimeaDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConnectXimea();
        }


        private void ConnectXimea()
        {
        

        }

        private void devicesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void offsetYUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private int GetSourceIndex()
        {
            int sourceIndex = 0;
    
      
            if (tcSource.SelectedTab.Equals(tabPage10))
                sourceIndex = 9;
         
            return sourceIndex;
        }

        private void llblHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = MainForm.Website+"/userguide-connecting-cameras.aspx";



            switch (GetSourceIndex())
            {
                case 0:
                    url = MainForm.Website+"/userguide-connecting-cameras.aspx#4";
                    break;
                case 1:
                    url = MainForm.Website+"/userguide-connecting-cameras.aspx#4";
                    break;
                case 2:
                    url = MainForm.Website+"/userguide-connecting-cameras.aspx";
                    break;
                case 3:
                    url = MainForm.Website+"/userguide-connecting-cameras.aspx#2";
                    break;
                case 4:
                    url = MainForm.Website+"/userguide-connecting-cameras.aspx#6";
                    break;
                case 5:
                    url = MainForm.Website+"/userguide-connecting-cameras.aspx#5";
                    break;
                case 6:
                    url = MainForm.Website+"/userguide-connecting-cameras.aspx#7";
                    break;
                case 7:
                    url = MainForm.Website+"/userguide-connecting-cameras.aspx#8";
                    break;
                case 9:
                    url = MainForm.Website + "/userguide-connecting-cameras.aspx#9";
                    break;
            }
            MainForm.OpenUrl( url);
        }

        private void combo_dwnsmpl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loaded)
                return;
           
        }

        private void numXimeaExposure_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numXimeaGain_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Wizard();
        }

        private void Wizard()
        {
            using (var fc = new FindCameras())
            {
                if (fc.ShowDialog(this) != DialogResult.OK) return;
                SetSourceIndex(fc.VideoSourceType);
                
           
                CameraControl.Camobject.settings.cookies = fc.Cookies;

                CameraControl.Camobject.settings.tokenconfig.tokenpath = fc.tokenPath;
                CameraControl.Camobject.settings.tokenconfig.tokenpost = fc.tokenPost;
                CameraControl.Camobject.settings.tokenconfig.tokenport = fc.tokenPort;

                switch (fc.VideoSourceType)
                {
                    case 0:
                
                        break;
                    case 1:
                                                      
                        break;
                    case 2:
                      
                        break;
                    case 5:
                      
                        break;
                    case 9:
                        onvifWizard1.ddlDeviceURL.Text = fc.FinalUrl;
                        onvifWizard1.GoStep1();
                        return;
                }

                if (!string.IsNullOrEmpty(fc.Flags))
                {
                    string[] flags = fc.Flags.Split(',');
                    foreach (string f in flags)
                    {
                        if (string.IsNullOrEmpty(f)) continue;
                        switch (f.ToUpper())
                        {
                            case "FBA":
                                CameraControl.Camobject.settings.forcebasic = true;
                                break;
                        }
                    }
                }
                if (fc.Ptzid > -1)
                {
                    CameraControl.Camobject.ptz = fc.Ptzid;
                    CameraControl.Camobject.ptzentryindex = fc.Ptzentryid;
                    CameraControl.Camobject.settings.ptzchannel = fc.Channel;

                    CameraControl.Camobject.settings.ptzusername = fc.Username;
                    CameraControl.Camobject.settings.ptzpassword = fc.Password;
                }

                if (!string.IsNullOrEmpty(fc.AudioModel))
                {
                    var uri = new Uri(fc.FinalUrl);
                    if (!string.IsNullOrEmpty(uri.DnsSafeHost))
                    {
                        CameraControl.Camobject.settings.audioip = uri.DnsSafeHost;
                    }
                    CameraControl.Camobject.settings.audiomodel = fc.AudioModel;
                    CameraControl.Camobject.settings.audioport = uri.Port;
                    CameraControl.Camobject.settings.audiousername = fc.Username;
                    CameraControl.Camobject.settings.audiopassword = fc.Password;
                }
                SetupVideoSource();

                CameraControl.Camobject.name = FriendlyName;

                if (fc.AudioSourceType > -1)
                {
                    var vc = CameraControl.VolumeControl;
                    if (vc == null)
                    {
                        vc = MainForm.InstanceReference.AddCameraMicrophone(CameraControl.Camobject.id,
                            CameraControl.Camobject.name + " mic");
                        CameraControl.Camobject.settings.micpair = vc.Micobject.id;
                        vc.Micobject.alerts.active = false;
                        vc.Micobject.detector.recordonalert = false;
                        vc.Micobject.detector.recordondetect = false;
                        CameraControl.SetVolumeLevel(vc.Micobject.id);
                    }
                    vc.Disable();
                    vc.Micobject.settings.typeindex = fc.AudioSourceType;
                    vc.Micobject.settings.sourcename = fc.AudioUrl;
                    vc.Micobject.settings.needsupdate = true;
                }
                FriendlyName = CameraControl.Camobject.name;
                CameraLogin = fc.Username;
                CameraPassword = fc.Password;
            }
        }

        private void devicesCombo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (_videoDevices.Count != 0)
            {
               
                EnumeratedSupportedFrameSizes();
            }
        }

        // Collect supported video and snapshot sizes
        private void EnumeratedSupportedFrameSizes()
        {
            Cursor = Cursors.WaitCursor;

       
            _snapshotCapabilitiesDictionary.Clear();
            _videoCapabilitiesDictionary.Clear();
            try
            {
                // collect video capabilities
                VideoCapabilities[] videoCapabilities = _videoCaptureDevice.VideoCapabilities;
                int videoResolutionIndex = 0;
                string precfg = NV("video");
                foreach (VideoCapabilities capabilty in videoCapabilities)
                {
                    if (capabilty!=null)
                    {
                        //do not put a comma in this description!
                        string item = string.Format(VideoFormatString, capabilty.FrameSize.Width,
                            Math.Abs(capabilty.FrameSize.Height), capabilty.AverageFrameRate, capabilty.BitCount);

                     

                        if (!_videoCapabilitiesDictionary.ContainsKey(item))
                        {
                            _videoCapabilitiesDictionary.Add(item, capabilty);
                        }
                    }
                }

                if (videoCapabilities.Length == 0)
                {
                   
                }
                else
                {
                  
                }


                if (ConfigureSnapshots)
                {
                    // collect snapshot capabilities
                    VideoCapabilities[] snapshotCapabilities = _videoCaptureDevice.SnapshotCapabilities;
                    int snapshotResolutionIndex = 0;

                    precfg = NV("snapshots");

                    foreach (VideoCapabilities capabilty in snapshotCapabilities)
                    {
                        //do not put a comma in this description!
                        string item = string.Format(SnapshotFormatString, capabilty.FrameSize.Width,
                            Math.Abs(capabilty.FrameSize.Height), capabilty.AverageFrameRate, capabilty.BitCount);

                      
                    }

                  
                }

                // get video inputs
                _availableVideoInputs = _videoCaptureDevice.AvailableCrossbarVideoInputs;
                int videoInputIndex = -1;

                foreach (VideoInput input in _availableVideoInputs)
                {
                    string item = $"{input.Index}: {input.Type}";

                   
                }

                if (_availableVideoInputs.Length == 0)
                {
                   
                }
                else
                {
                  
                }


            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            
        }

        private void videoResolutionsCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void videoInputsCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }



        private void chkMousePointer_CheckedChanged(object sender, EventArgs e)
        {
            if (CameraControl != null && CameraControl.Camera != null && CameraControl.Camera.VideoSource is DesktopStream)
            {
               
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
  
         
       
            
            Rectangle area = Rectangle.Empty;
            if (!string.IsNullOrEmpty(CameraControl.Camobject.settings.desktoparea))
            {
                var i = System.Array.ConvertAll(CameraControl.Camobject.settings.desktoparea.Split(','), int.Parse);
                area = new Rectangle(i[0],i[1],i[2],i[3]);
            }

       
                          
           
          
            
        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtVLCArgs_PastedText(object sender, ClipboardEventArgs e)
        {
            //reformat VLC local arguments to input arguments
            Clipboard.SetText(e.ClipboardText.Trim().Replace(":", Environment.NewLine+"-").Trim());

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm.OpenUrl(MainForm.Website+"/userguide-vlc.aspx");
        }

        private void snapshotResolutionsCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void chkKinectSkeletal_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Video Files|*.*";
            ofd.InitialDirectory = Program.AppPath;
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
               
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var s = CameraControl.Camobject.resolution;
            var vsa = new VideoSourceAdvanced {Camobject = CameraControl.Camobject};
            vsa.ShowDialog(this);
            vsa.Dispose();
            if (s!=CameraControl.Camobject.resolution)
                CameraControl.NeedSizeUpdate = true;
        }

        

        private void tcSource_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private MediaStream vfr;

        private void btnTest_Click(object sender, EventArgs e)
        {
          
            
        }

        private void Vfr_PlayingFinished(object sender, Sources.PlayingFinishedEventArgs e)
        {
           
        }

        private void Vfr_ErrorHandler(string message)
        {
          
        }

        private void Vfr_NewFrame(object sender, Sources.NewFrameEventArgs e)
        {
            vfr.NewFrame -= Vfr_NewFrame;
            if (e.Frame == null)
            {
                UISync.Execute(() => {MessageBox.Show(this, "Connection Failed");});
            }
            else
            {
                UISync.Execute(() => { MessageBox.Show(this, "Connected!"); });
            }

            vfr.Close();
        }

        private void numAnalyseDuration_ValueChanged(object sender, EventArgs e)
        {

        }

        private void chkUseGPU_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void onvifWizard1_Load(object sender, EventArgs e)
        {

        }
    }
    
    
}