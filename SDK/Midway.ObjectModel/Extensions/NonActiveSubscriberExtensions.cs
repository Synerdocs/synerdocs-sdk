namespace Midway.ObjectModel.Extensions
{
    public static class NonActiveSubscriberExtensions
    {
        /// <summary>
        /// Получить ФИО из данных по неактивному абоненту
        /// </summary>
        public static string GetFio(this NonActiveSubscriber subscriber)
        {
            return
                string.Join(" ", new[] { subscriber.LastName, subscriber.FirstName, subscriber.MiddleName})
                    .Trim(' ', ',');
        }

        /// <summary>
        /// Пересчитать наименование неактивного абонента
        /// </summary>
        public static void RecomputeName(this NonActiveSubscriber subscriber)
        {
            subscriber.Name = subscriber.OrganizationType.Code != (int)OrganizationType.Individual
                ? subscriber.OrganizationType.Code == (int)OrganizationType.LegalEntity
                    ? subscriber.Name
                    : $"ИП {subscriber.LastName} {subscriber.FirstName[0]}.{(!string.IsNullOrEmpty(subscriber.MiddleName) && subscriber.MiddleName != " " ? subscriber.MiddleName[0] + "." : string.Empty)}"
                : subscriber.GetFio();
        }
    }
}
