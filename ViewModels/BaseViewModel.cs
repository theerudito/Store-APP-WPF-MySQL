using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Store.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void OnPropertyChanging([CallerMemberName] string propertyName = "")
        {
            PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }

    }
}