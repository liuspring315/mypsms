using System;
using System.Data;
using System.Data.SqlClient;
using psms.Model;
using psms.IDAL;
using System.Collections.Generic;
using psms.DBUtility;

namespace psms.SQLServerDAL
{
    //3	OUT_SCRPNO	char	20	0
    //0	OUT_OU	char	20	1
    //0	OUT_DATE	datetime	8	1
    //0	OUT_COST	decimal	9	1
    //0	VIP_OU	char	20	1
    //0	OUT_ACC	int	4	1
    //0	OUT_MEMO	char	40	1
    public class OutTable : IOutTable
    {
        // Static constants

        //得到所有出库凭证信息sql
        private const string SQL_SELECT_OutTable_ALL = "SELECT out_scrpno,out_ou,out_date,out_cost,"+
			"vip_ou,out_acc,out_memo from OutTable ";

        //根据条件得到出库凭证信息sql
        private const string SQL_SELECT_OUTTABLE_BY_CONDITION = "SELECT DISTINCT o.out_scrpno,out_ou,out_date,out_cost," +
            "vip_ou,out_acc,out_memo from OutTable o,OutScrp s,preInfo p where o.out_scrpno = s.out_scrpno and s.p_no = p.p_no and 1=1 ";
        
        //凭证数据统计
        private const string SQL_SELECT_OUTTABLE_FOR_OUTSTAT = "SELECT OUTTABLE.OUT_SCRPNO, OUT_OU, VIP_OU, convert(char(10),out_date,20) as outdate, OUT_COST,  (SELECT SUM(QNT) FROM OUTSCRP WHERE OUTSCRP.OUT_SCRPNO=OUTTABLE.OUT_SCRPNO) AS SUMQ,OUT_MEMO " +
            "FROM OUTTABLE WHERE 1=1 and out_date >= @start and out_date <= @end ORDER BY OUTTABLE.OUT_SCRPNO";
        //凭证数据统计
        private const string SQL_SELECT_OUTTABLE_FOR_OUTSTAT_BY_OUTSCRPNO = "SELECT OUTTABLE.OUT_SCRPNO, OUT_OU, VIP_OU, convert(char(10),out_date,20) as outdate, OUT_COST,  (SELECT SUM(QNT) FROM OUTSCRP WHERE OUTSCRP.OUT_SCRPNO=OUTTABLE.OUT_SCRPNO) AS SUMQ,OUT_MEMO " +
            "FROM OUTTABLE WHERE 1=1 ";

        private const string SQL_SELECT_OUTTABLE_SUM_OUTSTAT = "select sum(qnt) as sumqnt, sum(out_price) as sumprice " +
            "from outscrp, outtable, preinfo " +
            "where outscrp.out_scrpno=outtable.out_scrpno and outscrp.p_no=preinfo.p_no  and out_date >= @start and out_date <= @end ";

        private const string SQL_SELECT_OUTTABLE_FOR_OUTSTAT2 = "select convert(char(10),outtable.out_date,20) as outdate, outtable.out_ou, outtable.vip_ou, outscrp.p_no, preinfo.p_name, unit_price,outscrp.qnt, out_price " +
            "from outscrp, outtable, preinfo " +
            "where outscrp.out_scrpno=outtable.out_scrpno and outscrp.p_no=preinfo.p_no  and out_date >= @start and out_date <= @end ";


        //修改出库凭证信息sql
        private const string SQL_UPDATE_OUTTABLE = "UPDATE OutTable set out_ou=@out_ou,out_date=@out_date,out_cost=@out_cost,"+
            "vip_ou=@vip_ou,out_memo=@out_memo where out_scrpno = @out_scrpno";

        //新增出库凭证信息sql
        private const string SQL_INSERT_OUTTABLE = "INSERT INTO OutTable (out_scrpno,out_ou,out_date,out_cost,vip_ou,out_acc,out_memo) values (" +
            "@out_scrpno,@out_ou,@out_date,@out_cost,@vip_ou,@out_acc,@out_memo)";
        //3	id	int	4	0
        //0	OUT_SCRPNO	char	20	0
        //0	P_NO	char	20	0
        //0	QNT	int	4	1
        //0	OUT_PRICE	decimal	9	1
        private const string SQL_INSERT_OUTSCRP = "INSERT INTO OUTSCRP (out_scrpno,p_no,qnt,out_price) values (" +
            "@out_scrpno,@p_no,@qnt,@out_price)";

