using Microsoft.AspNetCore.Mvc;
using Taligado.Models;
using Taligado.Repositories;

namespace Taligado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilialController : ControllerBase
    {
        private readonly IRepository<Filial> _repository;

        public FilialController(IRepository<Filial> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var filiais = await _repository.GetAllAsync();
            return Ok(filiais);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var filial = await _repository.GetByIdAsync(id);
            if (filial == null) return NotFound($"A filial com ID {id} não foi encontrada.");
            return Ok(filial);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Filial filial)
        {
            await _repository.AddAsync(filial);
            return CreatedAtAction(nameof(GetById), new { id = filial.IdFilial }, filial);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Filial filial)
        {
            if (id != filial.IdFilial)
                return BadRequest("O ID da filial na URL não corresponde ao ID da entidade.");

            var filialExistente = await _repository.GetByIdAsync(id);
            if (filialExistente == null)
                return NotFound($"A filial com ID {id} não foi encontrada.");

            // Atualizar os campos
            filialExistente.Nome = filial.Nome;
            filialExistente.Tipo = filial.Tipo;
            filialExistente.CNPJ_Filial = filial.CNPJ_Filial;
            filialExistente.Area_Operacional = filial.Area_Operacional;
            filialExistente.Empresa_IdEmpresa = filial.Empresa_IdEmpresa;
            filialExistente.Endereco_IdEndereco = filial.Endereco_IdEndereco;

            await _repository.UpdateAsync(filialExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var filialExistente = await _repository.GetByIdAsync(id);
            if (filialExistente == null)
                return NotFound($"A filial com ID {id} não foi encontrada.");

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }

}
