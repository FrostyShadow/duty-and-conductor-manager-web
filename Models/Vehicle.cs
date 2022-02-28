namespace DutyAndConductorManager.Web.Models;

public class Vehicle
{
    public int Id {get;set;}
    public int ModelId {get;set;}
    public string SideNumber {get;set;}

    public VehicleModel Model {get;set;}

    public override string ToString()
    {
        return $"{Model.Manufacturer.Name} {Model.Name} ({SideNumber})";
    }
}