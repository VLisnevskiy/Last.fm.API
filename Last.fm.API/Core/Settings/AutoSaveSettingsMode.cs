//-----------------------------------------------------------------------
// <copyright file="AutoSaveSettingsMode.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Last.fm.API.Core.Settings
{
    /// <summary>
    /// Automatically save settings for your application.
    /// </summary>
    public enum AutoSaveSettingsMode
    {
        /// <summary>
        /// Not save.
        /// </summary>
        None = 0x1,

        /// <summary>
        /// Save to xml file.
        /// </summary>
        ToXmlFile = 0x2,

        /// <summary>
        /// Save to App.config file.
        /// </summary>
        ToAppConfig = 0x3
    }
}