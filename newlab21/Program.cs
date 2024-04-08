using System.Globalization;

namespace newlab21
{
    class Program
    {
        public static void Main()
        {
            bool alive = true;
            Console.WriteLine(123);
            while (alive == true)
            {
                Console.WriteLine("\nСеместр 2, Лабораторная работа 1, выполнил студент Артемий Сидоров\n");
                Console.WriteLine("1 - использование класса ArrayVector");
                Console.WriteLine("2 - использование класса Vectors");
                Console.WriteLine("3 - завершение работы\n");
                string menu = Console.ReadLine()!;

                switch (menu)
                {
                    case "1":
                        {
                            Console.WriteLine("Введите координаты вектора через пробел");
                            string[] temp = Console.ReadLine().Split(" ");
                            ArrayVector vector = new ArrayVector(temp.Length);

                            for (int i = 0; i < temp.Length; i++)
                            {
                                vector[i] = int.Parse(temp[i]);
                            }

                            try
                            {
                                Console.Write("Ведите индекс элемента вектора, который хотите вывести: ");
                                int j = int.Parse(Console.ReadLine());
                                Console.WriteLine("Элемент с индексом " + j + " : " + vector[j]);
                            }
                            catch
                            {
                                Console.WriteLine("значение индекса выходит за предел");
                            }


                            try
                            {
                                int a = vector.SumPositivesFromChetIndex();
                                Console.WriteLine("Сумма всех положительных элементов с чётными номерами: " + a);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            try
                            {
                                int a = vector.SumLessFromNechetIndex();
                                Console.WriteLine("Сумма всех элементов меньше среднего значения всех модулей: " + a);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            try
                            {
                                int a = vector.MultChet();
                                Console.WriteLine("Произведение всех чётных положительных элементов: " + a);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            try
                            {
                                int a = vector.MultNechet();
                                Console.WriteLine("Произведение всех нечетных положительных элементов: " + a);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            int[] b = vector.SortUp();
                            Console.Write("Сортировка по возрастанию");
                            PrintArray(b);
                            int[] c = vector.SortDown();
                            Console.Write("Сортировка по убыванию");
                            PrintArray(c);
                            double d = vector.GetNorm();

                            Console.WriteLine("Модуль вектора: " + d);
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Введите координаты вектора 1 через пробел");
                            string[] temp1 = Console.ReadLine().Split(" ");
                            ArrayVector vector1 = new ArrayVector(temp1.Length);

                            for (int i = 0; i < temp1.Length; i++)
                            {
                                vector1[i] = int.Parse(temp1[i]);
                            }

                            Console.WriteLine("Введите координаты вектора 2 через пробел");
                            string[] temp2 = Console.ReadLine().Split(" ");
                            ArrayVector vector2 = new ArrayVector(temp2.Length);

                            for (int i = 0; i < temp2.Length; i++)
                            {
                                vector2[i] = int.Parse(temp2[i]);
                            }

                            try
                            {
                                ArrayVector sum = Vectors.Sum(vector1, vector2);
                                double scalar = Vectors.Scalar(vector1, vector2);
                                sum.PrintArray();
                                Console.WriteLine(scalar);

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            Console.Write("Введите число, на которое умножить вектор: ");
                            int n = int.Parse(Console.ReadLine());
                            ArrayVector mult = Vectors.MultNumber(vector1, n);
                            Console.Write("Вектор после умножения: ");
                            mult.PrintArray();
                            break;
                        }
                    case "3":
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

        private static void PrintArray(int[] array)
        {
            Console.Write("{ ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                if (i < array.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine(" }");
        }
    }
}