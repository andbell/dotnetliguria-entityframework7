using DotNetLiguria.EF7.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetLiguria.EF7;

public class MovieContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }

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

            // Require the package "Microsoft.EntityFrameworkCore.Proxies" - viene abilitato il caricamento lazy per qualsiasi proprietà di navigazione che può essere sottoposta a override (virtual)
            //.UseLazyLoadingProxies()

            // usa SqlServer
            .UseSqlServer(@"Data Source=.;Initial Catalog=EF7;User ID=ef7;Password=qwertysecure;Encrypt=False",
                providerOptions => { providerOptions.EnableRetryOnFailure(); });
    }
}
