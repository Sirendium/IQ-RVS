using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using System.Threading;
using System.Windows.Forms;
using iSpyApplication.Cloud;
using iSpyApplication.Controls;
using iSpyApplication.Properties;
using iSpyApplication.Utilities;

namespace iSpyApplication
{
    partial class MainForm
    {
        internal void SelectMediaRange(PreviewBox controlFrom, PreviewBox controlTo)
        {
            lock (ThreadLock)
            {
                if (controlFrom != null && controlTo != null)
                {
                  
                }
              
            }
        }

        private readonly Queue<string> _toDelete = new Queue<string>();
        private Thread _tDelete;

        internal void MediaDeleteSelected()
        {
            if (InvokeRequired)
            {
                Invoke(new Delegates.SimpleDelegate(MediaDeleteSelected));
                return;
            }
           
            lock (ThreadLock)
            {
               
            }
          
            _needsDelete = true;
        }

        private void DeleteFiles()
        {
            while (_toDelete.Count > 0)
            {
                var s = _toDelete.Dequeue();
                FileOperations.Delete(s);

                string[] parts = s.Split('\\');
                string fn = parts[parts.Length - 1];
                if (!fn.EndsWith(".mp3") && !fn.EndsWith(".wav"))
                {
                    //preview
                    string dir = s.Substring(0, s.LastIndexOf("\\", StringComparison.Ordinal));

                    var lthumb = dir + @"\thumbs\" + fn.Substring(0, fn.LastIndexOf(".", StringComparison.Ordinal)) +
                                 "_large.jpg";
                    FileOperations.Delete(lthumb);

                    lthumb = dir + @"\thumbs\" + fn.Substring(0, fn.LastIndexOf(".", StringComparison.Ordinal)) + ".jpg";
                    FileOperations.Delete(lthumb);
                }
            }
        }

        public void MediaArchiveSelected()
        {
            if (String.IsNullOrWhiteSpace(Conf.ArchiveNew))
            {
                MessageBox.Show(this, LocRm.GetString("SpecifyArchiveLocation"));
                ShowSettings(2);
            }
            if (!String.IsNullOrWhiteSpace(Conf.ArchiveNew))
            {
                int j = 0;
                string msg = "";
                lock (ThreadLock)
                {
                    
                }
                if (j > 0 && msg!="NOK")
                    MessageBox.Show(this, LocRm.GetString("MediaArchivedTo") +Environment.NewLine+ msg);
            }

        }

