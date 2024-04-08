namespace newlab22
{
    internal class Vectors
    {
        public static ArrayVector2 Sum(ArrayVector2 vector1, ArrayVector2 vector2)
        {
            if (vector1.Length != vector2.Length)
            {
                throw new Exception("Размерность векторов не совпадает!");
            }
            ArrayVector2 sum = new ArrayVector2(vector1.Length);
            for (int i = 0; i < vector1.Length; i++)
            {
                sum[i] = vector1[i] + vector2[i];
            }
            return sum;
        }

        public static double Scalar(ArrayVector2 vector1, ArrayVector2 vector2)
        {
            if (vector1.Length != vector2.Length)
            {
                throw new FormatException("Размерность векторов не совпадает!");
            }
            double scalar = 0;
            for (int i = 0; i < vector1.Length; i++)
            {
                scalar += vector1[i] * vector2[i];
            }
            return scalar;
        }

        public static double GetNormSt(ArrayVector2 vector)
        {
            return vector.GetNorm();
        }
    }
}