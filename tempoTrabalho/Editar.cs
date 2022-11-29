using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tempoTrabalho
{
    public partial class Editar : Form
    {
        public Editar()
        {
            InitializeComponent();
        }

        private void Editar_Load(object sender, EventArgs e)
        {
            label1.Text = Form1.projSelect.Nome;
            label3.Text = "Horas Totais: " + Form1.projSelect.Horas;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BancoDeDados.AlterarHoras(Form1.projSelect, int.Parse(textBox1.Text));
                label3.Text = "Horas Totais: " + Form1.projSelect.Horas;
            }
            catch
            {
                MessageBox.Show("Erro");
            }
        }
    }
}
