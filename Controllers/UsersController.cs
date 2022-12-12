using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tryitter.Context;
using Tryitter.Models;

namespace Tryitter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserOutput>>> GetUsers()
        {
            var usersDb = await _context.Users.ToListAsync();

            var users = new List<UserOutput>();

            usersDb.ForEach(user =>
                {
                    if (user?.IsDeleted == false)
                    {
                        users.Add(new UserOutput(user));
                    }
                });

            return users;
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<ActionResult<UserOutput>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return new UserOutput(user);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserInput userInput)
        {
            if (!UserExists(id))
            {
                return BadRequest();
            }

            var user = await _context.Users.FindAsync(id);

            user.Name = userInput.Name;
            user.Password = userInput.Password;
            user.Email = userInput.Email;
            user.Module = userInput.Module;
            user.Status = userInput.Status;

            _context.Entry(user).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserOutput>> PostUser(UserInput userInput)
        {
            var existsEmail = _context.Users.Any(e => e.Email == userInput.Email);
            if (existsEmail)
            {
                return BadRequest("Email já cadastrado.");
            }

            var user = userInput.ToInput();
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var userOutput = new UserOutput(user);

            return new CreatedAtRouteResult("GetUser", userOutput);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.IsDeleted = true;

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
