using iwantapp.domain.products;
using iwantapp.infra.data;

namespace iwantapp.endpoints.categories;

public class CategoryPost {
    // ao criar a propriedade template já atribui o valor "/categories"
    public static string template => "/categories";
    public static string[] methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate handle => Action;

    public static IResult Action(CategoryPostRequest request, ApplicationDbContext context) {
        /* validação do DTO agora é feita no dominio Category */
        // if (string.IsNullOrEmpty(request.name)) {
        //     return Results.BadRequest("Name is required");
        // }

        var category = new Category(request.name){
            createdBy = "Test",
            editedBy = "Test",
            createdOn = DateTime.Now,
            editedOn = DateTime.Now
        };

        if (!category.IsValid) {
            return Results.BadRequest(category.Notifications);
        }

        context.categories.Add(category);
        context.SaveChanges();

        return Results.Created($"/categories/${category.id}", category.id);
    }
}