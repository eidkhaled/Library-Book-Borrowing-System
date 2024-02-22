using DataBase;
using DTOS_BuissnesLogic.Buissneslogic;
using DTOS_BuissnesLogic.InterFaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(
        //    c =>
        //{
        //    c.AddPolicy("AllowOrigin", options =>
        //    {
        //        options.AllowAnyOrigin()
        //        ; options.AllowAnyHeader();
        //    });
        //    c.AddPolicy(name: "MyPolicy",
        //       policy =>
        //       {
        //           //WithOrigins("https://localhost:4200"
        //           //                   )
        //           policy.AllowAnyOrigin()
        //                   .WithMethods("PUT", "POST", "DELETE", "GET", "OPTIONS").AllowAnyHeader().WithHeaders("Authorization");
        //           ;
        //       });
        //}
        );
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IBookCopyRepository, CopyRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Books_Progect"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (true/*app.Environment.IsDevelopment()*/)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.UseCors(options => options.AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
