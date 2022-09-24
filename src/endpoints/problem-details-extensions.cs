using Flunt.Notifications;

namespace iwantapp.endpoints;

public static class ProblemDetailsExtensions {
    public static Dictionary<string, string[]> convertToProblemDetails(this IReadOnlyCollection<Notification> notifications) {
        return notifications
                .GroupBy(n => n.Key)
                .ToDictionary(g => g.Key, g => g.Select(x => x.Message).ToArray());
    }
}