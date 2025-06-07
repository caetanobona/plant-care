using PlantCare.Application.Plants.DTOs;
using PlantCare.Application.Plants.Interfaces;
using PlantCare.Application.Plants.Models;
using PlantCare.Domain.Entities;
using PlantCare.Domain.Repositories;
using PlantCare.Domain.Result;

namespace PlantCare.Application.Plants.Services;

public class PlantsService : IPlantsService
{
    private readonly IPlantsRepository _plantsRepository;

    public PlantsService(IPlantsRepository plantsRepository)
    {
        _plantsRepository = plantsRepository;
    }

    public async Task<Result<PlantDto?>> GetByIdAsync(long id)
    {
        var entity = await _plantsRepository.GetByIdAsync(id);

        if (entity == null)
        {
            return Result<PlantDto?>.Success(null);
        }

        var plantDto = new PlantDto{
            Name = entity.Name,
            Species = entity.Species,
            ImageUrl = entity.ImageUrl,
            WateringInterval = entity.WateringInterval,
            LastWatered = entity.LastWatered,
            LightRequirements = entity.LightRequirements
        };
        
        return Result<PlantDto?>.Success(plantDto);
    }
    public async Task<Result<List<PlantDto>>> GetAllAsync()
    {
        var entities = await _plantsRepository.GetAllAsync();

        var plants = entities.Select(entity => new PlantDto
        {
            Name = entity.Name,
            Species = entity.Species,
            ImageUrl = entity.ImageUrl,
            WateringInterval = entity.WateringInterval,
            LastWatered = entity.LastWatered,
            LightRequirements = entity.LightRequirements
        }).ToList();
        
        return Result<List<PlantDto>>.Success(plants);
    }

    public async Task<Result<CreateUpdatePlantResponse>> CreateAsync(CreatePlantRequest req)
    {
        var plant = new Plant {
            UserId = req.UserId,
            Name = req.Name,
            Species = req.Species,
            ImageUrl = req.ImageUrl,
            WateringInterval = req.WateringInterval,
            LastWatered = req.LastWatered,
            LightRequirements = req.LightRequirements,
        };
        
        var entity = await _plantsRepository.InsertAsync(plant);

        if (entity == null)
        {
            return Result<CreateUpdatePlantResponse>.Failure("Could not create plant");
        }
        
        var response = new CreateUpdatePlantResponse
        {
            Name = entity.Name,
            Species =  entity.Species,
            ImageUrl =  entity.ImageUrl,
            WateringInterval = entity.WateringInterval,
            LastWatered =  entity.LastWatered,
            LightRequirements =  entity.LightRequirements,
        };
        
        return  Result<CreateUpdatePlantResponse>.Success(response);
    }

    public Task<Result<CreateUpdatePlantResponse>> UpdateAsync(UpdatePlantRequest req)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> DeleteAsync(long id)
    {
        var plant = await _plantsRepository.GetByIdAsync(id);

        if (plant == null)
        {
            return Result.Failure("Could not find plant");
        }
        
        await _plantsRepository.DeleteAsync(plant);
        
        return Result.Success();
    }

    public Task<Result<List<PlantDto>>> GetAllByUserAsync(User user)
    {
        throw new NotImplementedException();
    }
}