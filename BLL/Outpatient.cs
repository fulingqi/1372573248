using Core.Responese;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    /// <summary>
    /// 门诊类
    /// </summary>
    public class Outpatient
    {
        #region 查询地区所有机构
        public string GetNewList(string K)
        {
            BigDataDAL dal = new BigDataDAL();
            List<Dictionary<string, object>> l = dal.GetNewList(K);
            string Key = string.Empty;
            for (int i = 0; i < l.Count; i++)
            {
                Key += "'" + l[i]["ORGCODE"].ToString() + "',";
            }
            return Key.Substring(0, Key.Length - 1);
        }
        #endregion


        #region 门诊数据
        /// <summary>
        /// 大数据接口
        /// </summary>
        /// <param name="StateTime"></param>   
        /// <param name="EndTime"></param>
        /// <param name="SPTXT">医院编号</param>
        /// <param name="K"></param>
        /// <returns></returns>
        public List<BigDataHome> BigDataBLL(string StateTime, string EndTime, string SPTXT, string K)
        {
            try
            {
                BigDataDAL dal = new BigDataDAL();
                SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@StateTime",SqlDbType.VarChar,50),
                new SqlParameter("@EndTime",SqlDbType.VarChar,50),
                new SqlParameter("@HospCode",SqlDbType.VarChar,200),
                new SqlParameter("@type",SqlDbType.VarChar,200)
                 };
                paras[0].Value = StateTime;
                paras[1].Value = EndTime;
                paras[2].Value = SPTXT;
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
                return dal.HomeBigDataDAL("SP_PHASE1_HomeData", paras);
            }
            catch (Exception e)
            {
                return new List<BigDataHome>();
            }
        }
        #region 门诊数据饼状图
        /// <summary>
        /// 门诊数据饼图
        /// </summary>
        /// <param name="StateTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="SPTXT"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public List<BigDataHome> GetOutpatientData(string StateTime, string EndTime, string SPTXT, string K)
        {
            BigDataDAL dal = new BigDataDAL();
            return dal.IllTypeBigData(StateTime, EndTime, SPTXT, K);
        }
        #endregion


        #endregion


        #region 二期（发热门诊）
        public List<BigDataHome> BigTTPDataBLL(string StateTime, string EndTime, string K, int n)
        {
            BigDataDAL dal = new BigDataDAL();
            if (n == 0)
            {
                SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@StateTime",StateTime),
                new SqlParameter("@EndTime",EndTime)
                 };
                return dal.HomeTTPBigDataDAL("SP_TTP_HomeBigData", paras);
            }
            if (n == 1)
            {
                SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@StateTime",StateTime),
                new SqlParameter("@EndTime",EndTime),
                new SqlParameter("@HospCode",K) };
                return dal.HomeTTPBigDataDAL("SP_TTP_HospBigData", paras);
            }
            if (n == 2)
            {
                SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@StateTime",StateTime),
                new SqlParameter("@EndTime",EndTime),
                new SqlParameter("@HospCode",K) };
                return dal.HomeTTPBigDataDAL("SP_TTP_CityBigData", paras);
            }
            return new List<BigDataHome>();
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
            BigDataDAL dal = new BigDataDAL();
            return dal.FeverChartData(StartTime,EndTime,SPTXT,K) ;
        }


        #endregion

        public List<BigDataHome> CityHospList(string City)
        {
            BigDataDAL dal = new BigDataDAL();
            return dal.CityHospList(City);
        }


        #region 住院数据


        public List<BigDataHome> HospLiveAgeData(string StateTime, string EndTime, string SPTXT, string K)
        {
            HospitalLiveDAL dal = new HospitalLiveDAL();
            return dal.HospLiveAgeData(StateTime,EndTime,SPTXT,K);
        }
        public List<BigDataHome> HospLiveData(string StateTime, string EndTime, string SPTXT, string K)
        {
            try
            {
                HospitalLiveDAL dal = new HospitalLiveDAL();
                SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@StartTime",SqlDbType.VarChar,50),
                new SqlParameter("@EndTime",SqlDbType.VarChar,50),
                new SqlParameter("@HospCode",SqlDbType.VarChar,200),
                new SqlParameter("@type",SqlDbType.VarChar,200)
                //new SqlParameter("@BigAge",SqlDbType.Int),
                //new SqlParameter("@SmallAge",SqlDbType.Int),
                //new SqlParameter("@DiseSpec",SqlDbType.VarChar,40)
                 };
                paras[0].Value = StateTime;
                paras[1].Value = EndTime;
                paras[2].Value = SPTXT;
                //paras[4].Value = bigAge;
                //paras[5].Value = smallAge;
                //paras[6].Value = DiscSpe;
                //paras[7].Value = Sex;

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
                return dal.HospLiveDataDAL("SP_LiveHosp", paras);
            }
            catch
            {
                return new List<BigDataHome>();
            }
        }
        #region 病种类别
        public List<BigDataHome> GetSickType(string StateTime, string EndTime, string SPTXT, string K)
        {
            HospitalLiveDAL dal = new HospitalLiveDAL();
            return dal.IllTypeBigDataDAL(StateTime, EndTime, SPTXT, K);
        }
        #endregion

        #endregion

        #region 预约挂号
        /// <summary>
        /// 预约挂号首页总数（预约人次，到诊人次，爽约人次等）
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public List<BigDataHome> BookRegisterData(string StartTime,string EndTime)
        {
            BookRegisterDAL dal = new BookRegisterDAL();
            return dal.BookRegisterData(StartTime,EndTime);
        }
        /// <summary>
        /// 预约挂号饼状图
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public List<BigDataHome> GetPieChartData(string StartTime, string EndTime)
        {
            BookRegisterDAL dal = new BookRegisterDAL();
            return dal.GetPieChartData(StartTime, EndTime);
        }


        #endregion


        #region 健康档案

        /// <summary>
        /// 表头数据（建档总数，档案调用，医院调用，个人调用）
        /// </summary>
        /// <returns></returns>
        public List<BigDataHome> HealthRecordData()
        {
            try
            {
                
                HealthRecordDAL dal = new HealthRecordDAL();

                SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@StartTime",SqlDbType.VarChar,50),
                new SqlParameter("@EndTime",SqlDbType.VarChar,50)
                 };
                paras[0].Value = "2";
                paras[1].Value = "2";
                return dal.HealthRecordDataDAL("SP_healthRecord", paras);
            }
            catch
            {
                return new List<BigDataHome>();
            }
        }


        /// <summary>
        /// 健康档案饼状图
        /// </summary>
        /// <returns></returns>
        public List<BigDataHome> HealthRecordPie()
        {
            HealthRecordDAL dal = new HealthRecordDAL();
            return dal.HealthRecordPie();
        }
        #endregion



        #region 双向转诊
        /// <summary>
        /// 双向转诊主界面数据（SP_TwoDia_Proc）
        /// </summary>
        /// <returns></returns>
        public List<BigDataHome> TwoDiaData(string StartTime, string EndTime, string SPTXT, string K)
        {
            DoubleDiagnoseDAL dal = new DoubleDiagnoseDAL();
            return dal.TwoDiaData(StartTime, EndTime,SPTXT,K) ;
        }

        /// <summary>
        /// 双向转诊饼状图Data
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public List<BigDataHome> GetTwoDiaPieChartData(string StartTime, string EndTime)
        {
            DoubleDiagnoseDAL dal = new DoubleDiagnoseDAL();
            return dal.GetTwoDiaPieChartData(StartTime, EndTime);
        }


        #endregion




    }
}
