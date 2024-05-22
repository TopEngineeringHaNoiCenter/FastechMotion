using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FastechMotion.ViewModels
{
    public class FunctionViewModel : ViewModelBase
    {
        public EventHandler ServoOnEvent;
        public ICommand ServoOnCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    ServoOnEvent?.Invoke(this, EventArgs.Empty);
                }); 
            }
        }
    }
}
