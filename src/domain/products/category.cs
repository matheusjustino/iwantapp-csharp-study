namespace iwantapp.domain.products;

public class Category : Entity {
    public string name { get; set; }
    public bool active { get; set; } = true;
}