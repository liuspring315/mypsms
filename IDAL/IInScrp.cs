using System.Collections.Generic;

//References to psms specific libraries
//psms busines entity library
using psms.Model;
using System.Data;

namespace psms.IDAL
{
    /// <summary>
    /// Interface to the InScrp DAL
    /// </summary>
    public interface IInScrp
    {

        /// <summary>
        /// </summary>
        /// <returns>Interface to Model Collection Generic of the results</returns>
        IList<InScrpInfo> GetInScrpByInScrpno(string in_scrpno);

        //void updateInScrp(string in_ou,string in_ou_old);

        //void insertInScrp(string data);

        //IList<InScrpInfo> GetInScrpForAcc();

        DataTable GetInScrpForAcc();

    }
}
