using System;
using System.Data;
using System.Data.SqlClient;
using psms.Model;
using psms.IDAL;
using System.Collections.Generic;
using psms.DBUtility;

namespace psms.SQLServerDAL
{
    public class PreAcc : IPreAcc
    {
        // Static constants

        //查询做帐
        private const string SQL_SELECT_PREACC = "SELECT IN_OUT, SCRP_NO, P_NO, QNT, COST, S_QNT, S_COST FROM PREACC";

        //新建做帐
        private const string SQL_INSERT_PREACC = "insert into PREACC (IN_OUT, SCRP_NO, P_NO, QNT, COST, S_QNT, S_COST) values " +
            "(@in_out, @scrp_no, @p_no, @qnt, @cost, @s_qnt, @s_cost)";
        
        //修改礼品库存
        private const string SQL_UPDATE_PREINFO_FOR_ACCQNT = "update PREINFO set ACC_QNT = @acc_qnt where P_NO = @p_no";

        //修改入库做账状态
        private const string SQL_UPDATE_INTABLE_INACC = "update INTABLE set IN_ACC = @in_acc where IN_SCRPNO = @in_scrpno";

        //修改出库做账状态
        private const string SQL_UPDATE_OUTTABLE_OUTACC = "update OUTTABLE set OUT_ACC = @out_acc where OUT_SCRPNO = @out_scrpno";

        private const string PARM_IN_OUT = "@in_out";
        private const string PARM_SCRP_NO = "@scrp_no";
        private const string PARM_P_NO = "@p_no";
        private const string PARM_QNT = "@qnt";
        private const string PARM_COST = "@cost";
        private const string PARM_S_QNT = "@s_qnt";
        private const string PARM_S_COST = "@s_cost";

        
        private const string PARM_IN_SCRPNO = "@in_scrpno";
        private const string PARM_OUT_SCRPNO = "@out_scrpno";
        private const string PARM_IN_ACC = "@in_acc";
        private const string PARM_OUT_ACC = "@out_acc";
        private const string PARM_ACC_QNT = "@acc_qnt";


