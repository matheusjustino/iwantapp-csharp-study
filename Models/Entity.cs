namespace IWantApp.Models;

public class Entity
{
    public Entity()
    {
        this.Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }

    public string CreatedBy { get; set; }

    public string EditedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime UpdatedOn { get; set; }
}
