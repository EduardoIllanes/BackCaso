using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using WebApiCaso.Services;
using WebApiCaso.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace WebApiCaso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowOrigin")]
    public class UserController : ControllerBase
    {
        private readonly UserService _usersService;
        public UserController(UserService usersService) => _usersService = usersService;
       
            
        [HttpGet]
        public async Task<List<User>> Get() =>
                await _usersService.GetAsync();

        [HttpPost]
        public async Task<IActionResult> Post(User newUser)
        {
            var existingUser = await _usersService.GetByNameAsync(newUser.Name);
            if (existingUser != null)
            {
                return BadRequest("Ya existe un usuario con el mismo nombre");
            }
            await _usersService.CreateAsync(newUser);

            return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
        }


    }
}
