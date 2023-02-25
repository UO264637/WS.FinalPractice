var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
	var groupName = "v1";
	options.SwaggerDoc(groupName, new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Title = $"Recipe Searcher {groupName}",
		Version = groupName,
		Description = "Recipe Searcher API",
		Contact = new Microsoft.OpenApi.Models.OpenApiContact
		{
			Name = "Company by Carmen and María",
			Email = string.Empty,
			Url = new Uri("https://uniovi.recipesearcher.com/")
		}
	});
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.html", "Recipe Searcher API V1");
});

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
