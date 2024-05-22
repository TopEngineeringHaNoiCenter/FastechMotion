using FASTECH;
using FastechMotion.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FastechMotion.ViewModels
{
    public class SingleMoveViewModel : ViewModelBase
    {
        private int _cmdPos;
        public int CmdPos
        {
            get { return _cmdPos; }
            set { _cmdPos = value; OnPropertyChanged(nameof(CmdPos)); }
        }

        private int _startSpeed;
        public int StartSpeed
        {
            get { return _startSpeed; }
            set { _startSpeed = value; OnPropertyChanged(nameof(StartSpeed)); }
        }

        private int _moveSpeed;
        public int MoveSpeed
        {
            get { return _moveSpeed; }
            set { _moveSpeed = value; OnPropertyChanged(nameof(MoveSpeed)); }
        }

        private int _accelTime;
        public int AccelTime
        {
            get { return _accelTime; }
            set { _accelTime = value; OnPropertyChanged(nameof(AccelTime)); }
        }

        private int _deccelTime;
        public int DeccelTime
        {
            get { return _deccelTime; }
            set { _deccelTime = value; OnPropertyChanged(nameof(DeccelTime)); }
        }
        public ICommand ABSMoveCommand {  get; set; }

        public ICommand DECMoveCommand { get; set; }   
        public ICommand INCMoveCommand { get; set; }
        
        public SingleMoveViewModel(MainViewModel MainViewModel)
        {
            ABSMoveCommand = new ABSMoveCommand(MainViewModel);
        }
    }
}
