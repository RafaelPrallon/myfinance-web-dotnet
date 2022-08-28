using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Controllers
{

    public class TransacaoController : Controller
    {
        private readonly ILogger<TransacaoController> _logger;

        public TransacaoController(ILogger<TransacaoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var transacao = new Transacao();
            ViewBag.Lista = transacao.ListaTransacoes();
            return View();
        }

        [HttpGet]
          public IActionResult CriarTransacao( int? id)
        {
            if (id != null)
            {
                var transacao = new Transacao().CarregarTransacaoPorId(id);
                ViewBag.Registro = transacao;
            }

            ViewBag.ListaPlanoContas = new PlanoContaModel().ListaPlanoContas();
            return View();
        }

         [HttpPost]
          public IActionResult CriarTransacao(TransacaoModel formulario)
        {
            var transacao = new Transacao();

            if(formulario.Id == null)
                transacao.Inserir(formulario);
            else
                transacao.Atualizar(formulario);
                
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}