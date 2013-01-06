using System;
using System.Xml;
using Last.fm.API.Channel;

namespace Last.fm.API.UserServices
{
    public interface IUserServices : IApiKey, IDisposable
    {
        XmlElement GetRecentTracks(string user);
    }
}
