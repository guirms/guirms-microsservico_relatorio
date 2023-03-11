using Application.Interfaces;
using Infra.External.Repositories.EstacionaFacilRepository;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace Application.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IEstacionaFacilRepository _estacionaFacilRepository;
        public RelatorioService(IRabbitMqConfig messageConsumerService)
        {
            messageConsumerService.OnReceived += data =>
            {
                Console.WriteLine($"Foi solicitado um relatório das últimas {data.QtdLinhas} linhas");
                Thread.Sleep(1_000);
            };

            messageConsumerService.Listen();
        }

        public RelatorioService()
        {
            //_estacionaFacilRepository = estacionaFacilRepository;
        }

        public async Task<bool> GerarRelatorioPDF()
        {
            //var url = @"https://localhost:7253/Usuario/Teste";

            //HttpClient httpClient = new HttpClient();

            //MemoryStream memoryStream = new MemoryStream();
            //PdfDocument pdf = new PdfDocument(new PdfWriter(memoryStream));
            //Document documento = new Document(pdf);

            //documento.Add(new Paragraph("Este é um documento PDF gerado com iText7. rubi"));

            //documento.Close();

            //byte[] conteudoPdf = memoryStream.ToArray();
            //HttpContent content = new ByteArrayContent(conteudoPdf);

            //HttpResponseMessage response = await httpClient.PostAsync(url, content);

            //if (response.IsSuccessStatusCode)
            //{
            //    Console.WriteLine("Documento PDF enviado com sucesso.");
            //}

            // DPS DE PRONTO

            using (var memoryStream = new MemoryStream())
            {
                var pdf = new PdfDocument(new PdfWriter(memoryStream));
                var documento = new Document(pdf);

                documento.Add(new Paragraph("Este é um documento PDF gerado com iText7. rubi"));
                documento.Close();

                if (documento != null)
                {
                    var enviarRelatorio = await _estacionaFacilRepository.EnviarRelatorio(documento, memoryStream);
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
