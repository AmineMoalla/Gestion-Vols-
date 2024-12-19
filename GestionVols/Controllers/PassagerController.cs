using GestionVols.Models;
using GestionVols.Models.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionVols.Controllers
{
    [Route("api/[controller]")]
<<<<<<< HEAD
    [ApiController] 
=======
    [ApiController]
    //[Authorize(Roles = "Admin")]
>>>>>>> ebd035e90e44e3225161bf286a2c481bd6bc833b
    public class PassagerController : ControllerBase
    {
        private readonly IPassagerRepos repos;

        public PassagerController(IPassagerRepos repos)
        {
            this.repos = repos;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Passager> passagers = await repos.GetPassagers();
            return Ok(passagers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var pass= await repos.GetPassagerById(id);
            if (pass == null)
                return BadRequest("Passager inexistante");
            return Ok(pass);
        }

        [HttpPost]
        public async Task<IActionResult> AddPassager(Passager passager)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (await repos.GetPassagerById(passager.IdPassager) != null)

                {
                    ModelState.AddModelError(string.Empty, "Passager existe");
                    return BadRequest(ModelState);
                }

                var newpass = await repos.AddPassager(passager);
                return CreatedAtAction(nameof(GetByID), new { id = newpass.IdPassager }, newpass);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Passager passager)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var pass = await repos.GetPassagerById(passager.IdPassager);
                if (pass == null)
                    return BadRequest("Passager non trouvé");

                pass.NomPassager = passager.NomPassager;
                pass.PrenomPassager=passager.PrenomPassager;
                pass.DateNaissance = passager.DateNaissance;
                pass.TelephonePassager=passager.TelephonePassager;
                pass.EmailPassager=passager.EmailPassager;

                await repos.UpdatePassager(pass);
                return Ok("Passager modifié avec succès");
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
                var pass = await repos.GetPassagerById(id);
                if (pass == null)
                    return BadRequest("Passager inexistante");

                await repos.DeletePassager(id);
                return Ok("Passger supprimé");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

    }
}
