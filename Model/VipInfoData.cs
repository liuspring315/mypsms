

namespace psms.Model
{
    //���쵥λ
    public class VipInfoData
    {
        private string vip_ou;

        public VipInfoData(string vip_ou)
			{
            this.vip_ou = vip_ou;
        }

        public string Vip_ou
        {
            get
            {
                return this.vip_ou;
            }
            set
            {
                this.vip_ou = value;
            }
        }

       
    }
}
