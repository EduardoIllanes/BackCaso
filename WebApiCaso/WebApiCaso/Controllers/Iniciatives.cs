using Microsoft.AspNetCore.Mvc;
using WebApiCaso.Models;
using WebApiCaso.Services;

namespace WebApiCaso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IniciativesController : Controller
    {
        private readonly IniciativeService _iniciativesService;
        public IniciativesController(IniciativeService iniciativesService) => _iniciativesService = iniciativesService;
        
        [HttpGet]
        public async Task<List<Iniciative>> Get() =>
                await _iniciativesService.GetAsync();

        [HttpPost]
        public async Task<IActionResult> Post(Iniciative newIniciative)
        {
            await _iniciativesService.CreateAsync(newIniciative);

            return CreatedAtAction(nameof(Get), new { id = newIniciative.Id }, newIniciative);
        }
    }
}
