using Dapper;
using GalaSoft.MvvmLight.Command;
using Store.DataBase;
using Store.Models;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using System.Windows.Input;

namespace Store.ViewModels
{
    public class VMProducts
    {
        MySQLConnection connection = new MySQLConnection();


        #region CONSTRUCTOR
        public VMProducts()
        {
            ShowProducts();
        }
        #endregion

        #region VARIABLES
        private ObservableCollection<MProduct> _List_Products;
        private string _NameProduct;
        private string _CodeProduct;
        private string _Brand;
        private string _Description;
        private int _Quantity;
        private float _P_Unitary;
        private float _P_Total;
        private string _Image_Product;
        #endregion

        #region OBJETOS
        public ObservableCollection<MProduct> List_Products { get; set; }
        public string NameProduct
        {
            get { return _NameProduct; }
            set { _NameProduct = value; }
        }
        public string CodeProduct
        {
            get { return _CodeProduct; }
            set { _CodeProduct = value; }
        }
        public string Brand
        {
            get { return _Brand; }
            set { _Brand = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        public int Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        public float P_Unitary
        {
            get { return _P_Unitary; }
            set { _P_Unitary = value; }
        }
        public float P_Total
        {
            get { return _P_Total; }
            set { _P_Total = value; }
        }
        public string Image_Product
        {
            get { return _Image_Product; }
            set { _Image_Product = value; }
        }
        #endregion

        #region METHODS
        public void ShowProducts()
        {
            var db = connection.openConnection();
            var getAllProducts = "SELECT * FROM MProduct";
            var result = db.Query<MProduct>(getAllProducts);
            List_Products = new ObservableCollection<MProduct>(result);

        }
        public void SaveProduct()
        {
            var db = connection.openConnection();

            var addProduct = "INSERT INTO MProduct (NameProduct, CodeProduct, Brand, Description, Quantity, P_Unitary, Image_Product) " +
            "VALUES ('" + NameProduct + "', '" + CodeProduct + "', '" + Brand + "', '" + Description + "', '" + Quantity + "', '" + P_Unitary + "', '" + Image_Product + "')";

            db.Execute(addProduct);

            if (addProduct != null)
            {
                ResetInput();
                ShowProducts();
                MessageBox.Show("producto agregado correctamente");
            }
            else
            {
                MessageBox.Show("Error al agregar producto");
            }
        }
        public void DeleteClient()
        {
            MessageBox.Show("Eliminar");
        }
        public void UpdateClient()
        {
            MessageBox.Show("Actualizar");
        }
        public void ResetInput()
        {
            CodeProduct = "";
            NameProduct = "";
            Brand = "";
            Description = "";
            Quantity = 0;
            P_Unitary = 0;
            P_Total = 0;
            Image_Product = "";
        }
        public void SearchProduct()
        {
            MessageBox.Show("Buscar");
        }
        public void ShowProduct()
        {
            MessageBox.Show("Mostrar");
        }
        public void ValidationInput()
        {
            if (string.IsNullOrEmpty(CodeProduct))
            {
                MessageBox.Show("El campo Código de producto es obligatorio");
            }
            else if (string.IsNullOrEmpty(NameProduct))
            {
                MessageBox.Show("El campo Nombre de producto es obligatorio");
            }
            else if (string.IsNullOrEmpty(Brand))
            {
                MessageBox.Show("El campo Marca es obligatorio");
            }
            else if (string.IsNullOrEmpty(Description))
            {
                MessageBox.Show("El campo Descripción es obligatorio");
            }
            else if (Quantity == 0)
            {
                MessageBox.Show("El campo Cantidad es obligatorio");
            }
            else if (P_Unitary == 0)
            {
                MessageBox.Show("El campo Precio unitario es obligatorio");
            }
            else if (P_Total == 0)
            {
                MessageBox.Show("El campo Precio total es obligatorio");
            }
            else if (string.IsNullOrEmpty(Image_Product))
            {
                MessageBox.Show("El campo Imagen de producto es obligatorio");
            }
            else
            {
                SaveProduct();
            }

        }
        #endregion

        #region COMMANDS
        private ICommand _btnCreateNewProductCommand;
        private ICommand _btnDeleteProductCommand;
        private ICommand _btnUpdateProductCommand;
        public ICommand btnCreateNewProductCommand
        {
            get
            {
                if (_btnCreateNewProductCommand == null)
                {
                    _btnCreateNewProductCommand = new RelayCommand(SaveProduct);
                }
                return _btnCreateNewProductCommand;
            }
        }
        public ICommand btnDeleteProductCommand
        {
            get
            {
                if (_btnDeleteProductCommand == null)
                {
                    _btnDeleteProductCommand = new RelayCommand(DeleteClient);
                }
                return _btnDeleteProductCommand;
            }
        }
        public ICommand btnUpdateProductCommand
        {
            get
            {
                if (_btnUpdateProductCommand == null)
                {
                    _btnUpdateProductCommand = new RelayCommand(UpdateClient);
                }
                return _btnUpdateProductCommand;
            }
        }
        #endregion
    }
}
