//-----------------------------------------------------------------------
// <copyright file="Location.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Xml.Serialization;

namespace Last.fm.API.User
{
    [XmlRoot("location")]
    public class Location
    {
        [XmlElement("city")]
        public string City { get; set; }

        [XmlElement("country")]
        public string Country { get; set; }

        [XmlElement("street")]
        public string Streat { get; set; }

        [XmlElement("postalcode")]
        public string PostalCode { get; set; }

        [XmlElement("point", Namespace = "http://www.w3.org/2003/01/geo/wgs84_pos#")]
        public GeoPoint Point { get; set; }

        #region Overrided

        public override string ToString()
        {
            return string.Format("Country: {0} - City: {1} - Streat: {2}",
                Country ?? string.Empty,
                City ?? string.Empty,
                Streat ?? string.Empty);
        }

        #endregion
    }
}