var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
var allowed_origins = builder.Configuration.GetValue<string>( "OrigenesAllowed" )!.Split( "," );
builder.Services.AddCors( optionss =>
{
  optionss.AddDefaultPolicy( rob_policy =>
  {
    rob_policy.WithOrigins( allowed_origins ).AllowAnyHeader().AllowAnyMethod();
  } );
} );

var app = builder.Build();

// Configure the HTTP request pipeline.
if( app.Environment.IsDevelopment() )
{
  app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
