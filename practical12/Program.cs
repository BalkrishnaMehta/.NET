using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(opts => {
    opts.UseMySql(builder.Configuration["ConnectionStrings:ProductConnection"], new MySqlServerVersion(new Version()));
    opts.EnableSensitiveDataLogging(true);
});

var app = builder.Build();

//const String BASEURL = "api/products";

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");


// app.MapGet($"{BASEURL}/{{id}}", async (HttpContext context, DataContext data) =>
// {
//     string? id = context.Request.RouteValues["id"] as string;
//     if (id == null || !int.TryParse(id, out int productId))
//     {
//         context.Response.StatusCode = StatusCodes.Status400BadRequest;
//         return;
//     }

//     Product? p = data.Products.Find(productId);
//     if (p == null)
//     {
//         context.Response.StatusCode = StatusCodes.Status404NotFound;
//     }
//     else
//     {
//         context.Response.ContentType = "application/json";
//         await context.Response.WriteAsync(JsonSerializer.Serialize<Product>(p));
//     }
// });


// app.MapGet(BASEURL, async (HttpContext context, DataContext data) =>
// {
//     context.Response.ContentType = "application/json";
//     await context.Response.WriteAsync(JsonSerializer.Serialize<IEnumerable<Product>>(data.Products));
// });

// app.MapPost(BASEURL, async (HttpContext context, DataContext data) =>
// {
//     Product? p = await JsonSerializer.DeserializeAsync<Product>(context.Request.Body);
//     if (p != null)
//     {
//         await data.AddAsync(p);
//         await data.SaveChangesAsync();
//         context.Response.StatusCode = StatusCodes.Status200OK;
//     }
//     else
//     {
//         context.Response.StatusCode = StatusCodes.Status400BadRequest;
//     }
// });

app.Run();
