using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared
{
    public class Ordine
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        List<RigaOrdine> RigheOrdine { get; set; } = new List<RigaOrdine>();
    }

    public  class RigaOrdine
    {
        public int Id { get; set; }
        public int Quantità { get; set; }
        public int IdProdotto { get; set; }
    }

    public class Prodotto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Catalogo
    {
        public List<Prodotto> Prodotti { get; set; }
    }

  

}
