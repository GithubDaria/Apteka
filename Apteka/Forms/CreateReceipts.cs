using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace Apteka
{
    public partial class CreateReceipts : KryptonForm
    {
        private Dictionary<Products, int> _ProductQuantities;
        private List<Seller> sellers;
        private Form1 form1;
        private DataLoader dataLoader;

        private bool _explicitClose = true;
        public CreateReceipts(Dictionary<Products, int> ProductQuantities, List<Seller> _sellers, Form1 _form1, DataLoader _dataLoader)
        {
            _ProductQuantities = ProductQuantities;
            sellers = _sellers;
            form1 = _form1;
            dataLoader = _dataLoader;
            InitializeComponent();
        }

        private void CreateReceipts_Load(object sender, EventArgs e)
        {
            foreach (var productQuantity in _ProductQuantities)
            {
                Console.WriteLine($"  ProductID: {productQuantity.Key.ProductID}");
                Console.WriteLine($"  Quantity: {productQuantity.Value}");
                RecieptsLabel label = new RecieptsLabel();

                // Set the properties of the RecieptsLabel control
                label.productName = productQuantity.Key.Name;
                label.ProductCode = productQuantity.Key.ProductID.ToString();
                label.ProdcutCount = productQuantity.Value;
                label.ProductCost = productQuantity.Key.Price * productQuantity.Value;

                // Wire up the event handlers for increment and decrement
                label.IncrementCountClicked += (s, ev) => IncrementCount(productQuantity.Key, label);
                label.DecrementCountClicked += (s, ev) => DecrementCount(productQuantity.Key, label);

                // Add the RecieptsLabel control to the flowLayoutPanel
                flowLayoutPanenl.Controls.Add(label);
            }
            FullPriceLabel.Text = GetTotalCost().ToString();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            // Check if the ProductQuantities dictionary is empty
            if (_ProductQuantities.Count == 0)
            {
                MessageBox.Show("Кількість товарів порожня. Будь ласка, додайте товари до чеку.");
                return;
            }

            // Get the code entered by the user in the text box
            string sellerCode = SellerCodeTextBox.Text;

            // Check if the code exists in the list of sellers (assuming SellersList is the list of sellers)
            if (!int.TryParse(sellerCode, out int sellerId))
            {
                MessageBox.Show("Невірний код продавця. Будь ласка, введіть дійсний цілочисельний код.");

                return;
            }

            // Check if the code exists in the list of sellers (assuming SellersList is the list of sellers)
            bool sellerExists = sellers.Any(seller => seller.SellerID == sellerId);

            if (!sellerExists)
            {
                MessageBox.Show("Код продавця не знайдено. Будь ласка, введіть дійсний код продавця.");
                return;
            }
   

            int uniqueReceiptId = dataLoader.InsertReceipt(sellerId, DateTime.Now, GetTotalCost());

            ReceiptsDetail receiptsDetail = new ReceiptsDetail
            {
                ProductQuantities = _ProductQuantities
            };
            foreach (var productQuantity in _ProductQuantities)
            {
                dataLoader.InsertReceiptDetail(uniqueReceiptId, productQuantity.Key.ProductID, productQuantity.Value);
            }
            receiptsDetail.ReceiptID = uniqueReceiptId;

            // Create a new Receipt instance
            Receipt receipt = new Receipt(
                uniqueReceiptId,
                sellers.FirstOrDefault(seller => seller.SellerID == sellerId),
                DateTime.Now,
                GetTotalCost(), // Pass the product quantities to calculate total cost
                receiptsDetail
            );
            form1.UpdateBoughtProducts(receipt);
            form1.UpdateReceipts(receipt);
            form1.UpdateReceiptDetails(receiptsDetail);
            OpenMainForm1();
        }
        private decimal GetTotalCost()
        {
            decimal totalCost = 0;

            foreach (var kvp in _ProductQuantities)
            {
                Products product = kvp.Key;
                int quantity = kvp.Value;

                // Calculate the cost for this product (price * quantity) and add it to the total cost
                totalCost += product.Price * quantity;
            }

            return totalCost;
        }
        private void DecrementCount(Products label, RecieptsLabel recieptsLabel)
        {
            foreach (var productQuantity in _ProductQuantities.ToList()) // Iterate over a copy of the dictionary to avoid modification during iteration
            {
                if (productQuantity.Key.ProductID == label.ProductID)
                {
                    int newValue = productQuantity.Value - 1;
                    _ProductQuantities[productQuantity.Key] = newValue; // Update the value in the dictionary
                    recieptsLabel.ProdcutCount = newValue;
                    recieptsLabel.ProductCost = newValue * productQuantity.Key.Price;
                    FullPriceLabel.Text = GetTotalCost().ToString();

                    if (newValue <= 0)
                    {
                        _ProductQuantities.Remove(productQuantity.Key); // Remove the key from the dictionary if the new value is less than or equal to 0
                        flowLayoutPanenl.Controls.Remove(recieptsLabel);
                    }
                    break; // Exit the loop after updating the value
                }
            }
        }

        private void IncrementCount(Products label, RecieptsLabel recieptsLabel)
        {
            foreach (var productQuantity in _ProductQuantities.ToList()) // Iterate over a copy of the dictionary to avoid modification during iteration
            {
                if (productQuantity.Key.ProductID == label.ProductID)
                {
                    if(label.Stock - _ProductQuantities[productQuantity.Key] != 0)
                    {
                        int newValue = productQuantity.Value + 1;
                        _ProductQuantities[productQuantity.Key] = newValue; // Update the value in the dictionary
                        recieptsLabel.ProdcutCount = newValue;
                        recieptsLabel.ProductCost = newValue * productQuantity.Key.Price;
                        FullPriceLabel.Text = GetTotalCost().ToString();
                    }
                    break; // Exit the loop after updating the value
                }
            }
        }

        private void AddProductPage_Click(object sender, EventArgs e)
        {
            form1.OpenAddProductPage();
            _explicitClose = false;

            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

            OpenMainForm1();
        }
        private void OpenMainForm1()
        {
            _explicitClose = false;
            form1.LoadAllTheData();
            form1.Show();
            this.Close();
        }

        private void SellersPage_Click(object sender, EventArgs e)
        {
            _explicitClose = false;

            form1.OpenSellersPage();
            this.Close();

        }

        private void RecieptsPageButton_Click(object sender, EventArgs e)
        {
            _explicitClose = false;

            form1.OpenReceiptsPage();
            this.Close();

        }

        private void CreateReceipts_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_explicitClose)
            {
                Application.Exit();
            }
        }

        private void SellerCodeTextBox_Click(object sender, EventArgs e)
        {
            

        }

        private void SellerCodeTextBox_MouseDown(object sender, MouseEventArgs e)
        {

            // Assuming textBox1 is your Krypton TextBox control
            SellerCodeTextBox.StateCommon.Border.Width = 2; // Set the border width to 2 pixels
            SellerCodeTextBox.StateCommon.Border.Color1 = Color.LightBlue;
            SellerCodeTextBox.StateCommon.Border.Color2 = Color.LightBlue;
        }

        private void SellerCodeTextBox_Enter(object sender, EventArgs e)
        {

        }
    }
}
