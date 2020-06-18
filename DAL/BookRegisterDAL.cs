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
    /// 预约挂号
    /// </summary>
    public class BookRegisterDAL
    {
        /// <summary>
        /// 预约首页数据
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public List<BigDataHome> BookRegisterData(string StartTime,string EndTime)
        {
            DBHelper dB = new DBHelper();
            HospitalLiveDAL dal = new HospitalLiveDAL();
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@StartTime",SqlDbType.VarChar,50),
                new SqlParameter("@EndTime",SqlDbType.VarChar,50)
                //new SqlParameter("@BigAge",SqlDbType.Int),
                //new SqlParameter("@SmallAge",SqlDbType.Int),
                //new SqlParameter("@DiseSpec",SqlDbType.VarChar,40)
                 };
            paras[0].Value = StartTime;
            paras[1].Value = EndTime;
            return UpdateDataName(dB.ProcHomeData("SP_BookRe", System.Data.CommandType.StoredProcedure, paras));
           
        }
        /// <summary>
        /// 预约挂号饼状图Data
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public List<BigDataHome> GetPieChartData(string StartTime,string EndTime)
        {
            string sql1 = "Select s.Sex,SUM(Case When age <=20 Then 1 Else 0 End) As ZoreToTwenty," +
        "Sum(Case When age Between 21 And 40 Then 1 Else 0 End) As TwentyToFourty," +
       "Sum(Case When age Between 41 And 60 Then 1 Else 0 End) As 'FourtyTOSixty'," +
       "Sum(Case When age >= 61 Then 1 Else 0 End) As OnSixty From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM MakeTable  where [Data] between '" + StartTime + "' and '" + EndTime + "' ) s Group by s.Sex";

            DBHelper dB = new DBHelper();
            List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);
            List<BigDataHome> list = new List<BigDataHome>();
            list.Add(new BigDataHome
            {
                message = "预约挂号饼状图",
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
                    item.Name = "预约人次";
                }
                if (item.Name == "门诊电子病历")
                {
                    item.Name = "到诊人次";
                }
                if (item.Name == "门诊处方总数")
                {
                    item.Name = "爽约人次";
                }
                if (item.Name == "中医处方总量")
                {
                    item.Name = "取消人次";
                }
                if (item.Name == "门诊费用总额")
                {
                    item.Name = "预约人次趋势";
                }
                if (item.Name == "中药费用总额")
                {
                    item.Name = "预约途径及数量";
                }
                if (item.Name == "门诊就医趋势")
                {
                    item.Name = "";
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
