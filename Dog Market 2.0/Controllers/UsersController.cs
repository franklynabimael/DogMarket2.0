using Dog_Market_2._0.JwtFeatures;
using Dog_Market_2._0.Models;
using Dog_Market_2._0.ViewModels;
using Dog_Market_2._0.ViewModels.Response;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.IdentityModel.Tokens.Jwt;

namespace Dog_Market_2._0.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly DogMarketContext _context;
    // userMAnager maneja todo lo que tiene que ver con el usuario, como asignarle un rol de administrador, asignarle contrase;a al usuario, confirmar el correo de un usuario, sirve tambien para el loging, etc. etc.
    private readonly UserManager<User> _userManager;
    private readonly JwtHandler _jwtHandler;
    public UsersController(DogMarketContext context, UserManager<User> userManager, JwtHandler jwtHandler)
    {
        _context =context;
        _userManager = userManager;
        _jwtHandler = jwtHandler;
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetUsers()
    {
        // IEnumerable es una forma de decir una Lista, y  le pongo entre flechitas User, porque es una lista de usuarios basado en mi model User, y ToList() trae todos mis Users que tenga en mi base de datos a una Lista.
        IEnumerable<User> users = _context.Users.ToList();
        // le decimos que retorne toda esa lista
        return Ok(users);
    }

    // estoy usando el viewModel RegisterDto como plantilla, como los campos que voy a ingresar pa registrarme.
    [HttpPost("register")]
    public async Task<IActionResult> CreateUser(RegisterDto registerDto)
    {
        var user = registerDto.Adapt<User>();
        user.CartUser = new Cart();
        var result = await _userManager.CreateAsync(user, registerDto.Password);
        if (!result.Succeeded)
            throw new Exception("Incorrect credentials");
        await _context.SaveChangesAsync();
        UserResponse userResponse = user.Adapt<UserResponse>();
        return Ok(userResponse);
    }

    [HttpPost("loging")] 
    public async Task<IActionResult> Loging (LogingDto logingDto)
    {
        var user = await _userManager.FindByNameAsync(logingDto.UserName);
        if (user == null || !await _userManager.CheckPasswordAsync(user, logingDto.Password))
            return Unauthorized(new LogingResponse { Message = "Username or password incorrect", IsAuthSuccessful = false });
        var signingCredentials = _jwtHandler.GetSigningCredentials();
        var claims = _jwtHandler.GetClaims(user);
        var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return Ok(new LogingResponse { IsAuthSuccessful = true, Token = token });
    }
}

