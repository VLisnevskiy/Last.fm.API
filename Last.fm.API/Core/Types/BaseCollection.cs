//-----------------------------------------------------------------------
// <copyright file="BaseCollection.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Last.fm.API.Core.Types
{
    /// <summary>
    /// Base collection.
    /// </summary>
    /// <typeparam name="TCollection">Type of collection.</typeparam>
    public abstract class BaseCollection<TCollection> : BaseResponse,
        IList<TCollection>, 
        ICollection<TCollection>,
        IEnumerable,
        IXmlSerializable
        where TCollection : class, new()
    {
        public abstract List<TCollection> Collection { get; set; }

        #region IList<TCollection>, ICollection<TCollection>, IEnumerable

        public void CopyTo(Array array, int index)
        {
            List<TCollection> items = new List<TCollection>();
            while (array.GetEnumerator().MoveNext())
            {
                TCollection item = array.GetEnumerator().Current as TCollection;
                if (null != item)
                {
                    items.Add(item);
                }
            }

            Collection.CopyTo(items.ToArray(), index);
        }

        public int Count
        {
            get { return Collection.Count; }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        public object SyncRoot
        {
            get { return false; }
        }

        public IEnumerator GetEnumerator()
        {
            return Collection.GetEnumerator();
        }

        public TCollection this[int index]
        {
            get { return Collection[index]; }
            set { Collection[index] = value; }
        }

        public void Add(TCollection item)
        {
            Collection.Add(item);
        }

        public void Clear()
        {
            Collection.Clear();
        }

        public bool Contains(TCollection item)
        {
            return Collection.Contains(item);
        }

        public void CopyTo(TCollection[] array, int arrayIndex)
        {
            Collection.CopyTo(array, arrayIndex);
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(TCollection item)
        {
            return Collection.Remove(item);
        }

        IEnumerator<TCollection> IEnumerable<TCollection>.GetEnumerator()
        {
            return Collection.GetEnumerator();
        }

        public int IndexOf(TCollection item)
        {
            return Collection.IndexOf(item);
        }

        public void Insert(int index, TCollection item)
        {
            Collection.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            Collection.RemoveAt(index);
        }

        public TCollection[] ToArray()
        {
            return Collection.ToArray();
        }

        #endregion
    }
}