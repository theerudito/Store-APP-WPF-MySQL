using Store.ViewModels;
using System.Windows.Controls;

namespace Store.View
{
    public partial class Configuracion : Page
    {
        public Configuracion()
        {
            InitializeComponent();
            DataContext = new VMConfiguration();
        }
    }
}
