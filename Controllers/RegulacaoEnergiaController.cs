using Microsoft.AspNetCore.Mvc;
using Taligado.Models;
using Taligado.Repositories;

namespace Taligado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegulacaoEnergiaController : ControllerBase
    {
        private readonly IRepository<RegulacaoEnergia> _repository;

        public RegulacaoEnergiaController(IRepository<RegulacaoEnergia> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regulacoes = await _repository.GetAllAsync();
            return Ok(regulacoes);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegulacaoEnergia regulacao)
        {
            await _repository.AddAsync(regulacao);
            return CreatedAtAction(nameof(GetAll), new { id = regulacao.IdRegulacao }, regulacao);
        }
    }

}
