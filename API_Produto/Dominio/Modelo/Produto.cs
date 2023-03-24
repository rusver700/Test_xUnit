namespace API_Produto.Dominio.Modelo
{
    public class Produto
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string? NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }

    }
}
