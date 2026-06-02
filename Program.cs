using InterviewSenseAPI.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddControllers();


var app = builder.Build();

app.UseCors("ReactPolicy");

app.MapControllers();

app.Run();