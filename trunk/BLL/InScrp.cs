
using System.Collections.Generic;
using System.Data;
using psms.Model;
using psms.IDAL;

namespace psms.BLL
{
    /// <summary>
    /// A business component to manage product items
    /// </summary>
    public class InScrp
    {
        // Get an instance of the Item DAL using the DALFactory
        // Making this static will cache the DAL instance after the initial load
        private static readonly IInScrp dal = psms.DALFactory.DataAccess.CreateInScrp();

        /// <summary>
        /// A method to list items by productId
        /// Every item is associated with a parent product
        /// </summary>
        /// <param name="productId">The productId to search by</param> 
        /// <returns>A Generic List of ItemInfo</returns>
        public IList<InScrpInfo> GetInScrpByInScrpno(string in_scrpno)
        {

            //// Validate input
            if (string.IsNullOrEmpty(in_scrpno))
                return new List<InScrpInfo>();

            // Use the dal to search by productId
            return dal.GetInScrpByInScrpno(in_scrpno);
        }

        public DataTable GetInScrpForAcc()
        {
            return dal.GetInScrpForAcc();
        }

    }
}
