using Book.Application.Interface;
using Book.Application.Services;
using Book.Domain.Interfaces;
using Book.Infra.Data.Context;
using Book.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Book.Infra.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDependencyInjectionRepository();
            services.AddDependencyInjectionService();
            services.AddAutoMapperConfig();
            services.AddContext(configuration);

            return services;
        }

        private static IServiceCollection AddDependencyInjectionRepository(this IServiceCollection services)
        {
            services.AddScoped<BookDbContext>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IBookAuthorRepository, BookAuthorRepository>();
            services.AddScoped<IBookSubjectRepository, BookSubjectRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        private static IServiceCollection AddDependencyInjectionService(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<ISubjectService, SubjectService>();

            return services;
        }

        private static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }

        private static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("BookDb"))
            );

            return services;
        }
    }
}
