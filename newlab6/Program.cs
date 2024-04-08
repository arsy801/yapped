using newlab6;

class Program
{
    public static void Main()
    {
        bool alive = true;
        while (alive == true)
        {
            Console.WriteLine("\nЛабораторная работа 4, выполнил студент Артемий Сидоров\n");
            Console.WriteLine("Выберете пункт меню:\n");
            Console.WriteLine("1 - Сортировка массива");
            Console.WriteLine("2 - Мой массив");
            Console.WriteLine("3 - Ступенчатый массив");
            Console.WriteLine("4 - Завершение работы\n");
            string menu = Console.ReadLine();

            switch (menu)
            {
                case "1":
                    {
                        int[] array = ReadArray();
                        Console.WriteLine("\nВыберете сортировку:\n");
                        Console.WriteLine("1 - Пузырьковая сортировка");
                        Console.WriteLine("2 - Сортировка вставкой");
                        Console.WriteLine("3 - Сортировка выбором\n");
                        string sortingmenu = Console.ReadLine();
                        switch(sortingmenu)
                        {
                            case "1":
                            {
                                Sorting.BubbleSort(array);
                                PrintArray(array);
                                break;
                            }
                            case "2":
                            {
                                Sorting.SelectionSort(array);
                                PrintArray(array);
                                break;
                            }
                            case "3":
                            {
                                Sorting.InsertionSort(array);
                                PrintArray(array);
                                break;
                            }
                            default:
                            {
                                Console.WriteLine("\nПовторите ввод\n");
                                break;
                            }
                        }
                        break;
                    }
                case "2":
                    {
                        MyArray myArray = new MyArray();

                        Console.WriteLine("\nИсходный массив:");
                        myArray.PrintArray();

                        Console.WriteLine("\nСтолбцы отсортированные по сумме по убыванию:");
                        myArray.SortColumnsBySum(true);
                        myArray.PrintArray();

                        Console.WriteLine("\nСтолбцы отсортированные по сумме по возрастанию:");
                        myArray.SortColumnsBySum(false);
                        myArray.PrintArray();
                        break;
                    }
                case "3":
                    {
                        JaggedMain();
                        break;
                    }
                case "4":
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
            Console.WriteLine("\nНажмите на любую клавишу, чтобы продолжить\n");
            Console.ReadKey();
        }
    }
    public static int[] ReadArray()
    {
        Console.Write("\nВведите элементы массива через пробел: ");
        string input = Console.ReadLine();

        int[] array = Array.ConvertAll(input.Split(' '), int.Parse);

        return array;
    }
    public static void PrintArray(int[] array)
    {
        Console.WriteLine($"\nОтсортированный массив: {string.Join(" ", array)}");
    }
    public static void JaggedMain()
    {
        JaggedArray jaggedArray = new JaggedArray();
        jaggedArray.Input();

        Console.WriteLine("\nИсходный ступенчатый массив:\n");
        jaggedArray.Output();

        jaggedArray.SortAndRebuild();

        Console.WriteLine("\nСтупенчатый массив после сортировки и восстановления структуры:\n");
        jaggedArray.Output();
    }
}
