using System;

namespace psms.Model
{
    //出库凭证单位
    //3	OUT_SCRPNO	char	20	0
    //0	OUT_OU	char	20	1
    //0	OUT_DATE	datetime	8	1
    //0	OUT_COST	decimal	9	1
    //0	VIP_OU	char	20	1
    //0	OUT_ACC	int	4	1
    //0	OUT_MEMO	char	40	1
    public class OutTableInfo
    {
        private string out_scrpno;
		private string out_ou;
        private DateTime out_date;
		private decimal out_cost;
		private string vip_ou;
		private int out_acc;
		private string out_memo;

        System.ComponentModel.BindingList<OutScrpInfo> outScrpList = new System.ComponentModel.BindingList<OutScrpInfo>();


        public OutTableInfo() { }


        public OutTableInfo(string out_scrpno, string out_ou, DateTime out_date, decimal out_cost, string vip_ou,
			int out_acc,string out_memo)
		{
            this.out_scrpno = out_scrpno;
            this.out_ou = out_ou;
			this.out_date = out_date;
			this.out_cost = out_cost;
            this.vip_ou = vip_ou;
			this.out_memo = out_memo;
			this.out_acc = out_acc;
        }


        public System.ComponentModel.BindingList<OutScrpInfo> OutScrpList
        {
            get
            {
                return this.outScrpList;
            }
            set
            {
                this.outScrpList = value;
            }
        }

        public string StrOutacc
        {
            get
            {
                if (this.out_acc == 0)
                {
                    return "未做账";
                }
                else
                {
                    return "已做账";
                }
            }
        }

		public string Out_scrpno
        {
            get
            {
                return this.out_scrpno;
            }
            set
            {
                this.out_scrpno = value;
            }
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

        public DateTime Out_date
        {
            get
            {
                return this.out_date;
            }
            set
            {
                this.out_date = value;
            }
        }

		public decimal Out_cost
        {
            get
            {
                return this.out_cost;
            }
            set
            {
                this.out_cost = value;
            }
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

		public string Out_memo
        {
            get
            {
                return this.out_memo;
            }
            set
            {
                this.out_memo = value;
            }
        }
        public int Out_acc
        {
            get
            {
                return this.out_acc;
            }
            set
            {
                this.out_acc = value;
            }
        }

       
    }
}
