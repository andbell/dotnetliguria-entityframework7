using DotNetLiguria.EF7.Configurations;
using DotNetLiguria.EF7.Conventions;
using DotNetLiguria.EF7.Interceptors;
using DotNetLiguria.EF7.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DotNetLiguria.EF7;

public class MovieContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            // attiva la registrazione dei dati sensibili
            //.EnableSensitiveDataLogging()

            // Imposta il comportamento di rilevamento predefinito per le query
            //.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll)

            // Errori di query più dettagliati (a spesa delle prestazioni)
            //.EnableDetailedErrors()

            // È possibile per esempio intercettare la connessione per effettuare una connessione di SQL Azure tramite AAD (e ottenere un token di accesso)
            //.AddInterceptors(new AadAuthenticationInterceptor())
            // o taggare ogni query eseguita
            //.AddInterceptors(new TaggedQueryCommandInterceptor())
            .AddInterceptors(new MyMaterializationInterceptor())
            .AddInterceptors(new SetRetrievedInterceptor())

            // Require the package "Microsoft.EntityFrameworkCore.Proxies" - viene abilitato il caricamento lazy per qualsiasi proprietà di navigazione che può essere sottoposta a override (virtual)
            //.UseLazyLoadingProxies()

            // usa SqlServer
            .UseSqlServer(@"Server=.;Database=EF7;Trusted_Connection=true;Encrypt=False")
                .LogTo(Console.WriteLine, LogLevel.Information);
    }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new MovieConfiguration());
        modelBuilder.ApplyConfiguration(new SerieTvConfiguration());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder.Conventions.Add(_ => new DiscriminatorLengthConvention());
        configurationBuilder.Conventions.Add(_ => new MaxStringLengthConvention());
    }
}
