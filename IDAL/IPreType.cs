using System.Collections.Generic;

//References to IPreType specific libraries
//PetShop busines entity library
using psms.Model;

namespace psms.IDAL
{
    /// <summary>
    /// Interface to the Action DAL
    /// </summary>
    public interface IPreType
    {

        /// <summary>
        /// </summary>
        /// <param name="productId">ProductId to search for</param>
        /// <returns>Interface to Model Collection Generic of the results</returns>
        IList<PreTypeInfo> GetAllPreTypeInfo();

        void updatePreType(string typename, int typeid);

        void insertPreType(string typename);

        void deletePerType(int typeid);

        int GetPreTypeByTypeName(string typename);

    }
}
