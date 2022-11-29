using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tempoTrabalho
{
    public class BancoDeDados
    {
        static SqlConnection con = new SqlConnection();
        static SqlCommand cmd = new SqlCommand();
        static SqlDataReader reader;

        public static void NovaConexao()
        {
            con.ConnectionString = "Data Source=DESKTOP-QQOLUS3\\SQLEXPRESS;Initial Catalog=estudos;Integrated Security=True";
        }

        private static void Conectar()
        {
            con.Open();
            cmd.Connection = con;
        }

        private static void Desconectar()
        {
            con.Close();
        }

        private static void ExecutarSemConsulta()
        {
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        private static void LimparParametros()
        {
            cmd.Parameters.Clear();
        }
     

        public static void AdicionarProj(Projeto proj)
        {
            cmd.CommandText = "INSERT INTO tempoTrabalho(numero, projeto, horas) VALUES(@numero, @projeto, @horas)";
            cmd.Parameters.Add(new SqlParameter("@numero", SqlDbType.Int)).Value = proj.Num;
            cmd.Parameters.Add(new SqlParameter("@projeto", SqlDbType.VarChar, 20)).Value = proj.Nome;
            cmd.Parameters.Add(new SqlParameter("@horas", SqlDbType.Int)).Value = proj.Horas;
            Conectar();
            ExecutarSemConsulta();
            Desconectar();
        }

        public static void AlterarHoras(Projeto projeto, int horasAdd)
        {
            LimparParametros();
            cmd.CommandText = "UPDATE tempoTrabalho SET horas = @horas WHERE numero = @num";
            cmd.Parameters.Add(new SqlParameter("@horas", SqlDbType.Int)).Value = projeto.Horas + horasAdd;
            cmd.Parameters.Add(new SqlParameter("@num", SqlDbType.Int)).Value = projeto.Num;
            projeto.Horas += horasAdd;
            Conectar();
            ExecutarSemConsulta();
            Desconectar();
        }

        public static List<Projeto> ConsultarTodos()
        {
            LimparParametros();
            List<Projeto> lista = new List<Projeto>();
            cmd.CommandText = "SELECT * FROM tempoTrabalho";
            Conectar();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Projeto proj = new Projeto();
                proj.Num = reader.GetInt32(0);
                proj.Nome = reader.GetString(1);
                proj.Horas = reader.GetInt32(2);
                lista.Add(proj);
            }
            Desconectar();
            return lista;
        }

        public static Projeto ConsultarUnico(int num)
        {
            LimparParametros();
            Projeto projeto = new Projeto();
            cmd.CommandText = "SELECT * FROM tempoTrabalho WHERE numero = @num";
            cmd.Parameters.AddWithValue("@num", num);
            Conectar();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                projeto.Num = reader.GetInt32(0);
                projeto.Nome = reader.GetString(1);
                projeto.Horas = reader.GetInt32(2);
            }
            Desconectar();
            return projeto;
        }

    }
}
