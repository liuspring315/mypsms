

namespace psms.Model
{
    //��ⵥλ
    public class InInfoData
    {
        private string in_ou;

        public InInfoData(string in_ou)
			{
            this.in_ou = in_ou;
        }

        public string In_ou
        {
            get
            {
                return this.in_ou;
            }
            set
            {
                this.in_ou = value;
            }
        }

       
    }
}
