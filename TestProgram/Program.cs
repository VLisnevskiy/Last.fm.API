using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Last.fm.API.BaseLastFm;
using Last.fm.API.AuthServices;

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
                    var r = proxy.GetToken();

                    string token = "";

                    var r1 = proxy.GetSession(token);
                }
                catch (LastFmError e)
                {
                }
            }

            using (var proxy = LastFmServicesHolder.CreateUserServicesClientProxy())
            {
                try
                {
                    var r = proxy.GetInfo("jimmy_smile");
                    var r1 = proxy.GetRecentTracks("jimmy_smile+6",page:2);
                }
                catch (LastFmError e)
                {
                }
            }

            Console.ReadKey();
        }
    }
}
