namespace DutyAndConductorManager.Web.Models;

public class VehicleModel
{
    public int Id {get;set;}
    public string Name {get;set;}
    public int ManufacturerId {get;set;}
    public int VehicleTypeId {get;set;}
    public bool IsCoupleable {get;set;}

    public VehicleManufacturer Manufacturer {get;set;}
    public VehicleType VehicleType {get;set;}

    public override string ToString()
    {
        return $"{Manufacturer.Name} {Name}";
    }
}