using SignWithMe.Interfaces;
using SignWithMe.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connString = builder.Configuration.GetConnectionString("TBConnection");
builder.Services.AddSingleton<IQuestions>(new QuestionsRepo(connString) );
builder.Services.AddSingleton<ISigns>(new SignsRepo(connString) );
builder.Services.AddSingleton<IUser>(new UserRepo(connString) );

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// To display static files
app.UseDefaultFiles();
app.UseStaticFiles();

 app.UseHttpsRedirection();

 app.UseAuthorization();

 app.MapControllers();

app.Run();
