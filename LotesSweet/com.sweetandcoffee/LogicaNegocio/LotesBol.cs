using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.sweetandcoffee.AccesoDatos;
using com.sweetandcoffee.Entidades;

namespace com.sweetandcoffee.LogicaNegocio
{
    public class LotesBol
    {
        private LotesDal _lotesDal = new LotesDal();

        public List<ELote> Todos()
        {
            return _lotesDal.GetAll();
        }
    }
}
