
using System.Collections.Generic;
using psms.Model;
using psms.IDAL;

namespace psms.BLL
{
    /// <summary>
    /// A business component to manage product items
    /// </summary>
    public class PreAcc
    {
        // Get an instance of the Item DAL using the DALFactory
        // Making this static will cache the DAL instance after the initial load
        private static readonly IPreAcc dal = psms.DALFactory.DataAccess.CreatePreAcc();


        //得到所有做帐记录
        public IList<PreAccInfo> GetAllPreAcc()
        {
            return dal.GetAllPreAcc();
        }

        //做账 入库凭证
        public bool insertPreAccForInTable(IList<PreAccInfo> list)
        {
            return dal.insertPreAccForInTable(list);
        }


        //做账 出库凭证
        public bool insertPreAccForOutTable(IList<PreAccInfo> list)
        {
            return dal.insertPreAccForOutTable(list);
        }



    }
}
