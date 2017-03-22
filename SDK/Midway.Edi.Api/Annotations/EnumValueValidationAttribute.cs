using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Midway.Edi.Api.Common;

namespace Midway.Edi.Api.Annotations
{
    /// <summary>
    /// Атрибут валидации значения переичсления
    /// </summary>
    public class EnumValueValidationAttribute : ValidationAttribute
    {
        private readonly Type _enumType;

        /// <summary>
        /// Создать новый экземпляр атрибута валидации
        /// </summary>
        /// <param name="enumType">Тип перечисления</param>
        public EnumValueValidationAttribute(Type enumType)
        {
            if (enumType == null)
                throw new ArgumentNullException(nameof(enumType));
            _enumType = enumType;
        }

        public override bool IsValid(object value)
        {
            var enumData = value as IEnumValue;
            if (enumData == null)
                return true;

            var enumValue = enumData.Value ?? Enum.ToObject(_enumType, enumData.Code);
            if (!Enum.IsDefined(_enumType, enumValue))
                return false;

            var result = IsDefined(_enumType.GetField(enumValue.ToString()), typeof(EnumMemberAttribute));
            return result;
        }
    }
}
