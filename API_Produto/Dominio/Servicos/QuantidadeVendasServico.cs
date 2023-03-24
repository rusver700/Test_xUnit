using API_Produto.Dominio.Interface;

namespace API_Produto.Dominio.Servicos
{
    public class QuantidadeVendasServico : IQuantidadeVendasServico
    {
        public string QuantidadeVendas(int quantidade)
        {
            if (quantidade == 0)
            {
                return "Nenhuma venda";
            }
            else
            {
                return quantidade >=1 && quantidade <= 10
                    ? $"Baixo volume de vendas. Apenas {quantidade} vendidos"
                    : "Bom volume de vendas. Total de " + quantidade + " vendidos.";
            }
        }
    }
}
