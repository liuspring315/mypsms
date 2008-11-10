using System;
using System.Data;
using System.Data.SqlClient;
using psms.Model;
using psms.IDAL;
using System.Collections.Generic;
using psms.DBUtility;

namespace psms.SQLServerDAL
{
	//    3	IN_SCRPNO	char	20	0
	//    0	billno	char	20	1
	//    0	IN_OU	char	20	1
	//    0	IN_DATE	datetime	8	1
	//    0	IN_COST	decimal	9	1
	//    0	planin	char	2	1
	//    0	goodsAcc	int	4	1
	//    0	IN_ACC	int	4	1
	//    0	IN_MEMO	varchar	50	1
    public class InTable : IInTable 
    {
        // Static constants

        //得到所有入库凭证信息sql
        private const string SQL_SELECT_INTABLE_ALL = "SELECT in_scrpno,billno,in_ou,in_date,in_cost,"+
			"planin,goodsAcc,in_acc,in_memo from INTABLE ";

        //根据条件得到入库凭证信息sql
        private const string SQL_SELECT_INTABLE_BY_CONDITION = "SELECT DISTINCT i.in_scrpno,billno,in_ou,in_date,in_cost," +
            "planin,goodsAcc,in_acc,in_memo from INTABLE i,INSCRP s,PREINFO p where i.in_scrpno = s.in_scrpno and s.p_no = p.p_no and  1=1 ";


        //修改入库凭证信息sql
        private const string SQL_UPDATE_INTABLE = "UPDATE INTABLE set billno=@billno,in_ou=@in_ou,in_date=@in_date,in_cost=@in_cost,"+
            "planin=@planin,goodsacc=@goodsacc,in_memo=@in_memo where in_scrpno = @in_scrpno";

        //新增入库凭证信息sql
        //InTableInfo(string in_scrpno, string billno, string in_ou,System.DateTime in_date ,decimal in_cost, string planin,
		//	int goodsAcc,int in_acc,string in_memo)
        private const string SQL_INSERT_INTABLE = "INSERT INTO INTABLE (in_scrpno,billno,in_ou,in_date,in_cost,planin,goodsacc,in_acc,in_memo) values (" +
            "@in_scrpno,@billno,@in_ou,@in_date,@in_cost,@planin,@goodsacc,@in_acc,@in_memo)";
        //3	id	int	4	0
        //0	IN_SCRPNO	char	20	0
        //0	P_NO	char	15	0
        //0	QNT	int	4	1
        //0	IN_PRICE	decimal	9	1
        private const string SQL_INSERT_INSCRP = "INSERT INTO INSCRP (in_scrpno,p_no,qnt,in_price) values (" +
            "@in_scrpno,@p_no,@qnt,@in_price)";

        //统计
        private const string SQL_SELECT_INTABLE_BY_REPORT1 = "select convert(char(10),intable.in_date,20) as indate, intable.in_scrpno,intable.billno + ' ' as billno, inscrp.p_no, preinfo.p_name, preinfo.unit,preinfo.unit_price,inscrp.qnt, inscrp.in_price " +
            "from inscrp, intable, preinfo " +
            "where inscrp.in_scrpno=intable.in_scrpno and inscrp.p_no=preinfo.p_no and in_date >= @start and in_date <= @end ";

        //统计2
        private const string SQL_SELECT_INTABLE_BY_REPORT2 = "select sum(qnt) as sumqnt, sum(in_price) as sumprice " +
            "from inscrp, intable, preinfo " +
            "where inscrp.in_scrpno=intable.in_scrpno and inscrp.p_no=preinfo.p_no  and in_date >= @start and in_date <= @end ";

        private const string SQL_ORDER_BY = " order by intable.in_scrpno,intable.in_date, inscrp.p_no";

        private const string UPDATE_GOODACC = "update intable set goodsacc = 1 where in_scrpno = @in_scrpno";

