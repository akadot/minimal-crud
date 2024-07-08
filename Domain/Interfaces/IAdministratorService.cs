using MinimalApi.Domain.Entities;
using MinimalApi.DTOS;

namespace MinimalApi.Domain.Interfaces;
public interface IAdministratorService 
{
    Administrator? Login(LoginDTO loginDTO);
}