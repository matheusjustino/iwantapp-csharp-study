namespace iwantapp.domain.products;

public class Product : Entity {
    public string name { get; set; }
    public Guid categoryId { get; set; }
    public Category category { get; set; }
    public string description { get; set; }
    public bool hasStock { get; set; } = true;
}
