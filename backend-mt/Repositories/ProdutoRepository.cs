using backend_mt.IRepositories;
using backend_mt.Models;
using backend_mt.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace backend_mt.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private BackendContext _context;

        public ProdutoRepository(BackendContext context)
        {
            this._context = context;
        }

        public void CreateProduto(Produto produto)
        {
            produto.ID = Guid.NewGuid();

            _context.Database.ExecuteSqlRaw(
                "INSERT INTO Produto (ID, Codigo, Descricao, DepartamentoId, Preco, Status) " +
                "VALUES ({0}, {1}, {2}, {3}, {4}, {5})",
                produto.ID, produto.Codigo, produto.Descricao, produto.DepartamentoId, produto.Preco, produto.Status);
        }

        public bool DeleteProduto(Guid id)
        {
            int affectedRows = _context.Database.ExecuteSqlRaw("DELETE FROM Produto WHERE ID = {0}", id);

            return affectedRows > 0;
        }

        public ActionResult<IEnumerable<ProdutoGrid>> GetAllProdutos()
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.AppendLine("SELECT Produto.ID,");
            sqlQuery.AppendLine("    Produto.Codigo,");
            sqlQuery.AppendLine("    Produto.Descricao,");
            sqlQuery.AppendLine("    Departamento.Codigo || ' - ' || Departamento.Descricao AS Departamento, ");
            sqlQuery.AppendLine("    Departamento.ID AS DepartamentoId, ");
            sqlQuery.AppendLine("    Preco,");
            sqlQuery.AppendLine("    Status ");
            sqlQuery.AppendLine("FROM Produto");
            sqlQuery.AppendLine("    INNER JOIN Departamento ON Produto.DepartamentoId = Departamento.ID ");
            return _context.ProdutosGrid
            .FromSqlRaw(sqlQuery.ToString())
            .AsNoTracking()
            .ToList();
        }

        public ActionResult<Produto> GetProdutoById(Guid id)
        {
            return _context.Produtos
            .FromSqlRaw($"SELECT * FROM Produto WHERE ID = '{ id }'")
            .AsEnumerable()
            .FirstOrDefault();
        }

        public bool UpdateProduto(Produto produto)
        {
            int affectedRows = _context.Database.ExecuteSqlRaw(
                "UPDATE Produto SET Codigo = {0}, Descricao = {1}, DepartamentoId = {2}, Preco = {3}, Status = {4} " +
                "WHERE ID = {5}",
                produto.Codigo, produto.Descricao, produto.DepartamentoId, produto.Preco, produto.Status, produto.ID);

            return affectedRows > 0;
        }
    }
}
