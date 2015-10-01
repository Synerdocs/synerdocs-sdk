using System.Linq;

namespace Midway.ObjectModel.Extensions
{
    public static class OrganizationExtensions
    {
        /// <summary>
        /// Получить адрес заданного типа
        /// </summary>
        /// <param name="org"></param>
        /// <param name="addressType"></param>
        /// <returns></returns>
        public static OrganizationAddress GetAddress(this Organization org, AddressType addressType)
        {
            return org.Addresses.FirstOrDefault(a => a.AddressType == addressType);
        }
    }
}
