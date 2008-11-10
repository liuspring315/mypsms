
using System.Collections.Generic;
using psms.Model;
using psms.IDAL;

namespace psms.BLL
{
    /// <summary>
    /// A business component to manage product items
    /// </summary>
    public class PreAcc
    {
        // Get an instance of the Item DAL using the DALFactory
        // Making this static will cache the DAL instance after the initial load
        private static readonly IPreAcc dal = psms.DALFactory.DataAccess.CreatePreAcc();


        //�õ��������ʼ�¼
        public IList<PreAccInfo> GetAllPreAcc()
        {
            return dal.GetAllPreAcc();
        }

        //���� ���ƾ֤
        public bool insertPreAccForInTable(IList<PreAccInfo> list)
        {
            return dal.insertPreAccForInTable(list);
        }


        //���� ����ƾ֤
        public bool insertPreAccForOutTable(IList<PreAccInfo> list)
        {
            return dal.insertPreAccForOutTable(list);
        }



    }
}
