namespace newlab5
{
    public static class FractionOperations
    {
        public static Fraction Addition(Fraction first, Fraction second)
        {
            int numerator = first.Numerator * second.Denominator + first.Denominator * second.Numerator;
            int denominator = first.Denominator * second.Denominator;
            return new Fraction(numerator, denominator);
        }

        public static Fraction Substraction(Fraction first, Fraction second)
        {
            int numerator = first.Numerator * second.Denominator - first.Denominator * second.Numerator;
            int denominator = first.Denominator * second.Denominator;
            return new Fraction(numerator, denominator);
        }

        public static Fraction Multiplication(Fraction first, Fraction second)
        {
            int numerator = first.Numerator * second.Numerator;
            int denominator = first.Denominator * second.Denominator;
            return new Fraction(numerator, denominator);
        }

        public static Fraction Division(Fraction first, Fraction second)
        {
            int numerator = first.Numerator * second.Denominator;
            int denominator = first.Denominator * second.Numerator;
            return new Fraction(numerator, denominator);
        }
    }
}