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
    /// 住院数据
    /// </summary>
    public class HospitalLiveDAL
    {
        #region  住院数据
        public List<BigDataHome> HospLiveDataDAL(string SP_Name, SqlParameter[] paras)
        {
            DBHelper dB = new DBHelper();
            return UpdateDataName( dB.ProcHomeData(SP_Name, System.Data.CommandType.StoredProcedure, paras));
        }
        #endregion

        #region 病种类别
        public List<BigDataHome> GetSickType()
        {
            string sql1 = "SELECT DISTINCT DiseName  from IemrTable WITH (NOLOCK)";
            DBHelper dB = new DBHelper();
            List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);
            List<BigDataHome> list = new List<BigDataHome>();
            list.Add(new BigDataHome
            {
                message = "病种类别",
                data = new List<ItmeList>{
            new ItmeList { Name="病种类别",SelectItmeList=mzrc }
            }
            });
            return list;
        }
        #endregion


        /// <summary>
        /// 住院数据统计年龄饼状图
        /// </summary>
        /// <param name="StateTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="SPTXT"></param>
        /// <param name="K"></param>
        /// <returns></returns>
       public List<BigDataHome> HospLiveAgeData(string StateTime, string EndTime, string SPTXT, string K)
        {

            List<BigDataHome> list = new List<BigDataHome>();
            list.Add(new BigDataHome
            {
                message = "住院数据年龄分组",
                data = new List<ItmeList>()
            });

            //    string sql1 = "Select s.Sex,SUM(Case When age <=5 Then 1 Else 0 End) As ZoreToFive,"+
            //        "SUM(Case When age Between 6 And 10 Then 1 Else 0 End) As FiveToTen,"+
            //        "SUM(Case When age Between 11 And 20 Then 1 Else 0 End) As TenToTwenty," +
            //      "SUM(Case When age Between 21 And 30 Then 1 Else 0 End) As TwentyToThrity," +
            //"Sum(Case When age Between 31 And 40 Then 1 Else 0 End) As ThrityToFourty," +
            //"Sum(Case When age Between 41 And 60 Then 1 Else 0 End) As FourtyTOSixty," +
            //"Sum(Case When age >= 61 Then 1 Else 0 End) As OnSixty From(SELECT *, datediff(year, Birthday, getdate()) AS age FROM InberTable  where[Data] between '"+StateTime+"' and '"+EndTime+"'";


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

            string part = " ) s ";
            if (K == "C")
            {
                part = " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE ) ) s  ";
            }
            if (K == "Y")
            {
                part = " and HospCode='" + SPTXT + "' ) s  ";
            }

            string sql1 = "SELECT  'ZoreToTwenty'AS AgeDuan, SUM(counts) AS ShuLiang,s.Sex From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM InberTable where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + "AND  age <=5  Group BY s.Sex " +
                           "UNION ALL " +
                           "SELECT  'TwentyToFourty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM InberTable  where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + "AND  age Between 6 And 10  Group BY s.Sex " +
                           "UNION ALL " +
                           "SELECT  'FourtyTOSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM InberTable where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + "AND  age Between 11 And 20 Group BY s.Sex " +
                           "UNION ALL " +
                           "SELECT  'FourtyTOSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM InberTable where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + "AND  age Between 21 And 30 Group BY s.Sex " +
                            "UNION ALL " +
                           "SELECT  'FourtyTOSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM InberTable where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + "AND  age Between 31 And 40 Group BY s.Sex " +
                            "UNION ALL " +
                           "SELECT  'FourtyTOSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM InberTable where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + "AND  age Between 41 And 60 Group BY s.Sex " +
                           "UNION ALL " +
                           "SELECT 'OnSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM InberTable where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + "AND  age >=61 Group BY s.Sex ";
            DBHelper dB = new DBHelper();


            List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);
            list[0].data.Add(new ItmeList { Name = "根据年龄分组各阶段人数", SelectItmeList = mzrc });

            return list;
        }

        /// <summary>
        /// 住院饼状图
        /// </summary>
        /// <param name="StateTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="SPTXT"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public List<BigDataHome> IllTypeBigDataDAL(string StateTime, string EndTime, string SPTXT, string K)
        {
            List<string> BingType = new List<string>();
            BingType.Add("肺炎");
            BingType.Add("发热");
            BingType.Add("高血压");
            BingType.Add("心脏病");
            BingType.Add("糖尿病");
            List<BigDataHome> list = new List<BigDataHome>();
            list.Add(new BigDataHome
            {
                message = "首页数据",
                data = new List<ItmeList>()
            });


            foreach (var item in BingType)
            {
                string part = " ) s  WHERE s.Chename LIKE '%" + item + "%' ";
                if (K == "C")
                {
                    part = " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE ) ) s  WHERE s.Chename LIKE '%" + item + "%'";
                }
                if (K == "Y")
                {
                    part = " and HospCode='" + SPTXT + "' ) s  WHERE s.Chename LIKE '%" + item + "%' ";
                }

                string sql1 = "SELECT '" + item + "' as name, 'ZoreToTwenty'AS AgeDuan, SUM(counts) AS ShuLiang,s.Sex From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM InberTable where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + "AND  age <=20  Group BY s.Sex " +
                               "UNION ALL " +
                               "SELECT '" + item + "' as name, 'TwentyToFourty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM InberTable  where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + "AND  age Between 21 And 40  Group BY s.Sex " +
                               "UNION ALL " +
                               "SELECT '" + item + "' as name, 'FourtyTOSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM InberTable where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + "AND  age Between 41 And 60 Group BY s.Sex " +
                              "UNION ALL " +
                               "SELECT '" + item + "' as name, 'OnSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM InberTable where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + "AND  age >=61 Group BY s.Sex ";
                DBHelper dB = new DBHelper();

                List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);
                list[0].data.Add(new ItmeList { Name = item, SelectItmeList = mzrc });
            }
            //     foreach (var item in BingType)
            //     {
            //         string sql1 = "Select s.Sex,'" + item + "' as name,SUM(Case When age <=20 Then 1 Else 0 End) As ZoreToTwenty," +
            // "Sum(Case When age Between 21 And 40 Then 1 Else 0 End) As TwentyToFourty," +
            //"Sum(Case When age Between 41 And 60 Then 1 Else 0 End) As 'FourtyTOSixty'," +
            //"Sum(Case When age >= 61 Then 1 Else 0 End) As OnSixty From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM InberTable  where [Data] between '" + StateTime + "' and '" + EndTime+"' ";


            //         DBHelper dB = new DBHelper();
            //         if (K == "C")
            //         {
            //             sql1 += " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE )";
            //         }
            //         if (K == "Y")
            //         {
            //             sql1 += " and HospCode='" + SPTXT + "' ";
            //         }
            //         sql1 += "";
            //         sql1 += ") s  WHERE s.DiseName LIKE '%" + item + "%' GROUP BY s.Sex";

            //         List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);
            //         list[0].data.Add(new ItmeList { Name = item, SelectItmeList = mzrc });
            //     }

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
                    item.Name = "住院人次";
                }
                if (item.Name == "门诊电子病历")
                {
                    item.Name = "出院人次";
                }
                if (item.Name == "门诊处方总数")
                {
                    item.Name = "住院电子病历";
                }
                if (item.Name == "中医处方总量")
                {
                    item.Name = "住院费用总额";
                }
                if (item.Name == "门诊费用总额")
                {
                    item.Name = "床位数";
                }
                if (item.Name == "中药费用总额")
                {
                    item.Name = "住院收费趋势";
                }
                if (item.Name == "门诊就医趋势")
                {
                    item.Name = "住院就医趋势";
                }
                if (item.Name == "门诊收费趋势")
                {
                    item.Name = "地区住院人次";
                }
                if (item.Name == "地区")
                {
                    item.Name = "";
                }

            }
            return data;
        }
        public List<BigDataHome> AgeTypeBigDataDAL(string StateTime, string EndTime, string SPTXT, string K)
        {
            string sql1 = "select SUM(TnoiDay) as MZRC from InberTable WITH (NOLOCK) where [Data] between " + StateTime + "and " + EndTime;
            DBHelper dB = new DBHelper();
            if (K == "C")
            {
                sql1 += " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE )";
            }
            if (K == "Y")
            {
                sql1 += " and HospCode='" + SPTXT + "'";
            }
            List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);
            List<BigDataHome> list = new List<BigDataHome>();
            list.Add(new BigDataHome
            {
                message = "首页数据",
                data = new List<ItmeList>{
            new ItmeList { Name="年龄",SelectItmeList=mzrc }
            }
            });
            return list;
        }
    }
}
