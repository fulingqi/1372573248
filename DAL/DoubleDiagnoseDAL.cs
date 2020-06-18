using Core;
using Core.Responese;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    /// <summary>
    /// 双向诊断
    /// </summary>
    public class DoubleDiagnoseDAL
    {

        /// <summary>
        /// 双向转诊主界面数据（SP_TwoDia_Proc）
        /// </summary>
        /// <returns></returns>
        public List<BigDataHome> TwoDiaData(string StartTime,string EndTime,string SPTXT,string K)
        {
            DBHelper dB = new DBHelper();
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@StartTime",SqlDbType.VarChar,50),
                new SqlParameter("@EndTime",SqlDbType.VarChar,50),
                new SqlParameter("@HospCode",SqlDbType.VarChar,200),
                new SqlParameter("@type",SqlDbType.VarChar,200)
                 };
            paras[0].Value = StartTime;
            paras[1].Value = EndTime;
            paras[2].Value = SPTXT;

            //K == 1 市   2县    3医院
            if (K == "H")
            {
                paras[3].Value = 1;
            }
            if (K == "C")
            {
                paras[3].Value = 2;
            }
            if (K == "Y")
            {
                paras[3].Value = 3;
            }
            return UpdateDataName(dB.ProcHomeData("SP_TwoDia_Proc", System.Data.CommandType.StoredProcedure, paras));
        }
        
        /// <summary>
        /// 双向转诊饼状图Data
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public List<BigDataHome> GetTwoDiaPieChartData(string StartTime, string EndTime)
        {
            //if (string.IsNullOrEmpty(StartTime))
            //{
            //    DateTime dt = DateTime.Parse(StartTime);
            //    StartTime = dt.ToString("yyyy/mm/dd hh:mm:ss");
            //}
            //if (string.IsNullOrEmpty(EndTime))
            //{
            //    DateTime dt = DateTime.Parse(EndTime);
            //    EndTime = dt.ToString("yyyy/mm/dd hh:mm:ss");
            //}
            string sql1 = "Select s.Sex,s.Department,Sum(Case When age <=20 Then 1 Else 0 End) As ZoreToTwenty," +
        "Sum(Case When age Between 21 And 40 Then 1 Else 0 End) As TwentyToFourty," +
       "Sum(Case When age Between 41 And 60 Then 1 Else 0 End) As  FourtyTOSixty," +
       "Sum(Case When age >= 61 Then 1 Else 0 End) As OnSixty From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM TwreTable  where [Data] between '" + StartTime + "' and '" + EndTime + "' ) s Group by s.Sex,s.Department";

            DBHelper dB = new DBHelper();
            List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);
            List<BigDataHome> list = new List<BigDataHome>();
            list.Add(new BigDataHome
            {
                message = "双向转诊饼状图",
                data = new List<ItmeList>{
            new ItmeList { Name="Data",SelectItmeList=mzrc }
            }
            });
            return list;
        }



        /// <summary>
        /// 修改数据中的Name
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<BigDataHome> UpdateDataName(List<BigDataHome> data)
        {
            foreach (var item in data[0].data)
            {
                if (item.Name == "门诊人次")
                {
                    item.Name = "转诊次数";
                }
                if (item.Name == "门诊电子病历")
                {
                    item.Name = "下转次数";
                }
                if (item.Name == "门诊处方总数")
                {
                    item.Name = "转诊成功";
                }
                if (item.Name == "中医处方总量")
                {
                    item.Name = "转诊人次地区";
                }
                if (item.Name == "门诊费用总额")
                {
                    item.Name = "转诊人次趋势";
                }
                if (item.Name == "中药费用总额")
                {
                    item.Name = "转诊拒绝";
                }
                if (item.Name == "门诊就医趋势")
                {
                    item.Name = "转诊取消";
                }
                if (item.Name == "门诊收费趋势")
                {
                    item.Name = "";
                }
                if (item.Name == "地区")
                {
                    item.Name = "";
                }

            }
            return data;
        }
    }
}
