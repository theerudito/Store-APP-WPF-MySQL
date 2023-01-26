using Store.ViewModels;
using System.Windows;
using System.Windows.Input;


namespace Store.View
{

    public partial class PageHome : Window
    {
        public PageHome()
        {
            InitializeComponent();
            DataContext = new VMPageHome();
        }

        private void MinimixarHome_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizarHome_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Maximized;
            }
        }

        private void CerrarHome_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void pageHome_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Hola");
        }
    }
}
