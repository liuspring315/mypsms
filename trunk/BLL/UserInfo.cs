
using System.Collections.Generic;
using psms.Model;
using psms.IDAL;

namespace psms.BLL
{
    /// <summary>
    /// A business component to manage product items
    /// </summary>
    public class UserInfo
    {
        // Get an instance of the Item DAL using the DALFactory
        // Making this static will cache the DAL instance after the initial load
        private static readonly IUserInfo dal = psms.DALFactory.DataAccess.CreateUserInfo();

        /// <summary>
        /// A method to list items by productId
        /// Every item is associated with a parent product
        /// </summary>
        /// <param name="productId">The productId to search by</param> 
        /// <returns>A Generic List of ItemInfo</returns>
        public IList<UserInfoData> GetAllUserInfo()
        {

        //// Validate input
        //if (string.IsNullOrEmpty(productId))
        //    return new List<ActionInfo>();

            // Use the dal to search by productId
            return dal.GetAllUserInfo();
        }

        public int GetUserInfoByNo(string username,int id)
        {
            //// Validate input
            if (string.IsNullOrEmpty(username))
                return 0;

            // Use the dal to search by productId
            return dal.GetUserInfoByNo(username,id);
        }

        public void updateUserInfo(UserInfoData data)
        {
            //// Validate input
            if (data == null)
                return;

            // Use the dal to search by productId
            dal.updateUserInfo(data);
        }

        public void insertUserInfo(UserInfoData data)
        {
            //// Validate input
            if (data == null)
                return;

            // Use the dal to search by productId
            dal.insertUserInfo(data);
        }

        public void deleteUserInfo(int id)
        {
            dal.deleteUserInfo(id);
        }




    }
}
