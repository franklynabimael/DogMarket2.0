using Dog_Market_2._0.JwtFeatures;
using Dog_Market_2._0.Models;
using Dog_Market_2._0.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dog_Market_2._0.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly DogMarketContext _context;
    public ProductsController(DogMarketContext context) { 
        _context = context;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddProducts(AddProductDTO addProductDTO)
    {
        // en var user estoy almacenando la adaptacion resultante entre el view model Registerdto y el Model User.
        var product = addProductDTO.Adapt<Product>();
        // en var userManager estoy almacenando el usuario que estoy creando en mi tabla Users, uso _userManager para indicar que quiero registrar mi usuario, y se va a crear en la tabla.
        // La propiedad Password no se habia adaptado, porque no existe una propiedad en identity que se llame asi, pero usamos esa propiedad para asignarle una contrase;a al usuario, y que el usermanager la encripte y cree el usuario.
        var Product = _context.Produts.Add(product);
        await _context.SaveChangesAsync();  
        // este return es la respuesta que quiero que resulte de la operacion que esta haciendo mi endpoint CreateUser
        return Ok(Product);
    }

}



