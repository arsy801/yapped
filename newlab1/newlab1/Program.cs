bool alive = true;
while (alive == true)
{
    Console.WriteLine("Лабораторная работа 1, выполнил студент Артемий Сидоров\n");
    Console.WriteLine("Выберете пункт меню:");
    Console.WriteLine("1 - Вычисление двух значений в зависимости от параметра а;");
    Console.WriteLine("2 - Вычисление значения функции в зависимости от значения аргумента;");
    Console.WriteLine("3 - Опредиление попадания в мишень.");
    Console.WriteLine("4 - Завершение работы\n");
    string menu = Console.ReadLine();

    switch (menu)
    {
        case "1":
            {
                Console.WriteLine("Введите число а");
                string sa = Console.ReadLine();
                double a = Convert.ToDouble(sa);
                double z11 = 2 * a + Math.Pow(a, 2);
                if (z11 == 0)
                    Console.WriteLine("На нуль делить нельзя!");
                else
                {
                    double z21 = 2 * a - Math.Pow(a, 2);
                    if (z21 == 0)
                        Console.WriteLine("На нуль делить нельзя");
                    else
                    {
                        double z1 = Math.Pow((1 + a + Math.Pow(a, 2)) / z11 + 2 - ((1 - a + Math.Pow(a, 2)) / z21), -1) * (5 - 2 * Math.Pow(a, 2));
                        double z2 = (4 - Math.Pow(a, 2)) / 2;
                        Console.WriteLine("z1 = {0}", z1);
                        Console.WriteLine("z2 = {0}", z2);
                    }
                }
                break;
            }
        case "2":
            {
                Console.WriteLine("Введите х");
                double x = Convert.ToDouble(Console.ReadLine());
                if (x >= -7 && x <= 3)
                {
                    double y;
                    if (x <= -6)
                        y = 2;
                    else if (x <= -2)
                        y = 0.25 * (x + 2);
                    else if (x <= 0)
                        y = 2 - Math.Sqrt(-Math.Pow(x, 2) - 4 * x);
                    else if (x <= 2)
                        y = Math.Sqrt(-Math.Pow(x, 2) + 4);
                    else y = -(x - 2);
                    Console.WriteLine("y = " + y);
                }
                else
                {
                    Console.WriteLine("Функция не определена");
                }
                break;
            }
        case "3":
            {
                Console.WriteLine("Введите х");
                double x = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите у");
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
                        Console.WriteLine("Вы попали!!!!!!!!!");
                    else
                        Console.WriteLine("Вы не попали(((((((((");
                }
                else Console.WriteLine("Вы не попали(((((((((");
                break;
            }
        case "4":
            alive = false;
            break;
        default:
            Console.WriteLine("Повторите ввод");
            break;
    }
}