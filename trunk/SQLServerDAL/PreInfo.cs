using System;
using System.Data;
using System.Data.SqlClient;
using psms.Model;
using psms.IDAL;
using System.Collections.Generic;
using psms.DBUtility;

namespace psms.SQLServerDAL
{
    public class PreInfo : IPreInfo
    {
        // Static constants

        //得到所有礼品信息sql
        private const string SQL_SELECT_PREINFO_ALL = "SELECT id,P_NO, p.pretype, p_NAME, UNIT, UNIT_PRICE, COST_PRICE, ACC_QNT FROM PREINFO p ORDER BY P_NO ";
        private const string SQL_SELECT_PREINFO_ALL_BY_CONDITION = "SELECT id,P_NO, p.pretype, p_NAME, UNIT, UNIT_PRICE, COST_PRICE, ACC_QNT FROM PREINFO p ";

        //得到所有礼品信息sql
        private const string SQL_SELECT_PREINFO_BY_CONDITION = "SELECT id,P_NO, t.typename, p_NAME, UNIT, UNIT_PRICE, COST_PRICE, ACC_QNT,pretype FROM PREINFO p join pretype t on p.pretype = t.typename ";
            

        //按礼品编号查询礼品信息sql
        private const string SQL_SELECT_PREINFO_BY_PNO1 = "SELECT * FROM PREINFO where p_no = @p_no and id <> @id";
        private const string SQL_SELECT_PREINFO_BY_PNO2 = "SELECT id,P_NO, t.typename, p_NAME, UNIT, UNIT_PRICE, COST_PRICE, ACC_QNT FROM PREINFO p join pretype t on p.pretype = t.typename and  p.p_no = @p_no ";

        //查询 用于盘存
        private const string SQL_SELECT_PREINFO_FOR_CHECKTABLE = "SELECT P_NO, P_NAME, ACC_QNT FROM PREINFO WHERE ACC_QNT<>0 ORDER BY P_NO";

        //修改礼品信息sql
        private const string SQL_UPDATE_PREINFO = "UPDATE PREINFO set p_no=@p_no,p_name=@p_name,pretype=@preType,unit=@unit,"
            + "unit_price=@unit_price,cost_price=@cost_price,acc_qnt=@acc_qnt where id = @id";
        
        //修改礼品库存
        private const string SQL_UPDATE_PREINFO_ACCQNT = "update PREINFO set ACC_QNT = @acc_qnt where P_NO = @p_no";

        //新增礼品信息sql
        private const string SQL_INSERT_PREINFO = "INSERT INTO PREINFO (p_no,pretype,p_name,unit,unit_price,cost_price,acc_qnt) values ("+
            "@p_no,@preType,@p_name,@unit,@unit_price,@cost_price,@acc_qnt)";

        //删除礼品信息sql
        private const string SQL_DELETE_PREINFO = "delete from preinfo where id=@id";

        private const string SQL_ORDERBY = " ORDER BY id ";

        private const string STORE_SPSUMMARY1 = "spsummary1";
        private const string SQL_SELECT_FOR_PREINFO_STAT_INOUT_SUM = "select c.p_no,c.pretype,c.p_name,c.unit_price, i_amount, i_total, o_amount, o_total " +
            "from ##summary s, preinfo c " +
            "where s.p_no = c.p_no and ((i_amount<>0) or (o_amount<>0)) ";
        private const string SQL_SELECT_FOR_PREINFO_STAT_INOUT_SUM2 = " order by s.p_no";
        private const string DROP_SUMMARY = "drop table ##summary";


        private const string STORE_SPSTOREQNT1 = "spStoreqnt1";
        private const string STORE_SPSTOREQNT2 = "select s.p_no, s.p_name, (select unit_price from preinfo where p_no = s.p_no ) as unit_price, s.s_qnt, i_amount, i_total, o_amount, o_total, e_qnt, (e_qnt * (select unit_price from preinfo where p_no = s.p_no )) as e_price " +
            "from ##StoreQnt s " +
            "where 1=1 ";
        private const string STORE_SPSTOREQNT3 = "select  sum(e_qnt) as sumq, sum(e_qnt * unit_price) as sump " +
            "from ##StoreQnt s, preinfo p " +
            "where s.p_no = p.p_no ";

