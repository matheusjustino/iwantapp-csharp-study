using iwantapp.domain.products;
using iwantapp.infra.data;

namespace iwantapp.endpoints.categories;

public class CategoryPost {
    // ao criar a propriedade template já atribui o valor "/categories"
    public static string template => "/categories";
    public static string[] methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate handle => Action;

    public static IResult Action(CategoryRequest request, ApplicationDbContext context) {
        var category = new Category{
            name = request.name,
            createdBy = "Test",
            editedBy = "Test",
            createdOn = DateTime.Now,
            editedOn = DateTime.Now
        };

        context.categories.Add(category);
        context.SaveChanges();

        return Results.Created($"/categories/${category.id}", category.id);
    }
}