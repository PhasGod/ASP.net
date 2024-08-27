var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TheLoai}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "the-loai",
    pattern: "the-loai/{action=Index}/{id?}",
    defaults: new { controller = "TheLoai", action = "Index" });

app.MapControllerRoute(
    name: "trang-chu",
    pattern: "trang-chu/{action=Index}/{id?}",
    defaults: new { controller = "Home", action = "Index" });

app.MapControllerRoute(
    name: "trang-chinh",
    pattern: "trang-chinh",
    defaults: new { controller = "Home", action = "Index" });


app.Run();
