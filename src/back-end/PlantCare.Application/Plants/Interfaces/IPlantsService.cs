using PlantCare.Application.Plants.DTOs;
using PlantCare.Application.Plants.Models;
using PlantCare.Domain.Entities;
using PlantCare.Domain.Result;

namespace PlantCare.Application.Plants.Interfaces;

public interface IPlantsService
{
    public Task<Result<List<PlantDto>>> GetAllAsync();
    public Task<Result<PlantDto?>> GetByIdAsync(long id);
    public Task<Result<CreateUpdatePlantResponse>> CreateAsync(CreatePlantRequest req);
    public Task<Result<CreateUpdatePlantResponse>> UpdateAsync(UpdatePlantRequest req);
    public Task<Result> DeleteAsync(int id);
    public Task<Result<List<PlantDto>>> GetAllByUserAsync(User user);
}