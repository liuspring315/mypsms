using System;
using System.Data;
using System.Data.SqlClient;
using psms.Model;
using psms.IDAL;
using System.Collections.Generic;
using psms.DBUtility;

namespace psms.SQLServerDAL
{
    public class Action : IAction
    {
        // Static constants
        private const string SQL_SELECT_ITEMS_BY_PRODUCT = "SELECT actionid,actionname,actionorder from [Action] where actionname = @Actionname";

        private const string PARM_PRODUCT_ID = "@Actionname";
        /// <summary>
        /// Function to get a list of items within a product group
        /// </summary>
        /// <param name="productId">Product Id</param>	   	 
        /// <returns>A Generic List of ItemInfo</returns>
        public IList<ActionInfo> GetItemsByProduct(string productId)
        {

            IList<ActionInfo> itemsByProduct = new List<ActionInfo>();

            SqlParameter parm = new SqlParameter(PARM_PRODUCT_ID, SqlDbType.VarChar, 50);
            parm.Value = productId;

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_ITEMS_BY_PRODUCT, parm))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    ActionInfo item = new ActionInfo(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2));
                    //Add each item to the arraylist
                    itemsByProduct.Add(item);
                }
            }
            return itemsByProduct;
        }

        /// <summary>
        /// Get the SqlCommand used to retrieve a list of items by product
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>Sql Command object used to retrieve the data</returns>
        public static SqlCommand GetCommand(string id)
        {

            //Create a parameter
            SqlParameter parm = new SqlParameter(PARM_PRODUCT_ID, SqlDbType.VarChar, 50);
            parm.Value = id;

            // Create and return SqlCommand object
            SqlCommand command = new SqlCommand(SQL_SELECT_ITEMS_BY_PRODUCT);
            command.Parameters.Add(parm);
            return command;
        }

    }
}
