using Dapper;
using Store.DataBase;
using Store.Models;
using System.Windows;
using System.Windows.Controls;


namespace Store
{
    public partial class MainWindow : Window
    {
        MySQLConnection connection = new MySQLConnection();
        int idClient;

        public MainWindow()
        {
            InitializeComponent();

            ListViewProductMethod();
        }

        public void AddToCart()
        {
            var product = (MProduct)ListViewProduct.SelectedItem;
            var cart = new MCart
            {
                IdClient = idClient,
                IdProduct = product.IdProduct,
                P_Total = product.P_Total
            };
            var db = connection.openConnection();

            db.Execute("INSERT INTO MCart (IdClient, IdProduct, P_Total) " +
                "VALUES ('" + cart.IdClient + "', '" + cart.IdProduct + "', '" + cart.P_Total + "')");
        }

        public void ListViewProductMethod()
        {
            var query = "SELECT * FROM MProduct";
            var db = connection.openConnection();
            var result = db.Query<MProduct>(query);
            connection.closeConnection();
            ListViewProduct.ItemsSource = result;
            ListViewProduct.IsReadOnly = true;
            ListViewProduct.Items.Refresh();


        }

        public void ListViewCartMethod()
        {
            var product = (MProduct)ListViewProduct.SelectedItem;

            ListView lista = new ListView();

            lista.Items.Add(product);
        }

        private void btnCreateProduct_Click(object sender, RoutedEventArgs e)
        {
            //var IdProduct = TextIdProduct.Text;
            var NameProduct = TextNameProduct.Text;
            var CodeProduct = TextCodeProduct.Text;
            var Brand = TextBrand.Text;
            var Description = TextDescription.Text;
            var Quantity = TextQuantity.Text;
            var P_Unitary = TextPriceUnitary.Text;
            var Image_Product = "png";

            var db = connection.openConnection();
            var insertProduct = "INSERT INTO MProduct (NameProduct, CodeProduct, Brand, Description, Quantity, P_Unitary, Image_Product) " +
            "VALUES ('" + NameProduct + "', '" + CodeProduct + "', '" + Brand + "', '" + Description + "', '" + Quantity + "', '" + P_Unitary + "', '" + Image_Product + "')";

            db.Execute(insertProduct);

            connection.closeConnection();
            ListViewProductMethod();

            MessageBox.Show("Create Product Successfully");
        }

        private void btnReadProduct_Click(object sender, RoutedEventArgs e)
        {
            AddToCart();
        }

        private void btnUpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Update Product");

        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Delete Product");

        }

        private void btnCreateClient_Click(object sender, RoutedEventArgs e)
        {
            //var IdClient = TextIdClient.Text;
            var DNI = TextCIClient.Text;
            var FirstName = TextFirstName.Text;
            var LastName = TextLastName.Text;
            var Direction = TextDirection.Text;
            var Phone = TextPhone.Text;
            var Email = TextEmail.Text;
            var City = TextCity.Text;


            var insertClient = "INSERT INTO MClient (DNI, FirstName, LastName, Direction, Phone, Email, City) " +
            "VALUES ('" + DNI + "', '" + FirstName + "', '" + LastName + "', '" + Direction + "', '" + Phone + "', '" + Email + "', '" + City + "')";

            var db = connection.openConnection();

            db.Execute(insertClient);

            connection.closeConnection();

            MessageBox.Show("Create Client Successfully");

        }

        private void btnReadClient_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Read Client");
        }

        private void btnUpdateClient_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Update Client");
        }

        private void btnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Delete Client");
        }

        private void btnPagar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pagar");
        }

        private void btnSearchCI_Click(object sender, RoutedEventArgs e)
        {
            var db = connection.openConnection();

            var query = "SELECT * FROM MClient WHERE DNI = '" + TextCI.Text + "'";

            var result = db.Query<MClient>(query);

            if (result != null)
            {
                foreach (var item in result)
                {
                    idClient = item.IdClient;
                    TextCI.Text = item.DNI;
                    Nombre.Text = item.FirstName;
                    Apellido.Text = item.LastName;
                    Direction.Text = item.Direction;
                    Phone.Text = item.Phone;
                    Email.Text = item.Email;
                }
            }
            else
            {
                MessageBox.Show("No se encontro el cliente");
            }

        }

        private void btnSearchProduct_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Search Product");
        }




    }
}
