namespace UI
{
    partial class FaceRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FaceRegister));
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtIDCard = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtYan = new System.Windows.Forms.TextBox();
            this.videPlayer = new AForge.Controls.VideoSourcePlayer();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Paneljps = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.picText = new System.Windows.Forms.PictureBox();
            this.btnAgree = new System.Windows.Forms.Button();
            this.picIsShow = new System.Windows.Forms.PictureBox();
            this.link2 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnNoAgree = new System.Windows.Forms.Button();
            this.link3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.button10 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.panelSuccess = new System.Windows.Forms.Panel();
            this.txtSuccess = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtZhuCeSuccess = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timerSuccess = new System.Windows.Forms.Timer(this.components);
            this.timerfail = new System.Windows.Forms.Timer(this.components);
            this.linkReturn = new System.Windows.Forms.LinkLabel();
            this.linkReturns = new System.Windows.Forms.LinkLabel();
            this.txtFails = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Paneljps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIsShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.link2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelSuccess.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtName.Location = new System.Drawing.Point(20, 128);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(474, 36);
            this.txtName.TabIndex = 0;
            this.txtName.Text = "请输入姓名";
            this.txtName.Click += new System.EventHandler(this.txtName_Click);
            this.txtName.Enter += new System.EventHandler(this.txtName_Enter);
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // txtIDCard
            // 
            this.txtIDCard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIDCard.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtIDCard.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtIDCard.Location = new System.Drawing.Point(20, 190);
            this.txtIDCard.Multiline = true;
            this.txtIDCard.Name = "txtIDCard";
            this.txtIDCard.Size = new System.Drawing.Size(497, 33);
            this.txtIDCard.TabIndex = 1;
            this.txtIDCard.Text = "请输入身份证号";
            this.txtIDCard.Click += new System.EventHandler(this.txtIDCard_Click);
            this.txtIDCard.Enter += new System.EventHandler(this.txtIDCard_Enter);
            this.txtIDCard.Leave += new System.EventHandler(this.txtIDCard_Leave);
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddress.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAddress.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtAddress.Location = new System.Drawing.Point(20, 253);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(560, 36);
            this.txtAddress.TabIndex = 2;
            this.txtAddress.Text = "请输入地址";
            this.txtAddress.Click += new System.EventHandler(this.txtAddress_Click);
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            this.txtAddress.Enter += new System.EventHandler(this.txtAddress_Enter);
            this.txtAddress.Leave += new System.EventHandler(this.txtAddress_Leave);
            // 
            // txtPhone
            // 
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPhone.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPhone.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtPhone.Location = new System.Drawing.Point(20, 317);
            this.txtPhone.Multiline = true;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(505, 37);
            this.txtPhone.TabIndex = 3;
            this.txtPhone.Text = "请输入手机号";
            this.txtPhone.Click += new System.EventHandler(this.txtPhone_Click);
            this.txtPhone.Enter += new System.EventHandler(this.txtPhone_Enter);
            this.txtPhone.Leave += new System.EventHandler(this.txtPhone_Leave);
            // 
            // txtYan
            // 
            this.txtYan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtYan.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtYan.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtYan.Location = new System.Drawing.Point(20, 378);
            this.txtYan.Multiline = true;
            this.txtYan.Name = "txtYan";
            this.txtYan.Size = new System.Drawing.Size(361, 37);
            this.txtYan.TabIndex = 4;
            this.txtYan.Text = "请输入验证码";
            this.txtYan.Click += new System.EventHandler(this.txtYan_Click);
            this.txtYan.Enter += new System.EventHandler(this.txtYan_Enter);
            this.txtYan.Leave += new System.EventHandler(this.txtYan_Leave);
            // 
            // videPlayer
            // 
            this.videPlayer.Location = new System.Drawing.Point(165, 480);
            this.videPlayer.Name = "videPlayer";
            this.videPlayer.Size = new System.Drawing.Size(216, 232);
            this.videPlayer.TabIndex = 15;
            this.videPlayer.VideoSource = null;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Paneljps
            // 
            this.Paneljps.Controls.Add(this.button5);
            this.Paneljps.Controls.Add(this.btnOk);
            this.Paneljps.Controls.Add(this.button1);
            this.Paneljps.Controls.Add(this.button11);
            this.Paneljps.Controls.Add(this.button2);
            this.Paneljps.Controls.Add(this.btndelete);
            this.Paneljps.Controls.Add(this.button3);
            this.Paneljps.Controls.Add(this.button7);
            this.Paneljps.Controls.Add(this.button6);
            this.Paneljps.Controls.Add(this.button8);
            this.Paneljps.Controls.Add(this.button4);
            this.Paneljps.Controls.Add(this.button9);
            this.Paneljps.Location = new System.Drawing.Point(0, 929);
            this.Paneljps.Name = "Paneljps";
            this.Paneljps.Size = new System.Drawing.Size(697, 434);
            this.Paneljps.TabIndex = 42;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.Transparent;
            this.button5.Location = new System.Drawing.Point(265, 131);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(150, 90);
            this.button5.TabIndex = 33;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOk.BackgroundImage")));
            this.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.ForeColor = System.Drawing.Color.Transparent;
            this.btnOk.Location = new System.Drawing.Point(515, 340);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(150, 90);
            this.btnOk.TabIndex = 41;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(35, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 90);
            this.button1.TabIndex = 29;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button11.BackgroundImage")));
            this.button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.ForeColor = System.Drawing.Color.Transparent;
            this.button11.Location = new System.Drawing.Point(265, 340);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(150, 90);
            this.button11.TabIndex = 38;
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(35, 131);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 90);
            this.button2.TabIndex = 32;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btndelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btndelete.BackgroundImage")));
            this.btndelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndelete.ForeColor = System.Drawing.Color.Transparent;
            this.btndelete.Location = new System.Drawing.Point(35, 340);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(150, 90);
            this.btndelete.TabIndex = 39;
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Location = new System.Drawing.Point(35, 230);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 90);
            this.button3.TabIndex = 35;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ForeColor = System.Drawing.Color.Transparent;
            this.button7.Location = new System.Drawing.Point(515, 241);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(150, 90);
            this.button7.TabIndex = 37;
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.Color.Transparent;
            this.button6.Location = new System.Drawing.Point(265, 19);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(150, 90);
            this.button6.TabIndex = 30;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button8.BackgroundImage")));
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.ForeColor = System.Drawing.Color.Transparent;
            this.button8.Location = new System.Drawing.Point(515, 131);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(150, 90);
            this.button8.TabIndex = 34;
            this.button8.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.Transparent;
            this.button4.Location = new System.Drawing.Point(265, 241);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 90);
            this.button4.TabIndex = 36;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button9.BackgroundImage")));
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.ForeColor = System.Drawing.Color.Transparent;
            this.button9.Location = new System.Drawing.Point(515, 19);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(150, 90);
            this.button9.TabIndex = 31;
            this.button9.UseVisualStyleBackColor = false;
            // 
            // timer4
            // 
            this.timer4.Interval = 2000;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // picText
            // 
            this.picText.BackgroundImage = global::UI.Properties.Resources.服务协议;
            this.picText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picText.Location = new System.Drawing.Point(64, 753);
            this.picText.Name = "picText";
            this.picText.Size = new System.Drawing.Size(436, 39);
            this.picText.TabIndex = 45;
            this.picText.TabStop = false;
            this.picText.Click += new System.EventHandler(this.picText_Click);
            // 
            // btnAgree
            // 
            this.btnAgree.AllowDrop = true;
            this.btnAgree.BackColor = System.Drawing.Color.White;
            this.btnAgree.BackgroundImage = global::UI.Properties.Resources.icon_checked_mark;
            this.btnAgree.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgree.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAgree.FlatAppearance.BorderSize = 0;
            this.btnAgree.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAgree.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAgree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgree.Location = new System.Drawing.Point(20, 753);
            this.btnAgree.Name = "btnAgree";
            this.btnAgree.Size = new System.Drawing.Size(38, 39);
            this.btnAgree.TabIndex = 43;
            this.btnAgree.UseVisualStyleBackColor = false;
            this.btnAgree.Click += new System.EventHandler(this.btnAgree_Click);
            // 
            // picIsShow
            // 
            this.picIsShow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picIsShow.BackgroundImage")));
            this.picIsShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picIsShow.Location = new System.Drawing.Point(165, 480);
            this.picIsShow.Name = "picIsShow";
            this.picIsShow.Size = new System.Drawing.Size(216, 232);
            this.picIsShow.TabIndex = 16;
            this.picIsShow.TabStop = false;
            this.picIsShow.Click += new System.EventHandler(this.picIsShow_Click);
            // 
            // link2
            // 
            this.link2.BackgroundImage = global::UI.Properties.Resources.验证码;
            this.link2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.link2.Location = new System.Drawing.Point(392, 378);
            this.link2.Name = "link2";
            this.link2.Size = new System.Drawing.Size(125, 32);
            this.link2.TabIndex = 5;
            this.link2.TabStop = false;
            this.link2.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BackgroundImage = global::UI.Properties.Resources._9_1注册;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(539, 935);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            // 
            // btnNoAgree
            // 
            this.btnNoAgree.AllowDrop = true;
            this.btnNoAgree.BackColor = System.Drawing.Color.White;
            this.btnNoAgree.BackgroundImage = global::UI.Properties.Resources.icon_Unchecked;
            this.btnNoAgree.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNoAgree.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNoAgree.FlatAppearance.BorderSize = 0;
            this.btnNoAgree.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnNoAgree.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnNoAgree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNoAgree.Location = new System.Drawing.Point(20, 753);
            this.btnNoAgree.Name = "btnNoAgree";
            this.btnNoAgree.Size = new System.Drawing.Size(38, 39);
            this.btnNoAgree.TabIndex = 44;
            this.btnNoAgree.UseVisualStyleBackColor = false;
            this.btnNoAgree.Click += new System.EventHandler(this.btnNoAgree_Click);
            // 
            // link3
            // 
            this.link3.BackColor = System.Drawing.Color.White;
            this.link3.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.link3.Location = new System.Drawing.Point(395, 376);
            this.link3.Name = "link3";
            this.link3.Size = new System.Drawing.Size(136, 34);
            this.link3.TabIndex = 46;
            this.link3.TabStop = true;
            this.link3.Text = "获取验证码";
            this.link3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link3_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel1.LinkColor = System.Drawing.Color.Red;
            this.linkLabel1.Location = new System.Drawing.Point(315, 1263);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(143, 33);
            this.linkLabel1.TabIndex = 47;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "退出注册";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked_1);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.White;
            this.button10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button10.BackgroundImage")));
            this.button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button10.Location = new System.Drawing.Point(20, 809);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(497, 82);
            this.button10.TabIndex = 48;
            this.button10.Text = "实名注册  刷脸注册";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button12.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button12.BackgroundImage")));
            this.button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button12.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button12.FlatAppearance.BorderSize = 0;
            this.button12.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button12.Location = new System.Drawing.Point(20, 809);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(497, 82);
            this.button12.TabIndex = 49;
            this.button12.Text = "实名注册  刷脸注册";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Visible = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // panelSuccess
            // 
            this.panelSuccess.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelSuccess.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelSuccess.BackgroundImage")));
            this.panelSuccess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSuccess.Controls.Add(this.txtSuccess);
            this.panelSuccess.Location = new System.Drawing.Point(-5, 0);
            this.panelSuccess.Name = "panelSuccess";
            this.panelSuccess.Size = new System.Drawing.Size(539, 923);
            this.panelSuccess.TabIndex = 0;
            // 
            // txtSuccess
            // 
            this.txtSuccess.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSuccess.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSuccess.Location = new System.Drawing.Point(252, 539);
            this.txtSuccess.Multiline = true;
            this.txtSuccess.Name = "txtSuccess";
            this.txtSuccess.Size = new System.Drawing.Size(33, 32);
            this.txtSuccess.TabIndex = 0;
            this.txtSuccess.TextChanged += new System.EventHandler(this.txtSuccess_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(5, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 935);
            this.panel1.TabIndex = 51;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtZhuCeSuccess);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Location = new System.Drawing.Point(177, 539);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(189, 52);
            this.panel3.TabIndex = 0;
            // 
            // txtZhuCeSuccess
            // 
            this.txtZhuCeSuccess.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtZhuCeSuccess.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtZhuCeSuccess.Location = new System.Drawing.Point(55, -5);
            this.txtZhuCeSuccess.Multiline = true;
            this.txtZhuCeSuccess.Name = "txtZhuCeSuccess";
            this.txtZhuCeSuccess.Size = new System.Drawing.Size(78, 39);
            this.txtZhuCeSuccess.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(72, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(37, 38);
            this.textBox1.TabIndex = 0;
            // 
            // timerSuccess
            // 
            this.timerSuccess.Interval = 1000;
            this.timerSuccess.Tick += new System.EventHandler(this.timerSuccess_Tick);
            // 
            // timerfail
            // 
            this.timerfail.Interval = 1000;
            this.timerfail.Tick += new System.EventHandler(this.timerfail_Tick);
            // 
            // linkReturn
            // 
            this.linkReturn.AutoSize = true;
            this.linkReturn.BackColor = System.Drawing.Color.White;
            this.linkReturn.DisabledLinkColor = System.Drawing.Color.White;
            this.linkReturn.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkReturn.ForeColor = System.Drawing.Color.White;
            this.linkReturn.LinkColor = System.Drawing.Color.Red;
            this.linkReturn.Location = new System.Drawing.Point(304, 1033);
            this.linkReturn.Name = "linkReturn";
            this.linkReturn.Size = new System.Drawing.Size(104, 19);
            this.linkReturn.TabIndex = 52;
            this.linkReturn.TabStop = true;
            this.linkReturn.Text = "返回上一级";
            this.linkReturn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkReturn_LinkClicked);
            // 
            // linkReturns
            // 
            this.linkReturns.AutoSize = true;
            this.linkReturns.BackColor = System.Drawing.Color.White;
            this.linkReturns.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkReturns.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.linkReturns.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkReturns.LinkColor = System.Drawing.Color.Red;
            this.linkReturns.Location = new System.Drawing.Point(187, 894);
            this.linkReturns.Name = "linkReturns";
            this.linkReturns.Size = new System.Drawing.Size(130, 24);
            this.linkReturns.TabIndex = 53;
            this.linkReturns.TabStop = true;
            this.linkReturns.Text = "返回上一级";
            this.linkReturns.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkReturns_LinkClicked);
            // 
            // txtFails
            // 
            this.txtFails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFails.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFails.Location = new System.Drawing.Point(96, 18);
            this.txtFails.Multiline = true;
            this.txtFails.Name = "txtFails";
            this.txtFails.Size = new System.Drawing.Size(38, 32);
            this.txtFails.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtFails);
            this.panel2.Location = new System.Drawing.Point(165, 540);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 70);
            this.panel2.TabIndex = 1;
            // 
            // FaceRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(539, 935);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelSuccess);
            this.Controls.Add(this.link2);
            this.Controls.Add(this.linkReturns);
            this.Controls.Add(this.link3);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.picIsShow);
            this.Controls.Add(this.videPlayer);
            this.Controls.Add(this.linkReturn);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.picText);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtYan);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtIDCard);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnAgree);
            this.Controls.Add(this.btnNoAgree);
            this.Controls.Add(this.Paneljps);
            this.Controls.Add(this.pictureBox2);
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FaceRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FaceRegister";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FaceRegister_FormClosing);
            this.Load += new System.EventHandler(this.FaceRegister_Load);
            this.Shown += new System.EventHandler(this.FaceRegister_Shown);
            this.Paneljps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIsShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.link2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelSuccess.ResumeLayout(false);
            this.panelSuccess.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtIDCard;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtYan;
        private System.Windows.Forms.PictureBox link2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private AForge.Controls.VideoSourcePlayer videPlayer;
        private System.Windows.Forms.PictureBox picIsShow;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel Paneljps;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Button btnAgree;
        private System.Windows.Forms.Button btnNoAgree;
        private System.Windows.Forms.PictureBox picText;
        private System.Windows.Forms.LinkLabel link3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Panel panelSuccess;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timerSuccess;
        private System.Windows.Forms.Timer timerfail;
        private System.Windows.Forms.TextBox txtSuccess;
        private System.Windows.Forms.LinkLabel linkReturn;
        private System.Windows.Forms.LinkLabel linkReturns;
        private System.Windows.Forms.TextBox txtFails;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtZhuCeSuccess;
    }
}