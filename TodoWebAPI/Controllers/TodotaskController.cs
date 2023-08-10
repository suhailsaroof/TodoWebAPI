using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoWebAPI.Data;
using TodoWebAPI.Model;

namespace TodoWebAPI.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class TodotaskController : Controller
        {
            private readonly todoAPIDbContext _context;

            public TodotaskController(todoAPIDbContext context)
            {
                _context = context;
            }

            // GET: api/todolist
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Tbltodotask>>> Gettodolists()
            {
                return Ok(await _context.Tbltodotask.ToListAsync());
            }

            // GET: api/todolist/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Tbltodotask>> Gettodolist(long id)
            {
                var todotask = await _context.Tbltodotask.FindAsync(id);

                if (todotask == null)
                {
                    return NotFound();
                }

                return todotask;
            }

            // POST: api/todolist
            [HttpPost]
            public async Task<ActionResult<Tbltodotask>> CreateTodotask(Tbltodotask todotask)
            {
                _context.Tbltodotask.Add(todotask);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(Gettodolist), new { id = todotask.Id }, todotask);
            }

            // PUT: api/todolist/5
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateTodotask(long id, Tbltodotask todotask)
            {
                if (id != todotask.Id)
                {
                    return BadRequest();
                }

                _context.Entry(todotask).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodotaskExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }

            // DELETE: api/todolist/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteTodotask(long id)
            {
                var todotask = await _context.Tbltodotask.FindAsync(id);
                if (todotask == null)
                {
                    return NotFound();
                }

                _context.Tbltodotask.Remove(todotask);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool TodotaskExists(long id)
            {
                return _context.Tbltodotask.Any(e => e.Id == id);
            }
        }
    }

