using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apteka
{
    public class Products 
    {

        public Products(int productId, string name, TypeOfMedication typeOfMedication, Manufacturer manufacturer, decimal price, int stock, PrescriptionType prescriptionType)
        {
            ProductID = productId; // Assign the provided ID to the current product
            Name = name;
            TypeOfmedication = typeOfMedication;
            Manufacturer = manufacturer;
            Price = price;
            Stock = stock;
            PrescriptionType = prescriptionType;
        }

        public int ProductID { get; set; }
        public string Name { get; set; }
        public TypeOfMedication TypeOfmedication { get; set; }
        public Manufacturer Manufacturer { get; set; } // Use Manufacturer object type instead of int
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public PrescriptionType PrescriptionType { get; set; }
    }
}
