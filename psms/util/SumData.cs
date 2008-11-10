using System;
using System.Collections.Generic;
using System.Text;

namespace psms.util
{
    class SumData
    {
        private string qnt = "";
        private string price = "";

        public SumData(string qnt,string price)
        {
            this.qnt = qnt;
            this.price = price;
        }

        public SumData()
        {
        }

        public string Qnt
        {
            get { return this.qnt; }
        }

        public string Price
        {
            get { return this.price; }
        }


        public static SumData getSumData(IList<IList<string>> list)
        {
            SumData obj = new SumData();
            if (list != null && list.Count > 0)
            {
                IList<string> data = list[0];
                obj = new SumData(data[0], data[1]);
            }
            return obj;
        }
    }
}
