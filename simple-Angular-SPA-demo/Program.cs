var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
.AddApiVersioning()
.AddControllers();

var MyAllowSpecificOrigins = "_allowSpecificOrigins";
builder.Services.AddCors(options =>
{
	options.AddPolicy(name: MyAllowSpecificOrigins,
					  builder =>
					  {
						  builder.WithOrigins("http://localhost:4200");
					  });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action?}/{id?}");
app.MapControllers();

app.UseCors(MyAllowSpecificOrigins);
app.Run();
