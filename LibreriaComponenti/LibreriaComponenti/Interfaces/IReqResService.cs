using LibreriaComponenti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaComponenti.Interfaces
{
    public interface IReqResService
    {
        Task<ReqResData> GetReqResData();
        void CancelRequest();
        Task<string> PostNewUser(NewUser newUser);
    }
}
