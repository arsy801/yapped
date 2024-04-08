using System.Globalization;

namespace newlab7
{
    public static class StringOperations
    {
        public static string LetterCount(string expression)
        {
            int wordsCount = 0;
            char[] expArr = expression.ToCharArray();
            foreach (char symbol in expArr)
            {
                if (char.IsLetter(symbol))
                wordsCount += 1;
            }
            return $"\nВ выражении {expression} - {Convert.ToString(wordsCount)} букв";
        }

        public static string AverageCount(string expression)
        {
            char[] separators = new char[] { ' ', ',', '.', '!', '?' };

            string[] words = expression.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            int totalLength = 0;

            foreach (string word in words)
            {
                totalLength += word.Length;
            }

            double averageLength = (double)totalLength / words.Length;

            return $"\nСредняя длина слова - {averageLength}";
        }

        public static string WordsReplace(string expression, string wordChange, string wordNew)
        {
            string[] words = expression.Split(' '); 

            for (int i = 0; i < words.Length; i++)
            {
                if (string.Equals(words[i], wordChange, StringComparison.OrdinalIgnoreCase)) 
                {
                    words[i] = wordNew;
                }
            }
            string result = string.Join(" ", words);
            return result;
        }

        public static string SubstringCount(string expression, string substring) 
        {
            int count = 0;
            int index = 0;
            expression = expression.ToLower();
            while ((index = expression.IndexOf(substring, index)) != -1) 
            {
                count++;
                index += substring.Length;
            }

            return $"\nКоличество вхождений подстроки {substring} в строку '{expression}' - {count}. ";
        }

        public static string PalindromFinder(string expression)
        {
            string cleanString = new string(expression.Where(char.IsLetterOrDigit).ToArray()).ToLower(); 

            int left = 0;
            int right = cleanString.Length - 1;

            while (left < right)
            {
                if (cleanString[left] != cleanString[right])
                {
                    return "\nСтрока не является палиндромом";
                }
                left++;
                right--;
            }
            return "\nСтрока явялется палиндромом";
        }

        public static string DateFinder(string expression)
        {
            DateTime time;
            if (DateTime.TryParseExact(expression, new[] { "dd.MM.yy", "dd.MM.yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out time)) 
            {
                return $"\nСтрока {expression} - дата.";
            }
            else
            {
                return $"\nСтрока {expression} не является датой.";
            }
        }
    }
}