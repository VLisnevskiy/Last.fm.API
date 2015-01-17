//-----------------------------------------------------------------------
// <copyright file="IArtistServicesApi.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ServiceModel;
using System.ServiceModel.Web;
using Last.fm.API.BaseLastFm;
using Last.fm.API.Core;

namespace Last.fm.API.Artist
{
    [ServiceContract]
    [XmlSerializerFormat]
    internal interface IArtistServicesApi : IApiKeys
    {
        #region artist.getInfo

        /// <summary>
        /// Get the metadata for an artist. Includes biography, truncated at 300 characters. 
        /// </summary>
        /// <param name="apiKey">api_key (Required) : A Last.fm API key.</param>
        /// <param name="artist">artist (Required (unless mbid)] : The artist name</param>
        /// <param name="username">username (Optional) : The username for the context of the request. If supplied, the user's playcount for this artist is included in the response.</param>
        /// <param name="mbid">mbid (Optional) : The musicbrainz id for the artist</param>
        /// <param name="lang">lang (Optional) : The language to return the biography in, expressed as an ISO 639 alpha-2 code.</param>
        /// <param name="autocorrect">autocorrect[0|1] (Optional) : Transform misspelled artist names into correct artist names, returning the correct version instead. The corrected artist name will be returned in the response.</param>
        /// <returns>Artst info</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "?method=artist.getInfo&api_key={apiKey}&artist={artist}&username={username}&mbid={mbid}&lang={lang}&autocorrect={autocorrect}")]
        ArtistInfo GetInfo(string apiKey, string artist, string username = null, string mbid = null, string lang = null, bool autocorrect = true);

        #endregion
    }
}
