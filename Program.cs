using iwantapp.endpoints.categories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<iwantapp.infra.data.ApplicationDbContext>(options => {
    var connectionString = builder.Configuration["ConnectionStrings:IWantDb"];
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "It's working!");

app.MapMethods(CategoryPost.template, CategoryPost.methods, CategoryPost.handle);
app.MapMethods(CategoryGetAll.template, CategoryGetAll.methods, CategoryGetAll.handle);
app.MapMethods(CategoryGetOne.template, CategoryGetOne.methods, CategoryGetOne.handle);
app.MapMethods(CategoryPut.template, CategoryPut.methods, CategoryPut.handle);
app.MapMethods(CategoryDelete.template, CategoryDelete.methods, CategoryDelete.handle);

app.Run();
