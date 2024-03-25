using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;


namespace Apteka
{
    public partial class AddingProductForm : KryptonForm
    {
        private List<ComboItem> originalComboBoxItems = new List<ComboItem>(); // List to store original ComboBox items
        private List<ComboItem> prescriptionOriginalItems = new List<ComboItem>();
        private List<ComboItem> typeOriginalItems = new List<ComboItem>();
        private List<Manufacturer> _manufacturers;
        private List<PrescriptionType> _prescriptionTypes;
        private List<TypeOfMedication> _typeOfMedications;
        private List<Products> _products;

        private Products NewItem;
        private Manufacturer NewManufacture;
        private PrescriptionType NewPrescription;
        private TypeOfMedication NewTypeMedicin;
        private Form1 _form1;
        private DataLoader _dataLoader;
        private Products EditProduct;

        private TypeOfMedication ChoosenTypeOfMedication;
        private Manufacturer ChoosenManufacturer;
        private PrescriptionType ChoosenPrescriptionType;


        private bool _explicitClose = true;
        public AddingProductForm(List<Manufacturer> manufacturers, List<PrescriptionType> prescriptionTypes, List<TypeOfMedication> typeOfMedications , List<Products> products, Form1 form1, Products _product, DataLoader dataLoader)
        {
            _manufacturers = manufacturers;
            _prescriptionTypes = prescriptionTypes;
            _typeOfMedications = typeOfMedications;
            _form1 = form1;
            _dataLoader = dataLoader;
            _products = products;
            InitializeComponent();
            EditProduct = _product;
            ManufacturePopulateComboBox();
            PopulatePrescriptionTypeComboBox();
            PopulateTypeOfMedicationComboBox();
            if (EditProduct != null)
            {
                ProductNameTextBox.Text = EditProduct.Name;
                AssignComboBoxEdit(EditProduct.PrescriptionType, PrescriptionComboBox);
                AssignComboBoxEdit(EditProduct.Manufacturer, ManufactureComboBox);
                AssignComboBoxEdit(EditProduct.TypeOfmedication, TypeComboBox);
                ConfirmButton.Text = "Змінити товар";
                CosttextBox.Text = EditProduct.Price.ToString();
                StockTextBox.Text = EditProduct.Stock.ToString();
            }
                
           
        }
        #region Assigning for Edit
        private void AssignComboBoxEdit(PrescriptionType prescriptionType, ComboBox combobox)
        {
            ComboItem itemToSelect = null;
            foreach (object item in combobox.Items)
            {
                if (item is ComboItem comboItem)
                {
                    PrescriptionType selectedType = comboItem.Item as PrescriptionType;
                    if (selectedType == prescriptionType)
                    {
                        itemToSelect = comboItem;
                        break;
                    }
                }
            }
            combobox.SelectedItem = itemToSelect;
        }

        private void AssignComboBoxEdit(Manufacturer manufacturer, ComboBox combobox)
        {
            ComboItem itemToSelect = null;
            foreach (object item in combobox.Items)
            {
                if (item is ComboItem comboItem)
                {
                    Manufacturer selectedType = comboItem.Item as Manufacturer;
                    if (selectedType == manufacturer)
                    {
                        itemToSelect = comboItem;
                        break;
                    }
                }
            }
            combobox.SelectedItem = itemToSelect;
        }

        private void AssignComboBoxEdit(TypeOfMedication typeOfMedication, ComboBox combobox)
        {
            ComboItem itemToSelect = null;
            foreach (object item in combobox.Items)
            {
                if (item is ComboItem comboItem)
                {
                    TypeOfMedication selectedType = comboItem.Item as TypeOfMedication;
                    if (selectedType == typeOfMedication)
                    {
                        itemToSelect = comboItem;
                        break;
                    }
                }
            }
            combobox.SelectedItem = itemToSelect;
        }
        #endregion
        private void AddingProductForm_Load(object sender, EventArgs e)
        {

        }
        #region SelectedIndexChanged
        public void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            Console.WriteLine("ComboBox Data:");
            foreach (var item in comboBox.Items)
            {
                Console.WriteLine($"Item: {item}, Type: {item.GetType()}");
            }
            string selectedValue = comboBox.SelectedItem.ToString();

