using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController, AllowAnonymous]
    [Route("Teste")]
    public class TesteController
    {
        [HttpPost("TesteConsole")]
        public void Imprimir(string texto)
        {
            Console.WriteLine(texto);
        }
    }
}

