using System.Text;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

var ClientUrl = Environment.GetEnvironmentVariable("CLIENT_URL") ?? "http://localhost:5193";

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.WithOrigins(ClientUrl)
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

var text = $$"""
Client URL: <a href="{{ClientUrl}}">{{ClientUrl}}</a>

Hello, World!
""";

Console.WriteLine(text);

app.MapGet("/", () => text);
app.MapPost("/", async context => {
    var request = await context.Request.ReadFromJsonAsync<JsonRpcRequest>();
    var Id = request?.Id ?? "";
    var Jsonrpc = request?.Jsonrpc ?? "";
    var Name = request?.Params.Name ?? "World";
    var response = new JsonRpcResponse {
        Id = Id,
        Jsonrpc = Jsonrpc,
        Result = new JsonRpcResult {
            Greeting = $"Hello, {Name}!"
        }
    };
    await context.Response.WriteAsJsonAsync(response);
});

app.Run();
