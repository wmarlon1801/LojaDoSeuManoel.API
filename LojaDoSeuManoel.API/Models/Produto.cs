namespace LojaDoSeuManoel.API.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Comprimento {  get; set; }
        
        public int CalcularVolume() => Altura * Largura * Comprimento;
    }
}
