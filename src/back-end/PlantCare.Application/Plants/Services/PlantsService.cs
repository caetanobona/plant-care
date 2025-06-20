using Amazon.S3;
using Amazon.S3.Model;
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
    private readonly IUserRepository _userRepository;
    private readonly IAmazonS3 _s3Client;
    
    private readonly string _plantImagesBucketName = "plantcare-images";
    public PlantsService(IPlantsRepository plantsRepository, IUserRepository userRepository, IAmazonS3 s3Client)
    {
        _plantsRepository = plantsRepository;
        _userRepository = userRepository;
        _s3Client = s3Client;
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
        var ownerExists = await _userRepository.ExistsAsync(req.UserId);

        if (!ownerExists)
        {
            return Result<CreateUpdatePlantResponse>.Failure("UserId does not exist");
        }
        
        var plant = new Plant {
            UserId = req.UserId,
            Name = req.Name,
            Species = req.Species, 
            ImageHash = req.Image is not null ? Utils.Utils.GetSha256Hash(req.Image.FileName) : null,
            WateringInterval = req.WateringInterval,
            LastWatered = req.LastWatered,
            LightRequirements = req.LightRequirements,
        };

        if (req.Image is not null)
        {
            var request = new PutObjectRequest()
            {
                BucketName = _plantImagesBucketName,
                Key = $"{plant.ImageHash}{Path.GetExtension(req.Image.FileName)}",
                InputStream = req.Image.OpenReadStream(),
            };
            
            await _s3Client.PutObjectAsync(request);
        }
        
        var entity = await _plantsRepository.InsertAsync(plant);

        if (entity == null)
        {
            return Result<CreateUpdatePlantResponse>.Failure("Could not create plant");
        }
        
        var response = new CreateUpdatePlantResponse
        {
            Id = entity.Id,
            UserId = entity.UserId,
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
        var errors = new List<string>();
        var plant = await _plantsRepository.GetByIdAsync(req.Id);

        if (plant == null)
        {
            errors.Add("Could not find plant with the provided Id");
        }

        if (req.UserId is not null)
        {
            var ownerExists = await _userRepository.ExistsAsync(req.UserId.Value);

            if (!ownerExists)
            {
                errors.Add("UserId does not exist");
            }
        }

        if (errors.Count > 0)
        {
            return Result<CreateUpdatePlantResponse>.Failure(errors);
        }

        plant!.Id = req.Id;
        plant.UserId = req.UserId ?? plant.UserId;
        plant.Name = req.Name ?? plant.Name;
        plant.Species = req.Species ?? plant.Species;
        plant.ImageHash = req.ImageHash ?? plant.ImageHash;
        plant.WateringInterval = req.WateringInterval ?? plant.WateringInterval;
        plant.LastWatered = req.LastWatered ?? plant.LastWatered;
        
        var updatedEntity = await _plantsRepository.UpdateAsync(plant);

        if (updatedEntity == null)
        {
            return Result<CreateUpdatePlantResponse>.Failure("Could not update plant");
        }
        
        var response = new CreateUpdatePlantResponse
        { 
            Id = updatedEntity.Id, 
            UserId = updatedEntity.UserId,
           Name = updatedEntity.Name,
           Species = updatedEntity.Species,
           ImageHash = updatedEntity.ImageHash,
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