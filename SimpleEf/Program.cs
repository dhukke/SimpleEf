using Microsoft.EntityFrameworkCore;
using SimpleEf;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(
    optionsBuilder =>
    {
        optionsBuilder.UseNpgsql(builder.Configuration["DbConnectionString"]);
    }
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/detail", async (AppDbContext appDbContext) =>
{
    var id = Guid.NewGuid();

    appDbContext.Details
        .Add(new Detail(id, id.ToString() ));

    await appDbContext.SaveChangesAsync();

    return Results.Created();
})
.WithName("AddDetail")
.WithOpenApi();

app.MapGet("/detail", async (AppDbContext appDbContext) =>
{
    return await appDbContext.Details.ToListAsync();
})
.WithName("GetDetail")
.WithOpenApi();

app.Run();