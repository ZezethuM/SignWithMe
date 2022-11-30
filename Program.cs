using SignWithMe.Interfaces;
using SignWithMe.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
<<<<<<< HEAD
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
=======
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
>>>>>>> 7ff5c28d350f2824c0badb0dba673c434aae19a8

// To display static files
app.UseDefaultFiles();
app.UseStaticFiles();


// app.UseHttpsRedirection();

// app.UseAuthorization();

// app.MapControllers();

app.Run();
