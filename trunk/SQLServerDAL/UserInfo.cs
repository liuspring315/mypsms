using System;
using System.Data;
using System.Data.SqlClient;
using psms.Model;
using psms.IDAL;
using System.Collections.Generic;
using psms.DBUtility;

namespace psms.SQLServerDAL
{
    public class UserInfo : IUserInfo
    {
        // Static constants

        //得到所有用户信息sql
        private const string SQL_SELECT_USERINFO_ALL = "SELECT id,username,name,password,power from userinfo ORDER BY id ";

        //按用户编号查询用户信息sql
        private const string SQL_SELECT_USERINFO_BY_PNO1 = "SELECT * FROM USERINFO where username = @username and id <> @id";

        //修改用户信息sql
        private const string SQL_UPDATE_USERINFO = "UPDATE USERINFO set username=@username,name=@name,password=@password,power=@power"
            + " where id = @id";


        //新增用户信息sql
        private const string SQL_INSERT_USERINFO = "INSERT INTO USERINFO (username,name,password,power) values ("+
            "@username,@name,@password,@power)";

        //删除用户信息sql
        private const string SQL_DELETE_USERINFO = "delete from userinfo where id=@id";

        private const string PARM_USERNAME = "@username";
        private const string PARM_ID = "@id";

        private const string PARM_NAME = "@name";
        private const string PARM_PASSWORD = "@password";
        private const string PARM_POWER = "@power";
        //得到所有用户信�?
        public IList<UserInfoData> GetAllUserInfo()
        {
            IList<UserInfoData> allUserInfo = new List<UserInfoData>();

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text,SQL_SELECT_USERINFO_ALL))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    UserInfoData userInfoData = new UserInfoData(
                        (rdr[0] == null || rdr[0] == DBNull.Value) ? 0 : rdr.GetInt32(0),
                        (SqlHelper.GetStringValue(rdr[1])).Trim(),
                        (SqlHelper.GetStringValue(rdr[2])).Trim(),
                        (SqlHelper.GetStringValue(rdr[3])).Trim(),
                        (SqlHelper.GetStringValue(rdr[4])).Trim()
                        );
                    //Add each item to the arraylist
                    allUserInfo.Add(userInfoData);
                }
            }
            return allUserInfo;
        }

        //按用户编号查�?
        public int GetUserInfoByNo(string username,int id)
        {
            SqlParameter parm = new SqlParameter(PARM_USERNAME, SqlDbType.VarChar, 50);
            parm.Value = username;
            SqlParameter parm2 = new SqlParameter(PARM_ID, SqlDbType.Int, 4);
            parm2.Value = id;
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = parm;
            parms[1] = parm2;

            int rowCount = 0;
            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_USERINFO_BY_PNO1, parms))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    rowCount = rowCount + 1;
                }
            }
            return rowCount;
        }

        //修改用户信息
        public void updateUserInfo(UserInfoData data)
        {
            SqlParameter[] userInfoParms;
            SqlCommand cmd = new SqlCommand();
            userInfoParms = GetUpdateUserInfoParameters();
            userInfoParms[0].Value = data.Username;
            userInfoParms[1].Value = data.Name;
            userInfoParms[2].Value = data.Password;
            userInfoParms[3].Value = data.Power;
            userInfoParms[4].Value = data.Id;
            //Open a connection username,name,password,power id
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_UPDATE_USERINFO, userInfoParms);

            }
        }

        //新增用户信息
        public void insertUserInfo(UserInfoData data)
        {
            SqlParameter[] userInfoParms;
            SqlCommand cmd = new SqlCommand();
            userInfoParms = GetInsertUserInfoParameters();
            userInfoParms[0].Value = data.Username;
            userInfoParms[1].Value = data.Password;
            userInfoParms[2].Value = data.Name;
            userInfoParms[3].Value = data.Power;
            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_INSERT_USERINFO, userInfoParms);

            }
        }

        //ɾ��
        public void deleteUserInfo(int id)
        {
            SqlParameter[] IninfoParms;
            SqlCommand cmd = new SqlCommand();
            IninfoParms = GetDeleteUserInfoParameters();
            IninfoParms[0].Value = id;
            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_DELETE_USERINFO, IninfoParms);
            }
        }


        /// <summary>
        /// Internal function to get cached parameters username,name,password,power id
        /// </summary>
        /// 
        /// <returns></returns>
        private static SqlParameter[] GetUpdateUserInfoParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_UPDATE_USERINFO);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARM_USERNAME, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_NAME, SqlDbType.VarChar, 50),
                    new SqlParameter(PARM_PASSWORD, SqlDbType.VarChar, 50),
                    new SqlParameter(PARM_POWER, SqlDbType.VarChar, 50),
                    new SqlParameter(PARM_ID, SqlDbType.Int)};

                SqlHelper.CacheParameters(SQL_UPDATE_USERINFO, parms);
            }

            return parms;
        }

        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetInsertUserInfoParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_INSERT_USERINFO);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARM_USERNAME, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_PASSWORD, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_NAME, SqlDbType.VarChar, 50),
                    new SqlParameter(PARM_POWER, SqlDbType.VarChar, 50)};

                SqlHelper.CacheParameters(SQL_INSERT_USERINFO, parms);
            }

            return parms;
        }


        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetDeleteUserInfoParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_DELETE_USERINFO);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARM_ID, SqlDbType.Int)};

                SqlHelper.CacheParameters(SQL_DELETE_USERINFO, parms);
            }

            return parms;
        }






    }
}
