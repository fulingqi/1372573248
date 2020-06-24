using Core;
using Core.Responese;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace DAL
{
    public class BigDataDAL
    {
        #region  获取直属医院信息
        public List<BigDataHome> ZhiShuHosp()
        {
            try
            {

                DBHelper dB = new DBHelper();
                string sql1 = "SELECT * FROM dbo.MediTable WHERE MANAGERORGNAME  IN('丽水市妇幼保健院','丽水市人民医院','丽水市中心医院','丽水市第二人民医院','丽水市中医院')";
                List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);


                List<BigDataHome> list = new List<BigDataHome>();
                list.Add(new BigDataHome
                {
                    message = "直属医院信息",
                    data = new List<ItmeList>{
            new ItmeList { Name="直属医院",SelectItmeList=mzrc }}
                });
                return list;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        #endregion




        #region 查询地区所有机构
        public List<Dictionary<string, object>> GetNewList(string K)
        {
            string sql = "select ORGCODE From MediTable where ADMINISTRATIVECODE like '" + K + "%'";
            DBHelper db = new DBHelper();
            return db.GetNewList(sql, System.Data.CommandType.Text);
        }
        #endregion

        #region 一期
        public List<BigDataHome> HomeBigDataDAL(string SP_Name, SqlParameter[] paras)
        {
            DBHelper dB = new DBHelper();

            var result = dB.ProcHomeData(SP_Name, System.Data.CommandType.StoredProcedure, paras);
            return result;
        }
        #endregion

        #region 二期（发热门诊）
        public List<BigDataHome> HomeTTPBigDataDAL(string SP_Name, SqlParameter[] paras)
        {
            DBHelper dB = new DBHelper();
            return dB.ProcTTPHomeData(SP_Name, System.Data.CommandType.StoredProcedure, paras);
        }
        /// <summary>
        /// 发热门诊ChartPIC
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="SPTXT"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public List<BigDataHome> FeverChartData(string StartTime, string EndTime, string SPTXT, string K)
        {
            List<BigDataHome> list = new List<BigDataHome>();
            list.Add(new BigDataHome
            {
                message = "首页数据",
                data = new List<ItmeList>()
            });

            #region 老

            //     string sql1 = "Select s.Sex,SUM(Case When age <=20 Then 1 Else 0 End) As ZoreToTwenty," +
            // "Sum(Case When age Between 21 And 40 Then 1 Else 0 End) As TwentyToFourty," +
            //"Sum(Case When age Between 41 And 60 Then 1 Else 0 End) As 'FourtyTOSixty'," +
            //"Sum(Case When age >= 61 Then 1 Else 0 End) As OnSixty From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM FeclTable  where [Data] between '" + StartTime + "' and '" + EndTime + "' ";


            //     DBHelper dB = new DBHelper();
            //     if (K == "C")
            //     {
            //         sql1 += " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE )";
            //     }
            //     if (K == "Y")
            //     {
            //         sql1 += " and HospCode='" + SPTXT + "' ";
            //     }
            //     sql1 += ") s   GROUP BY s.Sex";

            //     List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);
            //     list[0].data.Add(new ItmeList { Name = "发热门诊饼图", SelectItmeList = mzrc });
            #endregion
            string part = " ) s ";
            if (K == "C")
            {
                part = " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE ) ) s  ";
            }
            if (K == "Y")
            {
                part = " and HospCode='" + SPTXT + "' ) s  ";
            }

            string sql1 = "SELECT  'ZoreToTwenty'AS AgeDuan, SUM(counts) AS ShuLiang,s.Sex From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM FeclTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age <=20  Group BY s.Sex " +
                           "UNION ALL " +
                           "SELECT  'TwentyToFourty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM FeclTable  where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 21 And 40  Group BY s.Sex " +
                           "UNION ALL " +
                           "SELECT  'FourtyTOSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM FeclTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 41 And 60 Group BY s.Sex " +
                          "UNION ALL " +
                           "SELECT 'OnSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM FeclTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age >=61 Group BY s.Sex ";
            DBHelper dB = new DBHelper();

            List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);
            list[0].data.Add(new ItmeList { Name = "发热门诊饼图", SelectItmeList = mzrc });



            return list;
        }
        /// <summary>
        /// 发热门诊统计年龄饼状图  FeclTable
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="SPTXT"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public List<BigDataHome> FeverChartAgeData(string StartTime, string EndTime, string SPTXT, string K)
        {

            List<BigDataHome> list = new List<BigDataHome>();
            list.Add(new BigDataHome
            {
                message = "发热门诊年龄分组",
                data = new List<ItmeList>()
            });

            string part = " ) s ";
            if (K == "C")
            {
                part = " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE ) ) s  ";
            }
            if (K == "Y")
            {
                part = " and HospCode='" + SPTXT + "' ) s  ";
            }

            string sql1 = "SELECT  'ZoreToTwenty'AS AgeDuan, SUM(counts) AS ShuLiang,s.Sex From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM FeclTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age <=5  Group BY s.Sex " +
                           "UNION ALL " +
                           "SELECT  'TwentyToFourty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM FeclTable  where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 6 And 10  Group BY s.Sex " +
                           "UNION ALL " +
                           "SELECT  'FourtyTOSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM FeclTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 11 And 20 Group BY s.Sex " +
                           "UNION ALL " +
                           "SELECT  'FourtyTOSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM FeclTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 21 And 30 Group BY s.Sex " +
                            "UNION ALL " +
                           "SELECT  'FourtyTOSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM FeclTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 31 And 40 Group BY s.Sex " +
                            "UNION ALL " +
                           "SELECT  'FourtyTOSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM FeclTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 41 And 60 Group BY s.Sex " +
                           "UNION ALL " +
                           "SELECT 'OnSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM FeclTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age >=61 Group BY s.Sex ";
            DBHelper dB = new DBHelper();

            List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);
            list[0].data.Add(new ItmeList { Name = "根据年龄分组各阶段人数", SelectItmeList = mzrc });

            //    string sql1 = "Select s.Sex,SUM(Case When age <=5 Then 1 Else 0 End) As ZoreToFive," +
            //        "SUM(Case When age Between 6 And 10 Then 1 Else 0 End) As FiveToTen," +
            //        "SUM(Case When age Between 11 And 20 Then 1 Else 0 End) As TenToTwenty," +
            //      "SUM(Case When age Between 21 And 30 Then 1 Else 0 End) As TwentyToThrity," +
            //"Sum(Case When age Between 31 And 40 Then 1 Else 0 End) As ThrityToFourty," +
            //"Sum(Case When age Between 41 And 60 Then 1 Else 0 End) As FourtyTOSixty," +
            //"Sum(Case When age >= 61 Then 1 Else 0 End) As OnSixty From(SELECT *, datediff(year, Birthday, getdate()) AS age FROM FeclTable  where[Data] between '" + StartTime + "' and '" + EndTime + "'";


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

            //    List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);
            //    list[0].data.Add(new ItmeList { Name = "根据年龄分组各阶段人数", SelectItmeList = mzrc });

            return list;
        }



        #endregion

        #region 查询地区所有机构
        public string GetHospNewList(string K)
        {
            List<Dictionary<string, object>> l = GetNewList(K);
            string Key = string.Empty;
            for (int i = 0; i < l.Count; i++)
            {
                Key += "'" + l[i]["ORGCODE"].ToString() + "',";
            }
            return Key.Substring(0, Key.Length - 1);
        }
        #endregion

        #region 根据地区查询所有医院
        public List<BigDataHome> CityHospList(string City)
        {
            string sql1 = "select ORGCODE, MANAGERORGNAME FROM MediTable where ADMINISTRATIVECODE like '" + City + "%'";
            DBHelper dB = new DBHelper();
            List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);
            List<BigDataHome> list = new List<BigDataHome>();
            list.Add(new BigDataHome
            {
                message = "首页数据",
                data = new List<ItmeList>{
            new ItmeList { Name="地区医院",SelectItmeList=mzrc }
            }
            });
            return list;

        }
        #endregion

        public List<BigDataHome> CityBigDataDAL(string stat, string end, string city)
        {
            try
            {
                string k = GetHospNewList(city);
                DBHelper dB = new DBHelper();
                string sql1 = "select SUM(PsitDay) as '门诊人次' from Stocdata WHIT (NOLOCK) where [Data] between '" + stat + "' and '" + end + "' and HospCode in (" + k + ")";
                List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);


                List<BigDataHome> list = new List<BigDataHome>();
                list.Add(new BigDataHome
                {
                    message = "首页数据",
                    data = new List<ItmeList>{
            new ItmeList { Name="门诊人次",SelectItmeList=mzrc }}
                });
                return list;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 门诊数据饼状图
        /// </summary>
        /// <param name="StateTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="SPTXT"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public List<BigDataHome> IllTypeBigDataBySick(string StateTime, string EndTime, string SPTXT, string K)
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

                string sql1 = "SELECT '" + item + "' as name, 'ZoreToTwenty'AS AgeDuan, SUM(TnoiDay) AS ShuLiang,s.Sex From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM Stocdata where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + "AND  age <=20  Group BY s.Sex " +
                               "UNION ALL " +
                               "SELECT '" + item + "' as name, 'TwentyToFourty'AS AgeDuan, SUM(TnoiDay) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM Stocdata  where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + "AND  age Between 21 And 40  Group BY s.Sex " +
                               "UNION ALL " +
                               "SELECT '" + item + "' as name, 'FourtyTOSixty'AS AgeDuan, SUM(TnoiDay) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM Stocdata where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + "AND  age Between 41 And 60 Group BY s.Sex " +
                              "UNION ALL " +
                               "SELECT '" + item + "' as name, 'OnSixty'AS AgeDuan, SUM(TnoiDay) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM Stocdata where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + "AND  age >=61 Group BY s.Sex ";
                DBHelper dB = new DBHelper();

                List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);
                list[0].data.Add(new ItmeList { Name = item, SelectItmeList = mzrc });
            }
            //     foreach (var item in BingType)
            //     {

            //          string sql1 = "Select s.Sex,'" + item + "' as name,SUM(Case When age <=20 Then 1 Else 0 End) As ZoreToTwenty," +
            // "Sum(Case When age Between 21 And 40 Then 1 Else 0 End) As TwentyToFourty," +
            //"Sum(Case When age Between 41 And 60 Then 1 Else 0 End) As 'FourtyTOSixty'," +
            //"Sum(Case When age >= 61 Then 1 Else 0 End) As OnSixty From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM Stocdata  where [Data] between '" + StateTime + "' and '" + EndTime+"'";


            //         //string sql1 = "select SUM(TnoiDay) as MZRC from InberTable WITH (NOLOCK) where [Data] between " + StateTime + " and " + EndTime;
            //         DBHelper dB = new DBHelper();
            //         if (K == "C")
            //         {
            //             sql1 += " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE )";
            //         }
            //         if (K == "Y")
            //         {
            //             sql1 += " and HospCode='" + SPTXT + "'";
            //         }


            //         //if (item != "其他")
            //         //{

            //             sql1 += ") s WHERE s.DiseName LIKE '%" + item + "%' GROUP BY s.Sex";
            //         //}
            //         //else
            //         //{
            //         //    sql1 += "WHERE s.DiseName NOT LIKE '%发热%' and s.DiseName NOT LIKE '%肺炎%' and s.DiseName NOT LIKE '%心脏病%' and s.DiseName NOT LIKE '%糖尿病%' GROUP BY s.Sex";
            //         //}


            //         List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);

            //         list[0].data.Add(new ItmeList { Name = "病种", SelectItmeList = mzrc });


            //     }

            return list;
        }


        public List<BigDataHome> IllTypeBigData(string StateTime, string EndTime, string SPTXT, string K)
        {

            List<BigDataHome> list = new List<BigDataHome>();
            list.Add(new BigDataHome
            {
                message = "首页数据",
                data = new List<ItmeList>()
            });

            string part = " ) s ";
            if (K == "C")
            {
                part = " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE ) ) s  ";
            }
            if (K == "Y")
            {
                part = " and HospCode='" + SPTXT + "' ) s  ";
            }
            string sql1 = "SELECT  'ZoreToFive'AS AgeDuan, SUM(PsitDay) AS ShuLiang,s.Sex From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM Stocdata where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + " WHERE  age <=5  Group BY s.Sex " +
                         "UNION ALL " +
                         "SELECT  'SixToTen'AS AgeDuan, SUM(PsitDay) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM Stocdata  where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + " WHERE  age Between 6 And 10  Group BY s.Sex " +
                         "UNION ALL " +
                         "SELECT  'EvelTOTwenty'AS AgeDuan, SUM(PsitDay) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM Stocdata where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + " WHERE  age Between 11 And 20 Group BY s.Sex " +
                         "UNION ALL " +
                         "SELECT  'TwentyTOThirty'AS AgeDuan, SUM(PsitDay) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM Stocdata where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + " WHERE  age Between 21 And 30 Group BY s.Sex " +
                          "UNION ALL " +
                         "SELECT  'ThirtyTOFourty'AS AgeDuan, SUM(PsitDay) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM Stocdata where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + " WHERE  age Between 31 And 40 Group BY s.Sex " +
                          "UNION ALL " +
                         "SELECT  'FourtyTOSixty'AS AgeDuan, SUM(PsitDay) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM Stocdata where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + " WHERE  age Between 41 And 60 Group BY s.Sex " +
                         "UNION ALL " +
                         "SELECT 'OnSixty'AS AgeDuan, SUM(PsitDay) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM Stocdata where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + " WHERE  age >=61 Group BY s.Sex ";
            DBHelper dB = new DBHelper();
            List<Dictionary<string, object>> mzrcs = dB.GetNewList(sql1, System.Data.CommandType.Text);
            list[0].data.Add(new ItmeList { Name = "门诊根据年龄饼图", SelectItmeList = mzrcs });

            return list;
        }



        #region 医共体查询（医院下面的附属医院）
        public List<BigDataHome> GetNewCityList()
        {
            DBHelper db = new DBHelper();
            string sql = "SELECT HospCode,HospName  FROM dbo.HospRelaTable WHERE HospLevel=1";

            List<BigDataHome> list = new List<BigDataHome>();
            List<Dictionary<string, object>> mzrc = db.GetNewList(sql, System.Data.CommandType.Text);

            foreach (var item in mzrc)
            {
                BigDataHome resultItem = new BigDataHome();
                foreach (var it in item)
                {

                    if (it.Key.ToString() == "HospCode")
                    {
                        string sql1 = "SELECT * FROM dbo.HospRelaTable WHERE HospLevel=2 AND ParentCode='" + it.Value.ToString() + "'";
                        List<Dictionary<string, object>> mzrcs = db.GetNewList(sql1, System.Data.CommandType.Text);

                        resultItem.data = new List<ItmeList>{
                        new ItmeList { Name=it.Value.ToString(),SelectItmeList=mzrcs }
                         };
                    }
                    if (it.Key.ToString() == "HospName")
                    {
                        resultItem.message = it.Value.ToString();
                    }

                }
                list.Add(resultItem);
            }
            return list;
        }
        #endregion
    }
}
