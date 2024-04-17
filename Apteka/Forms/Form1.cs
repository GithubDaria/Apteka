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
    public partial class Form1 : KryptonForm
    {
        private DataPrinter dataPrinter;
        private DataLoader _dataLoader;
        private List<Products> _products;
        private List<Manufacturer> _manufacturers;
        private List<PrescriptionType> _prescriptionTypes;
        private List<TypeOfMedication> _typeOfMedications;
        private List<Seller> _sellers;
        private List<Receipt> _receipts;
        private List<ReceiptsDetail> _receiptsDetails;

        private List<Products> FilterdeList;
        private List<string> nameKeywords = new List<string>();
        private decimal lowestCost;
        private decimal highestCost;
        private List<Manufacturer> selectedManufacturers = new List<Manufacturer>();
        private List<PrescriptionType> selectedPrescriptionTypes = new List<PrescriptionType>();
        private List<TypeOfMedication> selectedMedicationTypes = new List<TypeOfMedication>();
        private string selectedSort;

        private Dictionary<Products, int> productQuantities = new Dictionary<Products, int>();

        public delegate void LoadMoreButtonClickedEventHandler(object sender, EventArgs e);

        SellersForm sellersForm;

        // Instantiate your user control

        // Subscribe to the custom event

        public Form1(List<Products> products, List<Manufacturer> manufacturers, List<PrescriptionType> prescriptionTypes,
            List<TypeOfMedication> typeOfMedications, List<Seller> sellers, List<Receipt> receipts, List<ReceiptsDetail> receiptsDetails, DataLoader datalowder)
        {
            InitializeComponent();
            _products = products;
            _manufacturers = manufacturers;
            _prescriptionTypes = prescriptionTypes;
            _typeOfMedications = typeOfMedications;
            _sellers = sellers;
            _receipts = receipts;
            _receiptsDetails = receiptsDetails;
            _dataLoader = datalowder;
        }
        //First print
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAllTheData();
        }
        public void LoadAllTheData()
        {
            LoadMinMaxTextBox();
            LoadProducts();
            LoadSoartingComboBox();
            LoadManufacturers();
            LoadPrescriptionType();
            LoadMedicationType();
            LoadSellersForm();
        }
        public void UpdateProducts(List<Products> products)
        {
            if (products != null)
            {
                _products = products;
                // Update products
                LoadProducts();
            }
        }

        public void UpdateManufacturers(List<Manufacturer> manufacturers)
        {
            if (manufacturers != null)
            {
                _manufacturers = manufacturers;
                LoadManufacturers();
                // Update manufacturers
            }
        }

        public void UpdatePrescriptionTypes(List<PrescriptionType> prescriptionTypes)
        {
            if (prescriptionTypes != null)
            {
                _prescriptionTypes = prescriptionTypes;
                LoadPrescriptionType();
                // Update prescription types
            }
        }

        public void UpdateTypeOfMedications(List<TypeOfMedication> typeOfMedications)
        {
            if (typeOfMedications != null)
            {
                _typeOfMedications = typeOfMedications;
                LoadMedicationType();
                // Update type of medications
            }
        }

        public void UpdateSellers(List<Seller> sellers)
        {
            if (sellers != null)
            {
                _sellers = sellers;
                // Update sellers
            }
        }

        public void UpdateReceipts(Receipt receipt)
        {
            if (receipt != null)
            {
                _receipts.Add(receipt);
                // Update receipts
                LoadProducts();
            }
        }

        public void UpdateReceiptDetails(ReceiptsDetail receiptsDetail)
        {
            if (receiptsDetail != null)
            {
                _receiptsDetails.Add(receiptsDetail);
                productQuantities.Clear();
                // Update receipt details
            }
        }
        public void DeleteProducts(Products products)
        {
            _products.Remove(products);
            LoadProducts();
        }
            #region Set Up The Search Values
            private void LoadProducts()
        {
            // Initialize and display MainForm
            if (dataPrinter ==null){
                dataPrinter = new DataPrinter(ProductsLayout, this);
            }
            ProductsLayout.Controls.Clear();
            dataPrinter.AddCustomControlsToLayoutPanel(_products, ProductControl_HandleProductEvent); // Pass the existing ProductsLayout control
            LoadMoreButtonControl loadMoreButton = new LoadMoreButtonControl();

            // Add the LoadMoreButtonControl to the bottom of the productsLayout
            ProductsLayout.Controls.Add(loadMoreButton);

            // Subscribe to the LoadMoreButtonClicked event of the LoadMoreButtonControl
            loadMoreButton.LoadMoreButtonClicked += LoadMoreButton_Clicked;
        }

        private void LoadMoreButton_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Herere");
            ProductsLayout.Controls.Remove((Control)sender);
            PassTheProducts(FilterdeList);
        }
        private void LoadManufacturers()
        {
            checkBoxListManufacturers.Items.Clear();

            // Add manufacturer names to the checkbox list
            foreach (Manufacturer manufacturer in _manufacturers)
            {
                // Create a new CheckBoxListItem with the manufacturer name and tag the Manufacturer object
                CheckBoxListItem item = new CheckBoxListItem(manufacturer.Name);
                item.Tag = manufacturer;

                // Add the CheckBoxListItem to the CheckBoxList
                checkBoxListManufacturers.Items.Add(item);
            }

        }
        private void LoadPrescriptionType()
        {
            checkBoxListPrescriptionTypes.Items.Clear();

            // Add prescription type names to the checkbox list
            foreach (PrescriptionType prescriptionType in _prescriptionTypes)
            {
                // Create a new CheckBoxListItem with the prescription type name and tag the PrescriptionType object
                CheckBoxListItem item = new CheckBoxListItem(prescriptionType.TypeName);
                item.Tag = prescriptionType;

                // Add the CheckBoxListItem to the CheckBoxList
                checkBoxListPrescriptionTypes.Items.Add(item);
            }

        }
        private void LoadMedicationType()
        {
            checkBoxListMedicationTypes.Items.Clear();

            // Add medication type names to the checkbox list
            foreach (TypeOfMedication medicationType in _typeOfMedications)
            {
                // Create a new CheckBoxListItem with the medication type name and tag the TypeOfMedication object
                CheckBoxListItem item = new CheckBoxListItem(medicationType.Name);
                item.Tag = medicationType;

                // Add the CheckBoxListItem to the CheckBoxList
                checkBoxListMedicationTypes.Items.Add(item);
            }
        }
        private void LoadSoartingComboBox()
        {
            SortingComboBox.Items.Clear();
            SortingComboBox.Items.AddRange(new string[] { "за алфавітом", "за зростанням", "за спаданням" });

            // Set the default selection
            SortingComboBox.SelectedIndex = 0; // "за алфавітом" is default
        }
        private void LoadMinMaxTextBox()
        {
            lowestCost = _products.Min(product => product.Price);
            highestCost = _products.Max(product => product.Price);

            MinPriceTextBox.Text = lowestCost.ToString();
            MaxPriceTextBox.Text = highestCost.ToString();

        }
        #endregion
        #region Min max Search event
        private void MinPriceTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Prevent the Enter key from producing a 'ding' sound
                e.SuppressKeyPress = true;

                // Call the main function to perform the search
                PerformSearch();
            }
        }

        private void MaxPriceTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Prevent the Enter key from producing a 'ding' sound
                e.SuppressKeyPress = true;

                // Call the main function to perform the search
                PerformSearch();
            }
        }
        #endregion
        #region Search system
        private void PerformSearch()
        {
            // Parse the minimum and maximum price values from the textboxes
            if (!decimal.TryParse(MinPriceTextBox.Text, out decimal minPrice) ||
                !decimal.TryParse(MaxPriceTextBox.Text, out decimal maxPrice))
            {
                minPrice = lowestCost;
                maxPrice = highestCost;
                MinPriceTextBox.Text = lowestCost.ToString();
                MaxPriceTextBox.Text = highestCost.ToString();
            }

            // Adjust the values if they are less than 0 or greater than the maximum value
            minPrice = Math.Max(minPrice, lowestCost);
            maxPrice = Math.Min(maxPrice, highestCost); // Use double.MaxValue as the upper limit

            // Ensure minPrice is not greater than maxPrice
            minPrice = Math.Min(minPrice, maxPrice);

            // Perform the search using the provided price range, selected manufacturers, and prescription types
            GetSearchProducts(minPrice, maxPrice, selectedManufacturers, selectedPrescriptionTypes);
        }

        private void GetSearchProducts(decimal minPrice, decimal maxPrice, List<Manufacturer> selectedManufacturers, List<PrescriptionType> selectedPrescriptionTypes)
        {
            dataPrinter.ResetLoadedProductsCount();
            // Filter products based on the price range, selected manufacturers, and prescription types
            List<Products> filteredProducts = SortingProducts(FilterProducts(_products, minPrice, maxPrice, selectedManufacturers, selectedPrescriptionTypes, selectedMedicationTypes));
            FilterdeList = filteredProducts;
            // Display the filtered products
            PassTheProducts(filteredProducts);
        }
        private void PassTheProducts(List<Products> filteredProducts)
        {
           
            if (filteredProducts == null)
            {
                filteredProducts = _products;
            }
            if (filteredProducts.Count == 0) 
            {
                User_Control.Not_found not_Found = new User_Control.Not_found();
                ProductsLayout.Controls.Add(not_Found);

            }
            else
            {
                dataPrinter.AddCustomControlsToLayoutPanel(filteredProducts, ProductControl_HandleProductEvent);
                if (dataPrinter.LoadedProductsCount < filteredProducts.Count)
                {
                    LoadMoreButtonControl loadMoreButton = new LoadMoreButtonControl();
                    // Add the LoadMoreButtonControl to the bottom of the productsLayout
                    ProductsLayout.Controls.Add(loadMoreButton);
                    // Subscribe to the LoadMoreClicked event of the LoadMoreButtonControl
                    loadMoreButton.LoadMoreButtonClicked -= LoadMoreButton_Clicked; // Unsubscribe first
                    loadMoreButton.LoadMoreButtonClicked += LoadMoreButton_Clicked; // Then subscribe
                }
            }
        }
        private List<Products> FilterProducts(List<Products> products, decimal minPrice, decimal maxPrice, List<Manufacturer> selectedManufacturers,
            List<PrescriptionType> selectedPrescriptionTypes, List<TypeOfMedication> selectedMedicationTypes)
        {
            // Filter products based on the price range
            var filteredProducts = products.Where(product =>
                product.Price >= minPrice &&
                product.Price <= maxPrice);

            // Filter based on selected manufacturers if any are selected
            if (selectedManufacturers != null && selectedManufacturers.Any())
            {
                filteredProducts = filteredProducts.Where(product =>
                    selectedManufacturers.Any(manufacturer => manufacturer.ManufacturerID == product.Manufacturer.ManufacturerID));
            }

            // Filter based on selected prescription types if any are selected
            if (selectedPrescriptionTypes != null && selectedPrescriptionTypes.Any())
            {
                filteredProducts = filteredProducts.Where(product =>
                    selectedPrescriptionTypes.Any(type => type.PrescriptionTypeID == product.PrescriptionType.PrescriptionTypeID));
            }

            // Filter based on selected medication types if any are selected
            if (selectedMedicationTypes != null && selectedMedicationTypes.Any())
            {
                filteredProducts = filteredProducts.Where(product =>
                    selectedMedicationTypes.Any(type => type.TypeOfMedicationID == product.TypeOfmedication.TypeOfMedicationID));
            }

            // Filter based on name keywords
            if (nameKeywords != null && nameKeywords.Any())
            {
                filteredProducts = filteredProducts.Where(product =>
                    nameKeywords.Any(keyword =>
                        product.Name.ToLower().Contains(keyword.ToLower())));
            }

            return filteredProducts.ToList();
        }
        private List<Products> SortingProducts(List<Products> filteredProducts)
        {
            switch (selectedSort)
            {
                case "за алфавітом":
                    return filteredProducts.OrderBy(product => product.Name).ToList();
                case "за зростанням":
                    return filteredProducts.OrderBy(product => product.Price).ToList();
                case "за спаданням":
                    return filteredProducts.OrderByDescending(product => product.Price).ToList();
                default:
                    return filteredProducts;
            }
        }
        #endregion
        #region User Events
        private void checkBoxListManufacturers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Get the CheckBoxListItem associated with the checked item
            CheckBoxListItem checkedItem = checkBoxListManufacturers.Items[e.Index] as CheckBoxListItem;

            // Get the Manufacturer object from the Tag property
            Manufacturer selectedManufacturer = checkedItem.Tag as Manufacturer;

            if (e.NewValue == CheckState.Checked)
            {
                // If the item is checked, add the manufacturer to the selected list
                selectedManufacturers.Add(selectedManufacturer);
            }
            else
            {
                // If the item is unchecked, remove the manufacturer from the selected list
                selectedManufacturers.Remove(selectedManufacturer);
            }

            // Perform the search using the selected manufacturers
            PerformSearch();
        }
        private void checkBoxListPrescriptionTypes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Get the CheckBoxListItem associated with the checked item
            CheckBoxListItem checkedItem = checkBoxListPrescriptionTypes.Items[e.Index] as CheckBoxListItem;

            // Get the PrescriptionType object from the Tag property
            PrescriptionType selectedPrescriptionType = checkedItem.Tag as PrescriptionType;

            if (e.NewValue == CheckState.Checked)
            {
                // If the item is checked, add the prescription type to the selected list
                selectedPrescriptionTypes.Add(selectedPrescriptionType);
            }
            else
            {
                // If the item is unchecked, remove the prescription type from the selected list
                selectedPrescriptionTypes.Remove(selectedPrescriptionType);
            }

            // Perform the search using the selected prescription types
            PerformSearch();
        }
        private void checkBoxListMedicationTypes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Get the CheckBoxListItem associated with the checked item
            CheckBoxListItem checkedItem = checkBoxListMedicationTypes.Items[e.Index] as CheckBoxListItem;

            // Get the TypeOfMedication object from the Tag property
            TypeOfMedication selectedMedicationType = checkedItem.Tag as TypeOfMedication;

            if (e.NewValue == CheckState.Checked)
            {
                // If the item is checked, add the medication type to the selected list
                selectedMedicationTypes.Add(selectedMedicationType);
            }
            else
            {
                // If the item is unchecked, remove the medication type from the selected list
                selectedMedicationTypes.Remove(selectedMedicationType);
            }

            // Perform the search using the selected medication types
            PerformSearch();
        }
        private void ProductNameTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = ProductNameTextBox.Text.Trim();

            nameKeywords = searchText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            PerformSearch();
        }
        private void SortingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            KryptonComboBox comboBox = sender as KryptonComboBox;

            if (comboBox != null && comboBox.SelectedItem != null)
            {
                selectedSort = comboBox.SelectedItem.ToString();
                PerformSearch();
            }
        }
        #endregion
        #region Change Forms
        private void LoadSellersForm()
        {
            sellersForm = new SellersForm(_sellers, this);

        }
        public void OpenSellersPage()
        {
            sellersForm.Show();
            this.Hide();
        }
        private void SellersPage_Click(object sender, EventArgs e)
        {
            //sellersForm.FormClosed += (s, args) => this.Close();
            OpenSellersPage();
        }
        private void ProductControl_HandleProductEvent(object sender, ProductEventArgs e)
        {
            // Handle the event raised by the user control
            Products product = e.Product;
            Product productDetailsForm = new Product(product, this, _dataLoader);
            productDetailsForm.Show();
            this.Hide();

        }
        public void OpenReceiptsPage()
        {
            ReceitsForm receipt = new ReceitsForm(_receipts, this);
            receipt.Show();
            this.Hide();
        }
        private void RecieptsPageButton_Click(object sender, EventArgs e)
        {
            OpenReceiptsPage();
        }
        public void OpenAddProductPage()
        {
            AddingProductForm addingProductForm = new AddingProductForm(_manufacturers, _prescriptionTypes, _typeOfMedications, _products, this, null, _dataLoader);
            addingProductForm.Show();
            this.Hide();
        }
        private void AddProductPage_Click(object sender, EventArgs e)
        {
            OpenAddProductPage();
        }
        public void EditProductPage(Products product)
        {
            AddingProductForm addingProductForm = new AddingProductForm(_manufacturers, _prescriptionTypes, _typeOfMedications, _products, this, product, _dataLoader);
            addingProductForm.Show();
            this.Hide();
        }
        public void OpenReceiptCreationPage()
        {
            // Assuming productQuantities is your original dictionary
            Dictionary<Products, int> productQuantitiesCopy = new Dictionary<Products, int>(productQuantities);

            CreateReceipts receipt = new CreateReceipts(productQuantitiesCopy, _sellers, this, _dataLoader);

            receipt.Show();
            this.Hide();
        }
        private void label5_Click(object sender, EventArgs e)
        {
            OpenReceiptCreationPage();
        }
        #endregion
        #region CreatingReceit

        public void ProductsLayoutInList_AddToReceiptClicked(object sender, ProductEventArgs e)
        {
            // Handle the event and call the method in Form1 to add the product to the receipt
            AddProductToReceipt(e.Product);
        }
        private void AddProductToReceipt(Products product)
        {
            if (productQuantities.ContainsKey(product))
            {
                productQuantities[product]++;
            }
            else
            {
                productQuantities.Add(product, 1);
            }
        }

        public void ProductsLayoutInList_IncrementCountClicked(object sender, EventArgs e)
        {
            if (sender is ProductsLayoutInList control && control.Tag is Products product)
            {
               
                if (productQuantities.ContainsKey(product))
                {
                 
                    productQuantities[product] += 1;
                    Console.WriteLine("productqunt" + productQuantities[product] + "-" + "product.Stock" + product.Stock);
                   

                }
                else
                {
                    productQuantities.Add(product, 1);
                }
                if (product.Stock - productQuantities[product] == 0)
                {
                    control.EnableNotinStock();

                }

            }
        }
     
        public void ProductsLayoutInList_DecrementCountClicked(object sender, EventArgs e)
        {
            if (sender is ProductsLayoutInList control && control.Tag is Products product)
            {
                if (productQuantities.ContainsKey(product))
                {
                    if (productQuantities[product] > 1)
                    {

                        productQuantities[product] -= 1;
                        if (product.Stock - productQuantities[product] > 0)
                        {
                            control.DisableNotinStock();
                        }

                    }
                    else
                    {
                        productQuantities.Remove(product);
                        control.DisableNotinStock();
                    }
                    
                }
            }
        }
        public void UpdateBoughtProducts(Receipt receipt)
        {
            foreach (var productKey in receipt.ReceiptDetails.ProductQuantities.Keys)
            {
                // Find the matching product in Products list based on the product key
                var matchingProduct = _products.FirstOrDefault(p => p.ProductID == productKey.ProductID);

                if (matchingProduct != null)
                {
                    // Get the quantity from ProductQuantities dictionary
                    int quantity = receipt.ReceiptDetails.ProductQuantities[productKey];

                    // Update stock
                    matchingProduct.Stock -= quantity;
                }
            }

            _dataLoader.UpdateBoughtProductsDatabase(receipt);
        }
        #endregion
    }

}
