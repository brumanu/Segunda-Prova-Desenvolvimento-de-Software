using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/inicializar")]
    public class InicializarDadosController : ControllerBase
    {
        private readonly DataContext _context;
        public InicializarDadosController(DataContext context)
        {
            _context = context;
        }

        //POST: api/inicializar/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create()
        {
            _context.FormasPagamento.AddRange(new FormaPagamento[]
                {
                    new FormaPagamento { FormaPagamentoId = 1, Nome = "Boleto", AVista =true },
                    new FormaPagamento { FormaPagamentoId = 2, Nome = "Pix", AVista =true },
                    new FormaPagamento { FormaPagamentoId = 3, Nome = "Cartão", AVista =false },
                }
            );
            _context.Categorias.AddRange(new Categoria[]
                {
                    new Categoria { CategoriaId = 1, Nome = "Celular" },
                }
            );
            _context.Produtos.AddRange(new Produto[]
                {
                    new Produto { ProdutoId = 1, Nome = "Galaxy s21 ultra", Preco = 5000.00, Quantidade = 5, CategoriaId = 1 },
                    new Produto { ProdutoId = 2, Nome = "Iphone 13", Preco = 6500.00, Quantidade = 15, CategoriaId = 1 },
                    new Produto { ProdutoId = 3, Nome = "Mi 11 Ultra ", Preco = 11000.00, Quantidade = 2, CategoriaId = 1 },
                }
            );
            _context.SaveChanges();
            return Ok(new { message = "Dados inicializados com sucesso!" });
        }
    }
}