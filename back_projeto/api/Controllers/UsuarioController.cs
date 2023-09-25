using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Intarfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            var usuarioDTOs = _mapper.Map<IList<UsuarioDTO>>(usuarios);

            return
                HttpMessageOk(usuarioDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null) return NotFound();

            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
            return
                HttpMessageOk(usuarioDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(UsuarioViewModel modelUsuario, EnderecoViewModel modelEndereco)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");

            var usuario = _mapper.Map<Usuario>(modelUsuario);
            var endereco = _mapper.Map<Endereco>(modelEndereco);

            await _usuarioRepository.CreateAsync(usuario, endereco);

            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
            return HttpMessageOk(usuarioDTO);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update (int id, UsuarioViewModel model )
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");
            
            var usuario = _mapper.Map<Usuario>(model);
            usuario.Id = id;
            await _usuarioRepository.UpdateAsync(usuario);

            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
            return
                HttpMessageOk(usuarioDTO);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null) return NotFound();

            await _usuarioRepository.DeleteAsync(id);
            return 
                HttpMessageOk(id);        
        }


        private IActionResult HttpMessageOk(dynamic data = null)
        {
            if (data == null)
                return NoContent();
            else
                return Ok(new { data });
        }

        private IActionResult HttpMessageError(string message = "")
        {
            return BadRequest(new { message });
        }
    }
}