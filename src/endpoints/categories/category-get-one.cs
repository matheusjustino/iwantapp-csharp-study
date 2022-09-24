using iwantapp.infra.data;
using Microsoft.AspNetCore.Mvc;

namespace iwantapp.endpoints.categories;

public class CategoryGetOne {
    // ao criar a propriedade template já atribui o valor "/categories"
    public static string template => "/categories/{id}";
    public static string[] methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate handle => Action;

    public static IResult Action([FromRoute] Guid id, ApplicationDbContext context) {
        var dbCategory = context.categories.Where(c => c.id == id).FirstOrDefault();

        if (dbCategory == null) {
            return Results.NotFound();
        }

        return Results.Ok(new CategoryResponse{ id = dbCategory.id, name = dbCategory.name, active = dbCategory.active });
    }
}