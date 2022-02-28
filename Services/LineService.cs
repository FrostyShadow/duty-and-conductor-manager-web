using DutyAndConductorManager.Web.Models;
namespace DutyAndConductorManager.Web.Services;

public interface ILineService
{
    Task<Line> GetById(int id);
    Task<IEnumerable<Line>> GetAll();

    Task AddLine(string number, int lineTypeId, DateTime startDateTime, DateTime endDateTime);
    Task EditLine(int id, string number, int lineTypeId, DateTime startDateTime, DateTime endDateTime);
    Task DeleteLine(int id);
}

public class LineService : ILineService
{
    private readonly IHttpService _httpService;

    public LineService(IHttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task<Line> GetById(int id)
    {
        return await _httpService.Get<Line>($"/Line/GetById?id={id}");
    }

    public async Task<IEnumerable<Line>> GetAll()
    {
        return await _httpService.Get<IEnumerable<Line>>("/Line/GetAll");
    }

    public async Task AddLine(string number, int lineTypeId, DateTime startDateTime, DateTime endDateTime)
    {
        await _httpService.Post<bool>("/Line/AddLine", new { number, lineTypeId, startDateTime, endDateTime });
    }

    public async Task EditLine(int id, string number, int lineTypeId, DateTime startDateTime, DateTime endDateTime)
    {
        await _httpService.Post<bool>("/Line/EditLine", new { id, number, lineTypeId, startDateTime, endDateTime });
    }

    public async Task DeleteLine(int id)
    {
        await _httpService.Post<bool>("/Line/DeleteLine", new { id });
    }
}