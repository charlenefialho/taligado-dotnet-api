using Microsoft.AspNetCore.Mvc;
using Taligado.Models;
using Taligado.Repositories;

namespace Taligado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertaController : ControllerBase
    {
        private readonly IRepository<Alerta> _repository;

        public AlertaController(IRepository<Alerta> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var alertas = await _repository.GetAllAsync();
            return Ok(alertas);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Alerta alerta)
        {
            await _repository.AddAsync(alerta);
            return CreatedAtAction(nameof(GetAll), new { id = alerta.IdAlerta }, alerta);
        }
    }

}
