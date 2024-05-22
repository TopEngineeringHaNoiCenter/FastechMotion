using CommunityToolkit.Mvvm.Input;
using FastechMotion.Commands;
using FastechMotion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace FastechMotion.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        DispatcherTimer TimerDemo;

        public EventHandler UpdateAxisStatusEvent;
        public ViewModelBase SingleMoveCurrentView { get; set; }
        public ViewModelBase PositionStatusCurrentView { get; set; }
        public ViewModelBase JogMoveCurrentView { get; set; }
        public ViewModelBase OriginCurrentView { get; set; }
        public ViewModelBase FunctioCurrentView { get; set; }
        public ViewModelBase AxisStatusCurentView { get; set; }

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
            AxisStatusCurentView = new AxisStatusViewModel();
            (OriginCurrentView as OriginViewModel).OriginEvent += (s, e) =>
            {
                EziMotionDemo.Origin();
            };
            (FunctioCurrentView as FunctionViewModel).ServoOnEvent += (s, e) =>
            {
                EziMotionDemo.ServoOn();
            };
            UpdateAxisStatusEvent += (AxisStatusCurentView as AxisStatusViewModel).UpdateAxisStatusEventHandler;

            TimerDemo = new DispatcherTimer();
            TimerDemo.Tick += new EventHandler(TimerDemo_Tick);
            TimerDemo.Interval = TimeSpan.FromMilliseconds(100);
            TimerDemo.Start();
        }

        private void TimerDemo_Tick(object sender, EventArgs e)
        {
            UpdateAxisStatusEvent?.Invoke(this, EventArgs.Empty);
        }

    }
}
