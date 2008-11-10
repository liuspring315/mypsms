using System.Collections.Generic;

//References to psms specific libraries
//psms busines entity library
using psms.Model;

namespace psms.IDAL
{
    /// <summary>
    /// Interface to the InInfo DAL
    /// </summary>
    public interface IInInfo
    {

        /// <summary>
        /// </summary>
        /// <returns>Interface to Model Collection Generic of the results</returns>
        IList<InInfoData> GetAllInInfo();

        void updateInInfo(string in_ou,string in_ou_old);

        void insertInInfo(string data);

        int GetInInfoByInou(string in_ou);


        void deleteInInfo(string in_ou);

    }
}
