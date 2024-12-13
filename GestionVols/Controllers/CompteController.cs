using GestionVols.DTO;
using GestionVols.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestionVols.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompteController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;

        public CompteController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid) 
            { return BadRequest(ModelState); }
            
            var user = await userManager.FindByNameAsync(registerDTO.UserName); 
            if (user != null) { 
                return BadRequest("Utilisateur existe"); }
            ApplicationUser applicationUser = new() 
            { UserName = registerDTO.UserName, Email = registerDTO.Email }; 
            var result = await userManager.CreateAsync(applicationUser, registerDTO.Password); 
            if (!result.Succeeded) {
                return BadRequest(result.Errors); } 
            // Ajouter l'utilisateur au rôle "Utilisateur" par défaut
         
            
            await userManager.AddToRoleAsync(applicationUser, "Utilisateur");

            return Ok("Utilisateur créé avec succès"); }

            [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByNameAsync(loginDTO.UserName);
                if (user != null)
                {
                    if (await userManager.CheckPasswordAsync(user, loginDTO.Password))
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.UserName),
                            new Claim(ClaimTypes.NameIdentifier, user.Id),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        };

                        // Récupérer les rôles de l'utilisateur et les ajouter aux claims
                        var roles = await userManager.GetRolesAsync(user);
                        foreach (var role in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role));
                        }

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));
                        var sc = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            claims: claims,
                            issuer: configuration["JWT:issuer"],
                            audience: configuration["JWT:audience"],
                            expires: DateTime.Now.AddHours(1),
                            signingCredentials: sc
                        );

                        var _token = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo,
                            username = loginDTO.UserName,
                        };

                        return Ok(_token);
                    }
                    else
                    {
                        ModelState.AddModelError("Erreur", "Utilisateur n'est pas autorisé à se connecter");
                        return Unauthorized(ModelState);
                    }
                }
                return BadRequest(ModelState);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("Users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = userManager.Users.ToList();
            var userList = new List<object>();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);
                userList.Add(new
                {
                    user.Id,
                    user.UserName,
                    user.Email,
                    Roles = roles
                });
            }

            return Ok(userList);
        }

        // Nouvelle méthode pour obtenir un utilisateur par ID
        [HttpGet("User/{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await userManager.FindByIdAsync(id); if (user == null)
            { return NotFound("Utilisateur non trouvé"); }
            var result = new
            { user.Id, user.UserName, user.Email };

            return Ok(result);
        }


        [HttpDelete("User/{id}")]
        public async Task<IActionResult> DeleteUser(string id) 
        { var user = await userManager.FindByIdAsync(id); if (user == null) 
            { return NotFound("Utilisateur non trouvé"); } 
            var result = await userManager.DeleteAsync(user); 
            if (!result.Succeeded) { return BadRequest(result.Errors); }
            return Ok("Utilisateur supprimé avec succès"); 
        }


    }
}
