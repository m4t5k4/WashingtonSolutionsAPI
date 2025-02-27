﻿using System;
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
    public class TeamsController : ControllerBase
    {
        private readonly KickerContext _context;

        public TeamsController(KickerContext context)
        {
            _context = context;
        }

        // GET: api/Teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            return await _context.Teams.Include(t => t.TeamUsers).ToListAsync();
        }

        // GET: api/Teams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            var team = await _context.Teams.Include(t => t.TeamUsers).FirstOrDefaultAsync(t => t.TeamID == id);

            if (team == null)
            {
                return NotFound();
            }

            return team;
        }

        [HttpGet("ByGroup/{id}")]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeamsByGroupID(int id)
        {
            return await _context.Teams.Where(t => t.GroupID == id).Include(t => t.TeamUsers).ToListAsync();
        }

        // PUT: api/Teams/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, Team team)
        {
            if (id != team.TeamID)
            {
                return BadRequest();
            }

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
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

        // POST: api/Teams
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeam", new { id = team.TeamID }, team);
        }

        [HttpPost("teamuser")]
        public async Task<ActionResult<TeamUser>> PostTeamUser(TeamUser teamUser)
        {
            _context.TeamUsers.Add(teamUser);
            await _context.SaveChangesAsync();
            return teamUser;
        }

        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Team>> DeleteTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return team;
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.TeamID == id);
        }
    }
}
