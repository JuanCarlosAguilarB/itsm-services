using ItsmServices.Src.Priorities.Domain;
using ItsmServices.Src.Priorities.Infrastructure.Adapters;
using ItsmServices.Src.Priorities.Services.Find;
using ItsmServices.Src.StatusModule.Domain;
using ItsmServices.Src.StatusModule.Infrastructure.Adapters;
using ItsmServices.Src.StatusModule.Services.Find;
using ItsmServices.Src.Tickets.Domain;
using ItsmServices.Src.Tickets.Infrastructure.Adapters;
using ItsmServices.Src.Tickets.Infrastructure.Web;
using ItsmServices.Src.Tickets.Infrastructure;
using ItsmServices.Src.Tickets.Services.Create;
using ItsmServices.Src.Tickets.Services.Find;
using ItsmServices.Src.Tickets.Services.Update;
using ItsmServices.Src.Users.Services.Create;
using ItsmServices.Src.Users.Services.Find;
using ItsmServices.Src.Users.Domain;
using ItsmServices.Src.Users.Infrastructure.Persistence;
using ItsmServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//-----------------------------------------------------------------------------------------------
// inyection of dependencies
builder.Services.AddScoped<TicketServices, HttpTicketServices>();
builder.Services.AddScoped<TicketCreator>();
builder.Services.AddScoped<HttpClientServices>();
builder.Services.AddScoped<TickerFinder>();
builder.Services.AddScoped<NoteCreator>();
builder.Services.AddScoped<TicketUpdater>();
builder.Services.AddScoped<ServicesPriority, HttpServicesPriority>();
builder.Services.AddScoped<PriorityFinder>();
builder.Services.AddScoped<ServicesStatus, HttpServicesStatus>();
builder.Services.AddScoped<StatusFinder>();
builder.Services.AddScoped<UserCreator>();
builder.Services.AddScoped<UserRepository, RDUserRepository>();
builder.Services.AddScoped<UserRightFinder>();
builder.Services.AddScoped<UserRightRepository, RDUserRightRepository>();


//-----------------------------------------------------------------------------------------------


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionString:PostgresDb"])
    );

//
builder.Services.AddHttpClient(); // client to http
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
