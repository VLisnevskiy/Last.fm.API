using System;
using System.Windows.Forms;
using Last.fm.API;
using Last.fm.API.Core.Settings;
using Last.fm.API.User;

namespace SimpleScrobbler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LastFmSettings.Configure();

            using (IUserServices client = LastFmServices.UserServicesClient)
            {
                //var topTags = client.GetTopTags("RJ");
                //var artistTracks = client.GetArtistTracks("RJ", "metallica");
                //var test = client.GetBannedTracks("RJ");
                //var events = client.GetEvents("JImmy_SmIle");
                //var userInfo = client.GetInfo("JImmy_SmIle");
                //var friends = client.GetFriends("JImmy_SmIle", true);
                //var recentTracks = client.GetRecentTracks("JImmy_SmIle", 200, extended: true);
                //var lovedTracks = client.GetLovedTracks("RJ");
                //var neighours = client.GetNeighbours("JImmy_SmIle");
                //var pastEvents = client.GetPastEvents("joanofarctan");
                var newReleases = client.GetNewReleases("JImmy_SmIle");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SimpleScrobblerForm());

            LastFmSettings.Instance.AutoSaveSettings = AutoSaveSettingsMode.ToXmlFile;
            LastFmSettings.Save();
        }
    }
}
