
using System.Collections.Generic;
using psms.Model;
using psms.IDAL;

namespace psms.BLL
{
    /// <summary>
    /// A business component to manage product items
    /// </summary>
    public class InInfo
    {
        // Get an instance of the Item DAL using the DALFactory
        // Making this static will cache the DAL instance after the initial load
        private static readonly IInInfo dal = psms.DALFactory.DataAccess.CreateInInfo();

        /// <summary>
        /// A method to list items by productId
        /// Every item is associated with a parent product
        /// </summary>
        /// <param name="productId">The productId to search by</param> 
        /// <returns>A Generic List of ItemInfo</returns>
        public IList<InInfoData> GetAllInInfo()
        {

        //// Validate input
        //if (string.IsNullOrEmpty(productId))
        //    return new List<ActionInfo>();

            // Use the dal to search by productId
            return dal.GetAllInInfo();
        }



        public void updateInInfo(string in_ou,string in_ou_old)
        {
            //// Validate input
            if (string.IsNullOrEmpty(in_ou) || string.IsNullOrEmpty(in_ou_old))
                return;

            // Use the dal to search by productId
            dal.updateInInfo(in_ou, in_ou_old);
        }

        public void insertInInfo(string in_ou)
        {
            //// Validate input
            if (in_ou == null)
                return;

            // Use the dal to search by productId
            dal.insertInInfo(in_ou);
        }


        public int GetInInfoByInou(string in_ou)
        {
            return dal.GetInInfoByInou(in_ou);
        }

        public void deleteInInfo(string in_ou)
        {
            dal.deleteInInfo(in_ou);
        }





    }
}
