using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using WebApiCaso.Services;
using WebApiCaso.Models;

namespace WebApiCaso.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            await _usersService.CreateAsync(newUser);

            return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
        }


    }
}
