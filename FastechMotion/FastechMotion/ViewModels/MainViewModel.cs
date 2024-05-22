using CommunityToolkit.Mvvm.Input;
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

        public EziMotionPlusE EziMotionDemo { get; set; }

        private string _strIP;
        public string StrIP
        {
            get { return _strIP; }
            set { _strIP = value; OnPropertyChanged(nameof(StrIP)); }
        }
        private int _boardId = 8;
        public int BoardId
        {
            get { return _boardId; }
            set { _boardId = value; OnPropertyChanged(nameof(BoardId)); }   
        }
        public ICommand ConnectCommand
        {
            get
            {
                return new CommunityToolkit.Mvvm.Input.RelayCommand(() =>
                {
                    EziMotionDemo = new EziMotionPlusE("Demo", StrIP);
                    EziMotionDemo.Connect();
                });
            }
        }
        public MainViewModel()
        {
            SingleMoveCurrentView = new SingleMoveViewModel();
            PositionStatusCurrentView = new PositionStatusViewModel();
            JogMoveCurrentView = new JogMoveViewModel();
            OriginCurrentView = new OriginViewModel();
            FunctioCurrentView = new FunctionViewModel();

            (OriginCurrentView as OriginViewModel).OriginEvent += (s,e)=>
            {
                EziMotionDemo.Origin();
            };
            (FunctioCurrentView as FunctionViewModel).ServoOnEvent += (s, e) =>
            {
                EziMotionDemo.ServoOn();
            };
        }
    }
}
