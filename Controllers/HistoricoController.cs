using Microsoft.AspNetCore.Mvc;
using Taligado.Models;
using Taligado.Repositories;

namespace Taligado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoricoController : ControllerBase
    {
        private readonly IRepository<Historico> _repository;

        public HistoricoController(IRepository<Historico> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var historicos = await _repository.GetAllAsync();
            return Ok(historicos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Historico historico)
        {
            await _repository.AddAsync(historico);
            return CreatedAtAction(nameof(GetAll), new { id = historico.IdHistorico }, historico);
        }
    }

}
