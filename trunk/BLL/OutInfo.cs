
using System.Collections.Generic;
using psms.Model;
using psms.IDAL;

namespace psms.BLL
{
    /// <summary>
    /// A business component to manage product items
    /// </summary>
    public class OutInfo
    {
        // Get an instance of the Item DAL using the DALFactory
        // Making this static will cache the DAL instance after the initial load
        private static readonly IOutInfo dal = psms.DALFactory.DataAccess.CreateOutInfo();

        /// <summary>
        /// �õ��������쵥λ
        /// </summary>
        /// <returns>A Generic List of ItemInfo</returns>
        public IList<OutInfoData> GetAllOutInfo()
        {

        //// Validate input
        //if (string.IsNullOrEmpty(productId))
        //    return new List<ActionInfo>();

            // Use the dal to search by productId
            return dal.GetAllOutInfo();
        }


        /// <summary>
        /// �޸�
        /// </summary>
        /// <returns></returns>
        public void updateOutInfo(string out_ou,string out_ou_old)
        {
            //// Validate input
            if (string.IsNullOrEmpty(out_ou) || string.IsNullOrEmpty(out_ou_old))
                return;

            // Use the dal to search by productId
            dal.updateOutInfo(out_ou, out_ou_old);
        }
        /// <summary>
        /// �½�
        /// </summary>
        /// <returns></returns>
        public void insertOutInfo(string out_ou)
        {
            //// Validate input
            if (out_ou == null)
                return;

            // Use the dal to search by productId
            dal.insertOutInfo(out_ou);
        }

        /// <summary>
        /// ����out_ou
        /// </summary>
        /// <returns></returns>
        public int GetOutInfoByOutou(string out_ou)
        {
            return dal.GetOutInfoByOutou(out_ou);
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <returns></returns>
        public void deleteOutInfo(string out_ou)
        {
            dal.deleteOutInfo(out_ou);
        }

        /// <summary>
        /// ��������ȡ����Ʒͳ��
        /// </summary>
        /// <returns></returns>
        public IList<IList<string>> GetOutInfoForStatOutSum(string startTime, string endTime, string condition)
        {
            return dal.GetOutInfoForStatOutSum(startTime,endTime,condition);
        }

   




    }
}
