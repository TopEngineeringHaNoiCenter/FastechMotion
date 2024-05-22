using FASTECH;
using FastechMotion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FastechMotion.Commands
{
    public class ConnectCommand : ICommand
    {
        private MainViewModel mainViewModel;
        public ConnectCommand(MainViewModel mainViewModel)
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
            bool result = EziMOTIONPlusELib.FAS_ConnectTCP(IPAddress.Parse(mainViewModel.StrIP), mainViewModel.BoardId);
            if (result == false)
            {
                MessageBox.Show($"Connect to {mainViewModel.StrIP} failed!");
                return;
            } 
            MessageBox.Show($"Connect to {mainViewModel.StrIP} successed!");
        }
    }
}