        private const string STORE_SPSTOREQNT4 = "drop table ##StoreQnt";

        private const string SELECT_INSCRP_BY_PNO = "SELECT COUNT(*) FROM INSCRP i,PREINFO p WHERE p.p_no = i.p_no and p.id=@id";
        private const string SELECT_OUTSCRP_BY_PNO = "SELECT COUNT(*) FROM OUTSCRP o,PREINFO p WHERE p.p_no = o.p_no and p.id=@id";



        //查询所有库存总量、总金额
        private const string SELECT_PREINFO_COUNT = "select sum(acc_qnt) as sumqnt,sum(unit_price * acc_qnt) as sumprice from preinfo";



        #region 参数
        
        private const string PARM_P_NO = "@p_no";
        private const string PARM_ID = "@id";

        private const string PARM_PNAME = "@p_name";
        private const string PARM_PRETYPE = "@preType";
        private const string PARM_UNIT = "@unit";
        private const string PARM_UNITPRICE = "@unit_price";
        private const string PARM_COSTPRICE = "@cost_price";
        private const string PARM_ACCQNT = "@acc_qnt";
        private const string PARM_START = "@start";
        private const string PARM_END = "@end";

        #endregion

        
        /// <summary>
        /// 得到当前库存总量及金额
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public string[] GetPreInfoCount()
        {
            string qnt = "0";
            string price = "0";
            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text,
                SELECT_PREINFO_COUNT))
            {
                // Scroll through the results
                if (rdr.Read())
                {
                    qnt = SqlHelper.GetStringValue(rdr.GetValue(0)).Trim() == "" ? "0" : SqlHelper.GetStringValue(rdr.GetValue(0)).Trim();
                    price = SqlHelper.GetStringValue(rdr.GetValue(1)).Trim() == "" ? "0" : SqlHelper.GetStringValue(rdr.GetValue(1)).Trim();
                }
            }
            return new string[]{qnt,price};
        }



        /// <summary>
        /// 宣传品出入库总量统计
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataTable GetPreInfoForStatInOutSum(string startTime,string endTime,string condition)
        {
            DataTable dt = new DataTable();
            SqlParameter[] parms = GetPreInfoForStatInOutSumParameters();
            parms[0].Value = startTime ;//+ " 00:00:00.000";
            parms[1].Value = endTime;//+ " 23:59:59.990";
            //Execute the query against the database
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                // Scroll through the results
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, STORE_SPSUMMARY1, parms);
                SqlDataReader rdr = SqlHelper.ExecuteReader(conn.ConnectionString, CommandType.Text, SQL_SELECT_FOR_PREINFO_STAT_INOUT_SUM + condition + SQL_SELECT_FOR_PREINFO_STAT_INOUT_SUM2, null);
                dt = SqlHelper.DataReaderToTable(rdr);
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, DROP_SUMMARY);
            }
            return dt;
        }

        /// <summary>
        /// 通用
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable GetDataTableBySql(string sql)
        {
            DataTable dt = new DataTable();
            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, 
                sql))
            {
                // Scroll through the results
                dt = SqlHelper.DataReaderToTable(rdr);
            }
            return dt;
        }


        
        /// <summary>
        /// 宣传品进销存统计
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public IList<IList<string>> GetPreInfoForStatInOutSumspStoreqnt1(string startTime, string endTime,string condition)
        {
            IList<IList<string>> list = new List<IList<string>>();
            SqlParameter[] parms = GetPreInfoForStatInOutSumParameters();
            parms[0].Value = startTime;
            parms[1].Value = endTime;
            //Execute the query against the database
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                // Scroll through the results
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, STORE_SPSTOREQNT1, parms);
                SqlDataReader rdr = SqlHelper.ExecuteReader(conn.ConnectionString, CommandType.Text, STORE_SPSTOREQNT2 + condition, null);
                while (rdr.Read())
                {
                    IList<string> data = new List<string>();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        data.Add((SqlHelper.GetStringValue(rdr[i])).Trim());
                    }
                    list.Add(data);
                }
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, STORE_SPSTOREQNT4);
            }
            return list;
        }

        /// <summary>
        /// 宣传品进销存统计
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public DataTable GetDataTablePreInfoForStatInOutSumspStoreqnt1(string startTime, string endTime, string condition)
        {
            //IList<IList<string>> list = new List<IList<string>>();
            DataTable dt = new DataTable();
            SqlParameter[] parms = GetPreInfoForStatInOutSumParameters();
            parms[0].Value = startTime;
            parms[1].Value = endTime;
            //Execute the query against the database
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                // Scroll through the results
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, STORE_SPSTOREQNT1, parms);
                SqlDataReader rdr = SqlHelper.ExecuteReader(conn.ConnectionString, CommandType.Text, STORE_SPSTOREQNT2 + condition + " order by s.p_no", null);
                dt = SqlHelper.DataReaderToTable(rdr);
                
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, STORE_SPSTOREQNT4);
            }
            return dt;
        }



        //得到所有礼品信息
        public IList<PreInfoData> GetAllPreInfo()
        {
            IList<PreInfoData> allPreInfo = new List<PreInfoData>();

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text,SQL_SELECT_PREINFO_ALL))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    PreInfoData preInfoData = getPreInfoByDataReader(rdr);
                    //Add each item to the arraylist
                    allPreInfo.Add(preInfoData);
                }
            }
            return allPreInfo;
        }
        public IList<PreInfoData> GetAllPreInfoByCondition(string condition)
        {
            IList<PreInfoData> allPreInfo = new List<PreInfoData>();

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_PREINFO_ALL_BY_CONDITION + condition + " ORDER BY P_NO "))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    PreInfoData preInfoData = getPreInfoByDataReader(rdr);
                    //Add each item to the arraylist
                    allPreInfo.Add(preInfoData);
                }
            }
            return allPreInfo;
        }

        /// <summary>
        /// 根据Condition得到所有礼品信息
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IList<PreInfoData> GetPreInfoByCondition(string condition)
        {
            IList<PreInfoData> allPreInfo = new List<PreInfoData>();

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_PREINFO_BY_CONDITION + condition + SQL_ORDERBY))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    PreInfoData preInfoData = getPreInfoByDataReader(rdr);
                    //Add each item to the arraylist
                    allPreInfo.Add(preInfoData);
                }
            }
            return allPreInfo;
        }

        /// <summary>
        /// 查询 用于盘存
        /// </summary>
        /// <returns></returns>
        public IList<PreInfoData> GetPreInfoForCheckTable()
        {
            IList<PreInfoData> allPreInfo = new List<PreInfoData>();

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_PREINFO_FOR_CHECKTABLE))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    PreInfoData preInfoData = new PreInfoData(
                        (SqlHelper.GetStringValue(rdr[0])).Trim(),
                        (SqlHelper.GetStringValue(rdr[1])).Trim(),
                        (rdr[2] == null || rdr[2] == DBNull.Value) ? 0 : rdr.GetInt32(2)
                        );
                    //Add each item to the arraylist
                    allPreInfo.Add(preInfoData);
                }
            }
            return allPreInfo;
        }

        
        /// <summary>
        /// 按礼品编号查询
        /// </summary>
        /// <param name="p_no"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetPreInfoByNo(string p_no,int id)
        {
            if (id != 0)
            {
                SqlParameter parm = new SqlParameter(PARM_P_NO, SqlDbType.VarChar, 50);
                parm.Value = p_no;
                SqlParameter parm2 = new SqlParameter(PARM_ID, SqlDbType.Int, 4);
                parm2.Value = id;
                SqlParameter[] parms = new SqlParameter[2];
                parms[0] = parm;
                parms[1] = parm2;

                int rowCount = 0;
                //Execute the query against the database
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_PREINFO_BY_PNO1, parms))
                {
                    // Scroll through the results
                    while (rdr.Read())
                    {
                        rowCount = rowCount + 1;
                    }
                }
                return rowCount;
            }
            else
            {
                SqlParameter parm = new SqlParameter(PARM_P_NO, SqlDbType.VarChar, 50);
                parm.Value = p_no;

                int rowCount = 0;
                //Execute the query against the database
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text,
                    "select * from preinfo where p_no = @p_no", parm))
                {
                    // Scroll through the results
                    while (rdr.Read())
                    {
                        rowCount = rowCount + 1;
                    }
                }
                return rowCount;
            }
        }

        /// <summary>
        /// 按礼品编号查询
        /// </summary>
        /// <param name="p_no"></param>
        /// <returns></returns>
        public PreInfoData GetPreInfoByNo(string p_no)
        {
            PreInfoData preInfoData = null;
            SqlParameter parm = new SqlParameter(PARM_P_NO, SqlDbType.VarChar, 50);
            parm.Value = p_no;
           
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = parm;

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_PREINFO_BY_PNO2, parms))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    preInfoData = getPreInfoByDataReader(rdr);
                }
            }
            return preInfoData;
        }

        /// <summary>
        /// 修改礼品信息
        /// </summary>
        /// <param name="data"></param>
        public void updatePreInfo(PreInfoData data)
        {
            SqlParameter[] preInfoParms;
            SqlCommand cmd = new SqlCommand();
            preInfoParms = GetUpdatePreInfoParameters();
            preInfoParms[0].Value = data.P_no;
            preInfoParms[1].Value = data.Id;
            preInfoParms[2].Value = data.P_name;
            preInfoParms[3].Value = data.Pretype;
            preInfoParms[4].Value = data.Unit;
            preInfoParms[5].Value = data.Unit_price;
            preInfoParms[6].Value = data.Cost_price;
            preInfoParms[7].Value = data.Acc_qnt;
            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_UPDATE_PREINFO, preInfoParms);

            }
        }

        /// <summary>
        /// 修改礼品信息库存
        /// </summary>
        /// <param name="pno"></param>
        /// <param name="accQnt"></param>
        public void updatePreInfoAccQnt(string pno,int accQnt)
        {
            SqlParameter[] preInfoParms;
            SqlCommand cmd = new SqlCommand();
            preInfoParms = GetUpdatePreInfoAccQntParameters();
            preInfoParms[0].Value = accQnt;
            preInfoParms[1].Value = pno;
            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_UPDATE_PREINFO_ACCQNT, preInfoParms);
            }
        }

        /// <summary>
        /// 新增礼品信息
        /// </summary>
        /// <param name="data"></param>
        public void insertPreInfo(PreInfoData data)
        {
            SqlParameter[] preInfoParms;
            SqlCommand cmd = new SqlCommand();
            preInfoParms = GetInsertPreInfoParameters();
            preInfoParms[0].Value = data.P_no;
            preInfoParms[1].Value = data.Pretype;
            preInfoParms[2].Value = data.P_name;
            preInfoParms[3].Value = data.Unit;
            preInfoParms[4].Value = data.Unit_price;
            preInfoParms[5].Value = data.Cost_price;
            preInfoParms[6].Value = data.Acc_qnt;
            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_INSERT_PREINFO, preInfoParms);
                //foreach (SqlParameter parm in preInfoParms)
                //    cmd.Parameters.Add(parm);

                //// Open the connection
                //conn.Open();

                ////Set up the command
                //cmd.Connection = conn;
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = SQL_INSERT_PREINFO;

                ////Execute the query
                //cmd.ExecuteNonQuery();
                //cmd.Parameters.Clear();

            }
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="preid"></param>
        public void deletePerInfo(int preid)
        {
            SqlParameter[] PreTypeParms;
            SqlCommand cmd = new SqlCommand();
            PreTypeParms = GetDeletePreInfoParameters();
            PreTypeParms[0].Value = preid;
            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_DELETE_PREINFO, PreTypeParms);
            }
        }


        /// <summary>
        /// 查找入库凭证和出库凭证中是否有给定的id的记录
        /// </summary>
        /// <param name="p_no"></param>
        /// <returns></returns>
        public bool haveInOutScrpByPno(int p_no)
        {
            
            int count = 0;
            SqlParameter parm = new SqlParameter(PARM_ID, SqlDbType.Int);
            parm.Value = p_no;
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = parm;

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SELECT_INSCRP_BY_PNO, parms))
            {
                // Scroll through the results
                if (rdr.Read())
                {
                    count = Int32.Parse(rdr[0].ToString());
                }
            }
            if (count > 0)
            {
                return true;
            }
            else
            {
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SELECT_OUTSCRP_BY_PNO, parms))
                {
                    // Scroll through the results
                    if (rdr.Read())
                    {
                        count = Int32.Parse(rdr[0].ToString());
                    }
                }
                if (count > 0)
                {
                    return true;
                }
            }
            
            return false;
        }


        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetUpdatePreInfoParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_UPDATE_PREINFO);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARM_P_NO, SqlDbType.VarChar,50),
					new SqlParameter(PARM_ID, SqlDbType.Int),
                    new SqlParameter(PARM_PNAME, SqlDbType.VarChar, 50),
                    new SqlParameter(PARM_PRETYPE, SqlDbType.VarChar, 50),
                    new SqlParameter(PARM_UNIT, SqlDbType.VarChar, 50),
                    new SqlParameter(PARM_UNITPRICE, SqlDbType.Decimal),
                    new SqlParameter(PARM_COSTPRICE, SqlDbType.Decimal),
                    new SqlParameter(PARM_ACCQNT, SqlDbType.Int)};

                SqlHelper.CacheParameters(SQL_UPDATE_PREINFO, parms);
            }

            return parms;
        }

        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetInsertPreInfoParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_INSERT_PREINFO);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARM_P_NO, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_PRETYPE, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_PNAME, SqlDbType.VarChar, 50),
                    new SqlParameter(PARM_UNIT, SqlDbType.VarChar, 50),
                    new SqlParameter(PARM_UNITPRICE, SqlDbType.Decimal),
                    new SqlParameter(PARM_COSTPRICE, SqlDbType.Decimal),
                    new SqlParameter(PARM_ACCQNT, SqlDbType.Int)};

                SqlHelper.CacheParameters(SQL_INSERT_PREINFO, parms);
            }

            return parms;
        }


        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetDeletePreInfoParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_DELETE_PREINFO);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARM_ID, SqlDbType.Int)};

                SqlHelper.CacheParameters(SQL_DELETE_PREINFO, parms);
            }

            return parms;
        }

        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetUpdatePreInfoAccQntParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_UPDATE_PREINFO_ACCQNT);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					
                    new SqlParameter(PARM_ACCQNT, SqlDbType.Int),
                    new SqlParameter(PARM_P_NO, SqlDbType.VarChar,50)};

                SqlHelper.CacheParameters(SQL_UPDATE_PREINFO_ACCQNT, parms);
            }

            return parms;
        }


        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetPreInfoForStatInOutSumParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(STORE_SPSTOREQNT1);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					
                    new SqlParameter(PARM_START, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_END, SqlDbType.VarChar,50)};

                SqlHelper.CacheParameters(STORE_SPSTOREQNT1, parms);
            }

            return parms;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="rdr"></param>
        /// <returns></returns>
        private PreInfoData getPreInfoByDataReader(SqlDataReader rdr)
        {
            PreInfoData preInfoData = new PreInfoData(
                        (rdr[0] == null || rdr[0] == DBNull.Value) ? 0 : rdr.GetInt32(0),
                        (SqlHelper.GetStringValue(rdr[1])).Trim(),
                        (SqlHelper.GetStringValue(rdr[2])).Trim(),
                        (SqlHelper.GetStringValue(rdr[3])).Trim(),
                        (SqlHelper.GetStringValue(rdr[4])).Trim(),
                        (rdr[5] == null || rdr[5] == DBNull.Value) ? 0 : rdr.GetDecimal(5),
                        (rdr[6] == null || rdr[6] == DBNull.Value) ? 0 : rdr.GetDecimal(6),
                        (rdr[7] == null || rdr[7] == DBNull.Value) ? 0 : rdr.GetInt32(7)
                        );
            return preInfoData;
        }



    }
}
