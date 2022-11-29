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
    public partial class Form1 : Form
    {

        public static Projeto projSelect = new Projeto();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BancoDeDados.NovaConexao();
            int proxLinha = 0;
            int top = 30;
            int left = 130;
            List<Projeto> lista = BancoDeDados.ConsultarTodos();
            foreach(Projeto proj in lista)
            {
                Button button = new Button();
                button.Left = left;
                button.Top = top;
                button.Text = proj.Num + "/ " + proj.Nome;
                button.Click += Editar;
                button.Name = proj.Num.ToString();
                button.Width = 120;
                proxLinha++;
                this.Controls.Add(button);
                if (proxLinha % 3 == 0) {
                    top += button.Height + 2;
                    left = 130;
                }else left += button.Width + 2;
            }
        }


        private void Editar(object sender, EventArgs e)
        {
            Editar form = new Editar();
            projSelect = BancoDeDados.ConsultarUnico(int.Parse((sender as Button).Name));
            form.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Adicionar form = new Adicionar();
            form.Show();
        }

    }
}
