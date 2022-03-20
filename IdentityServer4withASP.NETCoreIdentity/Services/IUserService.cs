using System.Threading.Tasks;
using APITest.Dto;

namespace IdentityServer4withASP.NETCoreIdentity.Services;

public interface IUserService
{
    Task<bool> CreateUser(UserCreateDto user);
}