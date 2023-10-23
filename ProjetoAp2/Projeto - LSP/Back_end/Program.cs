using Back_end.Configurations;
using Back_end.Models.Data;
using Back_end.Models.Data.Repository;
using Back_end.Models.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(typeof(AutoMapperConfigDTOs), typeof(AutoMapperConfigViewModels));


builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<IInstitutoRepository, InstitutoRepository>();
builder.Services.AddScoped<IVoluntariadoRepository, VoluntariadoRepository>();
builder.Services.AddScoped<IVoluntariadoBeneficioRepository, VoluntariadoBeneficioRepository>();
builder.Services.AddScoped<IVoluntariadoResponsabilidadeRepository, VoluntariadoResponsabilidadeRepository>();
builder.Services.AddScoped<IMaterialDoacaoRepository, MaterialDoacaoRepository>();
builder.Services.AddScoped<IPontoDoacaoRepository, PontoDoacaoRepository>();


builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


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

app.Run();
