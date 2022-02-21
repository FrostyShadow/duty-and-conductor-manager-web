using DutyAndConductorManager.Web.Models;

namespace DutyAndConductorManager.Web.Services;

public interface IVehicleService
{
    Task<Vehicle> GetVehicleById(int id);
    Task<IEnumerable<Vehicle>> GetAllVehicles();

    Task<VehicleModel> GetVehicleModelById(int id);
    Task<IEnumerable<VehicleModel>> GetAllVehicleModels();

    Task<VehicleManufacturer> GetVehicleManufacturerById(int id);
    Task<IEnumerable<VehicleManufacturer>> GetAllVehicleManufacturers();
    
    Task<Set> GetSetById(int id);
    Task<IEnumerable<Set>> GetAllSets();

    Task<IEnumerable<VehicleSet>> GetVehiclesInSet(int id);


    Task AddVehicle(int modelId, string sideNumber);
    Task EditVehicle(int id, int modelId, string sideNumber);
    Task DeleteVehicle(int id);

    Task AddVehicleModel(string name, int manufacturerId, int vehicleTypeId, bool isCoupleable);
    Task EditVehicleModel(int id, string name, int manufacturerId, int vehicleTypeId, bool isCoupleable);
    Task DeleteVehicleModel(int id);

    Task AddVehicleManufacturer(string name);
    Task EditVehicleManufacturer(int id, string name);
    Task DeleteVehicleManufacturer(int id);

    Task AddSet(string name, IList<VehicleSet> vehicles);
    Task EditSet(int id, string name, IList<VehicleSet> vehicles);
    Task DeleteSet(int id);
}

public class VehicleService : IVehicleService
{
    private IHttpService _httpService;

    public VehicleService(IHttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task AddSet(string name, IList<VehicleSet> vehicles)
    {
        await _httpService.Post<bool>("/Vehicle/AddSet", new { name, vehicles });
    }

    public async Task AddVehicle(int modelId, string sideNumber)
    {
        await _httpService.Post<bool>("/Vehicle/AddVehicle", new { modelId, sideNumber });
    }

    public async Task AddVehicleManufacturer(string name)
    {
        await _httpService.Post<bool>("/Vehicle/AddVehicleManufacturer", new { name });
    }

    public async Task AddVehicleModel(string name, int manufacturerId, int vehicleTypeId, bool isCoupleable)
    {
        await _httpService.Post<bool>("/Vehicle/AddVehicleModel", new { name, manufacturerId, vehicleTypeId, isCoupleable });
    }

    public async Task DeleteSet(int id)
    {
        await _httpService.Post<bool>("/Vehicle/DeleteSet", new { id });
    }

    public async Task DeleteVehicle(int id)
    {
        await _httpService.Post<bool>("/Vehicle/DeleteVehicle", new { id });
    }

    public async Task DeleteVehicleManufacturer(int id)
    {
        await _httpService.Post<bool>("/Vehicle/DeleteVehicleManufacturer", new { id });
    }

    public async Task DeleteVehicleModel(int id)
    {
        await _httpService.Post<bool>("/Vehicle/DeleteVehicleModel", new { id });
    }

    public async Task EditSet(int id, string name, IList<VehicleSet> vehicles)
    {
        await _httpService.Post<bool>("/Vehicle/EditSet", new { id, name, vehicles });
    }

    public async Task EditVehicle(int id, int modelId, string sideNumber)
    {
        await _httpService.Post<bool>("/Vehicle/EditVehicle", new { id, modelId, sideNumber });
    }

    public async Task EditVehicleManufacturer(int id, string name)
    {
        await _httpService.Post<bool>("/Vehicle/EditVehicleManufacturer", new { id, name });
    }

    public async Task EditVehicleModel(int id, string name, int manufacturerId, int vehicleTypeId, bool isCoupleable)
    {
        await _httpService.Post<bool>("/Vehicle/EditVehicleModel", new { id, name, manufacturerId, vehicleTypeId, isCoupleable });
    }

    public async Task<IEnumerable<Set>> GetAllSets()
    {
        return await _httpService.Get<IEnumerable<Set>>("/Vehicle/GetAllSets");
    }

    public async Task<IEnumerable<VehicleManufacturer>> GetAllVehicleManufacturers()
    {
        return await _httpService.Get<IEnumerable<VehicleManufacturer>>("/Vehicle/GetAllVehicleManufacturers");
    }

    public async Task<IEnumerable<VehicleModel>> GetAllVehicleModels()
    {
        return await _httpService.Get<IEnumerable<VehicleModel>>("/Vehicle/GetAllVehicleModels");
    }

    public async Task<IEnumerable<Vehicle>> GetAllVehicles()
    {
        return await _httpService.Get<IEnumerable<Vehicle>>("/Vehicle/GetAllVehicles");
    }

    public async Task<Set> GetSetById(int id)
    {
        return await _httpService.Get<Set>($"/Vehicle/GetSetById?id={id}");
    }

    public async Task<Vehicle> GetVehicleById(int id)
    {
        return await _httpService.Get<Vehicle>($"/Vehicle/GetVehicleById?id={id}");
    }

    public async Task<VehicleManufacturer> GetVehicleManufacturerById(int id)
    {
        return await _httpService.Get<VehicleManufacturer>($"/Vehicle/GetVehicleManufacturerById?id={id}");
    }

    public async Task<VehicleModel> GetVehicleModelById(int id)
    {
        return await _httpService.Get<VehicleModel>($"/Vehicle/GetVehicleModelById?id={id}");
    }

    public async Task<IEnumerable<VehicleSet>> GetVehiclesInSet(int id)
    {
        return await _httpService.Get<IEnumerable<VehicleSet>>($"/Vehicle/GetVehiclesInSet?id={id}");
    }
}