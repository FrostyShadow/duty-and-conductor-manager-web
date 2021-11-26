using DutyAndConductorManager.Web.Models;

namespace DutyAndConductorManager.Web.Services;

public interface IUserService
{
    Task<Guid> Activate(int id, Guid token);
    Task ForgotPassword(string email);
    Task<Guid> PasswordReset(int id, Guid token);
    Task SetPassword(int id, Guid token, string password);
    Task<IEnumerable<User>> GetAll();
    Task<User> GetById(int id);
    Task AddUser(string firstName, string lastName, string username, string email, int roleId, DateTime? birthDate, bool isTrained, string phoneNumber);
    Task DeleteUser(int id);
}

public class UserService : IUserService
{
    private IHttpService _httpService;

    public UserService(IHttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task<Guid> Activate(int id, Guid token)
    {
        return await _httpService.Post<Guid>("/User/Activate", new { id, token });
    }

    public async Task ForgotPassword(string email)
    {
        await _httpService.Post<bool>("/User/ForgotPassword", new { email });
    }

    public async Task<Guid> PasswordReset(int id, Guid token)
    {
        return await _httpService.Post<Guid>("/User/PasswordReset", new { id, token });
    }

    public async Task SetPassword(int id, Guid token, string password)
    {
        await _httpService.Post<bool>("/User/SetPassword", new { id, token, password });
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _httpService.Get<IEnumerable<User>>("/User/GetAll");
    }

    public async Task<User> GetById(int id)
    {
        return await _httpService.Get<User>($"/User/GetById?id={id}");
    }

    public async Task AddUser(string firstName, string lastName, string username, string email, int roleId, DateTime? birthDate, bool isTrained, string phoneNumber)
    {
        await _httpService.Post<User>("/User/AddUser", new { firstName, lastName, username, email, roleId, birthDate, isTrained, phoneNumber });
    }

    public async Task DeleteUser(int id)
    {
        await _httpService.Post<bool>("/User/DeleteUser", new { id });
    }
}