using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastechMotion.States
{
    public enum EAlarmTypes
    {
        NoAlarm          = 0, 
        OverCurrent      = 1,
        OverSpeed        = 2,
        StepOut          = 3,
        OverLoad         = 4,
        OverTemperature  = 5,
        BackEMF          = 6,
        MotorConnect     = 7,
        EncoderConnect   = 8,
        MotorPower       = 9, 
        Inposition       = 10,
        SystemHalt       = 11,
        ROMdevice        = 12,
        PositionOverflow = 15
    }
}
