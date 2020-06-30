using BLL;
using Core;
using System.Web.Http;

namespace API.Controllers
{
    public class HomeController : ApiController
    {
        #region 直属医院信息
        [HttpGet]
        public EntityResult GetZhiZhuHosp()
        {
            try
            {
                Outpatient bll = new Outpatient();
                return new EntityResult(ResultType.Success, "", bll.ZhiShuHosp());
            }
            catch (System.Exception ex)
            {
                return new EntityResult(ResultType.Error, "", null);
                throw;
            }
        }

        #endregion



        #region 门诊数据

        [HttpGet]
        public EntityResult HomeData(string StateTime, string EndTime,string SPTXT,string K)
        {
            try
            {
                Outpatient bll = new Outpatient();
                return new EntityResult(ResultType.Success, "", bll.BigDataBLL(StateTime, EndTime, SPTXT, K));
            }
            catch (System.Exception ex)
            {
                return new EntityResult(ResultType.Error, "", null);
                throw;
            }
        }
        [HttpGet]
        public EntityResult Homenum(string StateTime, string EndTime, string SPTXT, string K)
        {
            try
            {
                Outpatient bll = new Outpatient();
                return new EntityResult(ResultType.Success, "", bll.HomeBigDataGet(StateTime, EndTime, SPTXT, K));
            }
            catch (System.Exception ex)
            {
                return new EntityResult(ResultType.Error, "", null);
                throw;
            }
        }
        #region 门诊数据饼状图

        public EntityResult GetOutpatientData(string StateTime, string EndTime, string SPTXT, string K)
        {
            try
            {
                Outpatient bll = new Outpatient();
                var bls = bll.GetOutpatientData(StateTime, EndTime, SPTXT, K);
                return new EntityResult(ResultType.Success, "", bls);
            }
            catch (System.Exception ex)
            {
                return new EntityResult(ResultType.Error, "", null);
                throw;
            }
        }
        #endregion
        #endregion

        #region 二期（发热门诊）
        #region 全市数据查询
        [HttpGet]
        public EntityResult TTPHomeData(string StateTime, string EndTime)
        {
            try
            {
                Outpatient bll = new Outpatient();
                return new EntityResult(ResultType.Success, "", bll.BigTTPDataBLL(StateTime, EndTime, "", 0));
            }
            catch (System.Exception ex)
            {
                return new EntityResult(ResultType.Error, "", null);
                throw;
            }
        }
        #endregion

        #region 医院信息查询
        [HttpGet]
        public EntityResult TTPHospData(string StateTime, string EndTime, string HospCode)
        {
            try
            {
                Outpatient bll = new Outpatient();
                return new EntityResult(ResultType.Success, "", bll.BigTTPDataBLL(StateTime, EndTime, HospCode, 1));
            }
            catch (System.Exception ex)
            {
                return new EntityResult(ResultType.Error, "", null);
                throw;
            }
        }
        #endregion

        #region 根据县查询
        [HttpGet]
        public EntityResult TTPCityData(string StateTime, string EndTime, string City)
        {
            try
            {
                Outpatient bll = new Outpatient();
                return new EntityResult(ResultType.Success, "", bll.BigTTPDataBLL(StateTime, EndTime, City, 2));
            }
            catch (System.Exception ex)
            {
                return new EntityResult(ResultType.Error, "", null);
                throw;
            }
        }
        #endregion

        #region 发热门诊饼状图
        [HttpGet]
        public EntityResult GetFeverChartDataChart(string StartTime, string EndTime, string SPTXT, string K)
        {
            try
            {
                Outpatient bll = new Outpatient();
                return new EntityResult(ResultType.Success, "", bll.FeverChartData(StartTime, EndTime, SPTXT,K));
            }
            catch (System.Exception ex)
            {
                return new EntityResult(ResultType.Error, "", null);
                throw;
            }
        }
        #region 发热门诊饼状根据年龄图
        public EntityResult GetFeverChartAgeData(string StartTime, string EndTime, string SPTXT, string K)
        {
            try
            {
                Outpatient bll = new Outpatient();
                return new EntityResult(ResultType.Success, "", bll.FeverChartAgeData(StartTime, EndTime, SPTXT, K));
            }
            catch (System.Exception ex)
            {
                return new EntityResult(ResultType.Error, "", null);
                throw;
            }
        }
        #endregion
        #endregion
        #endregion

