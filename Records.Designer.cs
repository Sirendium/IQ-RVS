namespace iSpyApplication
{
    partial class Records
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Records));
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.flowPreview = new iSpyApplication.Controls.MediaPanel();
            this.mediaPanelControl1 = new iSpyApplication.Controls.MediaPanelControl();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.mediaPanelControl1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(207, 489);
            this.panel4.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.flowPreview);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 32);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(207, 457);
            this.panel6.TabIndex = 22;
            // 
            // flowPreview
            // 
            this.flowPreview.AutoScroll = true;
            this.flowPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(143)))), ((int)(((byte)(186)))));
            this.flowPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPreview.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPreview.Location = new System.Drawing.Point(0, 0);
            this.flowPreview.Margin = new System.Windows.Forms.Padding(0);
            this.flowPreview.Name = "flowPreview";
            this.flowPreview.Padding = new System.Windows.Forms.Padding(2);
            this.flowPreview.Size = new System.Drawing.Size(207, 457);
            this.flowPreview.TabIndex = 0;
            // 
            // mediaPanelControl1
            // 
            this.mediaPanelControl1.AutoSize = true;
            this.mediaPanelControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(143)))), ((int)(((byte)(186)))));
            this.mediaPanelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.mediaPanelControl1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mediaPanelControl1.Location = new System.Drawing.Point(0, 0);
            this.mediaPanelControl1.Margin = new System.Windows.Forms.Padding(0);
            this.mediaPanelControl1.Name = "mediaPanelControl1";
            this.mediaPanelControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.mediaPanelControl1.Size = new System.Drawing.Size(207, 32);
            this.mediaPanelControl1.TabIndex = 21;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.DimGray;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBox1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 23;
            this.listBox1.Location = new System.Drawing.Point(213, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(467, 489);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Records
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(680, 489);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Records";
            this.Text = "Records";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        internal Controls.MediaPanel flowPreview;
        private Controls.MediaPanelControl mediaPanelControl1;
        private System.Windows.Forms.ListBox listBox1;
    }
}