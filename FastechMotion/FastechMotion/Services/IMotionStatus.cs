using FastechMotion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastechMotion.Services
{
    public interface IMotionStatus
    {
        bool IsConnected { get; set; }
        bool IsMotionOn { get; set; }
        bool IsHomeDone { get; set; }
        bool IsMotionDone { get; set; }
        AlarmStatus AlarmStatus { get; set; }
        AxisStatus AxisStatus { get; set; }
        double CommandPosition { get; set; }
        double ActualPosition { get; set; }
        double PositionError { get; set; }
        double ActualVelocity { get; set; }
    }
}
