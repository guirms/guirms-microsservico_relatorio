namespace Application.Interfaces
{
    public interface IRelatorioService
    {
        public Task<bool> GerarRelatorioPDF();
    }
}
