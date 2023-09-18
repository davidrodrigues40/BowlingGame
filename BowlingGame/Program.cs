using BowlingGame.Abstractions.Services;
using BowlingGame.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
	.AddEndpointsApiExplorer()
	.AddSwaggerGen()
	.AddSingleton<IGameService, GameService>()
	.AddSingleton<IBowlService, BowlService>()
	.AddSingleton<IRatedGameService, RatedGameService>()
	.AddSingleton<IScoreCalculator, ScoreCalculator>()
	.AddCors();

builder.Services.AddControllers().AddNewtonsoftJson();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.Run();
