using Flunt.Notifications;

namespace iwantapp.domain;

public abstract class Entity : Notifiable<Notification> {
    public Entity() {
        id = Guid.NewGuid();
    }

    public Guid id { get; set; }
    public string createdBy { get; set; }
    public string editedBy { get; set; }
    public DateTime createdOn { get; set; }
    public DateTime editedOn { get; set; }
}