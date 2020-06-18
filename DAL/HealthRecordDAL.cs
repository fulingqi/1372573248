﻿using Core;
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
        /// 健康档案饼状图
        /// </summary>
        /// <returns></returns>
        public List<BigDataHome> HealthRecordPie()
        {
            DBHelper dB = new DBHelper();
            string sql = "Select s.Sex,SUM(Case When age <=20 Then 1 Else 0 End) As ZoreToTwenty,"+
        "Sum(Case When age Between 21 And 40 Then 1 Else 0 End) As TwentyToFourty,"+
       "Sum(Case When age Between 41 And 60 Then 1 Else 0 End) As FourtyTOSixty,"+
       "Sum(Case When age >= 61 Then 1 Else 0 End) As OnSixty From(SELECT *, datediff(year, Birthday, getdate()) AS age FROM InberTable)s GROUP BY s.Sex";
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

        public List<BigDataHome> HealthBookData(string StateTime, string EndTime, string SPTXT, string K)
        {

            List<BigDataHome> list = new List<BigDataHome>();
            list.Add(new BigDataHome
            {
                message = "年龄分组",
                data = new List<ItmeList>()
            });

            string sql1 = "Select s.Sex,SUM(Case When age <=5 Then 1 Else 0 End) As ZoreToFive," +
                "SUM(Case When age Between 6 And 10 Then 1 Else 0 End) As FiveToTen," +
                "SUM(Case When age Between 11 And 20 Then 1 Else 0 End) As TenToTwenty," +
              "SUM(Case When age Between 21 And 30 Then 1 Else 0 End) As TwentyToThrity," +
        "Sum(Case When age Between 31 And 40 Then 1 Else 0 End) As ThrityToFourty," +
        "Sum(Case When age Between 41 And 60 Then 1 Else 0 End) As FourtyTOSixty," +
        "Sum(Case When age >= 61 Then 1 Else 0 End) As OnSixty From(SELECT *, datediff(year, Birthday, getdate()) AS age FROM InberTable  where[Data] between '" + StateTime + "' and '" + EndTime + "'";


            DBHelper dB = new DBHelper();
            if (K == "C")
            {
                sql1 += " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE )";
            }
            if (K == "Y")
            {
                sql1 += " and HospCode='" + SPTXT + "' ";
            }
            sql1 += "";
            sql1 += ") s GROUP BY s.Sex";

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
