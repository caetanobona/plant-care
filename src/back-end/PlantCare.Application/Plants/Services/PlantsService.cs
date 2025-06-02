using PlantCare.Application.Plants.DTOs;
using PlantCare.Application.Plants.Interfaces;
using PlantCare.Application.Plants.Models;
using PlantCare.Domain.Entities;
using PlantCare.Domain.Result;

namespace PlantCare.Application.Plants.Services;

public class PlantsService : IPlantsService
{
    public Task<Result<List<PlantDto>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Result<PlantDto>> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<CreateUpdatePlantResponse>> CreateAsync(CreatePlantRequest req)
    {
        throw new NotImplementedException();
    }

    public Task<Result<CreateUpdatePlantResponse>> UpdateAsync(UpdatePlantRequest req)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<PlantDto>>> GetAllByUserAsync(User user)
    {
        throw new NotImplementedException();
    }
}