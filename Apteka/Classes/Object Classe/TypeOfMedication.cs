using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apteka
{
    public class TypeOfMedication
    {
        public TypeOfMedication(int typeID, string name)
        {
            TypeOfMedicationID = typeID;
            Name = name;
        }

        public int TypeOfMedicationID { get; set; }
        public string Name { get; set; }
    }
}
