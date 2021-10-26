using LibreriaComponenti.Interfaces;
using LibreriaComponenti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoServer.Services
{
    public class LogDataService : ILogData
    {
        public List<LogData> GetLogs()
        {
            // qui farò chiamate al db
            var logs = new List<LogData>();

            logs.Add(new LogData { Id = 1, Level = "critic", Message = "Messaggio 1" });
            logs.Add(new LogData { Id = 2, Level = "info", Message = "Messaggio 2" });
            logs.Add(new LogData { Id = 3, Level = "warning", Message = "Messaggio 3" });
            logs.Add(new LogData { Id = 4, Level = "critic", Message = "Messaggio 4" });
            return logs;

        }

        public List<LogData> GetPastLogs()
        {
            var logs = new List<LogData>();

            logs.Add(new LogData { Id = 5, Level = "critic", Message = "Messaggio 5" });
            logs.Add(new LogData { Id = 6, Level = "info", Message = "Messaggio 6" });
            logs.Add(new LogData { Id = 7, Level = "warning", Message = "Messaggio 7" });
            logs.Add(new LogData { Id = 8, Level = "critic", Message = "Messaggio 8" });
            return logs;
        }
    }
}
