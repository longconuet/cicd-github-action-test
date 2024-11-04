var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/time/utc", () => Results.Ok(DateTime.UtcNow.ToString("HH:mm:ss dd/MM/yyyy")));
app.MapGet("/time/local", () => Results.Ok(DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy")));

await app.RunAsync();
