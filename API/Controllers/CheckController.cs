using BLL;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class CheckController : ApiController
    {
        #region 检查检验

        /// <summary>
        /// 检查检验主界面数据
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="SPTXT"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        [HttpGet]
        public EntityResult GetCheckMainData(string StartTime, string EndTime, string SPTXT, string K)
        {
            try
            {
                Outpatient bll = new Outpatient();
                var result = bll.CheckMainData(StartTime, EndTime, SPTXT, K);
                return new EntityResult(ResultType.Success, "", result);
            }
            catch (System.Exception ex)
            {
                return new EntityResult(ResultType.Error, "", null);
                throw;
            }
        }

        /// <summary>
        /// 检查检验饼状图
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="SPTXT"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        [HttpGet]
        public EntityResult GetCheckMainChartData(string StartTime, string EndTime, string SPTXT, string K)
        {
            try
            {
                Outpatient bll = new Outpatient();
                var result = bll.GetCheckMainChartData(StartTime, EndTime, SPTXT, K);
                return new EntityResult(ResultType.Success, "", result);
            }
            catch (System.Exception ex)
            {
                return new EntityResult(ResultType.Error, "", null);
                throw; 
            }
        }


        [HttpGet]
        public EntityResult GetCheckMainAgeChartData(string StartTime, string EndTime, string SPTXT, string K)
        {
            try
            {
                Outpatient bll = new Outpatient();
                var result = bll.GetCheckMainAgeChartData(StartTime, EndTime, SPTXT, K);
                return new EntityResult(ResultType.Success, "", result);
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
