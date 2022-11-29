using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tempoTrabalho
{
    public class Projeto
    {
        public Projeto() { }
        
        public Projeto(int num, String nome, int horas)
        {
            Num = num;
            Nome = nome;
            Horas = horas;
        }

        public int Num { get; set; }
        public String Nome { get; set; }
        public int Horas { get; set; }
    }
}
