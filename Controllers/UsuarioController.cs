using Microsoft.AspNetCore.Mvc;
using Sistema_Rodonaves.DTO;
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

        [NonAction]
        public List<UsuarioDTO> BuscarUsuarios(List<Usuario> usuarios)
        {
            List<UsuarioDTO> usuariosDTO = new List<UsuarioDTO>();

            foreach (var u in usuarios)
            {
                var usuarioView = new UsuarioDTO()
                {
                    Id = u.Id,
                    Login = u.Login,
                    Status = u.Status
                };
                usuariosDTO.Add(usuarioView);
            }
            return usuariosDTO;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioDTO>>> BuscarTodosUsuarios()
        {
            List<Usuario> usuarios = await _usuarioRepository.BuscarTodosUsuarios();
            
            if(usuarios.Count == 0)
            {
                return NotFound("Nenhum usuário encontrado");
            }

            var usuarioModel = BuscarUsuarios(usuarios);
            return Ok(usuarioModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> BuscarPorId(int id)
        {
            Usuario usuario = await _usuarioRepository.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<List<UsuarioDTO>>> BuscarPorStatus(int status)
        {
            List<Usuario> usuarios = await _usuarioRepository.BuscarPorStatus(status);

            if(usuarios.Count == 0)
            {
                return NotFound("Nenhum usuário com status informado foi encontrado...");
            }
            var usuarioModel = BuscarUsuarios(usuarios);
            return Ok(usuarioModel);

        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> CadastrarUsuario([FromBody] Usuario usuarioModel)
        {
            Usuario usuario = await _usuarioRepository.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> AtualizaUsuario([FromBody] UsuarioAlteraDTO usuarioModel, int id)
        {
            usuarioModel.Id = id;
            Usuario usuario = await _usuarioRepository.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }
    }
}
