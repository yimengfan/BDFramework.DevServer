namespace BDFramework.Service;

public class AssetBundleIOService
{
    /// <summary>
    /// 缓存目录
    /// </summary>
    private string ROOT_PATH;

    public AssetBundleIOService()
    {
        ROOT_PATH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin/AssetbundleCache");
    }


    /// <summary>
    /// 保存文件
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="bytes"></param>
    public void SaveFile(string fileName, byte[] bytes)
    {
        var filepath = Path.Combine(ROOT_PATH, fileName);
        FileHelper.WriteAllBytes(filepath, bytes);
    }

    /// <summary>
    /// 获取文件
    /// </summary>
    /// <param name="fileName"></param>
    public byte[] GetFile(string fileName)
    {
        var filepath = Path.Combine(ROOT_PATH, fileName);
        if (File.Exists(filepath))
        {
            var bytes = File.ReadAllBytes(filepath);

            return bytes;
        }

        return null;
    }
}
