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
    public partial class Form1 : Form
    {


        public static int x=0,y=0,z=0;
        int height, width;
        public Form1()
        {
            InitializeComponent();
        }

        private void newForm(bool custom)
        {
            Form2 form2 = new Form2(x,y,z);
            form2.form1 = this;
            if (!custom)
            {
            form2.Size = new Size(height,width);
            }
            form2.personalizada = custom;
            this.Visible = false;
            form2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            x = 8; y = 8; z = 10;
            height = x * 24 + 2;
            width = y * 26 +10;
            newForm(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            x = 16; y = 16; z = 40;
            height = x * 24 -14;
            width = y * 24 + 9;
            newForm(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            x = 30; y = 16; z = 99;
            height = x * 24-45;
            width = y * 24+10;
            newForm(false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            x = Convert.ToInt32(numericUpDown2.Value);
            y = Convert.ToInt32(numericUpDown3.Value);
            z = Convert.ToInt32(numericUpDown1.Value);
            if (z >= x * y)
            {
                MessageBox.Show("Las minas no pueden sobrepasar el número de filas por columnas.");
            }
            else
            {
                newForm(true);
            }
        }


    }
}
