using backend_mt.Models;
using backend_mt.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace backend_mt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            this._produtoRepository = produtoRepository;
        }

        /// <summary>
        /// Obtém uma lista de produtos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<ProdutoGrid>> GetAllProdutos()
        {
            return Ok(_produtoRepository.GetAllProdutos());
        }

        /// <summary>
        /// Obtém um produto
        /// </summary>
        /// <param name="id">Id do produto a ser obtido</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Produto> GetProdutoById(Guid id)
        {
            var produto = _produtoRepository.GetProdutoById(id);
            if (!(produto is object))
            {
                return NotFound();
            }

            return Ok(produto);
        }

        /// <summary>
        /// Adiciona um novo produto na base de dados
        /// </summary>
        /// <param name="produto">Objeto contendo os atributos do produto a ser adicionado</param>
        /// <returns></returns>
        [HttpPost("create")]
        public ActionResult<Produto> CreateProduto(Produto produto)
        {
            _produtoRepository.CreateProduto(produto);
            return CreatedAtAction(nameof(GetProdutoById), new { id = produto.ID }, produto);
        }

        /// <summary>
        /// Atualiza um produto já existente na base de dados
        /// </summary>
        /// <param name="produto">Objeto contendo os atributos do produto a serem atualizados</param>
        /// <returns></returns>
        [HttpPost("update")]
        public ActionResult<Produto> UpdateProduto(Produto produto)
        {
            if (!_produtoRepository.UpdateProduto(produto))
                return NotFound();

            return Ok(produto);
        }

        /// <summary>
        /// Remove produto da base de dados
        /// </summary>
        /// <param name="id">Id do produto a ser removido</param>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteProduto(Guid id)
        {
            if (!_produtoRepository.DeleteProduto(id))
                return NotFound();

            return Ok();
        }
    }
}
