using Store.ViewModels;
using System.Windows.Controls;

namespace Store.View
{
    public partial class Add_Product : Page
    {
        public Add_Product()
        {
            InitializeComponent();
            DataContext = new VMProducts();
        }
    }
}
