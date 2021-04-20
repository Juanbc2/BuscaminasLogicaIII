using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BuscaminasLogicaIII
{
    public class matrizForma1
    {

            nodoDoble mat;

            public matrizForma1(int m, int n) // constructor
            {
                tripleta t = new tripleta(m, n, null);
                mat = new nodoDoble(t);
                t.asignaValor(mat);
                mat.asignaDato(t);
            }

            public nodoDoble nodoCabeza()
            {
                return this.mat;
            }
            public nodoDoble primerNodo()
            {
                tripleta tp = (tripleta)mat.retornaDato();
                nodoDoble p = (nodoDoble)tp.retornaValor();
                return p;
            }
            public bool esVacia()
            {
                nodoDoble p = primerNodo();
                return p == mat;
            }
            public bool finDeRecorrido(nodoDoble p)
            {
                return p == mat;
            }
            public void construyeNodosCabeza()
            {
                int mayor, i;
                nodoDoble x, ultimo;
                tripleta t;
                ultimo = nodoCabeza();
                t = (tripleta)ultimo.retornaDato();
                int m = t.retornaFila();
                int n = t.retornaColumna();
                mayor = m;
                if (n > m)
                {
                    mayor = n;
                }
                for (i = 1; i <= mayor; i++)
                {
                    t = new tripleta(i, i, nodoCabeza());
                    x = new nodoDoble(t);
                    x.asignaLd(x);
                    x.asignaLi(x);
                    t = (tripleta)ultimo.retornaDato();
                    t.asignaValor(x);
                    ultimo.asignaDato(t);
                    ultimo = x;

                }
            }


            public void conectaPorFilas(nodoDoble x)
            {
                nodoDoble p, q, anterior;
                tripleta tp, tq, tx;
                int i;
                tx = (tripleta)x.retornaDato();
                p = primerNodo();
                for (i = 0; i < tx.retornaFila(); i++)
                {
                    tp = (tripleta)p.retornaDato();
                    p = (nodoDoble)tp.retornaValor();
                }
                anterior = p;
                q = p.retornaLd();

                tq = (tripleta)q.retornaDato();
                while ((q != p) && (tq.retornaColumna() < tx.retornaColumna()))
                {
                    anterior = q;
                    q = q.retornaLd();
                    tq = (tripleta)q.retornaDato();
                }
                anterior.asignaLd(x);
                x.asignaLd(q);


            }



            public void conectaPorColumnas(nodoDoble x)
            {
                nodoDoble p, q, anterior;
                tripleta tp, tq, tx;
                int i;
                tx = (tripleta)x.retornaDato();
                p = primerNodo();
                for (i = 0; i < tx.retornaColumna(); i++)
                {
                    tp = (tripleta)p.retornaDato();
                    p = (nodoDoble)tp.retornaValor();
                }
                anterior = p;
                q = p.retornaLi();
                tq = (tripleta)q.retornaDato();
                while ((q != p) && (tq.retornaFila() < tx.retornaFila()))
                {
                    anterior = q;
                    q = q.retornaLi();
                    tq = (tripleta)q.retornaDato();
                }
                anterior.asignaLi(x);
                x.asignaLi(q);

            }


		public int buscaEnMatriz(int m,int n)
		{
			int qf, qc, qv;
			nodoDoble p, q;
			tripleta tq, tp;
			p = primerNodo();
			while (!finDeRecorrido(p))
			{
				q = p.retornaLd();
				while (q != p)
				{
					tq = (tripleta)q.retornaDato();
					qf = tq.retornaFila();
					qc = tq.retornaColumna();
					qv = (int)tq.retornaValor();
					if (qf == m && qc == n)
					{
						return (int)tq.retornaValor();
					}
					q = q.retornaLd();
				}
				tp = (tripleta)p.retornaDato();
				p = (nodoDoble)tp.retornaValor();
			}
			return 0;
		}


        public object muestraMatriz(object obj)
        {
            int qf, qc, qv;
            nodoDoble p, q;
            tripleta tq, tp;
            p = primerNodo();
            while (!finDeRecorrido(p))
            {
                q = p.retornaLd();
                while (q != p)
                {
                    tq = (tripleta)q.retornaDato();
                    qf = tq.retornaFila();
                    qc = tq.retornaColumna();
                    qv = (int)tq.retornaValor();
                    if (qv == (int)obj) return qv;
                    q = q.retornaLd();
                }
                tp = (tripleta)p.retornaDato();
                p = (nodoDoble)tp.retornaValor();
            }
            return null;
        }

            public void muestraMatriz()
            {
                int qf, qc, qv;
                nodoDoble p, q;
                tripleta tq, tp;
                p = primerNodo();
                while (!finDeRecorrido(p))
                {
                    q = p.retornaLd();
                    while (q != p)
                    {
                        tq = (tripleta)q.retornaDato();
                        qf = tq.retornaFila();
                        qc = tq.retornaColumna();
                        qv = (int)tq.retornaValor();

                        Console.WriteLine(qf + " " + qc + " " + qv);
                        q = q.retornaLd();
                    }
                    tp = (tripleta)p.retornaDato();
                    p = (nodoDoble)tp.retornaValor();
                }
            }
        }
    }

