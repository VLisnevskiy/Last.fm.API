using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Last.fm.API;
using Last.fm.API.Core;
using Last.fm.API.Core.Settings;
using Last.fm.API.Core.Web;

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


            LastFmSettings.Instance.AutoSaveSettings = AutoSaveSettingsMode.ToAppConfig;
            LastFmSettings.Save();
        }
    }
}
