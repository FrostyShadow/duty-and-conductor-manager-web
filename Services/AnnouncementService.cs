using DutyAndConductorManager.Web.Helpers;
using DutyAndConductorManager.Web.Models;

namespace DutyAndConductorManager.Web.Services;

public interface IAnnouncementService
{
    Task<IEnumerable<Announcement>> GetAll();
    Task<Announcement> GetById(int id);
    Task AddAnnouncement(int creatorId, string message, int announcementTypeId);
    Task EditAnnouncement(int id, int editorId, string message, int? announcementTypeId);
    Task DeleteAnnouncement(int id, int deleterId);
}

public class AnnouncementService : IAnnouncementService
{
    private IHttpService _httpService;

    public AnnouncementService(IHttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task AddAnnouncement(int creatorId, string message, int announcementTypeId)
    {
        await _httpService.Post<Announcement>("/Announcement/AddAnnouncement", new { creatorId, message, announcementTypeId });
    }

    public async Task DeleteAnnouncement(int id, int deleterId)
    {
        await _httpService.Post<bool>("/Announcement/DeleteAnnouncement", new { id, deleterId });
    }

    public async Task EditAnnouncement(int id, int editorId, string message, int? announcementTypeId)
    {
        await _httpService.Post<bool>("/Announcement/EditAnnouncement", new { id, editorId, message, announcementTypeId });
    }

    public async Task<IEnumerable<Announcement>> GetAll()
    {
        return await _httpService.Get<IEnumerable<Announcement>>("/Announcement/GetAll");
    }

    public async Task<Announcement> GetById(int id)
    {
        return await _httpService.Get<Announcement>($"/Announcement/GetById?id={id}");
    }
}