using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("Teste")]
    public class TesteController
    {
        [HttpPost("TesteConsole")]
        public void TesteConsole(string texto)
        {
            Console.WriteLine(texto);
        }
    }
}

