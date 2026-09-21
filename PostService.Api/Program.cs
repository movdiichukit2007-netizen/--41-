using PostService.BusinessLogic;
using PostService.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IPostingService, PostingService>();
builder.Services.AddScoped<IPostingRepository, PostingRepository>();

var app = builder.Build();

// Піднімаємо міграцію (створюємо таблицю, якщо її ще немає)
// один раз під час запуску, до того, як прийде перший запит
using (var scope = app.Services.CreateScope())
{
    var repository = (PostingRepository)scope.ServiceProvider.GetRequiredService<IPostingRepository>();
    repository.CreateDb();
}

app.MapControllers();

app.Run();
