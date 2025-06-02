using Microsoft.AspNetCore.Mvc;
using PlantCare.Application.Users.Interfaces;

namespace Plantcare.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlantsController : ControllerBase
{
    
    public PlantsController(IUserService userService)
    {
        
    }
}