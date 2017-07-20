using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sweetandcoffee.Entidades
{
    public class ELote
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal StockFront { get; set; } 
        public decimal StockLotes { get; set; }
        public decimal Diferencia { get; set; }
    }
}
