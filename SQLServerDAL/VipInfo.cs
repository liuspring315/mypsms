using System;
using System.Data;
using System.Data.SqlClient;
using psms.Model;
using psms.IDAL;
using System.Collections.Generic;
using psms.DBUtility;

namespace psms.SQLServerDAL
{
    public class VipInfo : IVipInfo
    {
        // Static constants

        //得到所有请领单位信息sql
        private const string SQL_SELECT_VIPINFO_ALL = "SELECT * from VIPINFO ";


        //修改请领单位信息sql
        private const string SQL_UPDATE_VIPINFO = "UPDATE VIPINFO set vip_ou=@vip_ou where vip_ou = @vip_ou_old";

        //新增请领单位信息sql
        private const string SQL_INSERT_VIPINFO = "INSERT INTO VIPINFO (vip_ou) values (" +
            "@vip_ou)";

        //删除请领单位信息sql
        private const string SQL_DELETE_VIPINFO = "delete from vipinfo where vip_ou=@vip_ou";

        //判断请领单位是否已存在sql
        private const string SQL_SELECT_VIPINFO_BY_VIPOU = "SELECT * from VIPINFO where vip_ou=@vip_ou";

        //各单位赠送宣传品统计
        private const string SQL_SELECT_VIPINFO_FOR_VIPSTAT1 = "select vipinfo.vip_ou, "+
            "( select sum(qnt) from outscrp, outtable,preinfo "+
                    "where outscrp.out_scrpno=outtable.out_scrpno and outtable.vip_ou=vipinfo.vip_ou and outscrp.p_no=preinfo.p_no and out_date >= @start and out_date < @end ";
        private const string SQL_SELECT_VIPINFO_FOR_VIPSTAT2 = ")  as sumqout,"+
            "( select sum(out_price) from outscrp, outtable,preinfo " +
                    "where outscrp.out_scrpno=outtable.out_scrpno and outtable.vip_ou=vipinfo.vip_ou and outscrp.p_no=preinfo.p_no and out_date >= @start and out_date < @end ";
        private const string SQL_SELECT_VIPINFO_FOR_VIPSTAT3 = ")  as sumpout "+
            "from vipinfo "+
            "where ( select sum(qnt) from outscrp, outtable,preinfo where outscrp.out_scrpno=outtable.out_scrpno and outtable.vip_ou=vipinfo.vip_ou and outscrp.p_no=preinfo.p_no and out_date >= @start and out_date < @end ";
        private const string SQL_SELECT_VIPINFO_FOR_VIPSTAT4 = ")  is not null ";
        //private const string SQL_SELECT_VIPINFO_FOR_VIPSTAT2 = " order by vipinfo.vip_group, vipinfo.vip_ou";



        private const string PARM_VIP_OU = "@vip_ou";
        private const string PARM_VIP_OU_OLD = "@vip_ou_old";
        private const string PARM_START = "@start";
        private const string PARM_END = "@end";

