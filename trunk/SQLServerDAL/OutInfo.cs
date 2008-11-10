using System;
using System.Data;
using System.Data.SqlClient;
using psms.Model;
using psms.IDAL;
using System.Collections.Generic;
using psms.DBUtility;

namespace psms.SQLServerDAL
{
    public class OutInfo : IOutInfo
    {
        // Static constants

        //�õ������ջ���λ��Ϣsql
        private const string SQL_SELECT_OUTINFO_ALL = "SELECT * from outinfo ";


        //�޸��ջ���λ��Ϣsql
        private const string SQL_UPDATE_OUTINFO = "UPDATE OUTINFO set out_ou=@out_ou where out_ou = @out_ou_old";

        //�����ջ���λ��Ϣsql
        private const string SQL_INSERT_OUTINFO = "INSERT INTO OUTINFO (out_ou) values (" +
            "@out_ou)";

        //ɾ���ջ���λ��Ϣsql
        private const string SQL_DELETE_OUTINFO = "delete from OUTINFO where out_ou=@out_ou";

        //�ж��ջ���λ�Ƿ��Ѵ���
        private const string SQL_SELECT_OUTINFO_BY_OUTOU = "SELECT * from outinfo where out_ou = @out_ou";

        //��������ȡ����Ʒͳ��
        private const string SQL_SELECT_OUTINFO_FOR_OUTSTAT1 = "select outinfo.out_ou," +
                "( select sum(qnt) from outscrp, outtable,preinfo " +
                       "where outscrp.out_scrpno=outtable.out_scrpno and outtable.out_ou=outinfo.out_ou and preinfo.p_no=outscrp.p_no and out_date >= @start and out_date <= @end " ;

        private const string SQL_SELECT_OUTINFO_FOR_OUTSTAT2 = ")  as sumqout, " +
                "( select sum(out_price) " +
                        "from outscrp, outtable,preinfo where outscrp.out_scrpno=outtable.out_scrpno and outtable.out_ou=outinfo.out_ou and preinfo.p_no=outscrp.p_no and out_date >= @start and out_date <= @end ";
        private const string SQL_SELECT_OUTINFO_FOR_OUTSTAT3 = ")  as sumpout " +
                "from outinfo where " +
                "( select sum(qnt) from outscrp, outtable,preinfo " +
                "where outscrp.out_scrpno=outtable.out_scrpno and outtable.out_ou=outinfo.out_ou and preinfo.p_no=outscrp.p_no and out_date >= @start and out_date < @end ";
                
        private const string SQL_SELECT_OUTINFO_FOR_OUTSTAT4 = ")  is not null ";

        private const string PARM_OUT_OU = "@out_ou";
        private const string PARM_OUT_OU_OLD = "@out_ou_old";
        private const string PARM_START = "@start";
        private const string PARM_END = "@end";

        /// <summary>
        /// �õ������ջ���λ��Ϣ
        /// </summary>
        /// <returns></returns>
        //
        public IList<OutInfoData> GetAllOutInfo()
        {
            IList<OutInfoData> allOutInfo = new List<OutInfoData>();

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text,SQL_SELECT_OUTINFO_ALL))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    OutInfoData inInfoData = new OutInfoData(
                        (SqlHelper.GetStringValue(rdr[0])).Trim()
                        );
                    //Add each item to the arraylist
                    allOutInfo.Add(inInfoData);
                }
            }
            return allOutInfo;
        }
        
        /// <summary>
        /// ��������ȡ����Ʒͳ��
        /// </summary>
        /// <returns></returns>
        public IList<IList<string>> GetOutInfoForStatOutSum(string startTime, string endTime, string condition)
        {
            IList<IList<string>> list = new List<IList<string>>();
            SqlParameter[] parms = GetOutInfoForStatOutSumParameters();
            parms[0].Value = startTime;
            parms[1].Value = endTime;
            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_OUTINFO_FOR_OUTSTAT1 + condition + 
                SQL_SELECT_OUTINFO_FOR_OUTSTAT2 + condition + SQL_SELECT_OUTINFO_FOR_OUTSTAT3 + condition + SQL_SELECT_OUTINFO_FOR_OUTSTAT4, parms))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    IList<string> data = new List<string>();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        data.Add(rdr.GetValue(i).ToString().Trim());
                    }
                    list.Add(data);
                }
            }
            return list;
        }


        /// <summary>
        /// �޸��ջ���λ��Ϣ
        /// </summary>
        /// <returns></returns>
        public void updateOutInfo(string out_ou,string out_ou_old)
        {
            SqlParameter[] OutInfoParms;
            SqlCommand cmd = new SqlCommand();
            OutInfoParms = GetUpdateOutInfoParameters();
            OutInfoParms[0].Value = out_ou;
            OutInfoParms[1].Value = out_ou_old;
            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                foreach (SqlParameter parm in OutInfoParms)
                     cmd.Parameters.Add(parm);
                  
                // Open the connection
                conn.Open();

                //Set up the command
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = SQL_UPDATE_OUTINFO;

                //Execute the query
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

            }
        }

        /// <summary>
        /// �½�
        /// </summary>
        /// <returns></returns>
        public void insertOutInfo(string data)
        {
            SqlParameter[] OutInfoParms;
            SqlCommand cmd = new SqlCommand();
            OutInfoParms = GetInsertOutInfoParameters();
            OutInfoParms[0].Value = data;
            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                foreach (SqlParameter parm in OutInfoParms)
                    cmd.Parameters.Add(parm);

                // Open the connection
                conn.Open();

                //Set up the command
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = SQL_INSERT_OUTINFO;

                //Execute the query
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

            }
        }

        /// <summary>
        /// �ж��ջ���λ�Ƿ��Ѵ���
        /// </summary>
        /// <returns></returns>
        public int GetOutInfoByOutou(string out_ou)
        {
            SqlParameter parm = new SqlParameter(PARM_OUT_OU, SqlDbType.VarChar, 50);
            parm.Value = out_ou;
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = parm;

            int rowCount = 0;
            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_OUTINFO_BY_OUTOU, parms))
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
        /// ɾ��
        /// </summary>
        /// <returns></returns>
        public void deleteOutInfo(string out_ou)
        {
            SqlParameter[] IninfoParms;
            SqlCommand cmd = new SqlCommand();
            IninfoParms = GetDeleteOutInfoParameters();
            IninfoParms[0].Value = out_ou;
            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_DELETE_OUTINFO, IninfoParms);
            }
        }

        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetUpdateOutInfoParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_UPDATE_OUTINFO);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARM_OUT_OU, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_OUT_OU_OLD, SqlDbType.VarChar, 50)};

                SqlHelper.CacheParameters(SQL_UPDATE_OUTINFO, parms);
            }

            return parms;
        }

        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetInsertOutInfoParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_INSERT_OUTINFO);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARM_OUT_OU, SqlDbType.VarChar,50)};

                SqlHelper.CacheParameters(SQL_INSERT_OUTINFO, parms);
            }

            return parms;
        }

        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetDeleteOutInfoParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_DELETE_OUTINFO);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARM_OUT_OU, SqlDbType.VarChar,50)};

                SqlHelper.CacheParameters(SQL_DELETE_OUTINFO, parms);
            }

            return parms;
        }

        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetOutInfoForStatOutSumParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_SELECT_OUTINFO_FOR_OUTSTAT1);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					
                    new SqlParameter(PARM_START, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_END, SqlDbType.VarChar,50)};

                SqlHelper.CacheParameters(SQL_SELECT_OUTINFO_FOR_OUTSTAT1, parms);
            }

            return parms;
        }



    }
}
