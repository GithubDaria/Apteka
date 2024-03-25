using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apteka
{
    public class ReceiptsDetail
    {
        public int ReceiptID { get; set; }
        public Dictionary<Products, int> ProductQuantities { get; set; }
        // Other receipt detail properties

        public ReceiptsDetail()
        {
            ProductQuantities = new Dictionary<Products, int>();
        }
    }
}
