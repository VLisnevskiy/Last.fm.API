//-----------------------------------------------------------------------
// <copyright file="LastFmSettings.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using Last.fm.API.Auth;
using TimeSpan = Last.fm.API.Core.Types.TimeSpan;

namespace Last.fm.API.Core.Settings
{
    /// <summary>
    /// LastFm API configuration settings
    /// </summary>
    [XmlRoot("Settings")]
    public sealed class LastFmSettings
    {
        #region Singleton implementation

        private static readonly object LockObject = new object();

        private static LastFmSettings instance;

        /// <summary>
        /// Instance of LastFm API Settings
        /// </summary>
        public static LastFmSettings Instance
        {
            get
            {
                if (null == instance)
                {
                    lock (LockObject)
                    {
                        if (null == instance)
                        {
                            instance = new LastFmSettings();
                        }
                    }
                }

                return instance;
            }
        }

        private LastFmSettings()
        {
            AutoSaveWhenTokeChanged = false;
            MaxReceivedMessageSize = 125000000;

            CloseTimeout = new TimeSpan(0, 1, 0);
            OpenTimeout = new TimeSpan(0, 1, 0);
            ReceiveTimeout = new TimeSpan(0, 10, 0);
            SendTimeout = new TimeSpan(0, 1, 0);
            AutoSaveSettings = AutoSaveSettingsMode.None;
            GetSettingsElements();
        }

        private static void GetSettingsElements()
        {
            if (null == publicProperties)
            {
                publicProperties = new Dictionary<string, PropertyInfo>();
                (typeof(LastFmSettings))
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Where((property) => property.CanWrite && null != property.GetAttribute<SettingsElementAttribute>(false))
                    .ToList()
                    .ForEach((property) =>
                    {
                        string elementName = property.Name;
                        SettingsElementAttribute settingsElement = property.GetAttribute<SettingsElementAttribute>(false);
                        if (null != settingsElement)
                        {
                            if (!string.IsNullOrEmpty(settingsElement.Name))
                            {
                                elementName = settingsElement.Name;
                            }
                        }

                        publicProperties.Add(elementName, property);
                    });
            }
        }

        #endregion

        #region Configuration - static methods

        /// <summary>
        /// Method to configure Settings for Last.fm.API library
        /// </summary>
        /// <param name="fileName">File name that contains configuration</param>
        public static void Configure(string fileName = null)
        {
            isConfigured = false;
            instance = null;

            if (string.IsNullOrWhiteSpace(fileName) || !File.Exists(fileName))
            {
                isConfigured = ConfigureFromAppConfig();
            }
            else
            {
                isConfigured = ConfigureFromFile(fileName);
            }

            if (!isConfigured)
            {
                _configType = ConfigurationType.None;
            }
        }

        /// <summary>
        /// Save Last.fm.API library settings
        /// </summary>
        /// <returns>Indicate if settings was saved successful</returns>
        public static bool Save()
        {
            if (!contextChanged)
            {
                return false;
            }

            switch (_configType)
            {
                case ConfigurationType.AppConfig:
                    return Instance.SaveConfig();
                case ConfigurationType.FromFile:
                    return Instance.SaveFile(File.Exists(configFileName) ? configFileName : ConfigFileName);
                default:
                    switch (Instance.AutoSaveSettings)
                    {
                        case AutoSaveSettingsMode.ToAppConfig:
                            {
                                string exeFile = Environment.GetCommandLineArgs()[0];
                                Configuration config = ConfigurationManager.OpenExeConfiguration(exeFile);
                                ConfigurationSection appSettings = config.Sections.Get(ConfigSectionName);
                                ClientSettingsSection newAppSettings = new ClientSettingsSection();
                                if (null == appSettings)
                                {
                                    config.Sections.Add(ConfigSectionName, newAppSettings);
                                }
                                else
                                {
                                    newAppSettings = (ClientSettingsSection)appSettings;
                                }

                                foreach (KeyValuePair<string, PropertyInfo> property in publicProperties)
                                {
                                    SettingElement element = null;
                                    Instance.ChangeValue(property.Value, property.Key, ref element);
                                    newAppSettings.Settings.Add(element);
                                }

                                try
                                {
                                    config.Save(ConfigurationSaveMode.Full);
                                }
                                catch (Exception)
                                {
                                    return false;
                                }

                                _configType = ConfigurationType.AppConfig;
                                return true;
                            }
                        case AutoSaveSettingsMode.ToXmlFile:
                            bool bRes = Instance.SaveFile(ConfigFileName);
                            if (bRes)
                            {
                                _configType = ConfigurationType.FromFile;
                            }

                            return bRes;
                        default:
                            return false;
                    }
            }
        }

