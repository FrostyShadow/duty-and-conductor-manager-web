using System.Collections.Specialized;
using System.Web;
using Microsoft.AspNetCore.Components;
using System.Linq;

namespace DutyAndConductorManager.Web.Helpers;

public static class ExtensionMethods
{
    public static NameValueCollection QueryString(this NavigationManager navigationManager) => HttpUtility.ParseQueryString(new Uri(navigationManager.Uri).Query);

    public static string QueryString(this NavigationManager navigationManager, string key) => navigationManager.QueryString()[key];

    public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> source)
    {
        return source.Select((item, index) => (item, index));
    }
}