using DutyAndConductorManager.Web.Models;

namespace DutyAndConductorManager.Web.Services;

public interface IShiftService
{
    Task<Brigade> GetById(int id);
    Task<IEnumerable<Brigade>> GetAll();
    Task<IEnumerable<BrigadeUser>> GetUsersInBrigade(int id);

    Task AddBrigade(string name, DateTime dateTimeFrom, DateTime dateTimeTo, int conductorLimit, int setId, int lineId, bool isActive);
    Task EditBrigade(int id, string name, DateTime dateTimeFrom, DateTime dateTimeTo, int conductorLimit, int setId, int lineId, bool isActive);
    Task DeleteBrigade(int id);

    Task AddUserToBrigade(int brigadeId, int userId, bool isManager);
    Task DeleteUserFromBrigade(int brigadeId, int userId);
}

public class ShiftService : IShiftService
{
    private readonly IHttpService _httpService;

    public ShiftService(IHttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task<Brigade> GetById(int id)
    {
        return await _httpService.Get<Brigade>($"/Shift/GetById?id={id}");
    }

    public async Task<IEnumerable<Brigade>> GetAll()
    {
        return await _httpService.Get<IEnumerable<Brigade>>("/Shift/GetAll");
    }

    public async Task<IEnumerable<BrigadeUser>> GetUsersInBrigade(int id)
    {
        return await _httpService.Get<IEnumerable<BrigadeUser>>($"/Shift/GetUsersInBrigade?id={id}");
    }

    public async Task AddBrigade(string name, DateTime dateTimeFrom, DateTime dateTimeTo, int conductorLimit, int setId, int lineId, bool isActive)
    {
        await _httpService.Post<bool>("/Shift/AddBrigade", new { name, dateTimeFrom, dateTimeTo, conductorLimit, setId, lineId, isActive });
    }

    public async Task EditBrigade(int id, string name, DateTime dateTimeFrom, DateTime dateTimeTo, int conductorLimit, int setId, int lineId, bool isActive)
    {
        await _httpService.Post<bool>("/Shift/EditBrigade", new { id, name, dateTimeFrom, dateTimeTo, conductorLimit, setId, lineId, isActive });
    }

    public async Task DeleteBrigade(int id)
    {
        await _httpService.Post<bool>("/Shift/DeleteBrigade", new { id });
    }

    public async Task AddUserToBrigade(int brigadeId, int userId, bool isManager)
    {
        await _httpService.Post<bool>("/Shift/AddUserToBrigade", new { brigadeId, userId, isManager });
    }

    public async Task DeleteUserFromBrigade(int brigadeId, int userId)
    {
        await _httpService.Post<bool>("/Shift/DeleteUserFromBrigade", new { brigadeId, userId });
    }
}