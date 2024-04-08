using System;

bool alive = true;
while (alive == true)
{
    Console.WriteLine("\n" + "\nЛабораторная работа 4, выполнил студент Артемий Сидоров\n");
    Console.WriteLine("Выберете пункт меню:\n");
    Console.WriteLine("1 - Десятичный счётчик");
    Console.WriteLine("2 - Решение квадратных уравнений");
    Console.WriteLine("3 - Завершение работы\n");
    string menu = Console.ReadLine();

    switch (menu)
    {
        case "1":
            {
                Counter.Main();
                break;
            }
        case "2":
            {
                Polynomial.Run();
                break;
            }
        case "3":
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

class DecimalCounter
{
    private int minValue;
    private int maxValue;
    private int currentValue;

    public DecimalCounter(int minValue, int maxValue, int currentValue)
    {
        if (minValue > maxValue)
        {
            this.minValue = maxValue;
            this.maxValue = minValue;
        }
        else
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        if (currentValue > this.maxValue)
        {
            this.currentValue = this.maxValue;
        }
        else if (currentValue < this.minValue)
        {
            this.currentValue = this.minValue;
        }
        else
        {
            this.currentValue = currentValue;
        }
    }

    public void Increment()
    {
        if (currentValue == maxValue)
        {
            currentValue = minValue;
        }
        else
        {
            currentValue++;
        }
    }

    public void Decrement()
    {
        if (currentValue == minValue)
        {
            currentValue = maxValue;
        }
        else
        {
            currentValue--;
        }
    }

    public int GetValue()
    {
        return currentValue;
    }
}

class Counter
{
    public static void Main()
    {
        DecimalCounter counter = new DecimalCounter(0, 9, 5);

        Console.WriteLine("\n" + "Текущее значение счетчика: " + counter.GetValue() + "\n");

        counter.Increment();
        Console.WriteLine("Увеличили счетчик: " + counter.GetValue());

        counter.Decrement();
        Console.WriteLine("Уменьшили счетчик: " + counter.GetValue());

        for (int i = 0; i < 10; i++)
        {
            counter.Increment();
            Console.WriteLine("Увеличили счетчик: " + counter.GetValue());
        }

        for (int i = 0; i < 10; i++)
        {
            counter.Decrement();
            Console.WriteLine("Уменьшили счетчик: " + counter.GetValue());
        }
        Console.WriteLine("\nНажмите на любую клавишу, чтобы продолжить\n");
        Console.ReadKey();
    }
}

class Polynomial
{
    private double a;
    private double b;
    private double c;

    public Polynomial(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public void RootsCalculation()
    {
        double discr = Math.Pow(b, 2) - 4 * a * c;
        if (discr > 0)
        {
            double root1 = (-b + Math.Sqrt(discr)) / (2 * a);
            double root2 = (-b - Math.Sqrt(discr)) / (2 * a);
            Console.WriteLine("\n" + "Уравнение имеет 2 корня:" + "\n" + "\n" + "x = " + root1 + "\n" + "x = " + root2 + "\n");
        }
        else if (discr == 0)
        {
            double root = -b / (2 * a);
            Console.WriteLine("\n" + "Уравнение имеет единственный корень:" + "\n" + "x = " + root);
        }
        else
        {
            Console.WriteLine("\n" + "Уравнение не имеет корней");
        }
    }

    public static void Run()
    {
        Console.WriteLine("\nВведите коэффициенты многочлена ax^2 + bx + c:\n");
        Console.Write("a = ");
        double a = Convert.ToDouble(Console.ReadLine());
        if (a == 0)
        {
            Console.WriteLine("\nУравнение линейное, код решает только квадратные уравнения!");
        }
        else
        {
            Console.Write("b = ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("c = ");
            double c = Convert.ToDouble(Console.ReadLine());

            Polynomial polynom = new Polynomial(a, b, c);
            polynom.RootsCalculation();
        }
        Console.WriteLine("\nНажмите на любую клавишу, чтобы продолжить\n");
        Console.ReadKey();
    }
}
