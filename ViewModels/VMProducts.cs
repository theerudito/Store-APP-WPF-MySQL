using Dapper;
using GalaSoft.MvvmLight.Command;
using Store.DataBase;
using Store.DB_Context;
using Store.Models;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Store.ViewModels
{
    public class VMProducts : BaseViewModel
    {
        MySQLConnection connection = new MySQLConnection();
        private readonly Application_DBContext context = new Application_DBContext();


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
        private string _Image_Product = "png";
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
        public async Task ShowProducts()
        {
            try
            {
                List_Products = new ObservableCollection<MProduct>(context.Products);
                OnPropertyChanged(nameof(List_Products));
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public async Task SaveProduct()
        {
            Application_DBContext context = new Application_DBContext();

            context.Add(new MProduct
            {
                NameProduct = NameProduct,
                CodeProduct = CodeProduct,
                Brand = Brand,
                Description = Description,
                Quantity = Quantity,
                P_Unitary = P_Unitary,
                P_Total = P_Total,
                Image_Product = Image_Product
            });

            if (await context.SaveChangesAsync() > 0)
            {

                MessageBox.Show("Producto guardado correctamente");
                ResetInput();
                await ShowProducts();
            }
            else
            {
                MessageBox.Show("Error al guardar el producto");
            }
            await ShowProducts();
        }
        public void DeleteClient()
        {
            // eliminar el cliente

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
                    _btnCreateNewProductCommand = new RelayCommand(async () => await SaveProduct());
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
