using LatelierWebApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region UseCors
string MyAllowSpecificOrigins = "MyAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
    policy =>
    {
        policy.WithOrigins("http://localhost:4200",
                            "https://localhost:4200");
    });
});
#endregion

builder.Services.AddTransient<IPlayerRepository, PlayerRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
#region UseCors
app.UseCors(MyAllowSpecificOrigins);
#endregion
app.MapControllers();

app.Run();
