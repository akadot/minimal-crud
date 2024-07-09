using MinimalApi.Domain.Entities;
using MinimalApi.DTOS;

namespace MinimalApi.Domain.Interfaces;
public interface IVehicleService 
{
    List<Vehicle> GetAll(int page = 1, string? name = null, string? model = null);
    Vehicle? GetById(int id);
    void Add(Vehicle vehicle);
    void Update(Vehicle vehicle);
    void Delete(Vehicle vehicle);
}