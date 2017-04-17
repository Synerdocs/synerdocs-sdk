using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Результат валидации модели
    /// </summary>
    [DataContract]
    public class ModelValidationResult
    {
        /// <summary>
        /// Итоговый статус валидации
        /// </summary>
        [DataMember]
        public EnumValue Status { get; set; }

        /// <summary>
        /// Сообщения валидации модели
        /// </summary>
        [DataMember]
        public List<ModelValidationMessage> Messages { get; set; }

        /// <summary>
        /// Наименование элемента
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Результаты валидации полей
        /// </summary>
        [DataMember]
        public List<ModelValidationResult> Fields { get; set; }
        
        /// <summary>
        /// Получить все результаты валидации в виде линейного списка
        /// </summary>
        /// <returns>Словарь результатов валидации</returns>
        public Dictionary<string, ModelValidationResult> GetFlatResults()
        {
            var flatResults = new Dictionary<string, ModelValidationResult>();
            AppendModelResults(flatResults, this, string.Empty);
            return flatResults;
        }

        /// <summary>
        /// Добавить результаты валидации модели в плоскому списку результатов
        /// </summary>
        /// <param name="flatResults">Плоский списку результатов валидации</param>
        /// <param name="outerResult">Внешний результат валидации</param>
        /// <param name="outerPath">Внешний путь к свойству</param>
        private void AppendModelResults(Dictionary<string, ModelValidationResult> flatResults, ModelValidationResult outerResult, string outerPath)
        {
            if (outerResult.Messages != null && outerResult.Messages.Any())
                flatResults.Add(outerPath, new ModelValidationResult { Messages = outerResult.Messages });

            foreach (var innerResult in outerResult.Fields)
            {
                int key;
                var innerPath = (int.TryParse(innerResult.Name, out key))
                    ? $"{outerPath}[{innerResult.Name}]"
                    : !string.IsNullOrEmpty(outerPath.Trim())
                        ? $"{outerPath}.{innerResult.Name}"
                        : $"{innerResult.Name}";

                AppendModelResults(flatResults, innerResult, innerPath);
            }
        }
    }
}
