namespace newlab7
{
    class Program
    {
        public static void Main()
        {
            bool alive = true;
            while (alive == true)
            {
                Console.WriteLine("\nЛабораторная работа 7, выполнил студент Артемий Сидоров\n");
                Console.WriteLine("1 - Количество букв в строке");
                Console.WriteLine("2 - Усреднённое значение");
                Console.WriteLine("3 - Замена вхождений слова");
                Console.WriteLine("4 - Количесво вхождения строки");
                Console.WriteLine("5 - Проверка на палиндром");
                Console.WriteLine("6 - Проверка на дату");
                Console.WriteLine("7 - Завершение работы\n");
                string menu = Console.ReadLine()!;

                switch (menu)
                {
                    case "1":
                        {
                            Console.WriteLine(StringOperations.LetterCount(GetInput("\nВведите строку:\n")));
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine(StringOperations.AverageCount(GetInput("\nВведите строку:\n")));
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine(StringOperations.WordsReplace(GetInput("\nВведите строку, заменяемое слово и новое слово:\n"), Console.ReadLine(), Console.ReadLine()));
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine(StringOperations.SubstringCount(GetInput("\nВведите строку и подстроку:\n"), Console.ReadLine()));
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine(StringOperations.PalindromFinder(GetInput("\nВведите строку:\n")));
                            break;
                        }
                    case "6":
                        {
                            Console.WriteLine(StringOperations.DateFinder(GetInput("\nВведите строку:\n")));
                            break;
                        }
                    case "7":
                        {
                            Console.WriteLine("\nВы завершили работу программы\n");
                            alive = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\nПовторите ввод\n");
                            break;
                        }
                }
                Console.WriteLine("\n\nНажмите на любую клавишу, чтобы продолжить\n");
                Console.ReadKey();
            }
        }
        public static string GetInput(string request)
        {
            Console.WriteLine(request);
            string exp = Console.ReadLine();
            return exp;
        }
    }
}