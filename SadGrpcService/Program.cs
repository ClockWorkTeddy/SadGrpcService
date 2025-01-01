using Microsoft.EntityFrameworkCore;
using SadGrpcService.DataBase;
using SadGrpcService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8081, listenOptions =>
    {
        listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2;
    });
});
// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddDbContext<SadSchoolContext>(_ => _.UseSqlServer(builder.Configuration["sad_school_conn_str"]).UseLazyLoadingProxies());

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
