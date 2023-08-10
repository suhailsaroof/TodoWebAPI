using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoWebAPI.Data;

namespace TodoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodolistController : Controller
    {
        private readonly todoAPIDbContext _context;

        public TodolistController(todoAPIDbContext context)
        {
            _context = context;
        }

        // GET: api/todolist
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbltodolist>>> Gettodolists()
        {
            return Ok(await _context.Tbltodolist.ToListAsync());
        }

        // GET: api/todolist/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbltodolist>> Gettodolist(long id)
        {
            var todolist = await _context.Tbltodolist.FindAsync(id);

            if (todolist == null)
            {
                return NotFound();
            }

            return todolist;
        }

        // POST: api/todolist
        [HttpPost]
        public async Task<ActionResult<Tbltodolist>> CreateTodolist(Tbltodolist todolist)
        {
            _context.Tbltodolist.Add(todolist);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Gettodolist), new { id = todolist.Id }, todolist);
        }

        // PUT: api/todolist/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodolist(long id, Tbltodolist todolist)
        {
            if (id != todolist.Id)
            {
                return BadRequest();
            }

            _context.Entry(todolist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodolistExists(id))
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
        public async Task<IActionResult> DeleteTodolist(long id)
        {
            var todolist = await _context.Tbltodolist.FindAsync(id);
            if (todolist == null)
            {
                return NotFound();
            }

            _context.Tbltodolist.Remove(todolist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodolistExists(long id)
        {
            return _context.Tbltodolist.Any(e => e.Id == id);
        }
    }
}
