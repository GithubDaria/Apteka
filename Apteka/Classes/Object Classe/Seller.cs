using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apteka
{
    public class Seller
    {
        // Properties
        public int SellerID { get; set; } // Primary Key
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }

        // Constructor
        public Seller(int sellerID, string firstName, string lastName, string position)
        {
            SellerID = sellerID;
            FirstName = firstName;
            LastName = lastName;
            Position = position;
        }
    }
}
