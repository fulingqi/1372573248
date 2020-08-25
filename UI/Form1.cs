using Baidu.Aip;
using Jayrock.Json.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using AForge.Video.DirectShow;
using AForge.Video;
using Newtonsoft.Json.Linq;
using System.Diagnostics;


namespace UI
{
    public partial class Form1 : Form
    {


        public delegate void UpdateText();
        byte[] photoImg = null;//人脸照片
        public String yPhone = "";//接受手机验证码的号码
        public String tPhone = "";//注册上面的手机号
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

        public int errorCount = 0;
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));

        public int ShibaiDao = 0;
        public int ChengGong = 0;

        /// <summary>
        /// 是否开始读卡**********
        /// </summary>
        public bool IsStartIDCard = true;

        public DateTime GetMessageStart; //获取验证码时间
        public DateTime GetMessageEnd; //使用验证码时间

        public DateTime GetImageStart;
        public DateTime GetImageEnd;
        
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            //错误信息提示
            this.panelMessage.Visible = false;

            //注册结果初始化
            panelSuccess.Visible = false;
            //注册成功后返回成功结果
            panelSuccess.BackColor = Color.FromArgb(80, 192, 192, 192);

            //明医隐私政策
            this.linkLabel1.ForeColor = ColorTranslator.FromHtml("#93b2ff");
            //明医实名刷脸注册
            this.labHead.BackColor= ColorTranslator.FromHtml("#5c8dff");
            this.labTime.BackColor = ColorTranslator.FromHtml("#5c8dff");
            this.labCountDown.BackColor = ColorTranslator.FromHtml("#5c8dff");
            //注册按钮隐藏
            this.btnRegister.Visible = false;
            this.btnRegister.Enabled = false;

            //panelSmallSuccess.BackColor= Color.FromArgb(80, 192, 192, 192);
            //软键盘设定背景色
            Paneljp.BackColor = ColorTranslator.FromHtml("#84a9ff");
            #region 给软键盘按钮附加click事件
            this.button111.Click += new System.EventHandler(this.button000_Click);
            this.button222.Click += new System.EventHandler(this.button000_Click);
            this.button333.Click += new System.EventHandler(this.button000_Click);
            this.button444.Click += new System.EventHandler(this.button000_Click);
            this.button555.Click += new System.EventHandler(this.button000_Click);
            this.button666.Click += new System.EventHandler(this.button000_Click);
            this.button777.Click += new System.EventHandler(this.button000_Click);
            this.button888.Click += new System.EventHandler(this.button000_Click);
            this.button999.Click += new System.EventHandler(this.button000_Click);
            #endregion
        }

        
        /// <summary>
        /// 获取手机验证码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtPhone.Text.Trim()))
                {
                    ShowMessage("手机号码不能为空!");
                    return;
                }
                if (!Phone(txtPhone.Text.Trim()))
                {
                    ShowMessage("手机号码格式有误!");
                    return;
                }


                tPhone = this.txtPhone.Text.Trim();
                yPhone = txtPhone.Text.Trim();
                
                Thread.Sleep(500);
                yCode = VerificationCode(tPhone.Trim());//wsf.VerificationCode(txtPhone.Text.Trim());//验证码
                JObject obj = JObject.Parse(yCode);
                yCode = "111111";
                //yCode = obj["string"]["#text"].ToString();
                link2.Enabled = false;
                link3.Text = "30 秒后重试";
                link2.Visible = false;
                link3.Visible = true;
                link3.Enabled = false;
                GetMessageStart = DateTime.Now;
            }
            catch (Exception ex)
            {
                ShowMessage("业务限流！");
                string s = ex.Message;
                //Logging.LogFile(s);
            }
        }


        #region 注册
        private void Register()
        {

            #region   检验是否正确
            if (String.IsNullOrEmpty(txtName.Text) || txtName.Text == "请输入姓名")
            {
                ShowMessage("请输入姓名");
                return;
            }
            if (String.IsNullOrEmpty(txtIDCard.Text) || txtIDCard.Text == "请输入身份证号")
            {
                ShowMessage("请输入身份证号");
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
                ShowMessage(Mge);
                return;
            }
      
            #endregion


            if (String.IsNullOrEmpty(txtAddress.Text) || txtAddress.Text == "请输入地址")
            {
                ShowMessage("请输入地址");
                return;
            }
            if (String.IsNullOrEmpty(tPhone) || tPhone == "请输入手机号")
            {
                ShowMessage("请输入手机号");
                return;
            }
            #region 验证手机号码是否合法
            if (!Phone(tPhone.Trim()))
            {
                Mge = "手机号码格式错误";
                ShowMessage(Mge);
                return;
            }
            #endregion
            #region 判断手机号与验证码是否合法
            if (!String.IsNullOrEmpty(tPhone))
            {
                if (string.IsNullOrEmpty(yPhone))
                {
                    Mge = "请您获取验证码";
                    ShowMessage("请您获取验证码");
                    return;
                }
                if (tPhone != yPhone)//如果接收验证码的手机与文本框的手机不一致
                {
                    ShowMessage("手机号码不一致");
                    return;
                }
                if (String.IsNullOrEmpty(txtYan.Text))//如果验证码为空
                {
                    ShowMessage("请输入验证码");
                    return;
                }
                if (txtYan.Text.Trim() != yCode)//与发送的验证码不一致
                {
                    ShowMessage("验证码错误");
                    return;
                }
                GetMessageEnd = DateTime.Now;
                TimeSpan time = GetMessageEnd - GetMessageStart;
                if (time.TotalMinutes > 5)
                {
                    ShowMessage("验证码失效");
                    return;
                }
            }
            #endregion

            if (IsAgree == 0)
            {
                ShowMessage("请同意该协议！");
                return;
            }

            #endregion
            #region 人脸识别
            FileStream fileStream;
            //抓取照片
            if (File.Exists(Path.GetFullPath(".\\") + "price.jpg"))
            {
                File.Delete(Path.GetFullPath(".\\") + "price.jpg");
            }
            try
            {
                Bitmap.Save(Path.GetFullPath(".\\") + "price.jpg");
                Bitmap.Dispose();//释放资源
            }
            catch (Exception)
            {

                ShowMessage("请上传照片！");
            }
           
            fileStream = new FileStream(Path.GetFullPath(".\\") + "price.jpg", FileMode.Open);
            byte[] byt = Stream(fileStream);//转换二进制流文件
            fileStream.Dispose();
            photoImg = byt;
            #endregion
            #region 图片
            if (photoImg == null)
            {
                ShowMessage("请上传图片！");
                return;
            }
            #endregion
            //本机
            //Test.WSFaces wsf = new Test.WSFaces();
            // 服务器
            // WebFace.WSFaces wsf = new WebFace.WSFaces();
            Stream stream = new MemoryStream(photoImg);
            //string PhoneNum = this.txtPhone.Text;
            string PhoneNum = tPhone;
            #region 调用注册接口（公安）验证

            #region 访问数据库判断是否存在用户


            //UserInfoBLL bll = new UserInfoBLL();

            ///// row=0可以注册
            ///// row=1用户已注册
            ///// row=3身份证号已注册
            ///// row=4手机号已注册
            //int checkResult = bll.CheckIDCard(PhoneNum, Sidnum);
            //string strs = "";
            //JObject obj = null;
            //if (checkResult == 0)
            //{
            //    string result = AuthenPliceFace(Sidnum, SName, PhoneNum, SNation, Address, stream);//wsf.AuthenPliceFace(Sidnum, SName, this.txtPhone.Text, SNation, Address, photoImg);

            //    obj = JObject.Parse(result);
            //    //结果码
            //    strs = obj["code"].ToString();
            //}
            //else if (checkResult == 1)
            //{
            //    strs = "2";
            //    errorMessage = "用户已注册";
            //}
            //else if (checkResult == 3)
            //{
            //    strs = "3";
            //    errorMessage = "身份证号已注册";
            //}
            //else
            //{
            //    strs = "4";
            //    errorMessage = "手机号已注册";
            //}

            #endregion

            string result = AuthenPliceFace(Sidnum, SName, PhoneNum, SNation, Address, stream);//wsf.AuthenPliceFace(Sidnum, SName, this.txtPhone.Text, SNation, Address, photoImg);

            JObject obj = JObject.Parse(result);
            //结果码
            string strs = obj["code"].ToString();


            if (strs == "1")
            {
                this.panelSuccess.Visible = true;
                this.panelSmallSuccess.Visible = true;
            }
            else
            {
                errorCount += 1; 
                if (obj != null)
                {
                    errorMessage = obj["message"].ToString();
                    this.panelSuccess.Visible = true;
                    this.panelSmallFail.Visible = true;
                    this.txtError.Text = errorMessage;
                }
                if (errorCount == 3)
                {
                    //Thread.Sleep(500);
                    errorMessage = obj["message"].ToString();
                    this.panelSuccess.Visible = true;
                    this.panelSmallFail.Visible = true;
                    FailCountDown = 10;
                    ExitRegister();
                }
            }

            #endregion

        }

        #endregion
        #region 图片转换
        public byte[] Stream(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];//把图片转成byte型 二进制流
            stream.Read(bytes, 0, bytes.Length);//把二进制流读入缓冲区
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }
        #endregion
        #region 人脸注册
        public static string AuthenPliceFace(string idcard, string name, string Phone, string Nation, string Address, Stream imgHead)
        {
            string result = "0";
            try
            {

                string reqUrl = "http://121.42.164.134:9918/API/HealthCard/HealthCardGiter";
                string encodeUrl = Utils.UriEncode(reqUrl);
                HttpWebRequest request = WebRequest.Create(reqUrl) as HttpWebRequest;
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = "POST";
                byte[] img = new byte[imgHead.Length];
                imgHead.Read(img, 0, img.Length);
                string postData = "Idno=" + idcard + "&Name=" + name
                    + "&Phone=" + Phone + "&Nation=" + Nation + "&Address=" + Address +
                    "&Base64=" + Utils.UriEncode(Convert.ToBase64String(img));
                var data = Encoding.UTF8.GetBytes(postData);
                Stream postStream = request.GetRequestStream();
                postStream.Write(data, 0, data.Length);
                postStream.Close();
                //发送请求并获取相应回应数据  
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream instream = response.GetResponseStream();
                result = "过程";
                StreamReader sr = new StreamReader(instream, Encoding.UTF8);
                result = sr.ReadToEnd();


            }
            catch (Exception ex)
            {
                //Logging.LogFile("BaiDuAuthent-AuthenPliceFaceTwo:" + ex.Message);
            }
            return result;
        }



        #endregion

        #region 通过timer4实现每隔规定时间自动读取身份证信息

        //private void timer4_Tick(object sender, EventArgs e)
        //{
                
        //}
        public void ReadIdcardInfo(object s)
        {
            IsStartIDCard = false;

            #region 读取身份证信息
            IDCardData CardMsg = new IDCardData();
            int nRet, nPort, iPhotoType;
            string stmp;
            byte[] cPath = new byte[255];
            byte[] pucIIN = new byte[4];
            byte[] pucSN = new byte[8];
            nPort = m_iPort;
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
                        //身份证读取之后，开始拍照
                        //将身份证放置在感应区
                        //请摘去帽子眼镜口罩 并正对屏幕刷脸认证
                        this.labTishi.Text = "请摘去帽子眼镜口罩";
                        this.labTIshi2.Text = "并正对屏幕刷脸认证";
                        ClearMemory();

                    }
                    else
                    {
                        stmp = Convert.ToString(System.DateTime.Now) + "  读取身份证信息错误";
                    }
                }
            }
            #endregion

            IsStartIDCard = true;
        }
        #endregion


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
        public String replaceStrAndName(String param)
        {
            int len = param.Trim().Length;
            if (len == 1 || len == 0)
            {
                return param;
            }
            else if (len == 2)
            {
                return param.Substring(0, 1) + "*";
            }
            else if (len == 3)
            {
                return param.Substring(0, 1) + "*" + param.Substring(param.Length - 1, 1);
            }
            else
            {
                return param.Substring(0, 1) + "**" + param.Substring(param.Length - 1, 1);
            }


        }
        public String replaceStrAnd(String param)
        {
            int len = param.Length;
            if (len < 6)
            {
                return param;
            }
            return Regex.Replace(param, "(.{" + (len < 12 ? 3 : 6) + "})(.*)(.{4})", "$1" + "****" + "$3");

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

        #region 手机号码验证
        public bool Phone(string phone)
        {
            Regex rx = new Regex(@"((^13[0-9]{1}[0-9]{8}|^15[0-9]{1}[0-9]{8}|^14[0-9]{1}[0-9]{8}|^16[0-9]{1}[0-9]{8}|^17[0-9]{1}[0-9]{8}|^18[0-9]{1}[0-9]{8}|^19[0-9]{1}[0-9]{8})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)");
            return rx.IsMatch(phone);
        }

        #endregion
        private void Form1_Shown(object sender, EventArgs e)
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
                ShowMessage(stmp);
            }
            #endregion
        }

        public Bitmap Bitmap;
        FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        public int selectedDeviceIndex = 0;
        private Point point;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                #region   检验是否正确
                if (String.IsNullOrEmpty(txtName.Text) || txtName.Text == "请输入姓名")
                {
                    ShowMessage("请输入姓名");
                    return;
                }
                if (String.IsNullOrEmpty(txtIDCard.Text) || txtIDCard.Text == "请输入身份证号")
                {
                    ShowMessage("请输入身份证号");
                    return;
                }
                #region 验证身份证是否合法
                String Mge = "";
                Address = this.txtAddress.Text.IndexOf('*')>0?Address:this.txtAddress.Text;
                Sidnum = this.txtIDCard.Text.IndexOf('*') > 0 ? Sidnum : this.txtIDCard.Text;
                SName = this.txtName.Text.IndexOf('*') > 0 ? SName : this.txtName.Text;

                string cid = CheckCidInfo18(Sidnum);
                if (cid != "")
                {
                    ShowMessage(cid);
                    return;
                }
        
                #endregion
                if (String.IsNullOrEmpty(txtAddress.Text) || txtAddress.Text == "请输入地址")
                {
                    ShowMessage("请输入地址");
                    return;
                }
                if (String.IsNullOrEmpty(tPhone) || tPhone == "请输入手机号")
                {
                    ShowMessage("请输入手机号");
                    return;
                }
                #region 验证手机号码是否合法
                if (!Phone(tPhone.Trim()))
                {
                    ShowMessage("手机号码格式错误!");
                    return;
                }
                #endregion
                #region 判断手机号与验证码是否合法
                if (!String.IsNullOrEmpty(tPhone))
                {
                    if (string.IsNullOrEmpty(yPhone))
                    {
                        ShowMessage("请您获取验证码");
                        return;
                    }
                    if (tPhone != yPhone)//如果接收验证码的手机与文本框的手机不一致
                    {
                        ShowMessage("手机号码不一致");
                        return;
                    }
                    if (String.IsNullOrEmpty(txtYan.Text))//如果验证码为空
                    {
                        ShowMessage("请输入验证码");
                        return;
                    }
                    if (txtYan.Text.Trim() != yCode)//与发送的验证码不一致
                    {
                        ShowMessage("验证码错误");
                        return;
                    }
                }
                #endregion
                
                if (IsAgree == 0)
                {
                    ShowMessage("请同意该协议！");
                    return;
                }




                #endregion

                Paneljp.Visible = false;
                //读卡提示消失
                picHict.Hide();
                Bitmap = null;
                
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                videoSource = new VideoCaptureDevice(videoDevices[selectedDeviceIndex].MonikerString);//连接摄像头
                videoSource.DesiredFrameSize = new Size(250, 250);
                videoSource.DesiredFrameRate = 1;
                videoSourcePlayer1.VideoSource = videoSource;
                // set NewFrame event handler
                videoSourcePlayer1.Start();
                videoSource.NewFrame += new NewFrameEventHandler(Asda);
              
                
            }
            catch (Exception)
            {
                return;
                throw;
            }
        }
        public void Asda(object sender, NewFrameEventArgs e)
        {
            try
            {
                
                Bitmap = (Bitmap)e.Frame.Clone();
               
            }
            catch (Exception ee)
            {
                string s = ee.Message;
            }
        }

        /// <summary>
        /// 调用短信接口
        /// </summary>
        /// <param name="Phone"></param>
        /// <returns></returns>
        public string VerificationCode(string Phone)
        {
            string result = "";
            
            //string url = "http://121.42.164.134:11122/WSFaces.asmx/VerificationCode";
            string url = "http://121.42.164.134:9909/NtitServer.asmx/GetShortMessageCode";
            var request = WebRequest.Create(url) as HttpWebRequest;
            if (request == null) throw new ArgumentNullException();
            //request.ContentType = "application/json;charset=utf-8";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "Post";
            string postData = "Phone=" + Phone;
            var data = Encoding.UTF8.GetBytes(postData);
            Stream postStream = request.GetRequestStream();
            postStream.Write(data, 0, data.Length);
            postStream.Close();
            //发送请求并获取相应回应数据  

            var response = request.GetResponse() as HttpWebResponse;
            //return mialcode.ToString();



            Stream instream = response.GetResponseStream();
            StreamReader sr = new StreamReader(instream, Encoding.UTF8);
            result = sr.ReadToEnd();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(result);
            result = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);
            //JObject obj = JObject.Parse(result);
            //result = obj["text"].ToString();//.SelectSingleNode("string").InnerText;

            return result;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register();
        }
        

        private void btnAgree_Click(object sender, EventArgs e)
        {
            //不同意协议
            IsAgree = 0;
            //btnNoAgree.BringToFront();
            btnAgree.Visible = false;
            btnNoAgree.Visible = true;
        }

        private void btnNoAgree_Click(object sender, EventArgs e)
        {
            //同意协议
            IsAgree = 1;
            //btnAgree.BringToFront();

            btnNoAgree.Visible = false;
            btnAgree.Visible = true;
        }

        private void link3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            link3.Visible = false;
            link2.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region 输入值判断


        #region 传输文本框内容

        private void txtName_TextChanged(object sender, EventArgs e)
        {

            //if (txtName.Text != "请输入姓名")
            //{
            this.txtName.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
           
            //}
            //else
            //{
            //    this.txtName.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ababab");
            //}
        }

        private void txtIDCard_TextChanged(object sender, EventArgs e)
        {
            //if (txtIDCard.Text != "请输入身份证号")
            //{
            this.txtIDCard.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
            
            //}
            //else
            //{
            //    this.txtIDCard.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ababab");
            //}
        }
        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            //if (txtAddress.Text != "请输入地址")
            //{
            this.txtAddress.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");

            //}
            //else
            //{
            //    this.txtAddress.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ababab");
            //}
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            //if (txtPhone.Text != "请输入手机号")
            //{
            this.txtPhone.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
            
            //}
            //else
            //{
            //    this.txtPhone.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ababab");
            //}

        }

        private void txtYan_TextChanged(object sender, EventArgs e)
        {
            //if (txtYan.Text != "请输入验证码")
            //{
            this.txtYan.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
            //}
            //else
            //{
            //    this.txtYan.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ababab");
            //}
        }

        #endregion

        private void txtName_Leave(object sender, EventArgs e)
        {

            SName = this.txtName.Text;
            this.txtName.Text = replaceStrAndName(this.txtName.Text);
            //if (string.IsNullOrEmpty(this.txtName.Text))
            //{
            //    this.txtName.Text = "请输入姓名";
            //}
        }

        private void txtName_Click(object sender, EventArgs e)
        {
            Paneljp.Visible = false;
            //if (this.txtName.Text == "请输入姓名")
            //{
            //    this.txtName.Text = "";
            //}
        }
        private void txtAddress_Leave(object sender, EventArgs e)
        {
            Address = this.txtAddress.Text;
            this.txtAddress.Text = replaceStrAnd(this.txtAddress.Text);
            //if (string.IsNullOrEmpty(this.txtAddress.Text))
            //{
            //    this.txtAddress.Text = "请输入地址";
            //}
        }


        private void txtAddress_Click(object sender, EventArgs e)
        {
            Paneljp.Visible = false;
            //if (this.txtAddress.Text == "请输入地址")
            //{
            //    this.txtAddress.Text = "";
            //}
        }

        private void txtIDCard_Leave(object sender, EventArgs e)
        {
            Sidnum = this.txtIDCard.Text;
            this.txtIDCard.Text = replaceStrAnd(this.txtIDCard.Text);
            //if (string.IsNullOrEmpty(this.txtIDCard.Text))
            //{
            //    this.txtIDCard.Text = "请输入身份证号";
            //}
        }
        

        private void txtIDCard_Click(object sender, EventArgs e)
        {
            Paneljp.Visible = false;
            //if (this.txtIDCard.Text == "请输入身份证号")
            //{
            //    this.txtIDCard.Text = "";
            //}
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            
            
            //if (string.IsNullOrEmpty(this.txtPhone.Text))
            //{
            //    this.txtPhone.Text = "请输入手机号";
            //}
        }
        

        private void txtPhone_Click(object sender, EventArgs e)
        {
            Paneljp.Visible = true;
            //if (this.txtPhone.Text== "请输入手机号")
            //{
            //    this.txtPhone.Text = "";
            //}
        }

        private void txtYan_Click(object sender, EventArgs e)
        {
            Paneljp.Visible = true;
            //if (this.txtYan.Text== "请输入验证码")
            //{
            //    this.txtYan.Text = "";
            //}
        }

        private void txtYan_Leave(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(this.txtYan.Text))
            //{
            //    this.txtYan.Text = "请输入验证码";
            //}
        }
        #endregion

        //倒计时清空注册信息
        int countDown = 300;
        int FailCountDown = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            countDown--;
            labTime.Text = DateTime.Now.ToString("yyyy.MM.dd").Trim()+"  " +DateTime.Now.ToString("HH:mm:ss").Trim();
            if (IsStartIDCard)
            {
                //this.labTishi.Text = "请摘去帽子眼镜口罩";
                //this.labTIshi2.Text = "并正对屏幕刷脸认证";
                ThreadPool.QueueUserWorkItem(ReadIdcardInfo, null);
            }
            if (link3.Text != "获取验证码" && int.Parse(link3.Text.Substring(0, link3.Text.Length - 5)) > 0)
            {

                link3.Text = int.Parse(link3.Text.Substring(0, link3.Text.Length - 5)) - 1 + " 秒后重试";
            }
            else
            {
                link2.Enabled = true;
                link3.Visible = false;
                link3.Enabled = true;
                link2.Visible = true;
            }
            //倒计时清空注册信息
            if (countDown<0)
            {
                //清空注册表单信息
                ExitRegister();
                this.labCountDown.Text = "";
            }
            else
            {
                this.labCountDown.Text =countDown.ToString()+ "秒后退出";
            }
            //if (Bitmap!=null)
            //{
            //    videoSourcePlayer1.Stop();

            //   this.picHict.BackgroundImage = Bitmap;
            //   picHict.Show();
            //}
            if (Bitmap!=null)
            {
                this.btnRegister.Visible = true;
                this.btnRegister.Enabled = true;
            }

            //失败倒计时
            if (FailCountDown>0)
            {
                FailCountDown--;
                this.txtError.Text = errorMessage + "，" + FailCountDown + "秒后重新注册";
                if (FailCountDown==0)
                {
                    panelSuccess.Visible = false;
                }
                
            }
        }
        #region 软键盘手动输入数字
        TextBox tmpTextBox = null;//定义全局变量储存光标所在的textbox
        private void button000_Click(object sender, EventArgs e)
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

        /// <summary>
        /// 手机号调用软键盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPhone_Enter(object sender, EventArgs e)
        {
            tmpTextBox = (TextBox)sender;
        }
        /// <summary>
        /// 验证码调用软键盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtYan_Enter(object sender, EventArgs e)
        {
            tmpTextBox = (TextBox)sender;
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

        private void btndelete_Click_1(object sender, EventArgs e)
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

        private void btnook_Click(object sender, EventArgs e)
        {
            tmpTextBox.Text = "";
        }
        

        private void txtName_Enter(object sender, EventArgs e)
        {
            Paneljp.Visible = false;
        }



        #region 手动退出和自动退出
        private void ExitRegister()
        {
            //倒计时初始化
            countDown = 300;
            //失败次数初始化
            errorCount = 0;
            this.txtName.Text = "";
            this.txtAddress.Text = "";
            this.txtIDCard.Text = "";
            this.txtPhone.Text = "";
            this.txtYan.Text = "";
            //初始化获取验证码
            link2.Enabled = true;
            link2.Visible = true;
            Sidnum = ""; SName = ""; yPhone = ""; SNation = ""; Address = "";
            Bitmap = null;
            //videoSourcePlayer1.Stop();
            try
            {
                if (videoSource!=null)
                {
                    videoSource.Stop();
                }
                
                //videoSourcePlayer1.WaitForStop();
            }
            catch (Exception )
            {
                
            }
            picHict.Show();
            //videoSourcePlayer1.WaitForStop();
            //初始化倒计时时间
            countDown = 300;
        }
        #endregion

        

        private void panelSuccess_Click(object sender, EventArgs e)
        {
            panelSuccess.Visible = false;
        }

        private void labExit_Click(object sender, EventArgs e)
        {
            ExitRegister();
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            ExitRegister();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MingYiPrivacyPolicy m = new MingYiPrivacyPolicy();
            m.StartPosition = FormStartPosition.CenterScreen;
            m.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void panelAll_Click(object sender, EventArgs e)
        {
            Paneljp.Visible = false;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            this.button1.BackColor = Color.White;
        }

        /// <summary>
        /// 关机命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            int time = 3600;    //单位为：秒
            Process.Start("c:/windows/system32/shutdown.exe", "-s -t " + time);
        }

        #region 错误提示
        /// <summary>
        /// 提示错误信息
        /// </summary>
        /// <param name="Message">错误信息</param>
        private void MessageShow(string Message)
        {
            this.panelMessage.Visible = true;
            this.txtErrorMessage.Text = Message;
        }
        private void ShowMessage(string Message)
        {
            MessageBox form = new MessageBox(Message);
            form.Show();
        }
        #endregion
        

        private void panelMessage_Click(object sender, EventArgs e)
        {
            this.panelMessage.Visible = false;
        }

        private void txtErrorMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtErrorMessage_Click(object sender, EventArgs e)
        {
            this.panelMessage.Visible = false;
        }
    }
}
