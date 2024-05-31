using Microsoft.AspNetCore.Mvc;
using Sistema_Rodonaves.Models;
using Sistema_Rodonaves.Repository.Interfaces;

namespace Sistema_Rodonaves.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> BuscarTodosUsuarios()
        {
            List<Usuario> usuarios = await _usuarioRepository.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> BuscarPorId(int id)
        {
            Usuario usuario = await _usuarioRepository.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> CadastrarUsuario([FromBody] Usuario usuarioModel)
        {
            Usuario usuario = await _usuarioRepository.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> AtualizaUsuario([FromBody] Usuario usuarioModel, int id)
        {
            usuarioModel.Id = id;
            Usuario usuario = await _usuarioRepository.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }
    }
}
