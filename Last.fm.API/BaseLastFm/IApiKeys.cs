namespace Last.fm.API.BaseLastFm
{
    /// <summary>
    /// ApiKey & ApiSig
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
