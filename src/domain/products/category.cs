using Flunt.Validations;

namespace iwantapp.domain.products;

public class Category : Entity {
    public string name { get; private set; }
    public bool active { get; private set; }

    public Category(string name, string createdBy, string editedBy) {
        this.name = name;
        this.active = true;
        this.createdBy = createdBy;
        this.editedBy = editedBy;
        this.createdOn = DateTime.Now;
        this.editedOn = DateTime.Now;

        validate();
    }

    private void validate() {
        var contract = new Contract<Category>();
        contract
            .IsNotNullOrEmpty(this.name, "name", "name is required")
            .IsGreaterOrEqualsThan(this.name, 3, "name")
            .IsNotNullOrEmpty(this.createdBy, "createdBy", "createdBy is required")
            .IsNotNullOrEmpty(this.editedBy, "editedBy", "editedBy is required");

        AddNotifications(contract);
    }

    public void editInfo(string? name, bool? active) {
        if (active != null) {
            this.active = (bool) active;
        }
        if (name != null) {
            this.name = name;
        }
        
         validate();
    }
}