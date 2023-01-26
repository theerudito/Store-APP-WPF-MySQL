
using GalaSoft.MvvmLight.Command;
using Store.View;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Store.ViewModels
{
    public class VMPageHome : BaseViewModel
    {
        public VMPageHome()
        {

        }

        public async Task GoFactura()
        {
            Cart cart = new Cart();
            cart.Show();
        }

        public async Task GoClient()
        {
            MessageBox.Show("Client");
        }

        public async Task GoProduct()
        {
            MessageBox.Show("Client");
        }

        public async Task GoReport()
        {
            MessageBox.Show("report");
        }

        public async Task GoConfiguration()
        {
            MessageBox.Show("configuration");
        }


        public ICommand GoFacturaCommand => new RelayCommand(async () => await GoFactura());
        public ICommand GoClientCommand => new RelayCommand(async () => await GoClient());
        public ICommand GoProductCommand => new RelayCommand(async () => await GoProduct());
        public ICommand GoReportsCommand => new RelayCommand(async () => await GoReport());
        public ICommand GoConfigurationCommand => new RelayCommand(async () => await GoConfiguration());

    }
}
