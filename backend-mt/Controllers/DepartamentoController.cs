using backend_mt.IRepositories;
using backend_mt.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend_mt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private IDepartamentoRepository _departamentoRepository;

        public DepartamentoController(IDepartamentoRepository departamentoRepository)
        {
            this._departamentoRepository = departamentoRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Departamento>> GetAllDepartamentos()
        {
            return Ok(_departamentoRepository.GetAllDepartamentos());
        }

        [HttpPost("create")]
        public ActionResult<Produto> CreateDepartamento(Departamento departamento)
        {
            _departamentoRepository.CreateDepartamento(departamento);
            return Ok();
        }
    }
}
