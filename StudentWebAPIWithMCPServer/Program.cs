using ModelContextProtocol.Protocol;
using SSEStudentTool.Tools;


var builder = WebApplication.CreateBuilder(args);

var serverInfo = new Implementation { Name = "StudentASPControllerWithMCPServer", Version = "1.0.0" };
builder.Services
    .AddMcpServer(mcp =>
    {
        mcp.ServerInfo = serverInfo;
    })
    .WithHttpTransport()
    .WithToolsFromAssembly(typeof(StudentTool).Assembly);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapMcp();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

await app.RunAsync();
