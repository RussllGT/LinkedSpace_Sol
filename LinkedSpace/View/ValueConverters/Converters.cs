namespace LinkedSpace.View.ValueConverters
{
    public static class Converters
    {
        public const string ONE_WAY_CONVERTER_EXCEPTION = "Конвертер поддерживает только отдностороннюю привязку";
        public const string INCORRECT_PARAMETER_EXCEPTION = "Некорректное значение параметра";

        /// <summary>
        /// Метод определяет, содержится ли в строковом выражении передаваемое строковое представление перечисления.
        /// </summary>
        /// <param name="expression">Выражение.</param>
        /// <param name="enumValue">Строковое представление перечисления.</param>
        /// <returns>Результат парсинга выражения.</returns>
        public static bool ParseEnumExpressionToBool(this string expression, string enumValue)
        {
            bool result = true;
            if (expression.StartsWith("-"))
            {
                result = false;
                expression = expression.Substring(1);
            }

            foreach (string prmtr in expression.Split(':'))
            {
                if (enumValue.Equals(prmtr)) return result;
            }

            return !result;
        }
    }
}