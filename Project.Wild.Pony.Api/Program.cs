var builder = WebApplication.CreateBuilder(args);

// Add DbContext if you use one (keep your existing code here)

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Needed for HTTP -> HTTPS redirect
app.UseHttpsRedirection();

// Enable CORS
app.UseCors();   // ← EXACTLY like the screenshot

app.UseAuthorization();

app.MapControllers();

app.Run();