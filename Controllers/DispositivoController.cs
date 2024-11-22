using Microsoft.AspNetCore.Mvc;
using Taligado.Models;
using Taligado.Repositories;

namespace Taligado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DispositivoController : ControllerBase
    {
        private readonly IRepository<Dispositivo> _repository;

        public DispositivoController(IRepository<Dispositivo> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dispositivos = await _repository.GetAllAsync();
            return Ok(dispositivos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dispositivo = await _repository.GetByIdAsync(id);
            if (dispositivo == null)
                return NotFound($"O dispositivo com ID {id} não foi encontrado.");
            return Ok(dispositivo);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Dispositivo dispositivo)
        {
            await _repository.AddAsync(dispositivo);
            return CreatedAtAction(nameof(GetById), new { id = dispositivo.IdDispositivo }, dispositivo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Dispositivo dispositivo)
        {
            if (id != dispositivo.IdDispositivo)
                return BadRequest("O ID do dispositivo na URL não corresponde ao ID da entidade.");

            var dispositivoExistente = await _repository.GetByIdAsync(id);
            if (dispositivoExistente == null)
                return NotFound($"O dispositivo com ID {id} não foi encontrado.");

            // Atualizar os campos
            dispositivoExistente.Nome = dispositivo.Nome;
            dispositivoExistente.Tipo = dispositivo.Tipo;
            dispositivoExistente.Status = dispositivo.Status;
            dispositivoExistente.DataInstalacao = dispositivo.DataInstalacao;
            dispositivoExistente.Filial_IdFilial = dispositivo.Filial_IdFilial;
            dispositivoExistente.PotenciaNominal = dispositivo.PotenciaNominal;

            await _repository.UpdateAsync(dispositivoExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dispositivoExistente = await _repository.GetByIdAsync(id);
            if (dispositivoExistente == null)
                return NotFound($"O dispositivo com ID {id} não foi encontrado.");

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }

}
