using System.Data.Common;
using System.Data.SqlClient; //teve que instalar

namespace Agenda.DAO
{
    public class DAOUtils
    {
        public static DbConnection GetConexao() //Retorna a conexao
        {
            //DbConnection so serve de base, é abstrata
            DbConnection conexao = new SqlConnection(@"Data Source=DESKTOP-U2AC359\SQLEXPRESS;Initial Catalog=Agenda;Integrated Security=True"); //site onnection strings
            conexao.Open();
            return conexao;
        }

        public static DbCommand GetComando(DbConnection conexao) //precisa saber a partir de qual conexao ele vai ser usado
        {
            DbCommand comando = conexao.CreateCommand(); //vai servir pra executar as instrucoes
            return comando;
        }

        public static DbDataReader GetDataReader(DbCommand comando) //serve pra ler as info da tabela
        {
            return comando.ExecuteReader(); //retorna o data reader com as infos trazidas pela exec do comando
        }
        



    }
}
