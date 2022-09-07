namespace CityAir_Node_Configurator
{
    partial class ConfiguratorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfiguratorForm));
            this.portComboBox = new System.Windows.Forms.ComboBox();
            this.rescanButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.altitudeTextBox = new System.Windows.Forms.TextBox();
            this.longitudeTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.latitudeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.debuggsmCheckBox = new System.Windows.Forms.CheckBox();
            this.debugCheckBox = new System.Windows.Forms.CheckBox();
            this.measuretimesTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.looptimeTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.apnTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.writeButton = new System.Windows.Forms.Button();
            this.readButton = new System.Windows.Forms.Button();
            this.defaultButton = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // portComboBox
            // 
            this.portComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portComboBox.FormattingEnabled = true;
            this.portComboBox.Location = new System.Drawing.Point(6, 20);
            this.portComboBox.Name = "portComboBox";
            this.portComboBox.Size = new System.Drawing.Size(70, 21);
            this.portComboBox.TabIndex = 1;
            // 
            // rescanButton
            // 
            this.rescanButton.Location = new System.Drawing.Point(82, 19);
            this.rescanButton.Name = "rescanButton";
            this.rescanButton.Size = new System.Drawing.Size(73, 23);
            this.rescanButton.TabIndex = 2;
            this.rescanButton.Text = "Rescan";
            this.rescanButton.UseVisualStyleBackColor = true;
            this.rescanButton.Click += new System.EventHandler(this.rescanButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.connectButton);
            this.groupBox1.Controls.Add(this.rescanButton);
            this.groupBox1.Controls.Add(this.portComboBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 80);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Port";
            // 
            // connectButton
            // 
            this.connectButton.Enabled = false;
            this.connectButton.Location = new System.Drawing.Point(6, 48);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(149, 23);
            this.connectButton.TabIndex = 3;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.altitudeTextBox);
            this.groupBox2.Controls.Add(this.longitudeTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.latitudeTextBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.idTextBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(163, 125);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sensor Node";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "ALTITUDE:";
            // 
            // altitudeTextBox
            // 
            this.altitudeTextBox.Location = new System.Drawing.Point(85, 97);
            this.altitudeTextBox.Name = "altitudeTextBox";
            this.altitudeTextBox.Size = new System.Drawing.Size(70, 20);
            this.altitudeTextBox.TabIndex = 6;
            this.altitudeTextBox.Text = "159.1";
            // 
            // longitudeTextBox
            // 
            this.longitudeTextBox.Location = new System.Drawing.Point(85, 71);
            this.longitudeTextBox.Name = "longitudeTextBox";
            this.longitudeTextBox.Size = new System.Drawing.Size(70, 20);
            this.longitudeTextBox.TabIndex = 5;
            this.longitudeTextBox.Text = "83.112921";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "LONGITUDE:";
            // 
            // latitudeTextBox
            // 
            this.latitudeTextBox.Location = new System.Drawing.Point(85, 45);
            this.latitudeTextBox.Name = "latitudeTextBox";
            this.latitudeTextBox.Size = new System.Drawing.Size(70, 20);
            this.latitudeTextBox.TabIndex = 3;
            this.latitudeTextBox.Text = "54.854441";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "LATITUDE:";
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(85, 19);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(70, 20);
            this.idTextBox.TabIndex = 1;
            this.idTextBox.Text = "101";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.debuggsmCheckBox);
            this.groupBox3.Controls.Add(this.debugCheckBox);
            this.groupBox3.Controls.Add(this.measuretimesTextBox);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.looptimeTextBox);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(251, 315);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(187, 100);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Configuration";
            // 
            // debuggsmCheckBox
            // 
            this.debuggsmCheckBox.AutoSize = true;
            this.debuggsmCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.debuggsmCheckBox.Location = new System.Drawing.Point(84, 73);
            this.debuggsmCheckBox.Name = "debuggsmCheckBox";
            this.debuggsmCheckBox.Size = new System.Drawing.Size(94, 17);
            this.debuggsmCheckBox.TabIndex = 9;
            this.debuggsmCheckBox.Text = "DEBUG_GSM";
            this.debuggsmCheckBox.UseVisualStyleBackColor = true;
            // 
            // debugCheckBox
            // 
            this.debugCheckBox.AutoSize = true;
            this.debugCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.debugCheckBox.Location = new System.Drawing.Point(6, 73);
            this.debugCheckBox.Name = "debugCheckBox";
            this.debugCheckBox.Size = new System.Drawing.Size(64, 17);
            this.debugCheckBox.TabIndex = 8;
            this.debugCheckBox.Text = "DEBUG";
            this.debugCheckBox.UseVisualStyleBackColor = true;
            // 
            // measuretimesTextBox
            // 
            this.measuretimesTextBox.Location = new System.Drawing.Point(108, 45);
            this.measuretimesTextBox.Name = "measuretimesTextBox";
            this.measuretimesTextBox.Size = new System.Drawing.Size(70, 20);
            this.measuretimesTextBox.TabIndex = 3;
            this.measuretimesTextBox.Text = "30";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "MEASURETIMES:";
            // 
            // looptimeTextBox
            // 
            this.looptimeTextBox.Location = new System.Drawing.Point(108, 19);
            this.looptimeTextBox.Name = "looptimeTextBox";
            this.looptimeTextBox.Size = new System.Drawing.Size(70, 20);
            this.looptimeTextBox.TabIndex = 1;
            this.looptimeTextBox.Text = "180000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "LOOPTIME:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.passwordTextBox);
            this.groupBox4.Controls.Add(this.usernameTextBox);
            this.groupBox4.Controls.Add(this.apnTextBox);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(12, 315);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(230, 100);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Connection";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "GPRS_PASSWORD:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "GPRS_USERNAME:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(121, 70);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(100, 20);
            this.passwordTextBox.TabIndex = 3;
            this.passwordTextBox.Text = "gdata";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(121, 45);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(100, 20);
            this.usernameTextBox.TabIndex = 2;
            this.usernameTextBox.Text = "gdata";
            // 
            // apnTextBox
            // 
            this.apnTextBox.Location = new System.Drawing.Point(121, 19);
            this.apnTextBox.Name = "apnTextBox";
            this.apnTextBox.Size = new System.Drawing.Size(100, 20);
            this.apnTextBox.TabIndex = 1;
            this.apnTextBox.Text = "internet";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "GPRS_APN:";
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(44, 19);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(373, 20);
            this.urlTextBox.TabIndex = 4;
            this.urlTextBox.Text = "104.155.87.12:8080/postPacket?authkey=J3UK0ex9RUVhzgFi9BeI";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "URL:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.urlTextBox);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Location = new System.Drawing.Point(12, 421);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(426, 50);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "POST";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.writeButton);
            this.groupBox6.Controls.Add(this.readButton);
            this.groupBox6.Controls.Add(this.defaultButton);
            this.groupBox6.Location = new System.Drawing.Point(12, 98);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(163, 80);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Parameters";
            // 
            // writeButton
            // 
            this.writeButton.Enabled = false;
            this.writeButton.Location = new System.Drawing.Point(82, 19);
            this.writeButton.Name = "writeButton";
            this.writeButton.Size = new System.Drawing.Size(73, 52);
            this.writeButton.TabIndex = 2;
            this.writeButton.Text = "Write";
            this.writeButton.UseVisualStyleBackColor = true;
            this.writeButton.Click += new System.EventHandler(this.writeButton_Click);
            // 
            // readButton
            // 
            this.readButton.Enabled = false;
            this.readButton.Location = new System.Drawing.Point(6, 48);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(70, 23);
            this.readButton.TabIndex = 1;
            this.readButton.Text = "Read";
            this.readButton.UseVisualStyleBackColor = true;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // defaultButton
            // 
            this.defaultButton.Location = new System.Drawing.Point(6, 19);
            this.defaultButton.Name = "defaultButton";
            this.defaultButton.Size = new System.Drawing.Size(70, 23);
            this.defaultButton.TabIndex = 0;
            this.defaultButton.Text = "Default";
            this.defaultButton.UseVisualStyleBackColor = true;
            this.defaultButton.Click += new System.EventHandler(this.defaultButton_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(6, 19);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(245, 270);
            this.logTextBox.TabIndex = 12;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.logTextBox);
            this.groupBox7.Location = new System.Drawing.Point(181, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(257, 297);
            this.groupBox7.TabIndex = 12;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Log";
            // 
            // ConfiguratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 484);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConfiguratorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CityAir Node Configurator - RobotAero, 2016";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.configuratorForm_FormClosing);
            this.Load += new System.EventHandler(this.configuratorForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox portComboBox;
        private System.Windows.Forms.Button rescanButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button connectButton;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox altitudeTextBox;
        private System.Windows.Forms.TextBox longitudeTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox latitudeTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox debuggsmCheckBox;
        private System.Windows.Forms.CheckBox debugCheckBox;
        private System.Windows.Forms.TextBox measuretimesTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox looptimeTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox apnTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button writeButton;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Button defaultButton;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.GroupBox groupBox7;
    }
}

