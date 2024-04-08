namespace newlab6
{
    public static class Sorting
        {
            public static int[] BubbleSort(int[] array)
            {
                int n = array.Length;

                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - 1 - i; j++)
                    {
                        if (array[j] > array[j + 1])
                        {
                            int temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
                return array;
            }
            public static int[] SelectionSort(int[] array)
            {
                int n = array.Length;

                for (int i = 0; i < n - 1; i++)
                {
                    int minIndex = i;

                    for (int j = i + 1; j < n; j++)
                    {
                        if (array[j] < array[minIndex])
                        {
                            minIndex = j;
                        }
                    }
                    int temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;
                }
                return array;
            }
            public static int[] InsertionSort(int[] array)
            {
                int n = array.Length;

                for (int i = 1; i < n; i++)
                {
                    int key = array[i];
                    int j = i - 1;

                    while (j >= 0 && array[j] > key)
                    {
                        array[j + 1] = array[j];
                        j--;
                    }

                    array[j + 1] = key;
                }
                return array;
            }
        }
}