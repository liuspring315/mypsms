using System;
using System.Data;
using System.Data.SqlClient;
using psms.Model;
using psms.IDAL;
using System.Collections.Generic;
using psms.DBUtility;

namespace psms.SQLServerDAL
{
    public class InInfo : IInInfo
    {
        // Static constants

        //得到所有入库单位信息sql
        private const string SQL_SELECT_ININFO_ALL = "SELECT * from ininfo ";


        //修改入库单位信息sql
        private const string SQL_UPDATE_ININFO = "UPDATE ININFO set in_ou=@in_ou where in_ou = @in_ou_old";

        //新增入库单位信息sql
        private const string SQL_INSERT_ININFO = "INSERT INTO ININFO (in_ou) values (" +
            "@in_ou)";

        //删除入库单位信息sql
        private const string SQL_DELETE_ININFO = "delete from Ininfo where in_ou=@in_ou";

        //判断入库单位是否已存在
        private const string SQL_SELECT_ININFO_BY_INOU = "SELECT * from ininfo where in_ou = @in_ou";


        private const string PARM_IN_OU = "@in_ou";
        private const string PARM_IN_OU_OLD = "@in_ou_old";

        //得到所有入库单位信息
        public IList<InInfoData> GetAllInInfo()
        {
            IList<InInfoData> allInInfo = new List<InInfoData>();

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text,SQL_SELECT_ININFO_ALL))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    InInfoData inInfoData = new InInfoData(
                        (SqlHelper.GetStringValue(rdr[0])).Trim()
                        );
                    //Add each item to the arraylist
                    allInInfo.Add(inInfoData);
                }
            }
            return allInInfo;
        }


        //修改入库单位信息
        public void updateInInfo(string in_ou,string in_ou_old)
        {
            SqlParameter[] InInfoParms;
            SqlCommand cmd = new SqlCommand();
            InInfoParms = GetUpdateInInfoParameters();
            InInfoParms[0].Value = in_ou;
            InInfoParms[1].Value = in_ou_old;
            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_UPDATE_ININFO, InInfoParms);
                //foreach (SqlParameter parm in InInfoParms)
                //     cmd.Parameters.Add(parm);
                  
                //// Open the connection
                //conn.Open();

                ////Set up the command
                //cmd.Connection = conn;
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = SQL_UPDATE_ININFO;

                ////Execute the query
                //cmd.ExecuteNonQuery();
                //cmd.Parameters.Clear();

            }
        }

        //xinjian
        public void insertInInfo(string data)
        {
            SqlParameter[] InInfoParms;
            SqlCommand cmd = new SqlCommand();
            InInfoParms = GetInsertInInfoParameters();
            InInfoParms[0].Value = data;
            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_INSERT_ININFO, InInfoParms);
                //foreach (SqlParameter parm in InInfoParms)
                //    cmd.Parameters.Add(parm);

                //// Open the connection
                //conn.Open();

                ////Set up the command
                //cmd.Connection = conn;
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = SQL_INSERT_ININFO;

                ////Execute the query
                //cmd.ExecuteNonQuery();
                //cmd.Parameters.Clear();

            }
        }


        //判断入库单位是否已存在
        public int GetInInfoByInou(string in_ou)
        {
            SqlParameter parm = new SqlParameter(PARM_IN_OU, SqlDbType.VarChar, 50);
            parm.Value = in_ou;
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = parm;

            int rowCount = 0;
            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_ININFO_BY_INOU, parms))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    rowCount = rowCount + 1;
                }
            }
            return rowCount;
        }


        //删除
        public void deleteInInfo(string in_ou)
        {
            SqlParameter[] IninfoParms;
            SqlCommand cmd = new SqlCommand();
            IninfoParms = GetDeleteInInfoParameters();
            IninfoParms[0].Value = in_ou;
            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_DELETE_ININFO, IninfoParms);
            }
        }






        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetUpdateInInfoParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_UPDATE_ININFO);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARM_IN_OU, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_IN_OU_OLD, SqlDbType.VarChar, 50)};

                SqlHelper.CacheParameters(SQL_UPDATE_ININFO, parms);
            }

            return parms;
        }

        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetInsertInInfoParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_INSERT_ININFO);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARM_IN_OU, SqlDbType.VarChar,50)};

                SqlHelper.CacheParameters(SQL_INSERT_ININFO, parms);
            }

            return parms;
        }


        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetDeleteInInfoParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_DELETE_ININFO);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARM_IN_OU, SqlDbType.VarChar,50)};

                SqlHelper.CacheParameters(SQL_DELETE_ININFO, parms);
            }

            return parms;
        }







    }
}
