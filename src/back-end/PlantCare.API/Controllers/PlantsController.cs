using Amazon.S3;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PlantCare.API.Adapters;
using PlantCare.API.DTOs;
using PlantCare.Application.DTOs;
using PlantCare.Application.Plants.DTOs;
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
    private readonly UpdatePlantRequestValidator _updateValidator;
    
    public PlantsController(IPlantsService plantsService, CreatePlantRequestValidator createValidator, UpdatePlantRequestValidator updateValidator, IAmazonS3 s3Client)
    {
        _plantsService = plantsService;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdatePlantRequest plant)
    {
        var validation = await _updateValidator.ValidateAsync(plant);

        if (!validation.IsValid)
        {
            return BadRequest(validation.Errors.Select(x => x.ErrorMessage).ToList());
        }
        
        var result = await _plantsService.UpdateAsync(plant);

        if (result.IsFailure)
        {
            return BadRequest(result.Errors.ToList());
        }
        
        return Ok(result.Value);
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

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetAllByUserAsync([FromRoute] long userId)
    {
        var result = await _plantsService.GetAllByUserAsync(userId);

        if (result.IsFailure)
        {
            return StatusCode(501, result.Errors.ToList());
        }
        
        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CreatePlantDto req)
    {
        var createPlantRequest = new CreatePlantRequest
        {
            UserId = req.UserId,
            Name = req.Name,
            Species = req.Species,
            Image = req.Image is not null ? new FormFileAdapter(req.Image) : null,
            WateringInterval = req.WateringInterval,
            LastWatered = req.LastWatered,
            LightRequirements = req.LightRequirements
        };

        if (createPlantRequest.Image is not null)
        {
            Console.WriteLine(createPlantRequest.Image.FileName);
        }
       
        
        var validation = await _createValidator.ValidateAsync(createPlantRequest);

        if (!validation.IsValid)
        {
            return BadRequest(validation.Errors.Select(x => x.ErrorMessage));
        }
        
        var result = await _plantsService.CreateAsync(createPlantRequest);

        if (result.IsFailure)
        {
            return BadRequest(result.Errors.ToList());
        }
        
        return Ok(result.Value); // Change to Created(uri, result.Value)
    }
    
}