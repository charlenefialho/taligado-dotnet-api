using Microsoft.AspNetCore.Mvc;
using Taligado.Models;
using Taligado.Repositories;

namespace Taligado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorController : ControllerBase
    {
        private readonly IRepository<Sensor> _repository;

        public SensorController(IRepository<Sensor> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sensores = await _repository.GetAllAsync();
            return Ok(sensores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sensor = await _repository.GetByIdAsync(id);
            if (sensor == null)
                return NotFound($"O sensor com ID {id} não foi encontrado.");
            return Ok(sensor);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Sensor sensor)
        {
            await _repository.AddAsync(sensor);
            return CreatedAtAction(nameof(GetById), new { id = sensor.IdSensor }, sensor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Sensor sensor)
        {
            if (id != sensor.IdSensor)
                return BadRequest("O ID do sensor na URL não corresponde ao ID da entidade.");

            var sensorExistente = await _repository.GetByIdAsync(id);
            if (sensorExistente == null)
                return NotFound($"O sensor com ID {id} não foi encontrado.");

            // Atualizar os campos
            sensorExistente.Tipo = sensor.Tipo;
            sensorExistente.Descricao = sensor.Descricao;
            sensorExistente.Unidade = sensor.Unidade;
            sensorExistente.ValorAtual = sensor.ValorAtual;
            sensorExistente.TempoOperacao = sensor.TempoOperacao;

            await _repository.UpdateAsync(sensorExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sensorExistente = await _repository.GetByIdAsync(id);
            if (sensorExistente == null)
                return NotFound($"O sensor com ID {id} não foi encontrado.");

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }

}
