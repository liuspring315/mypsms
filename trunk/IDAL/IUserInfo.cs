using System.Collections.Generic;

//References to psms specific libraries
//psms busines entity library
using psms.Model;

namespace psms.IDAL
{
    /// <summary>
    /// Interface to the UserInfo DAL
    /// </summary>
    public interface IUserInfo
    {

        /// <summary>
        /// </summary>
        /// <returns>Interface to Model Collection Generic of the results</returns>
        IList<UserInfoData> GetAllUserInfo();

        int GetUserInfoByNo(string username,int id);

        void updateUserInfo(UserInfoData data);

        void insertUserInfo(UserInfoData data);

        void deleteUserInfo(int id);

    }
}
