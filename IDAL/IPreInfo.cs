using System.Collections.Generic;

//References to psms specific libraries
//psms busines entity library
using psms.Model;
using System.Data;

namespace psms.IDAL
{
    /// <summary>
    /// Interface to the PreInfo DAL
    /// </summary>
    public interface IPreInfo
    {

        /// <summary>
        /// </summary>
        /// <returns>Interface to Model Collection Generic of the results</returns>
        IList<PreInfoData> GetAllPreInfo();

        /// <summary>
        /// 按礼品编号查询
        /// </summary>
        /// <param name="p_no"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        int GetPreInfoByNo(string p_no,int id);

        /// <summary>
        /// 按礼品编号查询
        /// </summary>
        /// <param name="p_no"></param>
        /// <returns></returns>
        PreInfoData GetPreInfoByNo(string p_no);


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="data"></param>
        void updatePreInfo(PreInfoData data);

        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="data"></param>
        void insertPreInfo(PreInfoData data);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="preid"></param>
        void deletePerInfo(int preid);

        /// <summary>
        /// 用于盘存初始化
        /// </summary>
        /// <returns></returns>
        IList<PreInfoData> GetPreInfoForCheckTable();

        /// <summary>
        /// 根据where条件查询
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IList<PreInfoData> GetPreInfoByCondition(string condition);

        /// <summary>
        /// 修改库存
        /// </summary>
        /// <param name="pno"></param>
        /// <param name="accQnt"></param>
        void updatePreInfoAccQnt(string pno, int accQnt);

        /// <summary>
        /// 用于报表显示
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        DataTable GetPreInfoForStatInOutSum(string startTime, string endTime, string condition);


        /// <summary>
        /// 宣传品进销存统计
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        IList<IList<string>> GetPreInfoForStatInOutSumspStoreqnt1(string startTime, string endTime,string condition);

        /// <summary>
        /// 宣传品进销存统计
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        DataTable GetDataTablePreInfoForStatInOutSumspStoreqnt1(string startTime, string endTime, string condition);

        /// <summary>
        /// 查找入库凭证和出库凭证中是否有给定的p_no的记录
        /// </summary>
        /// <param name="p_no"></param>
        /// <returns></returns>
        bool haveInOutScrpByPno(int p_no);

        /// <summary>
        /// 得到当前库存总量及金额
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        string[] GetPreInfoCount();


        /// <summary>
        /// 通用
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        DataTable GetDataTableBySql(string sql);

    
    }
}
