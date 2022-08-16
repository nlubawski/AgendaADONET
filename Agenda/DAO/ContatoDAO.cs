using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.DAO
{
    public class ContatoDAO
    {
        public DataSet GetContatos()
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM CONTATOS"; //instrucao sql
            DbDataAdapter adapter = new SqlDataAdapter((SqlCommand) comando);
            DataSet ds = new DataSet(); // criamos o data set que vai ser populado
            adapter.Fill(ds, "CONTATOS"); // vai preencher nosso data set com o que veio da consulta
            return ds;

            //Da pra fazer com data reader ai usuaria o tipo DataTable ==> pesquise
            //DbDataReader reader = DAOUtils.GetDataReader(comando); //recupera os dados trazidos pela exec do comando
            //...
        }

        public void Excluir(int id)
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "DELETE FROM CONTATOS WHERE ID = @id"; //NAO CONCATENE!! DANGERRR
            comando.Parameters.Add(new SqlParameter("@id", id)); //Use parametros S2
            comando.ExecuteNonQuery(); //executa e nao traz nada

        }
    }
}
