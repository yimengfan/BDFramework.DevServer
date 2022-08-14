using Microsoft.AspNetCore.Http;

namespace BDFramework.DevServer.AssetbundleCacheController;

public class Data
{
    /// <summary>
    /// 上传ab文件的数据
    /// </summary>
    public class UploadAssetbundleData
    {
        /// <summary>
        /// 项目名
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// unity版本
        /// </summary>
        public string UnityVersion { get; set; }
        /// <summary>
        /// 平台
        /// </summary>
        public string Platform { get; set; }
        
        /// <summary>
        /// 文件名：使用原资产颗粒度包含资源+按guid排序+byte拼接+取murmurhash3 生成
        /// </summary>
        public string FileName { get; set; }
        
        /// <summary>
        /// 校验hash
        /// 采用murmur hash3
        /// </summary>
        public string Hash { get; set; }
        /// <summary>
        /// Assetbundle文件
        /// </summary>
        public IFormFile AssetbundleFile { get; set; }
    }
    
    
    /// <summary>
    /// 下载ab文件的数据
    /// </summary>
    public class DownloadAssetbundleData
    {
        /// <summary>
        /// 项目名
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// unity版本
        /// </summary>
        public string UnityVersion { get; set; }
        /// <summary>
        /// 平台
        /// </summary>
        public string Platform { get; set; }
        
        /// <summary>
        /// 文件名：使用原资产颗粒度包含资源+按guid排序+byte拼接+取murmurhash3 生成
        /// </summary>
        public string FileName { get; set; }
        
    }
    
}
