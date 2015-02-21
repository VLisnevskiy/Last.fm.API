using System;
using System.Windows.Forms;
using Last.fm.API.Core.Settings;

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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SimpleScrobblerForm());

            LastFmSettings.Instance.AutoSaveSettings = AutoSaveSettingsMode.ToXmlFile;
            LastFmSettings.Save();
        }
    }
}
