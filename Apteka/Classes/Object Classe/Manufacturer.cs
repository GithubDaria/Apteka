using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apteka
{
    public class Manufacturer
    {
        public int ManufacturerID { get; set; }
        public string Name { get; set; }

        // Add other properties as needed

        public Manufacturer(int manufacturerID, string name)
        {
            ManufacturerID = manufacturerID;
            Name = name;
        }
    }
}
