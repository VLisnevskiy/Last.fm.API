using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Last.fm.API.BaseLastFm;
using Last.fm.API.AuthServices;
using Last.fm.API.BaseLastFm.Web;

namespace TestProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var proxy = LastFmServicesHolder.CreateAuthServicesClientProxy())
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

            using (var proxy = LastFmServicesHolder.CreateUserServicesClientProxy())
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
                    var t = proxy.GetInfo("Cher", lang: "ru");
                }
                catch (Exception e)
                {

                }
            }

        }
    }
}
