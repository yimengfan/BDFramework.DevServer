using BDFramework.AssetBundleCacheServer.Result;
using BDFramework.DevServer.AssetbundleCacheController;
using BDFramework.Service;
using Microsoft.AspNetCore.Mvc;

namespace BDFramework.DevServer.Controllers;

/// <summary>
/// 这里是AssetBundle服务器的辅助开发
/// 主要用于打包AssetBundle的缓存,下载
/// </summary>
[ApiController]
[Route("[controller]")]
public class AssetbundleCacheController : ControllerBase
{
    private AssetBundleIOService assetBundleIoService;

    public AssetbundleCacheController(AssetBundleIOService assetBundleIoService)
    {
        this.assetBundleIoService = assetBundleIoService;
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
        //
        try
        {
            MemoryStream ms = new MemoryStream();
            uploadData.AssetbundleFile.CopyTo(ms);
            var fileBytes = ms.ToArray();

            //校验hash
            var murmurHash = FileHelper.GetMurmurHash3(fileBytes);
            if (!murmurHash.Equals(uploadData.Hash))
            {
                return new Fail("Hash校验不一致");
            }

            //写入本地
            var filePath = Path.Combine(uploadData.ProjectName, uploadData.UnityVersion, uploadData.Platform, uploadData.FileName);
            this.assetBundleIoService.SaveFile(filePath, fileBytes);


            return new Success("成功");
        }
        catch (Exception e)
        {
            return new Error(e);
        }
    }

    /// <summary>
    ///  下载AssetBundle
    /// </summary>
    /// <param name="projectName"></param>
    /// <param name="unityVersion"></param>
    /// <param name="platform"></param>
    /// <param name="FileName"> 文件名：使用原资产颗粒度包含资源+按guid排序+byte拼接+取murmurhash3 生成</param>
    /// <returns></returns>
    [HttpGet("Download")]
    public IActionResult Download(string ProjectName, string UnityVersion, string Platform, string FileName)
    {
        var contentType = "application/octet-stream";
        var filePath = Path.Combine(ProjectName, UnityVersion, Platform, FileName);
        var bytes = assetBundleIoService.GetFile(filePath);
        if (bytes != null)
        {
            return new FileContentResult(bytes,contentType);
        }
        
        return new FileContentResult(new byte[] { }, contentType);


    }
}
