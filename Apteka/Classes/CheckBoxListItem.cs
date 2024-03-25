using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apteka
{
    class CheckBoxListItem
    {
        public string Text { get; set; }
        public object Tag { get; set; }

        public CheckBoxListItem(string text)
        {
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
