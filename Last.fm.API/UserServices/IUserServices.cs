using System;
using System.Xml;
using Last.fm.API.BaseLastFm;

namespace Last.fm.API.UserServices
{
    public interface IUserServices : IApiKey, IDisposable
    {
        XmlDocument GetRecentTracks(string user);
    }
}
