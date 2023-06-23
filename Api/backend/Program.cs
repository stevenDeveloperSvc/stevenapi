using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Services;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);




// var connString = builder.Configuration.GetConnectionString("defaultConnection");
//builder.Services.AddSqlServer<SalesDBContext>(connString);

builder.Services.AddDbContext<SalesDBContext>(options =>
                                               options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));







builder.Services.AddControllers();
// builder.Services.AddDbContext<SaleContext>(opt=>
//         opt.UseInMemoryDatabase("da")
// );
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();






builder.Services.AddScoped<productServices>();
builder.Services.AddScoped<userServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

//app.UseCors();

//   app.UseCors(x => x
//                     .AllowAnyMethod()
//                     .AllowAnyHeader()
//                     .SetIsOriginAllowed(origin => true) // allow any origin
//                     //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins separated with comma
//                     .AllowCredentials()); // allow credentials


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

//app.UseAuthentication();

// app.UseAuthorization();

app.MapControllers();

app.Run();
