

namespace psms.Model
{
    //入库凭证单位
	//    3	IN_SCRPNO	char	20	0
	//    0	billno	char	20	1
	//    0	IN_OU	char	20	1
	//    0	IN_DATE	datetime	8	1
	//    0	IN_COST	decimal	9	1
	//    0	planin	char	2	1
	//    0	goodsAcc	int	4	1
	//    0	IN_ACC	int	4	1
	//    0	IN_MEMO	varchar	50	1
    public class InTableInfo
    {
        private string in_scrpno;
		private string billno;
        private string in_ou;
		private System.DateTime in_date;
		private decimal in_cost;
		private string planin;
		private int goodsAcc;
		private int in_acc;
		private string in_memo;

        //private string strGoodacc;
        //private string strInacc;

        private System.ComponentModel.BindingList<InScrpInfo> inScrpList;

        public InTableInfo() { }


        ////in_scrpno,billno,in_ou,in_date,in_cost,planin,goodsAcc,in_acc,in_memo
        public InTableInfo(string in_scrpno, string billno, string in_ou,System.DateTime in_date ,decimal in_cost, string planin,
			int goodsAcc,int in_acc,string in_memo)
		{
            this.in_scrpno = in_scrpno;
			this.billno = billno;
            this.in_ou = in_ou;
			this.in_date = in_date;
			this.in_cost = in_cost;
			this.planin = planin;
            this.goodsAcc = goodsAcc;
			this.in_memo = in_memo;
			this.in_acc = in_acc;
        }

        public string StrGoodacc
        {
            get
            {
                if (this.goodsAcc == 0)
                {
                    return "未确认";
                }
                else
                {
                    return "已确认";
                }
                
            }
        }

        public string StrInacc
        {
            get
            {
                if (this.in_acc == 0)
                {
                    return "未做账";
                }
                else
                {
                    return "已做账";
                }

            }
        }

        public System.ComponentModel.BindingList<InScrpInfo> InScrpList
        {
            get
            {
                return this.inScrpList;
            }
            set
            {
                this.inScrpList = value;
            }
        }


		public string In_scrpno
        {
            get
            {
                return this.in_scrpno;
            }
            set
            {
                this.in_scrpno = value;
            }
        }
		public string Billno
        {
            get
            {
                return this.billno;
            }
            set
            {
                this.billno = value;
            }
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

		public System.DateTime In_date
        {
            get
            {
                return this.in_date;
            }
            set
            {
                this.in_date = value;
            }
        }

		public decimal In_cost
        {
            get
            {
                return this.in_cost;
            }
            set
            {
                this.in_cost = value;
            }
        }

		public string Planin
        {
            get
            {
                return this.planin;
            }
            set
            {
                this.planin = value;
            }
        }

		public int GoodAcc
        {
            get
            {
                return this.goodsAcc;
            }
            set
            {
                this.goodsAcc = value;
            }
        }
		public string In_memo
        {
            get
            {
                return this.in_memo;
            }
            set
            {
                this.in_memo = value;
            }
        }
        public int In_acc
        {
            get
            {
                return this.in_acc;
            }
            set
            {
                this.in_acc = value;
            }
        }

       
    }
}
