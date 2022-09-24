using Flunt.Validations;

namespace iwantapp.domain.products;

public class Category : Entity {
    public string name { get; set; }
    public bool active { get; set; }

    public Category(string name) {
        var contract = new Contract<Category>();
        contract.IsNotNullOrEmpty(name, "name", "name is required");

        AddNotifications(contract);

        this.name = name;
        this.active = true;
    }
}