            if (selectedValue == "Додати тип")
            {
                // Prompt the user to enter the new type name
                string newTypeName = PromptUserForNew();

                if (!string.IsNullOrEmpty(newTypeName))
                {
                    // Create a new TypeOfMedication object with a temporary ID
                    TypeOfMedication newType = new TypeOfMedication(-1, newTypeName); // Assuming -1 is a placeholder for a temporary ID

                    // Create a new ComboItem with the new type name and associated TypeOfMedication object
                    ComboItem comboItem = new ComboItem(newTypeName, newType);

                    // Insert the new ComboItem at index 1 (after the "Add Type" item)
                    comboBox.Items.Insert(1, comboItem);

                    // Add the new ComboItem to the original items list
                    typeOriginalItems.Insert(1, comboItem);

                    // Select the newly added item
                    comboBox.SelectedItem = comboItem;
                }
                else
                {
                    // If the user cancels or enters an empty name, select the first item
                    comboBox.SelectedIndex = 0;
                }
            }
            else
            {
                if (comboBox.SelectedItem is ComboItem comboBoxItem)
                {
                    // Retrieve the TypeOfMedication from the ComboItem
                    ChoosenTypeOfMedication = comboBoxItem.Item as TypeOfMedication;
                }
                /*
                
                ComboItem comboBoxItem = (ComboItem)comboBox.SelectedItem;
                ChoosenTypeOfMedication = comboBoxItem.Item as TypeOfMedication;*/
            }
        }
        public void ManufacturerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            object selectedItem = comboBox.SelectedItem;

