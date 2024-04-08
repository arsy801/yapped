namespace newlab22
{
    internal class ArrayVector2
    {
        public int[] vector;

        public ArrayVector2(int size)
        {
            if (size < 1)
            {
                throw new Exception("Размерность вектора должна быть больше нуля!");
            }
            vector = new int[size];
        }
        public ArrayVector2() // конструктор без параметра
        {
            vector = new int[5];
        }

        public int this[int i] // индексатор
        {
            get
            {
                return vector[i];
            }
            set
            {
                vector[i] = value;
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
            string s = "{ ";
            for (int i = 0; i < Length; i++)
            {
                s += this[i];
                if (i < Length - 1)
                {
                    s += ", ";
                }
            }
            s += " }";
            return s;
        }
    }
}
