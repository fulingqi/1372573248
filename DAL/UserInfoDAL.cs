using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class UserInfoDAL
    {
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        public int AddUser(Models.UserInfoModel.UserInfo userinfo)
        {
            int row = 0;
            string sSQL = "INSERT INTO UserInfo(Phone,MedicareNo,SecretKey,LoginPass,Sex,RealName,BirthDate,IDno,CardType,VerifyFlag,Address,Healthcard) "
                  + " values('" + userinfo.Phone + "'"
                  + ", '" + userinfo.MedicareNo + "' "
                  + ", '" + userinfo.SecretKey + "' "
                  + ", '" + userinfo.LoginPass + "' "
                  + ",'" + userinfo.Sex + "' "
                  + ",'" + userinfo.RealName + "' "
                  + ",'" + userinfo.BirthDate + "' "
                  + ",'" + userinfo.IDno + "' "
                  + "," + userinfo.CardType + " "
                  + "," + userinfo.VerifyFlag + ",'"
                  + userinfo.Address + "','"
                  + userinfo.Healthcard + "')";
            try
            {
                row = Core.SQLHelper.EXECUTE_NONQUERY(sSQL);
            }
            catch (Exception ex)
            {
                Core.Logging.LogFile("插入数据失败[AddUser],原因:" + ex.Message);
            }
            return row;
        }

        /// <summary>
        /// 根据身份证与手机号进行查询
        /// </summary>
        /// <param name="IDno"></param>
        /// <returns></returns>
        public DataTable GetUserInfo(String Phone, String IDno)
        {
            int num = 0;
            string sql = "select * from UserInfo ";
            if (Phone != "")
            {
                sql += " Where Phone='" + Phone + "' ";
                num = 1;
            }
            if (IDno != "")
            {
                if (num == 1)
                {
                    sql += " and ";
                    num = 2;
                }
                else
                {
                    sql += " Where ";
                }
                sql += " IDno='" + IDno + "' ";
            }

            DataTable dt = new DataTable();
            try
            {
                dt = Core.SQLHelper.QUERY_DATE_TABLE(sql);
            }
            catch (Exception ex)
            {
                Core.Logging.LogFile("查询数据失败[GetUserInfoById],原因:" + ex.Message);
            }
            return dt;
        }

        public DataTable GetRealNameAuthByIdCardHospCode(string IdCard, string HospCode)
        {
            string sSQL = "select * from RealNameAuth where IdCard ='" + IdCard + "' and HospCode ='" + HospCode + "'";
            DataTable dt = new DataTable();
            try
            {
                dt = Core.SQLHelper.QUERY_DATE_TABLE(sSQL);
            }
            catch (Exception ex)
            {
                Core.Logging.LogFile("查询数据失败[GetRealNameAuthByIdCardHospCode],原因:" + ex.Message);
            }
            return dt;
        }

        public int InsertRealNameAuth(String HospCode, String IdCard, String UserName, String UserPhone, String LoginUser, int State)
        {
            int row = 0;
            string sSQL = "INSERT INTO RealNameAuth(HospCode,IdCard,UserName,UserPhone,CreatedOn,LoginUser,State) "
                  + " values('" + HospCode + "'"
                  + ", '" + IdCard + "' "
                  + ", '" + UserName + "' "
                  + ",'" + UserPhone + "' "
                  + ",'" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "' "
                  + ",'" + LoginUser + "' "
                  + "," + State + ")";
            try
            {
                row = Core.SQLHelper.EXECUTE_NONQUERY(sSQL);
            }
            catch (Exception ex)
            {
                Core.Logging.LogFile("插入数据失败[InsertRealNameAuth],原因:" + ex.Message);
            }
            return row;

        }

        public DataTable YZbyPhoneNumber(string Phone)
        {

            string sSQL = "select * from UserInfo where Phone ='" + Phone + "'";
            DataTable dt = new DataTable();
            try
            {
                dt = Core.SQLHelper.QUERY_DATE_TABLE(sSQL);
            }
            catch (Exception ex)
            {
                Core.Logging.LogFile("查询数据失败[GetRealNameAuthByIdCardHospCode],原因:" + ex.Message);
            }
            return dt;
        }

        public DataTable YZbyIDno(string IDno)
        {
            string sSQL = "select * from UserInfo where IDno ='" + IDno + "'";
            DataTable dt = new DataTable();
            try
            {
                dt = Core.SQLHelper.QUERY_DATE_TABLE(sSQL);
            }
            catch (Exception ex)
            {
                Core.Logging.LogFile("查询数据失败[GetRealNameAuthByIdCardHospCode],原因:" + ex.Message);
            }
            return dt;
        }

        /// <summary>
        /// HIS用户查询
        /// </summary>
        /// <param name="idno"></param>
        /// <returns></returns>
        public DataTable Ct(String idno)
        {
            String sql = "select top 1 zyh from jbxxk where sfzh = '" + idno + "' and fylb='00' order by insert_rq desc";
            DataTable dt = Core.SQLHelper.QUERYTABLE(sql);
            return dt;
        }

        /// <summary>
        /// HIS建档
        /// </summary>
        /// <returns></returns>
        public string sssa(string Name, string Sex, string CardID, string brithday)
        {
            // string sql = "declare @shuchu nvarchar(1000) exec jbxx_create'" + Name+"','"+Sex+"','"+CardID+"','"+brithday+"' ,@shuchu output";
            //  string sql = "declare @shuchu nvarchar(1000) exec jbxx_create '刘志伟','男','42102319980615715X','1998-06-15'  ,@shuchu output";

            SqlConnection conn = new SqlConnection("Data Source=129.9.230.1;Initial Catalog=lsrmyy;User ID=ssa;password='20031118'");

            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "[jbxx_create]";
            cmd.Connection = conn;

            cmd.CommandType = CommandType.StoredProcedure;

           // string str_yuyue_message = @""+ Name + "," + Sex + "," + CardID + "," + brithday + "";

            cmd.Parameters.Add("@xm", SqlDbType.VarChar).Value = Name;
            cmd.Parameters.Add("@xb", SqlDbType.VarChar).Value = Sex;
            cmd.Parameters.Add("@sfzh", SqlDbType.VarChar).Value = CardID;
            cmd.Parameters.Add("@csny", SqlDbType.VarChar).Value = brithday;
            //cmd.Parameters.Add("@jieguo", SqlDbType.Int, 8).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@shuchu", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            string str_result = cmd.Parameters["@shuchu"].Value.ToString();

            //DataSet dt = Core.SQLHelper.QUERY_DATE_SET1(sql);
            return str_result;
        }


        public DataTable YZbyPhoneandIdno(string phone, string idno)
        {
            string sSQL = "select * from UserInfo where Phone ='" + phone + "' and IDno = '" + idno + "'";
            DataTable dt = new DataTable();
            try
            {
                dt = Core.SQLHelper.QUERY_DATE_TABLE(sSQL);
            }
            catch (Exception ex)
            {
                Core.Logging.LogFile("查询数据失败[GetRealNameAuthByIdCardHospCode],原因:" + ex.Message);
            }
            return dt;
        }

        public int updateJKK(string Healthcard, string IDno)
        {
            int row = 0;
            string sSQL = "update UserInfo set Healthcard='" + Healthcard + "' where  IDno='" + IDno + "' and Healthcard is NULL";
            try
            {
                row = Core.SQLHelper.EXECUTE_NONQUERY(sSQL);
            }
            catch (Exception ex)
            {
                Core.Logging.LogFile("插入数据失败[AddUser],原因:" + ex.Message);
            }
            return row;
        }

        /// <summary>
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
            int row = 0;
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@IDCard",IDCard),
                new SqlParameter("@Phone",Phone) };
            string sSQL = "SELECT COUNT(1)  FROM dbo.UserInfo WHERE IDno=@IDCard OR Phone=@Phone ";
            try
            {
                row =(int)Core.SQLHelper.EXECUTE_SCALAR(sSQL, paras);
                if (row==2)
                {
                    string selIDCard = "SELECT COUNT(1)  FROM dbo.UserInfo WHERE IDno=@IDCard";
                    if ((int)Core.SQLHelper.EXECUTE_SCALAR(selIDCard,paras[0]) >0)
                    {
                        row = 3;
                    }
                    string selPhone = "SELECT COUNT(1)  FROM dbo.UserInfo WHERE Phone = @Phone";
                    if ((int)Core.SQLHelper.EXECUTE_SCALAR(selPhone, paras[1]) > 0)
                    {
                        row = 4;
                    }
                }
            }
            catch (Exception ex)
            {
                Core.Logging.LogFile("判断134数据库是否存在，原因:" + ex.Message);
            }
            return row;
        }

    }
}
