

namespace psms.Model
{
    //收货单位
    public class OutInfoData
    {
        private string out_ou;

        public OutInfoData(string out_ou)
			{
            this.out_ou = out_ou;
        }

        public string Out_ou
        {
            get
            {
                return this.out_ou;
            }
            set
            {
                this.out_ou = value;
            }
        }

       
    }
}
