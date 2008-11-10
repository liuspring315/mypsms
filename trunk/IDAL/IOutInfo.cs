using System.Collections.Generic;

//References to psms specific libraries
//psms busines entity library
using psms.Model;

namespace psms.IDAL
{
    /// <summary>
    /// Interface to the OutInfo DAL
    /// </summary>
    public interface IOutInfo
    {

        /// <summary>
        /// </summary>
        /// <returns>Interface to Model Collection Generic of the results</returns>
        IList<OutInfoData> GetAllOutInfo();

        void updateOutInfo(string out_ou,string out_ou_old);

        void insertOutInfo(string data);

        int GetOutInfoByOutou(string out_ou);

        void deleteOutInfo(string out_ou);

        /// <summary>
        /// 各部门领取宣传品统计
        /// </summary>
        /// <returns></returns>
        IList<IList<string>> GetOutInfoForStatOutSum(string startTime, string endTime, string condition);

    }
}
