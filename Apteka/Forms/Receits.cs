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
    public partial class ReceitsForm : KryptonForm
    {
        List<Receipt> _receipts;
        private Form1 _form1;

        private bool _explicitClose = true;
        public ReceitsForm(List<Receipt> receipts, Form1 form1)
        {
            _receipts =receipts;
            _form1 = form1;
            InitializeComponent();
            DisplayReceipts();
        }

        private void Receits_Load(object sender, EventArgs e)
        {

        }
        private void DisplayReceipts()
        {
            dataGridViewReceipts.AutoGenerateColumns = false;

            // Add columns to DataGridView for receipts
            dataGridViewReceipts.Columns.Add("ReceiptIDColumn", "Чек");
            dataGridViewReceipts.Columns.Add("SellerIDColumn", "Продавець");
            dataGridViewReceipts.Columns.Add("DateTimeColumn", "Час");
            dataGridViewReceipts.Columns.Add("TotalAmountColumn", "Сума");

            // Add columns to DataGridView for receipt details
            dataGridViewReceipts.Columns.Add("ProductColumn", "Продукт");
            dataGridViewReceipts.Columns.Add("QuantityColumn", "Кількість");
            dataGridViewReceipts.Columns.Add("PriceColumn", "Ціна");

            // Populate DataGridView with receipt information
            foreach (Receipt receipt in _receipts)
            {
                dataGridViewReceipts.Rows.Add(
                    $"{receipt.ReceiptID}",
                    $"{receipt.Seller.LastName}",
                    $"{receipt.DateTime}",
                    $"{receipt.TotalCost}");

                // Add rows for each receipt detail
                foreach (var productQuantity in receipt.ReceiptDetails.ProductQuantities)
                {
                    Products product = productQuantity.Key;
                    int quantity = productQuantity.Value;

                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dataGridViewReceipts);
                    row.Cells[4].Value = $"{product.Name}";
                    row.Cells[5].Value = $"{quantity}";
                    row.Cells[6].Value = $"{product.Price}₴";

                    dataGridViewReceipts.Rows.Add(row);
                }
            }
        }

        private void ProductsPage_Click_1(object sender, EventArgs e)
        {
            _form1.Show();
            _explicitClose = false;
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            _form1.OpenAddProductPage();
            _explicitClose = false;

            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            _explicitClose = false;

            _form1.OpenSellersPage();
            this.Close();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            _explicitClose = false;

            _form1.OpenReceiptCreationPage();
            this.Close();
        }

        private void ReceitsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_explicitClose)
            {
                Application.Exit();
            }
        }
    }
}
