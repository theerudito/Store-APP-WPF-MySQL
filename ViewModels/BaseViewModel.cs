using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Store.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        private string greeting;
        public string Greeting
        {
            get { return greeting; }
            set
            {
                greeting = value;
                NotifyPropertyChanged("Greeting");
            }
        }
    }
}