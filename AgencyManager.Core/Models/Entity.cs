using Flunt.Notifications;

namespace AgencyManager.Core.Models
{
    public abstract class Entity : Notifiable<Notification>
    {
        public Entity()
        {
          
        }
        public int Id { get; private set; }
    }
}