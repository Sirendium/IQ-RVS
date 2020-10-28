using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.Concurrent;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using System.Threading;
using System.Windows.Forms;
using NsrRadarSdk;
using NsrRadarSdk.NsrTypes;
using System.IO;
namespace iSpyApplication
{
    public partial class ConnectRadar : Form
    {
        NsrRadar _radarSelected;
        private ConcurrentDictionary<string, NsrRadar> _radars;
        public ConnectRadar()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            _radars = new ConcurrentDictionary<string, NsrRadar>();
            NsrSdk.Instance.Init(9000, true); // int localPort,bool useTcp
            NsrSdk.Instance.Timeout = 3000; // //Получить или установить время ожидания (мс) для получения сообщения с радара.
            try
            {
                NsrSdk.Instance.StartReceiveBroadcast(RadarBroadcast);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            NsrSdk.Instance.TargetDetect += FormTestRadar_TargetDetect; // Распознования объекта
            NsrSdk.Instance.RadarOnlineStateChanged += _manager_RadarConnect;
            dataGridView1.AutoGenerateColumns = false;

            UpdateRadars();
            
        }
        private void RadarBroadcast(NsrRadar radar, ref RVS_PARAM_BROADCAST info)
        {
            if (radar.Ip == "192.168.61.123" && radar.Online == false)
            {
                try
                {
                     radar.Connect();
                }
                catch (Exception)
                {

                }
            }
            if (_radars.ContainsKey(radar.Ip))
                return;

            _radars[radar.Ip] = radar;

            this.BeginInvoke(new Action(() =>
            {
                UpdateRadars();
            }));
        }

        void UpdateRadars()
        {
            dataGridView1.DataSource = _radars.Values;
          
        }

        void _manager_RadarConnect(NsrRadar radar, bool online)
        {
            this.BeginInvoke(new Action(() =>
            {
                UpdateRadars();
            }));
        }
  
        /// <summary>
        /// format target info and append to the textbox
        /// </summary>
        /// <param name="radar"></param>
        void FormTestRadar_TargetDetect(NsrRadar radar, RVS_Target_List targetList)
        {

            StringBuilder sb = new StringBuilder(targetList.TargetNum * 40);
            DateTime now = DateTime.Now;

            foreach (var item in targetList.Targets)
            {
               
                sb.AppendLine(string.Format("X=\t{0}\t, Y=\t{1}\t, Time\t{2}", item.X.ToString("F2"),
                item.Y.ToString("F2"), now.ToString()));
                TextInfo.Text = sb.ToString();
                
            }
            //////////////////////////////////////////
            StreamReader f1 = new StreamReader("InfoBOX.txt");
            string info_box = f1.ReadToEnd();
            f1.Close();
            info_box += sb.ToString();
            ///////////////////////////////////
            StreamWriter f = new StreamWriter("InfoBOX.txt", true);
            f.WriteLine(info_box);  
            f.Close();
            ////////////////////////////////
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_radarSelected == null)
                {
                    MessageBox.Show("Please select alarm radar)");
                    return;
                    
                }
                int nHeartTime = int.Parse(radar_HeartTime.Text);

