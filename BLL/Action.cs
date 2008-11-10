using System.Collections.Generic;
using psms.Model;
using psms.IDAL;

namespace psms.BLL
{
    /// <summary>
    /// A business component to manage product items
    /// </summary>
    public class Action
    {
        // Get an instance of the Item DAL using the DALFactory
        // Making this static will cache the DAL instance after the initial load
        private static readonly IAction dal = psms.DALFactory.DataAccess.CreateItem();

        /// <summary>
        /// A method to list items by productId
        /// Every item is associated with a parent product
        /// </summary>
        /// <param name="productId">The productId to search by</param> 
        /// <returns>A Generic List of ItemInfo</returns>
        public IList<ActionInfo> GetItemsByProduct(string productId)
        {

            // Validate input
            if (string.IsNullOrEmpty(productId))
                return new List<ActionInfo>();

            // Use the dal to search by productId
            return dal.GetItemsByProduct(productId);
        }
    }
}
