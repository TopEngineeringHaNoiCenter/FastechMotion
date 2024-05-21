using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastechMotion.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase SingleMoveCurrentView { get; set; } = new SingleMoveViewModel();
        public ViewModelBase PositionStatusCurrentView { get; set; } = new PositionStatusViewModel();
        public ViewModelBase JogMoveViewModel { get; set; } = new JogMoveViewModel();
        public ViewModelBase OriginViewModel { get; set; } = new OriginViewModel();
        public ViewModelBase FunctionViewModel { get; set; } = new FunctionViewModel();
    }
}
