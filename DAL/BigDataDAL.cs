﻿using Core;
using Core.Responese;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class BigDataDAL
    {
        //https://github.com/QiLinQ/10.109.com.git
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
                string sql1 = "Select s.Sex,SUM(Case When age <=20 Then 1 Else 0 End) As ZoreToTwenty," +
        "Sum(Case When age Between 21 And 40 Then 1 Else 0 End) As TwentyToFourty," +
       "Sum(Case When age Between 41 And 60 Then 1 Else 0 End) As 'FourtyTOSixty'," +
       "Sum(Case When age >= 61 Then 1 Else 0 End) As OnSixty From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM FeclTable  where [Data] between '" + StartTime + "' and '" + EndTime + "' ";


                DBHelper dB = new DBHelper();
                if (K == "C")
                {
                    sql1 += " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE )";
                }
                if (K == "Y")
                {
                    sql1 += " and HospCode='" + SPTXT + "' ";
                }
                sql1 += ") s   GROUP BY s.Sex";

                List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);
                list[0].data.Add(new ItmeList { Name = "发热门诊饼图", SelectItmeList = mzrc });

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
            string sql1 = "select ORGCODE, MANAGERORGNAME from MediTable where ADMINISTRATIVECODE like '" + City + "%'";
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
        public List<BigDataHome> IllTypeBigData(string StateTime, string EndTime, string SPTXT, string K)
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
                
                 string sql1 = "Select s.Sex,'" + item + "' as name,SUM(Case When age <=20 Then 1 Else 0 End) As ZoreToTwenty," +
        "Sum(Case When age Between 21 And 40 Then 1 Else 0 End) As TwentyToFourty," +
       "Sum(Case When age Between 41 And 60 Then 1 Else 0 End) As 'FourtyTOSixty'," +
       "Sum(Case When age >= 61 Then 1 Else 0 End) As OnSixty From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM Stocdata  where [Data] between '" + StateTime + "' and '" + EndTime+"'";


                //string sql1 = "select SUM(TnoiDay) as MZRC from InberTable WITH (NOLOCK) where [Data] between " + StateTime + " and " + EndTime;
                DBHelper dB = new DBHelper();
                if (K == "C")
                {
                    sql1 += " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE )";
                }
                if (K == "Y")
                {
                    sql1 += " and HospCode='" + SPTXT + "'";
                }

               
                //if (item != "其他")
                //{

                    sql1 += ") s WHERE s.DiseName LIKE '%" + item + "%' GROUP BY s.Sex";
                //}
                //else
                //{
                //    sql1 += "WHERE s.DiseName NOT LIKE '%发热%' and s.DiseName NOT LIKE '%肺炎%' and s.DiseName NOT LIKE '%心脏病%' and s.DiseName NOT LIKE '%糖尿病%' GROUP BY s.Sex";
                //}


                List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);

                list[0].data.Add(new ItmeList { Name = "病种", SelectItmeList = mzrc });


            }

            return list;
        }

    }
}
