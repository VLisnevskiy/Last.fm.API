using System.ServiceModel;
using System.ServiceModel.Web;
using System.Xml;
using Last.fm.API.BaseLastFm;

namespace Last.fm.API.AlbumServices
{
    [ServiceContract]
    [XmlSerializerFormat(Style = OperationFormatStyle.Document, SupportFaults = true)]
    internal interface IAlbumServicesApi : IApiKeys
    {
        #region Don't use User Authentication

        #region album.getInfo
        /*
         * album.getInfo
         * 
         * Params
         * artist (Required (unless mbid)] : The artist name
         * album (Required (unless mbid)] : The album name
         * mbid (Optional) : The musicbrainz id for the album
         * autocorrect[0|1] (Optional) : Transform misspelled artist names into correct artist names, returning the correct version instead. The corrected artist name will be returned in the response.
         * username (Optional) : The username for the context of the request. If supplied, the user's playcount for this album is included in the response.
         * lang (Optional) : The language to return the biography in, expressed as an ISO 639 alpha-2 code.
         * api_key (Required) : A Last.fm API key.
         * 
         * ?method=user.getrecenttracks & user={user} & api_key=4930efce82e84fef13f6309659fe2bcd &raw=true"
         */

        /*[OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "?method=album.getInfo&raw=true&artist={artist}&album={album}&api_key={apiKey}")]
        XmlDocument GetRecentTracks(string artist, string album, string apiKey);*/

        [OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "?method=album.getInfo&raw=true&api_key={apiKey}&artist={artist}&album={album}&mbid={mbid}&username={username}&autocorrect={autocorrect}&lang={lang}")]
        XmlDocument GetInfo(string apiKey, string artist, string album, string mbid = "", string username = "", byte autocorrect = 0, string lang = "en");
        
        #endregion

        #endregion
    }
}
