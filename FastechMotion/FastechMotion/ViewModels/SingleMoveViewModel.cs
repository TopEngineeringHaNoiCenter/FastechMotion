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
		private int _commandPos;
        private uint _moveSpeed;
        private readonly MainViewModel mainViewModel;

        public int CommandPos
		{
			get 
			{
				return _commandPos; 
			}
			set 
			{
				_commandPos = value; 
				OnPropertyChanged(nameof(CommandPos));
			}
		}
		public uint MoveSpeed
		{
			get 
			{
				return _moveSpeed; 
			}
			set 
			{
				_moveSpeed = value;
				OnPropertyChanged(nameof(MoveSpeed));
			}
		}
    }
}
