namespace newlab23
{
    internal class ArrayVector : IVectorable
    {
        public int[] vector;

        public ArrayVector(int size)
        {
            if (size < 1)
            {
                throw new Exception("Размерность вектора должна быть больше нуля!");
            }
            vector = new int[size];
        }
        public ArrayVector() // конструктор без параметра
        {
            vector = new int[5];
        }

        public int this[int i] // индексатор
        {
            get
            {
                return vector[i - 1];
            }
            set
            {
                vector[i - 1] = value;
            }
        }

        public int Length
        {
            get
            {
                return vector.Length;
            }
        }

        public double GetNorm() // метод получения модуля вектора
        {
            int temp = 0;
            foreach (int i in vector)
            {
                temp += i * i;
            }
            return Math.Sqrt(temp);
        }

        public override string ToString()
        {
            string res = Length + "";
            for (int i = 0; i < Length; i++)
            {
                res += " " + this[i + 1];
            }
            return res;
        }
    }
}
