using Application.Interfaces;
using Application.Reports.RelatorioGeral;
using Infra.External.Repositories.EstacionaFacilRepository;

namespace Application.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IEstacionaFacilRepository _estacionaFacilRepository;

        //public RelatorioService(IRabbitMqConfig messageConsumerService, IEstacionaFacilRepository estacionaFacilRepository)
        //{
        //    messageConsumerService.OnReceived += data =>
        //    {
        //        Console.WriteLine($"Foi solicitado um relatório das últimas {data.QtdLinhas} linhas");
        //        Thread.Sleep(1_000);
        //    };

        //    messageConsumerService.Listen();

        //    _estacionaFacilRepository = estacionaFacilRepository;
        //}

        public RelatorioService(IEstacionaFacilRepository estacionaFacilRepository)
        {
            _estacionaFacilRepository = estacionaFacilRepository;
        }

        public async Task<bool> GerarRelatorioPDF()
        {
            using (var memory = new MemoryStream())
            {
                var documento = RelatorioGeral.GerarRelatorioGeral(memory);

                if (documento != null)
                {
                    var enviarRelatorio = await _estacionaFacilRepository.EnviarRelatorio(documento, memory);
                    return enviarRelatorio.IsSuccessStatusCode;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
