//-----------------------------------------------------------------------
// <copyright file="LastFmHelpers.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Last.fm.API.Core
{
    /// <summary>
    /// Helpers
    /// </summary>
    public static class LastFmHelpers
    {
        /// <summary>
        /// Method for converting a System.DateTime value to a UNIX Timestamp
        /// </summary>
        /// <param name="value">date to convert</param>
        /// <returns>UNIX Timestamp</returns>
        public static double ConvertToTimestamp(this DateTime value)
        {
            //create Timespan by subtracting the value provided from
            //the Unix Epoch
            TimeSpan span = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
            //return the total seconds (which is a UNIX timestamp)
            return span.TotalSeconds;
        }

        /// <summary>
        /// Method for converting a System.DateTime value to a UNIX Timestamp
        /// </summary>
        /// <param name="value">date to convert</param>
        /// <returns>UNIX Timestamp</returns>
        public static double ConvertToTimestamp(this DateTime? value)
        {
            if (value != null)
            {
                DateTime locValue = (DateTime)value;
                //create Timespan by subtracting the value provided from
                //the Unix Epoch
                TimeSpan span = (locValue - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
                //return the total seconds (which is a UNIX timestamp)
                return span.TotalSeconds;
            }

            return 0;
        }
    }
}