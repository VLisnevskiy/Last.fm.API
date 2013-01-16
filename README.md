#Last.fm API

Last.fm API - it's a library that provide capability to use Last.fm web services in C# like a ordinary functions.

##Example how use
    using (var proxy = LastFmServicesHolder.CreateAuthServicesClientProxy())
    {
        try
        {
            var response = proxy.GetToken();
        }
        catch (LastFmError e)
        {
        }
    }
