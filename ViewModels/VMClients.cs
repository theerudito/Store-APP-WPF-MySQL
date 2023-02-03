using Dapper;
using GalaSoft.MvvmLight.Command;
using Store.DataBase;
using Store.DB_Context;
using Store.Models;
using System.Collections.ObjectModel;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Store.ViewModels
{

    public class VMClients : BaseViewModel
    {
        MySQLConnection connection = new MySQLConnection();
        private readonly Application_DBContext context = new Application_DBContext();

        #region CONSTRUCTOR
        public VMClients()
        {
            ShowClients();
        }
        #endregion


        #region VARIABLES
        ObservableCollection<MClient> _List_Clients;
        private string _DNI;
        private string _FirstName;
        private string _LastName;
        private string _Direction;
        private string _Phone;
        private string _Email;
        private string _City;
        #endregion


        #region OBJECTS
        public ObservableCollection<MClient> List_Clients { get; set; }
        public string DNI
        {
            get { return _DNI; }
            set { _DNI = value; OnPropertyChanged(nameof(DNI)); }
        }
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; OnPropertyChanged(nameof(FirstName)); }
        }
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; OnPropertyChanged(nameof(LastName)); }
        }
        public string Direction
        {
            get { return _Direction; }
            set { _Direction = value; OnPropertyChanged(nameof(Direction)); }
        }
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; OnPropertyChanged(nameof(Phone)); }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; OnPropertyChanged(nameof(Email)); }
        }
        public string City
        {
            get { return _City; }
            set { _City = value; OnPropertyChanged(nameof(City)); }
        }
        #endregion


        #region METHODS
        public void ShowClients()
        {
            List_Clients = new ObservableCollection<MClient>(context.Clients);

        }
        public async Task SaveClient()
        {
            context.Add(new MClient
            {
                DNI = DNI,
                FirstName = FirstName,
                LastName = LastName,
                Direction = Direction,
                Email = Email,
                Phone = Phone,
                City = City
            });

            if (await context.SaveChangesAsync() > 0)
            {
                MessageBox.Show("Cliente guardado correctamente");
                ResetInput();
                ShowClients();
            }
            else
            {
                MessageBox.Show("Error al guardar el cliente");
            }
            ShowClients();
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
            DNI = "";
            FirstName = "";
            LastName = "";
            Direction = "";
            Phone = "";
            Email = "";
            City = "";
        }
        public void SearchClient()
        {
            MessageBox.Show("Buscar");
        }
        public void ShowClient()
        {
            MessageBox.Show("Mostrar");
        }
        public void ValidationInput()
        {
            if (string.IsNullOrEmpty(DNI))
            {
                MessageBox.Show("El campo DNI es obligatorio");
            }
            else if (string.IsNullOrEmpty(FirstName))
            {
                MessageBox.Show("El campo Nombre es obligatorio");
            }
            else if (string.IsNullOrEmpty(LastName))
            {
                MessageBox.Show("El campo Apellido es obligatorio");
            }
            else if (string.IsNullOrEmpty(Direction))
            {
                MessageBox.Show("El campo Dirección es obligatorio");
            }
            else if (string.IsNullOrEmpty(Phone))
            {
                MessageBox.Show("El campo Teléfono es obligatorio");
            }
            else if (string.IsNullOrEmpty(Email))
            {
                MessageBox.Show("El campo Email es obligatorio");
            }
            else if (string.IsNullOrEmpty(City))
            {
                MessageBox.Show("El campo Ciudad es obligatorio");
            }
            else
            {
                SaveClient();
            }
        }
        #endregion


        #region COMMANDS
        private ICommand _btnCreateNewClientCommand;
        public ICommand btnCreateNewClientCommand
        {
            get
            {
                if (_btnCreateNewClientCommand == null)
                {
                    _btnCreateNewClientCommand = new RelayCommand(async () => await SaveClient());
                }
                return _btnCreateNewClientCommand;
            }
        }
        private ICommand _btnDeleteClientCommand;
        public ICommand btnDeleteClientCommand
        {
            get
            {
                if (_btnDeleteClientCommand == null)
                {
                    _btnDeleteClientCommand = new RelayCommand(DeleteClient);
                }
                return _btnDeleteClientCommand;
            }
        }
        private ICommand _btnUpdateClientCommand;
        public ICommand btnUpdateClientCommand
        {
            get
            {
                if (_btnUpdateClientCommand == null)
                {
                    _btnUpdateClientCommand = new RelayCommand(UpdateClient);
                }
                return _btnUpdateClientCommand;
            }
        }
        #endregion
    }
}


#region CONSTRUCTOR
#endregion

#region VARIABLES
#endregion

#region OBJETOS
#endregion

#region METHODS
#endregion

#region COMMANDS
#endregion

