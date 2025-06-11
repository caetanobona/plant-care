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
            ImageHash = entity.ImageHash,
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
            ImageHash = entity.ImageHash,
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
            ImageHash = req.ImageHash,
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
            ImageHash =  entity.ImageHash,
            WateringInterval = entity.WateringInterval,
            LastWatered =  entity.LastWatered,
            LightRequirements =  entity.LightRequirements,
        };
        
        
        return  Result<CreateUpdatePlantResponse>.Success(response);
    }

    public async Task<Result<CreateUpdatePlantResponse>> UpdateAsync(UpdatePlantRequest req)
    {
        var plant = await _plantsRepository.GetByIdAsync(req.Id);

        if (plant == null)
        {
            return Result<CreateUpdatePlantResponse>.Failure("Could not find plant with the provided Id");
        }

        var updatedPlant = new Plant
        {
            Name = req.Name ?? plant.Name,
            Species = req.Species ?? plant.Species,
            ImageUrl = req.ImageUrl ?? plant.ImageUrl,
            WateringInterval = req.WateringInterval ?? plant.WateringInterval,
            LastWatered = req.LastWatered ?? plant.LastWatered,
        };
        
        var updatedEntity = await _plantsRepository.UpdateAsync(updatedPlant);

        if (updatedEntity == null)
        {
            return Result<CreateUpdatePlantResponse>.Failure("Could not update plant");
        }
        
        var response = new CreateUpdatePlantResponse
        {
           Name = updatedEntity.Name,
           Species = updatedEntity.Species,
           ImageUrl = updatedEntity.ImageUrl,
           WateringInterval = updatedEntity.WateringInterval,
           LastWatered = updatedEntity.LastWatered,
           LightRequirements = updatedEntity.LightRequirements,
        };
        
        return Result<CreateUpdatePlantResponse>.Success(response);
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

    public async Task<Result<List<PlantDto>>> GetAllByUserAsync(long userId)
    {
        var plants = await _plantsRepository.GetAllByUserAsync(userId);
        
        var plantsDtos = new List<PlantDto>(plants.Select(plant => new PlantDto
        {
            Name = plant.Name,
            Species = plant.Species,
            ImageHash = plant.ImageHash,
            WateringInterval = plant.WateringInterval,
            LastWatered = plant.LastWatered,
            LightRequirements = plant.LightRequirements
        }));
        
        return Result<List<PlantDto>>.Success(plantsDtos);
    }
}