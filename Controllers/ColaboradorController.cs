using Microsoft.AspNetCore.Mvc;
using Sistema_Rodonaves.Models;
using Sistema_Rodonaves.DTO;
using Sistema_Rodonaves.Repository.Interfaces;

namespace Sistema_Rodonaves.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorController(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Colaboradore>>> BuscarTodosColaboradores()
        {
            List<Colaboradore> colaborador = await _colaboradorRepository.BuscarTodosColaboradores();
            return Ok(colaborador);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Colaboradore>> BuscarPorId(int id)
        {
            Colaboradore colaborador = await _colaboradorRepository.BuscarPorId(id);
            return Ok(colaborador);
        }

        [HttpPost]
        public async Task<ActionResult<ColaboradorDTO>> CadastrarColaborador([FromBody] ColaboradorDTO colaboradorModel)
        {
            ColaboradorDTO colaborador = await _colaboradorRepository.Adicionar(colaboradorModel);
            return Ok(colaborador);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Colaboradore>> AtualizaColaborador([FromBody] ColaboradorDTO colaboradorModel, int id)
        {
            colaboradorModel.Id = id;
            Colaboradore colaborador = await _colaboradorRepository.Atualizar(colaboradorModel, id);
            return Ok(colaborador);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Colaboradore>> ApagarColaborador(int id)
        {
            string apagado = await _colaboradorRepository.Apagar(id);
            return Ok(apagado);
        }
    }
}
