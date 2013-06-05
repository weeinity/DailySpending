namespace Webcam_Timelaps_prototype1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MyTimer = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timeLaps_groupBox = new System.Windows.Forms.GroupBox();
            this.About_btn = new System.Windows.Forms.Button();
            this.screenGrab_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.To_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.From_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timeLaps_label2_txt = new System.Windows.Forms.Label();
            this.timelaps_on_off_btn = new System.Windows.Forms.Button();
            this.timeLaps_label1_txt = new System.Windows.Forms.Label();
            this.timeLaps_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Preview_groupBox = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NoImage_label_txt = new System.Windows.Forms.Label();
            this.timeLaps_groupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeLaps_numericUpDown)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.Preview_groupBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MyTimer
            // 
            this.MyTimer.Interval = 1000;
            this.MyTimer.Tick += new System.EventHandler(this.MyTimer_Tick);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(67, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(535, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Devices :";
            // 
            // timeLaps_groupBox
            // 
            this.timeLaps_groupBox.Controls.Add(this.About_btn);
            this.timeLaps_groupBox.Controls.Add(this.screenGrab_btn);
            this.timeLaps_groupBox.Controls.Add(this.groupBox1);
            this.timeLaps_groupBox.Controls.Add(this.textBox1);
            this.timeLaps_groupBox.Controls.Add(this.label1);
            this.timeLaps_groupBox.Controls.Add(this.timeLaps_label2_txt);
            this.timeLaps_groupBox.Controls.Add(this.timelaps_on_off_btn);
            this.timeLaps_groupBox.Controls.Add(this.timeLaps_label1_txt);
            this.timeLaps_groupBox.Controls.Add(this.timeLaps_numericUpDown);
            this.timeLaps_groupBox.Location = new System.Drawing.Point(12, 41);
            this.timeLaps_groupBox.Name = "timeLaps_groupBox";
            this.timeLaps_groupBox.Size = new System.Drawing.Size(246, 274);
            this.timeLaps_groupBox.TabIndex = 7;
            this.timeLaps_groupBox.TabStop = false;
            this.timeLaps_groupBox.Text = "Time Lapse Mode:";
            // 
            // About_btn
            // 
            this.About_btn.Location = new System.Drawing.Point(171, 243);
            this.About_btn.Name = "About_btn";
            this.About_btn.Size = new System.Drawing.Size(58, 23);
            this.About_btn.TabIndex = 20;
            this.About_btn.Text = "Credits";
            this.About_btn.UseVisualStyleBackColor = true;
            this.About_btn.Click += new System.EventHandler(this.About_btn_Click);
            // 
            // screenGrab_btn
            // 
            this.screenGrab_btn.Location = new System.Drawing.Point(90, 243);
            this.screenGrab_btn.Name = "screenGrab_btn";
            this.screenGrab_btn.Size = new System.Drawing.Size(75, 23);
            this.screenGrab_btn.TabIndex = 19;
            this.screenGrab_btn.Text = "Screen Grab";
            this.screenGrab_btn.UseVisualStyleBackColor = true;
            this.screenGrab_btn.Click += new System.EventHandler(this.screenGrab_btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.To_dateTimePicker);
            this.groupBox1.Controls.Add(this.From_dateTimePicker);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(6, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 137);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Timed Run :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "To :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "From :";
            // 
            // To_dateTimePicker
            // 
            this.To_dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.To_dateTimePicker.Location = new System.Drawing.Point(3, 106);
            this.To_dateTimePicker.MinDate = new System.DateTime(2009, 1, 1, 0, 0, 0, 0);
            this.To_dateTimePicker.Name = "To_dateTimePicker";
            this.To_dateTimePicker.Size = new System.Drawing.Size(225, 20);
            this.To_dateTimePicker.TabIndex = 20;
            // 
            // From_dateTimePicker
            // 
            this.From_dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.From_dateTimePicker.Location = new System.Drawing.Point(3, 57);
            this.From_dateTimePicker.Name = "From_dateTimePicker";
            this.From_dateTimePicker.Size = new System.Drawing.Size(225, 20);
            this.From_dateTimePicker.TabIndex = 19;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(73, 17);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "Timed run";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(78, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(72, 20);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "25,000";
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Clip FPS :";
            // 
            // timeLaps_label2_txt
            // 
            this.timeLaps_label2_txt.AutoSize = true;
            this.timeLaps_label2_txt.Location = new System.Drawing.Point(6, 21);
            this.timeLaps_label2_txt.Name = "timeLaps_label2_txt";
            this.timeLaps_label2_txt.Size = new System.Drawing.Size(66, 13);
            this.timeLaps_label2_txt.TabIndex = 9;
            this.timeLaps_label2_txt.Text = "Delay Time :";
            // 
            // timelaps_on_off_btn
            // 
            this.timelaps_on_off_btn.Location = new System.Drawing.Point(9, 243);
            this.timelaps_on_off_btn.Name = "timelaps_on_off_btn";
            this.timelaps_on_off_btn.Size = new System.Drawing.Size(75, 23);
            this.timelaps_on_off_btn.TabIndex = 8;
            this.timelaps_on_off_btn.Text = "Start";
            this.timelaps_on_off_btn.UseVisualStyleBackColor = true;
            this.timelaps_on_off_btn.Click += new System.EventHandler(this.timelaps_on_off_btn_Click);
            // 
            // timeLaps_label1_txt
            // 
            this.timeLaps_label1_txt.AutoSize = true;
            this.timeLaps_label1_txt.Location = new System.Drawing.Point(156, 21);
            this.timeLaps_label1_txt.Name = "timeLaps_label1_txt";
            this.timeLaps_label1_txt.Size = new System.Drawing.Size(20, 13);
            this.timeLaps_label1_txt.TabIndex = 7;
            this.timeLaps_label1_txt.Text = "ms";
            // 
            // timeLaps_numericUpDown
            // 
            this.timeLaps_numericUpDown.Location = new System.Drawing.Point(78, 19);
            this.timeLaps_numericUpDown.Maximum = new decimal(new int[] {
            120000,
            0,
            0,
            0});
            this.timeLaps_numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.timeLaps_numericUpDown.Name = "timeLaps_numericUpDown";
            this.timeLaps_numericUpDown.Size = new System.Drawing.Size(72, 20);
            this.timeLaps_numericUpDown.TabIndex = 6;
            this.timeLaps_numericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 323);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(614, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabel1.Text = "...";
            // 
            // Preview_groupBox
            // 
            this.Preview_groupBox.Controls.Add(this.panel1);
            this.Preview_groupBox.Location = new System.Drawing.Point(270, 41);
            this.Preview_groupBox.Name = "Preview_groupBox";
            this.Preview_groupBox.Size = new System.Drawing.Size(332, 274);
            this.Preview_groupBox.TabIndex = 10;
            this.Preview_groupBox.TabStop = false;
            this.Preview_groupBox.Text = "Preview :";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.NoImage_label_txt);
            this.panel1.Location = new System.Drawing.Point(6, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 240);
            this.panel1.TabIndex = 7;
            // 
            // NoImage_label_txt
            // 
            this.NoImage_label_txt.AutoSize = true;
            this.NoImage_label_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoImage_label_txt.Location = new System.Drawing.Point(123, 118);
            this.NoImage_label_txt.Name = "NoImage_label_txt";
            this.NoImage_label_txt.Size = new System.Drawing.Size(84, 13);
            this.NoImage_label_txt.TabIndex = 0;
            this.NoImage_label_txt.Text = "NO IMAGE....";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 345);
            this.Controls.Add(this.Preview_groupBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.timeLaps_groupBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WCamTimelapse";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.timeLaps_groupBox.ResumeLayout(false);
            this.timeLaps_groupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeLaps_numericUpDown)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.Preview_groupBox.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer MyTimer;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox timeLaps_groupBox;
        private System.Windows.Forms.Button timelaps_on_off_btn;
        private System.Windows.Forms.Label timeLaps_label1_txt;
        private System.Windows.Forms.NumericUpDown timeLaps_numericUpDown;
        private System.Windows.Forms.Label timeLaps_label2_txt;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker To_dateTimePicker;
        private System.Windows.Forms.DateTimePicker From_dateTimePicker;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox Preview_groupBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label NoImage_label_txt;
        private System.Windows.Forms.Button screenGrab_btn;
        private System.Windows.Forms.Button About_btn;
    }
}

