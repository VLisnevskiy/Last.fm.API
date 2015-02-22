//-----------------------------------------------------------------------
// <copyright file="Ticket.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Xml.Serialization;

namespace Last.fm.API.User
{
    [XmlRoot("ticket")]
    public class Ticket
    {
        [XmlAttribute("supplier")]
        public string Supplier { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}