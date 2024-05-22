using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FastechMotion.Services
{
    public interface ILogger
    {
        [JsonIgnore]
        ILog Log { get; }
    }
}
