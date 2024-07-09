using MinimalApi.Infrastructure.Database;
using MinimalApi.Domain.Interfaces;
using MinimalApi.Domain.Entities;
using MinimalApi.DTOS;

namespace MinimalApi.Domain.Services;
public class VehicleService : IVehicleService
{
    private readonly MinmalDbContext _context;
    public VehicleService(MinmalDbContext db)
    {
        _context = db;
    }

    public void Delete(Vehicle vehicle)
    {
        _context.Vehicles.Remove(vehicle);
        _context.SaveChanges();
    }

    public void Add(Vehicle vehicle)
    {
        _context.Vehicles.Add(vehicle);
        _context.SaveChanges();
    }

    public void Update(Vehicle vehicle)
    {
        _context.Vehicles.Update(vehicle);
        _context.SaveChanges();
    }

    public Vehicle? GetById(int id)
    {
        return _context.Vehicles.Where(vh => vh.Id == id).FirstOrDefault();
    }

    List<Vehicle> GetAll(int page = 1, string? name = null, string? model = null)
    {
        List<Vehicle> allVehicles = [.. _context.Vehicles];

        if (!string.IsNullOrEmpty(name))
        {
            allVehicles = allVehicles.Where(v => v.Name == name).ToList();
        }

        if (!string.IsNullOrEmpty(model))
        {
            allVehicles = allVehicles.Where(v => v.Model == model).ToList();
        }

        int defaultPageSize = 10;

        return allVehicles.Skip((page - 1) * defaultPageSize).Take(defaultPageSize).ToList();
    }
}