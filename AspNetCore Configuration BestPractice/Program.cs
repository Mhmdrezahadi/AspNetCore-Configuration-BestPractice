using AspNetCore_Configuration_BestPractice.Database;
using AspNetCore_Configuration_BestPractice.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add Extera App Configuration
builder.Host.ConfigureAppConfiguration(AddConfiguration);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    // connectionstring is obtained from usersecret in development and envrionment variables in production
    // so after deploy on server you will give usersecret to devops engineer to set in environment variables
    // so no body can see sensitive data in git repository like github
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

// using strongly typed configuration: map json setting to c# objects (POCO objects)
// to use MapSettings as a service should inject IOptions<MapSettings> or IOptionsSnapshot<MapSettings> to your class
// IOtions<T> & IOptionsSnapshot<T> registered in DI Container as singleton and exposes a value property
// to access genereic T properties
builder.Services.Configure<MapSettings>(builder.Configuration.GetSection(nameof(MapSettings)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

static void AddConfiguration(HostBuilderContext host, IConfigurationBuilder config)
{
    #region Explain
    // in best practice we dont store sensitve data (connection strings,Api Keys,Secrets, .. )
    // in appsettings.json in every development environment
    // we should store them in Environement Variables or UserSecrets

    // use environment variables in production and user secrets in development

    // UserSecret is a json file created outside project folder (somewhere in os)
    // to store sensitive data to not push in git repository
    // every project has own UserSecret (separated by GUID stored in project.csproj)
    #endregion

    //add UserSecret Just in Development
    if (host.HostingEnvironment.IsDevelopment())
        config.AddUserSecrets<Program>();

    //other json file are added based on evironement by default
}
