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

        /// <summary>
        /// 检查检验饼状图Data
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public List<BigDataHome> GetCheckMainChartData(string StartTime, string EndTime,string SPTXT,string K)
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
            foreach (var item in BingType)
            {
                string sql1 = "Select s.Sex,'" + item + "' as name,SUM(Case When age <=20 Then 1 Else 0 End) As ZoreToTwenty," +
        "Sum(Case When age Between 21 And 40 Then 1 Else 0 End) As TwentyToFourty," +
       "Sum(Case When age Between 41 And 60 Then 1 Else 0 End) As FourtyTOSixty," +
       "Sum(Case When age >= 61 Then 1 Else 0 End) As OnSixty From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM InspTable  where [Data] between '" + StartTime + "' and '" + EndTime + "' ";


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
                sql1 += ") s  WHERE s.Chename LIKE '%" + item + "%' GROUP BY s.Sex";

                List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);
                list[0].data.Add(new ItmeList { Name = "检查饼图", SelectItmeList = mzrc });
            }
            //检验
            List<string> BingTypes = new List<string>();
            BingType.Add("肝功能");
            BingType.Add("肾功能");
            BingType.Add("尿常规");
            BingType.Add("血常规");
            BingType.Add("微量元素");
            foreach (var item in BingType)
            {
                string sql1 = "Select s.Sex,'" + item + "' as name,SUM(Case When age <=20 Then 1 Else 0 End) As ZoreToTwenty," +
        "Sum(Case When age Between 21 And 40 Then 1 Else 0 End) As TwentyToFourty," +
       "Sum(Case When age Between 41 And 60 Then 1 Else 0 End) As FourtyTOSixty," +
       "Sum(Case When age >= 61 Then 1 Else 0 End) As OnSixty From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM TestTable  where [Data] between '" + StartTime + "' and '" + EndTime + "' ";


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
                sql1 += ") s  WHERE s.Chename LIKE '%" + item + "%' GROUP BY s.Sex";

                List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);
                list[0].data.Add(new ItmeList { Name = "检验饼图", SelectItmeList = mzrc });
            }
            return list;
            
        }



        /// <summary>
        /// 检查检验根据年龄分组
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
                string sql1 ="Select s.Sex,SUM(Case When age <= 5 Then 1 Else 0 End) As ZoreToFive," +
                "SUM(Case When age Between 6 And 10 Then 1 Else 0 End) As FiveToTen," +
                "SUM(Case When age Between 11 And 20 Then 1 Else 0 End) As TenToTwenty," +
              "SUM(Case When age Between 21 And 30 Then 1 Else 0 End) As TwentyToThrity," +
        "Sum(Case When age Between 31 And 40 Then 1 Else 0 End) As ThrityToFourty," +
        "Sum(Case When age Between 41 And 60 Then 1 Else 0 End) As FourtyTOSixty," +
       "Sum(Case When age >= 61 Then 1 Else 0 End) As OnSixty From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM InspTable  where [Data] between '" + StartTime + "' and '" + EndTime + "' ";


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
                sql1 += ") s  GROUP BY s.Sex";

             List<Dictionary<string, object>> mzrc = dB.GetNewList(sql1, System.Data.CommandType.Text);
            list[0].data.Add(new ItmeList { Name = "检查根据年龄饼图", SelectItmeList = mzrc });
            string sql2 = "Select s.Sex,SUM(Case When age <= 5 Then 1 Else 0 End) As ZoreToFive," +
                "SUM(Case When age Between 6 And 10 Then 1 Else 0 End) As FiveToTen," +
                "SUM(Case When age Between 11 And 20 Then 1 Else 0 End) As TenToTwenty," +
              "SUM(Case When age Between 21 And 30 Then 1 Else 0 End) As TwentyToThrity," +
        "Sum(Case When age Between 31 And 40 Then 1 Else 0 End) As ThrityToFourty," +
        "Sum(Case When age Between 41 And 60 Then 1 Else 0 End) As FourtyTOSixty," +
       "Sum(Case When age >= 61 Then 1 Else 0 End) As OnSixty From (SELECT *, datediff(year, Birthday, getdate()) AS age FROM TestTable  where [Data] between '" + StartTime + "' and '" + EndTime + "' ";
            
            if (K == "C")
            {
                sql1 += " and exists (SELECT ORGCODE FROM  MediTable where ADMINISTRATIVECODE like '" + SPTXT + "' and HospCode=MediTable.ORGCODE )";
            }
            if (K == "Y")
            {
                sql1 += " and HospCode='" + SPTXT + "' ";
            }
            sql1 += "";
            sql1 += ") s  GROUP BY s.Sex";

            List<Dictionary<string, object>> mzrcs = dB.GetNewList(sql1, System.Data.CommandType.Text);
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
