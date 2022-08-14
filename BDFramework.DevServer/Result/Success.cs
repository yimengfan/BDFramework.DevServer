using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BDFramework.AssetBundleCacheServer.Result;

[DefaultStatusCode(200)]
public class Success : ObjectResult
{
    public Success(object? value) : base(value)
    {
        
    }
}
