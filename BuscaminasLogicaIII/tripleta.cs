using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaminasLogicaIII
{
    class tripleta
    {


            int fila, columna;
            object valor;
            public tripleta(int f, int c, object v) //Constructor
            {
                this.fila = f;
                this.columna = c;
                this.valor = v;
            }

            public void asignaFila(int f)
            {
                this.fila = f;
            }

            public void asignaColumna(int c)
            {
                this.columna = c;
            }

            public void asignaValor(object v)
            {
                this.valor = v;
            }

            public int retornaFila()
            {
                return fila;
            }

            public int retornaColumna()
            {
                return columna;
            }

            public object retornaValor()
            {
                return valor;
            }
        
    }
}
