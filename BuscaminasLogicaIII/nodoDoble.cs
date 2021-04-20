using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaminasLogicaIII
{
    public class nodoDoble
    {

        private object dato;
        private nodoDoble ld, li;

        public nodoDoble(object d)
        {
            this.dato = d;
            li = null;
            ld = null;
        }

        public void asignaDato(object d)
        {
            dato = d;
        }

        public void asignaLi(nodoDoble x)
        {
            li = x;
        }
        public void asignaLd(nodoDoble x)
        {
            ld = x;
        }
        public object retornaDato()
        {
            return this.dato;
        }
        public nodoDoble retornaLi()
        {
            return this.li;
        }
        public nodoDoble retornaLd()
        {
            return this.ld;
        }

    }
}
