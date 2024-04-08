namespace newlab23
{
    internal class Vectors
    {
        public static IVectorable Sum(IVectorable vector1, IVectorable vector2)
        {
            if (vector1.Length != vector2.Length)
            {
                throw new Exception("Размерность векторов не совпадает!");
            }
            IVectorable sum = new ArrayVector(vector1.Length);
            for (int i = 1; i < vector1.Length + 1; i++)
            {
                sum[i] = vector1[i] + vector2[i];
            }
            return sum;
        }

        public static double Scalar(IVectorable vector1, IVectorable vector2)
        {
            if (vector1.Length != vector2.Length)
            {
                throw new FormatException("Размерность векторов не совпадает!");
            }
            double scalar = 0;
            for (int i = 1; i < vector1.Length + 1; i++)
            {
                scalar += vector1[i] * vector2[i];
            }
            return scalar;
        }

        public static double GetNormSt(IVectorable vector)
        {
            return vector.GetNorm();
        }
    }
}