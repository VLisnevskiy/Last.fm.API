//-----------------------------------------------------------------------
// <copyright file="IApiKeys.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Last.fm.API.Core
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
