using DAL;
using System;
using System.Data;

namespace BLL
{
    public class UserInfoBLL
    {
        /// <summary>
        /// 根据身份证与手机号进行查询
        /// </summary>
        /// <param name="IDno"></param>
        /// <returns></returns>
        public DataTable GetUserInfo(String Phone, String IDno)
        {
            UserInfoDAL dal = new UserInfoDAL();
            return dal.GetUserInfo(Phone, IDno);
        }
        /// <summary>
        /// 添加短信记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddShortMess(Models.ShortMessage model)
        {
            UserInfoDAL dal = new UserInfoDAL();
            return dal.AddShortMess(model);
        }


        public int AddUser(Models.UserInfoModel.UserInfo usfo)
        {
            UserInfoDAL dal = new UserInfoDAL();
            return dal.AddUser(usfo);
        }

        public DataTable GetRealNameAuthByIdCardHospCode(string IdCard, string HospCode)
        {
            UserInfoDAL dal = new UserInfoDAL();
            return dal.GetRealNameAuthByIdCardHospCode(IdCard, HospCode);
        }

        public int InsertRealNameAuth(String HospCode, String IdCard, String UserName, String UserPhone, String LoginUser, int State)
        {
            UserInfoDAL dal = new UserInfoDAL();
            return dal.InsertRealNameAuth(HospCode, IdCard, UserName, UserPhone, LoginUser, State);
        }


        public DataTable YZbyPhoneNumber(string Phone)
        {
            UserInfoDAL dal = new UserInfoDAL();
            return dal.YZbyPhoneNumber(Phone);
        }

        public DataTable YZbyIDno(string IDno)
        {
            UserInfoDAL dal = new UserInfoDAL();
            return dal.YZbyIDno(IDno);
        }

        public DataTable YZbyPhoneandIdno(string phone, string idno)
        {
            UserInfoDAL dal = new UserInfoDAL();
            return dal.YZbyPhoneandIdno(phone,idno);
        }
        public int updateJKK(string Healthcard, string IDno)
        {
            UserInfoDAL dal = new UserInfoDAL();
            return dal.updateJKK(Healthcard, IDno);
        }

        /// <summary>
        /// HIS用户查询
        /// </summary>
        /// <param name="idno"></param>
        /// <returns></returns>
        public DataTable Ct(String idno)
        {
            UserInfoDAL dal = new UserInfoDAL();
            return dal.Ct(idno);
        }

        /// <summary>
        /// HIS建档
        /// </summary>
        /// <returns></returns>
        public string sssa(string Name, string Sex, string CardID, string brithday)
        {
            UserInfoDAL dal = new UserInfoDAL();
            return dal.sssa(Name,Sex,CardID,brithday);
        }

        /// <summary>
        /// 检验数据库是否存在该用户
        /// row=0可以注册
        /// row=1用户已注册
        /// row=3身份证号已注册
        /// row=4手机号已注册
        /// </summary>
        /// <param name="Phone"></param>
        /// <param name="IDCard"></param>
        /// <returns></returns>
        public int CheckIDCard(string Phone, string IDCard)
        {
            UserInfoDAL dal = new UserInfoDAL();
            return dal.CheckIDCard(Phone,IDCard);
        }
    }
}
