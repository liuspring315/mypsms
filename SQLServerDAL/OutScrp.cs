using System;
using System.Data;
using System.Data.SqlClient;
using psms.Model;
using psms.IDAL;
using System.Collections.Generic;
using psms.DBUtility;

namespace psms.SQLServerDAL
{
    public class OutScrp : IOutScrp
    {
        // Static constants

        //得到所有出库礼品信息信息sql
        private const string SQL_SELECT_OutScrp_ALL = "SELECT * from OutScrp ";



        //根据入库凭证编号查询礼品信息sql
        private const string SQL_SELECT_OUTSCRP_BY_OUT_SCRPNO = "select i.id,out_scrpno,i.p_no,p.p_name,p.unit,p.unit_price,p.cost_price,i.qnt,i.out_price from outscrp i,preinfo p where i.p_no = p.p_no and out_scrpno = @out_scrpno";

        //未做账查询
        private const string SQL_SELECT_OUTSCRP_FOR_ACC = "SELECT OUTTABLE.OUT_SCRPNO, OUT_OU, VIP_OU, OUT_DATE, OUT_COST, OUT_ACC, OUT_MEMO, OUTSCRP.P_NO, QNT, OUT_PRICE, PREINFO.P_NAME, PREINFO.ACC_QNT,UNIT_PRICE " +
            "FROM OUTTABLE, OUTSCRP, PREINFO " +
            "WHERE OUT_ACC<>1 AND OUTTABLE.OUT_SCRPNO = OUTSCRP.OUT_SCRPNO AND OUTSCRP.P_NO = PREINFO.P_NO " +
            "ORDER BY OUTTABLE.OUT_SCRPNO ";

        private const string PARM_OUT_SCRPNO = "@out_scrpno";

        /// <summary>
        /// 得到所有出库礼品信息信息
        /// </summary>
        /// <returns></returns>
        public IList<OutScrpInfo> GetAllOutScrp()
        {
            IList<OutScrpInfo> allOutScrp = new List<OutScrpInfo>();

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text,SQL_SELECT_OutScrp_ALL))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    OutScrpInfo outScrpInfo = getOutScrpInfoByDataReader(rdr);
                    //Add each item to the arraylist
                    allOutScrp.Add(outScrpInfo);
                }
            }
            return allOutScrp;
        }


        
        /// <summary>
        /// 得到凭证编号查询礼品信息sql
        /// </summary>
        /// <param name="out_scrpno"></param>
        /// <returns></returns>
        public IList<OutScrpInfo> GetOutScrpByOutScrpno(string out_scrpno)
        {
            SqlParameter parm = new SqlParameter(PARM_OUT_SCRPNO, SqlDbType.VarChar, 50);
            parm.Value = out_scrpno;
            IList<OutScrpInfo> allOutScrp = new List<OutScrpInfo>();

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_OUTSCRP_BY_OUT_SCRPNO,parm))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    //int id, string out_scrpno, string p_no, string p_name,string unit,decimal unit_price,
                    //decimal cost_price,int qnt, decimal out_price
                    OutScrpInfo inInfoData = new OutScrpInfo(
                        (rdr[0] == null || rdr[0] == DBNull.Value) ? 0 : rdr.GetInt32(0),
                        (SqlHelper.GetStringValue(rdr[1])).Trim(),
                        (SqlHelper.GetStringValue(rdr[2])).Trim(),
                        (SqlHelper.GetStringValue(rdr[3])).Trim(),
                        (SqlHelper.GetStringValue(rdr[4])).Trim(),
                        (rdr[5] == null || rdr[5] == DBNull.Value) ? 0 : rdr.GetDecimal(5),
                        (rdr[6] == null || rdr[6] == DBNull.Value) ? 0 : rdr.GetDecimal(6),
                        (rdr[7] == null || rdr[7] == DBNull.Value) ? 0 : rdr.GetInt32(7),
                        (rdr[8] == null || rdr[8] == DBNull.Value) ? 0 : rdr.GetDecimal(8)
                        );
                    //Add each item to the arraylist
                    allOutScrp.Add(inInfoData);
                }
            }
            return allOutScrp;
        }

        
        /// <summary>
        /// 未做账查询
        /// </summary>
        /// <returns></returns>
        public DataTable GetOutScrpForAcc()
        {
            //IList<OutScrpInfo> allOutScrp = new List<OutScrpInfo>();

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_OUTSCRP_FOR_ACC))
            {
                // Scroll through the results
                //while (rdr.Read())
                //{
                //    //string outScrpno,string out_ou,string vip_ou,DateTime out_date,decimal out_cost,int out_acc,
                //    //string out_memo,string pno,int qnt,
                //    //decimal out_price,string pname,int accqnt
                //    //OutScrpInfo inInfoData = new OutScrpInfo(rdr.GetString(0).Trim(), rdr.GetString(1).Trim(), rdr.GetString(2).Trim(), rdr.GetDateTime(3),rdr.GetDecimal(4),rdr.GetInt32(5),
                //    //        rdr.GetString(6).Trim(),rdr.GetString(7).Trim(),rdr.GetInt32(8),
                //    //        rdr.GetDecimal(9), rdr.GetString(10).Trim(), rdr.GetInt32(11));
                //    //Add each item to the arraylist
                //    //allOutScrp.Add(inInfoData);
                    
                //}
                return SqlHelper.DataReaderToTable(rdr);
            }
            //return allOutScrp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rdr"></param>
        /// <returns></returns>
        private OutScrpInfo getOutScrpInfoByDataReader(SqlDataReader rdr)
        {
            OutScrpInfo inInfoData = new OutScrpInfo(
                        (rdr[0] == null || rdr[0] == DBNull.Value) ? 0 : rdr.GetInt32(0),
                        (SqlHelper.GetStringValue(rdr[1])).Trim(),
                        (SqlHelper.GetStringValue(rdr[2])).Trim(),
                        (rdr[3] == null || rdr[3] == DBNull.Value) ? 0 : rdr.GetInt32(3),
                        (rdr[4] == null || rdr[4] == DBNull.Value) ? 0 : rdr.GetDecimal(4)
                        );
            return inInfoData;
        }




    }
}
