using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Last.fm.API.BaseLastFm;
using Last.fm.API.UserServices;

namespace Last.fm.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (IUserServices userServices = LastFmServicesHolder.CreateUserServicesClientProxy())
            {
                try
                {
                    var res = userServices.GetRecentTracks("jimmy_smile");
                    Console.WriteLine(res);
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }

            
            Console.ReadKey();
        }
    }
}
