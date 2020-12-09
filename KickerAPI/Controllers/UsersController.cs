using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KickerAPI.Data;
using KickerAPI.Models;
using Microsoft.AspNetCore.Authorization;
using KickerAPI.Services;
using BC = BCrypt.Net.BCrypt;

namespace KickerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private readonly KickerContext _context;

        public UsersController(IUserService userService, KickerContext context) { 
            _userService = userService;
            _context = context;
        }


        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var username = User.Claims.FirstOrDefault(c => c.Type == "Username").Value;
            return await _context.Users.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            user.Password = BC.HashPassword(user.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] User userParam)
        {
            //var user = _userService.Authenticate(userParam.Username, userParam.Password);
            var user = _context.Users.SingleOrDefault(x => x.Email == userParam.Username);

            if (user == null || !BC.Verify(userParam.Password, user.Password))
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }
    }
}
