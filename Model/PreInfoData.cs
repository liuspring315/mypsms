

namespace psms.Model
{
    //礼品信息类
    public class PreInfoData
    {
        private int id;
        private string p_no;
        private string pretype;
        private string p_name;
        private string unit;
        private decimal unit_price;
        private decimal cost_price;
        private int acc_qnt;

        public PreInfoData() { }

        public PreInfoData(int id,string p_no,string pretype,string p_name,string unit,decimal unit_price,decimal cost_price,int acc_qnt)
        {
            this.id = id;
            this.p_no = p_no;
            this.pretype = pretype;
            this.p_name = p_name;
            this.unit = unit;
            this.unit_price = unit_price;
            this.cost_price = cost_price;
            this.acc_qnt = acc_qnt;
        }

        //盘存初始化
        public PreInfoData(string p_no, string p_name, int acc_qnt)
        {
            this.p_no = p_no;
            this.p_name = p_name;
            this.acc_qnt = acc_qnt;
        }

        public string P_no
        {
            get
            {
                return this.p_no;
            }
            set
            {
                this.p_no = value;
            }
        }

        public string Pretype
        {
            get
            {
                return this.pretype;
            }
            set
            {
                this.pretype = value;
            }
        }

        public string P_name
        {
            get
            {
                return this.p_name;
            }
            set
            {
                this.p_name = value;
            }
        }

        public string Unit
        {
            get
            {
                return this.unit;
            }
            set
            {
                this.unit = value;
            }
        }

        public decimal Unit_price
        {
            get
            {
                return this.unit_price;
            }
            set
            {
                this.unit_price = value;
            }
        }

        public decimal Cost_price
        {
            get
            {
                return this.cost_price;
            }
            set
            {
                this.cost_price = value;
            }
        }

        public int Acc_qnt
        {
            get
            {
                return this.acc_qnt;
            }
            set
            {
                this.acc_qnt = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

    }
}
