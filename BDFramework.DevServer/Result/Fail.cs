using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BDFramework.AssetBundleCacheServer.Result;

[DefaultStatusCode(600)]
public class Fail : ObjectResult
{
    public Fail(object? value) : base(value)
    {
        
    }
}
