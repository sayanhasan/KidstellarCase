using KidstellarCase.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromHours(2);
});
builder.Services.AddPersistenceServices();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=ParentLogin}/{id?}");

app.Run();