        [HttpGet]
        public EntityResult CityHospList(string City)
        {
            try
            {
                Outpatient bll = new Outpatient();
                return new EntityResult(ResultType.Success, "", bll.CityHospList(City));
            }
            catch (System.Exception ex)
            {
                return new EntityResult(ResultType.Error, "", null);
                throw;
            }
        }
        [HttpGet]
        public EntityResult GetCityHospRelaList()
        {
            try
            {
                Outpatient bll = new Outpatient();
                return new EntityResult(ResultType.Success, "", bll.GetNewCityList());
            }
            catch (System.Exception ex)
            {
                return new EntityResult(ResultType.Error, "", null);
                throw;
            }
        }

        #region 住院数据


        /// <summary>
        /// 获取住院数据
        /// </summary>
        /// <param name="StateTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="bigAge"></param>
        /// <param name="smallAge"></param>
        /// <param name="DiscSpe">病种</param>
        /// <param name="Sex">性别</param>
        /// <param name="SPTXT">医院编号</param>
        /// <param name="K">type==1 市   2县    3医院 </param>
        /// <returns></returns>
        [HttpGet]
        public EntityResult HospLiveData(string StateTime, string EndTime, string SPTXT, string K)
        {
            try
            {
                Outpatient bll = new Outpatient();
                var result = bll.HospLiveData(StateTime, EndTime, SPTXT, K);
                // bigAge, smallAge,  DiscSpe,  Sex, 
                //string bigAge, string smallAge, string DiscSpe, string Sex, 
                return new EntityResult(ResultType.Success, "", result);
            }
            catch (System.Exception ex)
            {
                return new EntityResult(ResultType.Error, "", null);
                throw;
            }
        }
        /// <summary>
        /// 获取病种类别饼状图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public EntityResult GetSickType(string StateTime, string EndTime, string SPTXT, string K)
        {
            try
            {
                Outpatient bll = new Outpatient();
                return new EntityResult(ResultType.Success, "", bll.GetSickType(StateTime, EndTime, SPTXT, K));
            }
            catch (System.Exception ex)
            {
                return new EntityResult(ResultType.Error, "", null);
                throw;
            }
        }

        /// <summary>
        /// 根据年龄统计住院人数
        /// </summary>
        /// <param name="StateTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="SPTXT"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        [HttpGet]
        public EntityResult GetHospLiveAgeData(string StateTime, string EndTime, string SPTXT, string K)
        {
            try
            {
                Outpatient bll = new Outpatient();
                var bls = bll.HospLiveAgeData(StateTime, EndTime, SPTXT, K);
                return new EntityResult(ResultType.Success, "", bls);
            }
            catch (System.Exception ex)
            {
                return new EntityResult(ResultType.Error, "", null);
                throw;
            }
        }
        #endregion

        #region 健康档案
        [HttpGet]
        public EntityResult GetHealthRecord()
        {
            try
            {
                Outpatient bll = new Outpatient();
                var bls = bll.HealthRecordData();
                return new EntityResult(ResultType.Success, "", bls);
            }
            catch (System.Exception ex)
            {
                return new EntityResult(ResultType.Error, "", null);
                throw;
            }
        }
        /// <summary>
        /// 健康档案占比
        /// </summary>
        /// <returns></returns>
        public EntityResult GetHealthRecordPie()
        {
            try
            {
                Outpatient bll = new Outpatient();
                var bls = bll.HealthRecordPie();
                return new EntityResult(ResultType.Success, "", bls);
            }

            catch (System.Exception ex)
            {
                return new EntityResult(ResultType.Error, "", null);
                throw;
            }
        }

        [HttpGet]
        public EntityResult GetHealthBookByAgeData()
        {
            try
            {
                Outpatient bll = new Outpatient();
                var bls = bll.HealthBookByAgeData();
                return new EntityResult(ResultType.Success, "", bls);
            }

            catch (System.Exception ex)
            {
                return new EntityResult(ResultType.Error, "", null);
                throw;
            }
        }
        #endregion

        


        #region 公共卫生（无年龄性别和时间）

        [HttpGet]
        public EntityResult GetPublicHealthData(string SPTXT,string K)
        {
            try
            {
                Outpatient bll = new Outpatient();
                var bls = bll.PublicHealthData(SPTXT, K);
                return new EntityResult(ResultType.Success, "", bls);
            }
            catch (System.Exception ex)
            {
                return new EntityResult(ResultType.Error, "", null);
                throw;
            }
        }
        [HttpGet]
        public EntityResult GetPuHealChildAndTotalData(string SPTXT, string K)
        {
            try
            {
                Outpatient bll = new Outpatient();
                var bls = bll.PuHealChildAndTotalData(SPTXT, K);
                return new EntityResult(ResultType.Success, "", bls);
            }
            catch (System.Exception ex)
            {
                return new EntityResult(ResultType.Error, "", null);
                throw;
            }
        }

        #endregion


    }
}