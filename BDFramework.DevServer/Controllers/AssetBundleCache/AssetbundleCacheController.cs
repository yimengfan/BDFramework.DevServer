using BDFramework.AssetBundleCacheServer.Result;
using BDFramework.DevServer.AssetbundleCacheController;
using Microsoft.AspNetCore.Mvc;

namespace BDFramework.DevServer.Controllers.AssetbundleCache;

/// <summary>
/// 这里是AssetBundle服务器的辅助开发
/// 主要用于打包AssetBundle的缓存,下载
/// </summary>
[ApiController]
[Route("[controller]")]
public class AssetbundleCacheController : ControllerBase
{
    readonly private IHostEnvironment hostEnvironment;

    public AssetbundleCacheController(IHostEnvironment hostEnvironment)
    {
        this.hostEnvironment = hostEnvironment;
    }

    /// <summary>
    /// 连接
    /// </summary>
    /// <returns></returns>
    [HttpGet("Connect")]
    public string Connect()
    {
        return "Connect assetbundle cache server success!";
    }

    /// <summary>
    /// 获取项目AssetBundle列表
    /// </summary>
    /// <returns></returns>
    public IActionResult GetProjectAssetbundleList(string projectName, string unityVersion, string platform)
    {
        return null;
    }


    /// <summary>
    ///  上传
    /// </summary>
    /// <param name="projectName">项目名</param>
    /// <param name="unityVersion">Unity版本号</param>
    /// <param name="platform">平台</param>
    /// <param name="hash"></param>
    /// <param name="assetbundleFile"></param>
    /// <returns></returns>
    [HttpPost("Upload")]
    public IActionResult Upload([FromForm] Data.UploadAssetbundleData uploadData)
    {
        var filePath = Path.Combine(uploadData.ProjectName, uploadData.UnityVersion, uploadData.Platform, uploadData.Hash);
        var savePath = Path.Combine(this.hostEnvironment.ContentRootPath, "bin/AssetbundleCache", filePath);
        //保存
        var dir = Path.GetDirectoryName(savePath);
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        //
        try
        {
            if (!System.IO.File.Exists(savePath))
            {
                using (var fileStream = System.IO.File.Create(savePath))
                {
                    uploadData.AssetbundleFile.CopyTo(fileStream);
                }

                Console.WriteLine("[缓存ab]: 写入成功 - " + savePath);
            }
            else
            {
                Console.WriteLine("[缓存ab]:");
            }


            return new Success("成功");
        }
        catch (Exception e)
        {
            return new Error(e);
        }
    }

    /// <summary>
    ///  上传
    /// </summary>
    /// <param name="projectName"></param>
    /// <param name="unityVersion"></param>
    /// <param name="platform"></param>
    /// <param name="hash"></param>
    /// <param name="assetbundleFile"></param>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Download(string hash)
    {
        return new JsonResult(null);
    }
}