        /// <summary>
        /// 
        /// 得到所有做帐记录
        /// </summary>
        /// <returns></returns>
        public IList<PreAccInfo> GetAllPreAcc()
        {
            IList<PreAccInfo> allPreAccInfo = new List<PreAccInfo>();

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_PREACC))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    //IN_OUT, SCRP_NO, P_NO, QNT, COST, S_QNT, S_COST FROM PREACC
                    PreAccInfo preAccData = new PreAccInfo(
                        (SqlHelper.GetStringValue(rdr[0])).Trim(),
                        (SqlHelper.GetStringValue(rdr[1])).Trim(),
                        (SqlHelper.GetStringValue(rdr[2])).Trim(),
                        (rdr[3] == null || rdr[3] == DBNull.Value) ? 0 : rdr.GetInt32(3),
                        (rdr[4] == null || rdr[4] == DBNull.Value) ? 0 : rdr.GetDecimal(4),
                        (rdr[5] == null || rdr[5] == DBNull.Value) ? 0 : rdr.GetInt32(5),
                        (rdr[6] == null || rdr[6] == DBNull.Value) ? 0 : rdr.GetDecimal(6)
                        );
                    //Add each item to the arraylist
                    allPreAccInfo.Add(preAccData);
                }
            }
            return allPreAccInfo;
        }

        /// <summary>
        /// 
        /// 做账 入库凭证
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool insertPreAccForInTable(IList<PreAccInfo> list)
        {
            
            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    
                    for (int i = 0; i < list.Count; i++)
                    {
                        PreAccInfo data = list[i];
                        SqlParameter[] PreAccParms;
                        PreAccParms = GetInsertPreAccParameters();
                        //IN_OUT, SCRP_NO, P_NO, QNT, COST, S_QNT, S_COST
                        PreAccParms[0].Value = data.In_out;
                        PreAccParms[1].Value = data.Scrp_no;
                        PreAccParms[2].Value = data.P_no;
                        PreAccParms[3].Value = data.Qnt;
                        PreAccParms[4].Value = data.Cost;
                        PreAccParms[5].Value = data.S_qnt;
                        PreAccParms[6].Value = data.S_cost;

                        //preacc
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SQL_INSERT_PREACC, PreAccParms);
                        //preinfo
                        SqlParameter[] PreInfoParms = GetUpdatePreInfoParameters();
                        PreInfoParms[0].Value = data.S_qnt;
                        PreInfoParms[1].Value = data.P_no;
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SQL_UPDATE_PREINFO_FOR_ACCQNT, PreInfoParms);
                        //intable
                        SqlParameter[] InTableParms = GetUpdateInTableParameters();
                        InTableParms[0].Value = 1;
                        InTableParms[1].Value = data.Scrp_no;
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SQL_UPDATE_INTABLE_INACC, InTableParms);
                       
                    }

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    tran.Rollback();
                    return false;
                }

            }
            return true;

        }


        /// <summary>
        /// 做账 出库凭证
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool insertPreAccForOutTable(IList<PreAccInfo> list)
        {

            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {

                    for (int i = 0; i < list.Count; i++)
                    {
                        PreAccInfo data = list[i];
                        SqlParameter[] PreAccParms;
                        PreAccParms = GetInsertPreAccParameters();
                        //IN_OUT, SCRP_NO, P_NO, QNT, COST, S_QNT, S_COST
                        PreAccParms[0].Value = data.In_out;
                        PreAccParms[1].Value = data.Scrp_no;
                        PreAccParms[2].Value = data.P_no;
                        PreAccParms[3].Value = data.Qnt;
                        PreAccParms[4].Value = data.Cost;
                        PreAccParms[5].Value = data.S_qnt;
                        PreAccParms[6].Value = data.S_cost;

                        //preacc
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SQL_INSERT_PREACC, PreAccParms);
                        //preinfo
                        SqlParameter[] PreInfoParms = GetUpdatePreInfoParameters();
                        PreInfoParms[0].Value = data.S_qnt;
                        PreInfoParms[1].Value = data.P_no;
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SQL_UPDATE_PREINFO_FOR_ACCQNT, PreInfoParms);
                        //outtable
                        SqlParameter[] OutTableParms = GetUpdateOutTableParameters();
                        OutTableParms[0].Value = 1;
                        OutTableParms[1].Value = data.Scrp_no;
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SQL_UPDATE_OUTTABLE_OUTACC, OutTableParms);

                    }

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    tran.Rollback();
                    return false;
                }

            }
            return true;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetInsertPreAccParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_INSERT_PREACC);

            if (parms == null)
            {
                //IN_OUT, SCRP_NO, P_NO, QNT, COST, S_QNT, S_COST
                parms = new SqlParameter[] {
                    new SqlParameter(PARM_IN_OUT, SqlDbType.VarChar,2),
					new SqlParameter(PARM_SCRP_NO, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_P_NO, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_QNT, SqlDbType.Int),
                    new SqlParameter(PARM_COST, SqlDbType.Decimal),
                    new SqlParameter(PARM_S_QNT, SqlDbType.Int),
                    new SqlParameter(PARM_S_COST, SqlDbType.Decimal)
                };

                SqlHelper.CacheParameters(SQL_INSERT_PREACC, parms);
            }

            return parms;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetUpdatePreInfoParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_UPDATE_PREINFO_FOR_ACCQNT);

            if (parms == null)
            {
                parms = new SqlParameter[] {
                    new SqlParameter(PARM_ACC_QNT, SqlDbType.Decimal),
                    new SqlParameter(PARM_P_NO, SqlDbType.VarChar,50)
                };

                SqlHelper.CacheParameters(SQL_UPDATE_PREINFO_FOR_ACCQNT, parms);
            }

            return parms;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetUpdateInTableParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_UPDATE_INTABLE_INACC);

            if (parms == null)
            {
                parms = new SqlParameter[] {
                    new SqlParameter(PARM_IN_ACC, SqlDbType.Int),
                    new SqlParameter(PARM_IN_SCRPNO, SqlDbType.VarChar,50)
                };

                SqlHelper.CacheParameters(SQL_UPDATE_INTABLE_INACC, parms);
            }

            return parms;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetUpdateOutTableParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_UPDATE_OUTTABLE_OUTACC);

            if (parms == null)
            {
                parms = new SqlParameter[] {
                    new SqlParameter(PARM_OUT_ACC, SqlDbType.Int),
                    new SqlParameter(PARM_OUT_SCRPNO, SqlDbType.VarChar,50)
                };

                SqlHelper.CacheParameters(SQL_UPDATE_OUTTABLE_OUTACC, parms);
            }

            return parms;
        }




    }
}
