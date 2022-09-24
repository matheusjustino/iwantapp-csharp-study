using iwantapp.infra.data;
using Microsoft.AspNetCore.Mvc;

namespace iwantapp.endpoints.categories;

public class CategoryDelete {
    // ao criar a propriedade template já atribui o valor "/categories"
    public static string template => "/categories/{id}";
    public static string[] methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate handle => Action;

    public static IResult Action([FromRoute] Guid id, ApplicationDbContext context) {
        var dbCategory = context.categories.Where(c => c.id == id).FirstOrDefault();

        if (dbCategory == null) {
            return Results.NotFound();
        }

        context.categories.Remove(dbCategory);
        context.SaveChanges();

        return Results.Ok();
    }
}