using System;

namespace psms.Model
{
    //×öÕË
    //3	preaccno	int	4	0
    //0	IN_OUT	char	1	0
    //0	SCRP_NO	char	10	0
    //0	P_NO	char	15	0
    //0	QNT	int	4	1
    //0	COST	decimal	9	1
    //0	S_QNT	int	4	1
    //0	S_COST	decimal	9	1
    public class PreAccInfo
    {
        private int preaccno;
        private string in_out;
        private string scrp_no;
        private string p_no;
        private int qnt;
        private decimal cost;
        private int s_qnt;
        private decimal s_cost;

        public PreAccInfo()
		{
        }

        //SELECT IN_OUT, SCRP_NO, P_NO, QNT, COST, S_QNT, S_COST FROM PREACC
        public PreAccInfo(string inout,string scrpno,string pno,int qnt,decimal cost,int sqnt,decimal scost)
        {
            this.in_out = inout;
            this.scrp_no = scrpno;
            this.p_no = pno;
            this.qnt = qnt;
            this.cost = cost;
            this.s_qnt = sqnt;
            this.s_cost = scost;

        }

        public int Preaccno
        {
            get
            {
                return this.preaccno;
            }
            set
            {
                this.preaccno = value;
            }
        }

        public string In_out
        {
            get
            {
                return this.in_out;
            }
            set
            {
                this.in_out = value;
            }
        }

        public string Scrp_no
        {
            get
            {
                return this.scrp_no;
            }
            set
            {
                this.scrp_no = value;
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

        public decimal Cost
        {
            get
            {
                return this.cost;
            }
            set
            {
                this.cost = value;
            }
        }

        public int S_qnt
        {
            get
            {
                return this.s_qnt;
            }
            set
            {
                this.s_qnt = value;
            }
        }

        public decimal S_cost
        {
            get
            {
                return this.s_cost;
            }
            set
            {
                this.s_cost = value;
            }
        }

       
    }
}
