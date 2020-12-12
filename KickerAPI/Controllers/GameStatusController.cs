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
    public class GameStatusController : ControllerBase
    {
        private readonly KickerContext _context;

        public GameStatusController(KickerContext context)
        {
            _context = context;
        }

        // GET: api/GameStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameStatus>>> GetGameStatus()
        {
            return await _context.GameStatus.ToListAsync();
        }

        // GET: api/GameStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameStatus>> GetGameStatus(int id)
        {
            var gameStatus = await _context.GameStatus.FindAsync(id);

            if (gameStatus == null)
            {
                return NotFound();
            }

            return gameStatus;
        }
    }
}
