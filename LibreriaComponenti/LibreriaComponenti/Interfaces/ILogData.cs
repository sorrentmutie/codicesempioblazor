using LibreriaComponenti.Models;
using System.Collections.Generic;

namespace LibreriaComponenti.Interfaces
{
    public interface ILogData
    {
        List<LogData> GetLogs();
        List<LogData> GetPastLogs();
    }
}
