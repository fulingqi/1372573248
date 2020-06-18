using Core.Responese;
using System;
using System.Collections.Generic;
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
                    item.Name = "";
                }
                if (item.Name == "门诊电子病历")
                {
                    item.Name = "";
                }
                if (item.Name == "门诊处方总数")
                {
                    item.Name = "";
                }
                if (item.Name == "中医处方总量")
                {
                    item.Name = "";
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
                    item.Name = "";
                }

            }
            return data;
        }

    }
}
