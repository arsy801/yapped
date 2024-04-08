namespace newlab5
{
    public class Fraction
    {
        private int numerator;
        private int denominator;

        public int Numerator
        {
            get
            {
                return numerator;
            }
            set
            {
                numerator = value;
            }
        }

        public int Denominator
        {
            get
            {
                return denominator;
            }
            set
            {
                if (value == 0)
                    throw new DivideByZeroException("\nЗнаменатель не может быть равен нулю");
                denominator = value;
            }
        }

        public Fraction()
        {
            Denominator = 1;
        }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public void Addition(Fraction fraction)
        {
            var result = FractionOperations.Addition(this, fraction);
            Numerator = result.Numerator;
            Denominator = result.Denominator;
        }

        public void Substraction(Fraction fraction)
        {
            var result = FractionOperations.Substraction(this, fraction);
            Numerator = result.Numerator;
            Denominator = result.Denominator;
        }

        public void Multiplication(Fraction fraction)
        {
            var result = FractionOperations.Multiplication(this, fraction);
            Numerator = result.Numerator;
            Denominator = result.Denominator;
        }

        public void Division(Fraction fraction)
        {
            var result = FractionOperations.Division(this, fraction);
            Numerator = result.Numerator;
            Denominator = result.Denominator;
        }



        public void PrintInfo()
        {
            if (Numerator == 0)
                Console.Write(0);
            else if (Denominator == 1)
                Console.Write(Numerator);
            else
                Console.Write($"{Numerator}/{Denominator}");
        }

        public static Fraction operator +(Fraction first, Fraction second)
        {
            return FractionOperations.Addition(first, second);
        }

        public static Fraction operator -(Fraction first, Fraction second)
        {
            return FractionOperations.Substraction(first, second);
        }

        public static Fraction operator *(Fraction first, Fraction second)
        {
            return FractionOperations.Multiplication(first, second);
        }

        public static Fraction operator /(Fraction first, Fraction second)
        {
            return FractionOperations.Division(first, second);
        }

        public void Reduce()
        {
            if (Numerator == 0)
                return;

            int gcd = GCD();
            Numerator = Numerator / gcd;
            Denominator = Denominator / gcd;
        }
        private int GCD()
        {
            int n = Math.Abs(Numerator);
            int d = Math.Abs(Denominator);
            while (d != 0)
            {
                int temp = d;
                d = n % d;
                n = temp;
            }
            return n;
        }

        // public void Reduce()
        // {
        //     if (Numerator == 0)
        //         return;

        //     int gcd = GCD(Numerator, Denominator);

        //     Numerator = Numerator / gcd;
        //     Denominator = Denominator / gcd;
        // }
        // private int GCD(int a, int b)
        // {
        //     while (b != 0)
        //     {
        //         int temp = b;
        //         b = a % b;
        //         a = temp;
        //     }
        //     return a;
        // }

    }
}