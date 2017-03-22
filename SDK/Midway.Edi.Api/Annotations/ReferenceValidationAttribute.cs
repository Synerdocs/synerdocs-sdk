using System;
using System.ComponentModel.DataAnnotations;

namespace Midway.Edi.Api.Annotations
{
    /// <summary>
    /// Атрибут валидации, позволяющий выполнять валидацию с помощью другого атрибута, который
    /// создается с помощью статического свойства-фабрики (Inversion of Control для валидации)
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ReferenceValidationAttribute : ValidationAttribute
    {
        private readonly Lazy<ValidationAttribute> _innerValidationAttribute;

        /// <summary>
        /// Фабрика внутренних атрибутов, выполняющих валидацию
        /// </summary>
        public static Func<ReferenceValidationAttribute, ValidationAttribute> InnerAttributeFactory { get; set; }

        /// <summary>
        /// Функция для мапиинга значения свойства
        /// </summary>
        public static Func<object, object> PropertyValueMapper { get; set; }

        /// <summary>
        /// Тип внутреннего атрибута, выполняющего валидацию
        /// </summary>
        public ValidationAttributeType InnerAttibuteType { get; private set; }

        /// <summary>
        /// Наименование зависимого свойства
        /// </summary>
        public string DependentProperty { get; private set; }

        /// <summary>
        /// Целевые значения зависимого свойства
        /// </summary>
        public object[] TargetValues { get; private set; }

        /// <summary>
        /// Создать новый экземпляр атрибута валидации
        /// </summary>
        /// <param name="innerAttributeType">Тип внутреннего атрибута, выполняющего валидацию</param>
        /// <param name="dependentProperty">Наименование зависимого свойства</param>
        /// <param name="targetValues">Целевые значения зависимого свойства</param>
        public ReferenceValidationAttribute(
            ValidationAttributeType innerAttributeType,
            string dependentProperty = null,
            params object[] targetValues)
        {
            InnerAttibuteType = innerAttributeType;
            DependentProperty = dependentProperty;
            TargetValues = targetValues;

            _innerValidationAttribute = new Lazy<ValidationAttribute>(
                CreateInnerAttribute,
                isThreadSafe: true);
        }

        public override string FormatErrorMessage(string name)
        {
            return _innerValidationAttribute.Value.FormatErrorMessage(name);
        }

        public override bool IsValid(object value)
        {
            value = MapPropertyValue(value);
            return _innerValidationAttribute.Value.IsValid(value);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            value = MapPropertyValue(value);
            return _innerValidationAttribute.Value.GetValidationResult(value, validationContext);
        }

        public override object TypeId
        {
            get
            {
                // Переопределяем это свойство, иначе инфраструктура валидации может
                // воспринять все объявления данного атрибута как один единственный атрибут
                var typeId = $"{GetType().Name}::{InnerAttibuteType}";
                return typeId;
            }
        }

        public override bool RequiresValidationContext
        {
            get { return _innerValidationAttribute.Value.RequiresValidationContext; }
        }

        /// <summary>
        /// Создать внутренний атрибут, выполняющий валидацию
        /// </summary>
        /// <returns>Атрибут, выполняющий валидацию</returns>
        private ValidationAttribute CreateInnerAttribute()
        {
            var attributeFactory = InnerAttributeFactory;
            if (attributeFactory == null)
                throw new InvalidOperationException("Фабрика атрибутов не инициализирована");

            var validationAttribute = InnerAttributeFactory(this);
            if (validationAttribute == null)
                throw new InvalidOperationException("Фабрика атрибутов вернула NULL");

            return validationAttribute;
        }

        /// <summary>
        /// Преобразовать значение свойства
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <returns>Полученное значение</returns>
        private object MapPropertyValue(object value)
        {
            var propertyValueMapper = PropertyValueMapper;
            if (propertyValueMapper != null && value != null)
                value = propertyValueMapper(value);
            return value;
        }
    }
}
