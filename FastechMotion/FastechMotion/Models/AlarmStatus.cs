using CommunityToolkit.Mvvm.ComponentModel;
using FastechMotion.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastechMotion.Models
{
    public class AlarmStatus : ObservableObject
    {
        #region Constructors
        public AlarmStatus()
        {
            _isAlarm = false;
            _alarmName = EAlarmTypes.NoAlarm;
            _alarmMessage = "";
        }
        #endregion

        #region Properties
        public bool IsAlarm { get { return _isAlarm; } set { _isAlarm = value; OnPropertyChanged(nameof(IsAlarm)); } }
        public EAlarmTypes AlarmCode { get { return _alarmName; } set { _alarmName = value; OnPropertyChanged(nameof(AlarmCode)); } }
        public string AlarmMessage { get { return _alarmMessage; } set { _alarmMessage = value; OnPropertyChanged(nameof(AlarmMessage)); } }
        #endregion

        #region Privates
        private bool _isAlarm;
        private EAlarmTypes _alarmName;
        private string _alarmMessage;
        #endregion
    }
}
