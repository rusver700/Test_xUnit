using API_Produto.Dominio.Interface;
using API_Produto.Dominio.Modelo;
using API_Produto.Infra.Repositorio;
using Moq;

namespace API_Produto_TestesUnitarios.Infra.Repositorio
{
    public class RepositorioProdutoTeste
    {
        [Fact]
        public void DadosRepositorio()
        {
            //Arrange
            var repositorio = new RepositorioProduto();

            //Act
            var result = repositorio.BuscarProdutos();

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);

            Assert.Equal("Motor", result[0].NomeProduto);
            Assert.Equal("Inversor", result[1].NomeProduto);
            Assert.Equal("Sensor", result[2].NomeProduto);
            Assert.Equal("CLP", result[3].NomeProduto);
            Assert.Equal("Lampada", result[4].NomeProduto);
            Assert.Equal("SoftStart", result[5].NomeProduto);
            Assert.Equal("Sensor", result[6].NomeProduto);
            Assert.Equal("Contatora", result[7].NomeProduto);
            Assert.Equal("Cabo 50mm", result[8].NomeProduto);

            Assert.NotNull( result[0].NomeProduto);
            Assert.NotNull( result[1].NomeProduto);
            Assert.NotNull( result[2].NomeProduto);
            Assert.NotNull( result[3].NomeProduto);
            Assert.NotNull( result[4].NomeProduto);
            Assert.NotNull( result[5].NomeProduto);
            Assert.NotNull( result[6].NomeProduto);
            Assert.NotNull( result[7].NomeProduto);
            Assert.NotNull( result[8].NomeProduto);

        }
        [Fact]
        public void DadosMock_Repositorio()
        {
            //Arrange
            var repositorio = new Mock<RepositorioProduto>();

            //Act
            var result = repositorio.Object.BuscarProdutos();

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("Motor", result[0].NomeProduto);

        }

        [Fact]
        public void DadosMock_IRepositorio()
        {
            //Arrange
            var retorno = new List<Produto>
            {
                new Produto
                {
                    Id = 1,
                    Data = new DateTime(2023, 03,20),
                    Valor = 8000.00m,
                    Quantidade = 2,
                    NomeProduto = "CLP",
                }
             };

            var repositorio = new Mock<IRepositorioProduto>();
            repositorio.Setup(x => x.BuscarProdutos()).Returns(retorno);

            //Act
            var result = repositorio.Object.BuscarProdutos();

            //Assert
            Assert.NotEmpty(result);
            Assert.NotNull(result);
            Assert.NotNull(result[0].NomeProduto);
            Assert.Equal("CLP", result[0].NomeProduto);
            Assert.Equal(retorno, result);
        }

        [Fact]
        public void DadosMock_IRepositorioVazio()
        {
            //Arrange
            var retorno = new List<Produto> { };

            var repositorio = new Mock<IRepositorioProduto>();
            repositorio.Setup(x => x.BuscarProdutos()).Returns(retorno);

            //Act
            var result = repositorio.Object.BuscarProdutos();

            //Assert
            Assert.Empty(result);
            Assert.Equal(retorno, result);
        }
    }
}
