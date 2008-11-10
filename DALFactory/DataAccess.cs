using System.Reflection;
using System.Configuration;

namespace psms.DALFactory {

    /// <summary>
    /// This class is implemented following the Abstract Factory pattern to create the DAL implementation
    /// specified from the configuration file
    /// </summary>
    public sealed class DataAccess {

        // Look up the DAL implementation we should be using
        private static readonly string path = ConfigurationManager.AppSettings["AppDAL"];
        
        private DataAccess() { }


        public static psms.IDAL.IAction CreateItem() {
            string className = path + ".Action";
            return (psms.IDAL.IAction)Assembly.Load(path).CreateInstance(className);
        }

        public static psms.IDAL.IPreInfo CreatePreInfo()
        {
            string className = path + ".PreInfo";
            return (psms.IDAL.IPreInfo)Assembly.Load(path).CreateInstance(className);
        }

        public static psms.IDAL.IPreType CreatePreTypeInfo()
        {
            string className = path + ".PreType";
            return (psms.IDAL.IPreType)Assembly.Load(path).CreateInstance(className);
        }

        public static psms.IDAL.IInInfo CreateInInfo()
        {
            string className = path + ".InInfo";
            return (psms.IDAL.IInInfo)Assembly.Load(path).CreateInstance(className);
        }

		 public static psms.IDAL.IOutInfo CreateOutInfo()
        {
            string className = path + ".OutInfo";
            return (psms.IDAL.IOutInfo)Assembly.Load(path).CreateInstance(className);
        }
       
		public static psms.IDAL.IVipInfo CreateVipInfo()
        {
            string className = path + ".VipInfo";
            return (psms.IDAL.IVipInfo)Assembly.Load(path).CreateInstance(className);
        }

		public static psms.IDAL.IUserInfo CreateUserInfo()
        {
            string className = path + ".UserInfo";
            return (psms.IDAL.IUserInfo)Assembly.Load(path).CreateInstance(className);
        }

        public static psms.IDAL.IInTable CreateInTable()
        {
            string className = path + ".InTable";
            return (psms.IDAL.IInTable)Assembly.Load(path).CreateInstance(className);
        }

        public static psms.IDAL.IInScrp CreateInScrp()
        {
            string className = path + ".InScrp";
            return (psms.IDAL.IInScrp)Assembly.Load(path).CreateInstance(className);
        }

		public static psms.IDAL.IOutTable CreateOutTable()
        {
            string className = path + ".OutTable";
            return (psms.IDAL.IOutTable)Assembly.Load(path).CreateInstance(className);
        }

        public static psms.IDAL.IOutScrp CreateOutScrp()
        {
            string className = path + ".OutScrp";
            return (psms.IDAL.IOutScrp)Assembly.Load(path).CreateInstance(className);
        }

        public static psms.IDAL.ICheckTable CreateCheckTable()
        {
            string className = path + ".CheckTable";
            return (psms.IDAL.ICheckTable)Assembly.Load(path).CreateInstance(className);
        }

        public static psms.IDAL.IPreAcc CreatePreAcc()
        {
            string className = path + ".PreAcc";
            return (psms.IDAL.IPreAcc)Assembly.Load(path).CreateInstance(className);
        }



    }
}
