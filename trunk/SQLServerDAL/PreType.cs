using System;
using System.Data;
using System.Data.SqlClient;
using psms.Model;
using psms.IDAL;
using System.Collections.Generic;
using psms.DBUtility;

namespace psms.SQLServerDAL
{
    public class PreType : IPreType
    {
        // Static constants
        private const string SQL_SELECT_PRETYPE_ALL = "SELECT typeid, typename FROM PRETYPE";

        //修改礼品系列信息sql
        private const string SQL_UPDATE_PRETYPE = "UPDATE PRETYPE set typename=@typename where typeid = @typeid";

        //新增礼品系列信息sql
        private const string SQL_INSERT_PRETYPE = "INSERT INTO PRETYPE (typename) values (" +
            "@typename)";

        //删除礼品系列信息sql
        private const string SQL_DELETE_PRETYPE = "delete from PRETYPE where typeid=@typeid";

        //判断是否已存在该礼品系列
        private const string SQL_SELECT_PRETYPE_BY_TYPENAME = "select * from PRETYPE where typename=@typename";

        private const string PARM_TYPENAME = "@typename";
        private const string PARM_TYPEID = "@typeid";
       
        /// <summary>
        /// 得到所有礼品系列
        /// </summary>
        /// <returns></returns>
        public IList<PreTypeInfo> GetAllPreTypeInfo()
        {

            IList<PreTypeInfo> preTypeList = new List<PreTypeInfo>();

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_PRETYPE_ALL))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    PreTypeInfo data = new PreTypeInfo(
                        (rdr[0] == null || rdr[0] == DBNull.Value) ? 0 : rdr.GetInt32(0),
                        (SqlHelper.GetStringValue(rdr[1])).Trim()
                    );
                    //Add each item to the arraylist
                    preTypeList.Add(data);
                }
            }
            return preTypeList;
        }

        /// <summary>
        /// 修改礼品系列信息
        /// </summary>
        /// <param name="typename"></param>
        /// <param name="typeid"></param>
        public void updatePreType(string typename, int typeid)
        {
            SqlParameter[] PreTypeParms;
            SqlCommand cmd = new SqlCommand();
            PreTypeParms = GetUpdatePreTypeParameters();
            PreTypeParms[0].Value = typename;
            PreTypeParms[1].Value = typeid;
            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_UPDATE_PRETYPE, PreTypeParms);
                //foreach (SqlParameter parm in PreTypeParms)
                //    cmd.Parameters.Add(parm);

                //// Open the connection
                //conn.Open();

                ////Set up the command
                //cmd.Connection = conn;
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = SQL_UPDATE_PRETYPE;

                ////Execute the query
                //cmd.ExecuteNonQuery();
                //cmd.Parameters.Clear();

            }
        }

        /// <summary>
        /// xinjian
        /// </summary>
        /// <param name="data"></param>

        public void insertPreType(string data)
        {
            SqlParameter[] PreTypeParms;
            SqlCommand cmd = new SqlCommand();
            PreTypeParms = GetInsertPreTypeParameters();
            PreTypeParms[0].Value = data;
            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_INSERT_PRETYPE, PreTypeParms);
                //foreach (SqlParameter parm in PreTypeParms)
                //    cmd.Parameters.Add(parm);

                //// Open the connection
                //conn.Open();

                ////Set up the command
                //cmd.Connection = conn;
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = SQL_INSERT_PRETYPE;

                ////Execute the query
                //cmd.ExecuteNonQuery();
                //cmd.Parameters.Clear();

            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="typeid"></param>
        public void deletePerType(int typeid)
        {
            SqlParameter[] PreTypeParms;
            SqlCommand cmd = new SqlCommand();
            PreTypeParms = GetDeletePreTypeParameters();
            PreTypeParms[0].Value = typeid;
            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_DELETE_PRETYPE, PreTypeParms);
            }
        }


        /// <summary>
        /// 判断礼品系列是否已存在
        /// </summary>
        /// <param name="typename"></param>
        /// <returns></returns>
        public int GetPreTypeByTypeName(string typename)
        {
            SqlParameter parm = new SqlParameter(PARM_TYPENAME, SqlDbType.VarChar, 50);
            parm.Value = typename;
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = parm;

            int rowCount = 0;
            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_PRETYPE_BY_TYPENAME, parms))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    rowCount = rowCount + 1;
                }
            }
            return rowCount;
        }


        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetUpdatePreTypeParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_UPDATE_PRETYPE);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARM_TYPENAME, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_TYPEID, SqlDbType.Int)};

                SqlHelper.CacheParameters(SQL_UPDATE_PRETYPE, parms);
            }

            return parms;
        }

        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetInsertPreTypeParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_INSERT_PRETYPE);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARM_TYPENAME, SqlDbType.VarChar,50)};

                SqlHelper.CacheParameters(SQL_INSERT_PRETYPE, parms);
            }

            return parms;
        }


        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetDeletePreTypeParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_DELETE_PRETYPE);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARM_TYPEID, SqlDbType.Int)};

                SqlHelper.CacheParameters(SQL_DELETE_PRETYPE, parms);
            }

            return parms;
        }



    }
}
