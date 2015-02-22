//-----------------------------------------------------------------------
// <copyright file="Streamable.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Xml.Serialization;

namespace Last.fm.API.Core.Types
{
    [XmlRoot("streamable")]
    public class Streamable
    {
        [XmlAttribute("fulltrack")]
        public bool FullTrack { get; set; }

        [XmlText]
        public bool Allow { get; set; }

        #region Overrided

        public override string ToString()
        {
            return string.Format("{0}", Allow);
        }

        #endregion
    }
}