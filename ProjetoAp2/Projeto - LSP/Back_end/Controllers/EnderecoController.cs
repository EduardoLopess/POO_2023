using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Back_end.Models.Domain.DTOs;
using Back_end.Models.Domain.Entities;
using Back_end.Models.Domain.Interfaces;
using Back_end.Models.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;
        public EnderecoController(IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var endereco = await _enderecoRepository.GetAllAsync();
            var enderecoDTO = _mapper.Map<IList<EnderecoDTO>>(endereco);

            return
                HttpMessageOk(enderecoDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var endereco = await _enderecoRepository.GetByIdAsync(id);
            if (endereco == null) return NotFound();
            
            var enderecoDTO = _mapper.Map<EnderecoDTO>(endereco);
            return
                HttpMessageOk(enderecoDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(EnderecoViewModel enderecoViewModel, int institutoId, int pontoDoacaoId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados incorretos");
            }
            var endereco = _mapper.Map<Endereco>(enderecoViewModel);

            try
            {
                await _enderecoRepository.CreateAsync(endereco, institutoId, pontoDoacaoId);
                return Ok("Endereço criado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update (int id, EnderecoViewModel model)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");
            var endereco = _mapper.Map<Endereco>(model);
            endereco.Id = id;
            await _enderecoRepository.UpdateAsync(endereco);

            var addressDTO = _mapper.Map<EnderecoDTO>(endereco);
            return
                HttpMessageOk(addressDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            var endereco = await _enderecoRepository.GetByIdAsync(id);
            if (endereco == null) return NotFound();

            await _enderecoRepository.DeleteAsync(id);
            return
                HttpMessageOk($"Endereço deletado ID: {id}");
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