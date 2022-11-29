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
    public partial class Adicionar : Form
    {
        public Adicionar()
        {
            InitializeComponent();
        }

        private void Adicionar_Load(object sender, EventArgs e)
        {
            BancoDeDados.NovaConexao();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Projeto projeto = new Projeto(int.Parse(textBox1.Text), textBox2.Text, 0);
                BancoDeDados.AdicionarProj(projeto);
                MessageBox.Show("Adicionado.");
            }
            catch
            {
                MessageBox.Show("Verifique se não há projeto com número indicado.");
            }
            
        }
    }
}
