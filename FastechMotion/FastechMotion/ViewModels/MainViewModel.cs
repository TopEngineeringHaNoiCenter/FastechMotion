using FASTECH;
using FastechMotion.Commands;
using FastechMotion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FastechMotion.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase SingleMoveCurrentView { get; set; } 
        public ViewModelBase PositionStatusCurrentView { get; set; } 
        public ViewModelBase JogMoveCurrentView { get; set; }
        public ViewModelBase OriginCurrentView { get; set; } 
        public ViewModelBase FunctioCurrentView { get; set; } 

        private IP _strIP;
        public IP StrIP
        {
            get { return _strIP; }
            set { _strIP = value; OnPropertyChanged(nameof(StrIP)); }
        }
        private int _boardId;
        public int BoardId
        {
            get { return _boardId; }
            set { _boardId = value; OnPropertyChanged(nameof(BoardId)); }   
        }
        private bool _isConnect;
        public bool IsConnect
        {
            get { return _isConnect; }
            set { _isConnect = value; OnPropertyChanged(nameof(IsConnect)); }
        }
        public ICommand ConnectCommand { get; set; }
        public MainViewModel()
        {
            SingleMoveCurrentView = new SingleMoveViewModel(this);
            PositionStatusCurrentView = new PositionStatusViewModel();
            JogMoveCurrentView = new JogMoveViewModel();
            OriginCurrentView = new OriginViewModel();
            FunctioCurrentView = new FunctionViewModel();

            StrIP.Address = "192.168.0.8";
            BoardId = 8;
            ConnectCommand = new ConnectCommand(this);
            EziMOTIONPlusELib.FAS_ServoEnable(BoardId, 1);

            IsConnect = false;
        }
    }
}
