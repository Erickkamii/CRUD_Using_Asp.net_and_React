using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {  
        private readonly ProdutoContexto _produtoContexto;
        public ProdutosController(ProdutoContexto produtoContexto)
        {
            _produtoContexto = produtoContexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos(){
            if(_produtoContexto.Produtos == null){
                return NotFound();
            }
            return await _produtoContexto.Produtos.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProdutos(int id){
            if(_produtoContexto.Produtos == null){
                return NotFound();
            }
            var produto = await _produtoContexto.Produtos.FindAsync(id);
            if(produto == null){
                return NotFound();
            }
            return produto;
        }
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto){
            _produtoContexto.Produtos.Add(produto);
            await _produtoContexto.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProdutos), new {id = produto.ID}, produto);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> PutProduto(int id, Produto produto)
        {
            if(id!=produto.ID)
            {
                return BadRequest();
            }
            _produtoContexto.Entry(produto).State = EntityState.Modified;
            try{
                await _produtoContexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduto(int id)
        {
            if(_produtoContexto.Produtos == null){
                return NotFound();
            }
            var produto = await _produtoContexto.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            _produtoContexto.Produtos.Remove(produto);
            await _produtoContexto.SaveChangesAsync();

            return Ok();
        }
    }
}