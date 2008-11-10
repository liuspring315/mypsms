using System;

namespace psms.Model
{
    //凭证礼品信息
	//3	id	int	4	0
	//0	out_SCRPNO	char	20	0
	//0	P_NO	char	15	0
	//0	QNT	int	4	1
	//0	out_PRICE	decimal	9	1
    public class OutScrpInfo
    {
		private int id;
        private string out_scrpno;
		private string p_no;
        private string p_name;
        private string unit;
        private decimal unit_price;
        private decimal cost_price;
		private int qnt;
		private decimal out_price;

        private OutTableInfo outTableInfo = new OutTableInfo();
        private PreInfoData preInfoData = new PreInfoData();

        public OutScrpInfo() { }

        public OutScrpInfo(int id,string out_scrpno,string p_no,int qnt,decimal out_price)
		{
			this.id = id;
            this.out_scrpno = out_scrpno;
			this.p_no = p_no;
			this.qnt = qnt;
			this.out_price = out_price;
        }
        public OutScrpInfo(int id, string out_scrpno, string p_no, string p_name,string unit,decimal unit_price,
            decimal cost_price,int qnt, decimal out_price)
        {
            this.id = id;
            this.out_scrpno = out_scrpno;
            this.p_no = p_no;
            this.qnt = qnt;
            this.out_price = out_price;
            this.p_name = p_name;
            this.unit = unit;
            this.unit_price = unit_price;
            this.cost_price = cost_price;
        }

        //SELECT OUTTABLE.OUT_SCRPNO, OUT_OU, VIP_OU, OUT_DATE, OUT_COST, OUT_ACC, OUT_MEMO, OUTSCRP.P_NO, QNT, OUT_PRICE, PREINFO.P_NAME, PREINFO.ACC_QNT
        public OutScrpInfo(string outScrpno,string out_ou,string vip_ou,DateTime out_date,decimal out_cost,int out_acc,
            string out_memo,string pno,int qnt,
            decimal out_price,string pname,int accqnt)
        {
            this.outTableInfo.Out_scrpno = outScrpno;
            this.outTableInfo.Out_ou = out_ou;
            this.outTableInfo.Vip_ou = vip_ou;
            this.outTableInfo.Out_date = out_date;
            this.outTableInfo.Out_cost = out_cost;
            this.outTableInfo.Out_acc = out_acc;
            this.outTableInfo.Out_memo = out_memo;


            this.preInfoData.P_no = pno;
            this.preInfoData.P_name = pname;

            this.qnt = qnt;
            this.out_price = out_price;


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

       
        public int Qnt
        {
            get
            {
                return this.qnt;
            }
            set
            {
                this.qnt = value;
            }
        }

        public decimal Out_price
        {
            get
            {
                return this.out_price;
            }
            set
            {
                this.out_price = value;
            }
        }

       
    }
}
