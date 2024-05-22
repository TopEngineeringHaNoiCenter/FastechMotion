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
        public AxisStatusViewModel() 
        {
            
        }
        private bool _isErroAll;

        public bool IsErrorAll
        {
            get 
            {
                return _isErroAll; 
            }
            set 
            { 
                _isErroAll = value;
                OnPropertyChanged(nameof(IsErrorAll));
            }
        }

        private bool _isHWPositiveLimit;

        public bool IsHWPositiveLimit
        {
            get { return _isHWPositiveLimit; }
            set { _isHWPositiveLimit = value; OnPropertyChanged(nameof(IsHWPositiveLimit)); }
        }

        private bool _isHWNegativeLimit;

        public bool IsHWNegativeLimit
        {
            get { return _isHWNegativeLimit; }
            set { _isHWNegativeLimit = value; OnPropertyChanged(nameof(IsHWNegativeLimit)); }
        }

        private bool _input1;

        public bool Input1
        {
            get { return _input1; }
            set { _input1 = value; OnPropertyChanged(nameof(Input1)); }
        }

        private bool _input2;

        public bool Input2
        {
            get { return _input2; }
            set { _input2 = value; OnPropertyChanged(nameof(Input2)); }
        }

        public void UpdateAxisStatusEventHandler(object sender, EventArgs e)
        {
            Input1 = !Input1;
            Input2 = !Input2;

            if ((sender as MainViewModel).EziMotionDemo == null) return;
            IsErrorAll =  (sender as MainViewModel).EziMotionDemo.IsErrorAll;
            IsHWPositiveLimit =  (sender as MainViewModel).EziMotionDemo.IsHWPositiveLimit;
            IsHWNegativeLimit =  (sender as MainViewModel).EziMotionDemo.IsHWNegativeLimit;
        }
    }
}
