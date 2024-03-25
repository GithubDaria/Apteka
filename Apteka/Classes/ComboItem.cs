using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apteka
{
    public class ComboItem
    {
        public string Name { get; set; }
        public object Item { get; set; } // Represents the associated object

        public ComboItem(string name, object item)
        {
            Name = name;
            Item = item;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
