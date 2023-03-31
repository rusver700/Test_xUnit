using API_Produto.Dominio.Interface;

namespace API_Produto.Dominio.Servicos
{
    public class MediaVendasServico : IMediaVendasServico
    {
        private readonly ILogger<MediaVendasServico> _loggerMediaVendasServico;
        private readonly IRepositorioProduto _repositorioProduto;

        public MediaVendasServico(ILogger<MediaVendasServico> logger, IRepositorioProduto repositorioProduto)
        {
            _loggerMediaVendasServico = logger;
            _repositorioProduto = repositorioProduto;
        }
        public decimal CalcularMediaMensal(DateTime data)
        {
            _loggerMediaVendasServico.LogInformation($"Buscando produto no Banco de Dados com a data: {data}");

            var vendas = _repositorioProduto.BuscarProdutos().Where(x => x.Data == data);

            if (!vendas.Any())
            {
                _loggerMediaVendasServico.LogError("Erro: Nenhum produto com a Data : {data} encontrado", data);
                throw new ArgumentException(data.ToString());
            }

            var vendasMensal = vendas.Sum(s => s.Valor * s.Quantidade) / vendas.Count();
            return Math.Round(vendasMensal, 2);
        }
    }
}