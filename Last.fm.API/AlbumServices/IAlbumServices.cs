using System.Xml;
using Last.fm.API.BaseLastFm;

namespace Last.fm.API.AlbumServices
{
    public interface IAlbumServices : IApiKeys
    {
        XmlDocument GetInfo(string artist, string album, string mbid = "", string username = "", byte autocorrect = 0, string lang = "en");
    }
}
