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
    /// 预约挂号（BookRegister）Controller
    /// </summary>
    public class BookRegisterController : ApiController
    {
        [HttpGet]
        public EntityResult GetBookRegisterData(string StartTime, string EndTime)
        {
            try
            {
                Outpatient bll = new Outpatient();
                var result = bll.BookRegisterData(StartTime, EndTime);
                return new EntityResult(ResultType.Success, "", result);
            }
            catch (System.Exception ex)
            {
                return new EntityResult(ResultType.Error, "", null);
                throw;
            }
        }
        /// <summary>
        /// 预约挂号饼状图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public EntityResult GetBookRegisterChartData(string StartTime,string EndTime)
        {
            try
            {
                Outpatient bll = new Outpatient();
                var result = bll.GetPieChartData(StartTime, EndTime);
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
