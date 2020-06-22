using Core.Responese;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Core;

namespace DAL
{
    /// <summary>
    /// 公共卫生
    /// </summary>
    public class PublicHygieneDAL
    {
        /// <summary>
        /// 公共卫生主界面数据（SP_TwoDia_Proc）
        /// </summary>
        /// <returns></returns>
        public List<BigDataHome> PublicHealthData(string SPTXT, string K)
        {
            DBHelper dB = new DBHelper();
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@HospCode",SqlDbType.VarChar,200),
                new SqlParameter("@type",SqlDbType.VarChar,200)
                 };
            paras[0].Value = SPTXT;

            //K == 1 市   2县    3医院
            if (K == "H")
            {
                paras[1].Value = 1;
            }
            if (K == "C")
            {
                paras[1].Value = 2;
            }
            if (K == "Y")
            {
                paras[1].Value = 3;
            }
            return UpdateDataName(dB.ProcHomeData("SP_PublicHeal", System.Data.CommandType.StoredProcedure, paras));
        }

        /// <summary>
        /// 公共卫生饼图Data NFileTable
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public List<BigDataHome> GetPublicMainData(string StartTime, string EndTime, string SPTXT, string K)
        {

            //     string sql1 = "Select s.Sex,s.Department,Sum(Case When age <=20 Then 1 Else 0 End) As ZoreToTwenty," +
            // "Sum(Case When age Between 21 And 40 Then 1 Else 0 End) As TwentyToFourty," +
            //"Sum(Case When age Between 41 And 60 Then 1 Else 0 End) As  FourtyTOSixty," +
            //"Sum(Case When age >= 61 Then 1 Else 0 End) As OnSixty From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM NFileTable  where [Data] between '" + StartTime + "' and '" + EndTime + "'";
            //     if (K == "C")
            //     {
            //         sql1 += " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE )";
            //     }
            //     if (K == "Y")
            //     {
            //         sql1 += " and HospCode='" + SPTXT + "' ";
            //     }
            //     sql1 += "";
            //     sql1 += "  ) s Group by s.Sex,s.Department";

            string part = " ) s ";
            if (K == "C")
            {
                part = " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE ) ) s  ";
            }
            if (K == "Y")
            {
                part = " and HospCode='" + SPTXT + "' ) s  ";
            }

            string sql1 = "SELECT  'ZoreToTwenty'AS AgeDuan, SUM(counts) AS ShuLiang,s.Sex ,s.Department From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM NFileTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age <=20  Group BY s.Sex ,s.Department" +
                           "UNION ALL " +
                           "SELECT  'TwentyToFourty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex,s.Department From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM NFileTable  where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 21 And 40  Group BY s.Sex ,s.Department" +
                           "UNION ALL " +
                           "SELECT  'FourtyTOSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex ,s.Department From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM NFileTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 41 And 60 Group BY s.Sex ,s.Department" +
                          "UNION ALL " +
                           "SELECT 'OnSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex ,s.Department From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM NFileTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age >=61 Group BY s.Sex ,s.Department";
            DBHelper dB = new DBHelper();
            List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);
            List<BigDataHome> list = new List<BigDataHome>();
            list.Add(new BigDataHome
            {
                message = "公共卫生饼图",
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
                    item.Name = "新建档案数量";
                }
                if (item.Name == "门诊电子病历")
                {
                    item.Name = "档案规范维护管理数量";
                }
                if (item.Name == "门诊处方总数")
                {
                    item.Name = "家庭医生签约数量";
                }
                if (item.Name == "中医处方总量")
                {
                    item.Name = "高血压管理总量";
                }
                if (item.Name == "门诊费用总额")
                {
                    item.Name = "糖尿病管理总量";
                }
                if (item.Name == "中药费用总额")
                {
                    item.Name = "老年人档案总量";
                }
                if (item.Name == "门诊就医趋势")
                {
                    item.Name = "高血压根据县";
                }
                if (item.Name == "门诊收费趋势")
                {
                    item.Name = "糖尿病根据县";
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
