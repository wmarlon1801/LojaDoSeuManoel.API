using LojaDoSeuManoel.API.Models;

namespace LojaDoSeuManoel.API.Services
{
    public class EmbalagemService
    {
        private readonly List<Caixa> _caixasDisponiveis;

        public EmbalagemService()
        {
            _caixasDisponiveis = new List<Caixa>
        {
            new Caixa { Id = 1, Altura = 30, Largura = 40, Comprimento = 80 },
            new Caixa { Id = 2, Altura = 80, Largura = 50, Comprimento = 40 },
            new Caixa { Id = 3, Altura = 50, Largura = 80, Comprimento = 60 },
        };
        }

        public List<Caixa> EmbalarProdutos(List<Produto> produtos)
        {            
            var produtosOrdenados = produtos
                .OrderByDescending(p => p.CalcularVolume())
                .ToList();

            var caixasUsadas = new List<Caixa>();

            foreach (var produto in produtosOrdenados)
            {
                bool adicionado = false;
               
                foreach (var caixa in caixasUsadas)
                {
                    if (caixa.TentarAdicionarProduto(produto))
                    {
                        adicionado = true;
                        break;
                    }
                }

                
                if (!adicionado)
                {
                    foreach (var caixaDisponivel in _caixasDisponiveis.OrderBy(c => c.Volume))
                    {
                        var novaCaixa = new Caixa
                        {
                            Id = caixaDisponivel.Id,
                            Altura = caixaDisponivel.Altura,
                            Largura = caixaDisponivel.Largura,
                            Comprimento = caixaDisponivel.Comprimento
                        };

                        if (novaCaixa.TentarAdicionarProduto(produto))
                        {
                            caixasUsadas.Add(novaCaixa);
                            break;
                        }
                    }
                }
            }
            return caixasUsadas;
        }
    }
}
