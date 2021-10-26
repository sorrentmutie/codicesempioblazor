using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaComponenti.Models
{
    public class EsempioInterop
    {
        public EsempioInterop(string name)
        {
            this.Name = name;
        }

        public string Name { get;  set; }

        [JSInvokable]
        public string Saluta()
        {
            return $"Ciao, {Name}";
        }

    }
}
