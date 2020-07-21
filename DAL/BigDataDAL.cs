using Core;
using Core.Responese;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Model;

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
        /// <summary>
        /// 门诊费用和药品收费金额1111111111
        /// </summary>
        /// <param name="StateTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="SPTXT"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public List<BigDataHome> HomeBigDataGet(string StateTime, string EndTime, string SPTXT, string K)
        {
            try
            {

                DBHelper dB = new DBHelper();

                string strWhere = "";
                //获取分表的表名
                int StartYear = Convert.ToDateTime(StateTime).Year;
                int EndYear = Convert.ToDateTime(EndTime).Year;
                for (int i = StartYear; i <= EndYear; i++)
                {
                    strWhere += i.ToString() + ",";
                }
                strWhere = strWhere.TrimEnd(',');
                string sqlSelTab = " SELECT tableName FROM dbo.TableRelation WHERE yearNum IN ( " + strWhere + ")";
                List<Dictionary<string, object>> tableRela = dB.GetNewList(sqlSelTab, System.Data.CommandType.Text);
                List<Dictionary<string, object>> mzrc = new List<Dictionary<string, object>>();
                List<Dictionary<string, object>> mzrc1 = new List<Dictionary<string, object>>();
                foreach (var item in tableRela)
                {
                    foreach (var itemvalue in item.Values)
                    {
                        string tableName = itemvalue.ToString();

                        string sql1 = "select sum(Topfees) as MZSFJE from Opusdule"+ tableName + " where TopfeeType=1 and [Data] between '" + StateTime + "' and '" + EndTime + "'";

                        if (K == "C")
                        {
                            sql1 += " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE )";
                        }
                        if (K == "Y")
                        {
                            sql1 += " and HospCode='" + SPTXT + "'";
                        }
                        mzrc.AddRange(dB.GetNewList(sql1, System.Data.CommandType.Text));

                        string sql2 = "select sum(Topfees) as ZYFYZE from Opusdule"+tableName+" where TopfeeType=2 and [Data] between '" + StateTime + "' and '" + EndTime + "'";

                        if (K == "C")
                        {
                            sql2 += " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE )";
                        }
                        if (K == "Y")
                        {
                            sql2 += " and HospCode='" + SPTXT + "'";
                        }

                       mzrc1 = dB.GetNewList(sql2, System.Data.CommandType.Text);

                    }
                }

                #region 整合多表门诊费用和药品收费金额


                string results = JsonConvert.SerializeObject(mzrc, Formatting.Indented);
                List<int> ageList = JsonConvert.DeserializeObject<List<int>>(results);
                List<int> resultList = null;

                resultList.Add(ageList.Sum());

                mzrc = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(JsonConvert.SerializeObject(resultList.ToList()));

                string results1 = JsonConvert.SerializeObject(mzrc1, Formatting.Indented);
                List<int> ageList1 = JsonConvert.DeserializeObject<List<int>>(results1);
                List<int> resultList1 = null;

                resultList1.Add(ageList1.Sum());

                mzrc1 = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(JsonConvert.SerializeObject(resultList1.ToList()));

                #endregion
                //string sql1 = "select sum(Topfees) as MZSFJE from Opusdule_one where TopfeeType=1 and [Data] between '" + StateTime + "' and '" + EndTime + "'";

                //if (K == "C")
                //{
                //    sql1 += " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE )";
                //}
                //if (K == "Y")
                //{
                //    sql1 += " and HospCode='" + SPTXT + "'";
                //}

                //List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);

                //string sql2 = "select sum(Topfees) as ZYFYZE from Opusdule_one where TopfeeType=2 and [Data] between '" + StateTime + "' and '" + EndTime + "'";

                //if (K == "C")
                //{
                //    sql2 += " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE )";
                //}
                //if (K == "Y")
                //{
                //    sql2 += " and HospCode='" + SPTXT + "'";
                //}

                //List<Dictionary<string, object>> mzrc1 = dB.GetNewList(sql2, System.Data.CommandType.Text);

                List<BigDataHome> list = new List<BigDataHome>();
                list.Add(new BigDataHome
                {
                    message = "门诊费用总额",
                    data = new List<ItmeList>{
            new ItmeList { Name="门诊费用总额",SelectItmeList=mzrc }}
                });
                //修改药品收费金额
                list[0].data.Add(new ItmeList { Name = "药品收费金额", SelectItmeList = mzrc1 });

                return list;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 门诊收费趋势111111
        /// </summary>
        /// <param name="StateTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="SPTXT"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public List<BigDataHome> HomeOutMonGet(string StateTime, string EndTime, string SPTXT, string K)
        {
            try
            {
                DBHelper dB = new DBHelper();


                string strWhere = "";
                //获取分表的表名
                int StartYear = Convert.ToDateTime(StateTime).Year;
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
                        string sql1 = "   select  CONVERT(nvarchar(10),Data,120) as [Data],sum(Topfees) as Topfees from Opusdule"+tableName+"  where [Data] between '" + StateTime + "' and '" + EndTime + "'";

                        if (K == "C")
                        {
                            sql1 += " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE )";
                        }
                        if (K == "Y")
                        {
                            sql1 += " and HospCode='" + SPTXT + "'";
                        }
                        sql1 += "  Group by  CONVERT(nvarchar(10),Data,120)  order by [Data] desc ";

                        mzrc.AddRange(dB.GetNewList(sql1, System.Data.CommandType.Text));
                    }
                }


               
                //List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);


                List<BigDataHome> list = new List<BigDataHome>();
                list.Add(new BigDataHome
                {
                    message = "门诊收费趋势",
                    data = new List<ItmeList>{
            new ItmeList { Name="门诊费用趋势",SelectItmeList=mzrc }}
                });

                return list;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 当月门诊就医趋势11111111111
        /// </summary>
        /// <param name="StateTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="SPTXT"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public List<BigDataHome> HomeOutHospGet(string StateTime, string EndTime, string SPTXT, string K)
        {
            try
            {
                DBHelper dB = new DBHelper();


                string strWhere = "";
                //获取分表的表名
                int StartYear = Convert.ToDateTime(StateTime).Year;
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
                        string sql1 = "select CONVERT(nvarchar(10),WHIT.Data,120) as [Data],SUM(PsitDay) as PsitDay from Stocdata" + tableName + " WHIT (NOLOCK) where [Data] between '" + StateTime + "' and '" + EndTime + "'";

                        if (K == "C")
                        {
                            sql1 += " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE )";
                        }
                        if (K == "Y")
                        {
                            sql1 += " and HospCode='" + SPTXT + "'";
                        }
                        sql1 += "  Group by CONVERT(nvarchar(10),WHIT.Data,120) order by [Data] desc ";

                        mzrc.AddRange(dB.GetNewList(sql1, System.Data.CommandType.Text));
                    }
                }
                //List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);               
                List<BigDataHome> list = new List<BigDataHome>();
                list.Add(new BigDataHome
                {
                    message = "就医趋势",
                    data = new List<ItmeList>{
            new ItmeList { Name="门诊就医趋势",SelectItmeList=mzrc }}
                });


                return list;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 门诊人次SUM1111111111
        /// </summary>
        /// <param name="StateTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="SPTXT"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public List<BigDataHome> HomeOutCountGet(string StateTime, string EndTime, string SPTXT, string K)
        {
            try
            {

                DBHelper dB = new DBHelper();

                string strWhere = "";
                //获取分表的表名
                int StartYear = Convert.ToDateTime(StateTime).Year;
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

                        string sql1 = "select SUM(PsitDay) as MZRC from  dbo.Stocdata" + tableName + " WHIT (NOLOCK) where [Data] between '" + StateTime + "' and '" + EndTime + "' ";

                        if (K == "C")
                        {
                            sql1 += " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE )";
                        }
                        if (K == "Y")
                        {
                            sql1 += " and HospCode='" + SPTXT + "'";
                        }
                        mzrc.AddRange(dB.GetNewList(sql1, System.Data.CommandType.Text));
                    }
                }

                #region 整合多表门诊人次


                string results = JsonConvert.SerializeObject(mzrc, Formatting.Indented);
                List<int> ageList = JsonConvert.DeserializeObject<List<int>>(results);
                List<int> resultList = null;

                resultList.Add(ageList.Sum());

                mzrc = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(JsonConvert.SerializeObject(resultList.ToList()));

                #endregion





                List<BigDataHome> list = new List<BigDataHome>();
                list.Add(new BigDataHome
                {
                    message = "门诊人次",
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

            string sql1 = "SELECT  'ZoreToTwenty'AS AgeDuan, SUM(counts) AS ShuLiang,s.Sex From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM FeclTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + " WHERE  age <=20  Group BY s.Sex " +
                           "UNION ALL " +
                           "SELECT  'TwentyToFourty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM FeclTable  where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "WHERE  age Between 21 And 40  Group BY s.Sex " +
                           "UNION ALL " +
                           "SELECT  'FourtyTOSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM FeclTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "WHERE  age Between 41 And 60 Group BY s.Sex " +
                          "UNION ALL " +
                           "SELECT 'OnSixty'AS AgeDuan, SUM(counts) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM FeclTable where [Data] between '" + StartTime + "' and '" + EndTime + "'  " + part + "WHERE  age >=61 Group BY s.Sex ";
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
                string sql1 = "select SUM(PsitDay) as '门诊人次' from Stocdata_one WHIT (NOLOCK) where [Data] between '" + stat + "' and '" + end + "' and HospCode in (" + k + ")";
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
        /// 门诊数据饼状图1111111111
        /// </summary>
        /// <param name="StateTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="SPTXT"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public List<BigDataHome> IllTypeBigDataBySick(string StateTime, string EndTime, string SPTXT, string K)
        {
            DBHelper dB = new DBHelper();
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


            #region  门诊数据饼图分表
            string strWhere = "";
            //获取分表的表名
            int StartYear = Convert.ToDateTime(StateTime).Year;
            int EndYear = Convert.ToDateTime(EndTime).Year;
            for (int i = StartYear; i <= EndYear; i++)
            {
                strWhere += i.ToString() + ",";
            }
            strWhere = strWhere.TrimEnd(',');
            string sqlSelTab = " SELECT tableName FROM dbo.TableRelation WHERE yearNum IN ( " + strWhere + ")";
            List<Dictionary<string, object>> tableRela = dB.GetNewList(sqlSelTab, System.Data.CommandType.Text);
            //结果集
            List<Dictionary<string, object>> mzrcs = new List<Dictionary<string, object>>();
            //开始获取结果
            foreach (var item in tableRela)
            {
                foreach (var itemvalue in item.Values)
                {
                    string tableName = itemvalue.ToString();
                    foreach (var Sick in BingType)
                    {
                        string part = " ) s  WHERE s.Chename LIKE '%" + Sick + "%' ";
                        if (K == "C")
                        {
                            part = " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE ) ) s  WHERE s.Chename LIKE '%" + item + "%'";
                        }
                        if (K == "Y")
                        {
                            part = " and HospCode='" + SPTXT + "' ) s  WHERE s.Chename LIKE '%" + Sick + "%' ";
                        }

                        string sql1 = "SELECT '" + Sick + "' as name, 'ZoreToTwenty'AS AgeDuan, SUM(TnoiDay) AS ShuLiang,s.Sex From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM Stocdata" + tableName + " where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + "AND  age <=20  Group BY s.Sex " +
                                       "UNION ALL " +
                                       "SELECT '" + Sick + "' as name, 'TwentyToFourty'AS AgeDuan, SUM(TnoiDay) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM Stocdata" + tableName + "  where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + "AND  age Between 21 And 40  Group BY s.Sex " +
                                       "UNION ALL " +
                                       "SELECT '" + Sick + "' as name, 'FourtyTOSixty'AS AgeDuan, SUM(TnoiDay) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM Stocdata" + tableName + " where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + "AND  age Between 41 And 60 Group BY s.Sex " +
                                      "UNION ALL " +
                                       "SELECT '" + Sick + "' as name, 'OnSixty'AS AgeDuan, SUM(TnoiDay) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM Stocdata" + tableName + " where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + "AND  age >=61 Group BY s.Sex ";

                        List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);
                        list[0].data.Add(new ItmeList { Name = Sick, SelectItmeList = mzrc });
                    }
                }
            }

            #endregion
            #region 门诊根据年龄饼图（整合多表查询结果）

            string results = JsonConvert.SerializeObject(mzrcs, Formatting.Indented);
            List<AgeFourPie> ageList = JsonConvert.DeserializeObject<List<AgeFourPie>>(results);
            List<AgeFourPie> resultList = JsonConvert.DeserializeObject<List<AgeFourPie>>(results);
            foreach (var item in resultList)
            {
                var stre = ageList.Where(m => m.AgeDuan == item.AgeDuan && m.Sex == item.Sex).ToList();
                item.ShuLiang = ageList.Where(m => m.AgeDuan == item.AgeDuan && m.Sex == item.Sex).Sum(m => long.Parse(m.ShuLiang)).ToString();
            }
            //Distinct(new AgeFourPieComparer()).ToList()
            mzrcs = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(JsonConvert.SerializeObject(resultList.Distinct(new AgeFourPieComparer()).ToList()));

            #endregion



            return list;
        }

        /// <summary>
        /// 门诊数据饼图（年龄7个分类）
        /// </summary>
        /// <param name="StateTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="SPTXT"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public List<BigDataHome> IllTypeBigData(string StateTime, string EndTime, string SPTXT, string K)
        {
            DBHelper dB = new DBHelper();

            List<BigDataHome> list = new List<BigDataHome>();
            list.Add(new BigDataHome
            {
                message = "首页数据",
                data = new List<ItmeList>()
            });
            #region  分表
            string strWhere = "";
            //获取分表的表名
            int StartYear = Convert.ToDateTime(StateTime).Year;
            int EndYear = Convert.ToDateTime(EndTime).Year;
            for (int i = StartYear; i <= EndYear; i++)
            {
                strWhere += i.ToString() + ",";
            }
            strWhere = strWhere.TrimEnd(',');
            string sqlSelTab = " SELECT tableName FROM dbo.TableRelation WHERE yearNum IN ( " + strWhere + ")";
            List<Dictionary<string, object>> tableRela = dB.GetNewList(sqlSelTab, System.Data.CommandType.Text);
            //结果集
            List<Dictionary<string, object>> mzrcs = new List<Dictionary<string, object>>();
            //开始获取结果
            foreach (var item in tableRela)
            {
                foreach (var itemvalue in item.Values)
                {
                    string tableName = itemvalue.ToString();
                    string part = " ) s ";
                    if (K == "C")
                    {
                        part = " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE ) ) s  ";
                    }
                    if (K == "Y")
                    {
                        part = " and HospCode='" + SPTXT + "' ) s  ";
                    }
                    string sql1 = "SELECT  'ZoreToFive'AS AgeDuan, SUM(PsitDay) AS ShuLiang,s.Sex From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM Stocdata" + tableName + " where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + " WHERE  age <=5  Group BY s.Sex " +
                                 "UNION ALL " +
                                 "SELECT  'SixToTen'AS AgeDuan, SUM(PsitDay) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM Stocdata" + tableName + "  where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + " WHERE  age Between 6 And 10  Group BY s.Sex " +
                                 "UNION ALL " +
                                 "SELECT  'EvelTOTwenty'AS AgeDuan, SUM(PsitDay) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM Stocdata" + tableName + " where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + " WHERE  age Between 11 And 20 Group BY s.Sex " +
                                 "UNION ALL " +
                                 "SELECT  'TwentyTOThirty'AS AgeDuan, SUM(PsitDay) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM Stocdata" + tableName + " where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + " WHERE  age Between 21 And 30 Group BY s.Sex " +
                                  "UNION ALL " +
                                 "SELECT  'ThirtyTOFourty'AS AgeDuan, SUM(PsitDay) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM Stocdata" + tableName + " where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + " WHERE  age Between 31 And 40 Group BY s.Sex " +
                                  "UNION ALL " +
                                 "SELECT  'FourtyTOSixty'AS AgeDuan, SUM(PsitDay) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM Stocdata" + tableName + " where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + " WHERE  age Between 41 And 60 Group BY s.Sex " +
                                 "UNION ALL " +
                                 "SELECT 'OnSixty'AS AgeDuan, SUM(PsitDay) AS ShuLiang, s.Sex From(SELECT*, datediff(year, Birthday, getdate()) AS age FROM Stocdata" + tableName + " where [Data] between '" + StateTime + "' and '" + EndTime + "'  " + part + " WHERE  age >=61 Group BY s.Sex ";

                    mzrcs.AddRange(dB.GetNewList(sql1, System.Data.CommandType.Text));
                }
            }

            #endregion
            #region 门诊根据年龄饼图（整合多表查询结果）

            string results = JsonConvert.SerializeObject(mzrcs, Formatting.Indented);
            List<AgePie> ageList = JsonConvert.DeserializeObject<List<AgePie>>(results);
            List<AgePie> resultList = JsonConvert.DeserializeObject<List<AgePie>>(results);
            foreach (var item in resultList)
            {
                var stre = ageList.Where(m => m.AgeDuan == item.AgeDuan && m.Sex == item.Sex).ToList();
                item.ShuLiang = ageList.Where(m => m.AgeDuan == item.AgeDuan && m.Sex == item.Sex).Sum(m => long.Parse(m.ShuLiang)).ToString();
            }
            
            //var resultse = resultList.Distinct(new AgePieComparer()).ToList();
            mzrcs = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(JsonConvert.SerializeObject(resultList.Distinct(new AgePieComparer()).ToList()));

            #endregion
            
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
