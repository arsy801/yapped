namespace newlab6;

using System;

class MyArray
{
        private int[,] array;
        private int m;
        private int n;

        public MyArray()
        {
            m = 2;
            n = 3;
            array = new int[m, n];
            InitializeArray();
        }
 
        public MyArray(int m, int n)
        {
            this.m = m;
            this.n = n;
            array = new int[m, n];
            InitializeArray();
        }

        private void InitializeArray()
        {
            Random random = new Random();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = random.Next(-100, 101);
                }
            }
        }

        public void PrintArray()
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

    public void SortColumnsBySum(bool descending)
    {
        int[] columnSums = CalculateColumnSums();

        int[] columnIndices = new int[n]; // массив индексов столбцов
        for (int i = 0; i < n; i++)
        {
            columnIndices[i] = i;
        }

        if (descending)
        {
            BubbleSortDescending(columnIndices, columnSums);
        }
        else
        {
            BubbleSortAscending(columnIndices, columnSums);
        }

        int[,] tempArray = new int[m, n]; // массив для перестановки столбцов

        for (int i = 0; i < n; i++)
        {
            int columnIndex = columnIndices[i];

            for (int j = 0; j < m; j++)
            {
                tempArray[j, i] = array[j, columnIndex];
            }
        }

        array = tempArray;
    }

    private void BubbleSortDescending(int[] columnIndices, int[] columnSums)
    {
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (columnSums[columnIndices[j]] < columnSums[columnIndices[j + 1]])
                {
                    int temp = columnIndices[j];
                    columnIndices[j] = columnIndices[j + 1];
                    columnIndices[j + 1] = temp;
                }
            }
        }
    }

    private void BubbleSortAscending(int[] columnIndices, int[] columnSums)
    {
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (columnSums[columnIndices[j]] > columnSums[columnIndices[j + 1]])
                {
                    int temp = columnIndices[j];
                    columnIndices[j] = columnIndices[j + 1];
                    columnIndices[j + 1] = temp;
                }
            }
        }
    }
    private int[] CalculateColumnSums()
    {
        int[] columnSums = new int[n];

        for (int j = 0; j < n; j++)
        {
            for (int i = 0; i < m; i++)
            {
                columnSums[j] += array[i, j];
            }
        }

        return columnSums;
    }
}