            if (selectedItem != null && selectedItem is ComboItem comboItem)
            {
                ChoosenManufacturer = comboItem.Item as Manufacturer;
            }
            else if (selectedItem != null && selectedItem.ToString() == "Додати виробника")
            {
                // Prompt the user to enter the new manufacturer name
                string newManufacturerName = PromptUserForNew();

                if (!string.IsNullOrEmpty(newManufacturerName))
                {
                    // Create a new Manufacturer object with a temporary ID
                    Manufacturer newManufacturer = new Manufacturer(-1, newManufacturerName); // Assuming -1 is a placeholder for a temporary ID
                    NewManufacture = newManufacturer;

                    // Create a new ComboItem with the new manufacturer name and associated Manufacturer object
                    ComboItem newComboItem = new ComboItem(newManufacturerName, newManufacturer);

                    // Add the new ComboItem to the ComboBox and original items list
                    comboBox.Items.Insert(1, newComboItem);
                    originalComboBoxItems.Add(newComboItem);

                    // Select the newly added item
                    comboBox.SelectedItem = newComboItem;
                }
                else
                {
                    // If the user cancels or enters an empty name, select the first item
                    comboBox.SelectedIndex = 0;
                }
            }
        }

        public void PrescriptionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            object selectedItem = comboBox.SelectedItem;

            if (selectedItem != null && selectedItem is ComboItem comboItem)
            {
                ChoosenPrescriptionType = comboItem.Item as PrescriptionType;
            }
            else if (selectedItem != null && selectedItem.ToString() == "Додати призначення")
            {
                // Prompt the user to enter the new prescription type name
                string newPrescriptionTypeName = PromptUserForNew();

                if (!string.IsNullOrEmpty(newPrescriptionTypeName))
                {
                    // Create a new PrescriptionType object with a temporary ID
                    PrescriptionType newPrescriptionType = new PrescriptionType(-1, newPrescriptionTypeName); // Assuming -1 is a placeholder for a temporary ID
                    NewPrescription = newPrescriptionType;

                    // Create a new ComboItem with the new prescription type name and associated PrescriptionType object
                    ComboItem newComboItem = new ComboItem(newPrescriptionTypeName, newPrescriptionType);

                    // Add the new ComboItem to the ComboBox and original items list
                    comboBox.Items.Insert(1, newComboItem);
                    prescriptionOriginalItems.Add(newComboItem);

                    // Select the newly added item
                    comboBox.SelectedItem = newComboItem;
                }
                else
                {
                    // If the user cancels or enters an empty name, select the first item
                    comboBox.SelectedIndex = 0;
                }
            }
        }

        #endregion
        #region TextChanged
        private void ManufactureComboBox_TextUpdate(object sender, EventArgs e)
        {
            FilterComboBox(ManufactureComboBox, originalComboBoxItems, ManufactureComboBox.Text);
            // Move the cursor to the end of the text
            ManufactureComboBox.SelectionStart = ManufactureComboBox.Text.Length;
        }
        private void PrescriptionComboBox_TextUpdate(object sender, EventArgs e)
        {
            FilterComboBox(PrescriptionComboBox, prescriptionOriginalItems, PrescriptionComboBox.Text);
            PrescriptionComboBox.SelectionStart = PrescriptionComboBox.Text.Length;

        }
        private void TypeComboBox_TextUpdate(object sender, EventArgs e)
        {
            FilterComboBox(TypeComboBox, typeOriginalItems, TypeComboBox.Text);
            TypeComboBox.SelectionStart = TypeComboBox.Text.Length;

        }
        #endregion
        private string PromptUserForNew()
        {
            using (var form = new Form())
            {
                form.StartPosition = FormStartPosition.CenterParent;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.Width = 250;
                form.Height = 150;

                Label label = new Label();
                label.Location = new Point(10, 10);
                label.Size = new Size(200, 20);
                label.Text = "Додати новий ";
                form.Controls.Add(label);

                TextBox textBox = new TextBox();
                textBox.Location = new Point(10, 40);
                textBox.Size = new Size(200, 20);
                form.Controls.Add(textBox);

                Button okButton = new Button();
                okButton.Text = "OK";
                okButton.DialogResult = DialogResult.OK;
                okButton.Location = new Point(50, 80);
                form.Controls.Add(okButton);

                Button cancelButton = new Button();
                cancelButton.Text = "Cancel";
                cancelButton.DialogResult = DialogResult.Cancel;
                cancelButton.Location = new Point(120, 80);
                form.Controls.Add(cancelButton);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    return textBox.Text.Trim();
                }

                return null;
            }

        }

        private string GetTopItemText(ComboBox comboBox)
        {
            if (comboBox == PrescriptionComboBox)
            {
                return "Додати призначення";
            }
            else if (comboBox == TypeComboBox)
            {
                return "Додати тип";
            }
            else if (comboBox == ManufactureComboBox)
            {
                return "Додати виробника";
            }
            // Add more conditions for other ComboBoxes if needed
            else
            {
                return string.Empty;
            }
        }

        private void FilterComboBox(ComboBox comboBox, List<ComboItem> originalItems, string searchText)
        {
            comboBox.Items.Clear(); // Clear the items in ComboBox

            // Add appropriate item at the top
            comboBox.Items.Add(GetTopItemText(comboBox));

            // If search text is empty, display all items in ComboBox
            if (string.IsNullOrWhiteSpace(searchText))
            {
                foreach (var item in originalItems)
                {
                    comboBox.Items.Add(item);
                }
            }
            else
            {
                // Filter and add items to ComboBox based on the search text
                foreach (var item in originalItems)
                {
                    if (item.Name.IndexOf(searchText, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        comboBox.Items.Add(item);
                    }
                }
            }
        }
        #region Populating ComboBox
        private void ManufacturePopulateComboBox()
        {
            originalComboBoxItems.Clear(); // Clear the originalComboBoxItems collection
            ManufactureComboBox.Items.Clear(); // Clear the items in ComboBox

            // Add "Add Manufacturer" item at the top
            ManufactureComboBox.Items.Add("Додати виробника");

            // Populate originalComboBoxItems and ComboBox
            foreach (Manufacturer manufacturer in _manufacturers)
            {
                string manufacturerName = manufacturer.Name;
                ComboItem comboItem = new ComboItem(manufacturerName, manufacturer);
                originalComboBoxItems.Add(comboItem);
                ManufactureComboBox.Items.Add(comboItem);
            }
        }

        private void PopulatePrescriptionTypeComboBox()
        {
            // Clear the items in the ComboBox
            PrescriptionComboBox.Items.Clear();

            // Add "Add Prescription Type" item at the top
            PrescriptionComboBox.Items.Add("Додати призначення");

            // Populate the ComboBox with prescription type names
            foreach (PrescriptionType prescriptionType in _prescriptionTypes)
            {
                string typeName = prescriptionType.TypeName;
                ComboItem comboItem = new ComboItem(typeName, prescriptionType);
                PrescriptionComboBox.Items.Add(comboItem);
                prescriptionOriginalItems.Add(comboItem);
            }
        }
        private void PopulateTypeOfMedicationComboBox()
        {
            // Clear the items in the ComboBox
            TypeComboBox.Items.Clear();

            // Add "Add Type of Medication" item at the top
            TypeComboBox.Items.Add("Додати тип");

            // Populate the ComboBox with type of medication names
            foreach (TypeOfMedication typeOfMedication in _typeOfMedications)
            {
                string typeName = typeOfMedication.Name;
                ComboItem comboItem = new ComboItem(typeName, typeOfMedication);
                TypeComboBox.Items.Add(comboItem);
                typeOriginalItems.Add(comboItem);
            }
        }
        #endregion
        private void label17_Click(object sender, EventArgs e)
        {
            // Check if essential fields are selected
            if (ChoosenTypeOfMedication == null || ChoosenManufacturer == null || ChoosenPrescriptionType == null)
            {
                MessageBox.Show("Не всі поля обрані");
                return;
            }

            // Validate cost and stock inputs
            if (!decimal.TryParse(CosttextBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal cost) ||
                !int.TryParse(StockTextBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out int stock))
            {
                MessageBox.Show("Неправильні дані");
                return;
            }

            // Insert new manufacturer if applicable
            if (NewManufacture != null && NewManufacture == ChoosenManufacturer)
            {
                int manufacturerId = _dataLoader.InsertManufacturer(NewManufacture.Name);
                if (manufacturerId != -1)
                {
                    NewManufacture.ManufacturerID = manufacturerId;
                    _manufacturers.Add(NewManufacture);
                    _form1.UpdateManufacturers(_manufacturers);
                }
                else
                {
                    // Handle the case where insertion failed
                }
            }

            if (NewPrescription != null && NewPrescription == ChoosenPrescriptionType)
            {
                int prescriptionTypeId = _dataLoader.InsertPrescriptionType(NewPrescription.TypeName);
                if (prescriptionTypeId != -1)
                {
                    NewPrescription.PrescriptionTypeID = prescriptionTypeId;
                    _prescriptionTypes.Add(NewPrescription);
                    _form1.UpdatePrescriptionTypes(_prescriptionTypes);
                }
                else
                {
                    // Handle the case where insertion failed
                }
            }
            if (NewTypeMedicin != null && NewTypeMedicin == ChoosenTypeOfMedication)
            {
                int typeOfMedicationId = _dataLoader.InsertTypeOfMedication(NewTypeMedicin.Name);
                if (typeOfMedicationId != -1)
                {
                    NewTypeMedicin.TypeOfMedicationID = typeOfMedicationId;
                    _typeOfMedications.Add(NewTypeMedicin);
                    _form1.UpdateTypeOfMedications(_typeOfMedications);
                }
                else
                {
                    // Handle the case where insertion failed
                }
            }


            // Edit or insert product based on the context
            if (EditProduct != null)
            {
                EditProduct.Name = ProductNameTextBox.Text;
                EditProduct.TypeOfmedication = ChoosenTypeOfMedication;
                EditProduct.Manufacturer = ChoosenManufacturer;
                EditProduct.Price = cost;
                EditProduct.Stock = stock;
                EditProduct.PrescriptionType = ChoosenPrescriptionType;
                _dataLoader.UpdateProductInDatabase(EditProduct, DesctiptionTextBox.Text);
            }
            else
            {
                // Insert new product
                string productName = ProductNameTextBox.Text;
                int productId = _dataLoader.InsertProduct(productName, ChoosenTypeOfMedication.TypeOfMedicationID, ChoosenManufacturer.ManufacturerID, cost, stock, ChoosenPrescriptionType.PrescriptionTypeID, DesctiptionTextBox.Text);

                if (productId != -1) // Check if insertion was successful
                {
                    NewItem = new Products(productId, ProductNameTextBox.Text, ChoosenTypeOfMedication, ChoosenManufacturer, cost, stock, ChoosenPrescriptionType);
                    _products.Add(NewItem);
                }
            }

            // Update products list and display
            _form1.UpdateProducts(_products);
            CloseOpenForm1();
        }

        private void ProductsPage_Click(object sender, EventArgs e)
        {
            CloseOpenForm1();
        }
        private void CloseOpenForm1()
        {
            _form1.Show();
            _explicitClose = false;
            this.Close();
        }
        private void SellersPage_Click(object sender, EventArgs e)
        {
            _form1.OpenSellersPage();
            _explicitClose = false;

            this.Close();
        }

        private void ReceiptPage_Click(object sender, EventArgs e)
        {
            _form1.OpenReceiptsPage();
            _explicitClose = false;

            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            _form1.OpenReceiptCreationPage();
            _explicitClose = false;

            this.Close();
        }


        private void AddingProductForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_explicitClose)
            {
                Application.Exit();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if(EditProduct != null)
            {
                _dataLoader.DeleteProduct(EditProduct);
                _form1.DeleteProducts(EditProduct);
            }
            CloseOpenForm1();
        }
    }
   
}
