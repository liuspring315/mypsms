
using System.Collections.Generic;
using psms.Model;
using psms.IDAL;
using System.Data;

namespace psms.BLL
{
    /// <summary>
    /// A business component to manage product items
    /// </summary>
    public class InTable
    {
        // Get an instance of the Item DAL using the DALFactory
        // Making this static will cache the DAL instance after the initial load
        private static readonly IInTable dal = psms.DALFactory.DataAccess.CreateInTable();

        /// <summary>
        /// A method to list items by productId
        /// Every item is associated with a parent product
        /// </summary>
        /// <param name="productId">The productId to search by</param> 
        /// <returns>A Generic List of ItemInfo</returns>
        public IList<InTableInfo> GetAllInTable()
        {
            return dal.GetAllInTable();
        }

        /// <summary>
        /// 新建
        /// </summary>
        /// <returns></returns>
        public bool insertInTable(InTableInfo data)
        {
            if (data == null)
                return false;
            return dal.insertInTable(data);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public bool updateInTable(InTableInfo data)
        {
            if (data == null)
                return false;
            return dal.updateInTable(data);
        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public IList<InTableInfo> GetInTableByCondition(string condition)
        {
            return dal.GetInTableByCondition(condition);
        }

        /// <summary>
        /// 统计
        /// </summary>
        /// <returns></returns>
        public IList<IList<string>> GetInTableForReport(string startTime, string endTime,string condition)
        {
            return dal.GetInTableForReport(startTime, endTime, condition);
        }

        /// <summary>
        /// 统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableInTableForReport(string startTime, string endTime, string condition)
        {
            return dal.GetDataTableInTableForReport(startTime, endTime, condition);
        }

        /// <summary>
        /// 统计2
        /// </summary>
        /// <returns></returns>
        public IList<IList<string>> GetInTableForReport2(string startTime, string endTime, string condition)
        {

            return dal.GetInTableForReport2(startTime, endTime, condition);
        }

        /// <summary>
        /// 确认提货
        /// </summary>
        /// <param name="in_scrpno"></param>
        /// <returns></returns>
        public bool setGoodAcc(string in_scrpno)
        {
            return dal.setGoodAcc(in_scrpno);
        }

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
        public bool UnInTable(InTableInfo data, System.ComponentModel.BindingList<InScrpInfo> inScrpList)
        {
            return dal.UnInTable(data, inScrpList);
        }


        /// <summary>
        /// 得到最大的入库凭证编号
        /// </summary>
        /// <returns></returns>
        public string GetTopInScrpno()
        {
            return dal.GetTopInScrpno();
        
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="in_scrpno"></param>
        /// <returns></returns>
        public bool deleteIntable(string in_scrpno)
        {
            return dal.deleteIntable(in_scrpno);
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
            return dal.GetDataTableReInTableForReport(startTime, endTime, condition);
        }






    }
}
