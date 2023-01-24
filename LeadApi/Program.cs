using LeadApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IEmailSender, GmailSender>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var allowBlazorClient = "allowBlazorClient";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowBlazorClient,
                      policy =>
                      {
                          policy.WithOrigins(new[] { "http://localhost:5000", "https://www.averybusiness.net" }).AllowAnyHeader().AllowAnyMethod();
                      });
});

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
app.UseCors(allowBlazorClient);

app.Run();
