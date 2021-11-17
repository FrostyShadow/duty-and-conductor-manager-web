using DutyAndConductorManager.Web.Models;

namespace DutyAndConductorManager.Web.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetAll();
}

public class UserService : IUserService
{
    private IHttpService _httpService;

    public UserService(IHttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _httpService.Get<IEnumerable<User>>("/User/GetAll");
    }
}