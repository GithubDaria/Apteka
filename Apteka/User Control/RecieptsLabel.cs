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
    public partial class RecieptsLabel : UserControl
    {
        public RecieptsLabel()
        {
            InitializeComponent();
        }

        public string productName
        {
            set { ProductName.Text = value; }
        }

        public string ProductCode
        {
            set { CodeLabel.Text = value; }
        }

        public int ProdcutCount
        {
            set { CountLabel.Text = value.ToString(); }
        }

        public decimal ProductCost
        {
            set { CostLabel.Text = value.ToString(); }
        }

        // Event handler for increment button click
        public event EventHandler IncrementCountClicked;

        // Event handler for decrement button click
        public event EventHandler DecrementCountClicked;

        private void incrementButton_Click(object sender, EventArgs e)
        {
            // Raise the IncrementCountClicked event
            IncrementCountClicked?.Invoke(this, EventArgs.Empty);
        }

        private void decrementButton_Click(object sender, EventArgs e)
        {
            // Raise the DecrementCountClicked event
            DecrementCountClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
