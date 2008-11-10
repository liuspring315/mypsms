
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
        /// �½�
        /// </summary>
        /// <returns></returns>
        public bool insertInTable(InTableInfo data)
        {
            if (data == null)
                return false;
            return dal.insertInTable(data);
        }

        /// <summary>
        /// �޸�
        /// </summary>
        /// <returns></returns>
        public bool updateInTable(InTableInfo data)
        {
            if (data == null)
                return false;
            return dal.updateInTable(data);
        }


        /// <summary>
        /// ��ѯ
        /// </summary>
        /// <returns></returns>
        public IList<InTableInfo> GetInTableByCondition(string condition)
        {
            return dal.GetInTableByCondition(condition);
        }

        /// <summary>
        /// ͳ��
        /// </summary>
        /// <returns></returns>
        public IList<IList<string>> GetInTableForReport(string startTime, string endTime,string condition)
        {
            return dal.GetInTableForReport(startTime, endTime, condition);
        }

        /// <summary>
        /// ͳ��
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableInTableForReport(string startTime, string endTime, string condition)
        {
            return dal.GetDataTableInTableForReport(startTime, endTime, condition);
        }

        /// <summary>
        /// ͳ��2
        /// </summary>
        /// <returns></returns>
        public IList<IList<string>> GetInTableForReport2(string startTime, string endTime, string condition)
        {

            return dal.GetInTableForReport2(startTime, endTime, condition);
        }

        /// <summary>
        /// ȷ�����
        /// </summary>
        /// <param name="in_scrpno"></param>
        /// <returns></returns>
        public bool setGoodAcc(string in_scrpno)
        {
            return dal.setGoodAcc(in_scrpno);
        }

        /// <summary>
        /// �˿�
        /// </summary>
        /// <param name="in_cost">ƾ֤������</param>
        /// <param name="in_scrpno">ƾ֤���</param>
        /// <param name="qnt">�޸ĺ����Ʒ����</param>
        /// <param name="in_price">�޸ĺ����Ʒ������</param>
        /// <param name="p_no">��Ʒ���</param>
        /// <param name="acc_qnt">�޸ĺ�Ŀ��</param>
        /// <param name="s_cost">�޸ĺ�Ŀ����</param>
        /// <param name="uninnum">�˿���</param>
        /// <param name="remark">�˿�ԭ��</param>
        /// <returns></returns>
        public bool UnInTable(InTableInfo data, System.ComponentModel.BindingList<InScrpInfo> inScrpList)
        {
            return dal.UnInTable(data, inScrpList);
        }


        /// <summary>
        /// �õ��������ƾ֤���
        /// </summary>
        /// <returns></returns>
        public string GetTopInScrpno()
        {
            return dal.GetTopInScrpno();
        
        }


        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="in_scrpno"></param>
        /// <returns></returns>
        public bool deleteIntable(string in_scrpno)
        {
            return dal.deleteIntable(in_scrpno);
        }


        /// <summary>
        /// �˿�ͳ��
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
