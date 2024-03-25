using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apteka
{
    public partial class ProductsLayoutInList : UserControl
    {
        public event EventHandler<ProductEventArgs> HandleProductEvent;
        public event EventHandler<ProductEventArgs> AddToReceiptClicked;

        public event EventHandler<ProductEventArgs> IncrementCountClicked;
        public event EventHandler<ProductEventArgs> DecrementCountClicked;

        private int Count = 0;
        public ProductsLayoutInList()
        {
            InitializeComponent();
        }
        private void ProductDataHolder_Click(object sender, EventArgs e)
        {
            ProductsLayoutInList customControl = this;
            if (customControl != null && customControl.Tag != null)
            {
                Products product = customControl.Tag as Products;
                if (product != null)
                {
                    HandleProductEvent?.Invoke(this, new ProductEventArgs(product));
                }
            }
        }

        private void AddToRecieptButton_Click(object sender, EventArgs e)
        {
            // Get the product associated with the button
            Control control = (Control)sender;
            ProductsLayoutInList customControl = this;
            Products product = this.Tag as Products;

            // Check if the product is valid
            if (product != null)
            {
                // Trigger the event to notify Form1
                AddToReceiptClicked?.Invoke(this, new ProductEventArgs(product));

                // Hide the button
                control.Visible = false;

                // Enable the PlusPanel and MinusPanel
                PlusPanel.Visible = true;
                MinusPanel.Visible = true;
                CountLabel.Visible = true;
                Count++;
                CountLabel.Text = Count.ToString();
                if(product.Stock - 1 == 0)
                {
                    EnableNotinStock();
                }
            }
        }
        private void IncrementCount_Click(object sender, EventArgs e)
        {
            // Get the product associated with the button
            Control control = (Control)sender;
            Products product = this.Tag as Products;

            // Check if the product is valid
            if (product != null)
            {
                // Trigger the event to notify Form1
                IncrementCountClicked?.Invoke(this, new ProductEventArgs(product));
                
                Count++;
                CountLabel.Text = Count.ToString();
            }
        }

        // Event handler for decrementing the product count
        private void DecrementCount_Click(object sender, EventArgs e)
        {
            // Get the product associated with the button
            Control control = (Control)sender;
            Products product = this.Tag as Products;

            // Check if the product is valid
            if (product != null)
            {
                // Trigger the event to notify Form1
                DecrementCountClicked?.Invoke(this, new ProductEventArgs(product));
                Count--;
                if(Count < 0)
                {
                    Count = 0;
                }
                CountLabel.Text = Count.ToString();

            }
        }
        public void EnableNotinStock()
        {
            NotinStockLabel.Visible = true;
            AddToRecieptButton.Visible = false;
        }
        public void DisableNotinStock()
        {
            NotinStockLabel.Visible = false;
        }
    }
    public class ProductEventArgs : EventArgs
    {
        public Products Product { get; }

        public ProductEventArgs(Products product)
        {
            Product = product;
        }
    }
}
