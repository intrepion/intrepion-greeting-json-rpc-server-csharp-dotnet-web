var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

var ClientUrl = Environment.GetEnvironmentVariable("CLIENT_URL") ?? "http://localhost:5193";
Console.WriteLine($"Client URL: {ClientUrl}");

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

app.MapGet("/", () => $"Client URL: <a href=\"{ClientUrl}\">{ClientUrl}</a>\n\nHello World!");
app.MapPost("/", async context => {
    var request = await context.Request.ReadFromJsonAsync<JsonRpcRequest>();
    var Id = request?.Id ?? "";
    var Jsonrpc = request?.Jsonrpc ?? "";
    var Name = request?.Params?.Name ?? "World";
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
