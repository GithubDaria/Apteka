using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apteka
{
    public class Receipt
    {
        public int ReceiptID { get; set; }
        public Seller Seller { get; set; } // Seller object instead of int
        public DateTime DateTime { get; set; }
        public decimal TotalCost { get; set; }
        public ReceiptsDetail ReceiptDetails;

        public Receipt(int receiptId, Seller seller, DateTime dateTime, decimal totalAmount, ReceiptsDetail receiptsDetail)
        {
            ReceiptID = receiptId;
            Seller = seller;
            DateTime = dateTime;
            TotalCost = totalAmount;
            ReceiptDetails = receiptsDetail;
        }
    }
}
