using Microsoft.AspNetCore.Mvc;
using ThoughtCatcher.Core.Interfaces;
using ThoughtCatcher.Core.Models;

namespace ThoughtCatcher.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThoughtController : ControllerBase
    {
        private readonly IThoughtRepository _repository;

        public ThoughtController(IThoughtRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Thought>>> GetAllThoughts()
        {
            var thoughts = await _repository.GetAllAsync();
            return Ok(thoughts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Thought>> GetThoughtById(int id)
        {
            var thought = await _repository.GetByIdAsync(id);
            if(thought == null)
                return NotFound();

            return Ok(thought);
        }

        [HttpPost]
        public async Task<ActionResult> CreateThought([FromBody] Thought thought)
        {
            await _repository.AddAsync(thought);
            return CreatedAtAction(nameof(GetThoughtById), new { id = thought.Id }, thought);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateThought(int id, [FromBody] Thought thought)
        {
            if(id != thought.Id)
                return BadRequest();

            var existing = await _repository.GetByIdAsync(id);
            if(existing == null)
                return NotFound();

            await _repository.UpdateAsync(thought);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteThought(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if(existing == null)
                return NotFound();

            await _repository.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("pong");
        }
    }
}

