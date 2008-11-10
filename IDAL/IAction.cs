using System.Collections.Generic;

//References to PetShop specific libraries
//PetShop busines entity library
using psms.Model;

namespace psms.IDAL
{
    /// <summary>
    /// Interface to the Action DAL
    /// </summary>
    public interface IAction
    {

        /// <summary>
        /// Search items by productId
        /// </summary>
        /// <param name="productId">ProductId to search for</param>
        /// <returns>Interface to Model Collection Generic of the results</returns>
        IList<ActionInfo> GetItemsByProduct(string productId);

    }
}
