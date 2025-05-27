using backend_mt.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend_mt.IRepositories
{
    public interface IDepartamentoRepository
    {
        ActionResult<IEnumerable<Departamento>> GetAllDepartamentos();
        void CreateDepartamento(Departamento departamento);
    }
}
