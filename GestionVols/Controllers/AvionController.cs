using GestionVols.Models;
using GestionVols.Models.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionVols.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    //[Authorize]
    public class AvionController : ControllerBase
    {
        private readonly IAvionRepos repos;

        public AvionController(IAvionRepos repos)
        {
            this.repos = repos;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Avion> avions = await repos.GetAvions();
            return Ok(avions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var av = await repos.GetAvionByID(id);
            if (av == null)
                return BadRequest("Avion inexistante");
            return Ok(av);
        }

        [HttpPost]
        public async Task<IActionResult> AddAvion(Avion avion)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (await repos.GetAvionByID(avion.IdAvion) != null)
                {
                    ModelState.AddModelError(string.Empty, "Avion existe");
                    return BadRequest(ModelState);
                }

                var newav = await repos.AddAvion(avion);
                return CreatedAtAction(nameof(GetByID), new { id = newav.IdAvion }, newav);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Avion avion)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var av = await repos.GetAvionByID(avion.IdAvion);
                if (av == null)
                    return BadRequest("Avion non trouvé");

                av.TypeAvion = avion.TypeAvion;
                av.CapaciteAvion = avion.CapaciteAvion;
                av.FabriquantAvion = avion.FabriquantAvion;

                await repos.UpdateAvion(av);
                return Ok("Avion modifié avec succès");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var av = await repos.GetAvionByID(id);
                if (av == null)
                    return BadRequest("Avion inexistante");

                await repos.DeleteAvion(id);
                return Ok("Avion supprimé");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
