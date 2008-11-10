using System.Collections.Generic;

//References to psms specific libraries
//psms busines entity library
using psms.Model;

namespace psms.IDAL
{
    /// <summary>
    /// Interface to the VipInfo DAL
    /// </summary>
    public interface ICheckTable
    {

        /// <summary>
        /// </summary>
        /// <returns>Interface to Model Collection Generic of the results</returns>
        IList<CheckTableInfo> GetAllCheckTableInfo();

        bool insertCheckTableInfo(IList<CheckTableInfo> list);

        int GetCheckNo();

        IList<CheckTableInfo> GetCheckTableInfoByCheckNo(int check_no);

        IList<CheckTableInfo> GetCheckTableInfoByCondition(string condition);

    }
}
