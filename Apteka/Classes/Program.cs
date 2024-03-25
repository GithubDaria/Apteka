using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apteka
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            DataLoader dataLoader = new DataLoader("Server=DESKTOP-CCPC27Q;Database=Apteka;Integrated Security=True;", "products.txt", "manufacturers.txt", "prescriptionType.txt", "typeOfMedication.txt", "sellers.txt", "receipts.txt", "receiptDetails.txt");
            // Load products from file
            var typeOfMedication = dataLoader.LoadTypesOfMedicationFromDatabase();
            var prescriptionType = dataLoader.LoadPrescriptionTypesFromDatabase();
            var manufacturers = dataLoader.LoadManufacturersFromDatabase();

            var products = dataLoader.LoadProductsFromDatabase(manufacturers, prescriptionType , typeOfMedication);

            var sellers = dataLoader.LoadSellersFromDatabase();

            var receiptsdetails = dataLoader.LoadReceiptDetailsFromDatabase(products);
            var receipts = dataLoader.LoadReceiptsFromDatabase(sellers, receiptsdetails);
            // Load manufacturers from file

            // Initialize and run the main form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(products, manufacturers, prescriptionType, typeOfMedication, sellers, receipts, receiptsdetails, dataLoader));
        }
    }
}