        /// <summary>
        /// 得到所有请领单位信息
        /// </summary>
        /// <returns></returns>
        public IList<VipInfoData> GetAllVipInfo()
        {
            IList<VipInfoData> allVipInfo = new List<VipInfoData>();

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text,SQL_SELECT_VIPINFO_ALL))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    VipInfoData inInfoData = new VipInfoData((SqlHelper.GetStringValue(rdr[0])).Trim());
                    //Add each item to the arraylist
                    allVipInfo.Add(inInfoData);
                }
            }
            return allVipInfo;
        }


        /// <summary>
        /// 各单位赠送宣传品统计
        /// </summary>
        /// <returns></returns>
        public IList<IList<string>> GetVipInfoForStatVipSum(string startTime, string endTime, string condition)
        {
            IList<IList<string>> list = new List<IList<string>>();
            SqlParameter[] parms = GetVipInfoForStatVipSumParameters();
            parms[0].Value = startTime;
            parms[1].Value = endTime;
            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, 
                SQL_SELECT_VIPINFO_FOR_VIPSTAT1 + condition + 
                SQL_SELECT_VIPINFO_FOR_VIPSTAT2 + condition + 
                SQL_SELECT_VIPINFO_FOR_VIPSTAT3 + condition + 
                SQL_SELECT_VIPINFO_FOR_VIPSTAT4, parms))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    IList<string> data = new List<string>();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        data.Add((SqlHelper.GetStringValue(rdr[i])).Trim());
                    }
                    list.Add(data);
                }
            }
            return list;
        }

        /// <summary>
        /// 修改请领单位信息
        /// </summary>
        /// <param name="vip_ou"></param>
        /// <param name="vip_ou_old"></param>
        public void updateVipInfo(string vip_ou,string vip_ou_old)
        {
            SqlParameter[] VipInfoParms;
            SqlCommand cmd = new SqlCommand();
            VipInfoParms = GetUpdateVipInfoParameters();
            VipInfoParms[0].Value = vip_ou;
            VipInfoParms[1].Value = vip_ou_old;
            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_UPDATE_VIPINFO, VipInfoParms);
                //foreach (SqlParameter parm in VipInfoParms)
                //     cmd.Parameters.Add(parm);
                  
                //// Open the connection
                //conn.Open();

                ////Set up the command
                //cmd.Connection = conn;
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = SQL_UPDATE_VIPINFO;

                ////Execute the query
                //cmd.ExecuteNonQuery();
                //cmd.Parameters.Clear();

            }
        }

        /// <summary>
        /// xinjian
        /// </summary>
        /// <param name="data"></param>
        public void insertVipInfo(string data)
        {
            SqlParameter[] VipInfoParms;
            SqlCommand cmd = new SqlCommand();
            VipInfoParms = GetInsertVipInfoParameters();
            VipInfoParms[0].Value = data;
            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_INSERT_VIPINFO, VipInfoParms);
                //foreach (SqlParameter parm in VipInfoParms)
                //    cmd.Parameters.Add(parm);

                //// Open the connection
                //conn.Open();

                ////Set up the command
                //cmd.Connection = conn;
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = SQL_INSERT_VIPINFO;

                ////Execute the query
                //cmd.ExecuteNonQuery();
                //cmd.Parameters.Clear();

            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="vip_ou"></param>
        public void deleteVipInfo(string vip_ou)
        {
            SqlParameter[] IninfoParms;
            SqlCommand cmd = new SqlCommand();
            IninfoParms = GetDeleteVipInfoParameters();
            IninfoParms[0].Value = vip_ou;
            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_DELETE_VIPINFO, IninfoParms);
            }
        }

        /// <summary>
        /// 判断请领单位是否已存在
        /// </summary>
        /// <param name="vip_ou"></param>
        /// <returns></returns>
        public int GetVipInfoByOutou(string vip_ou)
        {
            SqlParameter parm = new SqlParameter(PARM_VIP_OU, SqlDbType.VarChar, 50);
            parm.Value = vip_ou;
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = parm;

            int rowCount = 0;
            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_VIPINFO_BY_VIPOU, parms))
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
        private static SqlParameter[] GetUpdateVipInfoParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_UPDATE_VIPINFO);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARM_VIP_OU, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_VIP_OU_OLD, SqlDbType.VarChar, 50)};

                SqlHelper.CacheParameters(SQL_UPDATE_VIPINFO, parms);
            }

            return parms;
        }

        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetInsertVipInfoParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_INSERT_VIPINFO);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARM_VIP_OU, SqlDbType.VarChar,50)};

                SqlHelper.CacheParameters(SQL_INSERT_VIPINFO, parms);
            }

            return parms;
        }


        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetDeleteVipInfoParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_DELETE_VIPINFO);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARM_VIP_OU, SqlDbType.VarChar,50)};

                SqlHelper.CacheParameters(SQL_DELETE_VIPINFO, parms);
            }

            return parms;
        }


        /// <summary>
        /// Internal function to get cached parameters
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetVipInfoForStatVipSumParameters()
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_SELECT_VIPINFO_FOR_VIPSTAT1);

            if (parms == null)
            {
                parms = new SqlParameter[] {
					
                    new SqlParameter(PARM_START, SqlDbType.VarChar,50),
                    new SqlParameter(PARM_END, SqlDbType.VarChar,50)};

                SqlHelper.CacheParameters(SQL_SELECT_VIPINFO_FOR_VIPSTAT1, parms);
            }

            return parms;
        }



    }
}
