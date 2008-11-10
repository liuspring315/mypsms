
using System.Collections.Generic;
using psms.Model;
using psms.IDAL;

namespace psms.BLL
{
    /// <summary>
    /// A business component to manage product items
    /// </summary>
    public class CheckTable
    {
        // Get an instance of the Item DAL using the DALFactory
        // Making this static will cache the DAL instance after the initial load
        private static readonly ICheckTable dal = psms.DALFactory.DataAccess.CreateCheckTable();

        /// <summary>
        /// A method to list items by productId
        /// Every item is associated with a parent product
        /// </summary>
        /// <param name="productId">The productId to search by</param> 
        /// <returns>A Generic List of ItemInfo</returns>
        public IList<CheckTableInfo> GetAllCheckTableInfo()
        {

        //// Validate input
        //if (string.IsNullOrEmpty(productId))
        //    return new List<ActionInfo>();

            // Use the dal to search by productId
            return dal.GetAllCheckTableInfo();
        }

        public bool insertCheckTableInfo(IList<CheckTableInfo> list)
        {
            return dal.insertCheckTableInfo(list);
        }

        public int GetCheckNo()
        {
            return dal.GetCheckNo();
        }

        public IList<CheckTableInfo> GetCheckTableInfoByCheckNo(int check_no)
        {
            return dal.GetCheckTableInfoByCheckNo(check_no);
        }

        public IList<CheckTableInfo> GetCheckTableInfoByCondition(string condition)
        {
            return dal.GetCheckTableInfoByCondition(condition);
        }



   





    }
}
