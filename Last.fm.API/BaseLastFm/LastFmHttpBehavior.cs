using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Last.fm.API.BaseLastFm
{
    internal class LastFmHttpBehavior : WebHttpBehavior
    {
        protected override QueryStringConverter GetQueryStringConverter(OperationDescription operationDescription)
        {
            return new LastFmQueryStringConverter();
        }
    }
}