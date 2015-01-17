//-----------------------------------------------------------------------
// <copyright file="LfmStatus.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Last.fm.API.Core
{
    /// <summary>
    /// Success of Last.fm response
    /// </summary>
    public enum LfmStatus
    {
        /// <summary>
        /// Response is Ok
        /// </summary>
        ok = 0,

        /// <summary>
        /// Response has Failed status
        /// </summary>
        failed = 1,
    }
}