        private const string SQL_DELETE_OUTSCRP_BY_OUTSCRPNO = "DELETE FROM OUTSCRP where out_scrpno=@out_scrpno";

        //删除出库凭证信息sql
        //private const string SQL_DELETE_OUTTABLE = "delete from Outtable where out_scrpno=@out_scrpno";


        //统计在指定查询条件下按领取部门统计
        private const string SQL_STAT_OUTTABLE_OUTOU = "select out_ou,sum(qnt) as sumacc,sum(qnt*c.unit_price) as sumprice from outtable a,outscrp b,preinfo c where a.out_scrpno = b.out_scrpno and c.p_no = b.p_no  ";
        private const string SQL_STAT_OUTTABLE_OUTOU2 = " group by out_ou order by sumprice desc";
        private const string SQL_STAT_OUTTABLE_OUTOU_ALL = "select sum(qnt) as sumacc from outtable a,outscrp b,preinfo c where a.out_scrpno = b.out_scrpno and c.p_no = b.p_no ";
        private const string SQL_STAT_OUTTABLE_STAT_OUTOU = "select out_ou,sum(qnt) as sumacc,sum(qnt*c.unit_price) as sumprice from outtable a,outscrp b,preinfo c where a.out_scrpno = b.out_scrpno and c.p_no = b.p_no  ";
        private const string SQL_STAT_OUTTABLE_STAT_VIPOU = "select vip_ou,sum(qnt) as sumacc,sum(qnt*c.unit_price) as sumprice from outtable a,outscrp b,preinfo c where a.out_scrpno = b.out_scrpno and c.p_no = b.p_no  ";
        private const string SQL_STAT_OUTTABLE_VIPOU2 = " group by vip_ou order by sumprice desc";
        //private const string SQL_STAT_OUTTABLE_VIPOU_ALL = "select sum(qnt) as sumacc from outtable a,outscrp b,preinfo c where a.out_scrpno = b.out_scrpno and c.p_no = b.p_no ";

        /// <summary>
        /// 出库 添加礼品库存
        /// </summary>
        private const string SQL_UPDATE_PREINFO_ACCQNT = "update PREINFO set ACC_QNT = acc_qnt - @acc_qnt where P_NO = @p_no";

        /// <summary>
        /// 得到最大的出库凭证编号
        /// 2008年12月20日 修改 原来为SELECT TOP 1 OUT_SCRPNO FROM OUTTABLE ORDER BY OUT_SCRPNO DESC
        /// </summary>
        private const string SQL_SELECT_TOP_OUT_SCRPNO = "SELECT TOP 1 OUT_SCRPNO FROM OUTTABLE ORDER BY CONVERT(int,REPLACE(out_scrpno,'-','')) DESC";


        //删除出库凭证信息sql
        private const string SQL_DELETE_OUTTABLE = "delete from OUTTABLE where OUT_SCRPNO=@out_scrpno";
        private const string SQL_DELETE_OUTSCRP = "delete from OUTSCRP where OUT_SCRPNO=@out_scrpno";


        private const string PARM_OUT_SCRPNO = "@out_scrpno";
        private const string PARM_OUT_OU = "@out_ou";
        private const string PARM_OUT_DATE = "@out_date";
        private const string PARM_OUT_COST = "@out_cost";
        private const string PARM_VIP_OU = "@vip_ou";
        private const string PARM_OUT_ACC = "@out_acc";
        private const string PARM_OUT_MEMO = "@out_memo";

        private const string PARM_P_NO = "@p_no";
        private const string PARM_QNT = "@qnt";
        private const string PARM_OUT_PRICE = "@out_price";

        private const string PARM_START = "@start";
        private const string PARM_END = "@end";

        private const string PARM_ACC_QNT = "@acc_qnt";


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="out_scrpno"></param>
        /// <returns></returns>
        public bool deleteOutTable(string out_scrpno)
        {
            SqlParameter[] outtableParms;
            outtableParms = GetDeleteOutTableParameters();
            outtableParms[0].Value = out_scrpno;
            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                conn.Open();

                // Start a local transaction.
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SQL_DELETE_OUTTABLE, outtableParms);
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SQL_DELETE_OUTSCRP, outtableParms);
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



