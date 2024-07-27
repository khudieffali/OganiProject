using Business;
using Data;
using Infrastructure.Services.Abstarcts;
using Infrastructure.Services.Concretes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
DataServiceInjection.DataServices(builder.Services, builder.Configuration) ;

builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(IBusinessService).Assembly));

builder.Services.AddSingleton<IDateTimeService, DateTimeService>();
builder.Services.AddSingleton<IFileService, FileService>();
builder.Services.AddRouting(x => x.LowercaseUrls = true);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
         name: "areas",
         pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
       );   
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
