﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BDFramework.AssetBundleCacheServer.Result;

[DefaultStatusCode(601)]
public class Error : ObjectResult
{
    public Error(object? value) : base(value)
    {
        
    }
}
