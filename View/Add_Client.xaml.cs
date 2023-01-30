using Store.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Store.View
{

    public partial class Add_Client : Page
    {
        public Add_Client()
        {
            InitializeComponent();
            DataContext = new VMClients();
        }
    }
}
