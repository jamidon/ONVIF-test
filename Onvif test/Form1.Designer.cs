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
            this.buttonGoToStatus = new System.Windows.Forms.Button();
            this.buttonGetPresets = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonGetProfiles = new System.Windows.Forms.Button();
            this.comboBoxProfileTokens = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxPresets = new System.Windows.Forms.ComboBox();
            this.buttonPresetGo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trackBarMoveSpeed = new System.Windows.Forms.TrackBar();
            this.buttonMoveUpLeft = new System.Windows.Forms.Button();
            this.buttonMoveUpRight = new System.Windows.Forms.Button();
            this.buttonMoveDownLeft = new System.Windows.Forms.Button();
            this.buttonMoveDownRight = new System.Windows.Forms.Button();
            this.buttonGetStatus = new System.Windows.Forms.Button();
            this.buttonGetStreamURI = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonGoAuxCommand = new System.Windows.Forms.Button();
            this.comboBoxAuxCommands = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPresetName = new System.Windows.Forms.TextBox();
            this.textBoxPresetToken = new System.Windows.Forms.TextBox();
            this.buttonSetPreset = new System.Windows.Forms.Button();
            this.buttonDeletePreset = new System.Windows.Forms.Button();
            this.buttonGoStream = new System.Windows.Forms.Button();
            this.comboBoxStreamURIs = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Streams = new System.Windows.Forms.Label();
            this.vlcControl1 = new Vlc.DotNet.Forms.VlcControl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMoveSpeed)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            this.textBoxUrl.Text = "http://192.168.1.113/onvif/media_service";
            this.textBoxUrl.TextChanged += new System.EventHandler(this.endpoint_TextChanged);
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
            this.textBoxUsername.TextChanged += new System.EventHandler(this.endpoint_TextChanged);
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
            this.textBoxPassword.TextChanged += new System.EventHandler(this.endpoint_TextChanged);
            // 
            // buttonZoomOut
            // 
            this.buttonZoomOut.Enabled = false;
            this.buttonZoomOut.Location = new System.Drawing.Point(168, 135);
            this.buttonZoomOut.Name = "buttonZoomOut";
            this.buttonZoomOut.Size = new System.Drawing.Size(30, 23);
            this.buttonZoomOut.TabIndex = 13;
            this.buttonZoomOut.Text = "z";
            this.toolTip1.SetToolTip(this.buttonZoomOut, "zoom out");
            this.buttonZoomOut.UseVisualStyleBackColor = true;
            this.buttonZoomOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonZoomOut_MouseDown);
            this.buttonZoomOut.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonMove_MouseUp);
            // 
            // buttonZoomIn
            // 
            this.buttonZoomIn.Enabled = false;
            this.buttonZoomIn.Location = new System.Drawing.Point(132, 135);
            this.buttonZoomIn.Name = "buttonZoomIn";
            this.buttonZoomIn.Size = new System.Drawing.Size(30, 23);
            this.buttonZoomIn.TabIndex = 13;
            this.buttonZoomIn.Text = "Z";
            this.toolTip1.SetToolTip(this.buttonZoomIn, "zoom in");
            this.buttonZoomIn.UseVisualStyleBackColor = true;
            this.buttonZoomIn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonZoomIn_MouseDown);
            this.buttonZoomIn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonMove_MouseUp);
            // 
            // buttonMoveDown
            // 
            this.buttonMoveDown.AutoSize = true;
            this.buttonMoveDown.Enabled = false;
            this.buttonMoveDown.Location = new System.Drawing.Point(46, 121);
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
            this.buttonMoveLeft.Location = new System.Drawing.Point(6, 106);
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
            this.buttonMoveRight.Location = new System.Drawing.Point(87, 106);
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
            this.buttonMoveUp.Location = new System.Drawing.Point(46, 92);
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.buttonMoveUp.Size = new System.Drawing.Size(30, 23);
            this.buttonMoveUp.TabIndex = 11;
            this.buttonMoveUp.Text = "U";
            this.toolTip1.SetToolTip(this.buttonMoveUp, "tilt up");
            this.buttonMoveUp.UseVisualStyleBackColor = true;
            this.buttonMoveUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonMoveUp_MouseDown);
            this.buttonMoveUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonMove_MouseUp);
            // 
            // buttonGoToStatus
            // 
            this.buttonGoToStatus.Enabled = false;
            this.buttonGoToStatus.Location = new System.Drawing.Point(211, 22);
            this.buttonGoToStatus.Name = "buttonGoToStatus";
            this.buttonGoToStatus.Size = new System.Drawing.Size(75, 23);
            this.buttonGoToStatus.TabIndex = 13;
            this.buttonGoToStatus.Text = "GoTo";
            this.toolTip1.SetToolTip(this.buttonGoToStatus, "Go to position of last status cmd");
            this.buttonGoToStatus.UseVisualStyleBackColor = true;
            this.buttonGoToStatus.Click += new System.EventHandler(this.buttonGoToStatus_Click);
            // 
            // buttonGetPresets
            // 
            this.buttonGetPresets.Enabled = false;
            this.buttonGetPresets.Location = new System.Drawing.Point(168, 48);
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
            this.groupBox1.Controls.Add(this.buttonMoveUpLeft);
            this.groupBox1.Controls.Add(this.buttonMoveUpRight);
            this.groupBox1.Controls.Add(this.buttonMoveDownLeft);
            this.groupBox1.Controls.Add(this.buttonMoveDownRight);
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
            this.groupBox1.Size = new System.Drawing.Size(291, 169);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Get";
            // 
            // trackBarMoveSpeed
            // 
            this.trackBarMoveSpeed.Location = new System.Drawing.Point(125, 77);
            this.trackBarMoveSpeed.Maximum = 100;
            this.trackBarMoveSpeed.Name = "trackBarMoveSpeed";
            this.trackBarMoveSpeed.Size = new System.Drawing.Size(153, 45);
            this.trackBarMoveSpeed.TabIndex = 12;
            this.trackBarMoveSpeed.Value = 75;
            this.trackBarMoveSpeed.Scroll += new System.EventHandler(this.trackBarMoveSpeed_Scroll);
            // 
            // buttonMoveUpLeft
            // 
            this.buttonMoveUpLeft.AutoSize = true;
            this.buttonMoveUpLeft.Enabled = false;
            this.buttonMoveUpLeft.Location = new System.Drawing.Point(6, 77);
            this.buttonMoveUpLeft.Name = "buttonMoveUpLeft";
            this.buttonMoveUpLeft.Size = new System.Drawing.Size(31, 23);
            this.buttonMoveUpLeft.TabIndex = 11;
            this.buttonMoveUpLeft.Text = "UL";
            this.buttonMoveUpLeft.UseVisualStyleBackColor = true;
            this.buttonMoveUpLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonMoveUpLeft_MouseDown);
            this.buttonMoveUpLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonMove_MouseUp);
            // 
            // buttonMoveUpRight
            // 
            this.buttonMoveUpRight.AutoSize = true;
            this.buttonMoveUpRight.Enabled = false;
            this.buttonMoveUpRight.Location = new System.Drawing.Point(87, 77);
            this.buttonMoveUpRight.Name = "buttonMoveUpRight";
            this.buttonMoveUpRight.Size = new System.Drawing.Size(33, 23);
            this.buttonMoveUpRight.TabIndex = 11;
            this.buttonMoveUpRight.Text = "UR";
            this.buttonMoveUpRight.UseVisualStyleBackColor = true;
            this.buttonMoveUpRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonMoveUpRight_MouseDown);
            this.buttonMoveUpRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonMove_MouseUp);
            // 
            // buttonMoveDownLeft
            // 
            this.buttonMoveDownLeft.AutoSize = true;
            this.buttonMoveDownLeft.Enabled = false;
            this.buttonMoveDownLeft.Location = new System.Drawing.Point(6, 135);
            this.buttonMoveDownLeft.Name = "buttonMoveDownLeft";
            this.buttonMoveDownLeft.Size = new System.Drawing.Size(31, 23);
            this.buttonMoveDownLeft.TabIndex = 11;
            this.buttonMoveDownLeft.Text = "DL";
            this.buttonMoveDownLeft.UseVisualStyleBackColor = true;
            this.buttonMoveDownLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonMoveDownLeft_MouseDown);
            this.buttonMoveDownLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonMove_MouseUp);
            // 
            // buttonMoveDownRight
            // 
            this.buttonMoveDownRight.AutoSize = true;
            this.buttonMoveDownRight.Enabled = false;
            this.buttonMoveDownRight.Location = new System.Drawing.Point(87, 135);
            this.buttonMoveDownRight.Name = "buttonMoveDownRight";
            this.buttonMoveDownRight.Size = new System.Drawing.Size(33, 23);
            this.buttonMoveDownRight.TabIndex = 11;
            this.buttonMoveDownRight.Text = "DR";
            this.buttonMoveDownRight.UseVisualStyleBackColor = true;
            this.buttonMoveDownRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonMoveDownRight_MouseDown);
            this.buttonMoveDownRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonMove_MouseUp);
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
            this.groupBox3.Controls.Add(this.buttonGoAuxCommand);
            this.groupBox3.Controls.Add(this.comboBoxAuxCommands);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.buttonGoToStatus);
            this.groupBox3.Controls.Add(this.buttonGoStream);
            this.groupBox3.Controls.Add(this.comboBoxStreamURIs);
            this.groupBox3.Controls.Add(this.comboBoxPresets);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.Streams);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.buttonPresetGo);
            this.groupBox3.Controls.Add(this.comboBoxProfileTokens);
            this.groupBox3.Location = new System.Drawing.Point(9, 298);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(294, 206);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Commands";
            // 
            // buttonGoAuxCommand
            // 
            this.buttonGoAuxCommand.Enabled = false;
            this.buttonGoAuxCommand.Location = new System.Drawing.Point(211, 102);
            this.buttonGoAuxCommand.Name = "buttonGoAuxCommand";
            this.buttonGoAuxCommand.Size = new System.Drawing.Size(75, 23);
            this.buttonGoAuxCommand.TabIndex = 16;
            this.buttonGoAuxCommand.Text = "Go";
            this.buttonGoAuxCommand.UseVisualStyleBackColor = true;
            this.buttonGoAuxCommand.Click += new System.EventHandler(this.buttonGoAuxCommand_Click);
            // 
            // comboBoxAuxCommands
            // 
            this.comboBoxAuxCommands.Enabled = false;
            this.comboBoxAuxCommands.FormattingEnabled = true;
            this.comboBoxAuxCommands.Location = new System.Drawing.Point(57, 104);
            this.comboBoxAuxCommands.Name = "comboBoxAuxCommands";
            this.comboBoxAuxCommands.Size = new System.Drawing.Size(148, 21);
            this.comboBoxAuxCommands.TabIndex = 15;
            this.comboBoxAuxCommands.SelectedIndexChanged += new System.EventHandler(this.comboBoxAuxCommands_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.textBoxPresetName);
            this.groupBox4.Controls.Add(this.textBoxPresetToken);
            this.groupBox4.Controls.Add(this.buttonSetPreset);
            this.groupBox4.Controls.Add(this.buttonDeletePreset);
            this.groupBox4.Location = new System.Drawing.Point(8, 131);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(280, 70);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Set Presets";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Token";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Name";
            // 
            // textBoxPresetName
            // 
            this.textBoxPresetName.Location = new System.Drawing.Point(51, 14);
            this.textBoxPresetName.Name = "textBoxPresetName";
            this.textBoxPresetName.Size = new System.Drawing.Size(148, 20);
            this.textBoxPresetName.TabIndex = 1;
            this.textBoxPresetName.TextChanged += new System.EventHandler(this.textBoxPresetName_TextChanged);
            // 
            // textBoxPresetToken
            // 
            this.textBoxPresetToken.Location = new System.Drawing.Point(51, 40);
            this.textBoxPresetToken.Name = "textBoxPresetToken";
            this.textBoxPresetToken.Size = new System.Drawing.Size(148, 20);
            this.textBoxPresetToken.TabIndex = 1;
            this.textBoxPresetToken.TextChanged += new System.EventHandler(this.textBoxPresetToken_TextChanged);
            // 
            // buttonSetPreset
            // 
            this.buttonSetPreset.Enabled = false;
            this.buttonSetPreset.Location = new System.Drawing.Point(205, 9);
            this.buttonSetPreset.Name = "buttonSetPreset";
            this.buttonSetPreset.Size = new System.Drawing.Size(75, 23);
            this.buttonSetPreset.TabIndex = 0;
            this.buttonSetPreset.Text = "Set";
            this.buttonSetPreset.UseVisualStyleBackColor = true;
            this.buttonSetPreset.Click += new System.EventHandler(this.buttonSetPreset_Click);
            // 
            // buttonDeletePreset
            // 
            this.buttonDeletePreset.Enabled = false;
            this.buttonDeletePreset.Location = new System.Drawing.Point(205, 38);
            this.buttonDeletePreset.Name = "buttonDeletePreset";
            this.buttonDeletePreset.Size = new System.Drawing.Size(75, 23);
            this.buttonDeletePreset.TabIndex = 0;
            this.buttonDeletePreset.Text = "Delete";
            this.buttonDeletePreset.UseVisualStyleBackColor = true;
            this.buttonDeletePreset.Click += new System.EventHandler(this.buttonDeletePreset_Click);
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Aux";
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
            this.vlcControl1.Size = new System.Drawing.Size(626, 492);
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
            this.ClientSize = new System.Drawing.Size(944, 515);
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
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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
        private System.Windows.Forms.Button buttonMoveUpLeft;
        private System.Windows.Forms.Button buttonMoveUpRight;
        private System.Windows.Forms.Button buttonMoveDownLeft;
        private System.Windows.Forms.Button buttonMoveDownRight;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonDeletePreset;
        private System.Windows.Forms.Button buttonSetPreset;
        private System.Windows.Forms.TextBox textBoxPresetName;
        private System.Windows.Forms.TextBox textBoxPresetToken;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonGoAuxCommand;
        private System.Windows.Forms.ComboBox comboBoxAuxCommands;
        private System.Windows.Forms.Label label8;
    }
}

