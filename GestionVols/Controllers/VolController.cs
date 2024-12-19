using GestionVols.Models;
using GestionVols.Models.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionVols.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class VolController : ControllerBase
    {
        private readonly IVolRepos repos;

        public VolController(IVolRepos repos )
        {
            this.repos = repos;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Vol> vols = await repos.GetVols();
            return Ok(vols);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var vol = await repos.GetVolByID(id);
            if (vol == null)
                return BadRequest("vol inexistante");
            return Ok(vol);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddVol(Vol vol)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                if (vol.HeureArrivee <= vol.HeureDepart) { ModelState.AddModelError("HeureArrivee", "L'heure d'arrivée doit être supérieure à l'heure de départ."); 
                    return BadRequest(ModelState); }

                if (vol.IdAeroportDepart == vol.IdAeroportArrivee)
                {
                    ModelState.AddModelError("IdAeroportArrivee", "L'aéroport d'arrivée doit être différent de l'aéroport de départ.");
                    return BadRequest(ModelState);
                }

                if (await repos.GetVolByID(vol.IdVol) != null)
                {
                    ModelState.AddModelError(string.Empty, "Vol existe");
                    return BadRequest(ModelState);
                }

                var newvol = await repos.AddVol(vol);
                return CreatedAtAction(nameof(GetByID), new { id = newvol.IdVol }, newvol);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Vol vol)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var v = await repos.GetVolByID(vol.IdVol);
                if (v == null)
                    return BadRequest("Vol non trouvé");
                   v.NumeroVol=vol.NumeroVol;
                   v.HeureDepart=vol.HeureDepart;
                   v.HeureArrivee=vol.HeureArrivee;
                   v.Statut=vol.Statut;
                   v.Porte=vol.Porte;
                   v.TypeAvion=vol.TypeAvion;
                   v.IdAeroportArrivee=vol.IdAeroportArrivee;
                   v.IdAeroportDepart=vol.IdAeroportDepart;

                await repos.UpdateVol(v);
                return Ok("Vol modifié avec succès");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var v = await repos.GetVolByID(id);
                if (v == null)
                    return BadRequest("vol inexistante");

                await repos.DeleteVol(id);
                return Ok("vol supprimé");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("search")]    
        public async Task<IActionResult> SearchFlights([FromBody] RechercheVolRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

 
                var flights = await repos.RechercheVol(request);

                if (flights == null || !flights.Any())
                    return NotFound("No flights found matching the search criteria.");

                return Ok(flights);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }




    }
}
