//-----------------------------------------------------------------------
// <copyright file="IAlbumServices.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Last.fm.API.Core;

namespace Last.fm.API.Album
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAlbumServices : IApiKeys
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="artist"></param>
        /// <param name="album"></param>
        /// <param name="mbid"></param>
        /// <param name="username"></param>
        /// <param name="autocorrect"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        BaseResponse GetInfo(string artist, string album, string mbid = "", string username = "", byte autocorrect = 0, string lang = "en");
    }
}
