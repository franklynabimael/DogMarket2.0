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
        // en var user estoy almacenando la adaptacion resultante entre el view model Registerdto y el Model User.
        var user = registerDto.Adapt<User>();
        // en var userManager estoy almacenando el usuario que estoy creando en mi tabla Users, uso _userManager para indicar que quiero registrar mi usuario, y se va a crear en la tabla.
        // La propiedad Password no se habia adaptado, porque no existe una propiedad en identity que se llame asi, pero usamos esa propiedad para asignarle una contrase;a al usuario, y que el usermanager la encripte y cree el usuario.
        var userManager = await _userManager.CreateAsync(user, registerDto.Password);

        await _context.SaveChangesAsync();
        // este return es la respuesta que quiero que resulte de la operacion que esta haciendo mi endpoint CreateUser
        return Ok(user);
    }

    [HttpPost("loging")] 
    public async Task<IActionResult> Loging (LogingDto logingDto)
    {
        var user = await _userManager.FindByNameAsync(logingDto.UserName);
        if (user == null || !await _userManager.CheckPasswordAsync(user, logingDto.Password))
            return Unauthorized(new LogingResponse { Message = "Invalid Authentication", IsAuthSuccessful = false });
        var signingCredentials = _jwtHandler.GetSigningCredentials();
        var claims = _jwtHandler.GetClaims(user);
        var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return Ok(new LogingResponse { IsAuthSuccessful = true, Token = token });
    }
}

