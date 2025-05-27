using backend_mt.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend_mt.IRepositories
{
    public interface IProdutoRepository
    {
        ActionResult<IEnumerable<ProdutoGrid>> GetAllProdutos();
        ActionResult<Produto> GetProdutoById(Guid id);
        void CreateProduto(Produto produto);
        bool UpdateProduto(Produto produto);
        bool DeleteProduto(Guid id);
    }
}
