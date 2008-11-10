using System.Collections.Generic;

//References to psms specific libraries
//psms busOutes entity library
using psms.Model;
using System.Data;

namespace psms.IDAL
{
    /// <summary>
    /// Outterface to the OutTable DAL
    /// </summary>
    public interface IOutTable
    {

        /// <summary>
        /// </summary>
        /// <returns>Outterface to Model Collection Generic of the results</returns>
        IList<OutTableInfo> GetAllOutTable();

        bool updateOutTable(OutTableInfo data);

        bool insertOutTable(OutTableInfo data);


        IList<OutTableInfo> GetOutTableByCondition(string condition);

        /// <summary>
        /// 凭证数据统计
        /// </summary>
        /// <returns></returns>
        DataTable GetOutTableForStatQntSum(string startTime, string endTime);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        IList<IList<string>> GetOutTableForSUM(string startTime, string endTime, string condition);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        IList<IList<string>> GetOutTableForStatQntSum(string startTime, string endTime, string condition);


        /// <summary>
        /// 按领取礼品单位分组
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IList<IList<string>> GetStatOutTableGroupByOutOuByCon(string condition);


        /// <summary>
        /// 根据条件统计所有的出库数量
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        int GetStatOutTableAllOutOuByCon(string condition);

        /// <summary>
        /// 出库统计报表
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        DataTable GetOutTableDataTableForStatQntSum(string startTime, string endTime, string condition);


        /// <summary>
        /// 按领取礼品单位分组 用于部门领取情况统计报表
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        DataTable GetStatOutOuGroupByOutOuByCon(string condition);

        /// <summary>
        /// 按领取礼品单位分组 用于赠送情况统计报表
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        DataTable GetStatVipOuGroupByOutOuByCon(string condition);


        /// <summary>
        /// 凭证数据统计
        /// </summary>
        /// <returns></returns>
        
        DataTable GetOutTableForStatQntSum(string condition);

        /// <summary>
        /// 得到最大的出库凭证编号
        /// </summary>
        /// <returns></returns>
        
        string GetTopOutScrpNo();



        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="out_scrpno"></param>
        /// <returns></returns>
        bool deleteOutTable(string out_scrpno);




    }
}
