using System.Collections.Generic;
using psms.Model;
using psms.IDAL;

namespace psms.BLL
{
    /// <summary>
    /// A business component to manage product items
    /// </summary>
    public class PreType
    {
        // Get an instance of the Item DAL using the DALFactory
        // Making this static will cache the DAL instance after the initial load
        private static readonly IPreType dal = psms.DALFactory.DataAccess.CreatePreTypeInfo();

        public System.ComponentModel.BindingList<PreTypeInfo> GetAllPreTypeInfo()
        {
            IList<PreTypeInfo> data = dal.GetAllPreTypeInfo();
            System.ComponentModel.BindingList<PreTypeInfo> bindList= new System.ComponentModel.BindingList<PreTypeInfo>();
            for (int i = 0; i < data.Count; i++)
            {
                bindList.Add(data[i]);
            }
            return bindList;
        }

        public void updatePreType(string typename, int typeid)
        {
            //// Validate input
            if (string.IsNullOrEmpty(typename))
                return;

            // Use the dal to search by productId
            dal.updatePreType(typename, typeid);
        }

        public void insertPreType(string typename)
        {
            //// Validate input
            if (typename == null)
                return;

            // Use the dal to search by productId
            dal.insertPreType(typename);
        }


        public void deletePerType(int typeid)
        {
            dal.deletePerType(typeid);
        }

        public int GetPreTypeByTypeName(string typename)
        {
            return dal.GetPreTypeByTypeName(typename);
        }
    }
}
