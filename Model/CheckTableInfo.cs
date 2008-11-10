using System;
namespace psms.Model
{
    //≈Ã¥Ê
    //3	id	int	4	0
    //0	CHCK_NO	int	4	0
    //0	CHCK_DATE	datetime	8	0
    //0	P_NO	char	15	0
    //0	ACC_QNT	int	4	1
    //0	FACT_QNT	int	4	1
    //0	DIFF_QNT	int	4	1
    //0	CHCK_MEMO	varchar	50	1
    public class CheckTableInfo
    {
        private int id;
        private int chck_no;
        private DateTime chck_date;
        private string p_no;
        private string p_name;
        private int acc_qnt;
        private int fact_qnt;
        private int diff_qnt;
        private string chck_memo;

        public CheckTableInfo()
		{
        }

        public CheckTableInfo(int chck_no,DateTime chck_date,string p_no,string p_name,int acc_qnt,int fact_qnt,int diff_qnt,string chck_memo)
        {
            this.chck_no = chck_no;
            this.chck_date = chck_date;
            this.p_no = p_no;
            this.acc_qnt = acc_qnt;
            this.fact_qnt = fact_qnt;
            this.diff_qnt = diff_qnt;
            this.chck_memo = chck_memo;
            this.p_name = p_name;
        }

        //SELECT CHECKTABLE.CHCK_NO, CHECKTABLE.CHCK_DATE, CHECKTABLE.P_NO, PREINFO.P_NAME, CHECKTABLE.ACC_QNT, CHECKTABLE.FACT_QNT, CHECKTABLE.DIFF_QNT, CHECKTABLE.CHCK_MEMO
        //≈Ã¥Ê≤È—Ø
        public CheckTableInfo(int id,int chckno,DateTime chckdate,string p_no,string p_name,int accqnt,int factqnt,int diffqnt,string chckmemo)
        {
            this.chck_no = chckno;
            this.chck_date = chckdate;
            this.p_no = p_no;
            this.p_name = p_name;
            this.acc_qnt = accqnt;
            this.fact_qnt = factqnt;
            this.diff_qnt = diffqnt;
            this.chck_memo = chckmemo;
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

        public int Chck_no
        {
            get
            {
                return this.chck_no;
            }
            set
            {
                this.chck_no = value;
            }
        }

        public DateTime Chck_date
        {
            get
            {
                return this.chck_date;
            }
            set
            {
                this.chck_date = value;
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

        public int Fact_qnt
        {
            get
            {
                return this.fact_qnt;
            }
            set
            {
                this.fact_qnt = value;
            }
        }

        public int Diff_qnt
        {
            get
            {
                return this.diff_qnt;
            }
            set
            {
                this.diff_qnt = value;
            }
        }

        public string Chck_memo
        {
            get
            {
                return this.chck_memo;
            }
            set
            {
                this.chck_memo = value;
            }
        }










       
    }
}
