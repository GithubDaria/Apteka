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
    public partial class SellersForm : KryptonForm
    {
        public Form1 _form1;
        private List<Seller> _sellers;
        public SellersForm(List<Seller> sellers, Form1 form1)
        {
            _sellers = sellers;
            _form1 = form1;
            InitializeComponent();
       
        }

        private void SellersForm_Load(object sender, EventArgs e)
        {
            LoadSellers();
        }
        private void LoadSellers()
        {
            dataGridViewSellers.DataSource = _sellers;

            dataGridViewSellers.Columns["SellerID"].HeaderText = "Працівники";
            dataGridViewSellers.Columns["FirstName"].HeaderText = "Ім'я";
            dataGridViewSellers.Columns["LastName"].HeaderText = "Прізвище";
            dataGridViewSellers.Columns["Position"].HeaderText = "Посада";

            dataGridViewSellers.DefaultCellStyle.Font = new Font("Verdana", 20);
            dataGridViewSellers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
          
        }

        private void ProductsPage_Click(object sender, EventArgs e)
        {
            _form1.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            _form1.OpenAddProductPage();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            _form1.OpenReceiptsPage();
        }

        private void label5_Click(object sender, EventArgs e)
        {
                this.Hide();
                _form1.OpenReceiptCreationPage();
        }

        private void SellersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
