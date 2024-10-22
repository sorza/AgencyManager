using Flunt.Notifications;

namespace AgencyManager.Core.Requests
{
    public abstract class Request : Notifiable<Notification>
    {
        public string UserId { get; set; } = string.Empty;
    }
}