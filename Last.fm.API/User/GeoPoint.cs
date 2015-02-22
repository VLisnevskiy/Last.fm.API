//-----------------------------------------------------------------------
// <copyright file="GeoPoint.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Xml.Serialization;

namespace Last.fm.API.User
{
    [XmlRoot("point", Namespace = "http://www.w3.org/2003/01/geo/wgs84_pos#")]
    public class GeoPoint
    {
        [XmlElement("lat", Namespace = "http://www.w3.org/2003/01/geo/wgs84_pos#")]
        public string Lat { get; set; }

        [XmlElement("long", Namespace = "http://www.w3.org/2003/01/geo/wgs84_pos#")]
        public string Long { get; set; }

        #region Overrided

        public override string ToString()
        {
            return string.Format("Lat : {0} - Long : {1}",
                Lat ?? string.Empty,
                Long ?? string.Empty);
        }

        #endregion
    }
}