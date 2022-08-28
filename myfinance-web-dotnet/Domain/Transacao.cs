using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_dotnet.infra;
using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Domain
{
    public class Transacao
    {

        public void Inserir(TransacaoModel formulario)
        {
            var objDAL = DAL.GetInstancia;
            objDAL.Conectar();

            var sql = "INSERT INTO TRANSACAO (data,valor,tipo, historico,id_plano_conta) " +
            "VALUES(" +
            $"'{formulario.Data.ToString("yyyy-MM-dd")}'," +
            $"{formulario.Valor}," +
            $"'{formulario.Tipo}'," +
            $"'{formulario.Historico}'," +
            $"{formulario.IdPlanoConta})";

            objDAL.ExecutarComandoSQL(sql);
            objDAL.Desconectar();
        }
         public void Atualizar(TransacaoModel formulario)
        {
            var objDAL = DAL.GetInstancia;
            objDAL.Conectar();
            var sql = "UPDATE TRANSACAO SET " +
            $"Historico = '{formulario.Historico}'," +
            $"Tipo = '{formulario.Tipo}', " +
            $"Valor = {formulario.Valor} ," +
            $"Data = '{formulario.Data.ToString("yyyy-MM-dd")}', " +
            $"id_plano_conta = '{formulario.IdPlanoConta}' " +
            $"WHERE id = {formulario.Id}";
            objDAL.ExecutarComandoSQL(sql);
            objDAL.Desconectar();
        }
        public TransacaoModel CarregarTransacaoPorId (int? id)
        {
         var objDAL = DAL.GetInstancia;
            objDAL.Conectar();

            var sql = $"select id, data, valor, tipo, historico, id_plano_conta from transacao WHERE ID = {id}";
            var dataTable = objDAL.RetornarDataTable(sql);
            
            var transacao = new TransacaoModel()
            {
                Id = int.Parse(dataTable.Rows[0]["ID"].ToString()),
                Historico = dataTable.Rows[0]["HISTORICO"].ToString(),
                Tipo = dataTable.Rows[0]["TIPO"].ToString(),
                Data = DateTime.Parse(dataTable.Rows[0]["data"].ToString()),
                Valor = decimal.Parse(dataTable.Rows[0]["valor"].ToString()),
                IdPlanoConta = int.Parse(dataTable.Rows[0]["id_plano_conta"].ToString())
            };
             objDAL.Desconectar();
            return transacao;
        }

         public List<TransacaoModel> ListaTransacoes()
        {
            List<TransacaoModel> lista = new List<TransacaoModel>();

            var objDAL = DAL.GetInstancia;
            objDAL.Conectar();

            var sql = "select id, data, valor, tipo, historico, id_plano_conta from transacao";
            var dataTable = objDAL.RetornarDataTable(sql);

             for (int i=0; i < dataTable.Rows.Count; i++)
             {
                var transacao = new TransacaoModel()
                {
                    Id = int.Parse(dataTable.Rows[i]["ID"].ToString()),
                    Data = DateTime.Parse(dataTable.Rows[i]["DATA"].ToString()),
                    Valor = decimal.Parse(dataTable.Rows[i]["VALOR"].ToString()),
                    Tipo = dataTable.Rows[i]["TIPO"].ToString(),
                    Historico = dataTable.Rows[i]["HISTORICO"].ToString(),
                    IdPlanoConta = int.Parse(dataTable.Rows[i]["ID_PLANO_CONTA"].ToString()),
                    
                };
                lista.Add(transacao);
             }
             objDAL.Desconectar();
            return lista;
        }
        
    }
}