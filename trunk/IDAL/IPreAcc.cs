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
        //做账 入库凭证
        bool insertPreAccForInTable(IList<PreAccInfo> list);

        //做账 出库凭证
        bool insertPreAccForOutTable(IList<PreAccInfo> list);

        //得到所有做帐记录
        IList<PreAccInfo> GetAllPreAcc();



    }
}
