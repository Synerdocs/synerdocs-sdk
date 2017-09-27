using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using Midway.ServiceClient;

namespace Midway.ConsoleClient
{
    /// <summary>
    /// Контекст клиентского подключения к сервису обмена Synerdocs
    /// для хранения текущего ящика, выбранной после авторизации организации.
    /// </summary>
    public class ClientContext
    {
        /// <summary>
        /// текущий выбранный сертификат.
        /// </summary>
        public X509Certificate2 Certificate { get; set; }

        /// <summary>
        /// Клиент веб-сервиса.
        /// </summary>
        public Client ServiceClient { get; set; }

        /// <summary>
        /// Генератор служебных документов.
        /// </summary>
        public MessageFactory MessageFactory { get; set; }

        /// <summary>
        /// Текущий ящик.
        /// </summary>
        public string CurrentBox { get; set; }

        /// <summary>
        /// ID текущей организации.
        /// </summary>
        public int CurrentOrganizationId { get; set; }

        /// <summary>
        /// Последнее обработанное сообщение.
        /// </summary>
        public string LastProcessedMessageId { get; set; }
        /// <summary>
        /// Текущий логин.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Загрузить идентификатор последнего обработанного сообщения с прошлого запуска.
        /// </summary>
        public void LoadLastProcessedMessageId()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var keyValueConfigurationElement = config.AppSettings.Settings[LastProcessedMessageIdKey()];
            if (keyValueConfigurationElement != null)
            {
                LastProcessedMessageId = keyValueConfigurationElement.Value;
            }
        }

        public void SaveLastProcessedMessageId()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var keyValueConfigurationElement = config.AppSettings.Settings[LastProcessedMessageIdKey()];
            if (keyValueConfigurationElement != null)
            {
                keyValueConfigurationElement.Value = LastProcessedMessageId;
            }
            else
            {
                config.AppSettings.Settings.Add(LastProcessedMessageIdKey(), LastProcessedMessageId);
            }
            config.Save(ConfigurationSaveMode.Full);
        }

        private string LastProcessedMessageIdKey()
        {
            return "LastProcessedMessageId:" + CurrentBox;
        }
    }
}