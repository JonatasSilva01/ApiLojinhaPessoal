using Microsoft.EntityFrameworkCore;
using PrimeiroInfluencer.Data;

var builder = WebApplication.CreateBuilder(args);


// Add Conection db
var conectionString = builder.Configuration.GetConnectionString("LojaOnline");
builder.Services.AddDbContext<DatabaseContext>(options => options.UseMySql(conectionString, ServerVersion.AutoDetect(conectionString)));

// Add auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// add newtonjson (ModelState)
builder.Services.AddControllers().AddNewtonsoftJson();

// add controller.
builder.Services.AddControllers();

// add swagger
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

app.MapControllers();

app.Run();
