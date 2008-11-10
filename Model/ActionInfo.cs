using System;
namespace psms.Model
{
    /// <summary>
    /// Business entity used to model an Action.
    /// </summary>
    [Serializable]
    public class ActionInfo
    {

        // Internal member variables
        private int actionId;
        private string actionName;
        private int actionOrder;

        public ActionInfo() { }

        /// <summary>
        /// Constructor with specified initial values
        /// </summary>
        /// <param name="actionId">actionId</param>
        /// <param name="actionName">actionName</param>
        /// <param name="actionOrder">actionOrder</param>
        public ActionInfo(int id, string actionName, int actionOrder)
        {
            this.actionId = id;
            this.actionName = actionName;
            this.actionOrder = actionOrder;
        }

        // Properties
        public int ActionId
        {
            get { return actionId; }
        }

        public string ActionName
        {
            get { return actionName; }
        }

        public int ActionOrder
        {
            get { return actionOrder; }
        }

        
    }
}
