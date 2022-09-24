using iwantapp.infra.data;

namespace iwantapp.endpoints.categories;

public class CategoryGetAll {
    // ao criar a propriedade template já atribui o valor "/categories"
    public static string template => "/categories";
    public static string[] methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate handle => Action;

    public static IResult Action(ApplicationDbContext context) {
        var categories = context.categories.ToList().Select(c => new CategoryResponse{ id = c.id, name = c.name, active = c.active });

        return Results.Ok(categories);
    }
}