using System;
using System.Collections.Generic;
using System.Text;

namespace psms.util
{
    class ValueObject
    {
        private string value;
        private string text;

        public ValueObject(string v, string t)
        {
            this.value = v;
            this.text = t;
        }

        public string Value
        {
            get { return this.value;}
        }
        public string Text
        {
            get { return this.text; }
        }

    }
}
