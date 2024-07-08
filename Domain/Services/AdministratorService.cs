using MinimalApi.Infrastructure.Database;
using MinimalApi.Domain.Interfaces;
using MinimalApi.Domain.Entities;
using MinimalApi.DTOS;

namespace MinimalApi.Domain.Services;
public class AdministratorService : IAdministratorService
{
    private readonly MinmalDbContext _context;
    public AdministratorService(MinmalDbContext db)
    {
        _context = db;
    }

    public Administrator? Login(LoginDTO loginDTO)
    {
        return _context.Administrators.Where(adm => adm.Email == loginDTO.Email && adm.Password == loginDTO.Password).FirstOrDefault();
    }

}