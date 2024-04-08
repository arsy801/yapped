using newlab5;

class Program
{

    public static void Main()
    {
        bool alive = true;
        while (alive == true)
        {
            try 
            {
                Console.WriteLine("\n\nЛабораторная работа 5, выполнил студент Артемий Сидоров");

                Console.Write("\nВведите числитель первой дроби: ");
                int n1 = int.Parse(Console.ReadLine());
                Console.Write("\nВведите знаменатель первой дроби: ");
                int d1 = int.Parse(Console.ReadLine());

                Console.Write("\nВведите числитель второй дроби: ");
                int n2 = int.Parse(Console.ReadLine());
                Console.Write("\nВведите знаменатель второй дроби: ");
                int d2 = int.Parse(Console.ReadLine());

                var f1 = new Fraction(n1, d1);
                var f2 = new Fraction(n2, d2);

                Console.Write("\nВведённые дроби: ");
                f1.PrintInfo();
                Console.Write("; ");
                f2.PrintInfo();

                Console.WriteLine("\n\nВыберете пункт меню:\n");
                Console.WriteLine("1 - Сложить дробь 1 с дробью 2");
                Console.WriteLine("2 - Вычесть дробь 2 из дроби 1");
                Console.WriteLine("3 - Перемножить дроби");
                Console.WriteLine("4 - Поделить дробь 1 на дробь 2");
                Console.WriteLine("5 - Сократить дроби");
                Console.WriteLine("6 - Завершение работы\n");

                string menuChoise = Console.ReadLine();

                switch (menuChoise)
                {
                    case "1":
                        {
                            var f3 = FractionOperations.Addition(f1, f2);
                            Console.WriteLine("\nСложение: \n");
                            f3.PrintInfo();
                            break;
                        }
                    case "2":
                        {
                            var f3 = FractionOperations.Substraction(f1, f2);
                            Console.WriteLine("\nВычитание: \n");
                            f3.PrintInfo();
                            break;
                        }
                    case "3":
                        {
                            var f3 = FractionOperations.Multiplication(f1, f2);
                            Console.WriteLine("\nУмножение: \n");
                            f3.PrintInfo();

                            break;
                        }
                    case "4":
                        {
                            var f3 = FractionOperations.Division(f1, f2);
                            Console.WriteLine("\nДеление: \n");
                            f3.PrintInfo();
                            break;
                        }
                    case "5":
                        {
                            Console.Write("\nСокращение дробей: ");
                            f1.Reduce();
                            f1.PrintInfo();
                            Console.Write("; ");
                            f2.Reduce();
                            f2.PrintInfo();
                            break;
                        }
                    case "6":
                        {
                            Console.WriteLine("\nВы завершили работу программы.\n");
                            alive = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\nПовторите ввод\n");
                            break;
                        }
                }
            }
            catch (DivideByZeroException error)
            {
                Console.WriteLine(error.Message);
            }
            Console.WriteLine("\n\nНажмите на любую клавишу, чтобы продолжить\n");
            Console.ReadKey();
        }
    }
}