using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KickerAPI.Data;
using KickerAPI.Models;

namespace KickerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameTypesController : ControllerBase
    {
        private readonly KickerContext _context;

        public GameTypesController(KickerContext context)
        {
            _context = context;
        }

        // GET: api/GameTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameType>>> GetGameTypes()
        {
            return await _context.GameTypes.ToListAsync();
        }

        // GET: api/GameTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameType>> GetGameType(int id)
        {
            var gameType = await _context.GameTypes.FindAsync(id);

            if (gameType == null)
            {
                return NotFound();
            }

            return gameType;
        }

        // PUT: api/GameTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameType(int id, GameType gameType)
        {
            if (id != gameType.GameTypeID)
            {
                return BadRequest();
            }

            _context.Entry(gameType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameTypeExists(id))
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

        // POST: api/GameTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GameType>> PostGameType(GameType gameType)
        {
            _context.GameTypes.Add(gameType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameType", new { id = gameType.GameTypeID }, gameType);
        }

        // DELETE: api/GameTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GameType>> DeleteGameType(int id)
        {
            var gameType = await _context.GameTypes.FindAsync(id);
            if (gameType == null)
            {
                return NotFound();
            }

            _context.GameTypes.Remove(gameType);
            await _context.SaveChangesAsync();

            return gameType;
        }

        private bool GameTypeExists(int id)
        {
            return _context.GameTypes.Any(e => e.GameTypeID == id);
        }
    }
}
