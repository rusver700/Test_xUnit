using API_Produto.Dominio.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace API_Produto.Controllers
{
    [ExcludeFromCodeCoverage]

    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IRepositorioProduto _repositorioProduto;
        private readonly IMediaVendasServico _vendasServico;
        private readonly IQuantidadeVendasServico _quantidadeVendas;

        public ProdutoController(IRepositorioProduto repositorioProduto, IMediaVendasServico vendasServico, IQuantidadeVendasServico estoqueServico)
        {
            _repositorioProduto = repositorioProduto;
            _vendasServico = vendasServico;
            _quantidadeVendas = estoqueServico;
        }

        [HttpGet("Dados_Repositorio")] 
        public ActionResult RepositorioProduto() 
        {
            var response = _repositorioProduto.BuscarProdutos();

            return Ok( response); 
        }

        [HttpGet("Media_Venda_Mensal/{data}")]
        public ActionResult MediaVendaMensalProduto(DateTime data)
        {
            var produto = _repositorioProduto.BuscarProdutos().FirstOrDefault(x => x.Data == data);

            if (produto != null)
            {
                var response = _vendasServico.CalcularMediaMensal(produto.Data);
                return Ok(response);
            }

            return NotFound();
        }

        [HttpGet("Quantidade_Vendas/{id}")]
        public ActionResult QuantidadeVendaProduto(int id)
        {
            var produto = _repositorioProduto.BuscarProdutos().FirstOrDefault(x => x.Id == id);

            if (produto != null)
            {
                var response = _quantidadeVendas.QuantidadeVendas(produto.Quantidade);
                return Ok(response);
            }

            return NotFound();
        }
    }
}
