using GalaSoft.MvvmLight.Command;
using Store.View;
using System.Windows.Controls;
using System.Windows.Input;


namespace Store.ViewModels
{
    public class VMPageHome : BaseViewModel
    {
        private Frame myFrame;

        public VMPageHome()
        {

        }

        public VMPageHome(Frame myFrame)
        {
            this.myFrame = myFrame;
        }

        public void GoFactura()
        {
            myFrame.NavigationService.Navigate(new Cart());
        }

        public void Go_Add_Client()
        {
            myFrame.NavigationService.Navigate(new Add_Client());
        }

        public void Go_Add_Product()
        {
            myFrame.NavigationService.Navigate(new Add_Product());
        }

        public void GoReport()
        {
            myFrame.NavigationService.Navigate(new Reports());
        }

        public void GoConfiguration()
        {
            myFrame.NavigationService.Navigate(new Configuracion());
        }

        public void GoDetailsCart()
        {
            myFrame.NavigationService.Navigate(new DetailsCart());
        }

        public ICommand GoFacturaCommand => new RelayCommand(GoFactura);
        public ICommand GoClientCommand => new RelayCommand(Go_Add_Client);
        public ICommand GoProductCommand => new RelayCommand(Go_Add_Product);
        public ICommand GoReportsCommand => new RelayCommand(GoReport);
        public ICommand GoConfigurationCommand => new RelayCommand(GoConfiguration);
        public ICommand GoDetailCartCommand => new RelayCommand(GoDetailsCart);

    }
}
