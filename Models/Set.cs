namespace DutyAndConductorManager.Web.Models;

public class Set
{
    public int Id {get;set;}
    public string Name {get;set;}

    public IList<VehicleSet> VehicleSets {get;set;}
}