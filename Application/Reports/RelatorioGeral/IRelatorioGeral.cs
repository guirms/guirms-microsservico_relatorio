using iText.Layout;

namespace Application.Reports.RelatorioGeral
{
    public interface IRelatorioGeral
    {
        public Document GerarRelatorioGeral(MemoryStream memory);
    }
}
