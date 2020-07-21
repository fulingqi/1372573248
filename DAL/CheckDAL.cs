using Core;
using Core.Responese;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{

    /// <summary>
    /// 检查检验
    /// </summary>
    public class CheckDAL
    {

        /// <summary>
        /// 检查检验主界面数据（SP_Check）
        /// </summary>
        /// <returns></returns>
        public List<BigDataHome> CheckMainData(string StartTime, string EndTime, string SPTXT, string K)
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
            return UpdateDataName(dB.ProcHomeData("SP_Check", System.Data.CommandType.StoredProcedure, paras));
        }
        //public List<BigDataHome> CheckJYan(string StartTime, string EndTime, string SPTXT, string K)
        //{
        //    return null;
        //}
        /// <summary>
        /// 检查检验饼状图Data11111111111111111
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public List<BigDataHome> GetCheckMainChartData(string StartTime, string EndTime, string SPTXT, string K)
        {
            List<string> BingType = new List<string>();
            BingType.Add("胸部");
            BingType.Add("头颅");
            BingType.Add("胃镜");
            BingType.Add("子宫");
            BingType.Add("肝、胆、脾、胰");
            List<BigDataHome> list = new List<BigDataHome>();
            list.Add(new BigDataHome
            {
                message = "首页数据",
                data = new List<ItmeList>()
            });

            DBHelper dB = new DBHelper();
            
            //检查
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

                string sql1 = "SELECT '" + item + "' as name, 'ZoreToTwenty'AS AgeDuan, SUM(counts) AS ShuLiang,s.Sex From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM InspTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age <=20  Group BY s.Sex " +
                               "UNION ALL " +
                               "SELECT '" + item + "' as name, 'TwentyToFourty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM InspTable  where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 21 And 40  Group BY s.Sex " +
                               "UNION ALL " +
                               "SELECT '" + item + "' as name, 'FourtyTOSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM InspTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 41 And 60 Group BY s.Sex " +
                              "UNION ALL " +
                               "SELECT '" + item + "' as name, 'OnSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM InspTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age >=61 Group BY s.Sex ";
               
                List<Dictionary<string, object>> mzrc1 = dB.GetNewList(sql1, System.Data.CommandType.Text);

                if (mzrc1.Count ==0)
                {
                    mzrc1.Add(new Dictionary<string, object>() { { "name", item }, { "AgeDuan", "ZoreToTwenty" }, { "Sex", 1 }, { "ShuLiang", 0 } });
                    mzrc1.Add(new Dictionary<string, object>() { { "name", item }, { "AgeDuan", "ZoreToTwenty" }, { "Sex", 2 }, { "ShuLiang", 0 } });
                    mzrc1.Add(new Dictionary<string, object>() { { "name", item }, { "AgeDuan", "TwentyToFourty" }, { "Sex", 1 }, { "ShuLiang", 0 } });
                    mzrc1.Add(new Dictionary<string, object>() { { "name", item }, { "AgeDuan", "TwentyToFourty" }, { "Sex", 2 }, { "ShuLiang", 0 } });
                    mzrc1.Add(new Dictionary<string, object>() { { "name", item }, { "AgeDuan", "FourtyTOSixty" }, { "Sex", 1 }, { "ShuLiang", 0 } });
                    mzrc1.Add(new Dictionary<string, object>() { { "name", item }, { "AgeDuan", "FourtyTOSixty" }, { "Sex", 2 }, { "ShuLiang", 0 } });
                    mzrc1.Add(new Dictionary<string, object>() { { "name", item }, { "AgeDuan", "OnSixty" }, { "Sex", 2 }, { "ShuLiang", 0 } });
                    mzrc1.Add(new Dictionary<string, object>() { { "name", item }, { "AgeDuan", "OnSixty" }, { "Sex", 1 }, { "ShuLiang", 0 } });
                }
                list[0].data.Add(new ItmeList { Name = "检查", SelectItmeList = mzrc1 });
            }
            //检验
            List<string> BingTypes = new List<string>();
            BingTypes.Add("肝功能");
            BingTypes.Add("肾功能");
            BingTypes.Add("尿常规");
            BingTypes.Add("血常规");
            BingTypes.Add("微量元素");
            string strWhere = "";
            //获取分表的表名
            int StartYear = Convert.ToDateTime(StartTime).Year;
            int EndYear = Convert.ToDateTime(EndTime).Year;
            for (int i = StartYear; i <= EndYear; i++)
            {
                strWhere += i.ToString() + ",";
            }
            strWhere = strWhere.TrimEnd(',');
            string sqlSelTab = " SELECT tableName FROM dbo.TableRelation WHERE yearNum IN ( " + strWhere + ")";
            List<Dictionary<string, object>> tableRela = dB.GetNewList(sqlSelTab, System.Data.CommandType.Text);
            List<Dictionary<string, object>> mzrc = new List<Dictionary<string, object>>();

            foreach (var item in tableRela)
            {
                
                foreach (var itemvalue in item.Values)
                {
                    string tableName = itemvalue.ToString();
                    foreach (var itemName in BingTypes)
                    {

                        string part = " ) s  WHERE s.Chename LIKE '%" + item + "%' ";
                        if (K == "C")
                        {
                            part = " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE ) ) s  WHERE s.Chename LIKE '%" + item + "%'";
                        }
                        if (K == "Y")
                        {
                            part = " and HospCode='" + SPTXT + "' ) s  WHERE s.Chename LIKE '%" + itemName + "%' ";
                        }

                        string sql1 = "SELECT '" + itemName + "' as name, 'ZoreToTwenty'AS AgeDuan, SUM(counts) AS ShuLiang,s.Sex From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM TestTable"+tableName+" where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age <=20  Group BY s.Sex " +
                                   "UNION ALL " +
                                   "SELECT '" + itemName + "' as name, 'TwentyToFourty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM TestTable" + tableName + "  where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 21 And 40  Group BY s.Sex " +
                                   "UNION ALL " +
                                   "SELECT '" + itemName + "' as name, 'FourtyTOSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM TestTable" + tableName + " where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 41 And 60 Group BY s.Sex " +
                                  "UNION ALL " +
                                   "SELECT '" + itemName + "' as name, 'OnSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM TestTable" + tableName + " where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age >=61 Group BY s.Sex ";

                        mzrc.AddRange(dB.GetNewList(sql1, System.Data.CommandType.Text));
                        if (mzrc.Count == 0)
                        {
                            mzrc.Add(new Dictionary<string, object>() { { "name", itemName }, { "AgeDuan", "ZoreToTwenty" }, { "Sex", 1 }, { "ShuLiang", 0 } });
                            mzrc.Add(new Dictionary<string, object>() { { "name", itemName }, { "AgeDuan", "ZoreToTwenty" }, { "Sex", 2 }, { "ShuLiang", 0 } });
                            mzrc.Add(new Dictionary<string, object>() { { "name", itemName }, { "AgeDuan", "TwentyToFourty" }, { "Sex", 1 }, { "ShuLiang", 0 } });
                            mzrc.Add(new Dictionary<string, object>() { { "name", itemName }, { "AgeDuan", "TwentyToFourty" }, { "Sex", 2 }, { "ShuLiang", 0 } });
                            mzrc.Add(new Dictionary<string, object>() { { "name", itemName }, { "AgeDuan", "FourtyTOSixty" }, { "Sex", 1 }, { "ShuLiang", 0 } });
                            mzrc.Add(new Dictionary<string, object>() { { "name", itemName }, { "AgeDuan", "FourtyTOSixty" }, { "Sex", 2 }, { "ShuLiang", 0 } });
                            mzrc.Add(new Dictionary<string, object>() { { "name", itemName }, { "AgeDuan", "OnSixty" }, { "Sex", 2 }, { "ShuLiang", 0 } });
                            mzrc.Add(new Dictionary<string, object>() { { "name", itemName }, { "AgeDuan", "OnSixty" }, { "Sex", 1 }, { "ShuLiang", 0 } });
                        }
                        list[0].data.Add(new ItmeList { Name = "检验", SelectItmeList = mzrc });
                    }
                }
            }

            //foreach (var item in BingTypes)
            //{

            //    string part = " ) s  WHERE s.Chename LIKE '%" + item + "%' ";
            //    if (K == "C")
            //    {
            //        part = " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE ) ) s  WHERE s.Chename LIKE '%" + item + "%'";
            //    }
            //    if (K == "Y")
            //    {
            //        part = " and HospCode='" + SPTXT + "' ) s  WHERE s.Chename LIKE '%" + item + "%' ";
            //    }

            //    string sql1 = "SELECT '" + item + "' as name, 'ZoreToTwenty'AS AgeDuan, SUM(counts) AS ShuLiang,s.Sex From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM TestTable_one where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age <=20  Group BY s.Sex " +
            //                   "UNION ALL " +
            //                   "SELECT '" + item + "' as name, 'TwentyToFourty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM TestTable_one  where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 21 And 40  Group BY s.Sex " +
            //                   "UNION ALL " +
            //                   "SELECT '" + item + "' as name, 'FourtyTOSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM TestTable_one where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 41 And 60 Group BY s.Sex " +
            //                  "UNION ALL " +
            //                   "SELECT '" + item + "' as name, 'OnSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM TestTable_one where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age >=61 Group BY s.Sex ";


            //    List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);
            //    if (mzrc.Count == 0)
            //    {
            //        mzrc.Add(new Dictionary<string, object>() { { "name", item }, { "AgeDuan", "ZoreToTwenty" }, { "Sex", 1 }, { "ShuLiang", 0 } });
            //        mzrc.Add(new Dictionary<string, object>() { { "name", item }, { "AgeDuan", "ZoreToTwenty" }, { "Sex", 2 }, { "ShuLiang", 0 } });
            //        mzrc.Add(new Dictionary<string, object>() { { "name", item }, { "AgeDuan", "TwentyToFourty" }, { "Sex", 1 }, { "ShuLiang", 0 } });
            //        mzrc.Add(new Dictionary<string, object>() { { "name", item }, { "AgeDuan", "TwentyToFourty" }, { "Sex", 2 }, { "ShuLiang", 0 } });
            //        mzrc.Add(new Dictionary<string, object>() { { "name", item }, { "AgeDuan", "FourtyTOSixty" }, { "Sex", 1 }, { "ShuLiang", 0 } });
            //        mzrc.Add(new Dictionary<string, object>() { { "name", item }, { "AgeDuan", "FourtyTOSixty" }, { "Sex", 2 }, { "ShuLiang", 0 } });
            //        mzrc.Add(new Dictionary<string, object>() { { "name", item }, { "AgeDuan", "OnSixty" }, { "Sex", 2 }, { "ShuLiang", 0 } });
            //        mzrc.Add(new Dictionary<string, object>() { { "name", item }, { "AgeDuan", "OnSixty" }, { "Sex", 1 }, { "ShuLiang", 0 } });
            //    }
            //    list[0].data.Add(new ItmeList { Name = "检验", SelectItmeList = mzrc });
            //}
            return list;

        }



        /// <summary>
        /// 检查检验根据年龄分组111111111111111
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="SPTXT"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public List<BigDataHome> GetCheckMainAgeChartData(string StartTime, string EndTime, string SPTXT, string K)
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

            string sql1 = "SELECT  'ZoreToFive'AS AgeDuan, SUM(counts) AS ShuLiang,s.Sex From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM InspTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age <=5  Group BY s.Sex " +
                           "UNION ALL " +
                           "SELECT  'SixToTen'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM InspTable  where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 6 And 10  Group BY s.Sex " +
                           "UNION ALL " +
                           "SELECT  'EvelTOTwenty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM InspTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 11 And 20 Group BY s.Sex " +
                           "UNION ALL " +
                           "SELECT  'TwentyTOThirty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM InspTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 21 And 30 Group BY s.Sex " +
                            "UNION ALL " +
                           "SELECT  'ThirtyTOFourty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM InspTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 31 And 40 Group BY s.Sex " +
                            "UNION ALL " +
                           "SELECT  'FourtyTOSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM InspTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 41 And 60 Group BY s.Sex " +
                           "UNION ALL " +
                           "SELECT 'OnSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM InspTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age >=61 Group BY s.Sex ";
            DBHelper dB = new DBHelper();

            List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);
            list[0].data.Add(new ItmeList { Name = "检查根据年龄饼图", SelectItmeList = mzrc });

            string strWhere = "";
            //获取分表的表名
            int StartYear = Convert.ToDateTime(StartTime).Year;
            int EndYear = Convert.ToDateTime(EndTime).Year;
            for (int i = StartYear; i <= EndYear; i++)
            {
                strWhere += i.ToString() + ",";
            }
            strWhere = strWhere.TrimEnd(',');
            string sqlSelTab = " SELECT tableName FROM dbo.TableRelation WHERE yearNum IN ( " + strWhere + ")";
            List<Dictionary<string, object>> tableRela = dB.GetNewList(sqlSelTab, System.Data.CommandType.Text);
            List<Dictionary<string, object>> mzrcs = new List<Dictionary<string, object>>();
            foreach (var item in tableRela)
            {
                foreach (var itemvalue in item.Values)
                {
                    string tableName = itemvalue.ToString();

                    string sql2 = "SELECT  'ZoreToFive'AS AgeDuan, SUM(counts) AS ShuLiang,s.Sex From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM TestTable"+ tableName + " where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age <=5  Group BY s.Sex " +
                                 "UNION ALL " +
                                 "SELECT  'SixToTen'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM TestTable" + tableName + "   where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 6 And 10  Group BY s.Sex " +
                                 "UNION ALL " +
                                 "SELECT  'EvelTOTwenty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM TestTable" + tableName + "  where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 11 And 20 Group BY s.Sex " +
                                 "UNION ALL " +
                                 "SELECT  'TwentyTOThirty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM TestTable" + tableName + "  where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 21 And 30 Group BY s.Sex " +
                                  "UNION ALL " +
                                 "SELECT  'ThirtyTOFourty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM TestTable" + tableName + "  where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 31 And 40 Group BY s.Sex " +
                                  "UNION ALL " +
                                 "SELECT  'FourtyTOSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM TestTable" + tableName + "  where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 41 And 60 Group BY s.Sex " +
                                 "UNION ALL " +
                                 "SELECT 'OnSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM TestTable" + tableName + "  where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age >=61 Group BY s.Sex ";
                    
                    mzrcs.AddRange(dB.GetNewList(sql2, System.Data.CommandType.Text));
                }
            }

            #region 整合多表门诊人次

            string results = JsonConvert.SerializeObject(mzrcs, Formatting.Indented);
            List<AgePie> ageList = JsonConvert.DeserializeObject<List<AgePie>>(results);
            List<AgePie> resultList = JsonConvert.DeserializeObject<List<AgePie>>(results);
            foreach (var item in resultList)
            {
                var stre = ageList.Where(m => m.AgeDuan == item.AgeDuan && m.Sex == item.Sex).ToList();
                item.ShuLiang = ageList.Where(m => m.AgeDuan == item.AgeDuan && m.Sex == item.Sex).Sum(m => long.Parse(m.ShuLiang)).ToString();
            }
            
            mzrcs = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(JsonConvert.SerializeObject(resultList.Distinct(new AgePieComparer()).ToList()));
            
            #endregion


            //string sql2 = "SELECT  'ZoreToFive'AS AgeDuan, SUM(counts) AS ShuLiang,s.Sex From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM TestTable_one where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age <=5  Group BY s.Sex " +
            //             "UNION ALL " +
            //             "SELECT  'SixToTen'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM TestTable_one  where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 6 And 10  Group BY s.Sex " +
            //             "UNION ALL " +
            //             "SELECT  'EvelTOTwenty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM TestTable_one where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 11 And 20 Group BY s.Sex " +
            //             "UNION ALL " +
            //             "SELECT  'TwentyTOThirty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM TestTable_one where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 21 And 30 Group BY s.Sex " +
            //              "UNION ALL " +
            //             "SELECT  'ThirtyTOFourty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM TestTable_one where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 31 And 40 Group BY s.Sex " +
            //              "UNION ALL " +
            //             "SELECT  'FourtyTOSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM TestTable_one where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age Between 41 And 60 Group BY s.Sex " +
            //             "UNION ALL " +
            //             "SELECT 'OnSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM TestTable_one where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "AND  age >=61 Group BY s.Sex ";

            //List<Dictionary<string, object>> mzrcs = dB.GetNewList(sql1, System.Data.CommandType.Text);
            list[0].data.Add(new ItmeList { Name = "检验根据年龄饼图", SelectItmeList = mzrcs });


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
                    item.Name = "检验数量";
                }
                if (item.Name == "门诊电子病历")
                {
                    item.Name = "检查数量";
                }
                if (item.Name == "门诊处方总数")
                {
                    item.Name = "检验上传省库";
                }
                if (item.Name == "中医处方总量")
                {
                    item.Name = "检验平台共享";
                }
                if (item.Name == "门诊费用总额")
                {
                    item.Name = "检查数量趋势";
                }
                if (item.Name == "中药费用总额")
                {
                    item.Name = "上传省库趋势";
                }
                if (item.Name == "门诊就医趋势")
                {
                    item.Name = "检查表地区";
                }
                if (item.Name == "门诊收费趋势")
                {
                    item.Name = "检验表地区";
                }
                if (item.Name == "地区")
                {
                    item.Name = "检验数量趋势";
                }

            }
            return data;
        }

    }
    
}