        private void DeletePreviewBox(PreviewBox pb)
        {
            _toDelete.Enqueue(pb.FileName);

            string[] parts = pb.FileName.Split('\\');
            string fn = parts[parts.Length - 1];

            try
            {
               
                switch (pb.Otid)
                {
                    case 1:
                        var vl = GetVolumeLevel(pb.Oid);
                        vl?.RemoveFile(fn);
                        break;
                    case 2:
                        var cw = GetCameraWindow(Convert.ToInt32(pb.Oid));
                        cw?.RemoveFile(fn);
                        break;
                }


               
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
        
            pb.MouseDown -= PbMouseDown;
            pb.MouseEnter -= PbMouseEnter;
            pb.Dispose();

            NeedsMediaRefresh = Helper.Now;
            _needsDelete = true;
           
        }

        

        public void LoadPreviews()
        {
            
        }

        private void RenderPreviewBoxes()  {

            lock (ThreadLock)
            {
                if (MediaPanelPage * Conf.PreviewItems > MasterFileList.Count-1)
                {
                    MediaPanelPage = 0;
                }

                if (Filter.Filtered)
                {
                    var l = MasterFileList.Where(
                            p =>
                            ((p.ObjectTypeId == 2 && Filter.CheckedCameraIDs.Contains(p.ObjectId)) ||
                             (p.ObjectTypeId == 1 && Filter.CheckedMicIDs.Contains(p.ObjectId))) &&
                            p.CreatedDateTicks > Filter.StartDate.Ticks && p.CreatedDateTicks < Filter.EndDate.Ticks).ToList
                            ();
                    int pageCount = (l.Count - 1) / Conf.PreviewItems + 1;

                    var displayList = l.OrderByDescending(p => p.CreatedDateTicks).Skip(MediaPanelPage * Conf.PreviewItems).Take(Conf.PreviewItems).ToList();
                    RenderList(displayList, pageCount);

                }
                else
                {
                    var displayList = MasterFileList.OrderByDescending(p => p.CreatedDateTicks).Skip(MediaPanelPage * Conf.PreviewItems).Take(Conf.PreviewItems).ToList();
                    int pageCount = (MasterFileList.Count - 1) / Conf.PreviewItems + 1;
                    RenderList(displayList,pageCount);
                }
               
                
                   
            }
        }

        private void RenderList(List<FilePreview> l, int pageCount )
        {
            
           

            var currentList = new List<PreviewBox>();
            
          

            int ci = 0;
            DateTime dtCurrent = DateTime.MinValue;
            bool first = true;
            foreach (FilePreview fp in l)
            {
                var dt = new DateTime(fp.CreatedDateTicks);
                if (first || dtCurrent.DayOfYear != dt.DayOfYear)
                {
                    first = false;
                    dtCurrent = dt;
                    DateTime tag = new DateTime(dtCurrent.Year, dtCurrent.Month, dtCurrent.Day);
                    var lb = new Label { Text = dtCurrent.ToShortDateString(), Tag = tag, Margin = new Padding(3), Padding = new Padding(0), ForeColor = Color.White, BackColor = Color.Black, Width=96, Height=73, TextAlign = ContentAlignment.MiddleCenter};
                    lb.Click += Lb_Click;
                    lb.Cursor = Cursors.Hand;
                   
                    ci++;
                }
                var cdt = new DateTime(fp.CreatedDateTicks);
                var pb = currentList.FirstOrDefault(p => p.CreatedDate == cdt);
                if (pb == null)
                {
                    FilePreview fp1 = fp;
                    var dir = Helper.GetMediaDirectory(fp1.ObjectTypeId, fp1.ObjectId);
                    switch (fp1.ObjectTypeId)
                    {
                        case 1:
                            var v = Microphones.SingleOrDefault(p => p.id == fp1.ObjectId);
                            if (v != null)
                            {
                                var filename = dir + "audio\\" + v.directory + "\\" + fp.Filename;
                                pb = AddPreviewControl(fp1,Resources.audio, filename, v.name);
                            }
                            break;
                        case 2:
                            var c = Cameras.SingleOrDefault(p => p.id == fp1.ObjectId);
                            if (c != null)
                            {
                                var filename = dir + "video\\" + c.directory + "\\" + fp.Filename;
                                var thumb = dir + "video\\" + c.directory + "\\thumbs\\" +
                                            fp.Filename.Substring(0,
                                                                  fp.Filename.LastIndexOf(".", StringComparison.Ordinal)) +
                                            ".jpg";
                                pb = AddPreviewControl(fp1,thumb, filename, c.name);
                            }
                            break;
                    }

                }
                if (pb != null)
                {
                    
                    ci++;
                }
            }

          
            NeedsMediaRebuild = false;
        }

        private void Lb_Click(object sender, EventArgs e)
        {
            var dt = (DateTime)((Label) sender).Tag;
            var dtTo = dt.AddDays(1);
            bool f = true, s = false;
          
            

        }

        public void RemovePreviewByFileName(string fn)
        {
            lock (ThreadLock)
            {
               
            }
        }

        internal void MediaBack()
        {
            MediaPanelPage--;
            if (MediaPanelPage < 0)
                MediaPanelPage = 0;
            else
            {
               
              
                LoadPreviews();
            }
        }


        internal void MediaNext()
        {
            MediaPanelPage++;
            if (MediaPanelPage * Conf.PreviewItems >= MasterFileList.Count)
                MediaPanelPage--;
            else
            {
               
                LoadPreviews();
            }
        }

        internal void MediaPage()
        {
            var p = new Pager();
            int i = MediaPanelPage;
            p.ShowDialog(this);
            if (i != MediaPanelPage)
            {
               
              
                LoadPreviews();
            }
        }

        internal void MediaUploadCloud()
        {
            if (!Conf.Subscribed)
            {
                var ns = new NotSubscribed();
                ns.ShowDialog(this);
                return;
            }

            string msg = "";
            lock (ThreadLock)
            {
               
            }
            if (msg != "")
                MessageBox.Show(this, LocRm.GetString(msg));
            
        }

        internal void MediaUploadYouTube()
        {
            if (!Conf.Subscribed)
            {
                var ns = new NotSubscribed();
                ns.ShowDialog(this);
                return;
            }

            string msg = "";
            lock (ThreadLock)
            {
                
            }
            if (msg != "")
                MessageBox.Show(this, LocRm.GetString(msg));
        }


        internal void MergeMedia()
        {
            using (var m = new Merger {MainClass = this})
            {
                m.ShowDialog(this);
            }

        }
    }
}
