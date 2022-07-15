using Entra21.BancoDados01.Ado.Net.DataBase1;
using Entra21.BancoDados01.Ado.Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entra21.BancoDados01.Ado.Net.Services
{
    //Dois pontos seguido de uma interface quer dizer que a classe
    //será obrigada a implementar os métodos (contratos) estabelecidos na interface
    internal class TipoPersonagemService : ITipoPersonagemService
    {
        public void Cadastrar(TipoPersonagem tipoPersonagem)
        {
            var conexao = new Conexao().Conectar();

            //Criar comando para executar no banco de dados
            SqlCommand comando = conexao.CreateCommand();

            //Especificando o comando que será executado
            comando.CommandText = "INSERT INTO tipos_personagens (tipo) VALUES ('" + tipoPersonagem.Tipo + "')";

            //Executando o comando de insert na tabela de tipos personagens
            comando.ExecuteNonQuery();

            conexao.Close();
        }

        public List<TipoPersonagem> ObterTodos()
        {
            var conexao = new Conexao().Conectar();

            var comando = conexao.CreateCommand();

            comando.CommandText = "SELECT id, tipo FROM tipos_personagens";

            //Criado tabela em memoria para postriormente carregar os registros obtidos com o select
            var tabelaEmMemoria = new DataTable();

            //Carregado na tabela em memória os registros encontrados com o comando select 
            tabelaEmMemoria.Load(comando.ExecuteReader());

            //Criado uma lista para armazenar os registros da consulta do select
            var tipoPersonagens = new List<TipoPersonagem>();

            //Percorrido cada um dos registros da tabelaEmMemoria(registros do select
            for (int i = 0; i < tabelaEmMemoria.Rows.Count; i++)
            {
                //Obtido o registro da linha que esta sendo percorrida
                var linha = tabelaEmMemoria.Rows[i];

                //Instanciando objeto da classe TipoPersonagem
                //Preenchendo com as informações do SELECT, da linha
                //que está sendo percorrida
                var tipoPersonagem = new TipoPersonagem();
                tipoPersonagem.Id = Convert.ToInt32(linha["id"].ToString());
                tipoPersonagem.Tipo = linha["tipo"].ToString();

                //Adicionado tipoPersonagem instanciado na lista
                //de TiposPersonagens
                tipoPersonagens.Add(tipoPersonagem);
            }
            //Fechado a conexao com o banco de dados 
            comando.Connection.Close();
            return tipoPersonagens;
        }
    }
}
