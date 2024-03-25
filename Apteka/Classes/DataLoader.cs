using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apteka
{
    public class DataLoader
    {
        private string _productsFilePath;
        private string _manufacturersFilePath;
        private string _typeOfMedication;
        private string _prescriptionTypesFilePath;
        private string _sellersFilePath;
        private string _receiptsFilePath;
        private string _receiptsDataFilePath;

        private string _connectionString;

        DateTime parsedDate;
        string format = "yyyy-MM-dd";
        public DataLoader(string connectionString, string productsFilePath, string manufacturersFilePath, string prescriptionTypesFilePath, string typeOfMedicationTypesFilePath, string sellersFilePath, string receiptsFilePath, string receiptsDataFilePath)
        {
            _connectionString = connectionString;
            _productsFilePath = productsFilePath;
            _manufacturersFilePath = manufacturersFilePath;
            _prescriptionTypesFilePath = prescriptionTypesFilePath;
            _typeOfMedication = typeOfMedicationTypesFilePath;
            _sellersFilePath = sellersFilePath;
            _receiptsFilePath = receiptsFilePath;
            _receiptsDataFilePath = receiptsDataFilePath;
        }
        #region LoadData
        public List<Receipt> LoadReceiptsFromDatabase(List<Seller> sellers, List<ReceiptsDetail> allReceiptDetails)
        {
            List<Receipt> receipts = new List<Receipt>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT ID_Receipt, Seller_ID, Date_Time, Total_Amount FROM receipts";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int receiptID = reader.GetInt32(0);
                        int sellerID = reader.GetInt32(1);
                        DateTime dateTime = reader.GetDateTime(2);
                        decimal totalAmount = reader.GetDecimal(3);

                        Seller seller = sellers.FirstOrDefault(s => s.SellerID == sellerID);
                        ReceiptsDetail receiptDetail = allReceiptDetails.FirstOrDefault(rd => rd.ReceiptID == receiptID);

                        if (seller != null && receiptDetail != null)
                        {
                            Receipt receipt = new Receipt(receiptID, seller, dateTime, totalAmount, receiptDetail);
                            receipts.Add(receipt);
                        }
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading receipts from the database: {ex.Message}");
                }
            }

            PrintReceipts(receipts); // Assuming this is a method to print receipts for debugging purposes
            return receipts;
        }

        public void PrintReceipts(List<Receipt> receipts)
        {
            foreach (var receipt in receipts)
            {
                Console.WriteLine($"ReceiptID: {receipt.ReceiptID}");
                Console.WriteLine($"SellerID: {receipt.Seller.SellerID}");
                Console.WriteLine($"DateTime: {receipt.DateTime}");
                Console.WriteLine($"TotalAmount: {receipt.TotalCost}");

                Console.WriteLine("ReceiptDetails count :" + receipt.ReceiptDetails.ProductQuantities.Count);

                if (receipt.ReceiptDetails != null)
                {
                    Console.WriteLine("ReceiptDetails:");
                    foreach (var productQuantity in receipt.ReceiptDetails.ProductQuantities)
                    {
                        Console.WriteLine($"  ProductID: {productQuantity.Key.ProductID}");
                        Console.WriteLine($"  Quantity: {productQuantity.Value}");
                    }
                }

                Console.WriteLine();
            }
        }
        public List<ReceiptsDetail> LoadReceiptDetailsFromDatabase(List<Products> products)
        {
            List<ReceiptsDetail> receiptDetailsList = new List<ReceiptsDetail>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Receipt_ID, Product_ID, Quantity FROM receiptDetails";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int receiptID = reader.GetInt32(0);
                        int productID = reader.GetInt32(1);
                        int quantity = reader.GetInt32(2);

                        Products product = products.FirstOrDefault(p => p.ProductID == productID);
                        if (product != null)
                        {
                            ReceiptsDetail detail = receiptDetailsList.FirstOrDefault(r => r.ReceiptID == receiptID);
                            if (detail == null)
                            {
                                detail = new ReceiptsDetail
                                {
                                    ReceiptID = receiptID,
                                    ProductQuantities = new Dictionary<Products, int>()
                                };
                                receiptDetailsList.Add(detail);
                            }

                            if (detail.ProductQuantities.ContainsKey(product))
                            {
                                // If the product already exists in the dictionary, update its quantity
                                detail.ProductQuantities[product] += quantity;
                            }
                            else
                            {
                                // Otherwise, add the product to the dictionary with its quantity
                                detail.ProductQuantities[product] = quantity;
                            }
                        }
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading receipt details from the database: {ex.Message}");
                }
            }

            return receiptDetailsList;
        }

        public List<Products> LoadProductsFromDatabase(List<Manufacturer> manufacturers, List<PrescriptionType> prescriptionTypes, List<TypeOfMedication> typeOfMedications)
        {
            List<Products> products = new List<Products>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT ID_Product, Name, Type_of_Medication_ID, Manufacturer_ID, Price, Stock, Type_ID FROM products";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        int typeMedicationID = reader.GetInt32(2);
                        int manufacturerID = reader.GetInt32(3);
                        decimal price = reader.GetDecimal(4);
                        int stock = reader.GetInt32(5);
                        int typeID = reader.GetInt32(6);

                        Manufacturer manufacturer = manufacturers.FirstOrDefault(m => m.ManufacturerID == manufacturerID);
                        PrescriptionType prescriptionType = prescriptionTypes.FirstOrDefault(t => t.PrescriptionTypeID == typeID);
                        TypeOfMedication typeOfMedication = typeOfMedications.FirstOrDefault(s => s.TypeOfMedicationID == typeMedicationID);

                        Products product = new Products(id, name, typeOfMedication, manufacturer, price, stock, prescriptionType);
                        products.Add(product);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading products from the database: {ex.Message}");
                }
            }

            return products;
        }

        public List<Manufacturer> LoadManufacturersFromDatabase()
        {
            List<Manufacturer> manufacturers = new List<Manufacturer>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT ID_Manufacturer, Manufacturer_Name FROM manufacturer";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);

                        Manufacturer manufacturer = new Manufacturer(id, name);
                        manufacturers.Add(manufacturer);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading manufacturers from the database: {ex.Message}");
                }
            }

            return manufacturers;
        }


        public List<PrescriptionType> LoadPrescriptionTypesFromDatabase()
        {
            List<PrescriptionType> prescriptionTypes = new List<PrescriptionType>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT ID_Type, Type_Name FROM types"; // Changed 'Name' to 'Type_Name'

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);

                        PrescriptionType prescriptionType = new PrescriptionType(id, name);
                        prescriptionTypes.Add(prescriptionType);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading prescription types from the database: {ex.Message}");
                }
            }

            return prescriptionTypes;
        }
        public List<TypeOfMedication> LoadTypesOfMedicationFromDatabase()
        {
            List<TypeOfMedication> typesOfMedication = new List<TypeOfMedication>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT ID_Type_of_Medication, Name_of_Medication FROM typeOfMedication";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);

                        TypeOfMedication typeOfMedication = new TypeOfMedication(id, name);
                        typesOfMedication.Add(typeOfMedication);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading types of medication from the database: {ex.Message}");
                }
            }

            return typesOfMedication;
        }
        public List<Seller> LoadSellersFromDatabase()
        {
            List<Seller> sellers = new List<Seller>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT ID_Seller, First_Name, Last_Name, Position FROM sellers";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string firstName = reader.GetString(1);
                        string lastName = reader.GetString(2);
                        string position = reader.GetString(3);

                        Seller seller = new Seller(id, firstName, lastName, position);
                        sellers.Add(seller);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading sellers from the database: {ex.Message}");
                }
            }

            return sellers;
        }
        #endregion
        #region Insert

        public string LoadDescription(int productId)
        {
            string query = "SELECT Description FROM products WHERE ID_Product = @ProductId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductId", productId);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return result.ToString();
                    }
                    else
                    {
                        Console.WriteLine("Error: Description not found for the product ID."); // Log the error
                        return string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading description from the database: {ex.Message}");
                    return string.Empty; // Return empty string to indicate error
                }
            }
        }

        public int InsertProduct(string productName, int typeID, int manufacturerID, decimal price, int stock, int prescriptionTypeID, string description)
        {
            string query = "INSERT INTO products (Name, Type_ID, Manufacturer_ID, Price, Stock, Type_of_Medication_ID, Description) " +
                           "VALUES (@Name, @TypeID, @ManufacturerID, @Price, @Stock, @PrescriptionTypeID, @Description);";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", productName);
                command.Parameters.AddWithValue("@TypeID", typeID);
                command.Parameters.AddWithValue("@ManufacturerID", manufacturerID);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@Stock", stock);
                command.Parameters.AddWithValue("@PrescriptionTypeID", prescriptionTypeID);
                command.Parameters.AddWithValue("@Description", description);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery(); // Execute the INSERT statement
                    Console.WriteLine("Product inserted successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting product into the database: {ex.Message}");
                    return -1; // Return -1 to indicate error
                }
            }
            int lastInsertedId = GetLastInsertedProductId();
            return lastInsertedId;
        }
        public int GetLastInsertedProductId()
        {
            string query = "SELECT IDENT_CURRENT('products') AS LastInsertedId;";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        int lastInsertedId = Convert.ToInt32(result);
                        return lastInsertedId;
                    }
                    else
                    {
                        Console.WriteLine("Error: IDENT_CURRENT() returned DBNull or null."); // Log the error
                        return -1; // Return -1 to indicate error
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving last inserted ID: {ex.Message}"); // Log the exception
                    return -1; // Return -1 to indicate error
                }
            }
        }

        public int InsertManufacturer(string manufacturerName)
        {
            string query = "INSERT INTO manufacturer (Manufacturer_Name) VALUES (@ManufacturerName);" +
                "SELECT IDENT_CURRENT('manufacturer') AS LastInsertedId;";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ManufacturerName", manufacturerName);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery(); // Execute the INSERT statement

                    // Retrieve the last inserted ID using IDENT_CURRENT()
                    command.CommandText = "SELECT IDENT_CURRENT('manufacturer') AS LastInsertedId;";
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        int manufacturerId = Convert.ToInt32(result);
                        return manufacturerId;
                    }
                    else
                    {
                        Console.WriteLine("Error: IDENT_CURRENT() returned DBNull or null."); // Log the error
                        return -1; // Return -1 to indicate error
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting manufacturer into the database: {ex.Message}");
                    return -1; // Return -1 to indicate error
                }
            }
        }

        public int InsertPrescriptionType(string prescriptionTypeName)
        {
            string query = "INSERT INTO prescriptionType (Prescription_Type_Name) VALUES (@PrescriptionTypeName);" +
                    "SELECT IDENT_CURRENT('prescriptionType') AS LastInsertedId;";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PrescriptionTypeName", prescriptionTypeName);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery(); // Execute the INSERT statement

                    // Retrieve the last inserted ID using IDENT_CURRENT()
                    command.CommandText = "SELECT IDENT_CURRENT('prescriptionType') AS LastInsertedId;";
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        int typeId = Convert.ToInt32(result);
                        return typeId;
                    }
                    else
                    {
                        Console.WriteLine("Error: IDENT_CURRENT() returned DBNull or null."); // Log the error
                        return -1; // Return -1 to indicate error
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting prescription type into the database: {ex.Message}");
                    return -1; // Return -1 to indicate error
                }
            }
        }

        public int InsertTypeOfMedication(string typeOfMedicationName)
        {
            string query = "INSERT INTO typeOfMedication (Name_of_Medication) VALUES (@NameOfMedication);" +
                           "SELECT IDENT_CURRENT('typeOfMedication') AS LastInsertedId;";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NameOfMedication", typeOfMedicationName);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery(); // Execute the INSERT statement

                    // Retrieve the last inserted ID using IDENT_CURRENT()
                    command.CommandText = "SELECT IDENT_CURRENT('typeOfMedication') AS LastInsertedId;";
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        int typeId = Convert.ToInt32(result);
                        return typeId;
                    }
                    else
                    {
                        Console.WriteLine("Error: IDENT_CURRENT() returned DBNull or null."); // Log the error
                        return -1; // Return -1 to indicate error
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting type of medication into the database: {ex.Message}");
                    return -1; // Return -1 to indicate error
                }
            }
        }
        public int InsertReceipt(int sellerID, DateTime dateTime, decimal totalAmount)
        {
            string query = "INSERT INTO receipts (Seller_ID, Date_Time, Total_Amount) " +
                           "VALUES (@SellerID, @DateTime, @TotalAmount);" +
                           "SELECT IDENT_CURRENT('receipts') AS LastInsertedId;";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SellerID", sellerID);
                command.Parameters.AddWithValue("@DateTime", dateTime);
                command.Parameters.AddWithValue("@TotalAmount", totalAmount);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery(); // Execute the INSERT statement

                    // Retrieve the last inserted ID using IDENT_CURRENT()
                    command.CommandText = "SELECT IDENT_CURRENT('receipts') AS LastInsertedId;";
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        int lastInsertedId = Convert.ToInt32(result);
                        return lastInsertedId;
                    }
                    else
                    {
                        Console.WriteLine("Error: IDENT_CURRENT() returned DBNull or null."); // Log the error
                        return -1; // Return -1 to indicate error
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting receipt into the database: {ex.Message}");
                    return -1; // Return -1 to indicate error
                }
            }
        }

        public void InsertReceiptDetail(int receiptID, int productID, int quantity)
        {
            string query = "INSERT INTO receiptDetails (Receipt_ID, Product_ID, Quantity) " +
                           "VALUES (@ReceiptID, @ProductID, @Quantity)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ReceiptID", receiptID);
                command.Parameters.AddWithValue("@ProductID", productID);
                command.Parameters.AddWithValue("@Quantity", quantity);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery(); // Execute the INSERT statement
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting receipt detail into the database: {ex.Message}");
                }
            }
        }

        #endregion
        #region Delete 
        public void DeleteProduct(Products product)
        {
            // Remove the product from the class collection

            // Delete the product from the database
            string query = "DELETE FROM products WHERE ID_Product = @ProductID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", product.ProductID);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Successfully deleted from the database
                        Console.WriteLine($"Product with ID {product.ProductID} deleted from the database.");
                    }
                    else
                    {
                        // Handle the case where deletion from the database was unsuccessful
                        Console.WriteLine($"Product with ID {product.ProductID} not found in the database.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting product from the database: {ex.Message}");
                }
            }
        }
        #endregion
        #region Updates
        public void UpdateProductInDatabase(Products product, string description)
        {
            string query = "UPDATE products SET Name = @Name, Type_ID = @TypeID, Manufacturer_ID = @ManufacturerID, " +
                           "Price = @Price, Stock = @Stock, Type_of_Medication_ID = @PrescriptionTypeID, Description = @Description WHERE ID_Product = @ProductId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@TypeID", product.TypeOfmedication.TypeOfMedicationID); // Assuming TypeOfmedication is an object with an ID property
                command.Parameters.AddWithValue("@ManufacturerID", product.Manufacturer.ManufacturerID); // Assuming Manufacturer is an object with an ID property
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Stock", product.Stock);
                command.Parameters.AddWithValue("@PrescriptionTypeID", product.PrescriptionType.PrescriptionTypeID); // Assuming PrescriptionType is an object with an ID property
                command.Parameters.AddWithValue("@ProductId", product.ProductID);
                command.Parameters.AddWithValue("@Description", description);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Product updated successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating product in the database: {ex.Message}");
                }
            }
        }

        public void UpdateBoughtProductsDatabase(Receipt receipt)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                foreach (var productKey in receipt.ReceiptDetails.ProductQuantities.Keys)
                {
                    int productId = productKey.ProductID;
                    int quantity = receipt.ReceiptDetails.ProductQuantities[productKey];

                    string query = "UPDATE products SET Stock = Stock - @Quantity WHERE ID_Product = @ProductId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Quantity", quantity);
                        command.Parameters.AddWithValue("@ProductId", productId);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
        public void UpdateDescription(int productId, string newDescription)
        {
            string query = "UPDATE ProductDescriptions SET Description = @NewDescription WHERE ProductID = @ProductId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductId", productId);
                command.Parameters.AddWithValue("@NewDescription", newDescription);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Description updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No description updated. Product ID not found.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating description in the database: {ex.Message}");
                }
            }
        }

        #endregion


    }

}
