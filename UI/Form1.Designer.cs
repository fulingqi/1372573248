namespace UI
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.link3 = new System.Windows.Forms.LinkLabel();
            this.btnNoAgree = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtIDCard = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtYan = new System.Windows.Forms.TextBox();
            this.btnAgree = new System.Windows.Forms.Button();
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.picHict = new System.Windows.Forms.PictureBox();
            this.Paneljp = new System.Windows.Forms.Panel();
            this.btnook = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.button000 = new System.Windows.Forms.Button();
            this.button999 = new System.Windows.Forms.Button();
            this.button777 = new System.Windows.Forms.Button();
            this.button888 = new System.Windows.Forms.Button();
            this.button666 = new System.Windows.Forms.Button();
            this.button555 = new System.Windows.Forms.Button();
            this.button444 = new System.Windows.Forms.Button();
            this.button333 = new System.Windows.Forms.Button();
            this.button222 = new System.Windows.Forms.Button();
            this.button111 = new System.Windows.Forms.Button();
            this.txtTimeNow = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picHeader = new System.Windows.Forms.PictureBox();
            this.labHead = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labTishi = new System.Windows.Forms.Label();
            this.labTime = new System.Windows.Forms.Label();
            this.labCountDown = new System.Windows.Forms.Label();
            this.labTIshi2 = new System.Windows.Forms.Label();
            this.picBottom = new System.Windows.Forms.PictureBox();
            this.labBottom = new System.Windows.Forms.Label();
            this.labExit = new System.Windows.Forms.Label();
            this.picExit = new System.Windows.Forms.PictureBox();
            this.txtAddress = new System.Windows.Forms.RichTextBox();
            this.panelSuccess = new System.Windows.Forms.Panel();
            this.panelSmallFail = new System.Windows.Forms.Panel();
            this.txtError = new System.Windows.Forms.TextBox();
            this.panelSmallSuccess = new System.Windows.Forms.Panel();
            this.panelMessage = new System.Windows.Forms.Panel();
            this.picError = new System.Windows.Forms.PictureBox();
            this.txtErrorMessage = new System.Windows.Forms.TextBox();
            this.panelAll = new System.Windows.Forms.Panel();
            this.btnRegister = new System.Windows.Forms.Button();
            this.link2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picHict)).BeginInit();
            this.Paneljp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            this.panelSuccess.SuspendLayout();
            this.panelSmallFail.SuspendLayout();
            this.panelSmallSuccess.SuspendLayout();
            this.panelMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            this.panelAll.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // link3
            // 
            this.link3.BackColor = System.Drawing.Color.White;
            this.link3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.link3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.link3.Location = new System.Drawing.Point(464, 584);
            this.link3.Name = "link3";
            this.link3.Size = new System.Drawing.Size(125, 47);
            this.link3.TabIndex = 52;
            this.link3.TabStop = true;
            this.link3.Text = "获取验证码";
            this.link3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.link3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link3_LinkClicked);
            // 
            // btnNoAgree
            // 
            this.btnNoAgree.AllowDrop = true;
            this.btnNoAgree.BackColor = System.Drawing.Color.White;
            this.btnNoAgree.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNoAgree.BackgroundImage")));
            this.btnNoAgree.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNoAgree.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNoAgree.FlatAppearance.BorderSize = 0;
            this.btnNoAgree.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnNoAgree.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnNoAgree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNoAgree.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNoAgree.Location = new System.Drawing.Point(279, 709);
            this.btnNoAgree.Name = "btnNoAgree";
            this.btnNoAgree.Size = new System.Drawing.Size(38, 34);
            this.btnNoAgree.TabIndex = 47;
            this.btnNoAgree.UseVisualStyleBackColor = false;
            this.btnNoAgree.Click += new System.EventHandler(this.btnNoAgree_Click);
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.txtName.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtName.Location = new System.Drawing.Point(264, 194);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(198, 44);
            this.txtName.TabIndex = 5;
            this.txtName.Click += new System.EventHandler(this.txtName_Click);
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.Enter += new System.EventHandler(this.txtName_Enter);
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // txtIDCard
            // 
            this.txtIDCard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIDCard.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.txtIDCard.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtIDCard.Location = new System.Drawing.Point(261, 286);
            this.txtIDCard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIDCard.MaxLength = 18;
            this.txtIDCard.Multiline = true;
            this.txtIDCard.Name = "txtIDCard";
            this.txtIDCard.Size = new System.Drawing.Size(319, 44);
            this.txtIDCard.TabIndex = 6;
            this.txtIDCard.Click += new System.EventHandler(this.txtIDCard_Click);
            this.txtIDCard.TextChanged += new System.EventHandler(this.txtIDCard_TextChanged);
            this.txtIDCard.Leave += new System.EventHandler(this.txtIDCard_Leave);
            // 
            // txtPhone
            // 
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPhone.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.txtPhone.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtPhone.Location = new System.Drawing.Point(264, 486);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPhone.MaxLength = 11;
            this.txtPhone.Multiline = true;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(221, 45);
            this.txtPhone.TabIndex = 8;
            this.txtPhone.Click += new System.EventHandler(this.txtPhone_Click);
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            this.txtPhone.Enter += new System.EventHandler(this.txtPhone_Enter);
            this.txtPhone.Leave += new System.EventHandler(this.txtPhone_Leave);
            // 
            // txtYan
            // 
            this.txtYan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtYan.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.txtYan.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtYan.Location = new System.Drawing.Point(261, 605);
            this.txtYan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtYan.MaxLength = 6;
            this.txtYan.Multiline = true;
            this.txtYan.Name = "txtYan";
            this.txtYan.Size = new System.Drawing.Size(176, 45);
            this.txtYan.TabIndex = 9;
            this.txtYan.Click += new System.EventHandler(this.txtYan_Click);
            this.txtYan.TextChanged += new System.EventHandler(this.txtYan_TextChanged);
            this.txtYan.Enter += new System.EventHandler(this.txtYan_Enter);
            this.txtYan.Leave += new System.EventHandler(this.txtYan_Leave);
            // 
            // btnAgree
            // 
            this.btnAgree.AllowDrop = true;
            this.btnAgree.BackColor = System.Drawing.Color.White;
            this.btnAgree.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgree.BackgroundImage")));
            this.btnAgree.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgree.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAgree.FlatAppearance.BorderSize = 0;
            this.btnAgree.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAgree.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAgree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgree.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAgree.Location = new System.Drawing.Point(280, 708);
            this.btnAgree.Name = "btnAgree";
            this.btnAgree.Size = new System.Drawing.Size(38, 34);
            this.btnAgree.TabIndex = 46;
            this.btnAgree.UseVisualStyleBackColor = false;
            this.btnAgree.Click += new System.EventHandler(this.btnAgree_Click);
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.Location = new System.Drawing.Point(997, 180);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(627, 543);
            this.videoSourcePlayer1.TabIndex = 53;
            this.videoSourcePlayer1.Text = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            // 
            // picHict
            // 
            this.picHict.BackColor = System.Drawing.Color.White;
            this.picHict.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picHict.BackgroundImage")));
            this.picHict.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picHict.Location = new System.Drawing.Point(997, 180);
            this.picHict.Name = "picHict";
            this.picHict.Size = new System.Drawing.Size(627, 543);
            this.picHict.TabIndex = 55;
            this.picHict.TabStop = false;
            // 
            // Paneljp
            // 
            this.Paneljp.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Paneljp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Paneljp.Controls.Add(this.btnook);
            this.Paneljp.Controls.Add(this.btndelete);
            this.Paneljp.Controls.Add(this.button000);
            this.Paneljp.Controls.Add(this.button999);
            this.Paneljp.Controls.Add(this.button777);
            this.Paneljp.Controls.Add(this.button888);
            this.Paneljp.Controls.Add(this.button666);
            this.Paneljp.Controls.Add(this.button555);
            this.Paneljp.Controls.Add(this.button444);
            this.Paneljp.Controls.Add(this.button333);
            this.Paneljp.Controls.Add(this.button222);
            this.Paneljp.Controls.Add(this.button111);
            this.Paneljp.Location = new System.Drawing.Point(710, 355);
            this.Paneljp.Name = "Paneljp";
            this.Paneljp.Size = new System.Drawing.Size(266, 321);
            this.Paneljp.TabIndex = 56;
            // 
            // btnook
            // 
            this.btnook.BackColor = System.Drawing.Color.Transparent;
            this.btnook.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnook.BackgroundImage")));
            this.btnook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnook.FlatAppearance.BorderSize = 0;
            this.btnook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnook.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnook.ForeColor = System.Drawing.Color.Blue;
            this.btnook.Location = new System.Drawing.Point(189, 256);
            this.btnook.Name = "btnook";
            this.btnook.Size = new System.Drawing.Size(63, 57);
            this.btnook.TabIndex = 42;
            this.btnook.Text = "清空";
            this.btnook.UseVisualStyleBackColor = false;
            this.btnook.Click += new System.EventHandler(this.btnook_Click);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.Transparent;
            this.btndelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btndelete.BackgroundImage")));
            this.btndelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btndelete.FlatAppearance.BorderSize = 0;
            this.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndelete.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btndelete.ForeColor = System.Drawing.Color.Blue;
            this.btndelete.Location = new System.Drawing.Point(19, 256);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(63, 57);
            this.btndelete.TabIndex = 40;
            this.btndelete.Text = "回删";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click_1);
            // 
            // button000
            // 
            this.button000.BackColor = System.Drawing.Color.Transparent;
            this.button000.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button000.BackgroundImage")));
            this.button000.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button000.FlatAppearance.BorderSize = 0;
            this.button000.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button000.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.button000.ForeColor = System.Drawing.Color.Blue;
            this.button000.Location = new System.Drawing.Point(103, 256);
            this.button000.Name = "button000";
            this.button000.Size = new System.Drawing.Size(63, 57);
            this.button000.TabIndex = 38;
            this.button000.Text = "0";
            this.button000.UseVisualStyleBackColor = false;
            this.button000.Click += new System.EventHandler(this.button000_Click);
            // 
            // button999
            // 
            this.button999.BackColor = System.Drawing.Color.Transparent;
            this.button999.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button999.BackgroundImage")));
            this.button999.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button999.FlatAppearance.BorderSize = 0;
            this.button999.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button999.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.button999.ForeColor = System.Drawing.Color.Blue;
            this.button999.Location = new System.Drawing.Point(189, 175);
            this.button999.Name = "button999";
            this.button999.Size = new System.Drawing.Size(63, 57);
            this.button999.TabIndex = 37;
            this.button999.Text = "9";
            this.button999.UseVisualStyleBackColor = false;
            // 
            // button777
            // 
            this.button777.BackColor = System.Drawing.Color.Transparent;
            this.button777.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button777.BackgroundImage")));
            this.button777.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button777.FlatAppearance.BorderSize = 0;
            this.button777.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button777.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.button777.ForeColor = System.Drawing.Color.Blue;
            this.button777.Location = new System.Drawing.Point(19, 175);
            this.button777.Name = "button777";
            this.button777.Size = new System.Drawing.Size(63, 57);
            this.button777.TabIndex = 35;
            this.button777.Text = "7";
            this.button777.UseVisualStyleBackColor = false;
            // 
            // button888
            // 
            this.button888.BackColor = System.Drawing.Color.Transparent;
            this.button888.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button888.BackgroundImage")));
            this.button888.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button888.FlatAppearance.BorderSize = 0;
            this.button888.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button888.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.button888.ForeColor = System.Drawing.Color.Blue;
            this.button888.Location = new System.Drawing.Point(103, 175);
            this.button888.Name = "button888";
            this.button888.Size = new System.Drawing.Size(63, 57);
            this.button888.TabIndex = 36;
            this.button888.Text = "8";
            this.button888.UseVisualStyleBackColor = false;
            // 
            // button666
            // 
            this.button666.BackColor = System.Drawing.Color.Transparent;
            this.button666.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button666.BackgroundImage")));
            this.button666.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button666.FlatAppearance.BorderSize = 0;
            this.button666.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button666.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.button666.ForeColor = System.Drawing.Color.Blue;
            this.button666.Location = new System.Drawing.Point(189, 94);
            this.button666.Name = "button666";
            this.button666.Size = new System.Drawing.Size(63, 57);
            this.button666.TabIndex = 34;
            this.button666.Text = "6";
            this.button666.UseVisualStyleBackColor = false;
            // 
            // button555
            // 
            this.button555.BackColor = System.Drawing.Color.Transparent;
            this.button555.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button555.BackgroundImage")));
            this.button555.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button555.FlatAppearance.BorderSize = 0;
            this.button555.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button555.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.button555.ForeColor = System.Drawing.Color.Blue;
            this.button555.Location = new System.Drawing.Point(103, 94);
            this.button555.Name = "button555";
            this.button555.Size = new System.Drawing.Size(63, 57);
            this.button555.TabIndex = 33;
            this.button555.Text = "5";
            this.button555.UseVisualStyleBackColor = false;
            // 
            // button444
            // 
            this.button444.BackColor = System.Drawing.Color.Transparent;
            this.button444.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button444.BackgroundImage")));
            this.button444.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button444.FlatAppearance.BorderSize = 0;
            this.button444.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button444.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.button444.ForeColor = System.Drawing.Color.Blue;
            this.button444.Location = new System.Drawing.Point(19, 94);
            this.button444.Name = "button444";
            this.button444.Size = new System.Drawing.Size(63, 57);
            this.button444.TabIndex = 32;
            this.button444.Text = "4";
            this.button444.UseVisualStyleBackColor = false;
            // 
            // button333
            // 
            this.button333.BackColor = System.Drawing.Color.Transparent;
            this.button333.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button333.BackgroundImage")));
            this.button333.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button333.FlatAppearance.BorderSize = 0;
            this.button333.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button333.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.button333.ForeColor = System.Drawing.Color.Blue;
            this.button333.Location = new System.Drawing.Point(189, 21);
            this.button333.Name = "button333";
            this.button333.Size = new System.Drawing.Size(63, 57);
            this.button333.TabIndex = 31;
            this.button333.Text = "3";
            this.button333.UseVisualStyleBackColor = false;
            // 
            // button222
            // 
            this.button222.BackColor = System.Drawing.Color.Transparent;
            this.button222.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button222.BackgroundImage")));
            this.button222.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button222.FlatAppearance.BorderSize = 0;
            this.button222.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button222.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.button222.ForeColor = System.Drawing.Color.Blue;
            this.button222.Location = new System.Drawing.Point(103, 21);
            this.button222.Name = "button222";
            this.button222.Size = new System.Drawing.Size(63, 57);
            this.button222.TabIndex = 30;
            this.button222.Text = "2";
            this.button222.UseVisualStyleBackColor = false;
            // 
            // button111
            // 
            this.button111.BackColor = System.Drawing.Color.Transparent;
            this.button111.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button111.BackgroundImage")));
            this.button111.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button111.FlatAppearance.BorderSize = 0;
            this.button111.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button111.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.button111.ForeColor = System.Drawing.Color.Blue;
            this.button111.Location = new System.Drawing.Point(19, 21);
            this.button111.Name = "button111";
            this.button111.Size = new System.Drawing.Size(63, 57);
            this.button111.TabIndex = 29;
            this.button111.Text = "1";
            this.button111.UseVisualStyleBackColor = false;
            // 
            // txtTimeNow
            // 
            this.txtTimeNow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTimeNow.Location = new System.Drawing.Point(12, 25);
            this.txtTimeNow.Name = "txtTimeNow";
            this.txtTimeNow.Size = new System.Drawing.Size(100, 14);
            this.txtTimeNow.TabIndex = 57;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(112, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 35);
            this.label3.TabIndex = 60;
            this.label3.Text = "身份证号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(112, 387);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 35);
            this.label4.TabIndex = 61;
            this.label4.Text = "地      址：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(112, 491);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 35);
            this.label5.TabIndex = 62;
            this.label5.Text = "手 机 号：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(112, 605);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 35);
            this.label6.TabIndex = 63;
            this.label6.Text = "验 证 码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(112, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 35);
            this.label2.TabIndex = 59;
            this.label2.Text = "姓      名：";
            // 
            // picHeader
            // 
            this.picHeader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picHeader.BackgroundImage")));
            this.picHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picHeader.Location = new System.Drawing.Point(0, -2);
            this.picHeader.Name = "picHeader";
            this.picHeader.Size = new System.Drawing.Size(1940, 85);
            this.picHeader.TabIndex = 64;
            this.picHeader.TabStop = false;
            // 
            // labHead
            // 
            this.labHead.AutoSize = true;
            this.labHead.BackColor = System.Drawing.Color.Blue;
            this.labHead.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.labHead.ForeColor = System.Drawing.Color.White;
            this.labHead.Location = new System.Drawing.Point(830, 11);
            this.labHead.Name = "labHead";
            this.labHead.Size = new System.Drawing.Size(285, 35);
            this.labHead.TabIndex = 65;
            this.labHead.Text = "明医实名就医刷脸注册";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(326, 713);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 21);
            this.label1.TabIndex = 66;
            this.label1.Text = "我已阅读并同意";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.linkLabel1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.linkLabel1.Location = new System.Drawing.Point(442, 713);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(112, 23);
            this.linkLabel1.TabIndex = 68;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "明医隐私政策";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Underline);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(261, 238);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(424, 17);
            this.label9.TabIndex = 74;
            this.label9.Text = "                                                                                 " +
    "                       ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Underline);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(266, 330);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(424, 17);
            this.label7.TabIndex = 75;
            this.label7.Text = "                                                                                 " +
    "                       ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Underline);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(266, 422);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(424, 17);
            this.label8.TabIndex = 76;
            this.label8.Text = "                                                                                 " +
    "                       ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Underline);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(262, 532);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(416, 17);
            this.label10.TabIndex = 77;
            this.label10.Text = "                                                                                 " +
    "                     ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Underline);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(261, 643);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(424, 17);
            this.label11.TabIndex = 78;
            this.label11.Text = "                                                                                 " +
    "                       ";
            // 
            // labTishi
            // 
            this.labTishi.AutoSize = true;
            this.labTishi.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.labTishi.ForeColor = System.Drawing.Color.SandyBrown;
            this.labTishi.Location = new System.Drawing.Point(1102, 772);
            this.labTishi.Name = "labTishi";
            this.labTishi.Size = new System.Drawing.Size(463, 52);
            this.labTishi.TabIndex = 79;
            this.labTishi.Text = "请将身份证放置在感应区";
            // 
            // labTime
            // 
            this.labTime.AutoSize = true;
            this.labTime.BackColor = System.Drawing.Color.Transparent;
            this.labTime.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labTime.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.labTime.ForeColor = System.Drawing.Color.White;
            this.labTime.Location = new System.Drawing.Point(83, 26);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(67, 25);
            this.labTime.TabIndex = 80;
            this.labTime.Text = "11111";
            // 
            // labCountDown
            // 
            this.labCountDown.AutoSize = true;
            this.labCountDown.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labCountDown.ForeColor = System.Drawing.Color.Orange;
            this.labCountDown.Location = new System.Drawing.Point(1662, 21);
            this.labCountDown.Name = "labCountDown";
            this.labCountDown.Size = new System.Drawing.Size(41, 20);
            this.labCountDown.TabIndex = 81;
            this.labCountDown.Text = "1111";
            // 
            // labTIshi2
            // 
            this.labTIshi2.AutoSize = true;
            this.labTIshi2.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.labTIshi2.ForeColor = System.Drawing.Color.SandyBrown;
            this.labTIshi2.Location = new System.Drawing.Point(1102, 835);
            this.labTIshi2.Name = "labTIshi2";
            this.labTIshi2.Size = new System.Drawing.Size(0, 52);
            this.labTIshi2.TabIndex = 82;
            // 
            // picBottom
            // 
            this.picBottom.BackColor = System.Drawing.Color.Navy;
            this.picBottom.Location = new System.Drawing.Point(-12, 1022);
            this.picBottom.Name = "picBottom";
            this.picBottom.Size = new System.Drawing.Size(1940, 63);
            this.picBottom.TabIndex = 83;
            this.picBottom.TabStop = false;
            // 
            // labBottom
            // 
            this.labBottom.AutoSize = true;
            this.labBottom.BackColor = System.Drawing.Color.Navy;
            this.labBottom.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labBottom.ForeColor = System.Drawing.Color.White;
            this.labBottom.Location = new System.Drawing.Point(832, 1036);
            this.labBottom.Name = "labBottom";
            this.labBottom.Size = new System.Drawing.Size(346, 21);
            this.labBottom.TabIndex = 84;
            this.labBottom.Text = "由明壹信息科技（上海）有限公司提供技术支持";
            this.labBottom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labExit
            // 
            this.labExit.AutoSize = true;
            this.labExit.BackColor = System.Drawing.Color.Navy;
            this.labExit.ForeColor = System.Drawing.Color.White;
            this.labExit.Location = new System.Drawing.Point(1655, 1046);
            this.labExit.Name = "labExit";
            this.labExit.Size = new System.Drawing.Size(29, 12);
            this.labExit.TabIndex = 85;
            this.labExit.Text = "退出";
            this.labExit.Click += new System.EventHandler(this.labExit_Click);
            // 
            // picExit
            // 
            this.picExit.BackColor = System.Drawing.Color.Navy;
            this.picExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picExit.BackgroundImage")));
            this.picExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picExit.Location = new System.Drawing.Point(1686, 1039);
            this.picExit.Name = "picExit";
            this.picExit.Size = new System.Drawing.Size(25, 20);
            this.picExit.TabIndex = 86;
            this.picExit.TabStop = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddress.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.txtAddress.ForeColor = System.Drawing.Color.Black;
            this.txtAddress.Location = new System.Drawing.Point(269, 376);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(0);
            this.txtAddress.MaxLength = 300;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(260, 46);
            this.txtAddress.TabIndex = 7;
            this.txtAddress.Text = "";
            this.txtAddress.Click += new System.EventHandler(this.txtAddress_Click);
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            this.txtAddress.Leave += new System.EventHandler(this.txtAddress_Leave);
            // 
            // panelSuccess
            // 
            this.panelSuccess.BackColor = System.Drawing.Color.Transparent;
            this.panelSuccess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSuccess.Controls.Add(this.panelSmallFail);
            this.panelSuccess.Controls.Add(this.panelSmallSuccess);
            this.panelSuccess.Location = new System.Drawing.Point(-2, -6);
            this.panelSuccess.Name = "panelSuccess";
            this.panelSuccess.Size = new System.Drawing.Size(2100, 1202);
            this.panelSuccess.TabIndex = 58;
            this.panelSuccess.Click += new System.EventHandler(this.panelSuccess_Click);
            // 
            // panelSmallFail
            // 
            this.panelSmallFail.BackColor = System.Drawing.Color.Transparent;
            this.panelSmallFail.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelSmallFail.BackgroundImage")));
            this.panelSmallFail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSmallFail.Controls.Add(this.txtError);
            this.panelSmallFail.Location = new System.Drawing.Point(0, 0);
            this.panelSmallFail.Name = "panelSmallFail";
            this.panelSmallFail.Size = new System.Drawing.Size(367, 268);
            this.panelSmallFail.TabIndex = 0;
            // 
            // txtError
            // 
            this.txtError.BackColor = System.Drawing.Color.White;
            this.txtError.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtError.Location = new System.Drawing.Point(32, 203);
            this.txtError.Multiline = true;
            this.txtError.Name = "txtError";
            this.txtError.ReadOnly = true;
            this.txtError.Size = new System.Drawing.Size(311, 34);
            this.txtError.TabIndex = 0;
            this.txtError.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelSmallSuccess
            // 
            this.panelSmallSuccess.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelSmallSuccess.BackgroundImage")));
            this.panelSmallSuccess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSmallSuccess.Location = new System.Drawing.Point(745, 495);
            this.panelSmallSuccess.Name = "panelSmallSuccess";
            this.panelSmallSuccess.Size = new System.Drawing.Size(367, 268);
            this.panelSmallSuccess.TabIndex = 0;
            // 
            // panelMessage
            // 
            this.panelMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelMessage.Controls.Add(this.picError);
            this.panelMessage.Controls.Add(this.txtErrorMessage);
            this.panelMessage.Location = new System.Drawing.Point(643, 512);
            this.panelMessage.Name = "panelMessage";
            this.panelMessage.Size = new System.Drawing.Size(427, 278);
            this.panelMessage.TabIndex = 1;
            this.panelMessage.Click += new System.EventHandler(this.panelMessage_Click);
            // 
            // picError
            // 
            this.picError.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picError.BackgroundImage")));
            this.picError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picError.Location = new System.Drawing.Point(158, 34);
            this.picError.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picError.Name = "picError";
            this.picError.Size = new System.Drawing.Size(98, 95);
            this.picError.TabIndex = 2;
            this.picError.TabStop = false;
            this.picError.Click += new System.EventHandler(this.picError_Click);
            // 
            // txtErrorMessage
            // 
            this.txtErrorMessage.BackColor = System.Drawing.Color.White;
            this.txtErrorMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtErrorMessage.Location = new System.Drawing.Point(58, 162);
            this.txtErrorMessage.Multiline = true;
            this.txtErrorMessage.Name = "txtErrorMessage";
            this.txtErrorMessage.ReadOnly = true;
            this.txtErrorMessage.Size = new System.Drawing.Size(298, 59);
            this.txtErrorMessage.TabIndex = 1;
            this.txtErrorMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtErrorMessage.Click += new System.EventHandler(this.txtErrorMessage_Click);
            // 
            // panelAll
            // 
            this.panelAll.BackColor = System.Drawing.Color.White;
            this.panelAll.Controls.Add(this.panelMessage);
            this.panelAll.Controls.Add(this.txtAddress);
            this.panelAll.Controls.Add(this.picExit);
            this.panelAll.Controls.Add(this.labExit);
            this.panelAll.Controls.Add(this.labBottom);
            this.panelAll.Controls.Add(this.picBottom);
            this.panelAll.Controls.Add(this.labTIshi2);
            this.panelAll.Controls.Add(this.labCountDown);
            this.panelAll.Controls.Add(this.labTime);
            this.panelAll.Controls.Add(this.labTishi);
            this.panelAll.Controls.Add(this.label11);
            this.panelAll.Controls.Add(this.label10);
            this.panelAll.Controls.Add(this.label8);
            this.panelAll.Controls.Add(this.label7);
            this.panelAll.Controls.Add(this.label9);
            this.panelAll.Controls.Add(this.linkLabel1);
            this.panelAll.Controls.Add(this.label1);
            this.panelAll.Controls.Add(this.labHead);
            this.panelAll.Controls.Add(this.picHeader);
            this.panelAll.Controls.Add(this.label2);
            this.panelAll.Controls.Add(this.label6);
            this.panelAll.Controls.Add(this.label5);
            this.panelAll.Controls.Add(this.label4);
            this.panelAll.Controls.Add(this.label3);
            this.panelAll.Controls.Add(this.txtTimeNow);
            this.panelAll.Controls.Add(this.Paneljp);
            this.panelAll.Controls.Add(this.picHict);
            this.panelAll.Controls.Add(this.btnRegister);
            this.panelAll.Controls.Add(this.videoSourcePlayer1);
            this.panelAll.Controls.Add(this.link2);
            this.panelAll.Controls.Add(this.button1);
            this.panelAll.Controls.Add(this.btnAgree);
            this.panelAll.Controls.Add(this.txtYan);
            this.panelAll.Controls.Add(this.txtPhone);
            this.panelAll.Controls.Add(this.txtIDCard);
            this.panelAll.Controls.Add(this.txtName);
            this.panelAll.Controls.Add(this.btnNoAgree);
            this.panelAll.Controls.Add(this.link3);
            this.panelAll.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panelAll.Location = new System.Drawing.Point(3, 3);
            this.panelAll.Name = "panelAll";
            this.panelAll.Size = new System.Drawing.Size(2100, 1202);
            this.panelAll.TabIndex = 57;
            this.panelAll.Click += new System.EventHandler(this.panelAll_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.White;
            this.btnRegister.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRegister.BackgroundImage")));
            this.btnRegister.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.btnRegister.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRegister.Location = new System.Drawing.Point(218, 886);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(406, 61);
            this.btnRegister.TabIndex = 54;
            this.btnRegister.Text = "注册";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // link2
            // 
            this.link2.BackColor = System.Drawing.Color.White;
            this.link2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("link2.BackgroundImage")));
            this.link2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.link2.FlatAppearance.BorderSize = 0;
            this.link2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.link2.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.link2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.link2.Location = new System.Drawing.Point(466, 584);
            this.link2.Name = "link2";
            this.link2.Size = new System.Drawing.Size(121, 47);
            this.link2.TabIndex = 87;
            this.link2.Text = "获取验证码";
            this.link2.UseVisualStyleBackColor = false;
            this.link2.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(218, 776);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(406, 61);
            this.button1.TabIndex = 49;
            this.button1.Text = "拍照进行人脸识别";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button1_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1455, 880);
            this.Controls.Add(this.panelSuccess);
            this.Controls.Add(this.panelAll);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "明医注册";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.picHict)).EndInit();
            this.Paneljp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            this.panelSuccess.ResumeLayout(false);
            this.panelSmallFail.ResumeLayout(false);
            this.panelSmallFail.PerformLayout();
            this.panelSmallSuccess.ResumeLayout(false);
            this.panelMessage.ResumeLayout(false);
            this.panelMessage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            this.panelAll.ResumeLayout(false);
            this.panelAll.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.LinkLabel link3;
        private System.Windows.Forms.Button btnNoAgree;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtIDCard;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtYan;
        private System.Windows.Forms.Button btnAgree;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
        private System.Windows.Forms.PictureBox picHict;
        private System.Windows.Forms.Panel Paneljp;
        private System.Windows.Forms.Button btnook;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button button000;
        private System.Windows.Forms.Button button999;
        private System.Windows.Forms.Button button777;
        private System.Windows.Forms.Button button888;
        private System.Windows.Forms.Button button666;
        private System.Windows.Forms.Button button555;
        private System.Windows.Forms.Button button444;
        private System.Windows.Forms.Button button333;
        private System.Windows.Forms.Button button222;
        private System.Windows.Forms.Button button111;
        private System.Windows.Forms.TextBox txtTimeNow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picHeader;
        private System.Windows.Forms.Label labHead;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labTishi;
        private System.Windows.Forms.Label labTime;
        private System.Windows.Forms.Label labCountDown;
        private System.Windows.Forms.Label labTIshi2;
        private System.Windows.Forms.PictureBox picBottom;
        private System.Windows.Forms.Label labBottom;
        private System.Windows.Forms.Label labExit;
        private System.Windows.Forms.PictureBox picExit;
        private System.Windows.Forms.RichTextBox txtAddress;
        private System.Windows.Forms.Panel panelSuccess;
        private System.Windows.Forms.Panel panelSmallFail;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.Panel panelSmallSuccess;
        private System.Windows.Forms.Panel panelMessage;
        private System.Windows.Forms.Panel panelAll;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button link2;
        private System.Windows.Forms.PictureBox picError;
        private System.Windows.Forms.TextBox txtErrorMessage;
    }
}

