
using System.Collections.Generic;
using psms.Model;
using psms.IDAL;
using System.Data;

namespace psms.BLL
{
    /// <summary>
    /// A busOutess component to manage product items
    /// </summary>
    public class OutTable
    {
        // Get an Outstance of the Item DAL usOutg the DALFactory
        // MakOutg this static will cache the DAL Outstance after the Outitial load
        private static readonly IOutTable dal = psms.DALFactory.DataAccess.CreateOutTable();

        /// <summary>
        /// A method to list items by productId
        /// Every item is associated with a parent product
        /// </summary>
        /// <param name="productId">The productId to search by</param> 
        /// <returns>A Generic List of ItemOutfo</returns>
        public IList<OutTableInfo> GetAllOutTable()
        {
            return dal.GetAllOutTable();
        }


        /// <summary>
        /// 新建
        /// </summary>
        /// <returns></returns>
        public bool insertOutTable(OutTableInfo data)
        {
            return dal.insertOutTable(data);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public bool updateOutTable(OutTableInfo data)
        {
            return dal.updateOutTable(data);
        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <returns></returns>
        public IList<OutTableInfo> GetOutTableByCondition(string condition)
        {
            return dal.GetOutTableByCondition(condition);
        }

        /// <summary>
        /// 凭证数据统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetOutTableForStatQntSum(string startTime, string endTime)
        {
            return dal.GetOutTableForStatQntSum(startTime, endTime);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IList<IList<string>> GetOutTableForSUM(string startTime, string endTime, string condition)
        {
            return dal.GetOutTableForSUM(startTime,endTime,condition);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IList<IList<string>> GetOutTableForStatQntSum(string startTime, string endTime, string condition)
        {
            return dal.GetOutTableForStatQntSum(startTime, endTime, condition);
        }


        /// <summary>
        /// 按领取礼品单位分组
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IList<IList<string>> GetStatOutTableGroupByOutOuByCon(string condition)
        {
            return dal.GetStatOutTableGroupByOutOuByCon(condition);
        }


        /// <summary>
        /// 根据条件统计所有的出库数量
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public int GetStatOutTableAllOutOuByCon(string condition)
        {
            return dal.GetStatOutTableAllOutOuByCon(condition);
        }

        /// <summary>
        /// 出库统计报表
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataTable GetOutTableDataTableForStatQntSum(string startTime, string endTime, string condition)
        {
            return dal.GetOutTableDataTableForStatQntSum(startTime, endTime, condition);
        }


        /// <summary>
        /// 按领取礼品单位分组 用于部门领取情况统计报表
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataTable GetStatOutOuGroupByOutOuByCon(string condition)
        {
            return dal.GetStatOutOuGroupByOutOuByCon(condition);
        }

        /// <summary>
        /// 按领取礼品单位分组 用于赠送情况统计报表
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataTable GetStatVipOuGroupByOutOuByCon(string condition)
        {
            return dal.GetStatVipOuGroupByOutOuByCon(condition);
        }


        /// <summary>
        /// 凭证数据统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetOutTableForStatQntSum(string condition)
        {
            return dal.GetOutTableForStatQntSum(condition);
        }


        /// <summary>
        /// 得到最大的出库凭证编号
        /// </summary>
        /// <returns></returns>
        public string GetTopOutScrpNo()
        {
            return dal.GetTopOutScrpNo();
        
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="out_scrpno"></param>
        /// <returns></returns>
        public bool deleteOutTable(string out_scrpno)
        {
            return dal.deleteOutTable(out_scrpno);
        }


    }
}
