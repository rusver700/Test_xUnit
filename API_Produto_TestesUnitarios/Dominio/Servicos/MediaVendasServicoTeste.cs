using API_Produto.Dominio.Interface;
using API_Produto.Dominio.Modelo;
using API_Produto.Dominio.Servicos;
using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;

namespace API_Produto_TestesUnitarios.Dominio.Servicos
{
    public class MediaVendasServicoTeste
    {
        private Mock<ILogger<MediaVendasServico>> _logger;
        private Mock<IRepositorioProduto> _mockRepositorioProduto;
        private readonly MediaVendasServico _mediaVendasServico;

        public MediaVendasServicoTeste()
        {
            var retorno = new List<Produto>
            {
                new Produto
                {
                    Id = 1,
                    Data = new DateTime(2023, 03,20),
                    Valor= 6000.00m,
                    Quantidade=1,
                    NomeProduto= "Motor",
                },
                 new Produto
                {
                    Id = 2,
                    Data = new DateTime(2023, 03,20),
                    Valor= 8000.00m,
                    Quantidade=2,
                    NomeProduto= "Inversor",
                },
                 new Produto
                {
                    Id = 3,
                    Data = new DateTime(2023, 02,10),
                    Valor= 1000.00m,
                    Quantidade=10,
                    NomeProduto= "Sensor",
                }
            };
            _mockRepositorioProduto = new Mock<IRepositorioProduto>();
            _mockRepositorioProduto.Setup(x => x.BuscarProdutos()).Returns(retorno);
            _logger = new Mock<ILogger<MediaVendasServico>>();
            _mediaVendasServico = new MediaVendasServico(_logger.Object, _mockRepositorioProduto.Object);
        }

        [Fact]
        public void RetornaSucessoProduto()
        {
            //Arrange
            var data = new DateTime(2023, 03, 20);

            //Action
            var result = _mediaVendasServico.CalcularMediaMensal(data);

            //Assert
            Assert.Equal(11000m, result);
        }

        [Fact]
        public void RetornaSucessoVerificaLogger()
        {
            //Arrange
            var data = new DateTime(2023, 02, 10);
            string message = $"Buscando produto no Banco de Dados com a data: {data}";

            //Action
            var result = _mediaVendasServico.CalcularMediaMensal(data);

            //Assert
            Assert.Equal(10000m, result);
            _mockRepositorioProduto.Verify(m => m.BuscarProdutos(), Times.Once());
            _logger.Verify(
                         x => x.Log(
                             It.Is<LogLevel>(l => l == LogLevel.Information),
                             It.IsAny<EventId>(),
                             It.Is<It.IsAnyType>((v, t) => v.ToString() ==  message),
                             It.IsAny<Exception>(),
                             It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Once());
            _logger.Verify(
                          x => x.Log(
                              It.Is<LogLevel>(l => l == LogLevel.Error),
                              It.IsAny<EventId>(),
                              It.Is<It.IsAnyType>((v, t) => v.ToString() == $"Erro: Nenhum produto com a Data : {data} encontrado"),
                              It.IsAny<Exception>(),
                              It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Never());

        }

        [Fact]
        public void RetornaExcessao()
        {
            //Arrange
            var data = new DateTime();

            //Action

            //Assert
            Assert.Throws<ArgumentException>(() => _mediaVendasServico.CalcularMediaMensal(data));
            _mockRepositorioProduto.Verify(m => m.BuscarProdutos(), Times.Once());
            _mockRepositorioProduto.Verify(m => m.BuscarProdutos(), Times.Exactly(1));
            _logger.Verify(
                          x => x.Log(
                              It.Is<LogLevel>(l => l == LogLevel.Error),
                              It.IsAny<EventId>(),
                              It.Is<It.IsAnyType>((v, t) => v.ToString() == $"Erro: Nenhum produto com a Data : {data} encontrado"),
                              It.IsAny<Exception>(),
                              It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Once());
        }

        [Fact]
        public void RetornaSucesso_Fixture()
        {
            //Arrange
            var fixture = new Fixture();

            var data = new DateTime(2023, 02, 10);
            var dataFixture = fixture.Build<Produto>()
              .With(x => x.Data, data)
              .Create<Produto>();

            //Action
            var result = _mediaVendasServico.CalcularMediaMensal(dataFixture.Data);

            //Assert
            Assert.Equal(10000m, result);
            _logger.Verify(
                        x => x.Log(
                            It.Is<LogLevel>(l => l == LogLevel.Information),
                            It.IsAny<EventId>(),
                            It.Is<It.IsAnyType>((v, t) => v.ToString() == $"Buscando produto no Banco de Dados com a data: {dataFixture.Data}"),
                            It.IsAny<Exception>(),
                            It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Once());
        }

        [Fact]
        public void RetornaExcecao_Fixture()
        {
            //Arrange
            var fixture = new Fixture();

            //Action

            //Assert
            Assert.Throws<ArgumentException>(() => _mediaVendasServico.CalcularMediaMensal(fixture.Create<Produto>().Data));
        }
    }
}