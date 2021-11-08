using AppDDD.Catalogo.Application;
using AppDDD.Catalogo.Application.Services;
using AppDDD.Catalogo.Data;
using AppDDD.Catalogo.Data.Repository;
using AppDDD.Catalogo.Domain.Events;
using AppDDD.Catalogo.Domain.Interfaces.Repositories;
using AppDDD.Catalogo.Domain.Interfaces.Services;
using AppDDD.Catalogo.Domain.Services;
using AppDDD.Core.Bus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AppDDD.WebApp.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatrHandler, MediatrHandler>();

            // Catalogo
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<CatalogoContext>();

            services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventHandler>();
        }
    }
}