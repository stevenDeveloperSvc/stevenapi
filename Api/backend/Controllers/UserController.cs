
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Services;

namespace backend.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public userServices _userServices;
        public UserController(userServices userServices)
        {
            _userServices = userServices;
        }

        // GET: api/User
        [HttpGet]
        public async Task<IEnumerable<User>> GetUser() => await _userServices.getAllUser();



        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUsers(int id)
        {
            var user = await _userServices.getUser(id);

            return user is null ? NotFound() : user;
        }


        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, User users)
        {
            var idUser = await _userServices.getById(id);
            if (idUser is not null)
            {
                _userServices.putUser(id, users);
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUsers(User user)
        {
            await _userServices.postUser(user);
            return CreatedAtAction("GetUsers", new { id = user.Id }, user);

        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers(int id)
        {
                var products = await _userServices.getById(id);
            if (products is null)
            {
                return NotFound();
            }

           await  _userServices.deleteUsers(products);

            return Ok();

        }


    }
}
