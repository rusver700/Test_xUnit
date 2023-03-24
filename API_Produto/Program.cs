using API_Produto.Dominio.Interface;
using API_Produto.Dominio.Servicos;
using API_Produto.Infra.Repositorio;
using Microsoft.OpenApi.Models;
using System.Diagnostics.CodeAnalysis;

internal class Program
{
    [ExcludeFromCodeCoverage]

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api_Produto", Version = "v1.0" });
        });

        builder.Services.AddScoped<IRepositorioProduto, RepositorioProduto>();
        builder.Services.AddScoped<IQuantidadeVendasServico, QuantidadeVendasServico>();
        builder.Services.AddScoped<IMediaVendasServico, MediaVendasServico>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
