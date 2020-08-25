using iSpyApplication.Controls;

namespace iSpyApplication
{
    partial class AddCamera
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCamera));
            this.tcCamera = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label19 = new System.Windows.Forms.Label();
            this.flowLayoutPanel26 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMic = new System.Windows.Forms.Button();
            this.lblMicSource = new System.Windows.Forms.Label();
            this.chkIgnoreAudio = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label43 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCameraName = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.numMaxFR = new System.Windows.Forms.NumericUpDown();
            this.label47 = new System.Windows.Forms.Label();
            this.numMaxFRRecording = new System.Windows.Forms.NumericUpDown();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gbZones = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.AreaControl = new iSpyApplication.Controls.AreaSelector();
            this.llblClearAll = new System.Windows.Forms.LinkLabel();
            this.label83 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label72 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.chkSuppressNoise = new System.Windows.Forms.CheckBox();
            this.label48 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlProcessor = new System.Windows.Forms.ComboBox();
            this.ddlMotionDetector = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.button5 = new System.Windows.Forms.Button();
            this.chkColourProcessing = new System.Windows.Forms.CheckBox();
            this.ranger1 = new iSpyApplication.Controls.Ranger();
            this.button4 = new System.Windows.Forms.Button();
            this.label51 = new System.Windows.Forms.Label();
            this.flowLayoutPanel17 = new System.Windows.Forms.FlowLayoutPanel();
            this.numProcessInterval = new System.Windows.Forms.NumericUpDown();
            this.label64 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.numAutoOff = new System.Windows.Forms.NumericUpDown();
            this.label82 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.actionEditor1 = new iSpyApplication.Controls.ActionEditor();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.label89 = new System.Windows.Forms.Label();
            this.ddlActionType = new System.Windows.Forms.ComboBox();
            this.pnlMovement = new System.Windows.Forms.Panel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlAlertMode = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.rdoContinuous = new System.Windows.Forms.RadioButton();
            this.rdoMotion = new System.Windows.Forms.RadioButton();
            this.rdoTrigger = new System.Windows.Forms.RadioButton();
            this.label15 = new System.Windows.Forms.Label();
            this.intervalConfig1 = new iSpyApplication.Controls.IntervalConfig();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkMovement = new System.Windows.Forms.CheckBox();
            this.chkMessaging = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.txtMaxRecordTime = new System.Windows.Forms.NumericUpDown();
            this.label30 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.numMinRecordTime = new System.Windows.Forms.NumericUpDown();
            this.label53 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel10 = new System.Windows.Forms.FlowLayoutPanel();
            this.rdoNoRecord = new System.Windows.Forms.RadioButton();
            this.rdoRecordDetect = new System.Windows.Forms.RadioButton();
            this.rdoRecordAlert = new System.Windows.Forms.RadioButton();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.pnlPTZControls = new System.Windows.Forms.Panel();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbExtended = new System.Windows.Forms.ListBox();
            this.label16 = new System.Windows.Forms.Label();
            this.flowLayoutPanel31 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddPreset = new System.Windows.Forms.Button();
            this.btnDeletePreset = new System.Windows.Forms.Button();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPTZTrack = new System.Windows.Forms.Button();
            this.btnPTZSchedule = new System.Windows.Forms.Button();
            this.ptzui1 = new iSpyApplication.Controls.PTZUI();
            this.label75 = new System.Windows.Forms.Label();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.label73 = new System.Windows.Forms.Label();
            this.ddlPTZ = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel23 = new System.Windows.Forms.FlowLayoutPanel();
            this.button6 = new System.Windows.Forms.Button();
            this.llblEditPTZ = new System.Windows.Forms.LinkLabel();
            this.linkLabel10 = new System.Windows.Forms.LinkLabel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ofdDetect = new System.Windows.Forms.OpenFileDialog();
            this.label17 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.tcCamera.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel26.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxFR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxFRRecording)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.gbZones.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numProcessInterval)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoOff)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.pnlMovement.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxRecordTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinRecordTime)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.flowLayoutPanel10.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.pnlPTZControls.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.panel5.SuspendLayout();
            this.flowLayoutPanel31.SuspendLayout();
            this.flowLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.flowLayoutPanel23.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcCamera
            // 
            this.tcCamera.Controls.Add(this.tabPage1);
            this.tcCamera.Controls.Add(this.tabPage3);
            this.tcCamera.Controls.Add(this.tabPage2);
            this.tcCamera.Controls.Add(this.tabPage4);
            this.tcCamera.Controls.Add(this.tabPage8);
            this.tcCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcCamera.Location = new System.Drawing.Point(10, 10);
            this.tcCamera.Margin = new System.Windows.Forms.Padding(6);
            this.tcCamera.Name = "tcCamera";
            this.tcCamera.SelectedIndex = 0;
            this.tcCamera.Size = new System.Drawing.Size(657, 683);
            this.tcCamera.TabIndex = 16;
            this.tcCamera.SelectedIndexChanged += new System.EventHandler(this.TcCameraSelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.ForeColor = System.Drawing.Color.White;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage1.Size = new System.Drawing.Size(649, 657);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Camera";
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(6, 122);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(637, 87);
            this.groupBox2.TabIndex = 57;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Audio Source";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.label19, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel26, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.chkIgnoreAudio, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(625, 62);
            this.tableLayoutPanel3.TabIndex = 72;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 8);
            this.label19.Margin = new System.Windows.Forms.Padding(6, 8, 6, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 13);
            this.label19.TabIndex = 56;
            this.label19.Text = "Microphone";
            // 
            // flowLayoutPanel26
            // 
            this.flowLayoutPanel26.Controls.Add(this.btnMic);
            this.flowLayoutPanel26.Controls.Add(this.lblMicSource);
            this.flowLayoutPanel26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel26.Location = new System.Drawing.Point(120, 0);
            this.flowLayoutPanel26.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel26.Name = "flowLayoutPanel26";
            this.flowLayoutPanel26.Size = new System.Drawing.Size(513, 31);
            this.flowLayoutPanel26.TabIndex = 57;
            // 
            // btnMic
            // 
            this.btnMic.BackColor = System.Drawing.Color.Black;
            this.btnMic.Location = new System.Drawing.Point(3, 3);
            this.btnMic.Name = "btnMic";
            this.btnMic.Size = new System.Drawing.Size(32, 23);
            this.btnMic.TabIndex = 57;
            this.btnMic.Text = "...";
            this.btnMic.UseVisualStyleBackColor = false;
            this.btnMic.Click += new System.EventHandler(this.btnMic_Click);
            // 
            // lblMicSource
            // 
            this.lblMicSource.AutoSize = true;
            this.lblMicSource.Location = new System.Drawing.Point(41, 0);
            this.lblMicSource.Name = "lblMicSource";
            this.lblMicSource.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblMicSource.Size = new System.Drawing.Size(58, 21);
            this.lblMicSource.TabIndex = 58;
            this.lblMicSource.Text = "MicSource";
            // 
            // chkIgnoreAudio
            // 
            this.chkIgnoreAudio.AutoSize = true;
            this.chkIgnoreAudio.Location = new System.Drawing.Point(126, 37);
            this.chkIgnoreAudio.Margin = new System.Windows.Forms.Padding(6);
            this.chkIgnoreAudio.Name = "chkIgnoreAudio";
            this.chkIgnoreAudio.Size = new System.Drawing.Size(86, 17);
            this.chkIgnoreAudio.TabIndex = 58;
            this.chkIgnoreAudio.Text = "Ignore Audio";
            this.chkIgnoreAudio.UseVisualStyleBackColor = true;
            this.chkIgnoreAudio.CheckedChanged += new System.EventHandler(this.chkIgnoreAudio_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.tableLayoutPanel2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox3.Size = new System.Drawing.Size(637, 116);
            this.groupBox3.TabIndex = 56;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Video Source";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label43, 0, 12);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtCameraName, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel2, 1, 12);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 13;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(625, 91);
            this.tableLayoutPanel2.TabIndex = 80;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(6, 40);
            this.label43.Margin = new System.Windows.Forms.Padding(6, 8, 6, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(77, 13);
            this.label43.TabIndex = 73;
            this.label43.Text = "Max Framerate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Name";
            // 
            // txtCameraName
            // 
            this.txtCameraName.Location = new System.Drawing.Point(126, 6);
            this.txtCameraName.Margin = new System.Windows.Forms.Padding(6);
            this.txtCameraName.MaxLength = 50;
            this.txtCameraName.Name = "txtCameraName";
            this.txtCameraName.Size = new System.Drawing.Size(275, 20);
            this.txtCameraName.TabIndex = 21;
            this.toolTip1.SetToolTip(this.txtCameraName, "Give your camera a descriptive name, eg Office Cam");
            this.txtCameraName.TextChanged += new System.EventHandler(this.TxtCameraNameTextChanged);
            this.txtCameraName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtCameraNameKeyUp);
            // 
            // flowLayoutPanel2
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.flowLayoutPanel2, 2);
            this.flowLayoutPanel2.Controls.Add(this.numMaxFR);
            this.flowLayoutPanel2.Controls.Add(this.label47);
            this.flowLayoutPanel2.Controls.Add(this.numMaxFRRecording);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(120, 32);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(513, 59);
            this.flowLayoutPanel2.TabIndex = 80;
            // 
            // numMaxFR
            // 
            this.numMaxFR.DecimalPlaces = 2;
            this.numMaxFR.Location = new System.Drawing.Point(6, 6);
            this.numMaxFR.Margin = new System.Windows.Forms.Padding(6);
            this.numMaxFR.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numMaxFR.Name = "numMaxFR";
            this.numMaxFR.Size = new System.Drawing.Size(52, 20);
            this.numMaxFR.TabIndex = 74;
            this.numMaxFR.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxFR.ValueChanged += new System.EventHandler(this.numMaxFR_ValueChanged);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(70, 8);
            this.label47.Margin = new System.Windows.Forms.Padding(6, 8, 6, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(91, 13);
            this.label47.TabIndex = 75;
            this.label47.Text = "When  Recording";
            // 
            // numMaxFRRecording
            // 
            this.numMaxFRRecording.DecimalPlaces = 2;
            this.numMaxFRRecording.Location = new System.Drawing.Point(173, 6);
            this.numMaxFRRecording.Margin = new System.Windows.Forms.Padding(6);
            this.numMaxFRRecording.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numMaxFRRecording.Name = "numMaxFRRecording";
            this.numMaxFRRecording.Size = new System.Drawing.Size(70, 20);
            this.numMaxFRRecording.TabIndex = 76;
            this.numMaxFRRecording.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage3.Controls.Add(this.gbZones);
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.ForeColor = System.Drawing.Color.White;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage3.Size = new System.Drawing.Size(649, 657);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Motion Detection";
            // 
            // gbZones
            // 
            this.gbZones.Controls.Add(this.tableLayoutPanel6);
            this.gbZones.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbZones.ForeColor = System.Drawing.Color.White;
            this.gbZones.Location = new System.Drawing.Point(6, 258);
            this.gbZones.Margin = new System.Windows.Forms.Padding(6);
            this.gbZones.Name = "gbZones";
            this.gbZones.Padding = new System.Windows.Forms.Padding(6);
            this.gbZones.Size = new System.Drawing.Size(620, 409);
            this.gbZones.TabIndex = 56;
            this.gbZones.TabStop = false;
            this.gbZones.Text = "Detection Zones";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel6.Controls.Add(this.AreaControl, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.llblClearAll, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.label83, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(608, 384);
            this.tableLayoutPanel6.TabIndex = 48;
            // 
            // AreaControl
            // 
            this.AreaControl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AreaControl.BackColor = System.Drawing.Color.Black;
            this.AreaControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel6.SetColumnSpan(this.AreaControl, 2);
            this.AreaControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AreaControl.LastFrame = null;
            this.AreaControl.Location = new System.Drawing.Point(93, 0);
            this.AreaControl.Margin = new System.Windows.Forms.Padding(0);
            this.AreaControl.MinimumSize = new System.Drawing.Size(100, 100);
            this.AreaControl.MotionZones = new objectsCameraDetectorZone[0];
            this.AreaControl.Name = "AreaControl";
            this.AreaControl.Padding = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.AreaControl.Size = new System.Drawing.Size(421, 319);
            this.AreaControl.TabIndex = 48;
            // 
            // llblClearAll
            // 
            this.llblClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llblClearAll.AutoSize = true;
            this.llblClearAll.Location = new System.Drawing.Point(548, 319);
            this.llblClearAll.Name = "llblClearAll";
            this.llblClearAll.Padding = new System.Windows.Forms.Padding(6);
            this.llblClearAll.Size = new System.Drawing.Size(57, 25);
            this.llblClearAll.TabIndex = 49;
            this.llblClearAll.TabStop = true;
            this.llblClearAll.Text = "Clear All";
            this.llblClearAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel15_LinkClicked);
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(6, 319);
            this.label83.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label83.Name = "label83";
            this.label83.Padding = new System.Windows.Forms.Padding(6);
            this.label83.Size = new System.Drawing.Size(202, 25);
            this.label83.TabIndex = 47;
            this.label83.Text = "* Click and drag to draw out rectangles";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tableLayoutPanel5);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(6, 6);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox5.Size = new System.Drawing.Size(620, 252);
            this.groupBox5.TabIndex = 55;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Detector";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 5;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.label72, 0, 4);
            this.tableLayoutPanel5.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.chkSuppressNoise, 4, 0);
            this.tableLayoutPanel5.Controls.Add(this.label48, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.label46, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.ddlProcessor, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.ddlMotionDetector, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.flowLayoutPanel4, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.ranger1, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.button4, 2, 3);
            this.tableLayoutPanel5.Controls.Add(this.label51, 3, 3);
            this.tableLayoutPanel5.Controls.Add(this.flowLayoutPanel17, 4, 3);
            this.tableLayoutPanel5.Controls.Add(this.flowLayoutPanel1, 1, 4);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 5;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(608, 227);
            this.tableLayoutPanel5.TabIndex = 62;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(6, 197);
            this.label72.Margin = new System.Windows.Forms.Padding(6, 8, 6, 0);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(46, 13);
            this.label72.TabIndex = 62;
            this.label72.Text = "Auto Off";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 8);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 8, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Use Detector";
            // 
            // chkSuppressNoise
            // 
            this.chkSuppressNoise.AutoSize = true;
            this.chkSuppressNoise.Checked = true;
            this.chkSuppressNoise.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSuppressNoise.Location = new System.Drawing.Point(430, 6);
            this.chkSuppressNoise.Margin = new System.Windows.Forms.Padding(6);
            this.chkSuppressNoise.Name = "chkSuppressNoise";
            this.chkSuppressNoise.Size = new System.Drawing.Size(94, 17);
            this.chkSuppressNoise.TabIndex = 40;
            this.chkSuppressNoise.Text = "Supress Noise";
            this.chkSuppressNoise.UseVisualStyleBackColor = true;
            this.chkSuppressNoise.CheckedChanged += new System.EventHandler(this.ChkSuppressNoiseCheckedChanged);
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(6, 122);
            this.label48.Margin = new System.Windows.Forms.Padding(6, 8, 6, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(76, 13);
            this.label48.TabIndex = 58;
            this.label48.Text = "Colour Filtering";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(6, 153);
            this.label46.Margin = new System.Windows.Forms.Padding(6, 8, 6, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(67, 13);
            this.label46.TabIndex = 47;
            this.label46.Text = "Display Style";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 8, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Trigger Range";
            // 
            // ddlProcessor
            // 
            this.ddlProcessor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlProcessor.FormattingEnabled = true;
            this.ddlProcessor.Location = new System.Drawing.Point(94, 151);
            this.ddlProcessor.Margin = new System.Windows.Forms.Padding(6);
            this.ddlProcessor.Name = "ddlProcessor";
            this.ddlProcessor.Size = new System.Drawing.Size(191, 21);
            this.ddlProcessor.TabIndex = 48;
            this.ddlProcessor.SelectedIndexChanged += new System.EventHandler(this.DdlProcessorSelectedIndexChanged);
            // 
            // ddlMotionDetector
            // 
            this.ddlMotionDetector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlMotionDetector.FormattingEnabled = true;
            this.ddlMotionDetector.Location = new System.Drawing.Point(94, 6);
            this.ddlMotionDetector.Margin = new System.Windows.Forms.Padding(6);
            this.ddlMotionDetector.Name = "ddlMotionDetector";
            this.ddlMotionDetector.Size = new System.Drawing.Size(191, 21);
            this.ddlMotionDetector.TabIndex = 30;
            this.ddlMotionDetector.SelectedIndexChanged += new System.EventHandler(this.DdlMovementDetectorSelectedIndexChanged1);
            // 
            // flowLayoutPanel4
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.flowLayoutPanel4, 4);
            this.flowLayoutPanel4.Controls.Add(this.button5);
            this.flowLayoutPanel4.Controls.Add(this.chkColourProcessing);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(88, 114);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(605, 31);
            this.flowLayoutPanel4.TabIndex = 59;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 6);
            this.button5.Margin = new System.Windows.Forms.Padding(6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(38, 21);
            this.button5.TabIndex = 59;
            this.button5.Text = "...";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // chkColourProcessing
            // 
            this.chkColourProcessing.AutoSize = true;
            this.chkColourProcessing.Location = new System.Drawing.Point(56, 6);
            this.chkColourProcessing.Margin = new System.Windows.Forms.Padding(6);
            this.chkColourProcessing.Name = "chkColourProcessing";
            this.chkColourProcessing.Size = new System.Drawing.Size(52, 17);
            this.chkColourProcessing.TabIndex = 61;
            this.chkColourProcessing.Text = "Apply";
            this.chkColourProcessing.UseVisualStyleBackColor = true;
            this.chkColourProcessing.CheckedChanged += new System.EventHandler(this.chkColourProcessing_CheckedChanged);
            // 
            // ranger1
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.ranger1, 4);
            this.ranger1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ranger1.Gain = 10F;
            this.ranger1.Location = new System.Drawing.Point(92, 37);
            this.ranger1.Margin = new System.Windows.Forms.Padding(4);
            this.ranger1.Name = "ranger1";
            this.ranger1.Size = new System.Drawing.Size(462, 73);
            this.ranger1.TabIndex = 61;
            this.ranger1.ValueMax = 100D;
            this.ranger1.ValueMin = 0D;
            // 
            // button4
            // 
            this.button4.AutoSize = true;
            this.button4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button4.Location = new System.Drawing.Point(297, 151);
            this.button4.Margin = new System.Windows.Forms.Padding(6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(26, 23);
            this.button4.TabIndex = 57;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(335, 153);
            this.label51.Margin = new System.Windows.Forms.Padding(6, 8, 6, 0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(83, 13);
            this.label51.TabIndex = 50;
            this.label51.Text = "Process Interval";
            // 
            // flowLayoutPanel17
            // 
            this.flowLayoutPanel17.Controls.Add(this.numProcessInterval);
            this.flowLayoutPanel17.Controls.Add(this.label64);
            this.flowLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel17.Location = new System.Drawing.Point(424, 145);
            this.flowLayoutPanel17.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel17.Name = "flowLayoutPanel17";
            this.flowLayoutPanel17.Size = new System.Drawing.Size(269, 44);
            this.flowLayoutPanel17.TabIndex = 60;
            // 
            // numProcessInterval
            // 
            this.numProcessInterval.Location = new System.Drawing.Point(6, 6);
            this.numProcessInterval.Margin = new System.Windows.Forms.Padding(6);
            this.numProcessInterval.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numProcessInterval.Name = "numProcessInterval";
            this.numProcessInterval.Size = new System.Drawing.Size(83, 20);
            this.numProcessInterval.TabIndex = 55;
            this.numProcessInterval.ValueChanged += new System.EventHandler(this.numProcessInterval_ValueChanged);
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(101, 8);
            this.label64.Margin = new System.Windows.Forms.Padding(6, 8, 6, 0);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(20, 13);
            this.label64.TabIndex = 54;
            this.label64.Text = "ms";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.numAutoOff);
            this.flowLayoutPanel1.Controls.Add(this.label82);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(88, 189);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(203, 38);
            this.flowLayoutPanel1.TabIndex = 64;
            // 
            // numAutoOff
            // 
            this.numAutoOff.Location = new System.Drawing.Point(6, 6);
            this.numAutoOff.Margin = new System.Windows.Forms.Padding(6);
            this.numAutoOff.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numAutoOff.Name = "numAutoOff";
            this.numAutoOff.Size = new System.Drawing.Size(65, 20);
            this.numAutoOff.TabIndex = 63;
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(83, 8);
            this.label82.Margin = new System.Windows.Forms.Padding(6, 8, 6, 0);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(49, 13);
            this.label82.TabIndex = 55;
            this.label82.Text = "Seconds";
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage2.Controls.Add(this.groupBox9);
            this.tabPage2.Controls.Add(this.pnlMovement);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.ForeColor = System.Drawing.Color.White;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage2.Size = new System.Drawing.Size(649, 657);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Alerts";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.tableLayoutPanel8);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox9.ForeColor = System.Drawing.Color.White;
            this.groupBox9.Location = new System.Drawing.Point(6, 139);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(637, 336);
            this.groupBox9.TabIndex = 94;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Actions";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.actionEditor1, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.flowLayoutPanel6, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.Size = new System.Drawing.Size(631, 317);
            this.tableLayoutPanel8.TabIndex = 93;
            // 
            // actionEditor1
            // 
            this.actionEditor1.Dock = System.Windows.Forms.DockStyle.Top;
            this.actionEditor1.Location = new System.Drawing.Point(4, 35);
            this.actionEditor1.Margin = new System.Windows.Forms.Padding(4);
            this.actionEditor1.Name = "actionEditor1";
            this.actionEditor1.Size = new System.Drawing.Size(623, 260);
            this.actionEditor1.TabIndex = 92;
            this.actionEditor1.Load += new System.EventHandler(this.actionEditor1_Load);
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.label89);
            this.flowLayoutPanel6.Controls.Add(this.ddlActionType);
            this.flowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(631, 31);
            this.flowLayoutPanel6.TabIndex = 95;
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(6, 6);
            this.label89.Margin = new System.Windows.Forms.Padding(6);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(21, 13);
            this.label89.TabIndex = 94;
            this.label89.Text = "On";
            // 
            // ddlActionType
            // 
            this.ddlActionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlActionType.FormattingEnabled = true;
            this.ddlActionType.Location = new System.Drawing.Point(39, 3);
            this.ddlActionType.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.ddlActionType.Name = "ddlActionType";
            this.ddlActionType.Size = new System.Drawing.Size(121, 21);
            this.ddlActionType.TabIndex = 93;
            this.ddlActionType.SelectedIndexChanged += new System.EventHandler(this.ddlEventType_SelectedIndexChanged);
            // 
            // pnlMovement
            // 
            this.pnlMovement.Controls.Add(this.tableLayoutPanel7);
            this.pnlMovement.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMovement.Location = new System.Drawing.Point(6, 33);
            this.pnlMovement.Margin = new System.Windows.Forms.Padding(6);
            this.pnlMovement.Name = "pnlMovement";
            this.pnlMovement.Size = new System.Drawing.Size(637, 106);
            this.pnlMovement.TabIndex = 30;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 4;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.ddlAlertMode, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.button3, 2, 0);
            this.tableLayoutPanel7.Controls.Add(this.flowLayoutPanel5, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.label15, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.intervalConfig1, 1, 2);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(637, 102);
            this.tableLayoutPanel7.TabIndex = 82;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 8, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Mode:";
            // 
            // ddlAlertMode
            // 
            this.ddlAlertMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlAlertMode.FormattingEnabled = true;
            this.ddlAlertMode.Location = new System.Drawing.Point(65, 6);
            this.ddlAlertMode.Margin = new System.Windows.Forms.Padding(6);
            this.ddlAlertMode.Name = "ddlAlertMode";
            this.ddlAlertMode.Size = new System.Drawing.Size(266, 21);
            this.ddlAlertMode.TabIndex = 77;
            this.ddlAlertMode.SelectedIndexChanged += new System.EventHandler(this.DdlAlertModeSelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button3.Location = new System.Drawing.Point(343, 6);
            this.button3.Margin = new System.Windows.Forms.Padding(6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(26, 19);
            this.button3.TabIndex = 78;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3Click3);
            // 
            // flowLayoutPanel5
            // 
            this.tableLayoutPanel7.SetColumnSpan(this.flowLayoutPanel5, 3);
            this.flowLayoutPanel5.Controls.Add(this.rdoContinuous);
            this.flowLayoutPanel5.Controls.Add(this.rdoMotion);
            this.flowLayoutPanel5.Controls.Add(this.rdoTrigger);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(59, 31);
            this.flowLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(588, 31);
            this.flowLayoutPanel5.TabIndex = 79;
            // 
            // rdoContinuous
            // 
            this.rdoContinuous.AutoSize = true;
            this.rdoContinuous.Location = new System.Drawing.Point(6, 6);
            this.rdoContinuous.Margin = new System.Windows.Forms.Padding(6);
            this.rdoContinuous.Name = "rdoContinuous";
            this.rdoContinuous.Size = new System.Drawing.Size(78, 17);
            this.rdoContinuous.TabIndex = 0;
            this.rdoContinuous.TabStop = true;
            this.rdoContinuous.Text = "Continuous";
            this.rdoContinuous.UseVisualStyleBackColor = true;
            this.rdoContinuous.CheckedChanged += new System.EventHandler(this.rdoContinuous_CheckedChanged);
            // 
            // rdoMotion
            // 
            this.rdoMotion.AutoSize = true;
            this.rdoMotion.Location = new System.Drawing.Point(96, 6);
            this.rdoMotion.Margin = new System.Windows.Forms.Padding(6);
            this.rdoMotion.Name = "rdoMotion";
            this.rdoMotion.Size = new System.Drawing.Size(136, 17);
            this.rdoMotion.TabIndex = 1;
            this.rdoMotion.TabStop = true;
            this.rdoMotion.Text = "When Motion Detected";
            this.rdoMotion.UseVisualStyleBackColor = true;
            this.rdoMotion.CheckedChanged += new System.EventHandler(this.rdoMotion_CheckedChanged);
            // 
            // rdoTrigger
            // 
            this.rdoTrigger.AutoSize = true;
            this.rdoTrigger.Location = new System.Drawing.Point(244, 6);
            this.rdoTrigger.Margin = new System.Windows.Forms.Padding(6);
            this.rdoTrigger.Name = "rdoTrigger";
            this.rdoTrigger.Size = new System.Drawing.Size(99, 17);
            this.rdoTrigger.TabIndex = 2;
            this.rdoTrigger.TabStop = true;
            this.rdoTrigger.Text = "External Trigger";
            this.rdoTrigger.UseVisualStyleBackColor = true;
            this.rdoTrigger.CheckedChanged += new System.EventHandler(this.rdoTrigger_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 70);
            this.label15.Margin = new System.Windows.Forms.Padding(6, 8, 6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 13);
            this.label15.TabIndex = 57;
            this.label15.Text = "Intervals";
            // 
            // intervalConfig1
            // 
            this.tableLayoutPanel7.SetColumnSpan(this.intervalConfig1, 3);
            this.intervalConfig1.Dock = System.Windows.Forms.DockStyle.Left;
            this.intervalConfig1.Location = new System.Drawing.Point(63, 66);
            this.intervalConfig1.Margin = new System.Windows.Forms.Padding(4);
            this.intervalConfig1.Name = "intervalConfig1";
            this.intervalConfig1.Size = new System.Drawing.Size(519, 32);
            this.intervalConfig1.TabIndex = 80;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.chkMovement);
            this.panel4.Controls.Add(this.chkMessaging);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(6, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(637, 27);
            this.panel4.TabIndex = 75;
            // 
            // chkMovement
            // 
            this.chkMovement.AutoSize = true;
            this.chkMovement.Location = new System.Drawing.Point(7, 4);
            this.chkMovement.Margin = new System.Windows.Forms.Padding(6);
            this.chkMovement.Name = "chkMovement";
            this.chkMovement.Size = new System.Drawing.Size(94, 17);
            this.chkMovement.TabIndex = 28;
            this.chkMovement.Text = "Alerts Enabled";
            this.chkMovement.UseVisualStyleBackColor = true;
            this.chkMovement.CheckedChanged += new System.EventHandler(this.ChkMovementCheckedChanged);
            // 
            // chkMessaging
            // 
            this.chkMessaging.AutoSize = true;
            this.chkMessaging.Location = new System.Drawing.Point(134, 4);
            this.chkMessaging.Name = "chkMessaging";
            this.chkMessaging.Size = new System.Drawing.Size(77, 17);
            this.chkMessaging.TabIndex = 95;
            this.chkMessaging.Text = "Messaging";
            this.toolTip1.SetToolTip(this.chkMessaging, "Check to enable SMS and email alerts");
            this.chkMessaging.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.AutoScroll = true;
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Controls.Add(this.groupBox6);
            this.tabPage4.ForeColor = System.Drawing.Color.White;
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage4.Size = new System.Drawing.Size(649, 657);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Recording";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel9);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(6, 67);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox4.Size = new System.Drawing.Size(637, 249);
            this.groupBox4.TabIndex = 83;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Recording Settings";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 6;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.Controls.Add(this.txtMaxRecordTime, 4, 0);
            this.tableLayoutPanel9.Controls.Add(this.label30, 3, 0);
            this.tableLayoutPanel9.Controls.Add(this.label33, 2, 0);
            this.tableLayoutPanel9.Controls.Add(this.numMinRecordTime, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.label53, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.label41, 5, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(625, 224);
            this.tableLayoutPanel9.TabIndex = 75;
            // 
            // txtMaxRecordTime
            // 
            this.txtMaxRecordTime.Location = new System.Drawing.Point(345, 6);
            this.txtMaxRecordTime.Margin = new System.Windows.Forms.Padding(6);
            this.txtMaxRecordTime.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txtMaxRecordTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtMaxRecordTime.Name = "txtMaxRecordTime";
            this.txtMaxRecordTime.Size = new System.Drawing.Size(59, 20);
            this.txtMaxRecordTime.TabIndex = 74;
            this.toolTip1.SetToolTip(this.txtMaxRecordTime, "The maximum duration to record to a single file.");
            this.txtMaxRecordTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(239, 8);
            this.label30.Margin = new System.Windows.Forms.Padding(6, 8, 6, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(94, 13);
            this.label30.TabIndex = 56;
            this.label30.Text = "Max. Record Time";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(180, 8);
            this.label33.Margin = new System.Windows.Forms.Padding(6, 8, 6, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(47, 13);
            this.label33.TabIndex = 82;
            this.label33.Text = "seconds";
            // 
            // numMinRecordTime
            // 
            this.numMinRecordTime.Location = new System.Drawing.Point(109, 6);
            this.numMinRecordTime.Margin = new System.Windows.Forms.Padding(6);
            this.numMinRecordTime.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numMinRecordTime.Name = "numMinRecordTime";
            this.numMinRecordTime.Size = new System.Drawing.Size(59, 20);
            this.numMinRecordTime.TabIndex = 81;
            this.toolTip1.SetToolTip(this.numMinRecordTime, "The minimum duration to record to a single file.");
            this.numMinRecordTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(6, 8);
            this.label53.Margin = new System.Windows.Forms.Padding(6, 8, 6, 0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(91, 13);
            this.label53.TabIndex = 83;
            this.label53.Text = "Min. Record Time";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(416, 8);
            this.label41.Margin = new System.Windows.Forms.Padding(6, 8, 6, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(47, 13);
            this.label41.TabIndex = 51;
            this.label41.Text = "seconds";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.flowLayoutPanel10);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.ForeColor = System.Drawing.Color.White;
            this.groupBox6.Location = new System.Drawing.Point(6, 6);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox6.Size = new System.Drawing.Size(637, 61);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Recording Mode";
            // 
            // flowLayoutPanel10
            // 
            this.flowLayoutPanel10.Controls.Add(this.rdoNoRecord);
            this.flowLayoutPanel10.Controls.Add(this.rdoRecordDetect);
            this.flowLayoutPanel10.Controls.Add(this.rdoRecordAlert);
            this.flowLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel10.Location = new System.Drawing.Point(6, 19);
            this.flowLayoutPanel10.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel10.Name = "flowLayoutPanel10";
            this.flowLayoutPanel10.Size = new System.Drawing.Size(625, 36);
            this.flowLayoutPanel10.TabIndex = 3;
            // 
            // rdoNoRecord
            // 
            this.rdoNoRecord.AutoSize = true;
            this.rdoNoRecord.Location = new System.Drawing.Point(6, 6);
            this.rdoNoRecord.Margin = new System.Windows.Forms.Padding(6);
            this.rdoNoRecord.Name = "rdoNoRecord";
            this.rdoNoRecord.Size = new System.Drawing.Size(88, 17);
            this.rdoNoRecord.TabIndex = 0;
            this.rdoNoRecord.TabStop = true;
            this.rdoNoRecord.Text = "Don\'t Record";
            this.rdoNoRecord.UseVisualStyleBackColor = true;
            this.rdoNoRecord.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // rdoRecordDetect
            // 
            this.rdoRecordDetect.AutoSize = true;
            this.rdoRecordDetect.Location = new System.Drawing.Point(106, 6);
            this.rdoRecordDetect.Margin = new System.Windows.Forms.Padding(6);
            this.rdoRecordDetect.Name = "rdoRecordDetect";
            this.rdoRecordDetect.Size = new System.Drawing.Size(177, 17);
            this.rdoRecordDetect.TabIndex = 2;
            this.rdoRecordDetect.TabStop = true;
            this.rdoRecordDetect.Text = "Record on Movement Detection";
            this.rdoRecordDetect.UseVisualStyleBackColor = true;
            this.rdoRecordDetect.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // rdoRecordAlert
            // 
            this.rdoRecordAlert.AutoSize = true;
            this.rdoRecordAlert.Location = new System.Drawing.Point(295, 6);
            this.rdoRecordAlert.Margin = new System.Windows.Forms.Padding(6);
            this.rdoRecordAlert.Name = "rdoRecordAlert";
            this.rdoRecordAlert.Size = new System.Drawing.Size(99, 17);
            this.rdoRecordAlert.TabIndex = 1;
            this.rdoRecordAlert.TabStop = true;
            this.rdoRecordAlert.Text = "Record on Alert";
            this.rdoRecordAlert.UseVisualStyleBackColor = true;
            this.rdoRecordAlert.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // tabPage8
            // 
            this.tabPage8.AutoScroll = true;
            this.tabPage8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage8.Controls.Add(this.pnlPTZControls);
            this.tabPage8.Controls.Add(this.tableLayoutPanel11);
            this.tabPage8.ForeColor = System.Drawing.Color.White;
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage8.Size = new System.Drawing.Size(649, 657);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "PTZ";
            // 
            // pnlPTZControls
            // 
            this.pnlPTZControls.Controls.Add(this.tableLayoutPanel12);
            this.pnlPTZControls.Controls.Add(this.label75);
            this.pnlPTZControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPTZControls.Location = new System.Drawing.Point(6, 48);
            this.pnlPTZControls.Margin = new System.Windows.Forms.Padding(6);
            this.pnlPTZControls.Name = "pnlPTZControls";
            this.pnlPTZControls.Size = new System.Drawing.Size(637, 302);
            this.pnlPTZControls.TabIndex = 79;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 2;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 241F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.Controls.Add(this.panel5, 1, 0);
            this.tableLayoutPanel12.Controls.Add(this.label16, 0, 1);
            this.tableLayoutPanel12.Controls.Add(this.flowLayoutPanel31, 1, 1);
            this.tableLayoutPanel12.Controls.Add(this.flowLayoutPanel7, 0, 2);
            this.tableLayoutPanel12.Controls.Add(this.ptzui1, 0, 0);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 3;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(637, 287);
            this.tableLayoutPanel12.TabIndex = 81;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lbExtended);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(244, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(390, 176);
            this.panel5.TabIndex = 78;
            // 
            // lbExtended
            // 
            this.lbExtended.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbExtended.FormattingEnabled = true;
            this.lbExtended.Location = new System.Drawing.Point(0, 0);
            this.lbExtended.Margin = new System.Windows.Forms.Padding(6);
            this.lbExtended.Name = "lbExtended";
            this.lbExtended.Size = new System.Drawing.Size(390, 176);
            this.lbExtended.TabIndex = 7;
            this.lbExtended.Click += new System.EventHandler(this.LbExtendedClick);
            this.lbExtended.SelectedIndexChanged += new System.EventHandler(this.LbExtendedSelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(6, 182);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(229, 41);
            this.label16.TabIndex = 9;
            this.label16.Text = "Note: You can control PTZ on the live camera view by holding down the middle mous" +
    "e button.";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // flowLayoutPanel31
            // 
            this.flowLayoutPanel31.Controls.Add(this.btnAddPreset);
            this.flowLayoutPanel31.Controls.Add(this.btnDeletePreset);
            this.flowLayoutPanel31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel31.Location = new System.Drawing.Point(241, 182);
            this.flowLayoutPanel31.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel31.Name = "flowLayoutPanel31";
            this.flowLayoutPanel31.Size = new System.Drawing.Size(396, 41);
            this.flowLayoutPanel31.TabIndex = 82;
            // 
            // btnAddPreset
            // 
            this.btnAddPreset.BackColor = System.Drawing.Color.Black;
            this.btnAddPreset.Location = new System.Drawing.Point(3, 3);
            this.btnAddPreset.Name = "btnAddPreset";
            this.btnAddPreset.Size = new System.Drawing.Size(59, 23);
            this.btnAddPreset.TabIndex = 76;
            this.btnAddPreset.Text = "+ preset";
            this.btnAddPreset.UseVisualStyleBackColor = false;
            this.btnAddPreset.Click += new System.EventHandler(this.btnAddPreset_Click);
            // 
            // btnDeletePreset
            // 
            this.btnDeletePreset.BackColor = System.Drawing.Color.Black;
            this.btnDeletePreset.Location = new System.Drawing.Point(68, 3);
            this.btnDeletePreset.Name = "btnDeletePreset";
            this.btnDeletePreset.Size = new System.Drawing.Size(59, 23);
            this.btnDeletePreset.TabIndex = 77;
            this.btnDeletePreset.Text = "- preset";
            this.btnDeletePreset.UseVisualStyleBackColor = false;
            this.btnDeletePreset.Click += new System.EventHandler(this.btnDeletePreset_Click);
            // 
            // flowLayoutPanel7
            // 
            this.tableLayoutPanel12.SetColumnSpan(this.flowLayoutPanel7, 2);
            this.flowLayoutPanel7.Controls.Add(this.btnPTZTrack);
            this.flowLayoutPanel7.Controls.Add(this.btnPTZSchedule);
            this.flowLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel7.Location = new System.Drawing.Point(3, 226);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new System.Drawing.Size(631, 38);
            this.flowLayoutPanel7.TabIndex = 83;
            // 
            // btnPTZTrack
            // 
            this.btnPTZTrack.BackColor = System.Drawing.Color.Black;
            this.btnPTZTrack.Location = new System.Drawing.Point(3, 3);
            this.btnPTZTrack.Name = "btnPTZTrack";
            this.btnPTZTrack.Size = new System.Drawing.Size(145, 23);
            this.btnPTZTrack.TabIndex = 0;
            this.btnPTZTrack.Text = "Track Objects";
            this.btnPTZTrack.UseVisualStyleBackColor = false;
            this.btnPTZTrack.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnPTZSchedule
            // 
            this.btnPTZSchedule.BackColor = System.Drawing.Color.Black;
            this.btnPTZSchedule.Location = new System.Drawing.Point(154, 3);
            this.btnPTZSchedule.Name = "btnPTZSchedule";
            this.btnPTZSchedule.Size = new System.Drawing.Size(145, 23);
            this.btnPTZSchedule.TabIndex = 1;
            this.btnPTZSchedule.Text = "Schedule PTZ";
            this.btnPTZSchedule.UseVisualStyleBackColor = false;
            this.btnPTZSchedule.Click += new System.EventHandler(this.btnPTZSchedule_Click);
            // 
            // ptzui1
            // 
            this.ptzui1.Location = new System.Drawing.Point(2, 2);
            this.ptzui1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ptzui1.Name = "ptzui1";
            this.ptzui1.Size = new System.Drawing.Size(225, 176);
            this.ptzui1.TabIndex = 84;
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(480, 129);
            this.label75.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(107, 13);
            this.label75.TabIndex = 6;
            this.label75.Text = "Extended Commands";
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 3;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Controls.Add(this.label73, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.ddlPTZ, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.flowLayoutPanel23, 2, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 1;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(637, 42);
            this.tableLayoutPanel11.TabIndex = 80;
            // 
            // label73
            // 
            this.label73.Location = new System.Drawing.Point(6, 8);
            this.label73.Margin = new System.Windows.Forms.Padding(6, 8, 6, 0);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(118, 25);
            this.label73.TabIndex = 1;
            this.label73.Text = "Camera Model";
            // 
            // ddlPTZ
            // 
            this.ddlPTZ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPTZ.FormattingEnabled = true;
            this.ddlPTZ.Location = new System.Drawing.Point(136, 6);
            this.ddlPTZ.Margin = new System.Windows.Forms.Padding(6);
            this.ddlPTZ.Name = "ddlPTZ";
            this.ddlPTZ.Size = new System.Drawing.Size(178, 21);
            this.ddlPTZ.TabIndex = 0;
            this.ddlPTZ.SelectedIndexChanged += new System.EventHandler(this.DdlPtzSelectedIndexChanged);
            // 
            // flowLayoutPanel23
            // 
            this.flowLayoutPanel23.Controls.Add(this.button6);
            this.flowLayoutPanel23.Controls.Add(this.llblEditPTZ);
            this.flowLayoutPanel23.Controls.Add(this.linkLabel10);
            this.flowLayoutPanel23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel23.Location = new System.Drawing.Point(323, 3);
            this.flowLayoutPanel23.Name = "flowLayoutPanel23";
            this.flowLayoutPanel23.Size = new System.Drawing.Size(311, 36);
            this.flowLayoutPanel23.TabIndex = 2;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.AutoSize = true;
            this.button6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button6.BackColor = System.Drawing.Color.Black;
            this.button6.Location = new System.Drawing.Point(0, 0);
            this.button6.Margin = new System.Windows.Forms.Padding(0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(26, 23);
            this.button6.TabIndex = 76;
            this.button6.Text = "...";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // llblEditPTZ
            // 
            this.llblEditPTZ.AutoSize = true;
            this.llblEditPTZ.Location = new System.Drawing.Point(29, 8);
            this.llblEditPTZ.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.llblEditPTZ.Name = "llblEditPTZ";
            this.llblEditPTZ.Size = new System.Drawing.Size(25, 13);
            this.llblEditPTZ.TabIndex = 9;
            this.llblEditPTZ.TabStop = true;
            this.llblEditPTZ.Text = "Edit";
            this.llblEditPTZ.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblEditPTZ_LinkClicked);
            // 
            // linkLabel10
            // 
            this.linkLabel10.AutoSize = true;
            this.linkLabel10.Location = new System.Drawing.Point(60, 8);
            this.linkLabel10.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.linkLabel10.Name = "linkLabel10";
            this.linkLabel10.Size = new System.Drawing.Size(41, 13);
            this.linkLabel10.TabIndex = 10;
            this.linkLabel10.TabStop = true;
            this.linkLabel10.Text = "Reload";
            this.linkLabel10.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel10_LinkClicked);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.AutoSize = true;
            this.btnNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNext.BackColor = System.Drawing.Color.Black;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(264, 6);
            this.btnNext.Margin = new System.Windows.Forms.Padding(6);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(80, 30);
            this.btnNext.TabIndex = 22;
            this.btnNext.Text = "Next >>";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.BtnNextClick);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.AutoSize = true;
            this.btnBack.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBack.BackColor = System.Drawing.Color.Black;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(168, 6);
            this.btnBack.Margin = new System.Windows.Forms.Padding(6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(84, 30);
            this.btnBack.TabIndex = 45;
            this.btnBack.Text = "<< Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.Button2Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.AutoSize = true;
            this.btnFinish.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFinish.BackColor = System.Drawing.Color.Black;
            this.btnFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFinish.ForeColor = System.Drawing.Color.White;
            this.btnFinish.Location = new System.Drawing.Point(356, 6);
            this.btnFinish.Margin = new System.Windows.Forms.Padding(6);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(67, 30);
            this.btnFinish.TabIndex = 10;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Click += new System.EventHandler(this.BtnFinishClick);
            // 
            // ofdDetect
            // 
            this.ofdDetect.FileName = "openFileDialog1";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(230, 165);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 13);
            this.label17.TabIndex = 63;
            this.label17.Text = "frames";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(230, 107);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(47, 13);
            this.label35.TabIndex = 57;
            this.label35.Text = "seconds";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 165);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(91, 13);
            this.label26.TabIndex = 61;
            this.label26.Text = "Pre-Buffer Frames";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(5, 110);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(94, 13);
            this.label34.TabIndex = 56;
            this.label34.Text = "Max. Record Time";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(230, 139);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(47, 13);
            this.label24.TabIndex = 60;
            this.label24.Text = "seconds";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 13);
            this.label14.TabIndex = 52;
            this.label14.Text = "Record Timelapse";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 139);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(86, 13);
            this.label25.TabIndex = 58;
            this.label25.Text = "Calibration Delay";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(230, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "seconds";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(6, 80);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(87, 13);
            this.label32.TabIndex = 49;
            this.label32.Text = "Inactivity Record";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(230, 80);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(47, 13);
            this.label31.TabIndex = 51;
            this.label31.Text = "seconds";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 693);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(657, 47);
            this.panel3.TabIndex = 48;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 222F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel3, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(657, 47);
            this.tableLayoutPanel4.TabIndex = 48;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnFinish);
            this.flowLayoutPanel3.Controls.Add(this.btnNext);
            this.flowLayoutPanel3.Controls.Add(this.btnBack);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(225, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(429, 41);
            this.flowLayoutPanel3.TabIndex = 48;
            // 
            // AddCamera
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(677, 750);
            this.Controls.Add(this.tcCamera);
            this.Controls.Add(this.panel3);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimizeBox = false;
            this.Name = "AddCamera";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Camera";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.AddCamera_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddCameraFormClosing);
            this.Load += new System.EventHandler(this.AddCameraLoad);
            this.tcCamera.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.flowLayoutPanel26.ResumeLayout(false);
            this.flowLayoutPanel26.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxFR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxFRRecording)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.gbZones.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel17.ResumeLayout(false);
            this.flowLayoutPanel17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numProcessInterval)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoOff)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.pnlMovement.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxRecordTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinRecordTime)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.flowLayoutPanel10.ResumeLayout(false);
            this.flowLayoutPanel10.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.pnlPTZControls.ResumeLayout(false);
            this.pnlPTZControls.PerformLayout();
            this.tableLayoutPanel12.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.flowLayoutPanel31.ResumeLayout(false);
            this.flowLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.flowLayoutPanel23.ResumeLayout(false);
            this.flowLayoutPanel23.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tcCamera;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtCameraName;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMovement;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkMovement;
        private System.Windows.Forms.OpenFileDialog ofdDetect;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox ddlMotionDetector;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkSuppressNoise;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label13;

        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox ddlProcessor;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox gbZones;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.ComboBox ddlPTZ;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.ListBox lbExtended;
        private System.Windows.Forms.NumericUpDown txtMaxRecordTime;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.ComboBox ddlAlertMode;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numMaxFR;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.NumericUpDown numMaxFRRecording;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Panel pnlPTZControls;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox chkColourProcessing;
        private System.Windows.Forms.RadioButton rdoMotion;
        private System.Windows.Forms.RadioButton rdoContinuous;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoNoRecord;
        private System.Windows.Forms.RadioButton rdoRecordDetect;
        private System.Windows.Forms.RadioButton rdoRecordAlert;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.Panel panel5;
        private AreaSelector AreaControl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel17;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel23;
        private System.Windows.Forms.LinkLabel llblEditPTZ;
        private System.Windows.Forms.LinkLabel linkLabel10;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel26;
        private System.Windows.Forms.Button btnMic;
        private System.Windows.Forms.Label lblMicSource;
        private Ranger ranger1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkIgnoreAudio;
        private System.Windows.Forms.LinkLabel llblClearAll;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel31;
        private System.Windows.Forms.Button btnAddPreset;
        private System.Windows.Forms.Button btnDeletePreset;
        private System.Windows.Forms.RadioButton rdoTrigger;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.NumericUpDown numAutoOff;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private ActionEditor actionEditor1;
        private System.Windows.Forms.ComboBox ddlActionType;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private IntervalConfig intervalConfig1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.Button btnPTZTrack;
        private System.Windows.Forms.Button btnPTZSchedule;
        private System.Windows.Forms.NumericUpDown numMinRecordTime;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.CheckBox chkMessaging;
        private System.Windows.Forms.Button button6;
        private PTZUI ptzui1;
        private System.Windows.Forms.NumericUpDown numProcessInterval;
    }
}