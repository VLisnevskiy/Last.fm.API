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
                //var test = client.GetTopTags("RJ");
                //var test = client.GetArtistTracks("RJ", "metallica");
                //var test = client.GetBannedTracks("RJ");
                var test = client.GetEvents("JImmy_SmIle");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SimpleScrobblerForm());

            LastFmSettings.Instance.AutoSaveSettings = AutoSaveSettingsMode.ToXmlFile;
            LastFmSettings.Save();
        }
    }
}
