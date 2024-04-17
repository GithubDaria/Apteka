using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apteka
{
    class DataPrinter
    {
        Image defaultiamge = Image.FromFile(@"C:\Users\prooo\source\repos\Apteka\Apteka\Debug\ProductsImages\DefaultPicture.jpg");
        private int maxLoadedProductsCount;
        public int MaxLoadedProductsCount
        {
            get { return maxLoadedProductsCount; }
            set { maxLoadedProductsCount = value; }
        }

        private int pageSize = 20; // Number of products per page
        private int loadedProductsCount = 0;

        public int LoadedProductsCount
        {
            get { return loadedProductsCount; }
            set { loadedProductsCount = value; }
        }
        private FlowLayoutPanel productsLayout;

        private Form1 form1;

        public DataPrinter(FlowLayoutPanel _productsLayout, Form1 _form1)
        {
            form1 = _form1;
            productsLayout = _productsLayout;
        }
        public void AddCustomControlsToLayoutPanel(List<Products> products, EventHandler<ProductEventArgs> productEventHandler)
        {
            if (products != null)
            {
                // Calculate the range of products to load
                int startIndex = loadedProductsCount;
                int endIndex = Math.Min(startIndex + pageSize - 1, products.Count - 1);

                // Check if endIndex is non-negative
                if (endIndex >= 0)
                {
                    // Loop through the range of products to add
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        // Create custom control for each product and add it to the layout panel
                        ProductsLayoutInList customControl = new ProductsLayoutInList(LoadImage(products[i].ProductID))
                        {
                            // Populate labels in the custom control with product information
                            ProductCode = $"Код товару {products[i].ProductID}",
                            PRoductName = products[i].Name,
                            ProductCost = products[i].Price.ToString() + "₴",
                            
                        };

                        customControl.Tag = products[i];
                        // Add the custom control to the layout panel
                        customControl.HandleProductEvent += productEventHandler;
                        customControl.AddToReceiptClicked += form1.ProductsLayoutInList_AddToReceiptClicked;

                        customControl.IncrementCountClicked += form1.ProductsLayoutInList_IncrementCountClicked;
                        customControl.DecrementCountClicked += form1.ProductsLayoutInList_DecrementCountClicked;
                        Console.WriteLine("Stock" + products[i].Stock);
                        if (products[i].Stock == 0)
                        {
                            customControl.EnableNotinStock();
                        }
                        productsLayout.Controls.Add(customControl);
                    }

                    // Update the count of loaded products
                    loadedProductsCount += endIndex - startIndex + 1;
                }
            }
            else
            {
                Console.WriteLine("IsNull");
            }
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
        public void ResetLoadedProductsCount()
        {
            productsLayout.Controls.Clear();
            loadedProductsCount = 0;
        }
        public string RemoveDoubleSlashes(string path)
        {
            return Regex.Replace(path, @"[\\]+", @"\");
        }
    }
}
