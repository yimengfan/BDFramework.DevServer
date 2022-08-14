namespace BDFramework.AssetBundleCacheServer.Result;

/// <summary>
/// 统一返回对象的格式
/// </summary>
public class ResultObject
{
    /// <summary>
    /// 返回码
    /// </summary>
    public int Code;
    /// <summary>
    /// 返回消息
    /// </summary>
    public string Msg;
    /// <summary>
    /// 返回数据
    /// </summary>
    public object Data;
}
