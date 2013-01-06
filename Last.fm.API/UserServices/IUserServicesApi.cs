using System.ServiceModel;
using System.ServiceModel.Web;
using System.Xml;
using Last.fm.API.Channel;

namespace Last.fm.API.UserServices
{
    [ServiceContract]
    [XmlSerializerFormat(Style = OperationFormatStyle.Document, SupportFaults = true)]
    internal interface IUserServicesApi : IApiKey
    {
        #region Don't use User Authentication

        #region user.getRecentTracks

        /*
         * user.getRecentTracks
         * 
         * limit (Optional) : The number of results to fetch per page. Defaults to 50. Maximum is 200.
         * user (Required) : The last.fm username to fetch the recent tracks of.
         * page (Optional) : The page number to fetch. Defaults to first page.
         * from (Optional) : Beginning timestamp of a range - only display scrobbles after this time, in UNIX timestamp format (integer number of seconds since 00:00:00, January 1st 1970 UTC). This must be in the UTC time zone.
         * extended (0|1) (Optional) : Includes extended data in each artist, and whether or not the user has loved each track
         * to (Optional) : End timestamp of a range - only display scrobbles before this time, in UNIX timestamp format (integer number of seconds since 00:00:00, January 1st 1970 UTC). This must be in the UTC time zone.
         * 
         * api_key (Required) : A Last.fm API key.
         */

        [OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "?method=user.getRecentTracks&raw=true" +
                          "&api_key={apiKey}" +
                          "&user={user}")]
        XmlElement GetRecentTracks(string apiKey, string user);

        #endregion

        #endregion
    }
}
