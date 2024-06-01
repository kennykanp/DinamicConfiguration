using DTOValidatorCentralizedConfiguration.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext Configuration
builder.Services.AddDbContext<LocalizationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
}, ServiceLifetime.Singleton);

var context = builder.Services.BuildServiceProvider().GetRequiredService<LocalizationDbContext>();
context.Database.EnsureCreated();

// Custom Localization Configuration
builder.Services.AddSingleton<IStringLocalizerFactory, DatabaseStringLocalizerFactory>();
builder.Services.AddSingleton<IStringLocalizer, DatabaseStringLocalizer>();

// Add Localization Configuration
builder.Services.AddLocalization();
var localizationOptions = new RequestLocalizationOptions();

var supportedCultures = new List<CultureInfo>
{
    new CultureInfo("en-US"),
    new CultureInfo("es-ES"),
};

localizationOptions.SupportedCultures = supportedCultures;
localizationOptions.SupportedUICultures = supportedCultures;
localizationOptions.SetDefaultCulture("en-US");
localizationOptions.ApplyCurrentCultureToResponseHeaders = true;

//builder.Services.AddLocalization();
//builder.Services.Configure<RequestLocalizationOptions>(options =>
//{
//    options.DefaultRequestCulture = new RequestCulture("en-US");
//    options.SupportedCultures = supportedCultures;
//    options.SupportedUICultures = supportedCultures;
//});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRequestLocalization(localizationOptions);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.RunAsync().Wait();
