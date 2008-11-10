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
        /// ͳ��
        /// </summary>
        /// <returns></returns>
        IList<IList<string>> GetInTableForReport(string startTime, string endTime,string condition);

        /// <summary>
        /// ͳ��
        /// </summary>
        /// <returns></returns>
        DataTable GetDataTableInTableForReport(string startTime, string endTime, string condition);

        /// <summary>
        /// ͳ��2
        /// </summary>
        /// <returns></returns>
        IList<IList<string>> GetInTableForReport2(string startTime, string endTime, string condition);

        /// <summary>
        /// ȷ�����
        /// </summary>
        /// <param name="in_scrpno"></param>
        /// <returns></returns>
        bool setGoodAcc(string in_scrpno);


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

        bool UnInTable(InTableInfo data, System.ComponentModel.BindingList<InScrpInfo> inScrpList);

        /// <summary>
        /// �õ��������ƾ֤���
        /// </summary>
        /// <returns></returns>
        string GetTopInScrpno();

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="in_scrpno"></param>
        /// <returns></returns>
        bool deleteIntable(string in_scrpno);


        /// <summary>
        /// �˿�ͳ��
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        DataTable GetDataTableReInTableForReport(string startTime, string endTime, string condition);

    }
}
