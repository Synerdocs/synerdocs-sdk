namespace Midway.Edi.Api.Annotations
{
    /// <summary>
    /// Атрибут валидации по словарю, позволяющий выполнять валидацию с помощью другого атрибута
    /// </summary>
    public class DictionaryValidationAttribute : ReferenceValidationAttribute
    {
        /// <summary>
        /// Наименование справочника для валидации
        /// </summary>
        public ValidationDictionaryKind DictionaryKind { get; private set; }

        /// <summary>
        /// Создать новый экземпляр атрибута валидации
        /// </summary>
        /// <param name="innerAttributeType">Тип внутреннего атрибута, выполняющего валидацию</param>
        /// <param name="dictionaryKind">Наименование справочника для валидации</param>
        /// <param name="dependentProperty">Наименование зависимого свойства</param>
        /// <param name="targetValues">Целевые значения зависимого свойства</param>
        public DictionaryValidationAttribute(
            ValidationAttributeType innerAttributeType,
            ValidationDictionaryKind dictionaryKind,
            string dependentProperty = null,
            params object[] targetValues)
            : base(innerAttributeType, dependentProperty, targetValues)
        {
            DictionaryKind = dictionaryKind;
        }
    }
}
