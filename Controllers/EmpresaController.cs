using Microsoft.AspNetCore.Mvc;
using Taligado.Models;
using Taligado.Repositories;

namespace Taligado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly IRepository<Empresa> _repository;

        public EmpresaController(IRepository<Empresa> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var empresas = await _repository.GetAllAsync();
            return Ok(empresas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var empresa = await _repository.GetByIdAsync(id);
            if (empresa == null) return NotFound();
            return Ok(empresa);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Empresa empresa)
        {
            await _repository.AddAsync(empresa);
            return CreatedAtAction(nameof(GetById), new { id = empresa.IdEmpresa }, empresa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Empresa empresa)
        {
            if (id != empresa.IdEmpresa)
            {
                return BadRequest("O ID da empresa na URL não corresponde ao ID da entidade.");
            }

            var empresaExistente = await _repository.GetByIdAsync(id);
            if (empresaExistente == null)
            {
                return NotFound($"A empresa com ID {id} não foi encontrada.");
            }

            empresaExistente.Nome = empresa.Nome;
            empresaExistente.Email = empresa.Email;
            empresaExistente.CNPJ = empresa.CNPJ;
            empresaExistente.Segmento = empresa.Segmento;
            empresaExistente.DataFundacao = empresa.DataFundacao;

            await _repository.UpdateAsync(empresaExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var empresaExistente = await _repository.GetByIdAsync(id);
            if (empresaExistente == null)
            {
                return NotFound($"A empresa com ID {id} não foi encontrada.");
            }

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }


}
