//-----------------------------------------------------------------------
// <copyright file="LikeObject.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Last.fm.API.Core
{
    public abstract class LikeObject
    {
        #region IXmlSerializable

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            XmlRootAttribute xmlRoot = GetType().GetAttribute<XmlRootAttribute>(false);
            if (null == xmlRoot)
            {
                string message = string
                    .Format("Type {0} doesn't has XmlRoot attribute. Serialization can't be continued.",
                        GetType().Name);
                throw new SerializationException(message);
            }

            using (XmlReader rd = reader.ReadSubtree())
            {
                rd.ReadToFollowing(xmlRoot.ElementName, xmlRoot.Namespace ?? string.Empty);
                ReadXml(XDocument.Load(rd));
            }

            //Allow to continue serialization.
            reader.Read();
        }

        public abstract void ReadXml(XDocument doc);

        public virtual void WriteXml(XmlWriter writer)
        {
            XDocument doc = new XDocument();
            doc.Save(writer);
        }

        #endregion
    }
}