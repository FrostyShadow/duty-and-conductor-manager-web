using DutyAndConductorManager.Web.Helpers;

namespace DutyAndConductorManager.Web.Models;

public class Announcement
{
    public int Id {get;set;}
    public User User {get;set;}
    public DateTime CreatedDateTime {get;set;}
    public string Message {get;set;}
    public AnnouncementType AnnouncementType {get;set;}
}