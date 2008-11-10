using System;
namespace psms.Model
{
    /// <summary>
    /// Business entity used to model an PreTypeInfo.
    /// </summary>
    [Serializable]
    public class PreTypeInfo
    {

        // Internal member variables
        private int code;
        private string typeName;

        public PreTypeInfo() { }

        /// <summary>
        /// Constructor with specified initial values
        /// </summary>
        /// <param name="actionId">id</param>
        /// <param name="actionName">typeName</param>
        public PreTypeInfo(int id, string typeName)
        {
            this.code = id;
            this.typeName = typeName;
        }

        // Properties
        public int Code
        {
            get { return code; }
        }

        public string TypeName
        {
            get { return typeName; }
        }

        
    }
}
