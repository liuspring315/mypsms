
using System.Collections.Generic;
using psms.Model;
using psms.IDAL;
using System.Data;

namespace psms.BLL
{
    /// <summary>
    /// A business component to manage product items
    /// </summary>
    public class PreInfo
    {
        // Get an instance of the Item DAL using the DALFactory
        // Making this static will cache the DAL instance after the initial load
        private static readonly IPreInfo dal = psms.DALFactory.DataAccess.CreatePreInfo();

        /// <summary>
        /// A method to list items by productId
        /// Every item is associated with a parent product
        /// </summary>
        /// <param name="productId">The productId to search by</param> 
        /// <returns>A Generic List of ItemInfo</returns>
        public IList<PreInfoData> GetAllPreInfo()
        {

        //// Validate input
        //if (string.IsNullOrEmpty(productId))
        //    return new List<ActionInfo>();

            // Use the dal to search by productId
            return dal.GetAllPreInfo();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_no"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetPreInfoByNo(string p_no,int id)
        {
            //// Validate input
            if (string.IsNullOrEmpty(p_no))
                return 0;

            // Use the dal to search by productId
            return dal.GetPreInfoByNo(p_no,id);
        }

        /// <summary>
        /// ����Ʒ��Ų�ѯ
        /// </summary>
        /// <param name="p_no"></param>
        /// <returns></returns>
        public PreInfoData GetPreInfoByNo(string p_no)
        {
            return dal.GetPreInfoByNo(p_no);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void updatePreInfo(PreInfoData data)
        {
            //// Validate input
            if (data == null)
                return;

            // Use the dal to search by productId
            dal.updatePreInfo(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void insertPreInfo(PreInfoData data)
        {
            //// Validate input
            if (data == null)
                return;

            // Use the dal to search by productId
            dal.insertPreInfo(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="preid"></param>
        public void deletePerInfo(int preid)
        {
            dal.deletePerInfo(preid);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<PreInfoData> GetPreInfoForCheckTable()
        {
            return dal.GetPreInfoForCheckTable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IList<PreInfoData> GetPreInfoByCondition(string condition)
        {
            return dal.GetPreInfoByCondition(condition);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pno"></param>
        /// <param name="accQnt"></param>
        public void updatePreInfoAccQnt(string pno, int accQnt)
        {
            dal.updatePreInfoAccQnt(pno, accQnt);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataTable GetPreInfoForStatInOutSum(string startTime, string endTime, string condition)
        {
            return dal.GetPreInfoForStatInOutSum(startTime, endTime, condition);
        }

        /// <summary>
        /// ����Ʒ������ͳ��
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public IList<IList<string>> GetPreInfoForStatInOutSumspStoreqnt1(string startTime, string endTime,string condition)
        {
            return dal.GetPreInfoForStatInOutSumspStoreqnt1(startTime, endTime,condition);
        }


        /// <summary>
        /// ����Ʒ������ͳ��
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public DataTable GetDataTablePreInfoForStatInOutSumspStoreqnt1(string startTime, string endTime, string condition)
        {
            return dal.GetDataTablePreInfoForStatInOutSumspStoreqnt1(startTime, endTime, condition);
        }

        /// <summary>
        /// �������ƾ֤�ͳ���ƾ֤���Ƿ��и�����p_no�ļ�¼
        /// </summary>
        /// <param name="p_no"></param>
        /// <returns></returns>
        public bool haveInOutScrpByPno(int p_no)
        {
            return dal.haveInOutScrpByPno(p_no);
        }

        /// <summary>
        /// �õ���ǰ������������
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public string[] GetPreInfoCount()
        {
            return dal.GetPreInfoCount();
        }

        /// <summary>
        /// ͨ��
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable GetDataTableBySql(string sql)
        {
            return dal.GetDataTableBySql(sql);
        }

    }
}
