namespace Onvif_test
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.buttonGetCapabilities = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonZoomOut = new System.Windows.Forms.Button();
            this.buttonZoomIn = new System.Windows.Forms.Button();
            this.buttonMoveDown = new System.Windows.Forms.Button();
            this.buttonMoveLeft = new System.Windows.Forms.Button();
            this.buttonMoveRight = new System.Windows.Forms.Button();
            this.buttonMoveUp = new System.Windows.Forms.Button();
            this.buttonGetPresets = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonGetProfiles = new System.Windows.Forms.Button();
            this.comboBoxProfileTokens = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxPresets = new System.Windows.Forms.ComboBox();
            this.buttonPresetGo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trackBarMoveSpeed = new System.Windows.Forms.TrackBar();
            this.buttonGetStatus = new System.Windows.Forms.Button();
            this.buttonGetStreamURI = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonGoToStatus = new System.Windows.Forms.Button();
            this.buttonGoStream = new System.Windows.Forms.Button();
            this.comboBoxStreamURIs = new System.Windows.Forms.ComboBox();
            this.Streams = new System.Windows.Forms.Label();
            this.vlcControl1 = new Vlc.DotNet.Forms.VlcControl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMoveSpeed)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ONVIF URL";
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Location = new System.Drawing.Point(76, 18);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(202, 20);
            this.textBoxUrl.TabIndex = 1;
            this.textBoxUrl.Text = "http://10.205.6.82/onvif/services";
            // 
            // buttonGetCapabilities
            // 
            this.buttonGetCapabilities.Location = new System.Drawing.Point(87, 19);
            this.buttonGetCapabilities.Name = "buttonGetCapabilities";
            this.buttonGetCapabilities.Size = new System.Drawing.Size(75, 23);
            this.buttonGetCapabilities.TabIndex = 2;
            this.buttonGetCapabilities.Text = "Capabilities";
            this.buttonGetCapabilities.UseVisualStyleBackColor = true;
            this.buttonGetCapabilities.Click += new System.EventHandler(this.buttonGetCapabilities_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(76, 44);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(202, 20);
            this.textBoxUsername.TabIndex = 4;
            this.textBoxUsername.Text = "onvif";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(76, 70);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(202, 20);
            this.textBoxPassword.TabIndex = 4;
            this.textBoxPassword.Text = "seeatms";
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // buttonZoomOut
            // 
            this.buttonZoomOut.Enabled = false;
            this.buttonZoomOut.Location = new System.Drawing.Point(168, 93);
            this.buttonZoomOut.Name = "buttonZoomOut";
            this.buttonZoomOut.Size = new System.Drawing.Size(30, 23);
            this.buttonZoomOut.TabIndex = 13;
            this.buttonZoomOut.Text = "z";
            this.toolTip1.SetToolTip(this.buttonZoomOut, "zoom in");
            this.buttonZoomOut.UseVisualStyleBackColor = true;
            this.buttonZoomOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonZoomOut_MouseDown);
            this.buttonZoomOut.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonMove_MouseUp);
            // 
            // buttonZoomIn
            // 
            this.buttonZoomIn.Enabled = false;
            this.buttonZoomIn.Location = new System.Drawing.Point(132, 93);
            this.buttonZoomIn.Name = "buttonZoomIn";
            this.buttonZoomIn.Size = new System.Drawing.Size(30, 23);
            this.buttonZoomIn.TabIndex = 13;
            this.buttonZoomIn.Text = "Z";
            this.toolTip1.SetToolTip(this.buttonZoomIn, "zoom out");
            this.buttonZoomIn.UseVisualStyleBackColor = true;
            this.buttonZoomIn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonZoomIn_MouseDown);
            this.buttonZoomIn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonMove_MouseUp);
            // 
            // buttonMoveDown
            // 
            this.buttonMoveDown.AutoSize = true;
            this.buttonMoveDown.Enabled = false;
            this.buttonMoveDown.Location = new System.Drawing.Point(43, 144);
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.buttonMoveDown.Size = new System.Drawing.Size(30, 23);
            this.buttonMoveDown.TabIndex = 11;
            this.buttonMoveDown.Text = "D";
            this.toolTip1.SetToolTip(this.buttonMoveDown, "tilt down");
            this.buttonMoveDown.UseVisualStyleBackColor = true;
            this.buttonMoveDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonMoveDown_MouseDown);
            this.buttonMoveDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonMove_MouseUp);
            // 
            // buttonMoveLeft
            // 
            this.buttonMoveLeft.AutoSize = true;
            this.buttonMoveLeft.Enabled = false;
            this.buttonMoveLeft.Location = new System.Drawing.Point(7, 131);
            this.buttonMoveLeft.Name = "buttonMoveLeft";
            this.buttonMoveLeft.Size = new System.Drawing.Size(30, 23);
            this.buttonMoveLeft.TabIndex = 11;
            this.buttonMoveLeft.Text = "L";
            this.toolTip1.SetToolTip(this.buttonMoveLeft, "pan left");
            this.buttonMoveLeft.UseVisualStyleBackColor = true;
            this.buttonMoveLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonMoveLeft_MouseDown);
            this.buttonMoveLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonMove_MouseUp);
            // 
            // buttonMoveRight
            // 
            this.buttonMoveRight.AutoSize = true;
            this.buttonMoveRight.Enabled = false;
            this.buttonMoveRight.Location = new System.Drawing.Point(79, 131);
            this.buttonMoveRight.Name = "buttonMoveRight";
            this.buttonMoveRight.Size = new System.Drawing.Size(30, 23);
            this.buttonMoveRight.TabIndex = 11;
            this.buttonMoveRight.Text = "R";
            this.toolTip1.SetToolTip(this.buttonMoveRight, "pan right");
            this.buttonMoveRight.UseVisualStyleBackColor = true;
            this.buttonMoveRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonMoveRight_MouseDown);
            this.buttonMoveRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonMove_MouseUp);
            // 
            // buttonMoveUp
            // 
            this.buttonMoveUp.AutoSize = true;
            this.buttonMoveUp.Enabled = false;
            this.buttonMoveUp.Location = new System.Drawing.Point(43, 117);
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.buttonMoveUp.Size = new System.Drawing.Size(30, 23);
            this.buttonMoveUp.TabIndex = 11;
            this.buttonMoveUp.Text = "U";
            this.toolTip1.SetToolTip(this.buttonMoveUp, "tilt up");
            this.buttonMoveUp.UseVisualStyleBackColor = true;
            this.buttonMoveUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonMoveUp_MouseDown);
            this.buttonMoveUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonMove_MouseUp);
            // 
            // buttonGetPresets
            // 
            this.buttonGetPresets.Enabled = false;
            this.buttonGetPresets.Location = new System.Drawing.Point(6, 48);
            this.buttonGetPresets.Name = "buttonGetPresets";
            this.buttonGetPresets.Size = new System.Drawing.Size(75, 23);
            this.buttonGetPresets.TabIndex = 5;
            this.buttonGetPresets.Text = "Presets";
            this.buttonGetPresets.UseVisualStyleBackColor = true;
            this.buttonGetPresets.Click += new System.EventHandler(this.buttonGetPresets_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Profile";
            // 
            // buttonGetProfiles
            // 
            this.buttonGetProfiles.Location = new System.Drawing.Point(6, 19);
            this.buttonGetProfiles.Name = "buttonGetProfiles";
            this.buttonGetProfiles.Size = new System.Drawing.Size(75, 23);
            this.buttonGetProfiles.TabIndex = 8;
            this.buttonGetProfiles.Text = "Profiles";
            this.buttonGetProfiles.UseVisualStyleBackColor = true;
            this.buttonGetProfiles.Click += new System.EventHandler(this.buttonGetProfiles_Click);
            // 
            // comboBoxProfileTokens
            // 
            this.comboBoxProfileTokens.Enabled = false;
            this.comboBoxProfileTokens.FormattingEnabled = true;
            this.comboBoxProfileTokens.Location = new System.Drawing.Point(57, 22);
            this.comboBoxProfileTokens.Name = "comboBoxProfileTokens";
            this.comboBoxProfileTokens.Size = new System.Drawing.Size(148, 21);
            this.comboBoxProfileTokens.TabIndex = 9;
            this.comboBoxProfileTokens.SelectedIndexChanged += new System.EventHandler(this.comboBoxProfileTokens_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Presets";
            // 
            // comboBoxPresets
            // 
            this.comboBoxPresets.Enabled = false;
            this.comboBoxPresets.FormattingEnabled = true;
            this.comboBoxPresets.Location = new System.Drawing.Point(57, 48);
            this.comboBoxPresets.Name = "comboBoxPresets";
            this.comboBoxPresets.Size = new System.Drawing.Size(148, 21);
            this.comboBoxPresets.TabIndex = 9;
            this.comboBoxPresets.SelectedIndexChanged += new System.EventHandler(this.comboBoxPresets_SelectedIndexChanged);
            // 
            // buttonPresetGo
            // 
            this.buttonPresetGo.Enabled = false;
            this.buttonPresetGo.Location = new System.Drawing.Point(211, 47);
            this.buttonPresetGo.Name = "buttonPresetGo";
            this.buttonPresetGo.Size = new System.Drawing.Size(75, 23);
            this.buttonPresetGo.TabIndex = 10;
            this.buttonPresetGo.Text = "Go";
            this.buttonPresetGo.UseVisualStyleBackColor = true;
            this.buttonPresetGo.Click += new System.EventHandler(this.buttonPresetGo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonZoomOut);
            this.groupBox1.Controls.Add(this.buttonZoomIn);
            this.groupBox1.Controls.Add(this.trackBarMoveSpeed);
            this.groupBox1.Controls.Add(this.buttonMoveDown);
            this.groupBox1.Controls.Add(this.buttonMoveLeft);
            this.groupBox1.Controls.Add(this.buttonMoveRight);
            this.groupBox1.Controls.Add(this.buttonMoveUp);
            this.groupBox1.Controls.Add(this.buttonGetStatus);
            this.groupBox1.Controls.Add(this.buttonGetStreamURI);
            this.groupBox1.Controls.Add(this.buttonGetCapabilities);
            this.groupBox1.Controls.Add(this.buttonGetProfiles);
            this.groupBox1.Controls.Add(this.buttonGetPresets);
            this.groupBox1.Location = new System.Drawing.Point(9, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 173);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Get";
            // 
            // trackBarMoveSpeed
            // 
            this.trackBarMoveSpeed.Location = new System.Drawing.Point(125, 122);
            this.trackBarMoveSpeed.Maximum = 100;
            this.trackBarMoveSpeed.Name = "trackBarMoveSpeed";
            this.trackBarMoveSpeed.Size = new System.Drawing.Size(153, 45);
            this.trackBarMoveSpeed.TabIndex = 12;
            this.trackBarMoveSpeed.Value = 75;
            this.trackBarMoveSpeed.Scroll += new System.EventHandler(this.trackBarMoveSpeed_Scroll);
            // 
            // buttonGetStatus
            // 
            this.buttonGetStatus.Enabled = false;
            this.buttonGetStatus.Location = new System.Drawing.Point(87, 48);
            this.buttonGetStatus.Name = "buttonGetStatus";
            this.buttonGetStatus.Size = new System.Drawing.Size(75, 23);
            this.buttonGetStatus.TabIndex = 10;
            this.buttonGetStatus.Text = "Status";
            this.buttonGetStatus.UseVisualStyleBackColor = true;
            this.buttonGetStatus.Click += new System.EventHandler(this.buttonGetStatus_Click);
            // 
            // buttonGetStreamURI
            // 
            this.buttonGetStreamURI.Enabled = false;
            this.buttonGetStreamURI.Location = new System.Drawing.Point(168, 19);
            this.buttonGetStreamURI.Name = "buttonGetStreamURI";
            this.buttonGetStreamURI.Size = new System.Drawing.Size(75, 23);
            this.buttonGetStreamURI.TabIndex = 9;
            this.buttonGetStreamURI.Text = "StreamURIs";
            this.buttonGetStreamURI.UseVisualStyleBackColor = true;
            this.buttonGetStreamURI.Click += new System.EventHandler(this.buttonGetStreamURI_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxUsername);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxUrl);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxPassword);
            this.groupBox2.Location = new System.Drawing.Point(9, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 105);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Camera";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonGoToStatus);
            this.groupBox3.Controls.Add(this.buttonGoStream);
            this.groupBox3.Controls.Add(this.comboBoxStreamURIs);
            this.groupBox3.Controls.Add(this.comboBoxPresets);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.Streams);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.buttonPresetGo);
            this.groupBox3.Controls.Add(this.comboBoxProfileTokens);
            this.groupBox3.Location = new System.Drawing.Point(9, 302);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(294, 173);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Commands";
            // 
            // buttonGoToStatus
            // 
            this.buttonGoToStatus.Location = new System.Drawing.Point(211, 22);
            this.buttonGoToStatus.Name = "buttonGoToStatus";
            this.buttonGoToStatus.Size = new System.Drawing.Size(75, 23);
            this.buttonGoToStatus.TabIndex = 13;
            this.buttonGoToStatus.Text = "GoTo";
            this.buttonGoToStatus.UseVisualStyleBackColor = true;
            this.buttonGoToStatus.Click += new System.EventHandler(this.buttonGoToStatus_Click);
            // 
            // buttonGoStream
            // 
            this.buttonGoStream.Enabled = false;
            this.buttonGoStream.Location = new System.Drawing.Point(211, 74);
            this.buttonGoStream.Name = "buttonGoStream";
            this.buttonGoStream.Size = new System.Drawing.Size(75, 23);
            this.buttonGoStream.TabIndex = 12;
            this.buttonGoStream.Text = "Go";
            this.buttonGoStream.UseVisualStyleBackColor = true;
            this.buttonGoStream.Click += new System.EventHandler(this.buttonGoStream_Click);
            // 
            // comboBoxStreamURIs
            // 
            this.comboBoxStreamURIs.DropDownWidth = 255;
            this.comboBoxStreamURIs.Enabled = false;
            this.comboBoxStreamURIs.FormattingEnabled = true;
            this.comboBoxStreamURIs.Location = new System.Drawing.Point(57, 76);
            this.comboBoxStreamURIs.Name = "comboBoxStreamURIs";
            this.comboBoxStreamURIs.Size = new System.Drawing.Size(148, 21);
            this.comboBoxStreamURIs.TabIndex = 11;
            this.comboBoxStreamURIs.SelectedIndexChanged += new System.EventHandler(this.comboBoxStreamURIs_SelectedIndexChanged);
            // 
            // Streams
            // 
            this.Streams.AutoSize = true;
            this.Streams.Location = new System.Drawing.Point(6, 79);
            this.Streams.Name = "Streams";
            this.Streams.Size = new System.Drawing.Size(45, 13);
            this.Streams.TabIndex = 6;
            this.Streams.Text = "Streams";
            // 
            // vlcControl1
            // 
            this.vlcControl1.BackColor = System.Drawing.Color.Black;
            this.vlcControl1.Location = new System.Drawing.Point(310, 12);
            this.vlcControl1.Name = "vlcControl1";
            this.vlcControl1.Size = new System.Drawing.Size(626, 460);
            this.vlcControl1.Spu = -1;
            this.vlcControl1.TabIndex = 14;
            this.vlcControl1.Text = "vlcControl1";
            this.vlcControl1.VlcLibDirectory = ((System.IO.DirectoryInfo)(resources.GetObject("vlcControl1.VlcLibDirectory")));
            this.vlcControl1.VlcMediaplayerOptions = null;
            this.vlcControl1.EncounteredError += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerEncounteredErrorEventArgs>(this.vlcControl1_EncounteredError);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 484);
            this.Controls.Add(this.vlcControl1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "ONVIF Test";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMoveSpeed)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.Button buttonGetCapabilities;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonGetPresets;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonGetProfiles;
        private System.Windows.Forms.ComboBox comboBoxProfileTokens;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxPresets;
        private System.Windows.Forms.Button buttonPresetGo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonGetStreamURI;
        private System.Windows.Forms.Button buttonGoStream;
        private System.Windows.Forms.ComboBox comboBoxStreamURIs;
        private System.Windows.Forms.Label Streams;
        private Vlc.DotNet.Forms.VlcControl vlcControl1;
        private System.Windows.Forms.Button buttonGetStatus;
        private System.Windows.Forms.Button buttonGoToStatus;
        private System.Windows.Forms.Button buttonMoveDown;
        private System.Windows.Forms.Button buttonMoveLeft;
        private System.Windows.Forms.Button buttonMoveRight;
        private System.Windows.Forms.Button buttonMoveUp;
        private System.Windows.Forms.TrackBar trackBarMoveSpeed;
        private System.Windows.Forms.Button buttonZoomOut;
        private System.Windows.Forms.Button buttonZoomIn;
    }
}

