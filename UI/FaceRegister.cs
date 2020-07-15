using AForge.Video;
using AForge.Video.DirectShow;
using Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using WebServer;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace UI
{
    public partial class FaceRegister : Form
    {

        public delegate void UpdateText();

        public String yPhone = "";//接受手机验证码的号码
        public String yCode = "";//验证码
        public String Address = "";//家庭地址
        public String SNation = "";//民族

        public int isStart = 1;
        public int IsAgree = 1;

        public static string SName = ""; //完整姓名
        public static string Sidnum = "";//完整身份证信息


        public static int staus = 1;//timer 状态 0：启用计时器  1：关闭计时器

        public int IsGetAndrid = 0;

        public string errorMessage;

        //判断是否超过三次注册失败
        public string FirstRegi = "";
        public string SecondRegi = "";
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FaceRegister));

        public int ShibaiDao = 0;
        public int ChengGong = 0;
        AutoSizeFormClass asc = new AutoSizeFormClass();
        public FaceRegister()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams { get { CreateParams cp = base.CreateParams; cp.ExStyle |= 0x02000000; return cp; } }
        #region 获取验证码

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                //WebReference.WSFaces wsf = new WebReference.WSFaces();//我们的接口服务
                //Paneljps.Visible = false;
                Test.WSFaces wsf = new Test.WSFaces();
                //WebFace.WSFaces wsf = new WebFace.WSFaces();
                yPhone = txtPhone.Text.Trim();
                //Regex rx = new Regex(@"((^13[0-9]{1}[0-9]{8}|^15[0-9]{1}[0-9]{8}|^14[0-9]{1}[0-9]{8}|^16[0-9]{1}[0-9]{8}|^17[0-9]{1}[0-9]{8}|^18[0-9]{1}[0-9]{8}|^19[0-9]{1}[0-9]{8})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)");
                if (!Phone(txtPhone.Text.Trim()))
                {
                    MessageBox.Show("手机号码格式有误", "温馨提示", MessageBoxButtons.OK);
                    return;
                }
                yCode = wsf.VerificationCode(txtPhone.Text.Trim());//验证码
                JObject obj = JObject.Parse(yCode);
                yCode = obj["string"]["#text"].ToString();
                link2.Enabled = false;
                link3.Text = "30 秒后重试";
                link2.Visible = false;
                link3.Visible = true;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Logging.LogFile(s);
            }


            #region 倒计时事件
            //timer1.Start();
            #endregion
        }
        #endregion

        private void FaceRegister_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            //起始同意
            btnAgree.Visible = true;
            btnNoAgree.Visible = false;
            //关闭等待
            panelWait.Visible = false;
            
            //在窗体加载时隐藏lbl1标签
            link3.Visible = false;
            //成功和失败的界面隐藏
            panelFail.Visible = false;
            panelSuccess.Visible = false;
            txtZhuCeSuccess.Visible = false;

            staus = 0;
            
            //覆盖同意协议和注册按钮
            //panelCang.Visible = false;
            timer1.Start();
            Task t1 = new Task(() =>
            {
                ConnectAndroid();
            });
            //启动Task
            t1.Start();
        }

        //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{

        //}



        #region 刷身份证所用到的基类
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct IDCardData
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string Name; //姓名   
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
            public string Sex;   //性别
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
            public string Nation; //名族
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
            public string Born; //出生日期
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 72)]
            public string Address; //住址
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 38)]
            public string IDCardNo; //身份证号
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string GrantDept; //发证机关
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
            public string UserLifeBegin; // 有效开始日期
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
            public string UserLifeEnd;  // 有效截止日期
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 38)]
            public string reserved; // 保留
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
            public string PhotoFileName; // 照片路径
        }
        /************************端口类API *************************/
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_GetCOMBaud", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetCOMBaud(int iPort, ref uint puiBaudRate);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetCOMBaud", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetCOMBaud(int iPort, uint uiCurrBaud, uint uiSetBaud);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_OpenPort", CharSet = CharSet.Ansi)]
        public static extern int Syn_OpenPort(int iPort);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ClosePort", CharSet = CharSet.Ansi)]
        public static extern int Syn_ClosePort(int iPort);
        /**************************SAM类函数 **************************/
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetMaxRFByte", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetMaxRFByte(int iPort, byte ucByte, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ResetSAM", CharSet = CharSet.Ansi)]
        public static extern int Syn_ResetSAM(int iPort, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_GetSAMStatus", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetSAMStatus(int iPort, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_GetSAMID", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetSAMID(int iPort, ref byte pucSAMID, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_GetSAMIDToStr", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetSAMIDToStr(int iPort, ref byte pcSAMID, int iIfOpen);
        /*************************身份证卡类函数 ***************************/
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_StartFindIDCard", CharSet = CharSet.Ansi)]
        public static extern int Syn_StartFindIDCard(int iPort, ref byte pucIIN, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SelectIDCard", CharSet = CharSet.Ansi)]
        public static extern int Syn_SelectIDCard(int iPort, ref byte pucSN, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadBaseMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadBaseMsg(int iPort, ref byte pucCHMsg, ref uint puiCHMsgLen, ref byte pucPHMsg, ref uint puiPHMsgLen, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadBaseMsgToFile", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadBaseMsgToFile(int iPort, ref byte pcCHMsgFileName, ref uint puiCHMsgFileLen, ref byte pcPHMsgFileName, ref uint puiPHMsgFileLen, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadBaseFPMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadBaseFPMsg(int iPort, ref byte pucCHMsg, ref uint puiCHMsgLen, ref byte pucPHMsg, ref uint puiPHMsgLen, ref byte pucFPMsg, ref uint puiFPMsgLen, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadBaseFPMsgToFile", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadBaseFPMsgToFile(int iPort, ref byte pcCHMsgFileName, ref uint puiCHMsgFileLen, ref byte pcPHMsgFileName, ref uint puiPHMsgFileLen, ref byte pcFPMsgFileName, ref uint puiFPMsgFileLen, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadNewAppMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadNewAppMsg(int iPort, ref byte pucAppMsg, ref uint puiAppMsgLen, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_GetBmp", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetBmp(int iPort, ref byte Wlt_File);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadMsg(int iPortID, int iIfOpen, ref IDCardData pIDCardData);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadFPMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadFPMsg(int iPortID, int iIfOpen, ref IDCardData pIDCardData, ref byte cFPhotoname);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_FindReader", CharSet = CharSet.Ansi)]
        public static extern int Syn_FindReader();
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_FindUSBReader", CharSet = CharSet.Ansi)]
        public static extern int Syn_FindUSBReader();
        /***********************设置附加功能函数 ************************/
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetPhotoPath", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetPhotoPath(int iOption, ref byte cPhotoPath);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetPhotoType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetPhotoType(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetPhotoName", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetPhotoName(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetSexType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetSexType(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetNationType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetNationType(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetBornType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetBornType(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetUserLifeBType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetUserLifeBType(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetUserLifeEType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetUserLifeEType(int iType, int iOption);

        int m_iPort;

        #endregion

        #region 点击屏幕区域隐藏软键盘
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Paneljps.Visible = false;
        }
        #endregion
        #region 身份证号脱敏
        public String replaceStr(String param)
        {
            int len = param.Length;
            if (len < 9)
            {
                return param;
            }
            return Regex.Replace(param, "(.{" + (len < 12 ? 3 : 6) + "})(.*)(.{4})", "$1" + "****" + "$3");

        }
        #endregion

        #region 软键盘手动输入数字


        TextBox tmpTextBox = null;//定义全局变量储存光标所在的textbox
        private void button11_Click(object sender, EventArgs e)
        {
            if (tmpTextBox == null)
            {
                return;
            }
            //button1.TabIndex

            Button but = (Button)sender;


            switch (but.TabIndex.ToString())
            {
                case "38":
                    tmpTextBox.Text += "0";
                    break;
                case "29":
                    tmpTextBox.Text += "1";
                    break;
                case "30":
                    tmpTextBox.Text += "2";
                    break;
                case "31":
                    tmpTextBox.Text += "3";
                    break;
                case "32":
                    tmpTextBox.Text += "4";
                    break;
                case "33":
                    tmpTextBox.Text += "5";
                    break;
                case "34":
                    tmpTextBox.Text += "6";
                    break;
                case "35":
                    tmpTextBox.Text += "7";
                    break;
                case "36":
                    tmpTextBox.Text += "8";
                    break;
                case "37":
                    tmpTextBox.Text += "9";
                    break;
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (tmpTextBox.Text.Length > 1)
            {
                string numm = tmpTextBox.Text.Trim();
                tmpTextBox.Text = numm.Substring(0, numm.Length - 1);
            }
            else
            {
                tmpTextBox.Text = "";
            }
        }
        #endregion
        #region  控制软键盘的显示和隐藏
        private void btnOk_Click(object sender, EventArgs e)
        {
            //Paneljps.Visible = false;
        }

        private void txtPhone_Click(object sender, EventArgs e)
        {
            //Paneljps.Visible = true;
        }


        private void txtYan_Click(object sender, EventArgs e)
        {

           // Paneljps.Visible = true;
        }
        #endregion


        #region 验证码输入框调用软键盘

        #endregion
        private void txtYan_Enter(object sender, EventArgs e)
        {
            if (this.txtYan.Text == "请输入验证码")
            {
                this.txtYan.Text = "";
            }

            tmpTextBox = (TextBox)sender;
        }
        #region 获取验证码倒计时

        int sucSecond = 6;
        int failSecond =6;
        private void timer1_Tick(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(ReadIdcardInfo, null);

            //if (client == null)
            //{
                
            //}
            if (link3.Text != "获取验证码" && int.Parse(link3.Text.Substring(0, link3.Text.Length - 5)) > 0)
            {

                link3.Text = int.Parse(link3.Text.Substring(0, link3.Text.Length - 5)) - 1 + " 秒后重试";
            }
            else
            {
                link2.Enabled = true;
                link3.Visible = false;
                link2.Visible = true;
                //timer1.Enabled = false;
            }
            if (IsGetAndrid == 1)
            {
                ReceiveResultMessage("");
            }

            --failSecond;
            if (failSecond <= 0)
            {
                this.textBox1.Text = "";
                this.textBox1.Visible = false;
                textBox1.Enabled = false;
                panelFail.Visible = false;

            }
            else
            {
                this.textBox1.Text = errorMessage + failSecond.ToString();
            }

            --sucSecond;
            if (sucSecond <= 0)
            {
                this.txtSuccess.Text = "";
                panelSuccess.Visible = false;
                txtSuccess.Visible = false;
            }
            else
            {
                this.txtSuccess.Text = sucSecond.ToString();
            }

           
        }
        #endregion

        #region 手机号码验证
        public bool Phone(string phone)
        {
            Regex rx = new Regex(@"((^13[0-9]{1}[0-9]{8}|^15[0-9]{1}[0-9]{8}|^14[0-9]{1}[0-9]{8}|^16[0-9]{1}[0-9]{8}|^17[0-9]{1}[0-9]{8}|^18[0-9]{1}[0-9]{8}|^19[0-9]{1}[0-9]{8})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)");
            return rx.IsMatch(phone);
        }

        #endregion


        private void txtPhone_Enter(object sender, EventArgs e)
        {
            if (this.txtPhone.Text == "请输入手机号")
            {
                this.txtPhone.Text = "";
            }
            tmpTextBox = (TextBox)sender;
        }
        //private FilterInfoCollection videoDevices;
        public static Bitmap imgFace;

        #region 内存回收
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary> 
        /// 释放内存
        /// </summary> 
        public static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        #endregion

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                imgFace = (Bitmap)eventArgs.Frame.Clone();
                ClearMemory();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Logging.LogFile(s);
            }
        }
        byte[] photoImg =null;

        //打开摄像头
        private void picIsShow_Click(object sender, EventArgs e)
        {

            isStartFun();
            //等待中
           
            panelWait.Visible = true;
            panelWait.BackColor = Color.FromArgb(80,192,192,192);

            if (File.Exists(System.IO.Path.GetFullPath(".\\") + "temp.jpg"))
            {
                File.Delete(System.IO.Path.GetFullPath(".\\") + "temp.jpg");
            }

            SendMessage("7", "1");

         
            IsGetAndrid = 1;
        }



        #region 通过timer4实现每隔规定时间自动读取身份证信息

        //private void timer4_Tick(object sender, EventArgs e)
        //{
            
        //}
        public void ReadIdcardInfo(object s)
        {
            #region 读取身份证信息
            IDCardData CardMsg = new IDCardData();
            int nRet, nPort, iPhotoType;
            string stmp;
            byte[] cPath = new byte[255];
            byte[] pucIIN = new byte[4];
            byte[] pucSN = new byte[8];
            nPort = m_iPort;
            //if (pictureBox1.Image != null)
            //{
            //    pictureBox1.Image.Dispose();
            //    pictureBox1.Image = null;
            //}
            //Syn_SetPhotoPath(0,ref cPath[0]);	//设置照片路径	iOption 路径选项	0=C:	1=当前路径	2=指定路径
            //cPhotoPath	绝对路径,仅在iOption=2时有效
            iPhotoType = 0;
            Syn_SetPhotoType(0); //0 = bmp ,1 = jpg , 2 = base64 , 3 = WLT ,4 = 不生成
            Syn_SetPhotoName(2); // 生成照片文件名 0=tmp 1=姓名 2=身份证号 3=姓名_身份证号 

            Syn_SetSexType(1);  // 0=卡中存储的数据	1=解释之后的数据,男、女、未知
            Syn_SetNationType(1);// 0=卡中存储的数据	1=解释之后的数据 2=解释之后加"族"
            Syn_SetBornType(1);         // 0=YYYYMMDD,1=YYYY年MM月DD日,2=YYYY.MM.DD,3=YYYY-MM-DD,4=YYYY/MM/DD
            Syn_SetUserLifeBType(1);    // 0=YYYYMMDD,1=YYYY年MM月DD日,2=YYYY.MM.DD,3=YYYY-MM-DD,4=YYYY/MM/DD
            Syn_SetUserLifeEType(1, 1); // 0=YYYYMMDD(不转换),1=YYYY年MM月DD日,2=YYYY.MM.DD,3=YYYY-MM-DD,4=YYYY/MM/DD,
                                        // 0=长期 不转换,	1=长期转换为 有效期开始+50年

            if (Syn_OpenPort(nPort) == 0)
            {
                if (Syn_SetMaxRFByte(nPort, 80, 0) == 0)
                {
                    nRet = Syn_StartFindIDCard(nPort, ref pucIIN[0], 0);
                    nRet = Syn_SelectIDCard(nPort, ref pucSN[0], 0);
                    int i = Syn_SetPhotoType(4);//不生成图片
                    nRet = Syn_ReadMsg(nPort, 0, ref CardMsg);

                    if (nRet == 0)
                    {
                        Control.CheckForIllegalCrossThreadCalls = false;
                        
                        SName = CardMsg.Name.Trim(); //完整姓名
                        txtName.Text = SName.Substring(0, 1) + "*" + SName.Substring(SName.Length - 1, 1); //加密后的姓名
                        if (SName.Length == 2)
                        {
                            txtName.Text = SName.Substring(0, 1) + "*";
                        }
                        SNation = CardMsg.Nation.Trim();
                        Address = CardMsg.Address.Trim();
                        txtAddress.Text = Address;
                        Sidnum = CardMsg.IDCardNo.Trim();   //完整身份证信息
                        txtIDCard.Text = replaceStr(CardMsg.IDCardNo.Trim());//加密后的身份证信息
                        ClearMemory();

                    }
                    else
                    {
                        stmp = Convert.ToString(System.DateTime.Now) + "  读取身份证信息错误";
                    }
                }
            }
            #endregion
        }
        #endregion


        #region 注册按钮


        private void FaceRegister_MouseLeave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtAddress.Text) && !string.IsNullOrEmpty(this.txtName.Text) && !string.IsNullOrEmpty(this.txtIDCard.Text) && !string.IsNullOrEmpty(this.txtYan.Text) && !string.IsNullOrEmpty(this.txtPhone.Text))
            {
                if (this.txtIDCard.Text != "请输入身份证号" && this.txtName.Text != "请输入姓名" && this.txtPhone.Text != "请输入手机号" && this.txtAddress.Text != "请输入地址" && this.txtYan.Text != "请输入验证码" && photoImg!=null&&IsAgree==1)
                {
                    //实名注册刷脸就医按钮隐藏
                    btnNofinsh.Visible = false;

                    //panelCang.Visible = true;
                    //panelCang.BackColor = Color.White;
                    btnRegister.Visible = true;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //所有的信息填完之后注册按钮变为蓝色
            if (!string.IsNullOrEmpty(this.txtAddress.Text) && !string.IsNullOrEmpty(this.txtName.Text) && !string.IsNullOrEmpty(this.txtIDCard.Text) && !string.IsNullOrEmpty(this.txtYan.Text) && !string.IsNullOrEmpty(this.txtPhone.Text))
            {
                if (this.txtIDCard.Text != "请输入身份证号" && this.txtName.Text != "请输入姓名" && this.txtPhone.Text != "请输入手机号" && this.txtAddress.Text != "请输入地址" && this.txtYan.Text != "请输入验证码" && photoImg!=null&&IsAgree==1)
                {
                    //实名注册刷脸就医按钮隐藏
                    btnNofinsh.Visible = false;

                    //panelCang.Visible = true;
                    //panelCang.BackColor = Color.White;
                    btnRegister.Visible = true;
                    Register();
                }
                else
                {
                    btnRegister.Visible = false;
                }
            }
            else
            {
                btnRegister.Visible = false;
            }

        }

        private void Register()
        {
            failSecond = 6;
            sucSecond = 6;


            #region   检验是否正确
            if (String.IsNullOrEmpty(txtPhone.Text) || txtPhone.Text == "请输入手机号")
            {
                MessageBox.Show("请输入手机号");
                return;
            }
            if (String.IsNullOrEmpty(txtYan.Text) || txtPhone.Text == "请输入验证码")
            {
                MessageBox.Show("请输入验证码");
                return;
            }
            if (IsAgree == 0)
            {
                MessageBox.Show("请同意该协议！");
                return;
            }
            String Mge = "";
            #region 验证身份证是否合法

            Address = this.txtAddress.Text;
            Sidnum = this.txtIDCard.Text.IndexOf('*') > 0 ? Sidnum : this.txtIDCard.Text;
            SName = this.txtName.Text.IndexOf('*') > 0 ? SName : this.txtName.Text;
            string cid = CheckCidInfo18(Sidnum);
            if (cid != "")
            {
                Mge = cid;
                MessageBox.Show(Mge);
                return;
            }
            #region 验证手机号码是否合法
            if (!Phone(txtPhone.Text.Trim()))
            {
                Mge = "手机号码格式错误";
                MessageBox.Show(Mge);
                return;
            }
            #endregion
            #region 判断手机号与验证码是否合法
            if (!String.IsNullOrEmpty(txtPhone.Text))
            {
                if (string.IsNullOrEmpty(yPhone))
                {
                    Mge = "请您获取验证码";
                    MessageBox.Show("请您获取验证码");
                    return;
                }
                if (txtPhone.Text != yPhone)//如果接收验证码的手机与文本框的手机不一致
                {
                    MessageBox.Show("手机号码不一致");
                    return;
                }
                if (String.IsNullOrEmpty(txtYan.Text))//如果验证码为空
                {
                    MessageBox.Show("请输入验证码");
                    return;
                }
                if (txtYan.Text.Trim() != yCode)//与发送的验证码不一致
                {
                    MessageBox.Show("验证码错误");
                    return;
                }
            }
            #endregion

            #endregion




            #region 图片
            if (photoImg == null)
            {
                MessageBox.Show("请上传图片！");
                return;
            }
            #endregion

            Test.WSFaces wsf = new Test.WSFaces();
            //WebFace.WSFaces wsf = new WebFace.WSFaces();

            #region 调用注册接口（公安）验证
            string result = wsf.AuthenPliceFace(Sidnum, SName, this.txtPhone.Text, SNation, Address, photoImg);

            JObject obj = JObject.Parse(result);
            //结果码
            string strs = obj["code"].ToString();
            if (strs == "1")
            {
                panelSuccess.Visible = true;
                panelSuccess.BackColor = Color.FromArgb(80, 192, 192, 192);
                txtSuccess.Visible = true;
                SendMessage("8", "success");
            }
            else
            {
                if (string.IsNullOrEmpty(FirstRegi)&& string.IsNullOrEmpty(SecondRegi))
                {
                    FirstRegi = Sidnum;
                }
                else if (!string.IsNullOrEmpty(FirstRegi) && string.IsNullOrEmpty(SecondRegi))
                {
                    SecondRegi = Sidnum;
                }
                else if (FirstRegi == SecondRegi && SecondRegi != Sidnum)
                {
                    FirstRegi = SecondRegi;
                    SecondRegi = Sidnum;
                }
                else if (FirstRegi != SecondRegi && SecondRegi != Sidnum)
                {
                    FirstRegi = SecondRegi;
                    SecondRegi = Sidnum;
                }
                else if (FirstRegi != SecondRegi && SecondRegi == Sidnum)
                {
                    FirstRegi = SecondRegi;
                    SecondRegi = Sidnum;
                }
                else if (!string.IsNullOrEmpty(FirstRegi) && !string.IsNullOrEmpty(SecondRegi)&&FirstRegi ==SecondRegi&& SecondRegi == Sidnum)
                {
                    ReturnUpLevel();
                    FirstRegi = "";
                    SecondRegi = "";
                    SendMessage("6","1");
                }
                else
                {

                }
                errorMessage = obj["message"].ToString();
                panelFail.Visible = true;
                panelFail.BackColor = Color.FromArgb(80, 192, 192, 192);
                textBox1.Visible = true;
                textBox1.Enabled = true;
                SendMessage("8", errorMessage);

            }
            isStart = 0;
            
            #endregion



            #endregion

            //photoImg = null;
        }
        #endregion

        #region 身份证格式验证,以及15.18位互转方法
        /// <summary>
        /// 验证18位身份证格式
        /// </summary>
        /// <param name="cid"></param>
        /// <returns>返回字符串,出错信息</returns>
        public string CheckCidInfo18(string cid)
        {
            string[] aCity = new string[] { null, null, null, null, null, null, null, null, null, null, null, "北京", "天津", "河北", "山西", "内蒙古", null, null, null, null, null, "辽宁", "吉林", "黑龙江", null, null, null, null, null, null, null, "上海", "江苏", "浙江", "安微", "福建", "江西", "山东", null, null, null, "河南", "湖北", "湖南", "广东", "广西", "海南", null, null, null, "重庆", "四川", "贵州", "云南", "西藏", null, null, null, null, null, null, "陕西", "甘肃", "青海", "宁夏", "新疆", null, null, null, null, null, "台湾", null, null, null, null, null, null, null, null, null, "香港", "澳门", null, null, null, null, null, null, null, null, "国外" };
            double iSum = 0;
            System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"^\d{17}(\d|X|x)$");
            System.Text.RegularExpressions.Match mc = rg.Match(cid);
            if (!mc.Success)
            {
                return "- 您的身份证号码格式有误!";
            }
            cid = cid.ToLower();
            cid = cid.Replace("x", "a");
            if (aCity[int.Parse(cid.Substring(0, 2))] == null)
            {
                return "- 您的身份证号码格式有误!";//非法地区
            }
            try
            {
                DateTime.Parse(cid.Substring(6, 4) + "-" + cid.Substring(10, 2) + "-" + cid.Substring(12, 2));
            }
            catch
            {
                return "- 您的身份证号码格式有误!";//非法生日
            }
            for (int i = 17; i >= 0; i--)
            {
                iSum += (System.Math.Pow(2, i) % 11) * int.Parse(cid[17 - i].ToString(), System.Globalization.NumberStyles.HexNumber);
            }
            if (iSum % 11 != 1)
                return ("- 您的身份证号码格式有误!");//非法证号

            return "";

        }

        /// <summary>
        /// 验证15位身份证格式
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public string CheckCidInfo15(string cid)
        {
            string[] aCity = new string[] { null, null, null, null, null, null, null, null, null, null, null, "北京", "天津", "河北", "山西", "内蒙古", null, null, null, null, null, "辽宁", "吉林", "黑龙江", null, null, null, null, null, null, null, "上海", "江苏", "浙江", "安微", "福建", "江西", "山东", null, null, null, "河南", "湖北", "湖南", "广东", "广西", "海南", null, null, null, "重庆", "四川", "贵州", "云南", "西藏", null, null, null, null, null, null, "陕西", "甘肃", "青海", "宁夏", "新疆", null, null, null, null, null, "台湾", null, null, null, null, null, null, null, null, null, "香港", "澳门", null, null, null, null, null, null, null, null, "国外" };

            System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"^\d{15}$");
            System.Text.RegularExpressions.Match mc = rg.Match(cid);
            if (!mc.Success)
            {
                return "- 您的身份证号码格式有误!";
            }
            cid = cid.ToLower();
            cid = cid.Replace("x", "a");
            if (int.Parse(cid.Substring(0, 2)) > aCity.Length)
            {
                return "- 您的身份证号码格式有误!";//非法地区
            }
            if (aCity[int.Parse(cid.Substring(0, 2))] == null)
            {
                return "- 您的身份证号码格式有误!";//非法地区
            }
            try
            {
                DateTime.Parse(cid.Substring(6, 2) + "-" + cid.Substring(8, 2) + "-" + cid.Substring(10, 2));
            }
            catch
            {
                return "- 您的身份证号码格式有误!";//非法生日
            }
            return "";
        }

        /// <summary>
        /// 15位转18位身份证号
        /// </summary>
        /// <param name="perIDSrc"></param>
        /// <returns></returns>
        public string per15To18(string perIDSrc)
        {
            int iS = 0;
            //加权因子常数
            int[] iW = new int[] { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
            //校验码常数
            string LastCode = "10X98765432";
            //新身份证号
            string perIDNew;

            perIDNew = perIDSrc.Substring(0, 6);
            //填在第6位及第7位上填上‘1’，‘9’两个数字
            perIDNew += "19";
            perIDNew += perIDSrc.Substring(6, 9);
            //进行加权求和
            for (int i = 0; i < 17; i++)
            {
                iS += int.Parse(perIDNew.Substring(i, 1)) * iW[i];
            }

            //取模运算，得到模值
            int iY = iS % 11;
            //从LastCode中取得以模为索引号的值，加到身份证的最后一位，即为新身份证号。
            perIDNew += LastCode.Substring(iY, 1);

            return perIDNew;
        }

        /// <summary>
        /// 18位转15位身份证号
        /// </summary>
        /// <param name="perIDSrc"></param>
        /// <returns></returns>
        public string per18To15(string perIDSrc)
        {
            //前6位
            string str1 = perIDSrc.Substring(0, 6);
            //后9位
            string str2 = perIDSrc.Substring(8, 9);
            //新字符串
            string perIDNew = str1 + str2;
            return perIDNew;

        }
        #endregion



        #region 文本框内容清空
        public void Empty()
        {
            txtIDCard.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtYan.Text = "";
            txtAddress.Text = "";
            yPhone = "";
            yCode = "";
            link2.Enabled = true;
        }
        #endregion


   


        
        private void FaceRegister_Shown(object sender, EventArgs e)
        {
            #region 寻找身份证读卡器
            string stmp;
            int i, nRet;
            uint[] iBaud = new uint[1];
            i = Syn_FindReader();
            m_iPort = i;
            if (i > 0)
            {
                if (i > 1000)
                {
                    stmp = Convert.ToString(i);
                    stmp = Convert.ToString(System.DateTime.Now) + "  读卡器连接在USB " + stmp;
                }
                else
                {
                    System.Threading.Thread.Sleep(200);
                    nRet = Syn_GetCOMBaud(i, ref iBaud[0]);
                    stmp = Convert.ToString(i);
                    stmp = Convert.ToString(System.DateTime.Now) + "  读卡器连接在COM " + stmp + ";当前波特率为 " + Convert.ToString(iBaud[0]);
                }
            }
            else
            {
                stmp = Convert.ToString(System.DateTime.Now) + "  没有找到读卡器";
                MessageBox.Show(stmp);
            }
            #endregion
        }
        #region 明壹协议的同意



        private void btnNoAgree_Click(object sender, EventArgs e)
        {

            //同意协议
            IsAgree = 1;
            //btnAgree.BringToFront();

            btnNoAgree.Visible = false;
            btnAgree.Visible = true;
            SendMessage("9", IsAgree.ToString());
        }

        private void btnAgree_Click(object sender, EventArgs e)
        {
            //不同意协议
            IsAgree = 0;
            //btnNoAgree.BringToFront();
            btnAgree.Visible = false;
            btnNoAgree.Visible = true;

            SendMessage("9", IsAgree.ToString());
        }
        #endregion


        private void link3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            link3.Visible = false;
            link2.Visible = true;
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }


        

        #region 设置若用户30秒内无任何操作则显示MDI遮罩层

        int x, y;
        DateTime start;
        bool ff = true;

        private void FaceRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }

        /// <summary>
        /// 成功注册后倒计时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //int sucSecond = 6;
        //private void timerSuccess_Tick(object sender, EventArgs e)
        //{

            //--sucSecond;
            //if (sucSecond ==0)
            //{
            //    this.txtSuccess.Text = "";
                
            //    timerSuccess.Enabled = false;
            //    panelSuccess.Visible = false;
            //    txtSuccess.Visible = false;
            //}
            //else
            //{
            //    this.txtSuccess.Text = sucSecond.ToString();
            //}
            
        //}

        /// <summary>
        /// 注册失败倒计时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //int failSecond =6;
        //private void timerfail_Tick(object sender, EventArgs e)
        //{
            //--failSecond;
            //if (failSecond == 0)
            //{
            //    this.textBox1.Text = "";
            //    this.textBox1.Visible = false;
            //    textBox1.Enabled = false;
            //    panelFail.Visible = false;
            //    timerfail.Stop();
               
            //}
            //else
            //{
            //    this.textBox1.Text = errorMessage + failSecond.ToString();
            //}
           

        //}


        //private void timer3_Tick(object sender, EventArgs e)
        //{
        //    int x1 = Control.MousePosition.X;
        //    int y1 = Control.MousePosition.Y;

        //    if ((x == x1) && (y == y1) && ff)
        //    {
        //        start = DateTime.Now;
        //        ff = false;
        //    }
        //    if (x != x1 || y != y1)
        //    {
        //        x = x1;
        //        y = y1;
        //        start = DateTime.Now;
        //        ff = true;
        //    }
        //    TimeSpan ts = DateTime.Now.Subtract(start);

        //    if (ts.Seconds == 30)
        //    {
        //        timer3.Stop();
        //        timer4.Stop();
        //        staus = 1;
        //    }
        //}
        #endregion

        /// <summary>
        /// 返回上一级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkReturns_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ReturnUpLevel();
        }



        #region 非空判断

        private void txtName_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text == "请输入姓名")
            {
                this.txtName.Text = "";
            }
        }

        private void txtIDCard_Click(object sender, EventArgs e)
        {
            if (this.txtIDCard.Text == "请输入身份证号")
            {
                this.txtIDCard.Text = "";
            }
        }

        private void txtAddress_Click(object sender, EventArgs e)
        {
            if (this.txtAddress.Text == "请输入地址")
            {
                this.txtAddress.Text = "";
            }
        }


        private void ReturnResult()
        {
            if (string.IsNullOrEmpty(this.txtAddress.Text))
            {
                this.txtAddress.Text = "请输入地址";
            }
            if (string.IsNullOrEmpty(this.txtIDCard.Text))
            {
                this.txtIDCard.Text = "请输入身份证号";
            }
            if (string.IsNullOrEmpty(this.txtName.Text))
            {
                this.txtName.Text = "请输入姓名";
            }
            if (string.IsNullOrEmpty(this.txtPhone.Text))
            {
                this.txtName.Text = "请输入手机号";
            }
            if (string.IsNullOrEmpty(this.txtYan.Text))
            {
                this.txtName.Text = "请输入验证码";
            }
        }
        
        private void txtName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtName.Text))
            {
                this.txtName.Text = "请输入姓名";
            }
        }

        private void txtIDCard_Enter(object sender, EventArgs e)
        {
            if (this.txtIDCard.Text == "请输入身份证号")
            {
                this.txtIDCard.Text = "";
            }

        }

        private void txtIDCard_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtIDCard.Text))
            {
                this.txtIDCard.Text = "请输入身份证号";
            }
        }

        private void txtAddress_Enter(object sender, EventArgs e)
        {
            if (this.txtAddress.Text == "请输入地址")
            {
                this.txtAddress.Text = "";
            }

        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtAddress.Text))
            {
                this.txtAddress.Text = "请输入地址";
            }
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtPhone.Text))
            {
                this.txtPhone.Text = "请输入手机号";
            }
        }
        
        


        private void txtYan_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtYan.Text))
            {
                this.txtYan.Text = "请输入验证码";
            }
        }


        #endregion



        #region 传送数据到安卓

        //socket连接
        Socket client = null;
        private void ConnectAndroid()
        {
            Process p = new Process(); //实例一个Process类，启动一个独立进程
            p.StartInfo.FileName = "cmd.exe"; //设定程序名
            p.StartInfo.UseShellExecute = false; //关闭Shell的使用
            p.StartInfo.RedirectStandardInput = true; //重定向标准输入
            p.StartInfo.RedirectStandardOutput = true; //重定向标准输出
            p.StartInfo.RedirectStandardError = true; //重定向错误输出
            p.StartInfo.CreateNoWindow = true; // 设置不显示窗口
            p.StartInfo.ErrorDialog = false;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();

            p.StandardInput.WriteLine(@"adb shell am broadcast -a NotifyServiceStop");
            Thread.Sleep(2000);
            p.StandardInput.WriteLine(@"adb forward tcp:60075 tcp:60076");
            Thread.Sleep(2000);
            p.StandardInput.WriteLine(@"adb shell am broadcast -a NotifyServiceStart");
            Thread.Sleep(2000);

            IPAddress myIP = IPAddress.Parse("127.0.0.1");
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint EPhost = new IPEndPoint(myIP, int.Parse("60075"));
            client.Connect(EPhost);
            SendMessage("6", "1");
            Thread.Sleep(500);
            p.Close();
        }
        
        class SendData
        {
            public string type { get; set; }
            public string data { get; set; }
        }
        #region 传输文本框内容

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            isStartFun();
            SendMessage("1", this.txtName.Text);
        }

        private void txtIDCard_TextChanged(object sender, EventArgs e)
        {
            isStartFun();
            SendMessage("2", this.txtIDCard.Text);
        }
        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            isStartFun();
            SendMessage("3", this.txtAddress.Text);
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            isStartFun();
            SendMessage("4", this.txtPhone.Text);
        }

        private void txtYan_TextChanged(object sender, EventArgs e)
        {
            isStartFun();
            SendMessage("5", this.txtYan.Text);
        }

        #endregion

        /// <summary>
        /// 向安卓端发送消息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="content"></param>
        private void SendMessage(string type, string content)
        {
            if (client == null)
            {
                ConnectAndroid();
            }
            SendData model = new SendData() { type = type, data = content };
            byte[] bytedata = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model));
            string str = Convert.ToBase64String(bytedata);
            byte[] data = Encoding.ASCII.GetBytes(str);
            
            client.Send(data);
        }


        private void fun1()
        {
            byte[] aaaaa = Encoding.ASCII.GetBytes("TAKEPHOTO");  //通信时实际发送的是字节数组，所以要将发送消息转换字节
            client.Send(aaaaa);

            Thread.Sleep(1000);

            byte[] receive1 = new byte[2048 * 2000 * 2];
            //int length1 = ClientSocket.Receive(receive1);//length 接收字节数组长度
            string dataa = string.Empty; Thread.Sleep(2000);
            //string sdata = Encoding.ASCII.GetString(receive1, 0, length1).Replace("\n", "").Replace("\0", "").Replace("\t", "").Replace("\r", "");
            //LogFile(sdata);

            int receiveLength = 0;
            int index = 0;
            while (client.Available > 0)
            {
                Thread.Sleep(500);                              //参数 数据缓存区  起始位置  数据长度  值的按位组合
                receiveLength += client.Receive(receive1, index, client.ReceiveBufferSize, SocketFlags.None);
                index += receiveLength;

            }
            MessageBox.Show(index.ToString());
            string sdata = Encoding.ASCII.GetString(receive1, 0, index).Replace("\n", "").Replace("\0", "").Replace("\t", "").Replace("\r", "");
        }

        private void ReceiveResultMessage(string data)
        {

            if (client == null)
            {
                ConnectAndroid();
            }
            byte[] arrImgss = new byte[1024 * 700];
            int receiveLength = 0;
            int index = 0;
            string sdata = "";
            try
            {
                while (client.Available > 0)
                {
                    //参数 数据缓存区  起始位置  数据长度  值的按位组合
                    receiveLength += client.Receive(arrImgss, index, client.ReceiveBufferSize, SocketFlags.None);
                    index += receiveLength;
                }
                sdata = Encoding.ASCII.GetString(arrImgss, 0, index).Replace("\n", "").Replace("\0", "").Replace("\t", "").Replace("\r", "");
                byte[] outputb = Convert.FromBase64String(sdata);
                sdata = Encoding.Default.GetString(outputb);
                if (!string.IsNullOrEmpty(sdata))
                {
                    ReceiveData result = JsonConvert.DeserializeObject<ReceiveData>(sdata);
                    if (result.data=="ok")
                    {

                        Process p = new Process(); //实例一个Process类，启动一个独立进程
                        p.StartInfo.FileName = "cmd.exe"; //设定程序名
                        p.StartInfo.UseShellExecute = false; //关闭Shell的使用
                        p.StartInfo.RedirectStandardInput = true; //重定向标准输入
                        p.StartInfo.RedirectStandardOutput = true; //重定向标准输出
                        p.StartInfo.RedirectStandardError = true; //重定向错误输出
                        p.StartInfo.CreateNoWindow = true; // 设置不显示窗口
                        p.StartInfo.ErrorDialog = false;
                        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        p.Start();

                        string ssdsd = System.IO.Path.GetFullPath(".\\") + "temp.jpg";

                        p.StandardInput.WriteLine(@" adb pull /storage/emulated/0/b.jpg " + ssdsd);


                        Thread.Sleep(2000);

                        ReceiveMessage("");
                    }
                }
            }
            catch (Exception ex)
            {
                SendMessage("7", "1");
                throw;
            }


        }

        /// <summary>
        /// 接收安卓服务端消息
        /// </summary>
        /// <param name="data"></param>
        private void ReceiveMessage(string data)
        {
            FileStream jpgStream = new FileStream(System.IO.Path.GetFullPath(".\\") + "temp.jpg", FileMode.Open);
            byte[] bytes = StreamToBytes(jpgStream);

            picIsShow.BackgroundImage = Image.FromStream(jpgStream);
            jpgStream.Close();
            jpgStream.Dispose();
            System.GC.Collect();//垃圾回收
                                //获取到图片信息后
            IsGetAndrid = 0;
            //线程之间跨平台操作
            Control.CheckForIllegalCrossThreadCalls = false;
            //退出等待
            panelWait.Visible = false;
            #region 老版本获取图片


            //byte[] arrImgss = new byte[1024 * 700];
            //int receiveLength = 0;
            //int index = 0;
            //string sdata = "";
            //try
            //{
            //    while (client.Available > 0)
            //    {
            //        //参数 数据缓存区  起始位置  数据长度  值的按位组合
            //        receiveLength += client.Receive(arrImgss, index, client.ReceiveBufferSize, SocketFlags.None);
            //        index += receiveLength;
            //    }
            //    sdata = Encoding.ASCII.GetString(arrImgss, 0, index).Replace("\n", "").Replace("\0", "").Replace("\t", "").Replace("\r", "");
            //}
            //catch (Exception ex)
            //{
            //    SendMessage("7", "1");
            //    throw;
            //}
            //photoImg = Convert.FromBase64String(sdata);

            //if (receiveLength != 0)
            //{
            //    try
            //    {
            //        //读入MemoryStream对象
            //        MemoryStream memoryStream = new MemoryStream(photoImg);
            //        //转成图片
            //        Image image = Image.FromStream(memoryStream);

            //        picIsShow.BackgroundImage = image;

            //        memoryStream.Dispose();//释放占用资源
            //        memoryStream.Close();
            //        System.GC.Collect();//垃圾回收
            //                            //获取到图片信息后
            //        IsGetAndrid = 0;
            //        //线程之间跨平台操作
            //        Control.CheckForIllegalCrossThreadCalls = false;
            //        //退出等待
            //        panelWait.Visible = false;
            //    }
            //    catch (Exception ex)
            //    {
            //        SendMessage("7", "1");
            //        throw;
            //    }

            //}
            #endregion

        }

        #region 文件转二进制流
        public byte[] StreamToBytes(Stream stream)
        {

            byte[] bytes = new byte[stream.Length];

            stream.Read(bytes, 0, bytes.Length);

            // 设置当前流的位置为流的开始 

            stream.Seek(0, SeekOrigin.Begin);

            return bytes;

        }
        #endregion

        public void isStartFun()
        {
            if (isStart == 0)
            {
                isStart = 1;
                SendMessage("6", "1");
            }
        }

        class ReceiveData
        {
            public string result { get; set; }
            public string data { get; set; }
        }
        

        #endregion

        #region 返回上一级
        private void ReturnUpLevel()
        {
            //ReveiveAndroid();
            //SendToAndroidData();

            //实名注册刷脸就医按钮隐藏
            btnNofinsh.Visible = true;

            photoImg = null;
            //panelCang.Visible = false;
            
            SendMessage("11", "1");
            failSecond =6;
            sucSecond = 6;
            this.txtName.Text = "请输入姓名";
            this.txtPhone.Text = "请输入手机号";
            this.txtIDCard.Text = "请输入身份证号";
            this.txtAddress.Text = "请输入地址";
            this.txtYan.Text = "请输入验证码";
            Sidnum = ""; SName = ""; yPhone = ""; SNation = ""; Address = "";
            isStart = 0;
            picIsShow.Visible = true;
          
            picIsShow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picIsShow.BackgroundImage")));
            //关闭摄像头
            //videPlayer.SignalToStop();
            //videPlayer.Stop();

            //不同意协议
            btnNoAgree.Visible = false;
            btnAgree.Visible = true;
            IsAgree = 1;
            //btnNoAgree.BringToFront();
        }

        private void panelAll_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
        #endregion

        #region 自适应大小
        class AutoSizeFormClass
        {
            //(1).声明结构,只记录窗体和其控件的初始位置和大小。  
            public struct controlRect
            {
                public int Left;
                public int Top;
                public int Width;
                public int Height;
            }
            //(2).声明 1个对象  
            //注意这里不能使用控件列表记录 List<Control> nCtrl;，因为控件的关联性，记录的始终是当前的大小。  
            public List<controlRect> oldCtrl;
            //int ctrl_first = 0;  
            //(3). 创建两个函数  
            //(3.1)记录窗体和其控件的初始位置和大小,  
            public void controllInitializeSize(Form mForm)
            {
                // if (ctrl_first == 0)  
                {
                    //  ctrl_first = 1;  
                    oldCtrl = new List<controlRect>();
                    controlRect cR;
                    cR.Left = mForm.Left; cR.Top = mForm.Top; cR.Width = mForm.Width; cR.Height = mForm.Height;
                    oldCtrl.Add(cR);
                    foreach (Control c in mForm.Controls)
                    {
                        controlRect objCtrl;
                        objCtrl.Left = c.Left; objCtrl.Top = c.Top; objCtrl.Width = c.Width; objCtrl.Height = c.Height;
                        oldCtrl.Add(objCtrl);
                    }
                }
                // this.WindowState = (System.Windows.Forms.FormWindowState)(2);//记录完控件的初始位置和大小后，再最大化  
                //0 - Normalize , 1 - Minimize,2- Maximize  
            }
            //(3.2)控件自适应大小,  
            public void controlAutoSize(Form mForm)
            {
                //int wLeft0 = oldCtrl[0].Left; ;//窗体最初的位置  
                //int wTop0 = oldCtrl[0].Top;  
                ////int wLeft1 = this.Left;//窗体当前的位置  
                //int wTop1 = this.Top;  
                float wScale = (float)mForm.Width / (float)oldCtrl[0].Width;//新旧窗体之间的比例，与最早的旧窗体  
                float hScale = (float)mForm.Height / (float)oldCtrl[0].Height;//.Height;  
                int ctrLeft0, ctrTop0, ctrWidth0, ctrHeight0;
                int ctrlNo = 1;//第1个是窗体自身的 Left,Top,Width,Height，所以窗体控件从ctrlNo=1开始  
                foreach (Control c in mForm.Controls)
                {
                    ctrLeft0 = oldCtrl[ctrlNo].Left;
                    ctrTop0 = oldCtrl[ctrlNo].Top;
                    ctrWidth0 = oldCtrl[ctrlNo].Width;
                    ctrHeight0 = oldCtrl[ctrlNo].Height;
                    //c.Left = (int)((ctrLeft0 - wLeft0) * wScale) + wLeft1;//新旧控件之间的线性比例  
                    //c.Top = (int)((ctrTop0 - wTop0) * h) + wTop1;  
                    c.Left = (int)((ctrLeft0) * wScale);//新旧控件之间的线性比例。控件位置只相对于窗体，所以不能加 + wLeft1  
                    c.Top = (int)((ctrTop0) * hScale);//  
                    c.Width = (int)(ctrWidth0 * wScale);//只与最初的大小相关，所以不能与现在的宽度相乘 (int)(c.Width * w);  
                    c.Height = (int)(ctrHeight0 * hScale);//  
                    ctrlNo += 1;
                }
            }

        }
        #endregion

    }
}
