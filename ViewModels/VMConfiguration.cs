using GalaSoft.MvvmLight.Command;
using Store.DB_Context;
using Store.Models;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Store.ViewModels
{
    public class VMConfiguration : BaseViewModel
    {
        private readonly Application_DBContext context = new Application_DBContext();

        #region CONSTRUCTOR
        public VMConfiguration()
        {
            ObtenerDataCompany();
        }
        #endregion

        #region VARIABLES
        private string _nameCompany;
        private string _nameOwner;
        private string _direction;
        private string _email;
        private string _dni;
        private string _phone;
        private string _numDocument;
        private string _serie1;
        private string _serie2;
        private string _document;
        private string _dataBase;
        private string _iva;
        private string _current;
        #endregion

        #region OBJETOS
        public string NameCompany
        {
            get { return _nameCompany; }
            set { _nameCompany = value; OnPropertyChanged(nameof(NameCompany)); }
        }
        public string NameOwner
        {
            get { return _nameOwner; }
            set { _nameOwner = value; OnPropertyChanged(nameof(NameOwner)); }
        }
        public string Direction
        {
            get { return _direction; }
            set { _direction = value; OnPropertyChanged(nameof(Direction)); }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }
        public string DNI
        {
            get { return _dni; }
            set { _dni = value; OnPropertyChanged(nameof(DNI)); }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; OnPropertyChanged(nameof(Phone)); }
        }
        public string NumDocument
        {
            get { return _numDocument; }
            set { _numDocument = value; OnPropertyChanged(nameof(NumDocument)); }
        }
        public string Serie1
        {
            get { return _serie1; }
            set { _serie1 = value; OnPropertyChanged(nameof(Serie1)); }
        }
        public string Serie2
        {
            get { return _serie2; }
            set { _serie2 = value; OnPropertyChanged(nameof(Serie2)); }
        }
        public string Document
        {
            get { return _document; }
            set { _document = value; OnPropertyChanged(nameof(Document)); }
        }
        public string DataBase
        {
            get { return _dataBase; }
            set { _dataBase = value; OnPropertyChanged(nameof(DataBase)); }
        }
        public string Iva
        {
            get { return _iva; }
            set { _iva = value; OnPropertyChanged(nameof(Iva)); }
        }
        public string Current
        {
            get { return _current; }
            set { _current = value; OnPropertyChanged(nameof(Current)); }
        }
        #endregion

        #region METHODS
        public async Task ObtenerDataCompany()
        {
            try
            {
                var id = 1721457495;
                var data = await context.Company.FindAsync(id);
                if (data != null)
                {
                    NameCompany = data.NameCompany;
                    NameOwner = data.NameOwner;
                    Direction = data.Direction;
                    Email = data.Email;
                    DNI = data.DNI;
                    Phone = data.Phone;
                    NumDocument = data.NumDocument;
                    Serie1 = data.Serie1;
                    Serie2 = data.Serie2;
                    Document = data.Document;
                    DataBase = data.DataBase;
                    Iva = data.Iva;
                    Current = data.Current;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task SaveDataCompany()
        {
            try
            {
                context.Add(new MCompany
                {
                    NameCompany = NameCompany,
                    NameOwner = NameOwner,
                    Direction = Direction,
                    Email = Email,
                    DNI = DNI,
                    Phone = Phone,
                    NumDocument = NumDocument,
                    Serie1 = Serie1,
                    Serie2 = Serie2,
                    Document = Document,
                    DataBase = DataBase,
                    Iva = Iva,
                    Current = Current
                });

                if (await context.SaveChangesAsync() > 0)
                {
                    MessageBox.Show("Datos guardados correctamente");
                }
                else
                {
                    MessageBox.Show("no se puedo guardar los datos");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region COMMANDS
        private ICommand _btnSaveCompanyCommand;
        public ICommand btnSaveCompanyCommand
        {
            get
            {
                if (_btnSaveCompanyCommand == null)
                {
                    _btnSaveCompanyCommand = new RelayCommand(async () => await SaveDataCompany());
                }
                return _btnSaveCompanyCommand;
            }
        }
        #endregion
    }
}
