#Last.fm API

Last.fm API - it's a library that provide capability to use Last.fm web services in C# like a ordinary functions.

##Example how use
    //Add usings
    using Last.fm.API;
    using Last.fm.API.Auth;
    using Last.fm.API.Core.Web;
    
    using (IAuthServices client = LastFmServices.AuthServicesClient)
    {
        try
        {
            AuthToken token = client.GetToken();
            //Go to web browser and authorize token.
            Process.Start(token.Url);
            //Then continue to get session.
            AuthSession ssesion = client.GetSession(token);
        }
        catch (NotAuthorizedTokenException authEx)
        {
            //You can try to get session again.
        }
        catch (LastFmException commonEx)
        {
        }
    }
