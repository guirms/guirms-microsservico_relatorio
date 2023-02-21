using Application.Interfaces;

namespace Application.Services
{
    public class RelatorioService: IRelatorioService
    {
        public RelatorioService(IRabbitMqConfig messageConsumerService)
        {
            messageConsumerService.OnReceived += data =>
            {
                Console.WriteLine($"Foi solicitado um relatório das últimas {data.QtdLinhas} linhas");
                Thread.Sleep(1_000);
            };

            messageConsumerService.Listen();
        }

        public void Teste()
        {
            Console.WriteLine("Teste");
        }
    }
}
