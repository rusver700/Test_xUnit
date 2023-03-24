using API_Produto.Dominio.Interface;

namespace API_Produto.Dominio.Servicos
{
    public class MediaVendasServico : IMediaVendasServico
    {
        private ILogger<MediaVendasServico> _logger;
        private readonly IRepositorioProduto _repositorioProduto;

        public MediaVendasServico(ILogger<MediaVendasServico> logger, IRepositorioProduto repositorioProduto)
        {
            _logger = logger;
            _repositorioProduto = repositorioProduto;
        }
        public decimal CalcularMediaMensal(DateTime data)
        {
            _logger.LogInformation($"Buscando produto no Banco de Dados com a data : {data}");

            var vendas = _repositorioProduto.BuscarProdutos().Where(x => x.Data == data);

            if (vendas.Count() > 0)
            {
                var vendasMensal = vendas.Sum(s => s.Valor * s.Quantidade) / vendas.Count();
                return Math.Round(vendasMensal, 2);
            }

            _logger.LogError("Erro: Nenhum produto com a Data : {data} encontrado", data);
            throw new Exception();
        }
    }
}