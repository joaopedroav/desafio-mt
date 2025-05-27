using backend_mt.IRepositories;
using backend_mt.Models;
using backend_mt.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_mt.Repositories
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private BackendContext _context;

        public DepartamentoRepository(BackendContext context)
        {
            this._context = context;
        }

        public void CreateDepartamento(Departamento departamento)
        {
            departamento.ID = Guid.NewGuid();

            _context.Database.ExecuteSqlRaw(
                "INSERT INTO Departamento (ID, Codigo, Descricao) " +
                "VALUES ({0}, {1}, {2})",
                departamento.ID, departamento.Codigo, departamento.Descricao);
        }

        public ActionResult<IEnumerable<Departamento>> GetAllDepartamentos()
        {
            return _context.Departamentos
            .FromSqlRaw("SELECT * FROM Departamento")
            .AsNoTracking()
            .ToList();
        }
    }
}
