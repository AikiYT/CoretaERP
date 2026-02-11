var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//builder.Services.AddDbContext<IdentityContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));


builder.Services.AddSession();

builder.Services.AddHttpContextAccessor();
//builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//builder.Services.AddScoped<IWebAppAccountService, WebAppAccountService>(); 
//-------------------------------------------------------------------------------------------------------------
// Agregar servicios
//builder.Services.AddApplicationLayer(_config); // Solo uno de estos es necesario, revisa si es duplicado
//builder.Services.AddSharedInfrastructure(_config);
//-------------------------------------------------------------------------------------------------------------


// Después que ya registraste todo:
var app = builder.Build();

// Configure the HTTP request pipeline.
// Commit Anderson
// Otro commit
// Otro commit 2222

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
