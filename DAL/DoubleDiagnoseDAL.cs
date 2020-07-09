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
        public List<BigDataHome> TwoDiaData(string StartTime, string EndTime, string SPTXT, string K)
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
        /// 双向转诊饼状图Data  TwreTable
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public List<BigDataHome> GetTwoDiaPieChartData(string StartTime, string EndTime, string SPTXT, string K)
        {
            string part = " ) s ";
            if (K == "C")
            {
                part = " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE ) ) s  ";
            }
            if (K == "Y")
            {
                part = " and HospCode='" + SPTXT + "' ) s  ";
            }

            string sql1 = "SELECT  'ZoreToTwenty'AS AgeDuan,COUNT(1) AS ShuLiang,s.Sex ,s.Department From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM TwreTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + " WHERE  age <=20  Group BY s.Sex ,s.Department" +
                           " UNION ALL " +
                           "SELECT  'TwentyToFourty'AS AgeDuan, COUNT(1) AS ShuLiang, s.Sex,s.Department From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM TwreTable  where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + " WHERE  age Between 21 And 40  Group BY s.Sex ,s.Department" +
                           " UNION ALL " +
                           "SELECT  'FourtyTOSixty'AS AgeDuan, COUNT(1) AS ShuLiang, s.Sex ,s.Department From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM TwreTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + " WHERE  age Between 41 And 60 Group BY s.Sex ,s.Department" +
                          " UNION ALL " +
                           " SELECT 'OnSixty'AS AgeDuan, COUNT(1) AS ShuLiang, s.Sex ,s.Department From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM TwreTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "  WHERE  age >=61 Group BY s.Sex ,s.Department";
            DBHelper dB = new DBHelper();

            //     string sql1 = "Select s.Sex,s.Department,Sum(Case When age <=20 Then 1 Else 0 End) As ZoreToTwenty," +
            // "Sum(Case When age Between 21 And 40 Then 1 Else 0 End) As TwentyToFourty," +
            //"Sum(Case When age Between 41 And 60 Then 1 Else 0 End) As  FourtyTOSixty," +
            //"Sum(Case When age >= 61 Then 1 Else 0 End) As OnSixty From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM TwreTable  where [Data] between '" + StartTime + "' and '" + EndTime + "'";
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
            //     DBHelper dB = new DBHelper();
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
        /// 双向转诊统计年龄饼状图 TwreTable
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="SPTXT"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public List<BigDataHome> TwoDiaPieChartAgeData(string StartTime, string EndTime, string SPTXT, string K)
        {

            List<BigDataHome> list = new List<BigDataHome>();
            list.Add(new BigDataHome
            {
                message = "双向转诊年龄分组",
                data = new List<ItmeList>()
            });
            DBHelper dB = new DBHelper();
            string part = " ) s  WHERE";
            if (K == "C")
            {
                part = " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE ) ) s  WHERE";
            }
            if (K == "Y")
            {
                part = " and HospCode='" + SPTXT + "' ) s  WHERE";
            }

            string sql1 = "SELECT  'ZoreToFive'AS AgeDuan, COUNT(1) AS ShuLiang,s.Sex From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM TwreTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "  age <=5  Group BY s.Sex " +
                         "UNION ALL " +
                         "SELECT  'SixToTen'AS AgeDuan, COUNT(1) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM TwreTable  where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "  age Between 6 And 10  Group BY s.Sex " +
                         "UNION ALL " +
                         "SELECT  'EvelTOTwenty'AS AgeDuan, COUNT(1) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM TwreTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "  age Between 11 And 20 Group BY s.Sex " +
                         "UNION ALL " +
                         "SELECT  'TwentyTOThirty'AS AgeDuan, COUNT(1) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM TwreTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "  age Between 21 And 30 Group BY s.Sex " +
                          "UNION ALL " +
                         "SELECT  'ThirtyTOFourty'AS AgeDuan, COUNT(1) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM TwreTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "  age Between 31 And 40 Group BY s.Sex " +
                          "UNION ALL " +
                         "SELECT  'FourtyTOSixty'AS AgeDuan,COUNT(1) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM TwreTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "  age Between 41 And 60 Group BY s.Sex " +
                         "UNION ALL " +
                         "SELECT 'OnSixty'AS AgeDuan, COUNT(1) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM TwreTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "  age >=61 Group BY s.Sex ";
            //    string sql1 = "Select s.Sex,SUM(Case When age <=5 Then 1 Else 0 End) As ZoreToFive," +
            //        "SUM(Case When age Between 6 And 10 Then 1 Else 0 End) As FiveToTen," +
            //        "SUM(Case When age Between 11 And 20 Then 1 Else 0 End) As TenToTwenty," +
            //      "SUM(Case When age Between 21 And 30 Then 1 Else 0 End) As TwentyToThrity," +
            //"Sum(Case When age Between 31 And 40 Then 1 Else 0 End) As ThrityToFourty," +
            //"Sum(Case When age Between 41 And 60 Then 1 Else 0 End) As FourtyTOSixty," +
            //"Sum(Case When age >= 61 Then 1 Else 0 End) As OnSixty From(SELECT *, datediff(year, Birthday, getdate()) AS age FROM TwreTable  where[Data] between '" + StartTime + "' and '" + EndTime + "'";


            //    DBHelper dB = new DBHelper();
            //    if (K == "C")
            //    {
            //        sql1 += " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE )";
            //    }
            //    if (K == "Y")
            //    {
            //        sql1 += " and HospCode='" + SPTXT + "' ";
            //    }
            //    sql1 += "";
            //    sql1 += ") s GROUP BY s.Sex";

            List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);
            list[0].data.Add(new ItmeList { Name = "根据年龄分组各阶段人数", SelectItmeList = mzrc });

            return list;
        }


        public List<BigDataHome> TwoZhuanRuOrChuData(string StartTime, string EndTime, string SPTXT)
        {
            DBHelper dB = new DBHelper();
            List<BigDataHome> list = new List<BigDataHome>();
            list.Add(new BigDataHome
            {
                message = "乡镇转出和转入趋势",
                data = new List<ItmeList>()
            });
            string sql = "SELECT  COUNT(1) AS Sums,t.Data FROM dbo.TwreTable t  JOIN " +
                          " dbo.MediTable m ON t.HospCode = m.ORGCODE" +
                          " WHERE t.Updown != m.MANAGERORGNAME " +
                          " AND t.Data BETWEEN '"+ StartTime + "' AND '"+ EndTime + "'" +
                          " AND t.HospCode = '"+ SPTXT + "'" +
                          " GROUP BY t.Data";

            List<Dictionary<string, object>> mzrc = dB.GetNewList(sql, System.Data.CommandType.Text);
            list[0].data.Add(new ItmeList { Name = "转出趋势", SelectItmeList = mzrc });
            //list.Add(new BigDataHome
            //{
            //    message = "乡镇转入",
            //    data = new List<ItmeList>()
            //});
            string sql1 = "SELECT  COUNT(1) AS Sums,t.Data FROM dbo.TwreTable t  JOIN " +
                         "dbo.MediTable m ON t.HospCode = m.ORGCODE " +
                         " WHERE t.Updown = m.MANAGERORGNAME " +
                         " AND t.Data BETWEEN '" + StartTime + "' AND '" + EndTime + "'" +
                         " AND t.HospCode = '" + SPTXT + "'" +
                         " GROUP BY t.Data";

            List<Dictionary<string, object>> mzrcs = dB.GetNewList(sql1, System.Data.CommandType.Text);
            list[0].data.Add(new ItmeList { Name = "转入趋势", SelectItmeList = mzrcs });

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
                    item.Name = "上转次数";
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
