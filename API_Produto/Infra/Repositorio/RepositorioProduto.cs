using API_Produto.Dominio.Interface;
using API_Produto.Dominio.Modelo;

namespace API_Produto.Infra.Repositorio
{
    public class RepositorioProduto : IRepositorioProduto
    {
        public List<Produto> BuscarProdutos()
        {

            return new List<Produto>
            {
                new Produto
                {
                    Id = 1,
                    Data = new DateTime(2023, 03,20),
                    Valor= 6000.00m,
                    Quantidade=10,
                    NomeProduto= "Motor",
                },
                 new Produto
                {
                    Id = 2,
                    Data = new DateTime(2023, 03,20),
                    Valor= 8000.00m,
                    Quantidade=5,
                    NomeProduto= "Inversor",
                },
                 new Produto
                {
                    Id = 3,
                    Data = new DateTime(2023, 03,20),
                    Valor= 1000.00m,
                    Quantidade=10,
                    NomeProduto= "Sensor",
                },
                 new Produto
                {
                    Id = 4,
                    Data = new DateTime(2023, 01,26),
                    Valor= 30000.00m,
                    Quantidade=1,
                    NomeProduto= "CLP",
                },
                new Produto
                {
                    Id = 5,
                    Data = new DateTime(2023, 01,26),
                    Valor= 60.00m,
                    Quantidade=10,
                    NomeProduto= "Lampada",
                },
                 new Produto
                {
                    Id = 6,
                    Data = new DateTime(2023, 02,05),
                    Valor= 50000.00m,
                    Quantidade=0,
                    NomeProduto= "SoftStart",
                },
                 new Produto
                {
                    Id = 7,
                    Data = new DateTime(2023, 03,23),
                    Valor= 1000.00m,
                    Quantidade=10,
                    NomeProduto= "Sensor",
                },
                 new Produto
                {
                    Id = 8,
                    Data = new DateTime(2023, 03,23),
                    Valor= 300.00m,
                    Quantidade=1,
                    NomeProduto= "Contatora",
                }
            };
        }
    }
}