        #endregion

        #region Configuration

        private bool LoadSettings(ConfigurationType configType, object item)
        {
            _configType = configType;

            switch (configType)
            {
                case ConfigurationType.AppConfig:
                    return LoadConfig(item);
                case ConfigurationType.FromFile:
                    string fileName = null != item ? item.ToString() : string.Empty;
                    return LoadFile(File.Exists(fileName) ? fileName : ConfigFileName);
                default:
                    return false;
            }
        }

        public static bool Compare(object obj1, object obj2)
        {
            if ((null == obj1 && null == obj2) ||
                (null != obj1 && null == obj2) ||
                (null == obj1))
            {
                return false;
            }

            return obj1.Equals(obj2);
        }

        #region Settings from file

        private static bool ConfigureFromFile(string fileName)
        {
            if (!string.IsNullOrWhiteSpace(fileName) ||
                !File.Exists(fileName))
            {
                fileName = ConfigFileName;
            }

            return Instance.LoadSettings(ConfigurationType.FromFile, fileName);
        }

        private bool LoadFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                FileStream file = null;
                try
                {
                    configFileName = fileName;

                    using (file = new FileStream(fileName, FileMode.Open))
                    using (StreamReader reader = new StreamReader(file, Encoding.UTF8))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(LastFmSettings));
                        instance = (LastFmSettings)serializer.Deserialize(reader);
                    }

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    if (null != file)
                    {
                        file.Close();
                    }
                }
            }

            return false;
        }

        private bool SaveFile(string fileName)
        {
            FileStream file = null;
            try
            {
                using (file = new FileStream(fileName, FileMode.Create))
                using (StreamWriter writer = new StreamWriter(file, Encoding.UTF8))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(LastFmSettings), string.Empty);
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add(string.Empty, string.Empty);
                    serializer.Serialize(writer, instance, ns);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (null != file)
                {
                    file.Close();
                }
            }
        }

        #endregion

        #region from App.config

        private static bool ConfigureFromAppConfig()
        {
            string assemblyFile = Assembly.GetExecutingAssembly().Location;
            string directory = Path.GetDirectoryName(assemblyFile);
            string fileName = !string.IsNullOrWhiteSpace(directory)
                ? Path.Combine(directory, ConfigFileName)
                : ConfigFileName;

            var appSettings = ConfigurationManager.GetSection(ConfigSectionName);
            if (null != appSettings)
            {
                return Instance.LoadSettings(ConfigurationType.AppConfig, appSettings);
            }
            else
            {
                return Instance.LoadSettings(ConfigurationType.FromFile, fileName);
            }
        }

        private bool LoadConfig(object item)
        {
            if (item is ClientSettingsSection)
            {
                ClientSettingsSection settings = (ClientSettingsSection) item;
                foreach (SettingElement element in settings.Settings)
                {
                    if (ConfigFileElement == element.Name)
                    {
                        string fileName = element.GetValue();
                        return Instance.LoadSettings(ConfigurationType.FromFile, fileName);
                    }

                    ChceckAndSet(element);
                }

                return true;
            }

            return false;
        }

        private void ChceckAndSet(SettingElement element)
        {
            if (publicProperties.ContainsKey(element.Name))
            {
                isPreventSave = true;
                object value = element.GetValue();
                if (typeof(TimeSpan) == publicProperties[element.Name].PropertyType)
                {
                    value = new TimeSpan { Value = System.TimeSpan.Parse(value.ToString()) };
                }
                else if (typeof(bool) == publicProperties[element.Name].PropertyType)
                {
                    value = bool.Parse(value.ToString());
                }
                else if (typeof(AuthToken) == publicProperties[element.Name].PropertyType)
                {
                    value = new AuthToken { Token = value.ToString() };
                }

                publicProperties[element.Name].SetValue(this, value, null);
                isPreventSave = false;
            }
        }

        private bool SaveConfig()
        {
            string exeFile = Environment.GetCommandLineArgs()[0];
            Configuration config = ConfigurationManager.OpenExeConfiguration(exeFile);
            ClientSettingsSection appSettings = config.GetSection(ConfigSectionName) as ClientSettingsSection;
            if (null != appSettings)
            {
                foreach (KeyValuePair<string, PropertyInfo> property in publicProperties)
                {
                    SettingElement element = appSettings.Settings.Get(property.Key);
                    if (null == element)
                    {
                        ChangeValue(property.Value, property.Key, ref element);
                        appSettings.Settings.Add(element);
                    }
                    else
                    {
                        ChangeValue(property.Value, property.Key, ref element);
                    }
                }

                try
                {
                    config.Save(ConfigurationSaveMode.Modified);
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        private void ChangeValue(PropertyInfo property, string elementName, ref SettingElement inputElement)
        {
            if (null == inputElement)
            {
                inputElement = new SettingElement(elementName, SettingsSerializeAs.String);
            }

            object value = property.GetValue(this, null) ?? string.Empty;
            inputElement.SetValue(value);
        }

        #endregion

        #endregion

        #region Private members

        private static bool isConfigured = false;

        private static bool isPreventSave = false;

        private static bool contextChanged = false;

        private static ConfigurationType _configType = ConfigurationType.None;

        private static string configFileName;

        private const string ConfigFileName = "last.mf.xml";

        private const string ConfigSectionName = "Last.fm.API.Core.Settings.LastFmSettings";

        private const string ConfigFileElement = "ConfigFile";

        private static Dictionary<string, PropertyInfo> publicProperties;

        #endregion

        /// <summary>
        /// Url on LastFm API
        /// </summary>
        public const string LastFmApiUrl = "http://ws.audioscrobbler.com/2.0/";

        internal static string FakeToken
        {
            get { return Guid.NewGuid().ToString("N"); }
        }

        #region Public members

        #region ApiKey

        private string apiKey;

        /// <summary>
        /// WebServices ApiKey
        /// </summary>
        [SettingsElement]
        public string ApiKey
        {
            get
            {
                if (!isConfigured)
                {
                    throw new ArgumentNullException("ApiKey", "Looks like you forgot to configure Last.fm.API library");
                }

                return apiKey;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) &&
                    !value.Equals(apiKey))
                {
                    apiKey = value.ToLowerInvariant();
                    isConfigured = true;
                    if (!isPreventSave)
                    {
                        contextChanged = true;
                    }
                }
            }
        }

        #endregion

        #region ApiSig

        private string apiSig;

        /// <summary>
        /// WebServices ApiSig
        /// </summary>
        [SettingsElement]
        public string ApiSig
        {
            get
            {
                if (!isConfigured)
                {
                    throw new ArgumentNullException("ApiSig", "Looks like you forgot to configure Last.fm.API library");
                }

                return apiSig;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) &&
                    !value.Equals(apiSig))
                {
                    apiSig = value.ToLowerInvariant();
                    isConfigured = true;
                    if (!isPreventSave)
                    {
                        contextChanged = true;
                    }
                }
            }
        }

        #endregion

        #region CloseTimeout

        private TimeSpan closeTimeout;

        /// <summary>
        /// Timeout in minutes before Close
        /// </summary>
        [SettingsElement]
        public TimeSpan CloseTimeout
        {
            get
            {
                return closeTimeout;
            }
            set
            {
                if (!value.Equals(closeTimeout))
                {
                    closeTimeout = value;
                    if (!isPreventSave)
                    {
                        contextChanged = true;
                    }
                }
            }
        }

        #endregion

        #region OpenTimeout

        private TimeSpan openTimeout;

        /// <summary>
        /// Timeout in minutes before Open
        /// </summary>
        [SettingsElement]
        public TimeSpan OpenTimeout
        {
            get
            {
                return openTimeout;
            }
            set
            {
                if (!value.Equals(openTimeout))
                {
                    openTimeout = value;
                    if (!isPreventSave)
                    {
                        contextChanged = true;
                    }
                }
            }
        }

        #endregion

        #region ReceiveTimeout

        private TimeSpan receiveTimeout;

        /// <summary>
        /// Timeout in minutes before Receive
        /// </summary>
        [SettingsElement]
        public TimeSpan ReceiveTimeout
        {
            get
            {
                return receiveTimeout;
            }
            set
            {
                if (!value.Equals(receiveTimeout))
                {
                    receiveTimeout = value;
                    if (!isPreventSave)
                    {
                        contextChanged = true;
                    }
                }
            }
        }

        #endregion

        #region SendTimeout

        private TimeSpan sendTimeout;

        /// <summary>
        /// Timeout in minutes before Send
        /// </summary>
        [SettingsElement]
        public TimeSpan SendTimeout
        {
            get
            {
                return sendTimeout;
            }
            set
            {
                if (!value.Equals(sendTimeout))
                {
                    sendTimeout = value;
                    if (!isPreventSave)
                    {
                        contextChanged = true;
                    }
                }
            }
        }

        #endregion

        #region Token

        private AuthToken token;

        /// <summary>
        /// Autorized token.
        /// Needed to get Last.fm user session.
        /// Will be rewriten when will generated new token by method GetToken().
        /// </summary>
        [SettingsElement("Token")]
        public AuthToken Token
        {
            get
            {
                return token;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) &&
                    !value.Equals(token))
                {
                    token = value;
                    if (!isPreventSave)
                    {
                        contextChanged = true;
                        if (AutoSaveWhenTokeChanged)
                        {
                            Save();
                        }
                    }
                }
            }
        }

        #endregion

        #region AutoSaveWhenTokeChanged

        private bool autoSaveWhenTokeChanged;

        /// <summary>
        /// Automatically save settings when Token change
        /// </summary>
        [SettingsElement]
        public bool AutoSaveWhenTokeChanged
        {
            get
            {
                return autoSaveWhenTokeChanged;
            }
            set
            {
                autoSaveWhenTokeChanged = value;
                if (!isPreventSave)
                {
                    contextChanged = true;
                }
            }
        }

        #endregion

        #region MaxReceivedMessageSize

        private int maxReceivedMessageSize;

        /// <summary>
        /// MaxReceivedMessageSize.
        /// </summary>
        [SettingsElement]
        public int MaxReceivedMessageSize
        {
            get
            {
                return maxReceivedMessageSize;
            }
            set
            {
                maxReceivedMessageSize = value;
                if (!isPreventSave)
                {
                    contextChanged = true;
                }
            }
        }

        #endregion

        /// <summary>
        /// User session
        /// </summary>
        [XmlIgnore]
        public AuthSession UserSession { get; internal set; }

        /// <summary>
        /// Automatically save settings for your application.
        /// By default is AutoSaveSettings.None.
        /// </summary>
        [XmlIgnore]
        public AutoSaveSettingsMode AutoSaveSettings { get; set; }

        #endregion

        #region Overriden methods

        public override string ToString()
        {
            string text = string.Format("Url = [{0}] - ApiKey = [{1}] - ApiSig = [{2}]",
                LastFmApiUrl,
                ApiKey,
                ApiSig);

            return text;
        }

        #endregion
    }
}