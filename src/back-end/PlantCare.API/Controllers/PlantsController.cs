using Microsoft.AspNetCore.Mvc;
using PlantCare.Application.DTOs;
using PlantCare.Application.Plants.Interfaces;
using PlantCare.Application.Users.Interfaces;
using PlantCare.Domain.Repositories;

namespace Plantcare.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlantsController : ControllerBase
{
    private readonly IPlantsService _plantsService;
    
    public PlantsController(IPlantsService plantsService)
    {
        _plantsService = plantsService;
        
    }
    
}