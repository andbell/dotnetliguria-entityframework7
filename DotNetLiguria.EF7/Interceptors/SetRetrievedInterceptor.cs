using DotNetLiguria.EF7.Contracts;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DotNetLiguria.EF7.Interceptors;

public class SetRetrievedInterceptor : IMaterializationInterceptor
{
    public object InitializedInstance(MaterializationInterceptionData materializationData, object instance)
    {
        if (instance is IHasRetrieved hasRetrieved)
        {
            hasRetrieved.Retrieved = DateTime.UtcNow;
        }

        return instance;
    }
}