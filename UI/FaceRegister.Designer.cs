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
            this.txtName = new System.Windows.Forms.RichTextBox();
            this.txtIDCard = new System.Windows.Forms.RichTextBox();
            this.txtPhone = new System.Windows.Forms.RichTextBox();
            this.txtYan = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.picText = new System.Windows.Forms.PictureBox();
            this.btnAgree = new System.Windows.Forms.Button();
            this.picIsShow = new System.Windows.Forms.PictureBox();
            this.link2 = new System.Windows.Forms.PictureBox();
            this.btnNoAgree = new System.Windows.Forms.Button();
            this.link3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnRegister = new System.Windows.Forms.Button();
            this.panelSuccess = new System.Windows.Forms.Panel();
            this.panelSuccTwo = new System.Windows.Forms.Panel();
            this.txtSuccess = new System.Windows.Forms.TextBox();
            this.panelWait = new System.Windows.Forms.Panel();
            this.panelWaittwo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelFail = new System.Windows.Forms.Panel();
            this.panelFailTwo = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtZhuCeSuccess = new System.Windows.Forms.TextBox();
            this.linkReturns = new System.Windows.Forms.LinkLabel();
            this.txtFails = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelAll = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtAddress = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelConnectWait = new System.Windows.Forms.Panel();
            this.panelConnectWaitTwo = new System.Windows.Forms.Panel();
            this.labelconnect = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIsShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.link2)).BeginInit();
            this.panelSuccess.SuspendLayout();
            this.panelSuccTwo.SuspendLayout();
            this.panelWait.SuspendLayout();
            this.panelWaittwo.SuspendLayout();
            this.panelFail.SuspendLayout();
            this.panelFailTwo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelAll.SuspendLayout();
            this.panelConnectWait.SuspendLayout();
            this.panelConnectWaitTwo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtName.Name = "txtName";
            this.txtName.Click += new System.EventHandler(this.txtName_Click);
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // txtIDCard
            // 
            this.txtIDCard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtIDCard, "txtIDCard");
            this.txtIDCard.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtIDCard.Name = "txtIDCard";
            this.txtIDCard.Click += new System.EventHandler(this.txtIDCard_Click);
            this.txtIDCard.TextChanged += new System.EventHandler(this.txtIDCard_TextChanged);
            this.txtIDCard.Enter += new System.EventHandler(this.txtIDCard_Enter);
            this.txtIDCard.Leave += new System.EventHandler(this.txtIDCard_Leave);
            // 
            // txtPhone
            // 
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtPhone, "txtPhone");
            this.txtPhone.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Click += new System.EventHandler(this.txtPhone_Click);
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            this.txtPhone.Enter += new System.EventHandler(this.txtPhone_Enter);
            this.txtPhone.Leave += new System.EventHandler(this.txtPhone_Leave);
            // 
            // txtYan
            // 
            this.txtYan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtYan, "txtYan");
            this.txtYan.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtYan.Name = "txtYan";
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
            // picText
            // 
            resources.ApplyResources(this.picText, "picText");
            this.picText.Name = "picText";
            this.picText.TabStop = false;
            this.picText.Click += new System.EventHandler(this.picText_Click);
            // 
            // btnAgree
            // 
            this.btnAgree.AllowDrop = true;
            this.btnAgree.BackColor = System.Drawing.Color.White;
            this.btnAgree.BackgroundImage = global::UI.Properties.Resources.icon_checked_mark;
            resources.ApplyResources(this.btnAgree, "btnAgree");
            this.btnAgree.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAgree.FlatAppearance.BorderSize = 0;
            this.btnAgree.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAgree.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAgree.Name = "btnAgree";
            this.btnAgree.UseVisualStyleBackColor = false;
            this.btnAgree.Click += new System.EventHandler(this.btnAgree_Click);
            // 
            // picIsShow
            // 
            resources.ApplyResources(this.picIsShow, "picIsShow");
            this.picIsShow.Name = "picIsShow";
            this.picIsShow.TabStop = false;
            this.picIsShow.Click += new System.EventHandler(this.picIsShow_Click);
            // 
            // link2
            // 
            this.link2.BackgroundImage = global::UI.Properties.Resources.验证码;
            resources.ApplyResources(this.link2, "link2");
            this.link2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.link2.Name = "link2";
            this.link2.TabStop = false;
            this.link2.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnNoAgree
            // 
            this.btnNoAgree.AllowDrop = true;
            this.btnNoAgree.BackColor = System.Drawing.Color.White;
            this.btnNoAgree.BackgroundImage = global::UI.Properties.Resources.icon_Unchecked;
            resources.ApplyResources(this.btnNoAgree, "btnNoAgree");
            this.btnNoAgree.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNoAgree.FlatAppearance.BorderSize = 0;
            this.btnNoAgree.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnNoAgree.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnNoAgree.Name = "btnNoAgree";
            this.btnNoAgree.UseVisualStyleBackColor = false;
            this.btnNoAgree.Click += new System.EventHandler(this.btnNoAgree_Click);
            // 
            // link3
            // 
            this.link3.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.link3, "link3");
            this.link3.Name = "link3";
            this.link3.TabStop = true;
            this.link3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link3_LinkClicked);
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.LinkColor = System.Drawing.Color.Red;
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked_1);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.btnRegister, "btnRegister");
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnRegister.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnRegister.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.button10_Click);
            // 
            // panelSuccess
            // 
            this.panelSuccess.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.panelSuccess, "panelSuccess");
            this.panelSuccess.Controls.Add(this.panelSuccTwo);
            this.panelSuccess.Name = "panelSuccess";
            // 
            // panelSuccTwo
            // 
            resources.ApplyResources(this.panelSuccTwo, "panelSuccTwo");
            this.panelSuccTwo.Controls.Add(this.txtSuccess);
            this.panelSuccTwo.Name = "panelSuccTwo";
            // 
            // txtSuccess
            // 
            this.txtSuccess.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtSuccess, "txtSuccess");
            this.txtSuccess.Name = "txtSuccess";
            // 
            // panelWait
            // 
            resources.ApplyResources(this.panelWait, "panelWait");
            this.panelWait.Controls.Add(this.panelWaittwo);
            this.panelWait.Name = "panelWait";
            // 
            // panelWaittwo
            // 
            resources.ApplyResources(this.panelWaittwo, "panelWaittwo");
            this.panelWaittwo.Controls.Add(this.label1);
            this.panelWaittwo.Name = "panelWaittwo";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // panelFail
            // 
            this.panelFail.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.panelFail, "panelFail");
            this.panelFail.Controls.Add(this.panelFailTwo);
            this.panelFail.Name = "panelFail";
            // 
            // panelFailTwo
            // 
            resources.ApplyResources(this.panelFailTwo, "panelFailTwo");
            this.panelFailTwo.Controls.Add(this.textBox1);
            this.panelFailTwo.Controls.Add(this.txtZhuCeSuccess);
            this.panelFailTwo.Name = "panelFailTwo";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // txtZhuCeSuccess
            // 
            this.txtZhuCeSuccess.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtZhuCeSuccess, "txtZhuCeSuccess");
            this.txtZhuCeSuccess.Name = "txtZhuCeSuccess";
            // 
            // linkReturns
            // 
            resources.ApplyResources(this.linkReturns, "linkReturns");
            this.linkReturns.BackColor = System.Drawing.Color.White;
            this.linkReturns.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.linkReturns.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkReturns.LinkColor = System.Drawing.Color.Red;
            this.linkReturns.Name = "linkReturns";
            this.linkReturns.TabStop = true;
            this.linkReturns.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkReturns_LinkClicked);
            // 
            // txtFails
            // 
            this.txtFails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtFails, "txtFails");
            this.txtFails.Name = "txtFails";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtFails);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Name = "label6";
            // 
            // panelAll
            // 
            this.panelAll.BackColor = System.Drawing.Color.White;
            this.panelAll.Controls.Add(this.label12);
            this.panelAll.Controls.Add(this.label11);
            this.panelAll.Controls.Add(this.label10);
            this.panelAll.Controls.Add(this.label9);
            this.panelAll.Controls.Add(this.label8);
            this.panelAll.Controls.Add(this.pictureBox2);
            this.panelAll.Controls.Add(this.txtAddress);
            this.panelAll.Controls.Add(this.label7);
            this.panelAll.Controls.Add(this.link2);
            this.panelAll.Controls.Add(this.link3);
            this.panelAll.Controls.Add(this.pictureBox1);
            this.panelAll.Controls.Add(this.label2);
            this.panelAll.Controls.Add(this.btnNoAgree);
            this.panelAll.Controls.Add(this.btnAgree);
            this.panelAll.Controls.Add(this.txtName);
            this.panelAll.Controls.Add(this.label6);
            this.panelAll.Controls.Add(this.txtIDCard);
            this.panelAll.Controls.Add(this.label5);
            this.panelAll.Controls.Add(this.label4);
            this.panelAll.Controls.Add(this.txtYan);
            this.panelAll.Controls.Add(this.label3);
            this.panelAll.Controls.Add(this.txtPhone);
            this.panelAll.Controls.Add(this.picText);
            this.panelAll.Controls.Add(this.picIsShow);
            this.panelAll.Controls.Add(this.linkReturns);
            this.panelAll.Controls.Add(this.btnRegister);
            resources.ApplyResources(this.panelAll, "panelAll");
            this.panelAll.Name = "panelAll";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label12.Name = "label12";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label11.Name = "label11";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label10.Name = "label10";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label8.Name = "label8";
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtAddress, "txtAddress");
            this.txtAddress.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Click += new System.EventHandler(this.txtAddress_Click);
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            this.txtAddress.Enter += new System.EventHandler(this.txtAddress_Enter);
            this.txtAddress.Leave += new System.EventHandler(this.txtAddress_Leave);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Name = "label7";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // panelConnectWait
            // 
            resources.ApplyResources(this.panelConnectWait, "panelConnectWait");
            this.panelConnectWait.Controls.Add(this.panelConnectWaitTwo);
            this.panelConnectWait.Name = "panelConnectWait";
            // 
            // panelConnectWaitTwo
            // 
            resources.ApplyResources(this.panelConnectWaitTwo, "panelConnectWaitTwo");
            this.panelConnectWaitTwo.Controls.Add(this.labelconnect);
            this.panelConnectWaitTwo.Name = "panelConnectWaitTwo";
            // 
            // labelconnect
            // 
            this.labelconnect.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.labelconnect, "labelconnect");
            this.labelconnect.Name = "labelconnect";
            // 
            // FaceRegister
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelWait);
            this.Controls.Add(this.panelSuccess);
            this.Controls.Add(this.panelFail);
            this.Controls.Add(this.panelConnectWait);
            this.Controls.Add(this.panelAll);
            this.Controls.Add(this.linkLabel1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FaceRegister";
            this.Load += new System.EventHandler(this.FaceRegister_Load);
            this.Shown += new System.EventHandler(this.FaceRegister_Shown);
            this.SizeChanged += new System.EventHandler(this.FaceRegister_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.picText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIsShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.link2)).EndInit();
            this.panelSuccess.ResumeLayout(false);
            this.panelSuccTwo.ResumeLayout(false);
            this.panelSuccTwo.PerformLayout();
            this.panelWait.ResumeLayout(false);
            this.panelWaittwo.ResumeLayout(false);
            this.panelFail.ResumeLayout(false);
            this.panelFailTwo.ResumeLayout(false);
            this.panelFailTwo.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelAll.ResumeLayout(false);
            this.panelAll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelConnectWait.ResumeLayout(false);
            this.panelConnectWaitTwo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox txtName;
        private System.Windows.Forms.RichTextBox txtIDCard;
        private System.Windows.Forms.RichTextBox txtAddress;
        private System.Windows.Forms.RichTextBox txtPhone;
        private System.Windows.Forms.RichTextBox txtYan;
        private System.Windows.Forms.PictureBox link2;
        private System.Windows.Forms.PictureBox picIsShow;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnAgree;
        private System.Windows.Forms.Button btnNoAgree;
        private System.Windows.Forms.PictureBox picText;
        private System.Windows.Forms.LinkLabel link3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Panel panelSuccess;
        private System.Windows.Forms.Panel panelFail;
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
        private System.Windows.Forms.Panel panelFailTwo;
        private System.Windows.Forms.Panel panelSuccTwo;
        private System.Windows.Forms.Panel panelWaittwo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panelAll;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panelConnectWait;
        private System.Windows.Forms.Panel panelConnectWaitTwo;
        private System.Windows.Forms.Label labelconnect;
    }
}