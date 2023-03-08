using Application.Interfaces;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace Application.Services
{
    public class RelatorioService : IRelatorioService
    {
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
            
        }

        public void GerarRelatorioPDF()
        {
            #region CriandoListaFake

            var pessoa1 = new Pessoa(1, "João", "Do Caminhão", 2500, new Profissao(1, "Caminhoneiro"), true);
            var pessoa2 = new Pessoa(2, "Amilton", "Chinelo", 0, new Profissao(2, "Vadio"), false);

            var pessoas = new List<Pessoa>
            {
                pessoa1,
                pessoa2
            };

            #endregion

            PdfWriter writer = new PdfWriter(@"C:\Users\user\Desktop\arquivo.pdf");
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            Paragraph p = new Paragraph("poggers")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(24);
            document.Add(p);

            document.Close();
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
