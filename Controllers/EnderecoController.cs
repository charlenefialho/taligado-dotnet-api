using Microsoft.AspNetCore.Mvc;
using Taligado.Models;
using Taligado.Repositories;

namespace Taligado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IRepository<Endereco> _repository;

        public EnderecoController(IRepository<Endereco> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var enderecos = await _repository.GetAllAsync();
            return Ok(enderecos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var endereco = await _repository.GetByIdAsync(id);
            if (endereco == null) return NotFound($"O endereço com ID {id} não foi encontrado.");
            return Ok(endereco);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Endereco endereco)
        {
            await _repository.AddAsync(endereco);
            return CreatedAtAction(nameof(GetById), new { id = endereco.IdEndereco }, endereco);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Endereco endereco)
        {
            if (id != endereco.IdEndereco)
                return BadRequest("O ID do endereço na URL não corresponde ao ID da entidade.");

            var enderecoExistente = await _repository.GetByIdAsync(id);
            if (enderecoExistente == null)
                return NotFound($"O endereço com ID {id} não foi encontrado.");

            // Atualizar os campos
            enderecoExistente.Logradouro = endereco.Logradouro;
            enderecoExistente.Cidade = endereco.Cidade;
            enderecoExistente.Estado = endereco.Estado;
            enderecoExistente.CEP = endereco.CEP;
            enderecoExistente.Pais = endereco.Pais;

            await _repository.UpdateAsync(enderecoExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var enderecoExistente = await _repository.GetByIdAsync(id);
            if (enderecoExistente == null)
                return NotFound($"O endereço com ID {id} não foi encontrado.");

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }

}
