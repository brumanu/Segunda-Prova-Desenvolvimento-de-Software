using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/venda")]
    public class VendaController : ControllerBase
    {
        private readonly DataContext _context;
        public VendaController(DataContext context)
        {
            _context = context;
        }

        //GET: api/venda/list
        //ALTERAR O MÉTODO PARA MOSTRAR TODOS OS DADOS DA VENDA E OS DADOS RELACIONADOS
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> ListAsync() 
        {
            return Ok(await _context.Vendas.Include(x => x.FormaPagamento).Include(x => x.Itens).ThenInclude(x => x.Produto).ThenInclude(x => x.Categoria).AsNoTracking().ToListAsync());
        }
        // public async Task<IActionResult> ListAsync() => Ok(await _context.Vendas.ToListAsync());

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] Venda venda)
        {
            venda.FormaPagamento = _context.FormasPagamento.Find(venda.FormaPagamentoId);
            List<ItemVenda> itens = new List<ItemVenda>();
            foreach(ItemVenda itemVenda in venda.Itens){
                itens.Add(_context.ItensVenda.Find(itemVenda.ItemVendaId));
            }
            venda.Itens = itens;
            _context.Vendas.Add(venda);
            await _context.SaveChangesAsync();
            return Created("", venda);
        }
    }
}