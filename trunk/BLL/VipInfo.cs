
using System.Collections.Generic;
using psms.Model;
using psms.IDAL;

namespace psms.BLL
{
    /// <summary>
    /// A business component to manage product items
    /// </summary>
    public class VipInfo
    {
        // Get an instance of the Item DAL using the DALFactory
        // Making this static will cache the DAL instance after the initial load
        private static readonly IVipInfo dal = psms.DALFactory.DataAccess.CreateVipInfo();

        /// <summary>
        /// 得到所有
        /// </summary>
        /// <param name="productId">The productId to search by</param> 
        /// <returns>A Generic List of ItemInfo</returns>
        public IList<VipInfoData> GetAllVipInfo()
        {

        //// Validate input
        //if (string.IsNullOrEmpty(productId))
        //    return new List<ActionInfo>();

            // Use the dal to search by productId
            return dal.GetAllVipInfo();
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public void updateVipInfo(string vip_ou,string vip_ou_old)
        {
            //// Validate input
            if (string.IsNullOrEmpty(vip_ou) || string.IsNullOrEmpty(vip_ou_old))
                return;

            // Use the dal to search by productId
            dal.updateVipInfo(vip_ou, vip_ou_old);
        }

        /// <summary>
        /// 新建
        /// </summary>
        /// <returns></returns>
        public void insertVipInfo(string vip_ou)
        {
            //// Validate input
            if (vip_ou == null)
                return;

            // Use the dal to search by productId
            dal.insertVipInfo(vip_ou);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public void deleteVipInfo(string vip_ou)
        {
            dal.deleteVipInfo(vip_ou);
        }


        /// <summary>
        /// 根据vip_ou是否已存在
        /// </summary>
        /// <returns></returns>
        public int GetVipInfoByVipou(string vip_ou)
        {
            return dal.GetVipInfoByOutou(vip_ou);
        }


        /// <summary>
        /// 各单位赠送宣传品统计
        /// </summary>
        /// <returns></returns>
        public IList<IList<string>> GetVipInfoForStatVipSum(string startTime, string endTime, string condition)
        {
            return dal.GetVipInfoForStatVipSum(startTime, endTime, condition);
        }




    }
}