        //退库
        private const string UPDATE_UNIN_1 = "update intable set in_cost = @in_cost where in_scrpno = @in_scrpno";
        private const string UPDATE_UNIN_2 = "update inscrp set qnt = @qnt,in_price = @in_price where in_scrpno = @in_scrpno and p_no = @p_no";
        private const string UPDATE_UNIN_3 = "update preinfo set acc_qnt = @acc_qnt where p_no = @p_no";
        private const string UPDATE_UNIN_4 = "update preacc set QNT=@qnt, COST=@cost, S_QNT=@s_qnt, S_COST=@s_cost where IN_OUT='r' and SCRP_NO = @in_scrpno and P_NO=@p_no";
        private const string UPDATE_UNIN_5 = "insert into UNININFO (inscrpno,pno,undate,uninnum,remark) values (@in_scrpno,@p_no,@undate,@uninnum,@remark)";

        //退库统计
        private const string SQL_SELECT_REINTABLE_BY_REPORT = "select convert(char(10),u.undate,20) as undate, u.inscrpno, p.p_no, p.p_name, p.unit,p.unit_price,u.uninnum, p.unit_price * u.uninnum as allprice,intable.IN_OU " +
                   "from UNININFO u, preinfo p,intable " +
                   "where intable.in_scrpno = u.inscrpno and p.p_no=u.pno and undate >= @start and undate <= @end ";
        private const string SQL_REINTABLE_ORDER_BY = " order by intable.in_scrpno,u.undate, p.p_no";
        
        //删除入库凭证信息sql
        private const string SQL_DELETE_INTABLE = "delete from INTABLE where IN_SCRPNO=@in_scrpno";
        private const string SQL_DELETE_INSCRP = "delete from INSCRP where IN_SCRPNO=@in_scrpno";

        /// <summary>
        /// 入库 添加礼品库存
        /// </summary>
        private const string SQL_UPDATE_PREINFO_ACCQNT = "update PREINFO set ACC_QNT = acc_qnt + @acc_qnt where P_NO = @p_no";

        private const string SQL_SELECT_INSCRP_BY_IN_SCRPNO = "select i.qnt from inscrp i where in_scrpno = @in_scrptno";

        /// <summary>
        /// 得到最大的凭证编号
        /// </summary>
        private const string SQL_SELECT_TOP_IN_SCRPNO = "select top 1 in_scrpno from intable order by in_scrpno desc";



        #region 参数
        
        
        private const string PARM_IN_SCRPNO = "@in_scrpno";
        private const string PARM_IN_OU  = "@in_ou";
        private const string PARM_IN_DATE = "@in_date";
        private const string PARM_IN_COST = "@in_cost";
        private const string PARM_PLANIN = "@planin";
        private const string PARM_GOODSACC = "@goodsacc";
        private const string PARM_IN_ACC = "@in_acc";
        private const string PARM_IN_MEMO = "@in_memo";
        private const string PARM_BILLNO = "@billno";

        private const string PARM_P_NO = "@p_no";
        private const string PARM_P_NAME = "@p_name";
        private const string PARM_UNIT = "@unit";
        private const string PARM_UNIT_PRICE = "@unit_price";
        private const string PARM_COST_PRICE = "@cost_price";

        private const string PARM_QNT = "@qnt";
        private const string PARM_ACC_QNT = "@acc_qnt";
        private const string PARM_IN_PRICE = "@in_price";

        private const string PARM_START = "@start";
        private const string PARM_END = "@end";

        private const string PARM_COST = "@cost";
        private const string PARM_S_COST = "@s_cost";
        private const string PARM_S_QNT = "@s_qnt";
        private const string PARM_UNDATE = "@undate";
        private const string PARM_UNINNUM = "@uninnum";
        private const string PARM_REMARK = "@remark";
        #endregion


