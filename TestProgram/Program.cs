using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Last.fm.API.BaseLastFm;
using Last.fm.API.BaseLastFm.Web;
using Last.fm.API.Core;
using Last.fm.API.Core.Settings;

namespace TestProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            LastFmSettings.LoadSettings();

            /*using (var proxy = LastFmServicesHolder.CreateAuthServicesClient())
            {
                try
                {
                    var t = proxy.GetMobileSession("pass", "jimmy_Smile");

                    var r = proxy.GetToken();

                    string token = r.Token;

                    var r1 = proxy.GetSession(r.Token);
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
            }*/

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
