using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DotNetLiguria.EF7.Interceptors;

public class MyMaterializationInterceptor : IMaterializationInterceptor
{
    public InterceptionResult<object> CreatingInstance(
        MaterializationInterceptionData materializationData,
        InterceptionResult<object> result) => result;

    public object CreatedInstance(
        MaterializationInterceptionData materializationData,
        object entity) => entity;

    public InterceptionResult InitializingInstance(
        MaterializationInterceptionData materializationData,
        object entity, InterceptionResult result) => result;

    public object InitializedInstance(
        MaterializationInterceptionData materializationData,
        object entity) => entity;
}
