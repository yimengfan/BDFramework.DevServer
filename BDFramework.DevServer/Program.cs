using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//使用kestrel内核
builder.WebHost.UseKestrel(so =>
{
    int PORT = 9999;
    so.Limits.MaxConcurrentConnections = 10000;
    so.Limits.MaxConcurrentUpgradedConnections = 10000;
    so.Limits.MaxRequestBodySize = 52428800;
    so.Listen(IPAddress.Loopback, port: PORT);
    so.ListenAnyIP( PORT);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
