using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KickerAPI.Data;
using KickerAPI.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace KickerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly KickerContext _context;

        public GamesController(KickerContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {
            return await _context.Games.ToListAsync();
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            var game = await _context.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        [HttpGet("GetByTournament/{id}")]
        public async Task<ActionResult<IEnumerable<Game>>> GetByTournament(int id)
        {
            var games = await _context.Games.Where(g => g.TournamentID == id).ToListAsync();

            if (games == null)
            {
                return NotFound();
            }

            return games;
        }

        [HttpGet("GetByTeam/{id}")]
        public async Task<ActionResult<IEnumerable<Game>>> GetByTeam(int id)
        {
            var games = await _context.Games.Where(g => g.TeamAID == id).ToListAsync();
            var gamesB = await _context.Games.Where(g => g.TeamBID == id).ToListAsync();
            games.AddRange(gamesB);

            if (games == null)
            {
                return NotFound();
            }

            return games;
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, Game game)
        {
            if (id != game.GameID)
            {
                return BadRequest();
            }

            _context.Entry(game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
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

        // POST: api/Games
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGame", new { id = game.GameID }, game);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Game>> Patch(int id, [FromBody] JsonPatchDocument<Game> patchDocument)
        {
            var entity = _context.Games.FirstOrDefault(game => game.GameID == id);

            if (entity == null)
            {
                return NotFound();
            }

            patchDocument.ApplyTo(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Game>> DeleteGame(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return game;
        }

        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.GameID == id);
        }
    }
}
