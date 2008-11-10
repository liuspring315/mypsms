using System.Collections.Generic;

//References to psms specific libraries
//psms busines entity library
using psms.Model;

namespace psms.IDAL
{
    /// <summary>
    /// Interface to the VipInfo DAL
    /// </summary>
    public interface IVipInfo
    {

        /// <summary>
        /// </summary>
        /// <returns>Interface to Model Collection Generic of the results</returns>
        IList<VipInfoData> GetAllVipInfo();

        void updateVipInfo(string vip_ou,string vip_ou_old);

        void insertVipInfo(string data);

        void deleteVipInfo(string vip_ou);

        int GetVipInfoByOutou(string vip_ou);

        /// <summary>
        /// 各单位赠送宣传品统计
        /// </summary>
        /// <returns></returns>
        IList<IList<string>> GetVipInfoForStatVipSum(string startTime, string endTime, string condition);

    }
}
