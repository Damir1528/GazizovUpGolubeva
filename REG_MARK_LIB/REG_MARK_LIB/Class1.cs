namespace REG_MARK_LIB
{
    public class Class1
    {
        /// <summary>
        /// Проверяет, является ли номерной знак корректным.
        /// </summary>
        /// <param name="Mark">Номерной знак для проверки.</param>
        /// <returns>True, если номерной знак корректен, иначе false.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если номерной знак имеет неверный формат или длину.</exception>
        public bool Boolean(string Mark)
        {
            // Проверка длины номерного знака
            if (Mark.Length != 9)
            {
                throw new ArgumentException("Номерной знак должен состоять из 9 символов.");
            }
            // Проверка формата номерного знака
            if (!char.IsLetter(Mark[0]) || !char.IsDigit(Mark[1]) || !char.IsDigit(Mark[2]) || !char.IsDigit(Mark[3]) ||
                !char.IsLetter(Mark[4]) || !char.IsLetter(Mark[5]) || !char.IsDigit(Mark[6]) || !char.IsDigit(Mark[7]) || !char.IsDigit(Mark[8]))
            {
                throw new ArgumentException("Неверный формат номерного знака.");
            }
            // Проверка, является ли первая буква одной из допустимых
            if (!new[] { 'A', 'B', 'E', 'K', 'M', 'H', 'O', 'P', 'C', 'T', 'Y', 'X' }.Contains(Mark[0]))
            {
                return false; // Если первая буква недопустима, возвращаем false
            }
            // Проверка, что символы с 1 по 3 - это цифры
            for (int j = 1; j <= 3; j++)
            {
                if (!char.IsDigit(Mark[j]))
                {
                    return false; // Если хотя бы один символ не цифра, возвращаем false
                }
            }
            // Проверка, что символы с 4 по 5 - это буквы
            for (int j = 4; j <= 5; j++)
            {
                if (!new[] { 'A', 'B', 'E', 'K', 'M', 'H', 'O', 'P', 'C', 'T', 'Y', 'X' }.Contains(Mark[j]))
                {
                    return false; // Если хотя бы один символ недопустим, возвращаем false
                }
            }
            // Проверка, что символы с 6 по 8 - это цифры
            for (int j = 6; j <= 8; j++)
            {
                if (!char.IsDigit(Mark[j]))
                {
                    return false; // Если хотя бы один символ не цифра, возвращаем false
                }
            }
            // Если все проверки пройдены, возвращаем true
            return true;
        }
        /// <summary>
        /// Получает следующий номерной знак после указанного.
        /// </summary>
        /// <param name="Mark">Текущий номерной знак.</param>
        /// <returns>Следующий номерной знак.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если номерной знак имеет неверный формат или длину.</exception>
        /// <exception cref="InvalidOperationException">Выбрасывается, если достигнут предел номерных знаков.</exception>
        public string GetNextMarkAfter(string Mark)
        {
            // Проверка длины номерного знака
            if (Mark.Length != 9)
            {
                throw new ArgumentException("Номерной знак должен состоять из 9 символов.");
            }
            // Проверка формата номерного знака
            if (!char.IsLetter(Mark[0]) || !char.IsDigit(Mark[1]) || !char.IsDigit(Mark[2]) || !char.IsDigit(Mark[3]) ||
                !char.IsLetter(Mark[4]) || !char.IsLetter(Mark[5]) || !char.IsDigit(Mark[6]) || !char.IsDigit(Mark[7]) || !char.IsDigit(Mark[8]))
            {
                throw new ArgumentException("Неверный формат номерного знака.");
            }
            // Извлечение частей номерного знака
            char firstLetter = Mark[0]; // Первая буква
            int numberPart = int.Parse(Mark.Substring(1, 3)); // Числовая часть
            char secondLetter1 = Mark[4]; // Первая буква после чисел
            char secondLetter2 = Mark[5]; // Вторая буква
            int regionPart = int.Parse(Mark.Substring(6, 3)); // Региональная часть
            // Увеличение региональной части
            regionPart++;
            if (regionPart > 999)
            {
                regionPart = 0; // Сбрасываем региональную часть
                secondLetter2++; // Увеличиваем вторую букву
                if (secondLetter2 > 'Z')
                {
                    secondLetter2 = 'A'; // Сбрасываем вторую букву
                    secondLetter1++; // Увеличиваем первую букву
                    if (secondLetter1 > 'Z')
                    {
                        secondLetter1 = 'A'; // Сбрасываем первую букву
                        firstLetter++; // Увеличиваем первую букву номерного знака
                        if (firstLetter > 'Z')
                        {
                            throw new InvalidOperationException("Достигнут предел номерных знаков."); // Предел номерных знаков достигнут
                        }
                    }
                }
            }
            // Формирование следующего номерного знака
            string nextMark = $"{firstLetter}{numberPart:D3}{secondLetter1}{secondLetter2}{regionPart:D3}";
            return nextMark; // Возвращаем следующий номерной знак
        }

        /// <summary>
        /// Получает следующий номерной знак после указанного в заданном диапазоне.
        /// </summary>
        /// <param name="prevMark">Предыдущий номерной знак.</param>
        /// <param name="rangeStart">Начало диапазона.</param>
        /// <param name="rangeEnd">Конец диапазона.</param>
        /// <returns>Следующий номерной знак или "out of stock", если предел достигнут.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если номерные знаки имеют неверный формат или находятся вне диапазона.</exception>
        public string GetNextMarkAfterRange(string prevMark, string rangeStart, string rangeEnd)
        {
            // Проверка формата номерных знаков
            bool IsValidMarkFormat(string mark) =>
                mark.Length == 9 &&
                char.IsLetter(mark[0]) &&
                char.IsDigit(mark[1]) && char.IsDigit(mark[2]) && char.IsDigit(mark[3]) &&
                char.IsLetter(mark[4]) && char.IsLetter(mark[5]) &&
                char.IsDigit(mark[6]) && char.IsDigit(mark[7]) && char.IsDigit(mark[8]);
            // Проверка корректности формата для всех номерных знаков
            if (!IsValidMarkFormat(prevMark) || !IsValidMarkFormat(rangeStart) || !IsValidMarkFormat(rangeEnd))
            {
                throw new ArgumentException("Неверный формат номерного знака.");
            }
            // Функция для сравнения номерных знаков
            int CompareMarks(string mark1, string mark2)
            {
                return string.Compare(mark1, mark2, StringComparison.Ordinal);
            }
            // Проверка, находится ли предыдущий номерной знак в указанном диапазоне
            if (CompareMarks(prevMark, rangeStart) < 0 || CompareMarks(prevMark, rangeEnd) > 0)
            {
                throw new ArgumentException("Предыдущий номерной знак вне указанного диапазона.");
            }
            // Функция для генерации следующего номерного знака
            string GenerateNextMark(string currentMark)
            {
                char[] chars = currentMark.ToCharArray(); // Преобразуем строку в массив символов
                int i = chars.Length - 1; // Начинаем с последнего символа
                // Цикл для увеличения номерного знака
                while (i >= 0)
                {
                    // Увеличиваем цифры (позиции 6-8)
                    if (i >= 6 && i <= 8 && char.IsDigit(chars[i]))
                    {
                        chars[i]++;
                        if (chars[i] > '9')
                        {
                            chars[i] = '0'; // Сбрасываем на 0 и переходим к следующему символу
                            i--;
                        }
                        else
                        {
                            return new string(chars); // Возвращаем следующий номерной знак
                        }
                    }
                    // Увеличиваем буквы (позиции 4-5)
                    else if (i >= 4 && i <= 5 && char.IsLetter(chars[i]))
                    {
                        chars[i]++;
                        if (chars[i] > 'Z')
                        {
                            chars[i] = 'A'; // Сбрасываем на 'A' и переходим к следующему символу
                            i--;
                        }
                        else
                        {
                            return new string(chars); // Возвращаем следующий номерной знак
                        }
                    }
                    // Увеличиваем цифры (позиции 1-3)
                    else if (i >= 1 && i <= 3 && char.IsDigit(chars[i]))
                    {
                        chars[i]++;
                        if (chars[i] > '9')
                        {
                            chars[i] = '0'; // Сбрасываем на 0 и переходим к следующему символу
                            i--;
                        }
                        else
                        {
                            return new string(chars); // Возвращаем следующий номерной знак
                        }
                    }
                    // Увеличиваем первую букву (позиция 0)
                    else if (i == 0 && char.IsLetter(chars[i]))
                    {
                        chars[i]++;
                        if (chars[i] > 'Z')
                        {
                            return "out of stock"; // Предел достигнут
                        }
                        else
                        {
                            return new string(chars); // Возвращаем следующий номерной знак
                        }
                    }
                    else
                    {
                        return "out of stock"; // Неизвестный формат символа
                    }
                }
                return "out of stock"; // Не должен достигать этой точки, но для безопасности
            }
            // Генерация следующего номерного знака
            string nextMark = GenerateNextMark(prevMark);
            // Проверка, достигнут ли предел номерных знаков или выходит ли за пределы диапазона
            if (CompareMarks(nextMark, "out of stock") == 0 || CompareMarks(nextMark, rangeEnd) > 0)
            {
                return "out of stock"; // Возвращаем "out of stock", если предел достигнут или знак вне диапазона
            }
            return nextMark; 
        }

        /// <summary>
        /// Получает количество комбинаций номерных знаков в заданном диапазоне.
        /// </summary>
        /// <param name="mark1">Первый номерной знак.</param>
        /// <param name="mark2">Второй номерной знак.</param>
        /// <returns>Количество комбинаций номерных знаков в диапазоне.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если номерные знаки имеют неверный формат или если mark1 больше mark2.</exception>
        public long GetCombinationsCountInRange(string mark1, string mark2)
        {
            // 1. Проверка входных данных
            if (!IsValidMarkFormat(mark1) || !IsValidMarkFormat(mark2))
            {
                throw new ArgumentException("Неверный формат номерного знака. Должен быть a999aa999");
            }

            // 2. Преобразование номерных знаков в длинные целые числа
            long num1 = ConvertMarkToLong(mark1);
            long num2 = ConvertMarkToLong(mark2);

            // 3. Проверка порядка номеров
            if (num1 > num2)
            {
                throw new ArgumentException("mark1 должен быть меньше или равен mark2");
            }

            // 4. Расчет количества комбинаций (включая границы)
            return num2 - num1 + 1;
        }
        /// <summary>
        /// Проверяет формат номерного знака.
        /// </summary>
        /// <param name="mark">Номерной знак для проверки.</param>
        /// <returns>True, если формат корректный; иначе False.</returns>
        private bool IsValidMarkFormat(string mark)
        {
            // Проверка длины номерного знака
            if (mark.Length != 9) return false;
            // Проверка первой буквы
            if (!char.IsLetter(mark[0])) return false;
            // Проверка первых трех цифр
            if (!char.IsDigit(mark[1]) || !char.IsDigit(mark[2]) || !char.IsDigit(mark[3])) return false;
            // Проверка двух букв
            if (!char.IsLetter(mark[4]) || !char.IsLetter(mark[5])) return false;
            // Проверка последних трех цифр
            if (!char.IsDigit(mark[6]) || !char.IsDigit(mark[7]) || !char.IsDigit(mark[8])) return false;

            return true; // Формат корректный
        }
        /// <summary>
        /// Преобразует номерной знак в длинное целое число.
        /// </summary>
        /// <param name="mark">Номерной знак для преобразования.</param>
        /// <returns>Длинное целое число, представляющее номерной знак.</returns>
        private long ConvertMarkToLong(string mark)
        {
            // Разбиваем номерной знак на составляющие части
            char firstLetter = mark[0]; // Первая буква
            int numbersPart = int.Parse(mark.Substring(1, 3)); // Первые три цифры
            char secondLetter1 = mark[4]; // Первая буква после цифр
            char secondLetter2 = mark[5]; // Вторая буква после цифр
            int regionPart = int.Parse(mark.Substring(6, 3)); // Последние три цифры
            // Преобразуем каждую часть в числовое представление и объединяем в одно большое число
            long result = (firstLetter - 'A'); // Преобразуем первую букву в число (A=0, B=1, ...)
            result *= 1000; // Умножаем на 1000, чтобы освободить место для 3-х значного числа
            result += numbersPart; // Добавляем числовую часть
            result *= (long)Math.Pow(26, 2) * 1000; // Умножаем на 26^2 * 1000 для двух букв и трёх цифр
            result += (secondLetter1 - 'A') * 26 * 1000; // Добавляем первую букву
            result += (secondLetter2 - 'A') * 1000; // Добавляем вторую букву
            result += regionPart; // Добавляем региональную часть
            return result; 
        }
    }
}
