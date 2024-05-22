using FastechMotion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FastechMotion.Commands
{
    public class ServoOnCommand :ICommand
    {
        private MainViewModel mainViewModel;
        public ServoOnCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (mainViewModel.EziMotionDemo == null)
            {
                mainViewModel.EziMotionDemo.ServoOn();
            }
        }
    }
}
