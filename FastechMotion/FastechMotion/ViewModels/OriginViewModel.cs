using CommunityToolkit.Mvvm.Input;
using FastechMotion.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FastechMotion.ViewModels
{
    public class OriginViewModel : ViewModelBase
    {
        public EventHandler OriginEvent;
        public ICommand OriginCommand
        {
            get
            {
                return new CommunityToolkit.Mvvm.Input.RelayCommand(() =>
                {
                    OriginEvent?.Invoke(this, EventArgs.Empty);
                });
            }
        }
        public OriginViewModel() 
        {
        }
    }
}
