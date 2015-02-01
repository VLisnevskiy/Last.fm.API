//-----------------------------------------------------------------------
// <copyright file="ConfigurationType.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Last.fm.API.Core.Settings
{
    /// <summary>
    /// Type where read and save configuration settings.
    /// </summary>
    internal enum ConfigurationType
    {
        /// <summary>
        /// Without configuration.
        /// </summary>
        None = 0x1,

        /// <summary>
        /// Read and save to file.
        /// </summary>
        FromFile = 0x2,

        /// <summary>
        /// Read and save to App.Config file.
        /// </summary>
        AppConfig = 0x3
    }
}