                if (nHeartTime <= 0 || nHeartTime > 60)
                {

                    MessageBox.Show("HeartTime >0 &&HeartTime<60");
                    return;
                }
                if (_radarSelected.SetHeartTime((byte)nHeartTime))
                {
                    select();
                    MessageBox.Show("Set successfully");
                }
                else
                {
                    MessageBox.Show("Set failure)");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log.Error(ex.ToString());
            }
        }
        public void Draw_radar_vision()
        {

        }
        public void button2_Click(object sender, EventArgs e)
        {
          
            ///////////////////////////////////////////////////

            if (_radarSelected == null)
            {
                MessageBox.Show("Please select alarm radar)");
                return;
            }

            PointF[] pts = new PointF[4];
         
            try
            {
                pts[0].X = float.Parse(qqTextBoxEx_radar_x1.Text);
                pts[0].Y = float.Parse(qqTextBoxEx_radar_y1.Text);
                pts[1].X = float.Parse(qqTextBoxEx_radar_x2.Text);
                pts[1].Y = float.Parse(qqTextBoxEx_radar_y2.Text);
                pts[2].X = float.Parse(qqTextBoxEx_radar_x3.Text);
                pts[2].Y = float.Parse(qqTextBoxEx_radar_y3.Text);
                pts[3].X = float.Parse(qqTextBoxEx_radar_x4.Text);
                pts[3].Y = float.Parse(qqTextBoxEx_radar_y4.Text);
                _radarSelected.SetCoordinate(pts);
                StreamWriter Area = new StreamWriter("area.txt");
                Area.WriteLine((pts.ToString()));
         
                //////////////////////////Area///////////////////
                Area.Close();
                select();
                MessageBox.Show("Set successfully");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log.Error(ex.ToString());
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (_radarSelected == null)
                {
                    MessageBox.Show("Please select alarm radar)");
                    return;
                }
                int nHeartTime = int.Parse(radar_HeartTime.Text);

                if (nHeartTime <= 0 || nHeartTime > 60)
                {

                    MessageBox.Show("HeartTime >0 &&HeartTime<60");
                    return;
                }
                if (_radarSelected.SetHeartTime((byte)nHeartTime))
                {
                    select();
                    MessageBox.Show("Set successfully");
                }
                else
                {
                    MessageBox.Show("Set failure)");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log.Error(ex.ToString());
            }
        }
        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                if (e.RowIndex < 0)
                    return;

                textBox7.Clear();   
                select();
                return;
            }

            dataGridView1.ClearSelection();
            var hit = e;
            if (hit.RowIndex >= 0)
            {
                dataGridView1.Rows[hit.RowIndex].Selected = true;
                if (hit.ColumnIndex >= 0)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[hit.RowIndex].Cells[hit.ColumnIndex];
                }
                else
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[hit.RowIndex].Cells[0];
                }

            }

        }
        void select()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    string ip = dataGridView1.CurrentRow.Cells["RadarIP"].Value.ToString();
                    NsrRadar radar = _radars[ip];
                    radar.Connect();
                    _radarSelected = radar;

                    if (radar != null)
                    {
                        rvs_PARAM_STATUS state = new rvs_PARAM_STATUS();
                        if (radar.GetStatus(ref state))
                        {
                            textBox1.Text = "0x" + state.addr.ToString("x2");
                            textBox2.Text = state.heart.time.ToString();
                            textBox3.Text = state.bee.IsOpen.ToString();
                            textBox4.Text = state.radarVerInfo.FirmwareVersion;
                            textBox5.Text = state.radarVerInfo.AlgorithmVersion;
                            textBox6.Text = state.radarVerInfo.FpgaVersion;
                            textBox7.Clear();
                            for (int i = 0; i < radar.PtsAlarmAreaVertices.Length; i++)
                            {
                                textBox7.AppendText(i.ToString("D2"));
                                textBox7.AppendText(" , ");
                                textBox7.AppendText(radar.PtsAlarmAreaVertices[i].ToString());
                                textBox7.AppendText("\r\n");
                            }

                        }
                        else
                        {
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();
                            textBox4.Clear();
                            textBox5.Clear();
                            textBox6.Clear();
                            textBox7.Clear();
                            MessageBox.Show("Query failure)");
                        }

                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            StreamWriter f2 = new StreamWriter("InfoBOX.txt",false);
            f2.WriteLine("");
            f2.Close();
          
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress ip = IPAddress.Parse(textBox12.Text);
                int port = int.Parse(textBox10.Text);
                NsrRadar radar = NsrSdk.Instance.CreateRadar(ip.ToString(), port);
                radar.Connect();
                _radars[radar.Ip] = radar;
                UpdateRadars();
                radar.GetFilterCoordinate();
                textBox7.Text =  radar.GetFilterCoordinate().ToString();
                MessageBox.Show("Succes!", "Radar ready to using!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        

        private void buttonDisConnect_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress ip = IPAddress.Parse(textBox12.Text);
                int port = int.Parse(textBox10.Text);

                if (_radars.ContainsKey(ip.ToString()) == false)
                    return;

                NsrRadar radar = null;

                _radars.TryRemove(ip.ToString(), out radar);
                if (radar != null)
                    radar.DisConnect();
                UpdateRadars();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ConnectRadar_Load(object sender, EventArgs e)
        {

        }

        private void ConnectRadar_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamWriter fff = new StreamWriter("check.iq");
            fff.Write("false");
            fff.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox_radar_set_Enter(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
