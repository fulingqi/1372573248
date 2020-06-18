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

    /// <summary>
    /// 双向转诊(DoubleConvert)Controller
    /// </summary>
    public class DoubleConvertController : ApiController
    {
        #region 双向转诊

        #endregion
        [HttpGet]
            public EntityResult GetTwoDiaData(string StartTime, string EndTime, string SPTXT, string K)
            {
                try
                {
                    Outpatient bll = new Outpatient();
                    var result = bll.TwoDiaData(StartTime, EndTime,SPTXT,K);
                    return new EntityResult(ResultType.Success, "", result);
                }
                catch (System.Exception ex)
                {
                    return new EntityResult(ResultType.Error, "", null);
                    throw;
                }
            }
            /// <summary>
            /// 双向转诊饼状图
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            public EntityResult GetTwoDiaPieChartData(string StartTime, string EndTime,string  SPTXT,string  K)
            {
                try
                {
                    Outpatient bll = new Outpatient();
                    var result = bll.GetTwoDiaPieChartData(StartTime, EndTime, SPTXT, K);
                    return new EntityResult(ResultType.Success, "", result);
                }
                catch (System.Exception ex)
                {
                    return new EntityResult(ResultType.Error, "", null);
                    throw;
                }
            }
             /// <summary>
             /// 双向转诊根据年龄统计饼状图
             /// </summary>
             /// <param name="StartTime"></param>
             /// <param name="EndTime"></param>
             /// <param name="SPTXT"></param>
             /// <param name="K"></param>
             /// <returns></returns>
            [HttpGet]
            public EntityResult GetTwoDiaPieChartAgeData(string StartTime, string EndTime, string SPTXT, string K)
            {
            try
            {
                Outpatient bll = new Outpatient();
                var result = bll.TwoDiaPieChartAgeData(StartTime, EndTime, SPTXT, K);
                return new EntityResult(ResultType.Success, "", result);
            }
            catch (System.Exception ex)
            {
                return new EntityResult(ResultType.Error, "", null);
                throw;
            }
        }


    }
}
