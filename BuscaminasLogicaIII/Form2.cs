using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuscaminasLogicaIII
{
    public partial class Form2 : Form
    {
        public Form1 form1;
        private int x, y, z;
        public static matrizForma1 minas;
        private Tuple<int, int>[] posMinas;
        public bool personalizada = false;
        public Form2(int x, int y, int z)
        {
            
            this.x = x;
            this.y = y;
            this.z = z;
            minas = new matrizForma1(x, y);
            minas.construyeNodosCabeza();
            ponerMinas(x, y, z);
            minas.muestraMatriz();
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = x;
            dataGridView1.RowCount = y;
            colorToCells();
            if (!personalizada)
            {
            sizeDGV(dataGridView1);
            }

        }

        private void colorToCells()
        {
            for (int i = 0; i < this.x; i++)
            {
                for (int j = 0; j < this.y; j++)
                {
                    dataGridView1[i, j].Style.BackColor = Color.LightGreen;
                }
            }
        }

        private void ponerMinas(int x, int y, int z)
        {
            tripleta t;
            nodoDoble nd;
            Random rd = new Random();
            Tuple<int, int>[] posMinas = new Tuple<int, int>[z];
            for (int i = 0; i < z; i++)
            {
                int a = rd.Next(0, x);
                int b = rd.Next(0, y);
                //Tuple<int,int> c = new Tuple<
                if (!posMinas.Contains(new Tuple<int, int>(a, b)))
                {
                    posMinas[i] = new Tuple<int, int>(a, b);
                }
                else
                {
                    i--;
                }
            }
            this.posMinas = posMinas;
            foreach (Tuple<int, int> m in posMinas)
            {
                t = new tripleta(m.Item1, m.Item2, 9);
                nd = new nodoDoble(t);
                minas.conectaPorFilas(nd);
                minas.conectaPorColumnas(nd);
                sumarvecinas(m.Item1, m.Item2);
            }


        }

        private void sumarvecinas(int x1, int y1)
        {
            tripleta t;
            nodoDoble nd;
            if (x1 != 0 && y1!= 0 && minas.buscaEnMatriz(x1 - 1, y1 - 1) != 9)
            {

                t = new tripleta(x1 - 1, y1 - 1, minas.buscaEnMatriz(x1 - 1, y1 - 1) + 1);
                nd = new nodoDoble(t);
                minas.conectaPorFilas(nd);
                minas.conectaPorColumnas(nd);
            }
            if (y!= 0 && minas.buscaEnMatriz(x1, y1 - 1) != 9)
            {
                t = new tripleta(x1, y1 - 1, minas.buscaEnMatriz(x1, y1 - 1) + 1);
                nd = new nodoDoble(t);
                minas.conectaPorFilas(nd);
                minas.conectaPorColumnas(nd);
            }
            if (x1 != this.x - 1 && y1 != 0 && minas.buscaEnMatriz(x1 + 1, y1 - 1) != 9)
            {
                t = new tripleta(x1 + 1, y1 - 1, minas.buscaEnMatriz(x1 + 1, y1 - 1) + 1);
                nd = new nodoDoble(t);
                minas.conectaPorFilas(nd);
                minas.conectaPorColumnas(nd);
            }
            if (x1!= 0 && minas.buscaEnMatriz(x1 - 1, y1) != 9)
            {
                t = new tripleta(x1 - 1, y1, minas.buscaEnMatriz(x1 - 1, y1) + 1);
                nd = new nodoDoble(t);
                minas.conectaPorFilas(nd);
                minas.conectaPorColumnas(nd);
            }
            if (x1!= 0 && y1 != this.y - 1 && minas.buscaEnMatriz(x1 - 1, y1 + 1) != 9)
            {
                t = new tripleta(x1 - 1, y1 + 1, minas.buscaEnMatriz(x1 - 1, y1 + 1) + 1);
                nd = new nodoDoble(t);
                minas.conectaPorFilas(nd);
                minas.conectaPorColumnas(nd);
            }
            if (y1 != this.y - 1 && minas.buscaEnMatriz(x1, y1 + 1) != 9)
            {
                t = new tripleta(x1, y1 + 1, minas.buscaEnMatriz(x1, y1 + 1) + 1);
                nd = new nodoDoble(t);
                minas.conectaPorFilas(nd);
                minas.conectaPorColumnas(nd);
            }
            if (x1 != this.x - 1 && y1 != this.y - 1 && minas.buscaEnMatriz(x1 + 1, y1 + 1) != 9)
            {
                t = new tripleta(x1 + 1, y1 + 1, minas.buscaEnMatriz(x1 + 1, y1 + 1) + 1);
                nd = new nodoDoble(t);
                minas.conectaPorFilas(nd);
                minas.conectaPorColumnas(nd);
            }
            if (x1 != this.x - 1 && minas.buscaEnMatriz(x1 + 1, y1) != 9)
            {
                t = new tripleta(x1 + 1, y1, minas.buscaEnMatriz(x1 + 1, y1) + 1);
                nd = new nodoDoble(t);
                minas.conectaPorFilas(nd);
                minas.conectaPorColumnas(nd);
            }

        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.Visible = true;

        }
        void sizeDGV(DataGridView dgv)
        {
            DataGridViewElementStates states = DataGridViewElementStates.None;
            dgv.ScrollBars = ScrollBars.None;
            var totalHeight = dgv.Rows.GetRowsHeight(states) + dgv.ColumnHeadersHeight;
            totalHeight += dgv.Rows.Count - y * 2 - 1;
            var totalWidth = dgv.Columns.GetColumnsWidth(states) + dgv.RowHeadersWidth - x * 2 + 25;
            dgv.ClientSize = new Size(totalWidth, totalHeight);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            
            int x1 = dataGridView1.CurrentCell.ColumnIndex;
            int y1 = dataGridView1.CurrentCell.RowIndex;
            if(dataGridView1[x1,y1].Value==null){
            if (minas.buscaEnMatriz(x1, y1) == 9 && dataGridView1.CurrentCell.Style.BackColor!=Color.Green)
            {
                foreach(Tuple<int,int> t in this.posMinas)
                {
                    dataGridView1[t.Item1,t.Item2].Style.BackColor = Color.Red;
                }

                MessageBox.Show("Ha pisado una mina, fin del juego.");
                dataGridView1.Enabled = false;
            }
            else
            {
                if (minas.buscaEnMatriz(x1, y1) == 0)
                {
                    destapar(x1, y1,0);
                    Console.WriteLine(x1 + "|" + y1 + "|" + minas.buscaEnMatriz(x1, y1));
                }
                else
                {
                    if (dataGridView1.CurrentCell.Style.BackColor != Color.Green)
                    {
                        dataGridView1.CurrentCell.Value = minas.buscaEnMatriz(x1, y1);
                        dataGridView1.CurrentCell.Style.BackColor = Color.White;
                    }
                }
                Console.WriteLine(x1 + "|" + y1 + "|" + minas.buscaEnMatriz(x1, y1));
            }
            }
            checkWin();
        }

        private void checkWin()
        {
            int count = 0;
            for(int i = 0; i <this.x;i++){
                for (int j = 0; j < this.y;j++ )
                {
                    if (dataGridView1[i, j].Value != null)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
            if (count >= this.x * this.y - this.z)
            {
                MessageBox.Show("Ha ganado el juego,descubrió todas las minas.");
                dataGridView1.Enabled = false;
            }

        }



        private void destapar(int fila, int colum,int dir)
        {
            if ((dataGridView1[fila, colum].Value == null) && minas.buscaEnMatriz(fila, colum) == 0)
            {
                dataGridView1[fila, colum].Value = minas.buscaEnMatriz(fila, colum);
                dataGridView1[fila,colum].Style.BackColor = Color.White;

                if (fila != 0 && (dataGridView1[fila - 1, colum].Value == null))
                {
                    destapar(fila - 1, colum,1);
                }
                if (fila != this.x - 1 && (dataGridView1[fila + 1, colum].Value == null))
                {
                    destapar(fila + 1, colum,2);
                }
                if (colum != 0 && (dataGridView1[fila, colum - 1].Value == null ))
                {
                    destapar(fila, colum-1,3);
                }
                if (colum != this.y - 1 && (dataGridView1[fila, colum + 1].Value == null ))
                {
                    destapar(fila, colum+1,4);
                }
            }
            else
            {
                dataGridView1[fila, colum].Value = minas.buscaEnMatriz(fila, colum);
                dataGridView1[fila, colum].Style.BackColor = Color.White;
            }
            

        }

        private int max(int num1, int num2)
        {
            int num;
            if (num1 > num2)
            {
                num = num1;
            }
            else
            {
                num = num2;
            }
            return num;
        }

        private int min(int num1, int num2)
        {
            int num;
            if (num1 < num2)
            {
                num = num1;
            }
            else
            {
                num = num2;
            }
            return num;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            if (e.Button == System.Windows.Forms.MouseButtons.Right) {
                if (dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor != Color.Gold && dataGridView1[e.ColumnIndex, e.RowIndex].Value==null) { 
                    dataGridView1[e.ColumnIndex,e.RowIndex].Style.BackColor = Color.Gold;
                }
                else
                {
                    if(dataGridView1[e.ColumnIndex, e.RowIndex].Value==null)
                    dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightGreen;
                }

            }


        }



    }
}
