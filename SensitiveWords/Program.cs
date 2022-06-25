using SensitiveWords;
using SensitiveWords.Model;

var builder = WebApplication.CreateBuilder(args);
SensitiveWordsBuilderSetup.Configure(builder);
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DatabaseContext>();
    context.Database.EnsureCreated();
    DatabaseInitializer.Initialize(context);
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