        /// <summary>
        /// 得到最大的入库凭证编号
        /// </summary>
        /// <returns></returns>
        public string GetTopInScrpno()
        {
            //SQL_SELECT_TOP_IN_SCRPNO
            string re = "";
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_TOP_IN_SCRPNO))
            {
                // Scroll through the results
                if (rdr.Read())
                {
                   re = rdr.GetValue(0).ToString().Trim();
                }
            }
            return re;
        }
        //得到所有入库凭证信息
        //入库凭证单位
        //    3	IN_SCRPNO	char	20	0
        //    0	billno	char	20	1
        //    0	IN_OU	char	20	1
        //    0	IN_DATE	datetime	8	1
        //    0	IN_COST	decimal	9	1
        //    0	planin	char	2	1
        //    0	goodsAcc	int	4	1
        //    0	IN_ACC	int	4	1
        //    0	IN_MEMO	varchar	50	1
        public IList<InTableInfo> GetAllInTable()
        {
            IList<InTableInfo> allInTable = new List<InTableInfo>();

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text,SQL_SELECT_INTABLE_ALL))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    //in_scrpno,billno,in_ou,in_date,in_cost,planin,goodsAcc,in_acc,in_memo
                    InTableInfo inInfoData = new InTableInfo(
                        (SqlHelper.GetStringValue(rdr[0])).Trim(),
                        (SqlHelper.GetStringValue(rdr[1])).Trim(),
                        (SqlHelper.GetStringValue(rdr[2])).Trim(),
                        (rdr[3] == null || rdr[3] == DBNull.Value) ? new System.DateTime() : rdr.GetDateTime(3),
                        (rdr[4] == null || rdr[4] == DBNull.Value) ? 0 : rdr.GetDecimal(4),
                        (SqlHelper.GetStringValue(rdr[5])).Trim(),
                        (rdr[6] == null || rdr[6] == DBNull.Value) ? 0 : rdr.GetInt32(6),
                        (rdr[7] == null || rdr[7] == DBNull.Value) ? 0 : rdr.GetInt32(7),
                        (SqlHelper.GetStringValue(rdr[8])).Trim()
                        );
                    //InTableInfo inInfoData = new InTableInfo(rdr[0].ToString().Trim(), rdr[1].ToString().Trim(), rdr[2].ToString().Trim(), rdr.GetDateTime(3),
                    //    rdr.GetDecimal(4), rdr[5].ToString().Trim(), rdr.GetInt32(6), rdr.GetInt32(7), rdr[8].ToString().Trim());
                    //Add each item to the arraylist
                    allInTable.Add(inInfoData);
                }
            }
            return allInTable;
        }


        //根据条件所有入库凭证信息
        //入库凭证单位
        //    3	IN_SCRPNO	char	20	0
        //    0	billno	char	20	1
        //    0	IN_OU	char	20	1
        //    0	IN_DATE	datetime	8	1
        //    0	IN_COST	decimal	9	1
        //    0	planin	char	2	1
        //    0	goodsAcc	int	4	1
        //    0	IN_ACC	int	4	1
        //    0	IN_MEMO	varchar	50	1
        public IList<InTableInfo> GetInTableByCondition(string condition)
        {
            IList<InTableInfo> allInTable = new List<InTableInfo>();

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, 
                SQL_SELECT_INTABLE_BY_CONDITION + condition + " order by i.in_scrpno,in_date"))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    //in_scrpno,billno,in_ou,in_date,in_cost,planin,goodsAcc,in_acc,in_memo
                    //InTableInfo inInfoData = new InTableInfo(rdr.GetString(0).Trim(), rdr.GetString(1).Trim(), rdr.GetString(2).Trim(), rdr.GetDateTime(3),
                    //    rdr.GetDecimal(4), rdr.GetString(5).Trim(), rdr.GetInt32(6), rdr.GetInt32(7), rdr.GetString(8).Trim());
                    InTableInfo inInfoData = new InTableInfo(
                        (SqlHelper.GetStringValue(rdr[0])).Trim(),
                        (SqlHelper.GetStringValue(rdr[1])).Trim(),
                        (SqlHelper.GetStringValue(rdr[2])).Trim(),
                        (rdr[3] == null || rdr[3] == DBNull.Value) ? new System.DateTime() : rdr.GetDateTime(3),
                        (rdr[4] == null || rdr[4]== DBNull.Value) ? 0 : rdr.GetDecimal(4),
                        (SqlHelper.GetStringValue(rdr[5])).Trim(),
                        (rdr[6] == null || rdr[6] == DBNull.Value) ? 0 : rdr.GetInt32(6),
                        (rdr[7] == null || rdr[7] == DBNull.Value) ? 0 : rdr.GetInt32(7), 
                        (SqlHelper.GetStringValue(rdr[8])).Trim());
                    //Add each item to the arraylist
                    allInTable.Add(inInfoData);
                }
            }
            return allInTable;
        }

        /// <summary>
        /// 统计
        /// </summary>
        /// <returns></returns>
        public IList<IList<string>> GetInTableForReport(string startTime, string endTime ,string condition)
        {
            IList<IList<string>> list = new List<IList<string>>();
            SqlParameter[] parms = GetInTableForReportParameters();
            parms[0].Value = startTime;
            parms[1].Value = endTime;
            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_INTABLE_BY_REPORT1 + condition + SQL_ORDER_BY,parms))
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
        /// 入库统计
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataTable GetDataTableInTableForReport(string startTime, string endTime, string condition)
        {
            DataTable dt = new DataTable();
            SqlParameter[] parms = GetInTableForReportParameters();
            parms[0].Value = startTime;
            parms[1].Value = endTime;
            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_INTABLE_BY_REPORT1 + condition + SQL_ORDER_BY, parms))
            {
                dt = SqlHelper.DataReaderToTable(rdr);
            }
            return dt;
        }


        /// <summary>
        /// 退库统计
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataTable GetDataTableReInTableForReport(string startTime, string endTime, string condition)
        {
            DataTable dt = new DataTable();
            SqlParameter[] parms = GetReInTableForReportParameters();
            parms[0].Value = startTime;
            parms[1].Value = endTime;
            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_REINTABLE_BY_REPORT
                + condition + SQL_REINTABLE_ORDER_BY, parms))
            {
                dt = SqlHelper.DataReaderToTable(rdr);
            }
            return dt;
        }


        /// <summary>
        /// 统计2
        /// </summary>
        /// <returns></returns>
        public IList<IList<string>> GetInTableForReport2(string startTime, string endTime, string condition)
        {
            IList<IList<string>> list = new List<IList<string>>();
            SqlParameter[] parms = GetInTableForReportParameters();
            parms[0].Value = startTime;
            parms[1].Value = endTime;
            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_INTABLE_BY_REPORT2 + condition , parms))
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

        

        //修改入库凭证信息
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool updateInTable(InTableInfo data)
        {
            SqlParameter[] InTableParms;
            InTableParms = GetUpdateInTableParameters();
            //set billno=@billno,in_ou=@in_ou,in_date=@in_date,in_cost=@in_cost,"+
            //"planin=@planin,goodsacc=@goodsacc,in_memo=@in_memo where in_scrpno = @in_scrpno
            
            InTableParms[0].Value = data.Billno;
            InTableParms[1].Value = data.In_ou;
            InTableParms[2].Value = data.In_date.ToShortDateString();
            InTableParms[3].Value = data.In_cost;
            InTableParms[4].Value = data.Planin;
            InTableParms[5].Value = data.GoodAcc;
            InTableParms[6].Value = data.In_memo;
            InTableParms[7].Value = data.In_scrpno;
            SqlParameter[] DelInScrpParms = new SqlParameter[] { new SqlParameter(PARM_IN_SCRPNO, SqlDbType.VarChar, 50) };
            DelInScrpParms[0].Value = data.In_scrpno;
            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                conn.Open();

                // Start a local transaction.
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    //修改InTable表
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SQL_UPDATE_INTABLE, InTableParms);
                    
                    //先删除旧的礼品信息
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SQL_DELETE_INSCRP, DelInScrpParms);
                    //添加新的礼品信息
                    System.ComponentModel.BindingList<InScrpInfo> inScrpList = data.InScrpList;
                    for (int i = 0; i < inScrpList.Count; i++)
                    {
                        SqlParameter[] InScrpParms;
                        InScrpParms = GetInsertInScrpParameters();
                        //in_scrpno,billno,in_ou,in_date,in_cost,planin,goodacc,in_acc,in_memo
                        InScrpParms[0].Value = inScrpList[i].In_scrpno;
                        InScrpParms[1].Value = inScrpList[i].P_no;
                        InScrpParms[2].Value = inScrpList[i].Qnt;
                        InScrpParms[3].Value = inScrpList[i].In_price;
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SQL_INSERT_INSCRP, InScrpParms);
                    }

                    tran.Commit();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    tran.Rollback();
                    conn.Close();
                    return false;
                }

            }
            return true;
        }

        
        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool insertInTable(InTableInfo data)
        {
            SqlParameter[] InTableParms;
            InTableParms = GetInsertInTableParameters();
            //in_scrpno,billno,in_ou,in_date,in_cost,planin,goodacc,in_acc,in_memo
            InTableParms[0].Value = data.In_scrpno;
            InTableParms[1].Value = data.Billno;
            InTableParms[2].Value = data.In_ou;
            InTableParms[3].Value = data.In_date.ToShortDateString();
            InTableParms[4].Value = data.In_cost;
            InTableParms[5].Value = data.Planin;
            InTableParms[6].Value = data.GoodAcc;
            InTableParms[7].Value = data.In_acc; 
            InTableParms[8].Value = data.In_memo;
            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                conn.Open();

                // Start a local transaction.
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SQL_INSERT_INTABLE, InTableParms);
                    System.ComponentModel.BindingList<InScrpInfo> inScrpList = data.InScrpList;
                    for (int i = 0; i < inScrpList.Count; i++)
                    {
                        SqlParameter[] InScrpParms;
                        InScrpParms = GetInsertInScrpParameters();
                        //in_scrpno,billno,in_ou,in_date,in_cost,planin,goodacc,in_acc,in_memo
                        InScrpParms[0].Value = inScrpList[i].In_scrpno;
                        InScrpParms[1].Value = inScrpList[i].P_no;
                        InScrpParms[2].Value = inScrpList[i].Qnt;
                        InScrpParms[3].Value = inScrpList[i].In_price;
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SQL_INSERT_INSCRP, InScrpParms);

                        //以下任务已有触发器完成
                        //修改库存  此为入库 在原来库存基础上加上此次入库数量 SQL_UPDATE_PREINFO_ACCQNT
                        //SqlParameter[] updatePreInfoAccQntParms = GetUpdatePreInfoAccQntParameters();
                        //updatePreInfoAccQntParms[0].Value = inScrpList[i].Qnt;
                        //updatePreInfoAccQntParms[1].Value = inScrpList[i].P_no;
                        //SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SQL_UPDATE_PREINFO_ACCQNT, updatePreInfoAccQntParms);
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
        /// 确认提货
        /// </summary>
        /// <param name="in_scrpno"></param>
        /// <returns></returns>
        public bool setGoodAcc(string in_scrpno)
        {
            SqlParameter[] intableParms;
            intableParms = GetUpGoogAccInTableParameters();
            intableParms[0].Value = in_scrpno;
            //Open a connection
            int i = 0;
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                i = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, UPDATE_GOODACC, intableParms);
            }
            if (i > 0)
                return true;
            return false;

        }


        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="in_scrpno"></param>
        /// <returns></returns>
        public bool deleteIntable(string in_scrpno)
        {
            SqlParameter[] intableParms;
            SqlCommand cmd = new SqlCommand();
            intableParms = GetDeleteInTableParameters();
            intableParms[0].Value = in_scrpno;
            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                conn.Open();

                // Start a local transaction.
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SQL_DELETE_INTABLE, intableParms);
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SQL_DELETE_INSCRP, intableParms);
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
        /// 
        /// </summary>
        /// <param name="in_cost">凭证结算金额</param>
        /// <param name="in_scrpno">凭证编号</param>
        /// <param name="qnt">修改后的礼品数量</param>
        /// <param name="in_price">修改后的礼品结算金额</param>
        /// <param name="p_no">礼品编号</param>
        /// <param name="acc_qnt">修改后的库存</param>
        /// <param name="s_cost">修改后的库存金额</param>
        /// <param name="uninnum">退库数</param>
        /// <param name="remark">退库原因</param>
        /// <returns></returns>
        //public bool UnInTable(decimal in_cost,string in_scrpno,int qnt,decimal in_price,string p_no,
        //    int acc_qnt,decimal s_cost,int uninnum,string remark)
        public bool UnInTable(InTableInfo data, System.ComponentModel.BindingList<InScrpInfo> oldInScrpList)
            
        {
            SqlParameter[] InTableParms;
            InTableParms = GetUpdateInTableParameters();
            //set billno=@billno,in_ou=@in_ou,in_date=@in_date,in_cost=@in_cost,"+
            //"planin=@planin,goodsacc=@goodsacc,in_memo=@in_memo where in_scrpno = @in_scrpno

            InTableParms[0].Value = data.Billno;
            InTableParms[1].Value = data.In_ou;
            InTableParms[2].Value = data.In_date.ToShortDateString();
            InTableParms[3].Value = data.In_cost;
            InTableParms[4].Value = data.Planin;
            InTableParms[5].Value = data.GoodAcc;
            InTableParms[6].Value = data.In_memo;
            InTableParms[7].Value = data.In_scrpno;
            SqlParameter[] DelInScrpParms = new SqlParameter[] { new SqlParameter(PARM_IN_SCRPNO, SqlDbType.VarChar, 50) };
            DelInScrpParms[0].Value = data.In_scrpno;
            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                conn.Open();

                // Start a local transaction.
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    //修改InTable表
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SQL_UPDATE_INTABLE, InTableParms);

                    //先删除旧的礼品信息
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SQL_DELETE_INSCRP, DelInScrpParms);
                    //添加新的礼品信息
                    System.ComponentModel.BindingList<InScrpInfo> inScrpList = data.InScrpList;
                    for (int i = 0; i < inScrpList.Count; i++)
                    {
                        SqlParameter[] InScrpParms;
                        InScrpParms = GetInsertInScrpParameters();
                        //in_scrpno,billno,in_ou,in_date,in_cost,planin,goodacc,in_acc,in_memo
                        InScrpParms[0].Value = inScrpList[i].In_scrpno;
                        InScrpParms[1].Value = inScrpList[i].P_no;
                        InScrpParms[2].Value = inScrpList[i].Qnt;
                        InScrpParms[3].Value = inScrpList[i].In_price;
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SQL_INSERT_INSCRP, InScrpParms);

                        SqlParameter[] Parms5 = new SqlParameter[] { 
                                                                     new SqlParameter(PARM_IN_SCRPNO, SqlDbType.VarChar, 50),
                                                                     new SqlParameter(PARM_P_NO, SqlDbType.VarChar, 50),
                                                                     new SqlParameter(PARM_UNDATE, SqlDbType.DateTime),
                                                                     new SqlParameter(PARM_UNINNUM, SqlDbType.Int),
                                                                     new SqlParameter(PARM_REMARK, SqlDbType.VarChar, 50)};
                        Parms5[0].Value = inScrpList[i].In_scrpno;
                        Parms5[1].Value = inScrpList[i].P_no;
                        Parms5[2].Value = DateTime.Now;
                        int uninnum = 0;
                        for (int oldInScrpList_Count = 0; i < oldInScrpList.Count; oldInScrpList_Count++)
                        {
                            if (inScrpList[i].P_no == oldInScrpList[oldInScrpList_Count].P_no)
                            {
                                uninnum = oldInScrpList[oldInScrpList_Count].Qnt - inScrpList[i].Qnt;
                                break;
                            }
                        }
                        Parms5[3].Value = uninnum;
                        Parms5[4].Value = "";
                        //UPDATE_UNIN_5 = "insert into UNININFO (inscrpno,pno,undate,uninnum,remark) values (@in_scrpno,@p_no,@undate,@uninnum,@remark)";
                        if (uninnum > 0)
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, UPDATE_UNIN_5, Parms5);
                    }

                    tran.Commit();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    tran.Rollback();
                    conn.Close();
                    return false;
                }

            }
            return true;
            
            //SqlParameter[] Parms1 = new SqlParameter[] { new SqlParameter(PARM_IN_COST, SqlDbType.Decimal),
            //                                             new SqlParameter(PARM_IN_SCRPNO, SqlDbType.VarChar, 50) };
            //Parms1[0].Value = in_cost;
            //Parms1[1].Value = in_scrpno;

            //SqlParameter[] Parms2 = new SqlParameter[] { 
            //                                             new SqlParameter(PARM_QNT, SqlDbType.Int),
            //                                             new SqlParameter(PARM_IN_PRICE, SqlDbType.Decimal),
            //                                             new SqlParameter(PARM_IN_SCRPNO, SqlDbType.VarChar, 50),
            //                                             new SqlParameter(PARM_P_NO, SqlDbType.VarChar, 50)};
            //Parms2[0].Value = qnt;
            //Parms2[1].Value = in_price;
            //Parms2[2].Value = in_scrpno;
            //Parms2[3].Value = p_no;

            //SqlParameter[] Parms3 = new SqlParameter[] { new SqlParameter(PARM_ACC_QNT, SqlDbType.Int),
            //                                             new SqlParameter(PARM_P_NO, SqlDbType.VarChar, 50) };
            //Parms3[0].Value = acc_qnt;
            //Parms3[1].Value = p_no;

            //SqlParameter[] Parms4 = new SqlParameter[] { 
            //                                             new SqlParameter(PARM_QNT, SqlDbType.Int),
            //                                             new SqlParameter(PARM_COST, SqlDbType.Decimal),
            //                                             new SqlParameter(PARM_S_QNT, SqlDbType.Int),
            //                                             new SqlParameter(PARM_S_COST, SqlDbType.Decimal),
            //                                             new SqlParameter(PARM_IN_SCRPNO, SqlDbType.VarChar, 50),
            //                                             new SqlParameter(PARM_P_NO, SqlDbType.VarChar, 50)};
            //Parms4[0].Value = qnt;
            //Parms4[1].Value = in_price;
            //Parms4[2].Value = acc_qnt;
            //Parms4[3].Value = s_cost;
            //Parms4[4].Value = in_scrpno;
            //Parms4[5].Value = p_no;

            //SqlParameter[] Parms5 = new SqlParameter[] { 
            //                                             new SqlParameter(PARM_IN_SCRPNO, SqlDbType.VarChar, 50),
            //                                             new SqlParameter(PARM_P_NO, SqlDbType.VarChar, 50),
            //                                             new SqlParameter(PARM_UNDATE, SqlDbType.DateTime),
            //                                             new SqlParameter(PARM_UNINNUM, SqlDbType.Int),
            //                                             new SqlParameter(PARM_REMARK, SqlDbType.VarChar, 50)};
            //Parms5[0].Value = in_scrpno;
            //Parms5[1].Value = p_no;
            //Parms5[2].Value = DateTime.Now;
            //Parms5[3].Value = uninnum;
            //Parms5[4].Value = remark;

            ////Open a connection
            //using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            //{
            //    conn.Open();

            //    // Start a local transaction.
            //    SqlTransaction tran = conn.BeginTransaction();
            //    try
            //    {
            //        //update intable set in_cost = @in_cost where in_scrpno = @in_scrpno
            //        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, UPDATE_UNIN_1, Parms1);
            //        //update inscrp set qnt = @qnt,in_price = @in_price where in_scrpno = @in_scrpno and p_no = @p_no
            //        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, UPDATE_UNIN_2, Parms2);
            //        //update preinfo set acc_qnt = @acc_qnt where p_no = @p_no
            //        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, UPDATE_UNIN_3, Parms3);
            //        //update preacc set QNT=@qnt, COST=@cost, S_QNT=@s_qnt, S_COST=@s_cost where IN_OUT='r' and SCRP_NO = @in_scrpno and P_NO=@p_no
            //        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, UPDATE_UNIN_4, Parms4);
            //        //insert into UNININFO (inscrpno,pno,uninnum,remark) values (@in_scrpno,@p_no,@uninnum,@remark)
            //        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, UPDATE_UNIN_5, Parms5);

            //        tran.Commit();
            //        conn.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //        tran.Rollback();
            //        conn.Close();
            //        return false;
            //    }

            //}
            //return true;
        }


        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetUpdateInTableParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_UPDATE_INTABLE);

            if (parms == null)
            {
                //set billno=@billno,in_ou=@in_ou,in_date=@in_date,in_cost=@in_cost,"+
                //"planin=@planin,goodsacc=@goodsacc,in_memo=@in_memo where in_scrpno = @in_scrpno

                parms = new SqlParameter[] {
					
                    new SqlParameter(PARM_BILLNO, SqlDbType.Char,50),
                    new SqlParameter(PARM_IN_OU, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_IN_DATE, SqlDbType.DateTime),
                    new SqlParameter(PARM_IN_COST, SqlDbType.Decimal),
                    new SqlParameter(PARM_PLANIN, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_GOODSACC, SqlDbType.Int),
                    new SqlParameter(PARM_IN_MEMO, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_IN_SCRPNO, SqlDbType.VarChar,50)
                };

                SqlHelper.CacheParameters(SQL_UPDATE_INTABLE, parms);
            }

            return parms;
        }

        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetDeleteInTableParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_DELETE_INTABLE);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARM_IN_SCRPNO, SqlDbType.VarChar,50)};

                SqlHelper.CacheParameters(SQL_DELETE_INTABLE, parms);
            }

            return parms;
        }

        private static SqlParameter[] GetUpGoogAccInTableParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(UPDATE_GOODACC);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARM_IN_SCRPNO, SqlDbType.VarChar,50)};

                SqlHelper.CacheParameters(UPDATE_GOODACC, parms);
            }

            return parms;
        }


        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        ///         private const string PARM_IN_SCRPNO = "@in_scrpno";
        //private const string PARM_IN_OU = "@in_ou";
        //private const string PARM_IN_DATE = "@in_date";
        //private const string PARM_IN_COST = "@in_cost";
        //private const string PARM_PLANIN = "@planin";
        //private const string PARM_GOODSACC = "@goodacc";
        //private const string PARM_IN_ACC = "@in_acc";
        //private const string PARM_IN_MEMO = "@in_memo";
        //private const string PARM_BILLNO = "@billno";
        private static SqlParameter[] GetInsertInTableParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_INSERT_INTABLE);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARM_IN_SCRPNO, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_BILLNO, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_IN_OU, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_IN_DATE, SqlDbType.DateTime),
                    new SqlParameter(PARM_IN_COST, SqlDbType.Decimal),
                    new SqlParameter(PARM_PLANIN, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_GOODSACC, SqlDbType.Int),
                    new SqlParameter(PARM_IN_ACC, SqlDbType.Int),
                    new SqlParameter(PARM_IN_MEMO, SqlDbType.VarChar,50)
                };

                SqlHelper.CacheParameters(SQL_INSERT_INTABLE, parms);
            }

            return parms;
        }


        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        ///private const string PARM_P_NO = "@p_no";
        //private const string PARM_QNT = "@qnt";
        //private const string PARM_IN_PRICE = "@in_price";
        private static SqlParameter[] GetInsertInScrpParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_INSERT_INSCRP);

            if (parms == null)
            {
                parms = new SqlParameter[] {
                    new SqlParameter(PARM_IN_SCRPNO, SqlDbType.VarChar,50),
					new SqlParameter(PARM_P_NO, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_QNT, SqlDbType.Int),
                    new SqlParameter(PARM_IN_PRICE, SqlDbType.Decimal)
                };

                SqlHelper.CacheParameters(SQL_INSERT_INSCRP, parms);
            }

            return parms;
        }

        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetInTableForReportParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_SELECT_INTABLE_BY_REPORT1);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					
                    new SqlParameter(PARM_START, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_END, SqlDbType.VarChar,50)};

                SqlHelper.CacheParameters(SQL_SELECT_INTABLE_BY_REPORT1, parms);
            }

            return parms;
        }

        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetReInTableForReportParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_SELECT_REINTABLE_BY_REPORT);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					
                    new SqlParameter(PARM_START, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_END, SqlDbType.VarChar,50)};

                SqlHelper.CacheParameters(SQL_SELECT_REINTABLE_BY_REPORT, parms);
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



    }
}
