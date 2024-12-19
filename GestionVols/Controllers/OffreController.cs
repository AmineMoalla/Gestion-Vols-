using GestionVols.Models.Repos;
using GestionVols.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class OffreController : ControllerBase
{
    private readonly IVolRepos _volRepos;

    public OffreController(IVolRepos volRepos)
    {
        _volRepos = volRepos;
    }

    [HttpPost]
    public async Task<IActionResult> AddOffre([FromBody] Offre offre)
    {
        offre.Vol = null;
        var result = await _volRepos.AddOffre(offre);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetOffres()
    {
        var result = await _volRepos.GetOffres();
        return Ok(result);
    }

    [HttpGet("{volId}")]
    public async Task<IActionResult> GetOffresPourVol(int volId)
    {
        var result = await _volRepos.GetOffresPourVol(volId);
        return Ok(result);
    }
}
