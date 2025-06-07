using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PlantCare.Application.DTOs;
using PlantCare.Application.Plants.Interfaces;
using PlantCare.Application.Plants.Models;
using PlantCare.Application.Plants.Validators;
using PlantCare.Application.Users.Interfaces;
using PlantCare.Domain.Repositories;

namespace Plantcare.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlantsController : ControllerBase
{
    private readonly IPlantsService _plantsService;
    private readonly CreatePlantRequestValidator _createValidator;
    
    public PlantsController(IPlantsService plantsService, CreatePlantRequestValidator createValidator)
    {
        _plantsService = plantsService;
        _createValidator = createValidator;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        var result = await _plantsService.DeleteAsync(id);

        if (result.IsFailure)
        {
            return BadRequest(result.Errors.ToList());
        }
        
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
    {
        var result = await _plantsService.GetByIdAsync(id);
        
        if (result.IsFailure)
        {
            return StatusCode(501, result.Errors.ToList());
        }
        
        return Ok(result.Value);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _plantsService.GetAllAsync();

        if (result.IsFailure)
        {
            return StatusCode(501, result.Errors.ToList());
        }
        
        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreatePlantRequest req)
    {
        var validation = await _createValidator.ValidateAsync(req);

        if (!validation.IsValid)
        {
            return BadRequest(validation.Errors.Select(x => x.ErrorMessage));
        }
        
        var result = await _plantsService.CreateAsync(req);

        if (result.IsFailure)
        {
            return BadRequest(result.Errors.ToList());
        }
        
        return Ok(result.Value); // Change to Created(uri, result.Value)
    }
    
}