        /// <summary>
        /// 得到最大的出库凭证编号
        /// </summary>
        /// <returns></returns>
        public string GetTopOutScrpNo()
        {
            string re = "";
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text,
                SQL_SELECT_TOP_OUT_SCRPNO))
            {
                // Scroll through the results
                if (rdr.Read())
                {
                    re = SqlHelper.GetStringValue(rdr.GetValue(0)).Trim();
                }
            }
            return re;
        }
        /// <summary>
        /// 按领取礼品单位分组
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IList<IList<string>> GetStatOutTableGroupByOutOuByCon(string condition)
        {
            IList<IList<string>> list = new List<IList<string>>();
            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text,
                SQL_STAT_OUTTABLE_OUTOU + condition + SQL_STAT_OUTTABLE_OUTOU2))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    IList<string> data = new List<string>();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        data.Add(SqlHelper.GetStringValue(rdr.GetValue(i)).Trim());
                    }
                    list.Add(data);
                }
            }
            return list;
        }

        /// <summary>
        /// 按领取礼品单位分组 用于部门领取情况统计报表
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataTable  GetStatOutOuGroupByOutOuByCon(string condition)
        {
            DataTable dt = new DataTable();
            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text,
                SQL_STAT_OUTTABLE_STAT_OUTOU + condition + SQL_STAT_OUTTABLE_OUTOU2))
            {
                // Scroll through the results
                dt = SqlHelper.DataReaderToTable(rdr);
            }
            return dt;
        }

        /// <summary>
        /// 按领取礼品单位分组 用于赠送情况统计报表
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataTable GetStatVipOuGroupByOutOuByCon(string condition)
        {
            DataTable dt = new DataTable();
            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text,
                SQL_STAT_OUTTABLE_STAT_VIPOU + condition + SQL_STAT_OUTTABLE_VIPOU2))
            {
                // Scroll through the results
                dt = SqlHelper.DataReaderToTable(rdr);
            }
            return dt;
        }

        /// <summary>
        /// 根据条件统计所有的出库数量
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public int GetStatOutTableAllOutOuByCon(string condition)
        {
            int re = 0;
            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text,
                SQL_STAT_OUTTABLE_OUTOU_ALL + condition))
            {
                // Scroll through the results
                if (rdr.Read())
                {
                    re = Int32.Parse(SqlHelper.GetStringValue(rdr.GetValue(0)).Trim() == "" ? "0" : SqlHelper.GetStringValue(rdr.GetValue(0)).Trim());
                }
            }
            return re;
        }




        /// <summary>
        /// 凭证数据统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetOutTableForStatQntSum(string startTime, string endTime)
        {
            DataTable dt = new DataTable();
            SqlParameter[] parms = GetOutTableForStatQntSumParameters();
            parms[0].Value = startTime;
            parms[1].Value = endTime;
            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_OUTTABLE_FOR_OUTSTAT, parms))
            {
                // Scroll through the results
                dt = SqlHelper.DataReaderToTable(rdr);
            }
            return dt;
        }

        /// <summary>
        /// 凭证数据统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetOutTableForStatQntSum(string condition)
        {
            DataTable dt = new DataTable();
            //SqlParameter[] parms = GetOutTableForStatQntSumParameters();
            //parms[0].Value = startTime;
            //parms[1].Value = endTime;
            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_OUTTABLE_FOR_OUTSTAT_BY_OUTSCRPNO + condition))
            {
                // Scroll through the results
                dt = SqlHelper.DataReaderToTable(rdr);
            }
            return dt;
        }

        public IList<IList<string>> GetOutTableForStatQntSum(string startTime, string endTime,string condition)
        {
            IList<IList<string>> list = new List<IList<string>>();
            SqlParameter[] parms = GetOutTableForStatQntSumParameters();
            parms[0].Value = startTime;
            parms[1].Value = endTime;
            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_OUTTABLE_FOR_OUTSTAT2 + condition + " order by outtable.out_scrpno,outtable.out_date, outscrp.p_no", parms))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    IList<string> data = new List<string>();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        data.Add(SqlHelper.GetStringValue(rdr.GetValue(i)).Trim());
                    }
                    list.Add(data);
                }
            }
            return list;
        }

        

        /// <summary>
        /// 出库统计报表  制定领取部门统计领取情况 共用
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataTable GetOutTableDataTableForStatQntSum(string startTime, string endTime, string condition)
        {
            DataTable dt = new DataTable();
            SqlParameter[] parms = GetOutTableForStatQntSumParameters();
            parms[0].Value = startTime;
            parms[1].Value = endTime;
            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_OUTTABLE_FOR_OUTSTAT2 + condition + " order by outtable.out_scrpno,outtable.out_date, outscrp.p_no", parms))
            {
                // Scroll through the results
                dt = SqlHelper.DataReaderToTable(rdr);
            }
            return dt;
        }

        /// <summary>
        /// 统计2
        /// </summary>
        /// <returns></returns>
        public IList<IList<string>> GetOutTableForSUM(string startTime, string endTime, string condition)
        {
            IList<IList<string>> list = new List<IList<string>>();
            SqlParameter[] parms = GetOutTableForSUMParameters();
            parms[0].Value = startTime;
            parms[1].Value = endTime;
            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_OUTTABLE_SUM_OUTSTAT + condition, parms))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    IList<string> data = new List<string>();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        data.Add(SqlHelper.GetStringValue(rdr.GetValue(i)).Trim());
                    }
                    list.Add(data);
                }
            }
            return list;
        }


        //得到所有出库凭证信息
        public IList<OutTableInfo> GetAllOutTable()
        {
            IList<OutTableInfo> allOutTable = new List<OutTableInfo>();

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text,SQL_SELECT_OutTable_ALL))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    //string out_scrpno, string out_ou, DateTime out_date, decimal out_cost, string vip_ou,out_acc,string out_memo
                    OutTableInfo inInfoData = new OutTableInfo(
                        (SqlHelper.GetStringValue(rdr[0])).Trim(),
                        (SqlHelper.GetStringValue(rdr[1])).Trim(),
                        (rdr[2] == null || rdr[2] == DBNull.Value) ? new System.DateTime() : rdr.GetDateTime(2),
                        (rdr[3] == null || rdr[3] == DBNull.Value) ? 0 : rdr.GetDecimal(3),
                        (SqlHelper.GetStringValue(rdr[4])).Trim(),
                        (rdr[5] == null || rdr[5] == DBNull.Value) ? 0 : rdr.GetInt32(5),
                        (SqlHelper.GetStringValue(rdr[6])).Trim()
                        );
                    //Add each item to the arraylist
                    allOutTable.Add(inInfoData);
                }
            }
            return allOutTable;
        }


        
        /// <summary>
        /// 根据条件所有出库凭证信息
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IList<OutTableInfo> GetOutTableByCondition(string condition)
        {
            IList<OutTableInfo> allOutTable = new List<OutTableInfo>();

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, 
                SQL_SELECT_OUTTABLE_BY_CONDITION + condition + " order by o.out_scrpno, out_date"))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    //string out_scrpno, string out_ou, DateTime out_date, decimal out_cost, string vip_ou,out_acc,string out_memo
                    OutTableInfo inInfoData = new OutTableInfo(
                        (SqlHelper.GetStringValue(rdr[0])).Trim(),
                        (SqlHelper.GetStringValue(rdr[1])).Trim(),
                        (rdr[2] == null || rdr[2] == DBNull.Value) ? new System.DateTime() : rdr.GetDateTime(2),
                        (rdr[3] == null || rdr[3] == DBNull.Value) ? 0 : rdr.GetDecimal(3),
                        (SqlHelper.GetStringValue(rdr[4])).Trim(),
                        (rdr[5] == null || rdr[5] == DBNull.Value) ? 0 : rdr.GetInt32(5),
                        (SqlHelper.GetStringValue(rdr[6])).Trim()
                        );
                    //Add each item to the arraylist
                    allOutTable.Add(inInfoData);
                }
            }
            return allOutTable;
        }

        //修改出库凭证信息
        public bool updateOutTable(OutTableInfo data)
        {
            SqlParameter[] OutTableParms;
            OutTableParms = GetUpdateOutTableParameters();
            //out_scrpno,out_ou,out_date,out_cost,vip_ou,out_acc,out_memo
            
            OutTableParms[0].Value = data.Out_ou;
            OutTableParms[1].Value = data.Out_date.ToShortDateString();
            OutTableParms[2].Value = data.Out_cost;
            OutTableParms[3].Value = data.Vip_ou;
            OutTableParms[4].Value = data.Out_acc;
            OutTableParms[5].Value = data.Out_memo;
            OutTableParms[6].Value = data.Out_scrpno;

            SqlParameter[] DelOutScrpParms = new SqlParameter[]{new SqlParameter(PARM_OUT_SCRPNO, SqlDbType.VarChar,50)};
            DelOutScrpParms[0].Value = data.Out_scrpno;
            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                conn.Open();

                bool oneTran = false;
                SqlTransaction tran0 = conn.BeginTransaction();
                try
                {
                    SqlHelper.ExecuteNonQuery(tran0, CommandType.Text, SQL_UPDATE_OUTTABLE, OutTableParms);
                    //先删除旧的礼品信息
                    SqlHelper.ExecuteNonQuery(tran0, CommandType.Text, SQL_DELETE_OUTSCRP_BY_OUTSCRPNO, DelOutScrpParms);
                    tran0.Commit();
                    oneTran = true;
                }
                catch
                {
                    tran0.Rollback();
                    oneTran = false;
                }
                // Start a local transaction.
                if (oneTran)
                {
                    SqlTransaction tran = conn.BeginTransaction();
                    try
                    {


                        //添加新的礼品信息
                        System.ComponentModel.BindingList<OutScrpInfo> outScrpList = data.OutScrpList;
                        for (int i = 0; i < outScrpList.Count; i++)
                        {
                            SqlParameter[] OutScrpParms;
                            OutScrpParms = GetInsertOutScrpParameters();
                            //in_scrpno,billno,in_ou,in_date,in_cost,planin,goodacc,in_acc,in_memo
                            OutScrpParms[0].Value = outScrpList[i].Out_scrpno;
                            OutScrpParms[1].Value = outScrpList[i].P_no;
                            OutScrpParms[2].Value = outScrpList[i].Qnt;
                            OutScrpParms[3].Value = outScrpList[i].Out_price;

                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SQL_INSERT_OUTSCRP, OutScrpParms);
                        }

                        tran.Commit();
                        return true;
                    }
                    catch
                    {
                        tran.Rollback();
                    }
                }
            }
            return false;
        }

        //新建
        public bool insertOutTable(OutTableInfo data)
        {
            SqlParameter[] OutTableParms;
            OutTableParms = GetInsertOutTableParameters();
            //out_scrpno,out_ou,out_date,out_cost,vip_ou,out_acc,out_memo
            OutTableParms[0].Value = data.Out_scrpno;
            OutTableParms[1].Value = data.Out_ou;
            OutTableParms[2].Value = data.Out_date.ToShortDateString();
            OutTableParms[3].Value = data.Out_cost;
            OutTableParms[4].Value = data.Vip_ou;
            OutTableParms[5].Value = data.Out_acc;
            OutTableParms[6].Value = data.Out_memo;
            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                conn.Open();

                // Start a local transaction.
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SQL_INSERT_OUTTABLE, OutTableParms);
                    System.ComponentModel.BindingList<OutScrpInfo> outScrpList = data.OutScrpList;
                    for (int i = 0; i < outScrpList.Count; i++)
                    {
                        SqlParameter[] OutScrpParms;
                        OutScrpParms = GetInsertOutScrpParameters();
                        //in_scrpno,billno,in_ou,in_date,in_cost,planin,goodacc,in_acc,in_memo
                        OutScrpParms[0].Value = outScrpList[i].Out_scrpno;
                        OutScrpParms[1].Value = outScrpList[i].P_no;
                        OutScrpParms[2].Value = outScrpList[i].Qnt;
                        OutScrpParms[3].Value = outScrpList[i].Out_price;
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SQL_INSERT_OUTSCRP, OutScrpParms);

                        //以下任务已有触发器完成
                        ////修改库存  此为出库 在原来库存基础上减去此次入库数量 SQL_UPDATE_PREINFO_ACCQNT
                        //SqlParameter[] updatePreInfoAccQntParms = GetUpdatePreInfoAccQntParameters();
                        //updatePreInfoAccQntParms[0].Value = outScrpList[i].Qnt;
                        //updatePreInfoAccQntParms[1].Value = outScrpList[i].P_no;
                        //SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SQL_UPDATE_PREINFO_ACCQNT, updatePreInfoAccQntParms);
                    }

                    tran.Commit();
                    return true;
                }
                catch
                {
                    tran.Rollback();
                }
            }
            return false;
        }


        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetUpdateOutTableParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_UPDATE_OUTTABLE);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					
                    new SqlParameter(PARM_OUT_OU, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_OUT_DATE, SqlDbType.DateTime),
                    new SqlParameter(PARM_OUT_COST, SqlDbType.Decimal),
                    new SqlParameter(PARM_VIP_OU, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_OUT_ACC, SqlDbType.Int),
                    new SqlParameter(PARM_OUT_MEMO, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_OUT_SCRPNO, SqlDbType.VarChar,50)};

                SqlHelper.CacheParameters(SQL_UPDATE_OUTTABLE, parms);
            }

            return parms;
        }

        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetInsertOutTableParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_INSERT_OUTTABLE);

            if (parms == null)
            {
                //private const string PARM_OUT_SCRPNO = "@out_scrpno";
                //private const string PARM_OUT_OU = "@out_ou";
                //private const string PARM_OUT_DATE = "@out_date";
                //private const string PARM_OUT_COST = "@out_cost";
                //private const string PARM_VIP_OU = "@vip_ou";
                //private const string PARM_OUT_ACC = "@out_acc";
                //private const string PARM_OUT_MEMO = "@out_memo";
                ////out_scrpno,out_ou,out_date,out_cost,vip_ou,out_acc,out_memo
                parms = new SqlParameter[] {
					new SqlParameter(PARM_OUT_SCRPNO, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_OUT_OU, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_OUT_DATE, SqlDbType.DateTime),
                    new SqlParameter(PARM_OUT_COST, SqlDbType.Decimal),
                    new SqlParameter(PARM_VIP_OU, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_OUT_ACC, SqlDbType.Int),
                    new SqlParameter(PARM_OUT_MEMO, SqlDbType.VarChar,50)};

                SqlHelper.CacheParameters(SQL_INSERT_OUTTABLE, parms);
            }

            return parms;
        }

        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        ///private const string PARM_P_NO = "@p_no";
        //private const string PARM_QNT = "@qnt";
        //private const string PARM_OUT_PRICE = "@in_price";
        private static SqlParameter[] GetInsertOutScrpParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_INSERT_OUTSCRP);

            if (parms == null)
            {
                parms = new SqlParameter[] {
                    new SqlParameter(PARM_OUT_SCRPNO, SqlDbType.VarChar,50),
					new SqlParameter(PARM_P_NO, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_QNT, SqlDbType.Int,2),
                    new SqlParameter(PARM_OUT_PRICE, SqlDbType.Decimal)
                };

                SqlHelper.CacheParameters(SQL_INSERT_OUTSCRP, parms);
            }

            return parms;
        }


        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetOutTableForStatQntSumParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_SELECT_OUTTABLE_FOR_OUTSTAT);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					
                    new SqlParameter(PARM_START, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_END, SqlDbType.VarChar,50)};

                SqlHelper.CacheParameters(SQL_SELECT_OUTTABLE_FOR_OUTSTAT, parms);
            }

            return parms;
        }


        private static SqlParameter[] GetOutTableForSUMParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_SELECT_OUTTABLE_SUM_OUTSTAT);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					
                    new SqlParameter(PARM_START, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_END, SqlDbType.VarChar,50)};

                SqlHelper.CacheParameters(SQL_SELECT_OUTTABLE_SUM_OUTSTAT, parms);
            }

            return parms;
        }


        private static SqlParameter[] GetUpdatePreInfoAccQntParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_UPDATE_PREINFO_ACCQNT);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					
                    new SqlParameter(PARM_ACC_QNT, SqlDbType.Int),
                    new SqlParameter(PARM_P_NO, SqlDbType.VarChar,50)};

                SqlHelper.CacheParameters(SQL_UPDATE_PREINFO_ACCQNT, parms);
            }

            return parms;
        }


        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetDeleteOutTableParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_DELETE_OUTTABLE);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARM_OUT_SCRPNO, SqlDbType.VarChar,50)};

                SqlHelper.CacheParameters(SQL_DELETE_OUTTABLE, parms);
            }

            return parms;
        }



    }
}
