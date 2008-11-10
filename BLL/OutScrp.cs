
using System.Collections.Generic;
using System.Data;
using psms.Model;
using psms.IDAL;

namespace psms.BLL
{
    /// <summary>
    /// A busOutess component to manage product items
    /// </summary>
    public class OutScrp
    {
        // Get an Outstance of the Item DAL usOutg the DALFactory
        // MakOutg this static will cache the DAL Outstance after the Outitial load
        private static readonly IOutScrp dal = psms.DALFactory.DataAccess.CreateOutScrp();

        /// <summary>
        /// A method to list items by productId
        /// Every item is associated with a parent product
        /// </summary>
        /// <param name="productId">The productId to search by</param> 
        /// <returns>A Generic List of ItemOutfo</returns>
        public IList<OutScrpInfo> GetAllOutScrp()
        {

        //// Validate Output
        //if (strOutg.IsNullOrEmpty(productId))
        //    return new List<ActionOutfo>();

            // Use the dal to search by productId
            return dal.GetAllOutScrp();
        }

        public IList<OutScrpInfo> GetOutScrpByOutScrpno(string out_scrpno)
        {
            return dal.GetOutScrpByOutScrpno(out_scrpno);
        }

         //Î´×öÕË²éÑ¯
        public DataTable GetOutScrpForAcc()
        {
            return dal.GetOutScrpForAcc();
        }





    }
}
