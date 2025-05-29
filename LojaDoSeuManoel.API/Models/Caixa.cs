namespace LojaDoSeuManoel.API.Models
{
    public class Caixa
    {
        public int Id { get; set; }
        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Comprimento { get; set; }

        public List<Produto> Produtos { get; set; } = new();

        public int Volume => Altura * Largura * Comprimento;

        public bool TentarAdicionarProduto(Produto produto)
        {
            int volumeUsado = Produtos.Sum(p => p.CalcularVolume());
            if (volumeUsado + produto.CalcularVolume() <= Volume)
            {
                Produtos.Add(produto);
                return true;
            }

            return false;
        }
    }
}
