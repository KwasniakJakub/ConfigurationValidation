
using Microsoft.Extensions.Options;
using ConfigurationValidation;
using ConfigurationValidation.Configuration;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.

builder.Services.AddControllers();
//Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<SampleService>();

//builder.Services.Configure<ServiceConfiguration>(
//    builder.Configuration.GetSection(ServiceConfiguration.SectionName));

//builder.Services.AddOptions<ServiceConfiguration>()
//    .Configure<IConfiguration>((serviceConfig, configuration) =>
//    {
//        var configSection = configuration.GetSection(ServiceConfiguration.SectionName);
//        configSection.Bind(serviceConfig);

//        if (string.IsNullOrEmpty(serviceConfig.ApiKey))
//        {
//            throw new ArgumentNullException("serviceConfigurtion ApiKey is missing");
//        }
//    });

builder.Services.AddOptions<ServiceConfiguration>()
    .Bind(builder.Configuration.GetSection(ServiceConfiguration.SectionName))
    .ValidateOnStart();//Walidacja przy starcie aplikacji
    //.ValidateDataAnnotations()
    //.Validate((config) =>
    //{
    //    return config.LowestPriority < config.HighestPriority;
    //}, "Highest priority must be greater than lowest priority");

builder.Services.AddSingleton<IValidateOptions<ServiceConfigurationValidator>>();

var app = builder.Build();

//Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();