using System;
using System.Data;
using System.Data.SqlClient;
using psms.Model;
using psms.IDAL;
using System.Collections.Generic;
using psms.DBUtility;

namespace psms.SQLServerDAL
{
    public class CheckTable : ICheckTable
    {
        // Static constants

        //得到所有盘存信息sql
        private const string SQL_SELECT_CHECKTABLEINFO_ALL = "SELECT CHECKTABLE.id,CHECKTABLE.CHCK_NO, CHECKTABLE.CHCK_DATE, CHECKTABLE.P_NO, PREINFO.P_NAME, CHECKTABLE.ACC_QNT, CHECKTABLE.FACT_QNT, CHECKTABLE.DIFF_QNT, CHECKTABLE.CHCK_MEMO " +
                    "FROM CHECKTABLE, PREINFO " +
                    "WHERE  (CHECKTABLE.P_NO = PREINFO.P_NO) " +
                    "ORDER BY CHECKTABLE.CHCK_NO, CHECKTABLE.P_NO";
        //得到已盘存过次数
        private const string SQL_SELECT_CHECKTABLE_CHCK_NO = "SELECT MAX(CHCK_NO) AS MNO FROM CHECKTABLE ";

        //盘存查询
        private const string SQL_SELECT_CHECKTABLE_BY_CHECKNO = "SELECT CHECKTABLE.id,CHECKTABLE.CHCK_NO, CHECKTABLE.CHCK_DATE, CHECKTABLE.P_NO, PREINFO.P_NAME, CHECKTABLE.ACC_QNT, CHECKTABLE.FACT_QNT, CHECKTABLE.DIFF_QNT, CHECKTABLE.CHCK_MEMO " +
                    "FROM CHECKTABLE, PREINFO " +
                    "WHERE  (CHECKTABLE.P_NO = PREINFO.P_NO) AND (CHECKTABLE.CHCK_NO = @chck_no) " +
                    "ORDER BY CHECKTABLE.CHCK_NO, CHECKTABLE.P_NO";

        //根据Condition得到所有盘存信息sql
        private const string SQL_SELECT_CHECKTABLEINFO_BY_CONDITION = "SELECT CHECKTABLE.id,CHECKTABLE.CHCK_NO, CHECKTABLE.CHCK_DATE, CHECKTABLE.P_NO, PREINFO.P_NAME, CHECKTABLE.ACC_QNT, CHECKTABLE.FACT_QNT, CHECKTABLE.DIFF_QNT, CHECKTABLE.CHCK_MEMO " +
                    "FROM CHECKTABLE, PREINFO " +
                    "WHERE  (CHECKTABLE.P_NO = PREINFO.P_NO) ";
                    

        //3	id	int	4	0
        //0	CHCK_NO	int	4	0
        //0	CHCK_DATE	datetime	8	0
        //0	P_NO	char	15	0
        //0	ACC_QNT	int	4	1
        //0	FACT_QNT	int	4	1
        //0	DIFF_QNT	int	4	1
        //0	CHCK_MEMO	varchar	50	1
        //修改盘存信息sql
        private const string SQL_UPDATE_CHECKTABLEINFO = "UPDATE CHECKTABLE set chck_no=@chck_no,chck_date=@chck_date,p_no=@p_no," +
            "acc_qnt=@acc_qnt,fact_qnt=@fact_qnt,diff_qnt=@diff_qnt,chck_memo=@chck_memo where id = @id";

        //新增盘存信息sql
        private const string SQL_INSERT_CHECKTABLEINFO = "INSERT INTO CHECKTABLE (chck_no,chck_date,p_no,acc_qnt,fact_qnt,diff_qnt,chck_memo) values (" +
            "@chck_no,@chck_date,@p_no,@acc_qnt,@fact_qnt,@diff_qnt,@chck_memo)";

        //删除盘存信息sql
        private const string SQL_DELETE_CHECKTABLEINFO = "delete from CHECKTABLE where id=@id";

        private const string SQL_ORDERBY = " ORDER BY CHECKTABLE.CHCK_NO, CHECKTABLE.P_NO";

        private const string PARM_ID = "@id";

        private const string PARM_CHCK_NO = "@chck_no";
        private const string PARM_CHCK_DATE = "@chck_date";
        private const string PARM_P_NO = "@p_no";
        private const string PARM_ACC_QNT = "@acc_qnt";
        private const string PARM_FACT_QNT = "@fact_qnt";
        private const string PARM_DIFF_QNT = "@diff_qnt";
        private const string PARM_CHCK_MEMO = "@chck_memo";


