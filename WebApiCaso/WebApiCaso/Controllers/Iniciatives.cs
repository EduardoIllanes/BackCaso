using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApiCaso.Models;
using WebApiCaso.Services;

namespace WebApiCaso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowOrigin")]
    public class IniciativesController : Controller
    {
        private readonly IniciativeService _iniciativesService;
        private readonly UserService _userService;
        public IniciativesController(IniciativeService iniciativesService, UserService userService)
        {
            _iniciativesService = iniciativesService;
            _userService = userService;
        }
        
        [HttpGet]
        public async Task<List<Iniciative>> Get() =>
                await _iniciativesService.GetAsync();

        [HttpPost]
        public async Task<IActionResult> Post(Iniciative newIniciative)
        {
            if (string.IsNullOrWhiteSpace(newIniciative.Name) || string.IsNullOrWhiteSpace(newIniciative.Description))
            {
                return BadRequest("El nombre y la descripción no pueden estar vacíos.");
            }
            var user = await _userService.GetByNameAsync(newIniciative.Name);
            if (user == null)
            {
                return BadRequest("No se encontro un usuario con el nombre proporcionado");
            }
            newIniciative.UserCreatorId = user.Id;

            await _iniciativesService.CreateAsync(newIniciative);

            return CreatedAtAction(nameof(Get), new { id = newIniciative.Id }, newIniciative);
        }
    }
}
