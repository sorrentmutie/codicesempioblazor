using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared
{
    public interface IGestioneCatalogo
    {
        Catalogo GetCatalogoCorrente();
      //  void CreaCatalogo(Catalogo nuovoCatalogo);

    }

    public class GestioneCatalogo : IGestioneCatalogo
    {
        public Catalogo GetCatalogoCorrente()
        {
            return new Catalogo
            {
                Prodotti = new List<Prodotto>
            {
                new Prodotto { Id = 1, Name ="Prod1"},
                new Prodotto { Id = 2, Name ="Prod2"}
            }
            };
        }
    }
}