        //得到所有盘存信息
        public IList<CheckTableInfo> GetAllCheckTableInfo()
        {
            IList<CheckTableInfo> allCheckTableInfo = new List<CheckTableInfo>();

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_CHECKTABLEINFO_ALL))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    //int id,int chck_no,DateTime chck_date,string p_no,string p_name,int acc_qnt,int fact_qnt,int diff_qnt,string chck_memo
                    //CheckTableInfo checkTableInfo = new CheckTableInfo(
                    //    (rdr[0] == null || rdr[0] == DBNull.Value) ? 0 : rdr.GetInt32(0),
                    //    (rdr[1] == null || rdr[1] == DBNull.Value) ? 0 : rdr.GetInt32(1),
                    //    (rdr[2] == null || rdr[2] == DBNull.Value) ? new System.DateTime() : rdr.GetDateTime(2),
                    //    (SqlHelper.GetStringValue(rdr[3])).Trim(),
                    //    (SqlHelper.GetStringValue(rdr[4])).Trim(),
                    //    (rdr[5] == null || rdr[5] == DBNull.Value) ? 0 : rdr.GetInt32(5),
                    //    (rdr[6] == null || rdr[6] == DBNull.Value) ? 0 : rdr.GetInt32(6),
                    //    (rdr[7] == null || rdr[7] == DBNull.Value) ? 0 : rdr.GetInt32(7),
                    //    (rdr[8] == null || rdr[8] == DBNull.Value) ? 0 : rdr.GetInt32(8)
                    //    );
                    CheckTableInfo checkTableInfo = getCheckTableInfoByDataReader(rdr);
                    //Add each item to the arraylist
                    allCheckTableInfo.Add(checkTableInfo);
                }
            }
            return allCheckTableInfo;
        }

        //根据Condition得到所有盘存信息
        public IList<CheckTableInfo> GetCheckTableInfoByCondition(string condition)
        {
            IList<CheckTableInfo> allCheckTableInfo = new List<CheckTableInfo>();

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_CHECKTABLEINFO_BY_CONDITION + condition + SQL_ORDERBY))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    //int id,int chck_no,DateTime chck_date,string p_no,string p_name,int acc_qnt,int fact_qnt,int diff_qnt,string chck_memo
                    //CheckTableInfo checkTableInfo = new CheckTableInfo(
                    //    rdr.GetInt32(0), 
                    //    rdr.GetInt32(1), 
                    //    rdr.GetDateTime(2), 
                    //    rdr.GetString(3).Trim(), 
                    //    rdr.GetString(4).Trim(), 
                    //    rdr.GetInt32(5), 
                    //    rdr.GetInt32(6), 
                    //    rdr.GetInt32(7), 
                    //    rdr.GetString(8));
                    CheckTableInfo checkTableInfo = getCheckTableInfoByDataReader(rdr);
                    //Add each item to the arraylist
                    allCheckTableInfo.Add(checkTableInfo);
                }
            }
            return allCheckTableInfo;
        }

        //盘存查询
        public IList<CheckTableInfo> GetCheckTableInfoByCheckNo(int check_no)
        {
            IList<CheckTableInfo> allCheckTableInfo = new List<CheckTableInfo>();

            SqlParameter[] checkTableParms;
            checkTableParms = GetCheckTableCheckNoParameters();
            checkTableParms[0].Value = check_no;
            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_CHECKTABLE_BY_CHECKNO, checkTableParms))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    //int id,int chck_no,DateTime chck_date,string p_no,string p_name,int acc_qnt,int fact_qnt,int diff_qnt,string chck_memo
                    //CheckTableInfo checkTableInfo = new CheckTableInfo(
                    //    rdr.GetInt32(0), 
                    //    rdr.GetInt32(1), 
                    //    rdr.GetDateTime(2), 
                    //    rdr.GetString(3).Trim(), 
                    //    rdr.GetString(4).Trim(), 
                    //    rdr.GetInt32(5), 
                    //    rdr.GetInt32(6), 
                    //    rdr.GetInt32(7), 
                    //    rdr.GetString(8));
                    CheckTableInfo checkTableInfo = getCheckTableInfoByDataReader(rdr);
                    //Add each item to the arraylist
                    allCheckTableInfo.Add(checkTableInfo);
                }
            }
            return allCheckTableInfo;
        }


        public int GetCheckNo()
        {
            int num = 0;

            //Execute the query against the database
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                // Scroll through the results
                try
                {
                    num = Int32.Parse(SqlHelper.ExecuteScalar(conn, CommandType.Text, SQL_SELECT_CHECKTABLE_CHCK_NO).ToString());
                }
                catch { }
            }
            return num;
        }


      
        //xinjian
        public bool insertCheckTableInfo(IList<CheckTableInfo> list)
        {
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    
                    for (int i = 0; i < list.Count; i++)
                    {
                        CheckTableInfo data = list[i];
                        SqlParameter[] checkTableInfoParms;
                        checkTableInfoParms = GetInsertCheckTableInfoParameters();
                        //new SqlParameter(PARM_CHCK_NO, SqlDbType.Int),
                        //new SqlParameter(PARM_CHCK_DATE, SqlDbType.DateTime),
                        //new SqlParameter(PARM_P_NO, SqlDbType.VarChar,50),
                        //new SqlParameter(PARM_ACC_QNT, SqlDbType.Int),
                        //new SqlParameter(PARM_FACT_QNT, SqlDbType.Int),
                        //new SqlParameter(PARM_DIFF_QNT, SqlDbType.Int),
                        //new SqlParameter(PARM_CHCK_MEMO, SqlDbType.VarChar,50)
                        checkTableInfoParms[0].Value = data.Chck_no;
                        checkTableInfoParms[1].Value = data.Chck_date;
                        checkTableInfoParms[2].Value = data.P_no;
                        checkTableInfoParms[3].Value = data.Acc_qnt;
                        checkTableInfoParms[4].Value = data.Fact_qnt;
                        checkTableInfoParms[5].Value = data.Diff_qnt;
                        checkTableInfoParms[6].Value = data.Chck_memo;
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SQL_INSERT_CHECKTABLEINFO, checkTableInfoParms);
                    }
                    tran.Commit();
                    conn.Close();
                    return true;

                }
                catch
                {
                    tran.Rollback();
                    conn.Close();
                    return false;
                }

            }
            
        }

        //删除
        //public void deleteVipInfo(string vip_ou)
        //{
        //    SqlParameter[] IninfoParms;
        //    SqlCommand cmd = new SqlCommand();
        //    IninfoParms = GetDeleteVipInfoParameters();
        //    IninfoParms[0].Value = vip_ou;
        //    //Open a connection
        //    using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
        //    {
        //        SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_DELETE_CHECKTABLEINFO, IninfoParms);
        //    }
        //}







        /// <summary>
        /// Internal function to get cached parameters
        /// private const string PARM_ID = "@id";

        //private const string PARM_CHCK_NO = "@chck_no";
        //private const string PARM_CHCK_DATE = "@chck_date";
        //private const string PARM_P_NO = "@p_no";
        //private const string PARM_ACC_QNT = "@acc_qnt";
        //private const string PARM_FACT_QNT = "@fact_qnt";
        //private const string PARM_DIFF_QNT = "@diff_qnt";
        //private const string PARM_CHCK_MEMO = "@chck_memo";
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetInsertCheckTableInfoParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_INSERT_CHECKTABLEINFO);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARM_CHCK_NO, SqlDbType.Int),
                    new SqlParameter(PARM_CHCK_DATE, SqlDbType.DateTime),
                    new SqlParameter(PARM_P_NO, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_ACC_QNT, SqlDbType.Int),
                    new SqlParameter(PARM_FACT_QNT, SqlDbType.Int),
                    new SqlParameter(PARM_DIFF_QNT, SqlDbType.Int),
                    new SqlParameter(PARM_CHCK_MEMO, SqlDbType.VarChar,50)};

                SqlHelper.CacheParameters(SQL_INSERT_CHECKTABLEINFO, parms);
            }

            return parms;
        }


        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetCheckTableCheckNoParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_SELECT_CHECKTABLE_BY_CHECKNO);

            if (parms == null)
            {
                parms = new SqlParameter[] {
                    new SqlParameter(PARM_CHCK_NO, SqlDbType.Int)};

                SqlHelper.CacheParameters(SQL_SELECT_CHECKTABLE_BY_CHECKNO, parms);
            }

            return parms;
        }


        private CheckTableInfo getCheckTableInfoByDataReader(SqlDataReader rdr)
        {
            CheckTableInfo checkTableInfo = new CheckTableInfo(
                        (rdr[0] == null || rdr[0] == DBNull.Value) ? 0 : rdr.GetInt32(0),
                        (rdr[1] == null || rdr[1] == DBNull.Value) ? 0 : rdr.GetInt32(1),
                        (rdr[2] == null || rdr[2] == DBNull.Value) ? new System.DateTime() : rdr.GetDateTime(2),
                        (SqlHelper.GetStringValue(rdr[3])).Trim(),
                        (SqlHelper.GetStringValue(rdr[4])).Trim(),
                        (rdr[5] == null || rdr[5] == DBNull.Value) ? 0 : rdr.GetInt32(5),
                        (rdr[6] == null || rdr[6] == DBNull.Value) ? 0 : rdr.GetInt32(6),
                        (rdr[7] == null || rdr[7] == DBNull.Value) ? 0 : rdr.GetInt32(7),
                        (SqlHelper.GetStringValue(rdr[8])).Trim()
                        );
            return checkTableInfo;
        }



    }
}
