using System.Collections.Generic;

//References to psms specific libraries
//psms busines entity library
using psms.Model;

namespace psms.IDAL
{
    /// <summary>
    /// Interface to the VipInfo DAL
    /// </summary>
    public interface IPreAcc
    {

        /// <summary>
        /// </summary>
        /// <returns>Interface to Model Collection Generic of the results</returns>
        //���� ���ƾ֤
        bool insertPreAccForInTable(IList<PreAccInfo> list);

        //���� ����ƾ֤
        bool insertPreAccForOutTable(IList<PreAccInfo> list);

        //�õ��������ʼ�¼
        IList<PreAccInfo> GetAllPreAcc();



    }
}
