using API_Produto.Dominio.Modelo;

namespace API_Produto.Dominio.Interface
{
    public interface IRepositorioProduto
    {
        List<Produto> BuscarProdutos();
    }
}
