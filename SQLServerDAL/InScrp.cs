using System;
using System.Data;
using System.Data.SqlClient;
using psms.Model;
using psms.IDAL;
using System.Collections.Generic;
using psms.DBUtility;

namespace psms.SQLServerDAL
{
    public class InScrp : IInScrp
    {
        // Static constants

        //得到所有入库礼品信息sql
        //private const string SQL_SELECT_INSCRP_ALL = "SELECT * from INSCRP ";

        //根据入库凭证编号查询礼品信息sql
        private const string SQL_SELECT_INSCRP_BY_IN_SCRPNO = "select i.id,in_scrpno,i.p_no,p.p_name,p.unit,p.unit_price,p.cost_price,i.qnt,i.in_price from inscrp i,preinfo p where i.p_no = p.p_no and in_scrpno = @in_scrptno";

        //未做账查询
        private const string SQL_SELECT_INSCRP_FOR_ACC = "SELECT INTABLE.IN_SCRPNO, IN_OU, IN_DATE, IN_COST, IN_ACC, IN_MEMO, INSCRP.P_NO, QNT, IN_PRICE, PREINFO.P_NAME, PREINFO.ACC_QNT,UNIT_PRICE " +
            "FROM INTABLE, INSCRP, PREINFO " +
            "WHERE IN_ACC<>1 AND INTABLE.IN_SCRPNO = INSCRP.IN_SCRPNO AND INSCRP.P_NO = PREINFO.P_NO " +
            "ORDER BY INTABLE.IN_SCRPNO";


        private const string PARM_IN_SCRPNO = "@in_scrptno";

        //根据入库凭证编号查询礼品信息
        public IList<InScrpInfo> GetInScrpByInScrpno(string in_scrpno)
        {
            SqlParameter parm = new SqlParameter(PARM_IN_SCRPNO, SqlDbType.VarChar, 50);
            parm.Value = in_scrpno;

            IList<InScrpInfo> InScrpList = new List<InScrpInfo>();

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_INSCRP_BY_IN_SCRPNO, parm))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    InScrpInfo inInfoData = getInScrpInfoByDataReader(rdr);
                    //Add each item to the arraylist
                    InScrpList.Add(inInfoData);
                }
            }
            return InScrpList;
        }


        //未做账查询
        public DataTable GetInScrpForAcc()
        {
            //IList<InScrpInfo> InScrpList = new List<InScrpInfo>();

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_INSCRP_FOR_ACC))
            {
                // Scroll through the results

                //while (rdr.Read())
                //{
                //    //SELECT INTABLE.IN_SCRPNO, IN_OU, IN_DATE, IN_COST, IN_ACC, IN_MEMO, INSCRP.P_NO, QNT, IN_PRICE, PREINFO.P_NAME, PREINFO.ACC_QNT UNIT_PRICE
                //    InScrpInfo inInfoData = new InScrpInfo(rdr.GetString(0).Trim(), rdr.GetString(1).Trim(), rdr.GetDateTime(2), rdr.GetDecimal(3),
                //        rdr.GetInt32(4), rdr.GetString(5).Trim(), rdr.GetString(6), rdr.GetInt32(7), rdr.GetDecimal(8), rdr.GetString(9).Trim(), rdr.GetInt32(10));
                //    //Add each item to the arraylist
                //    InScrpList.Add(inInfoData);
                //}
                return SqlHelper.DataReaderToTable(rdr);
            }

        }



        private InScrpInfo getInScrpInfoByDataReader(SqlDataReader rdr)
        {
            InScrpInfo inInfoData = new InScrpInfo(
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
            return inInfoData;
        }

        

       
    }
}
