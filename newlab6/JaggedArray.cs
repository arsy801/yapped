namespace newlab6;

class JaggedArray
{
    private int[][] jaggedArray;

    public JaggedArray()
    {
        jaggedArray = new int[0][];
    }

    public JaggedArray(int[][] array)
    {
        jaggedArray = array;
    }

    public void Input()
    {
        Console.WriteLine("\nВведите количество строк в ступенчатом массиве:\n");
        int rows = int.Parse(Console.ReadLine());

        jaggedArray = new int[rows][];

        for (int i = 0; i < rows; i++)
        {
            Console.WriteLine($"\nВведите количество элементов в строке {i + 1}:\n");
            int elements = int.Parse(Console.ReadLine());

            jaggedArray[i] = new int[elements];

            Console.WriteLine($"\nВведите элементы строки {i + 1} через пробел:\n");
            string[] inputValues = Console.ReadLine().Split(' ');

            for (int j = 0; j < elements; j++)
            {
                jaggedArray[i][j] = int.Parse(inputValues[j]);
            }
        }
    }

    public void Output()
    {

        for (int i = 0; i < jaggedArray.Length; i++)
        {
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                Console.Write($"{jaggedArray[i][j]} ");
            }
            Console.WriteLine();
        }
    }

    public void SortAndRebuild()
    {
        int[] flattenedArray = new int[jaggedArray.Sum(row => row.Length)];
        int index = 0;

        foreach (int[] row in jaggedArray)
        {
            foreach (int element in row)
            {
                flattenedArray[index++] = element;
            }
        }

        Array.Sort(flattenedArray);

        index = 0;
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                jaggedArray[i][j] = flattenedArray[index++];
            }
        }
    }
}
