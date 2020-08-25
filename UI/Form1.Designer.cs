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
            this.txtYan = new System.Windows.Forms.TextBox();
            this.link3 = new System.Windows.Forms.LinkLabel();
            this.btnNoAgree = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtIDCard = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.btnAgree = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.link2 = new System.Windows.Forms.PictureBox();
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.btnRegister = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.picHict = new System.Windows.Forms.PictureBox();
            this.button222 = new System.Windows.Forms.Button();
            this.Paneljp = new System.Windows.Forms.Panel();
            this.button111 = new System.Windows.Forms.Button();
            this.button333 = new System.Windows.Forms.Button();
            this.button444 = new System.Windows.Forms.Button();
            this.button555 = new System.Windows.Forms.Button();
            this.button666 = new System.Windows.Forms.Button();
            this.button888 = new System.Windows.Forms.Button();
            this.button777 = new System.Windows.Forms.Button();
            this.button999 = new System.Windows.Forms.Button();
            this.button000 = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnook = new System.Windows.Forms.Button();
            this.panelAll = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.link2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHict)).BeginInit();
            this.Paneljp.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtYan
            // 
            this.txtYan.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtYan.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtYan.Location = new System.Drawing.Point(234, 428);
            this.txtYan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtYan.Multiline = true;
            this.txtYan.Name = "txtYan";
            this.txtYan.Size = new System.Drawing.Size(150, 24);
            this.txtYan.TabIndex = 9;
            this.txtYan.Click += new System.EventHandler(this.txtYan_Click);
            this.txtYan.TextChanged += new System.EventHandler(this.txtYan_TextChanged);
            this.txtYan.Enter += new System.EventHandler(this.txtYan_Enter);
            this.txtYan.Leave += new System.EventHandler(this.txtYan_Leave);
            // 
            // link3
            // 
            this.link3.BackColor = System.Drawing.Color.White;
            this.link3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.link3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.link3.Location = new System.Drawing.Point(408, 410);
            this.link3.Name = "link3";
            this.link3.Size = new System.Drawing.Size(111, 42);
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
            this.btnNoAgree.Location = new System.Drawing.Point(217, 483);
            this.btnNoAgree.Name = "btnNoAgree";
            this.btnNoAgree.Size = new System.Drawing.Size(33, 30);
            this.btnNoAgree.TabIndex = 47;
            this.btnNoAgree.UseVisualStyleBackColor = false;
            this.btnNoAgree.Click += new System.EventHandler(this.btnNoAgree_Click);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtName.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtName.Location = new System.Drawing.Point(234, 184);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(198, 24);
            this.txtName.TabIndex = 5;
            this.txtName.Click += new System.EventHandler(this.txtName_Click);
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.Enter += new System.EventHandler(this.txtName_Enter);
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // txtIDCard
            // 
            this.txtIDCard.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtIDCard.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtIDCard.Location = new System.Drawing.Point(234, 248);
            this.txtIDCard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIDCard.Multiline = true;
            this.txtIDCard.Name = "txtIDCard";
            this.txtIDCard.Size = new System.Drawing.Size(198, 24);
            this.txtIDCard.TabIndex = 6;
            this.txtIDCard.Click += new System.EventHandler(this.txtIDCard_Click);
            this.txtIDCard.TextChanged += new System.EventHandler(this.txtIDCard_TextChanged);
            this.txtIDCard.Leave += new System.EventHandler(this.txtIDCard_Leave);
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtAddress.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtAddress.Location = new System.Drawing.Point(234, 310);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(198, 24);
            this.txtAddress.TabIndex = 7;
            this.txtAddress.Click += new System.EventHandler(this.txtAddress_Click);
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            this.txtAddress.Leave += new System.EventHandler(this.txtAddress_Leave);
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtPhone.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtPhone.Location = new System.Drawing.Point(234, 368);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPhone.Multiline = true;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(198, 24);
            this.txtPhone.TabIndex = 8;
            this.txtPhone.Click += new System.EventHandler(this.txtPhone_Click);
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            this.txtPhone.Enter += new System.EventHandler(this.txtPhone_Enter);
            this.txtPhone.Leave += new System.EventHandler(this.txtPhone_Leave);
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
            this.btnAgree.Location = new System.Drawing.Point(216, 483);
            this.btnAgree.Name = "btnAgree";
            this.btnAgree.Size = new System.Drawing.Size(33, 30);
            this.btnAgree.TabIndex = 46;
            this.btnAgree.UseVisualStyleBackColor = false;
            this.btnAgree.Click += new System.EventHandler(this.btnAgree_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(153, 537);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(350, 57);
            this.button1.TabIndex = 49;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox2.Location = new System.Drawing.Point(255, 488);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(285, 25);
            this.pictureBox2.TabIndex = 50;
            this.pictureBox2.TabStop = false;
            // 
            // link2
            // 
            this.link2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.link2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("link2.BackgroundImage")));
            this.link2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.link2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.link2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.link2.Location = new System.Drawing.Point(408, 410);
            this.link2.Name = "link2";
            this.link2.Size = new System.Drawing.Size(111, 42);
            this.link2.TabIndex = 51;
            this.link2.TabStop = false;
            this.link2.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.Location = new System.Drawing.Point(665, 176);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(517, 354);
            this.videoSourcePlayer1.TabIndex = 53;
            this.videoSourcePlayer1.Text = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnRegister.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRegister.BackgroundImage")));
            this.btnRegister.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRegister.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRegister.Location = new System.Drawing.Point(153, 615);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(350, 57);
            this.btnRegister.TabIndex = 54;
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // picHict
            // 
            this.picHict.BackColor = System.Drawing.Color.White;
            this.picHict.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picHict.BackgroundImage")));
            this.picHict.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picHict.Location = new System.Drawing.Point(665, 176);
            this.picHict.Name = "picHict";
            this.picHict.Size = new System.Drawing.Size(517, 354);
            this.picHict.TabIndex = 55;
            this.picHict.TabStop = false;
            // 
            // button222
            // 
            this.button222.BackColor = System.Drawing.Color.White;
            this.button222.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button222.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.button222.ForeColor = System.Drawing.Color.Blue;
            this.button222.Location = new System.Drawing.Point(103, 17);
            this.button222.Name = "button222";
            this.button222.Size = new System.Drawing.Size(63, 57);
            this.button222.TabIndex = 30;
            this.button222.Text = "2";
            this.button222.UseVisualStyleBackColor = false;
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
            this.Paneljp.Location = new System.Drawing.Point(525, 176);
            this.Paneljp.Name = "Paneljp";
            this.Paneljp.Size = new System.Drawing.Size(266, 321);
            this.Paneljp.TabIndex = 56;
            // 
            // button111
            // 
            this.button111.BackColor = System.Drawing.Color.White;
            this.button111.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button111.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.button111.ForeColor = System.Drawing.Color.Blue;
            this.button111.Location = new System.Drawing.Point(19, 17);
            this.button111.Name = "button111";
            this.button111.Size = new System.Drawing.Size(63, 57);
            this.button111.TabIndex = 29;
            this.button111.Text = "1";
            this.button111.UseVisualStyleBackColor = false;
            this.button111.Click += new System.EventHandler(this.button111_Click);
            // 
            // button333
            // 
            this.button333.BackColor = System.Drawing.Color.White;
            this.button333.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button333.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.button333.ForeColor = System.Drawing.Color.Blue;
            this.button333.Location = new System.Drawing.Point(189, 17);
            this.button333.Name = "button333";
            this.button333.Size = new System.Drawing.Size(63, 57);
            this.button333.TabIndex = 31;
            this.button333.Text = "3";
            this.button333.UseVisualStyleBackColor = false;
            // 
            // button444
            // 
            this.button444.BackColor = System.Drawing.Color.White;
            this.button444.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button444.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.button444.ForeColor = System.Drawing.Color.Blue;
            this.button444.Location = new System.Drawing.Point(19, 90);
            this.button444.Name = "button444";
            this.button444.Size = new System.Drawing.Size(63, 57);
            this.button444.TabIndex = 32;
            this.button444.Text = "4";
            this.button444.UseVisualStyleBackColor = false;
            // 
            // button555
            // 
            this.button555.BackColor = System.Drawing.Color.White;
            this.button555.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button555.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.button555.ForeColor = System.Drawing.Color.Blue;
            this.button555.Location = new System.Drawing.Point(103, 90);
            this.button555.Name = "button555";
            this.button555.Size = new System.Drawing.Size(63, 57);
            this.button555.TabIndex = 33;
            this.button555.Text = "5";
            this.button555.UseVisualStyleBackColor = false;
            // 
            // button666
            // 
            this.button666.BackColor = System.Drawing.Color.White;
            this.button666.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button666.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.button666.ForeColor = System.Drawing.Color.Blue;
            this.button666.Location = new System.Drawing.Point(189, 90);
            this.button666.Name = "button666";
            this.button666.Size = new System.Drawing.Size(63, 57);
            this.button666.TabIndex = 34;
            this.button666.Text = "6";
            this.button666.UseVisualStyleBackColor = false;
            // 
            // button888
            // 
            this.button888.BackColor = System.Drawing.Color.White;
            this.button888.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button888.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.button888.ForeColor = System.Drawing.Color.Blue;
            this.button888.Location = new System.Drawing.Point(103, 171);
            this.button888.Name = "button888";
            this.button888.Size = new System.Drawing.Size(63, 57);
            this.button888.TabIndex = 36;
            this.button888.Text = "8";
            this.button888.UseVisualStyleBackColor = false;
            // 
            // button777
            // 
            this.button777.BackColor = System.Drawing.Color.White;
            this.button777.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button777.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.button777.ForeColor = System.Drawing.Color.Blue;
            this.button777.Location = new System.Drawing.Point(19, 171);
            this.button777.Name = "button777";
            this.button777.Size = new System.Drawing.Size(63, 57);
            this.button777.TabIndex = 35;
            this.button777.Text = "7";
            this.button777.UseVisualStyleBackColor = false;
            // 
            // button999
            // 
            this.button999.BackColor = System.Drawing.Color.White;
            this.button999.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button999.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.button999.ForeColor = System.Drawing.Color.Blue;
            this.button999.Location = new System.Drawing.Point(189, 171);
            this.button999.Name = "button999";
            this.button999.Size = new System.Drawing.Size(63, 57);
            this.button999.TabIndex = 37;
            this.button999.Text = "9";
            this.button999.UseVisualStyleBackColor = false;
            // 
            // button000
            // 
            this.button000.BackColor = System.Drawing.Color.White;
            this.button000.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button000.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.button000.ForeColor = System.Drawing.Color.Blue;
            this.button000.Location = new System.Drawing.Point(103, 252);
            this.button000.Name = "button000";
            this.button000.Size = new System.Drawing.Size(63, 57);
            this.button000.TabIndex = 38;
            this.button000.Text = "0";
            this.button000.UseVisualStyleBackColor = false;
            this.button000.Click += new System.EventHandler(this.button000_Click);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.White;
            this.btndelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btndelete.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btndelete.ForeColor = System.Drawing.Color.Blue;
            this.btndelete.Location = new System.Drawing.Point(19, 252);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(63, 57);
            this.btndelete.TabIndex = 40;
            this.btndelete.Text = "回删";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click_1);
            // 
            // btnook
            // 
            this.btnook.BackColor = System.Drawing.Color.White;
            this.btnook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnook.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnook.ForeColor = System.Drawing.Color.Blue;
            this.btnook.Location = new System.Drawing.Point(189, 252);
            this.btnook.Name = "btnook";
            this.btnook.Size = new System.Drawing.Size(63, 57);
            this.btnook.TabIndex = 42;
            this.btnook.Text = "清空";
            this.btnook.UseVisualStyleBackColor = false;
            this.btnook.Click += new System.EventHandler(this.btnook_Click);
            // 
            // panelAll
            // 
            this.panelAll.BackColor = System.Drawing.Color.Transparent;
            this.panelAll.Location = new System.Drawing.Point(68, 119);
            this.panelAll.Name = "panelAll";
            this.panelAll.Size = new System.Drawing.Size(1061, 583);
            this.panelAll.TabIndex = 57;
            this.panelAll.Controls.Add(this.Paneljp);
            this.panelAll.Controls.Add(this.picHict);
            this.panelAll.Controls.Add(this.btnRegister);
            this.panelAll.Controls.Add(this.videoSourcePlayer1);
            this.panelAll.Controls.Add(this.link2);
            this.panelAll.Controls.Add(this.pictureBox2);
            this.panelAll.Controls.Add(this.button1);
            this.panelAll.Controls.Add(this.btnAgree);
            this.panelAll.Controls.Add(this.txtYan);
            this.panelAll.Controls.Add(this.txtPhone);
            this.panelAll.Controls.Add(this.txtAddress);
            this.panelAll.Controls.Add(this.txtIDCard);
            this.panelAll.Controls.Add(this.txtName);
            this.panelAll.Controls.Add(this.btnNoAgree);
            this.panelAll.Controls.Add(this.link3);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(946, 657);
            this.Controls.Add(this.panelAll);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "42";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.link2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHict)).EndInit();
            this.Paneljp.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtYan;
        private System.Windows.Forms.LinkLabel link3;
        private System.Windows.Forms.Button btnNoAgree;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtIDCard;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button btnAgree;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox link2;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox picHict;
        private System.Windows.Forms.Button button222;
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
        private System.Windows.Forms.Button button111;
        private System.Windows.Forms.Panel panelAll;
    }
}

