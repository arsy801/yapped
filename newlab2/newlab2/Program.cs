bool alive = true;
while (alive == true)
{
    Console.WriteLine("\nЛабораторная работа 2, выполнил студент Артемий Сидоров\n");
    Console.WriteLine("Выберете пункт меню:\n");
    Console.WriteLine("1 - Таблица значений функции");
    Console.WriteLine("2 - Серия выстрелов по мишени");
    Console.WriteLine("3 - Сумма ряда");
    Console.WriteLine("4 - Осознанно завершить работу\n");
    string menu = Console.ReadLine();

    switch (menu)
    {
        case "1":
            {
                Console.WriteLine("Введите минимальное значение Х");
                double Xmin = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите максимальное значение Х");
                double Xmax = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите шаг");
                double dX = Convert.ToDouble(Console.ReadLine());
                double y;
                Console.WriteLine("{0,9}{1,8}", "x", "y");
                for (double x = Xmin; x <= Xmax; x += dX)
                {
                    if (x >= -7 && x <= 3)
                    {
                        if (x <= -6)
                        {
                            y = 2;
                        }
                        else if (x <= -2)
                        {
                            y = 0.25 * (x + 2);
                        }
                        else if (x <= 0)
                        {
                            y = 2 - Math.Sqrt(-Math.Pow(x, 2) - 4 * x);
                        }
                        else if (x <= 2)
                        {
                            y = Math.Sqrt(-Math.Pow(x, 2) + 4);
                        }
                        else
                        {
                            y = -(x - 2);
                        }
                        Console.WriteLine("{0,9:0.00}{1,8:0.00}", x, y);
                    }
                    else
                    {
                        Console.WriteLine("{0,9:0.00}{1,8}", x, "-");
                    }
                }
                break;
            }
        case "2":
            {
                int n = 0;
                while (n < 10)
                {
                    Console.WriteLine("\nВведите х\n");
                    double x = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("\nВведите у\n");
                    double y = Convert.ToDouble(Console.ReadLine());
                    if (y >= Math.Pow(x - 2, 2) - 3)
                    {
                        bool isWin = false;
                        if (y >= 0)
                        {
                            if (y <= x)
                            {
                                isWin = true;

                            }
                        }
                        else
                        {
                            if (y <= -x)
                            {
                                isWin = true;
                            }
                        }
                        if (isWin == true)
                        {
                            Console.WriteLine("\nВы попали!\n");
                        }
                        else
                        {
                            Console.WriteLine("\nВы не попали(\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nВы не попали(\n");
                    }
                    n++;
                }
                break;
            }
        case "3":
            { 
               
                double exp;
                double sum = Math.PI / 2;
                int n = 0;
                Console.WriteLine("\nВведите переменную x\n");
                double x = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("\nВведите значение точности acr\n");
                double acr = Convert.ToDouble(Console.ReadLine());
                if (x > 1)
                {
                    do
                    {
                        exp = Math.Pow(-1, n + 1) / ((2 * n + 1) * Math.Pow(x, 2 * n + 1));
                        sum += exp;
                        n++;
                    }
                    while (Math.Abs(exp) > acr);
                    Console.WriteLine("\nСумма ряда = " + sum);
                    Console.WriteLine("\nКоличество членов ряда = " + n);
                }
                else
                {
                    Console.WriteLine("\nЗначение x должно быть больше 1!\n");
                }
                break;
            }
        case "4":
            {
                Console.WriteLine("\nВы осознанно завершили работу.\n");
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
