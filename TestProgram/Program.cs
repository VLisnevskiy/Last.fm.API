using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Last.fm.API.Core;
using Last.fm.API.Core.Settings;
using Last.fm.API.Core.Web;

namespace TestProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            LastFmSettings.LoadSettings();

            using (var proxy = LastFmServicesHolder.CreateAuthServicesClient())
            {
                try
                {
                    var r = proxy.GetToken();

                    Process.Start(r.Url);

                    string token = "6e1264c6c4f9c8336e5ab2f8a606293e";

                    var r1 = proxy.GetSession(token);
                }
                catch (LastFmException e)
                {
                }
            }

            using (var proxy = LastFmServicesHolder.CreateUserServicesClient())
            {
                try
                {
                    var r = proxy.GetInfo("jimmy_smile");
                    var r1 = proxy.GetRecentTracks("jimmy_smile",page:2);
                }
                catch (LastFmException e)
                {
                }
            }

            using (var proxy = LastFmServicesHolder.CreateArtistServicesClientProxy())
            {
                try
                {
                    var t = proxy.GetInfo("Бумбокс", lang: "ru");
                }
                catch (Exception e)
                {

                }
            }

        }
    }
}
