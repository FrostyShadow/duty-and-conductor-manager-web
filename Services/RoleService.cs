using DutyAndConductorManager.Web.Models;

namespace DutyAndConductorManager.Web.Services;

public interface IRoleService
{
    Task<Role> GetById(int id);
    Task<IEnumerable<Role>> GetAll();
}

public class RoleService : IRoleService
{
    private IHttpService _httpService;

    public RoleService(IHttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task<Role> GetById(int id)
    {
        var result = await _httpService.Get<Role>($"/Role/GetById?id={id}");
        return result;
    }

    public async Task<IEnumerable<Role>> GetAll()
    {
        var result = await _httpService.Get<IEnumerable<Role>>("/Role/GetAll");
        return result;
    }
}