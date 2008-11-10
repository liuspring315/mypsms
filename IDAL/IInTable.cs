using System.Collections.Generic;

//References to psms specific libraries
//psms busines entity library
using psms.Model;
using System.Data;

namespace psms.IDAL
{
    /// <summary>
    /// Interface to the InTable DAL
    /// </summary>
    public interface IInTable
    {

        /// <summary>
        /// </summary>
        /// <returns>Interface to Model Collection Generic of the results</returns>
        IList<InTableInfo> GetAllInTable();

        bool updateInTable(InTableInfo data);

        bool insertInTable(InTableInfo data);

        IList<InTableInfo> GetInTableByCondition(string condition);

        /// <summary>
        /// 统计
        /// </summary>
        /// <returns></returns>
        IList<IList<string>> GetInTableForReport(string startTime, string endTime,string condition);

        /// <summary>
        /// 统计
        /// </summary>
        /// <returns></returns>
        DataTable GetDataTableInTableForReport(string startTime, string endTime, string condition);

        /// <summary>
        /// 统计2
        /// </summary>
        /// <returns></returns>
        IList<IList<string>> GetInTableForReport2(string startTime, string endTime, string condition);

        /// <summary>
        /// 确认提货
        /// </summary>
        /// <param name="in_scrpno"></param>
        /// <returns></returns>
        bool setGoodAcc(string in_scrpno);


        /// <summary>
        /// 退库
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

        bool UnInTable(InTableInfo data, System.ComponentModel.BindingList<InScrpInfo> inScrpList);

        /// <summary>
        /// 得到最大的入库凭证编号
        /// </summary>
        /// <returns></returns>
        string GetTopInScrpno();

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="in_scrpno"></param>
        /// <returns></returns>
        bool deleteIntable(string in_scrpno);


        /// <summary>
        /// 退库统计
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        DataTable GetDataTableReInTableForReport(string startTime, string endTime, string condition);

    }
}
