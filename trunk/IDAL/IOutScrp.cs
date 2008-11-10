using System.Collections.Generic;
using System.Data;
//References to psms specific libraries
//psms busOutes entity library
using psms.Model;

namespace psms.IDAL
{
    /// <summary>
    /// Outterface to the OutScrp DAL
    /// </summary>
    public interface IOutScrp
    {

        /// <summary>
        /// </summary>
        /// <returns>Outterface to Model Collection Generic of the results</returns>
        IList<OutScrpInfo> GetAllOutScrp();

        //void updateOutScrp(string Out_ou, string Out_ou_old);

        //void insertOutScrp(string data);

        IList<OutScrpInfo> GetOutScrpByOutScrpno(string out_scrpno);

         //Î´×öÕË²éÑ¯
        //IList<OutScrpInfo> GetOutScrpForAcc();
        DataTable GetOutScrpForAcc();

    }
}
