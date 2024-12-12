﻿using GestionVols.Models;
using GestionVols.Models.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionVols.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Utilisateur")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepos repos;

        public ReservationController(IReservationRepos repos)
        {
            this.repos = repos;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Reservation> reservations = await repos.GetReservations();
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var res = await repos.GetReservationById(id);
            if (res == null)
                return BadRequest("Reservation inexistante");
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation(Reservation reservation)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (await repos.GetReservationById(reservation.IdReservation) != null)
                {
                    ModelState.AddModelError(string.Empty, "Reservation existe");
                    return BadRequest(ModelState);
                }

                //if(reservation.Vol.NbreReservée == reservation.Vol.Avion.CapaciteAvion)
                //{
                //    return BadRequest("Nombre max atteint");
                //}
                //reservation.Vol.NbreReservée++;

                var newres = await repos.AddReservation(reservation);
                return CreatedAtAction(nameof(GetByID), new { id = newres.IdReservation }, newres);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Reservation reservation)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var res= await repos.GetReservationById(reservation.IdReservation);
                if (res == null)
                    return BadRequest("Reservation non trouvé");
                     
                res.IdPassager=reservation.IdPassager;
                res.IdVol=reservation.IdVol;
                res.DateReservation=reservation.DateReservation;
                res.StatutReservation = reservation.StatutReservation;
                res.PrixReservation=reservation.PrixReservation;

                await repos.UpdateReservation(res);
                return Ok("Reservation modifié avec succès");
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
                var res= await repos.GetReservationById(id);
                if (res == null)
                    return BadRequest("Reservation inexistante");

                await repos.DeleteReservation(id);
                return Ok("Reservation supprimé");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}