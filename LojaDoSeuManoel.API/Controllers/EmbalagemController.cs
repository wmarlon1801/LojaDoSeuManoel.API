using LojaDoSeuManoel.API.Models;
using LojaDoSeuManoel.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace LojaDoSeuManoel.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmbalagemController : ControllerBase
{
    private readonly EmbalagemService _embalagemService;

    public EmbalagemController()
    {
        _embalagemService = new EmbalagemService();
    }

    [HttpPost("embalar")]
    public IActionResult EmbalarPedido([FromBody] Pedido pedido)
    {
        if (pedido.Produtos == null || !pedido.Produtos.Any())
            return BadRequest("Pedido precisa conter ao menos um produto.");

        var caixasUsadas = _embalagemService.EmbalarProdutos(pedido.Produtos);

        var resposta = new
        {
            PedidoId = pedido.Id,
            Caixas = caixasUsadas.Select(caixa => new
            {
                CaixaId = caixa.Id,
                Dimensoes = new { caixa.Altura, caixa.Largura, caixa.Comprimento },
                Produtos = caixa.Produtos.Select(p => new
                {
                    p.Id,
                    p.Nome,
                    Dimensoes = new { p.Altura, p.Largura, p.Comprimento }
                })
            })
        };

        return Ok(resposta);
    }
}
