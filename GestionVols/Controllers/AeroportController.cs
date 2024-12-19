using GestionVols.Models;
using GestionVols.Models.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionVols.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class AeroportController : ControllerBase
    {
        private readonly IAeroportRepos repos;

        public AeroportController(IAeroportRepos repos)
        {
            this.repos = repos;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Aeroport> aerops = await repos.GetAeroports();
            return Ok(aerops);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var av = await repos.GetAeroportByID(id);
            if (av == null)
                return BadRequest("Aeroport inexistante");
            return Ok(av);
        }


        [HttpPost]
        public async Task<IActionResult> AddAeroport(Aeroport aeroport)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (await repos.GetAeroportByID(aeroport.IdAeroport) != null)
                {
                    ModelState.AddModelError(string.Empty, "Aeroport existe");
                    return BadRequest(ModelState);
                }

                var newaerop = await repos.AddAeroport(aeroport);
                return CreatedAtAction(nameof( GetByID), new { id = newaerop.IdAeroport }, newaerop);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Aeroport aeroport)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var ar = await repos.GetAeroportByID(aeroport.IdAeroport);
                if (ar == null)
                    return BadRequest("Aeroport non trouvé");

                ar.NomAeroport = aeroport.NomAeroport;
                ar.VilleAeroport = aeroport.VilleAeroport;
                ar.PaysAeroport = aeroport.PaysAeroport;

                await repos.UpdateAeroport(ar);
                return Ok("Aeroport modifié avec succès");
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
                var av = await repos.GetAeroportByID(id);
                if (av == null)
                    return BadRequest("Aeroport inexistante");

                await repos.DeleteAeroport(id);
                return Ok("Aeroport supprimé");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }



    }
}
