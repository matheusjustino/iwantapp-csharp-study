using iwantapp.infra.data;
using Microsoft.AspNetCore.Mvc;

namespace iwantapp.endpoints.categories;

public class CategoryPut {
    // ao criar a propriedade template já atribui o valor "/categories"
    public static string template => "/categories/{id}";
    public static string[] methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate handle => Action;

    public static IResult Action([FromRoute] Guid id, CategoryPutRequest request, ApplicationDbContext context) {
        var dbCategory = context.categories.Where(c => c.id == id).FirstOrDefault();

        if (dbCategory == null) {
            return Results.NotFound();
        }

        /* seta as propriedades de dbCategory com o que está vindo de request. os tipos precisam ser os mesmo */
        // context.Entry(dbCategory).CurrentValues.SetValues(request);

        if (request.name != null) {
            dbCategory.name = request.name;
        }
        if (request.active != null) {
            dbCategory.active = (bool) request.active;
        }

        context.SaveChanges();

        return Results.Ok();
    }
}