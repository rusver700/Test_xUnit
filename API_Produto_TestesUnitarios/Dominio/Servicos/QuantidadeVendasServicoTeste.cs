using API_Produto.Dominio.Servicos;

namespace API_Produto_TestesUnitarios.Dominio.Servicos
{
    public class QuantidadeVendasServicoTeste
    {
        private readonly QuantidadeVendasServico _quantidadeVendas;

        public QuantidadeVendasServicoTeste()
        {
            _quantidadeVendas = new QuantidadeVendasServico();
        }

        [Fact]
        public void QuantidadeIgualZero()
        {
            //Arrange
            int quantidade =  0;

            //Act
            var result = _quantidadeVendas.QuantidadeVendas(quantidade);

            //Assert
           Assert.NotNull(result);
           Assert.Equal("Nenhuma venda", result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(10)]
        public void QuantidadeMaiorZeroMenorDez(int quantidade)
        {
            //Arrange

            //Act
            var result = _quantidadeVendas.QuantidadeVendas(quantidade);

            //Assert
            Assert.NotNull(result);
            Assert.Equal($"Baixo volume de vendas. Apenas {quantidade} vendidos", result);
        }

        [Theory] 
        [InlineData(11)]
        [InlineData(13)]
        [InlineData(16)]
        [InlineData(90)]
        public void QuantidadeMaiorDez(int quantidade)
        {
            //Arrange

            //Act
            var result = _quantidadeVendas.QuantidadeVendas(quantidade);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Bom volume de vendas. Total de " + quantidade + " vendidos.", result);
        }
    }
}
