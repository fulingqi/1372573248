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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.picText = new System.Windows.Forms.PictureBox();
            this.btnAgree = new System.Windows.Forms.Button();
            this.picIsShow = new System.Windows.Forms.PictureBox();
            this.link2 = new System.Windows.Forms.PictureBox();
            this.btnNoAgree = new System.Windows.Forms.Button();
            this.link3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.btnRegister = new System.Windows.Forms.Button();
            this.panelSuccess = new System.Windows.Forms.Panel();
            this.panelSuccTwo = new System.Windows.Forms.Panel();
            this.txtSuccess = new System.Windows.Forms.TextBox();
            this.panelFail = new System.Windows.Forms.Panel();
            this.panelFailTwo = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtZhuCeSuccess = new System.Windows.Forms.TextBox();
            this.panelWait = new System.Windows.Forms.Panel();
            this.panelWaittwo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.timerSuccess = new System.Windows.Forms.Timer(this.components);
            this.timerfail = new System.Windows.Forms.Timer(this.components);
            this.linkReturns = new System.Windows.Forms.LinkLabel();
            this.txtFails = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelCang = new System.Windows.Forms.Panel();
            this.btnNofinsh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIsShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.link2)).BeginInit();
            this.panelSuccess.SuspendLayout();
            this.panelSuccTwo.SuspendLayout();
            this.panelFail.SuspendLayout();
            this.panelFailTwo.SuspendLayout();
            this.panelWait.SuspendLayout();
            this.panelWaittwo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtName.Location = new System.Drawing.Point(144, 133);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(317, 37);
            this.txtName.TabIndex = 0;
            this.txtName.Text = "请输入姓名";
            this.txtName.Click += new System.EventHandler(this.txtName_Click);
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.Enter += new System.EventHandler(this.txtName_Enter);
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // txtIDCard
            // 
            this.txtIDCard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIDCard.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtIDCard.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtIDCard.Location = new System.Drawing.Point(144, 205);
            this.txtIDCard.Multiline = true;
            this.txtIDCard.Name = "txtIDCard";
            this.txtIDCard.Size = new System.Drawing.Size(352, 33);
            this.txtIDCard.TabIndex = 1;
            this.txtIDCard.Text = "请输入身份证号";
            this.txtIDCard.Click += new System.EventHandler(this.txtIDCard_Click);
            this.txtIDCard.TextChanged += new System.EventHandler(this.txtIDCard_TextChanged);
            this.txtIDCard.Enter += new System.EventHandler(this.txtIDCard_Enter);
            this.txtIDCard.Leave += new System.EventHandler(this.txtIDCard_Leave);
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddress.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAddress.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtAddress.Location = new System.Drawing.Point(148, 267);
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
            this.txtPhone.Location = new System.Drawing.Point(144, 340);
            this.txtPhone.Multiline = true;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(521, 37);
            this.txtPhone.TabIndex = 3;
            this.txtPhone.Text = "请输入手机号";
            this.txtPhone.Click += new System.EventHandler(this.txtPhone_Click);
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            this.txtPhone.Enter += new System.EventHandler(this.txtPhone_Enter);
            this.txtPhone.Leave += new System.EventHandler(this.txtPhone_Leave);
            // 
            // txtYan
            // 
            this.txtYan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtYan.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtYan.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtYan.Location = new System.Drawing.Point(148, 403);
            this.txtYan.Multiline = true;
            this.txtYan.Name = "txtYan";
            this.txtYan.Size = new System.Drawing.Size(216, 37);
            this.txtYan.TabIndex = 4;
            this.txtYan.Text = "请输入验证码";
            this.txtYan.Click += new System.EventHandler(this.txtYan_Click);
            this.txtYan.TextChanged += new System.EventHandler(this.txtYan_TextChanged);
            this.txtYan.Enter += new System.EventHandler(this.txtYan_Enter);
            this.txtYan.Leave += new System.EventHandler(this.txtYan_Leave);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer4
            // 
            this.timer4.Interval = 2000;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // picText
            // 
            this.picText.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picText.BackgroundImage")));
            this.picText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picText.Location = new System.Drawing.Point(74, 822);
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
            this.btnAgree.Location = new System.Drawing.Point(26, 810);
            this.btnAgree.Name = "btnAgree";
            this.btnAgree.Size = new System.Drawing.Size(42, 51);
            this.btnAgree.TabIndex = 43;
            this.btnAgree.UseVisualStyleBackColor = false;
            this.btnAgree.Click += new System.EventHandler(this.btnAgree_Click);
            // 
            // picIsShow
            // 
            this.picIsShow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picIsShow.BackgroundImage")));
            this.picIsShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picIsShow.Location = new System.Drawing.Point(189, 521);
            this.picIsShow.Name = "picIsShow";
            this.picIsShow.Size = new System.Drawing.Size(240, 248);
            this.picIsShow.TabIndex = 16;
            this.picIsShow.TabStop = false;
            this.picIsShow.Click += new System.EventHandler(this.picIsShow_Click);
            // 
            // link2
            // 
            this.link2.BackgroundImage = global::UI.Properties.Resources.验证码;
            this.link2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.link2.Location = new System.Drawing.Point(484, 402);
            this.link2.Name = "link2";
            this.link2.Size = new System.Drawing.Size(125, 32);
            this.link2.TabIndex = 5;
            this.link2.TabStop = false;
            this.link2.Click += new System.EventHandler(this.pictureBox1_Click);
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
            this.btnNoAgree.Location = new System.Drawing.Point(26, 810);
            this.btnNoAgree.Name = "btnNoAgree";
            this.btnNoAgree.Size = new System.Drawing.Size(42, 51);
            this.btnNoAgree.TabIndex = 44;
            this.btnNoAgree.UseVisualStyleBackColor = false;
            this.btnNoAgree.Click += new System.EventHandler(this.btnNoAgree_Click);
            // 
            // link3
            // 
            this.link3.BackColor = System.Drawing.Color.White;
            this.link3.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.link3.Location = new System.Drawing.Point(479, 406);
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
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.White;
            this.btnRegister.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRegister.BackgroundImage")));
            this.btnRegister.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnRegister.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRegister.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRegister.Location = new System.Drawing.Point(12, 876);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(586, 91);
            this.btnRegister.TabIndex = 48;
            this.btnRegister.Text = "注册";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.button10_Click);
            // 
            // panelSuccess
            // 
            this.panelSuccess.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelSuccess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSuccess.Controls.Add(this.panelSuccTwo);
            this.panelSuccess.Location = new System.Drawing.Point(1, -1);
            this.panelSuccess.Name = "panelSuccess";
            this.panelSuccess.Size = new System.Drawing.Size(611, 1012);
            this.panelSuccess.TabIndex = 0;
            // 
            // panelSuccTwo
            // 
            this.panelSuccTwo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelSuccTwo.BackgroundImage")));
            this.panelSuccTwo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSuccTwo.Controls.Add(this.txtSuccess);
            this.panelSuccTwo.Location = new System.Drawing.Point(87, 317);
            this.panelSuccTwo.Name = "panelSuccTwo";
            this.panelSuccTwo.Size = new System.Drawing.Size(453, 299);
            this.panelSuccTwo.TabIndex = 1;
            // 
            // txtSuccess
            // 
            this.txtSuccess.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSuccess.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSuccess.Location = new System.Drawing.Point(213, 246);
            this.txtSuccess.Multiline = true;
            this.txtSuccess.Name = "txtSuccess";
            this.txtSuccess.Size = new System.Drawing.Size(33, 32);
            this.txtSuccess.TabIndex = 0;
            this.txtSuccess.TextChanged += new System.EventHandler(this.txtSuccess_TextChanged);
            // 
            // panelFail
            // 
            this.panelFail.BackColor = System.Drawing.Color.White;
            this.panelFail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelFail.Controls.Add(this.panelFailTwo);
            this.panelFail.Location = new System.Drawing.Point(-2, -2);
            this.panelFail.Name = "panelFail";
            this.panelFail.Size = new System.Drawing.Size(611, 1012);
            this.panelFail.TabIndex = 51;
            // 
            // panelFailTwo
            // 
            this.panelFailTwo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelFailTwo.BackgroundImage")));
            this.panelFailTwo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelFailTwo.Controls.Add(this.textBox1);
            this.panelFailTwo.Controls.Add(this.txtZhuCeSuccess);
            this.panelFailTwo.Location = new System.Drawing.Point(87, 323);
            this.panelFailTwo.Name = "panelFailTwo";
            this.panelFailTwo.Size = new System.Drawing.Size(465, 305);
            this.panelFailTwo.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(86, 232);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(290, 40);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtZhuCeSuccess
            // 
            this.txtZhuCeSuccess.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtZhuCeSuccess.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtZhuCeSuccess.Location = new System.Drawing.Point(76, 171);
            this.txtZhuCeSuccess.Multiline = true;
            this.txtZhuCeSuccess.Name = "txtZhuCeSuccess";
            this.txtZhuCeSuccess.Size = new System.Drawing.Size(78, 39);
            this.txtZhuCeSuccess.TabIndex = 1;
            // 
            // panelWait
            // 
            this.panelWait.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelWait.Controls.Add(this.panelWaittwo);
            this.panelWait.Location = new System.Drawing.Point(4, 2);
            this.panelWait.Name = "panelWait";
            this.panelWait.Size = new System.Drawing.Size(611, 1012);
            this.panelWait.TabIndex = 54;
            // 
            // panelWaittwo
            // 
            this.panelWaittwo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelWaittwo.BackgroundImage")));
            this.panelWaittwo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelWaittwo.Controls.Add(this.label1);
            this.panelWaittwo.Location = new System.Drawing.Point(95, 360);
            this.panelWaittwo.Name = "panelWaittwo";
            this.panelWaittwo.Size = new System.Drawing.Size(458, 255);
            this.panelWaittwo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(175, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 86);
            this.label1.TabIndex = 0;
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
            // linkReturns
            // 
            this.linkReturns.AutoSize = true;
            this.linkReturns.BackColor = System.Drawing.Color.White;
            this.linkReturns.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkReturns.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.linkReturns.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkReturns.LinkColor = System.Drawing.Color.Red;
            this.linkReturns.Location = new System.Drawing.Point(234, 970);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.label2.Location = new System.Drawing.Point(12, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 31);
            this.label2.TabIndex = 54;
            this.label2.Text = "姓      名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.label3.Location = new System.Drawing.Point(14, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 31);
            this.label3.TabIndex = 55;
            this.label3.Text = "身份证号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.label4.Location = new System.Drawing.Point(20, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 31);
            this.label4.TabIndex = 56;
            this.label4.Text = "地      址：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.label5.Location = new System.Drawing.Point(20, 341);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 31);
            this.label5.TabIndex = 57;
            this.label5.Text = "手 机 号：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.label6.Location = new System.Drawing.Point(24, 403);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 31);
            this.label6.TabIndex = 58;
            this.label6.Text = "验 证 码：";
            // 
            // panelCang
            // 
            this.panelCang.BackColor = System.Drawing.Color.White;
            this.panelCang.Location = new System.Drawing.Point(26, 782);
            this.panelCang.Name = "panelCang";
            this.panelCang.Size = new System.Drawing.Size(505, 79);
            this.panelCang.TabIndex = 59;
            // 
            // btnNofinsh
            // 
            this.btnNofinsh.BackColor = System.Drawing.Color.White;
            this.btnNofinsh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNofinsh.FlatAppearance.BorderSize = 0;
            this.btnNofinsh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnNofinsh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnNofinsh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNofinsh.Font = new System.Drawing.Font("微软雅黑", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNofinsh.ForeColor = System.Drawing.Color.Blue;
            this.btnNofinsh.Location = new System.Drawing.Point(4, 879);
            this.btnNofinsh.Name = "btnNofinsh";
            this.btnNofinsh.Size = new System.Drawing.Size(594, 82);
            this.btnNofinsh.TabIndex = 61;
            this.btnNofinsh.Text = "实名注册    刷脸就医";
            this.btnNofinsh.UseVisualStyleBackColor = false;
            // 
            // FaceRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UI.Properties.Resources._9_1注册;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(618, 1011);
            this.Controls.Add(this.panelSuccess);
            this.Controls.Add(this.panelFail);
            this.Controls.Add(this.panelWait);
            this.Controls.Add(this.panelCang);
            this.Controls.Add(this.btnNofinsh);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.link2);
            this.Controls.Add(this.linkReturns);
            this.Controls.Add(this.link3);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.picIsShow);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.picText);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtYan);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtIDCard);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnAgree);
            this.Controls.Add(this.btnNoAgree);
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.DoubleBuffered = true;
            this.Location = new System.Drawing.Point(1280, 0);
            this.MaximizeBox = false;
            this.Name = "FaceRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FaceRegister";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FaceRegister_FormClosing);
            this.Load += new System.EventHandler(this.FaceRegister_Load);
            this.Shown += new System.EventHandler(this.FaceRegister_Shown);
            this.MouseLeave += new System.EventHandler(this.FaceRegister_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.picText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIsShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.link2)).EndInit();
            this.panelSuccess.ResumeLayout(false);
            this.panelSuccTwo.ResumeLayout(false);
            this.panelSuccTwo.PerformLayout();
            this.panelFail.ResumeLayout(false);
            this.panelFailTwo.ResumeLayout(false);
            this.panelFailTwo.PerformLayout();
            this.panelWait.ResumeLayout(false);
            this.panelWaittwo.ResumeLayout(false);
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
        private System.Windows.Forms.PictureBox picIsShow;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Button btnAgree;
        private System.Windows.Forms.Button btnNoAgree;
        private System.Windows.Forms.PictureBox picText;
        private System.Windows.Forms.LinkLabel link3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Panel panelSuccess;
        private System.Windows.Forms.Panel panelFail;
        private System.Windows.Forms.Timer timerSuccess;
        private System.Windows.Forms.Timer timerfail;
        private System.Windows.Forms.TextBox txtSuccess;
        private System.Windows.Forms.LinkLabel linkReturns;
        private System.Windows.Forms.TextBox txtFails;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtZhuCeSuccess;
        private System.Windows.Forms.Panel panelWait;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelCang;
        private System.Windows.Forms.Panel panelFailTwo;
        private System.Windows.Forms.Panel panelSuccTwo;
        private System.Windows.Forms.Panel panelWaittwo;
        private System.Windows.Forms.Button btnNofinsh;
    }
}