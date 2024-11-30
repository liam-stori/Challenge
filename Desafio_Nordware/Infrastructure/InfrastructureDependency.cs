using App.Infrastructure.Persist.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace App.Infrastructure;

public static class InfrastructureDependency
{
    public static IServiceCollection AddInfrastructureDependency(this IServiceCollection services,
        IConfiguration configuration)
    {
        var sessionFactory = Fluently.Configure()
            .Database(PostgreSQLConfiguration.Standard
                .ConnectionString(configuration.GetConnectionString("DefaultConnection"))
                .Driver<NpgsqlDriver>()
                .Dialect<PostgreSQLDialect>())
            .Mappings(m =>
            {
                m.FluentMappings.AddFromAssemblyOf<CustomerMap>();
                m.FluentMappings.AddFromAssemblyOf<ProductMap>();
                m.FluentMappings.AddFromAssemblyOf<ReservationMap>();
            })
            .ExposeConfiguration(cfg =>
            {
                cfg.SetProperty(NHibernate.Cfg.Environment.ShowSql, "true");
            })
            .BuildSessionFactory();

        services.AddSingleton(sessionFactory);

        services.AddScoped<ISession>(provider => sessionFactory.OpenSession());

        return services;
    }
}