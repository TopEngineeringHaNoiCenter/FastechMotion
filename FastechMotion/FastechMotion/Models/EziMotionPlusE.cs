using FASTECH;
using FastechMotion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace FastechMotion.Models
{
    public class EziMotionPlusE : ViewModelBase
    {
        DispatcherTimer UpdateStatusTimer;
		private string _name;
        private string _strIp;
		private uint _axisStatus;

        public uint AxisStatus
		{
			get 
			{
				return _axisStatus; 
			}
			set 
			{
				_axisStatus = value;
				OnPropertyChanged(nameof(AxisStatus));
			}
		}
		public string Name
		{
			get 
			{
				return _name; 
			}
			set 
			{
				_name = value; 
				OnPropertyChanged("Name");
			}
		}
		public string StrIP
		{
			get 
			{
				return _strIp; 
			}
			set 
			{
                _strIp = value;
				OnPropertyChanged("IP");
			}
		}
		public int BoardID { get; set; } = 8;

		public bool IsErrorAll => (AxisStatus & 0X00000001) == 0X00000001;
		public bool IsHWPositiveLimit => (AxisStatus & 0X00000002) == 0X00000002;
		public bool IsHWNegativeLimit => (AxisStatus & 0X00000004) == 0X00000004;

        public EziMotionPlusE(string name,string strIP) 
		{
			Name = name;
			StrIP = strIP;
			IPAddress ip = IPAddress.Parse(strIP);
			BoardID = ip.GetAddressBytes()[3];
			UpdateStatusTimer = new DispatcherTimer();
			UpdateStatusTimer.Tick += new EventHandler(UpdateStatus_Tick);
			UpdateStatusTimer.Interval = TimeSpan.FromMilliseconds(1000);
			UpdateStatusTimer.Start();
        }

		public void Connect()
		{
            EziMOTIONPlusELib.FAS_Connect(IPAddress.Parse(StrIP),BoardID);
        }
		public void Disconnect() 
		{
            EziMOTIONPlusELib.FAS_Close(BoardID);
        }

		public void ServoOn()
		{
            EziMOTIONPlusELib.FAS_ServoEnable(BoardID,1);
        }
		public void Origin()
		{
            EziMOTIONPlusELib.FAS_MoveOriginSingleAxis(BoardID);

        }
		public void MoveAbs(int absPos,uint velocity)
		{
			EziMOTIONPlusELib.FAS_MoveSingleAxisAbsPos(BoardID, absPos, velocity);
        }
		public void UpdateAxisStatus()
		{
			uint axisStatus = 0;
			EziMOTIONPlusELib.FAS_GetAxisStatus(BoardID, ref axisStatus);
			AxisStatus = axisStatus;
			OnPropertyChanged(nameof(IsErrorAll));
			OnPropertyChanged(nameof(IsHWPositiveLimit));
			OnPropertyChanged(nameof(IsHWNegativeLimit));
		}
		private void UpdateStatus_Tick(object sender, EventArgs e)
		{
			UpdateAxisStatus();
        }
	}
}
