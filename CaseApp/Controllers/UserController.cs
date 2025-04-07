using Microsoft.AspNetCore.Mvc;
using CaseApp.Repositories;
using CaseApp.Klasser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseApp.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepo;

        public UserController(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        // GET: api/user
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await userRepo.GetAll();
        }

        // GET: api/user/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await userRepo.GetUser(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // POST: api/user
        [HttpPost]
        public async Task<IActionResult> Add(User user)
        {
            await userRepo.AddUser(user);
            return Ok();
        }

        // PUT: api/user
        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            await userRepo.UpdateUser(user);
            return Ok();
        }

        // DELETE: api/user/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await userRepo.DeleteUser(id);
            return Ok();
        }
    }
}
