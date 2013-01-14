namespace Last.fm.API.BaseLastFm
{
    /// <summary>
    /// 
    /// </summary>
    public interface IApiKeys
    {
        /// <summary>
        /// WebServices ApiKey
        /// </summary>
        string ApiKey { get; }

        /// <summary>
        /// WebServices ApiSig
        /// </summary>
        string ApiSig { get; }
    }
}
