using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace FastechMotion.ViewModels
{
    public class AxisStatusViewModel : ViewModelBase
    {
        DispatcherTimer TimerDemo;
        public AxisStatusViewModel() 
        {
            TimerDemo = new DispatcherTimer();
            TimerDemo.Tick += new EventHandler(TimerDemo_Tick);
            TimerDemo.Interval = TimeSpan.FromMilliseconds(100);
            TimerDemo.Start();
        }

        private bool _input1;

        public bool Input1
        {
            get 
            { 
                return _input1; 
            }
            set 
            {
                _input1 = value; 
                OnPropertyChanged(nameof(Input1));
            }
        }

        private bool _input2;

        public bool Input2
        {
            get 
            {
                return _input2;
            }
            set 
            {
                _input2 = value;
                OnPropertyChanged(nameof(Input2));
            }
        }

        private void TimerDemo_Tick(object sender, EventArgs e) 
        {
            Input1 = !Input1;
            Input2 = !Input2;
        }
    }
}
