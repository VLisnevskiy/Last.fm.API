//-----------------------------------------------------------------------
// <copyright file="SettingsElementAttribute.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Xml.Serialization;

namespace Last.fm.API.Core.Settings
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    internal class SettingsElementAttribute : XmlElementAttribute
    {
        public SettingsElementAttribute()
        {
        }

        public SettingsElementAttribute(string name)
        {
            Name = name;
            ElementName = name;
        }

        public string Name { get; set; }
    }
}