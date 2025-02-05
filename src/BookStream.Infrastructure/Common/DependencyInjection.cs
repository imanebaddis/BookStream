using BookStream.Application.Common.Interfaces.Repositories;
using BookStream.Infrastructure.Books;
using BookStream.Infrastructure.Categories.Persistence;
using BookStream.Infrastructure.Common.Configuration;
using BookStream.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Supabase;


namespace BookStream.Infrastructure.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            /// Add the StatisticsDbContext to the services
            /* services.AddDbContextFactory<BookStreamDbContext>(options =>
                 options.UseNpgsql(configuration.GetConnectionString("PostgreSqlConnection")));*/

            services.AddOptions<SupabaseConfiguration>()
                .BindConfiguration(nameof(SupabaseConfiguration))
                .ValidateOnStart();

            // Register repositories
            //services.AddSingleton<IBookRepository, BookRepository>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();   

            var key = configuration["SupabaseConfiguration:Key"] ?? throw new ArgumentNullException("SupabaseConfiguration:Key is required");
            var url = configuration["SupabaseConfiguration:Url"] ?? throw new ArgumentNullException("SupabaseConfiguration:Url is required");


            var options = new SupabaseOptions
            {
                AutoRefreshToken = true,
                AutoConnectRealtime = true,
            };

            services.AddSingleton(provider => new Supabase.Client(url, key, options));

            return services;   
        } 
    }
}