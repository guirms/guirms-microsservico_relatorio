using Application.Interfaces;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Application.Services
{
    public class RelatorioService : IRelatorioService
    {
        //private readonly IEstacionaFacilRepository _estacionaFacilRepository;
        //public RelatorioService(IRabbitMqConfig messageConsumerService)
        //{
        //    messageConsumerService.OnReceived += data =>
        //    {
        //        Console.WriteLine($"Foi solicitado um relatório das últimas {data.QtdLinhas} linhas");
        //        Thread.Sleep(1_000);
        //    };

        //    messageConsumerService.Listen();
        //}

        public RelatorioService()
        {
            //_estacionaFacilRepository = estacionaFacilRepository;
        }

        public async void GerarRelatorioPDF()
        {
            var url = @"https://localhost:7253/Usuario/Teste";

            //// cria um novo documento PDF
            //PdfDocument pdf = new PdfDocument(new PdfWriter("meuDocumento.pdf"));
            //Document documento = new Document(pdf);

            //// adiciona conteúdo ao documento
            //documento.Add(new Paragraph("Este é um documento PDF gerado com iText7."));

            //// fecha o documento
            //documento.Close();

            HttpClient httpClient = new HttpClient();

            //// lê o conteúdo do arquivo PDF
            //byte[] conteudoPdf = File.ReadAllBytes("meuDocumento.pdf");

            //// cria um objeto HttpContent com o conteúdo do arquivo PDF
            //HttpContent content = new ByteArrayContent(conteudoPdf);

            //// envia o POST com o arquivo PDF
            //HttpResponseMessage response = await httpClient.PostAsync(url, content);

            //// verifica se a requisição foi bem sucedida
            //if (response.IsSuccessStatusCode)
            //{
            //    Console.WriteLine("Documento PDF enviado com sucesso.");
            //}

            // NOVO

            // Cria um novo documento PDF
            MemoryStream memoryStream = new MemoryStream();
            PdfDocument pdf = new PdfDocument(new PdfWriter(memoryStream));
            Document documento = new Document(pdf);

            // Adiciona conteúdo ao documento
            documento.Add(new Paragraph("Este é um documento PDF gerado com iText7."));

            // Fecha o documento
            documento.Close();

            // Cria um objeto HttpContent com o conteúdo do arquivo PDF
            byte[] conteudoPdf = memoryStream.ToArray();
            HttpContent content = new ByteArrayContent(conteudoPdf);

            // Envia o POST com o arquivo PDF
            HttpResponseMessage response = await httpClient.PostAsync(url, content);

            // Verifica se a requisição foi bem sucedida
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Documento PDF enviado com sucesso.");
            }

            // DPS DE PRONTO

            //using (var memoryStream = new MemoryStream())
            //{
            //    var writer = new PdfWriter(memoryStream);
            //    var pdfDocument = new PdfDocument(writer);

            //    Paragraph p = new Paragraph("poggers")
            //        .SetTextAlignment(TextAlignment.CENTER)
            //        .SetFontSize(24);


            //    _estacionaFacilRepository.EnviarRelatorio(pdfDocument);
            //}
        }

        [Serializable]
        public class Profissao
        {
            public Profissao(int idProfissao, string nome)
            {
                IdProfissao = idProfissao;
                Nome = nome;
            }

            public int IdProfissao { get; set; }
            public string Nome { get; set; }
        }

        [Serializable]
        public class Pessoa
        {
            public Pessoa(int idPessoa, string nome, string sobrenome, double salario, Profissao profissao, bool empregado)
            {
                IdPessoa = idPessoa;
                Nome = nome;
                Sobrenome = sobrenome;
                Salario = salario;
                Profissao = profissao;
                Empregado = empregado;
            }

            public int IdPessoa { get; set; }
            public string Nome { get; set; }
            public string Sobrenome { get; set; }
            public double Salario { get; set; }
            public Profissao Profissao { get; set; }
            public bool Empregado { get; set; }
        }
    }
}
