using Microsoft.AspNetCore.Mvc;
using Sistema_Rodonaves.Models;
using Sistema_Rodonaves.Repository.Interfaces;

namespace Sistema_Rodonaves.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadeController : ControllerBase
    {
        private readonly IUnidadeRepository _unidadeRepository;

        public UnidadeController(IUnidadeRepository unidadeRepository)
        {
            _unidadeRepository = unidadeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Unidade>>> BuscarTodasUnidades()
        {
            List<Unidade> unidades = await _unidadeRepository.BuscarTodasUnidades();
            return Ok(unidades);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Unidade>> BuscarPorId(int id)
        {
            Unidade unidades = await _unidadeRepository.BuscarPorId(id);
            return Ok(unidades);
        }

        [HttpPost]
        public async Task<ActionResult<Unidade>> CadastrarUsuario([FromBody] Unidade unidadeModel)
        {
            Unidade unidades = await _unidadeRepository.Adicionar(unidadeModel);
            return Ok(unidades);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unidade>> AtualizaUsuario([FromBody] Unidade unidadeModel, int id)
        {
            unidadeModel.Id = id;
            Unidade usuario = await _unidadeRepository.Atualizar(unidadeModel, id);
            return Ok(usuario);
        }
    }
}
