using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("Teste")]
    public class TesteController
    {
        private readonly IRelatorioService _relatorioService;
        public TesteController(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        [HttpPost("TesteConsole")]
        public void TesteConsole(string texto)
        {
            Console.WriteLine(texto);
        }

        [HttpGet("Gerar PDF")]
        public void GerarPDF()
        {
            _relatorioService.GerarRelatorioPDF();
        }
    }
}

