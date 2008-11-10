using System;

namespace psms.Model
{
    //凭证礼品信息
	//3	id	int	4	0
	//0	IN_SCRPNO	char	20	0
	//0	P_NO	char	15	0
	//0	QNT	int	4	1
	//0	IN_PRICE	decimal	9	1
    public class InScrpInfo
    {
		private int id;
        private string in_scrpno;
		private string p_no;
        private string p_name;
        private string unit;
        private decimal unit_price;
        private decimal cost_price;
		private int qnt;
		private decimal in_price;

        private InTableInfo inTableInfo = new InTableInfo();
        private PreInfoData preInfoData = new PreInfoData();


        public InScrpInfo(int id,string in_scrpno,string p_no,int qnt,decimal in_price)
		{
			this.id = id;
            this.in_scrpno = in_scrpno;
			this.p_no = p_no;
			this.qnt = qnt;
			this.in_price = in_price;
        }
        public InScrpInfo(int id, string in_scrpno, string p_no, string p_name,string unit,decimal unit_price,
            decimal cost_price,int qnt, decimal in_price)
        {
            this.id = id;
            this.in_scrpno = in_scrpno;
            this.p_no = p_no;
            this.qnt = qnt;
            this.in_price = in_price;
            this.p_name = p_name;
            this.unit = unit;
            this.unit_price = unit_price;
            this.cost_price = cost_price;
        }

        //SELECT INTABLE.IN_SCRPNO, IN_OU, IN_DATE, IN_COST, IN_ACC, IN_MEMO, INSCRP.P_NO, QNT, IN_PRICE, PREINFO.P_NAME, PREINFO.ACC_QNT
        public InScrpInfo(string inScrpno,string inou,DateTime indate,decimal in_cost,int inacc,string inmemo,string pno,int qnt,decimal inprice,
            string pname,int accqnt)
        {
            this.inTableInfo.In_scrpno = inScrpno;
            this.inTableInfo.In_ou = inou;
            this.inTableInfo.In_cost = in_cost;
            this.inTableInfo.In_acc = inacc;
            this.inTableInfo.In_memo = inmemo;
            this.inTableInfo.In_date = indate;

            this.preInfoData.P_no = pno;
            this.preInfoData.P_name = pname;
            this.preInfoData.Acc_qnt = accqnt;

            this.qnt = qnt;
            this.in_price = inprice;


        }

        public PreInfoData PreInfoData
        {
            get
            {
                return this.preInfoData;
            }
            set
            {
                this.preInfoData = value;
            }
        }

        public InTableInfo InTableInfo
        {
            get
            {
                return this.inTableInfo;
            }
            set
            {
                this.inTableInfo = value;
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

        public decimal In_price
        {
            get
            {
                return this.in_price;
            }
            set
            {
                this.in_price = value;
            }
        }

       
    }
}
