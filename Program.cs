var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();          // enables controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();           // Swagger = test page for your API

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();                     // open https://localhost:PORT/swagger
}

app.UseHttpsRedirection();
app.MapControllers();                       // connects URLs to controllers
app.Run();
