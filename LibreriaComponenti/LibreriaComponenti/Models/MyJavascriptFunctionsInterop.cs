using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaComponenti.Models
{
    public class MyJavascriptFunctionsInterop : IDisposable
    {
        private readonly IJSRuntime _jsRuntime;
        private DotNetObjectReference<EsempioInterop> referenzaOggetto;
        public MyJavascriptFunctionsInterop(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public ValueTask<int> FaiQualcosa(string argomento1, string argomento2)
        {
            return _jsRuntime.InvokeAsync<int>("faiQualcosa", argomento1, argomento2);
        }

        public ValueTask<string> ChiamaSaluta(string name)
        {
            referenzaOggetto = DotNetObjectReference.Create(new EsempioInterop(name));
            return _jsRuntime.InvokeAsync<string>("sayHello", referenzaOggetto);
        }

        public void Dispose()
        {
            referenzaOggetto?.Dispose();
        }
    }
}
