using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace DotNetLiguria.EF7.Interceptors;

public class TaggedQueryCommandInterceptor : DbCommandInterceptor
{
    public override InterceptionResult<DbDataReader> ReaderExecuting(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result)
    {
        ManipulateCommand(command);
        return result;
    }

    public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result,
        CancellationToken cancellationToken = default)
    {
        ManipulateCommand(command);
        return new ValueTask<InterceptionResult<DbDataReader>>(result);
    }

    private static void ManipulateCommand(DbCommand command)
    {
        // example:
        // var blogs1 = context.Blogs.TagWith("Use robust plan").ToList();
        if (command.CommandText.StartsWith("-- Use robust plan", StringComparison.Ordinal))
            command.CommandText += " OPTION (ROBUST PLAN)";
    }
}
