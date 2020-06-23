using Core;
using Core.Responese;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{

    /// <summary>
    /// 健康档案
    /// </summary>
     public class HealthRecordDAL
    {
        #region 健康档案数据

        public List<BigDataHome> HealthRecordDataDAL(string SP_Name, SqlParameter[] paras)
        {
            DBHelper dB = new DBHelper();
            return UpdateDataName(dB.ProcHomeData(SP_Name, System.Data.CommandType.StoredProcedure, paras));
        }
        /// <summary>
        /// 健康档案饼状图InberTable
        /// </summary>
        /// <returns></returns>
        public List<BigDataHome> HealthRecordPie()
        {
            DBHelper dB = new DBHelper();
            //     string sql = "Select s.Sex,SUM(Case When age <=20 Then 1 Else 0 End) As ZoreToTwenty,"+
            // "Sum(Case When age Between 21 And 40 Then 1 Else 0 End) As TwentyToFourty,"+
            //"Sum(Case When age Between 41 And 60 Then 1 Else 0 End) As FourtyTOSixty,"+
            //"Sum(Case When age >= 61 Then 1 Else 0 End) As OnSixty From(SELECT *, datediff(year, Birthday, getdate()) AS age FROM InberTable)s GROUP BY s.Sex";
            string sql = "SELECT  'ZoreToTwenty'AS AgeDuan, SUM(counts) AS ShuLiang,s.Sex ,s.DepartmentFrom (SELECT *, datediff(year, Birthday, getdate()) AS age FROM FiledTable) s where age <=20  Group BY s.Sex ,s.Department" +
                               "UNION ALL " +
                               "SELECT  'TwentyToFourty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex,s.Department From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM FiledTable ) s where age Between 21 And 40  Group BY s.Sex ,s.Department" +
                               "UNION ALL " +
                               "SELECT  'FourtyTOSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex ,s.DepartmentFrom(SELECT*, datediff(year, Birthday, getdate()) AS age FROM FiledTable ) s where  age Between 41 And 60 Group BY s.Sex ,s.Department" +
                              "UNION ALL " +
                               "SELECT 'OnSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex ,s.DepartmentFrom(SELECT*, datediff(year, Birthday, getdate()) AS age FROM FiledTable ) s where  age >=61 Group BY s.Sex ,s.Department";

            List<Dictionary<string, object>> mzrc = dB.GetNewList(sql, System.Data.CommandType.Text);
            List<BigDataHome> list = new List<BigDataHome>();
            list.Add(new BigDataHome
            {
                message = "健康档案饼状图",
                data = new List<ItmeList>{
            new ItmeList { Name="建档占比",SelectItmeList=mzrc }}
            });
            return list;
        }



        /// <summary>
        /// 健康档案根据年龄分组
        /// </summary>
        /// <param name="StateTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="SPTXT"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public List<BigDataHome> HealthBookByAgeData()
        {

            List<BigDataHome> list = new List<BigDataHome>();
            list.Add(new BigDataHome
            {
                message = "年龄分组",
                data = new List<ItmeList>()
            });

            //    string sql1 = "Select s.Sex,SUM(Case When age <=5 Then 1 Else 0 End) As ZoreToFive," +
            //        "SUM(Case When age Between 6 And 10 Then 1 Else 0 End) As FiveToTen," +
            //        "SUM(Case When age Between 11 And 20 Then 1 Else 0 End) As TenToTwenty," +
            //      "SUM(Case When age Between 21 And 30 Then 1 Else 0 End) As TwentyToThrity," +
            //"Sum(Case When age Between 31 And 40 Then 1 Else 0 End) As ThrityToFourty," +
            //"Sum(Case When age Between 41 And 60 Then 1 Else 0 End) As FourtyTOSixty," +
            //"Sum(Case When age >= 61 Then 1 Else 0 End) As OnSixty From(SELECT *, datediff(year, Birthday, getdate()) AS age FROM InberTable  ";


            //    DBHelper dB = new DBHelper();
            //    sql1 += ") s GROUP BY s.Sex";
            DBHelper dB = new DBHelper();
            string part = " ) s  where  ";

            string sql1 = "SELECT  'ZoreToFive'AS AgeDuan, SUM(counts) AS ShuLiang,s.Sex From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM FiledTable" + part + "  age <=5  Group BY s.Sex " +
                         "UNION ALL " +
                         "SELECT  'SixToTen'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM FiledTable " + part + "  age Between 6 And 10  Group BY s.Sex " +
                         "UNION ALL " +
                         "SELECT  'EvelTOTwenty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM FiledTable  " + part + "  age Between 11 And 20 Group BY s.Sex " +
                         "UNION ALL " +
                         "SELECT  'TwentyTOThirty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM FiledTable " + part + "  age Between 21 And 30 Group BY s.Sex " +
                          "UNION ALL " +
                         "SELECT  'ThirtyTOFourty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM FiledTable " + part + "  age Between 31 And 40 Group BY s.Sex " +
                          "UNION ALL " +
                         "SELECT  'FourtyTOSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM FiledTable " + part + "  age Between 41 And 60 Group BY s.Sex " +
                         "UNION ALL " +
                         "SELECT 'OnSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM FiledTable  " + part + "  age >=61 Group BY s.Sex ";


            List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);
            list[0].data.Add(new ItmeList { Name = "根据年龄分组各阶段人数", SelectItmeList = mzrc });

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
                if (item.Name=="门诊人次")
                {
                    item.Name = "档案调用总数";
                }
                if (item.Name == "门诊电子病历")
                {
                    item.Name = "医院调用";
                }
                if (item.Name == "门诊处方总数")
                {
                    item.Name = "个人调用";
                }
                if (item.Name == "中医处方总量")
                {
                    item.Name = "已建档总数";
                }
                if (item.Name == "门诊费用总额")
                {
                    item.Name = "";
                }
                if (item.Name == "中药费用总额")
                {
                    item.Name = "";
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
                    item.Name = "   ";
                }

            }
            return data;
        }
        #endregion
    }
}
