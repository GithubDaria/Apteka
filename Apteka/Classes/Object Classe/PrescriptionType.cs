using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apteka
{
    public class PrescriptionType
    {
        public int PrescriptionTypeID { get; set; }
        public string TypeName { get; set; }

        public PrescriptionType(int typeId, string typeName)
        {
            PrescriptionTypeID = typeId;
            TypeName = typeName;
        }
    }
}
