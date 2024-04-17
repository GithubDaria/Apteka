using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;


namespace Apteka
{
    public partial class Product : KryptonForm
    {
        private Products _product;
        private Form1 _form1;
        private string Description;
        private DataLoader dataLoader;
        Image defaultiamge = Image.FromFile(@"C:\Users\prooo\source\repos\Apteka\Apteka\Debug\ProductsImages\DefaultPicture.jpg");

        public Product(Products product, Form1 form1, DataLoader _dataLoader)
        {
            _product = product;
            _form1 = form1;
            dataLoader = _dataLoader;
            InitializeComponent();
            ProductPictureBox.Image = LoadImage(product.ProductID);

        }

        private void Product_Load(object sender, EventArgs e)
        {
            NameLabel.Text = _product.Name;
            CodeLabel.Text = "Код товару " + _product.ProductID.ToString();
            PriceLabel.Text = _product.Price.ToString() + "₴";
            TypeLabel.Text = _product.TypeOfmedication.Name;
            ManufactureLabel.Text = _product.Manufacturer.Name;
            PrescriptionLabel.Text = _product.PrescriptionType.TypeName;
            CountLabel.Text = _product.Stock.ToString();
            DescriptionLabel.Text = dataLoader.LoadDescription(_product.ProductID);
        }

        private void Product_FormClosed(object sender, FormClosedEventArgs e)
        {
            _form1.Show();
            this.Hide();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            _form1.EditProductPage(_product);
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            _form1.OpenAddProductPage();
        }
        public Image LoadImage(int id)
        {
            string imagePath = $@"C:\Users\prooo\source\repos\Apteka\Apteka\Debug\ProductsImages\{id}.png";
            if (File.Exists(imagePath))
            {
                return Image.FromFile(imagePath);
                //pictureBox.Image = Image.FromFile(imagePath);
            }
            else
            {
                return defaultiamge;
            }
        }
    }
}
