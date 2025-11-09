using Microsoft.AspNetCore.Mvc;

namespace Project.Wild.Pony.Api;

[ApiController]
[Route("api/[controller]")]
public class SecurityController : ControllerBase
{
    // GET /api/security/login 
    [HttpGet("login")]
    public IActionResult LoginHealth()
    {
        return Ok(new { message = "Login route reachable (GET)" });
    }

    // POST /api/security/login 
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest body)
    {
        if (body is null)
            return BadRequest(new { message = "Invalid payload" });

        
        if (body.Username == "admin" && body.Password == "1234")
        {
            return Ok(new
            {
                token = "fake-jwt-token",
                message = "Login successful"
            });
        }

        return Unauthorized(new { message = "Invalid credentials" });
    }

    // POST /api/security/logout 
    [HttpPost("logout")]
    public IActionResult Logout()
    {
        return Ok(new { message = "Logged out successfully" });
    }

    public record LoginRequest(string Username, string Password);
}
