using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
     public  class ShortMessage
    {
        //       [ID] [INT] IDENTITY(1,1) NOT NULL,

        //   [HospCode] [NVARCHAR] (200) NULL,
        //[MACAddress] [NVARCHAR] (200) NULL,
        //[PhoneNum] [NVARCHAR] (20) NULL,
        //[AuthCode] [NVARCHAR] (50) NULL,
        //[SendMessDate] [DATETIME] NULL
        public int ID { get; set; }
        /// <summary>
        /// 医院编号
        /// </summary>
        public string HospCode { get; set; }

        /// <summary>
        /// MAC地址
        /// </summary>
        public string MACAddress { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNum { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string AuthCode { get; set; }
        /// <summary>
        /// 发送短信的时间
        /// </summary>
        public string SendMessDate { get; set; }
    }
}
