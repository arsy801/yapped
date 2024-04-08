using System;

bool alive = true;
while (alive == true)
{
    Console.WriteLine("\nЛабораторная работа 3, выполнил студент Артемий Сидоров\n");
    Console.WriteLine("Выберете пункт меню:\n");
    Console.WriteLine("1 - Операции над матрицами");
    Console.WriteLine("2 - Операции с двоичной СС");
    Console.WriteLine("3 - Осознанно завершить работу\n");
    string menu = Console.ReadLine();

    switch (menu)
    {
        case "1":
            {
                MatrixOperations.Run();
                break;
            }
        case "2":
            {
                Convertation.TriadeConvertation();
                break;
            }
        case "3":
            {
                Console.WriteLine("\nВы осознанно завершили работу.\n");
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


class MatrixOperations
{
    public static void Run()
    {
        Console.Write("\nВведите размерность матрицы (не более 10): ");
        int n = int.Parse(Console.ReadLine());

        if (n <= 0 || n > 10)
        {
            Console.WriteLine("Недопустимый размер матрицы. Размер должен быть от 1 до 10.");
            return;
        }

        int[,] matrixA = InputMatrix("Введите матрицу A:", n);
        int[,] matrixB = InputMatrix("Введите матрицу B:", n);

        Console.WriteLine("\nВыберите операцию:\n");
        Console.WriteLine("1. Сложение матриц");
        Console.WriteLine("2. Вычитание матриц");
        Console.WriteLine("3. Умножение матриц");
        Console.WriteLine("4. Умножение матрицы на число");
        Console.WriteLine("5. Сравнение матриц на равенство\n");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                int[,] resultAddition = AddMatrices(matrixA, matrixB);
                PrintMatrix(resultAddition, "\nРезультат сложения матриц:\n");
                break;
            case 2:
                int[,] resultSubtraction = SubtractMatrices(matrixA, matrixB);
                PrintMatrix(resultSubtraction, "\nРезультат вычитания матриц:\n");
                break;
            case 3:
                int[,] resultMultiplication = MultiplyMatrices(matrixA, matrixB);
                PrintMatrix(resultMultiplication, "\nРезультат умножения матриц:\n");
                break;
            case 4:
                Console.Write("\nВведите число для умножения матрицы А: ");
                int scalar = int.Parse(Console.ReadLine());
                int[,] resultScalarMultiplication = MultiplyMatrixByScalar(matrixA, scalar);
                PrintMatrix(resultScalarMultiplication, "\nРезультат умножения матрицы A на число:\n");
                break;
            case 5:
                bool isEqual = AreMatricesEqual(matrixA, matrixB);
                Console.WriteLine("\nМатрицы равны: " + isEqual);
                break;
            default:
                Console.WriteLine("\nНеверный выбор операции\n");
                break;
        }
    }

    static int[,] InputMatrix(string prompt, int n)
    {
        Console.WriteLine(prompt);
        int[,] matrix = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("Введите элементы " + (i + 1) + "-й строки (разделите пробелом): ");
            string[] elements = Console.ReadLine().Split(' ');
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = int.Parse(elements[j]);
            }
        }

        return matrix;
    }

    public static void PrintMatrix(int[,] matrix, string label)
    {
        Console.WriteLine(label);
        int n = matrix.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public static int[,] AddMatrices(int[,] matrixA, int[,] matrixB)
{
    int rows = matrixA.GetLength(0);
    int cols = matrixA.GetLength(1);
    int[,] result = new int[rows, cols];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            result[i, j] = matrixA[i, j] + matrixB[i, j];
        }
    }
    return result;
}

public static int[,] SubtractMatrices(int[,] matrixA, int[,] matrixB)
{
    int rows = matrixA.GetLength(0);
    int cols = matrixA.GetLength(1);
    int[,] result = new int[rows, cols];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            result[i, j] = matrixA[i, j] - matrixB[i, j];
        }
    }
    return result;
}

public static int[,] MultiplyMatrices(int[,] matrixA, int[,] matrixB)
{
    int rowsA = matrixA.GetLength(0);
    int colsA = matrixA.GetLength(1);
    int colsB = matrixB.GetLength(1);
    int[,] result = new int[rowsA, colsB];
    for (int i = 0; i < rowsA; i++)
    {
        for (int j = 0; j < colsB; j++)
        {
            result[i, j] = 0;
            for (int k = 0; k < colsA; k++)
            {
                result[i, j] += matrixA[i, k] * matrixB[k, j];
            }
        }
    }
    return result;
}

public static int[,] MultiplyMatrixByScalar(int[,] matrix, int scalar)
{
    int rows = matrix.GetLength(0);
    int cols = matrix.GetLength(1);
    int[,] result = new int[rows, cols];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            result[i, j] = matrix[i, j] * scalar;
        }
    }
    return result;
}

public static bool AreMatricesEqual(int[,] matrixA, int[,] matrixB)
{
    int rowsA = matrixA.GetLength(0);
    int colsA = matrixA.GetLength(1);
    int rowsB = matrixB.GetLength(0);
    int colsB = matrixB.GetLength(1);

    if (rowsA != rowsB || colsA != colsB)
    {
        return false;
    }

    for (int i = 0; i < rowsA; i++)
    {
        for (int j = 0; j < colsA; j++)
        {
            if (matrixA[i, j] != matrixB[i, j])
            {
                return false;
            }
        }
    }
    return true;
}
}

class Convertation
{
        public static string DecimalToBinary(int decimalNumber)
    {
        if (decimalNumber == 0)
        {
            return "0";
        }

        string binaryNumber = ""; 

        while (decimalNumber > 0)
        {
            int remainder = decimalNumber % 2;
            binaryNumber = remainder + binaryNumber;
            decimalNumber = decimalNumber / 2;
        }
        return binaryNumber;
    }

    public static int BinaryToDecimal(string binaryNumber)
    {
        int decimalNumber = 0;
        for (int i = 0; i < binaryNumber.Length; i++)
        {
            decimalNumber = decimalNumber * 2 + (binaryNumber[i] - '0');
        }
        return decimalNumber;
    }
    public static void TriadeConvertation()
    {
        Console.Write("\n" + "Введите число в десятичной системе счисления: ");
        int decimalNumber = int.Parse(Console.ReadLine());

        string binaryNumber = DecimalToBinary(decimalNumber);
        Console.WriteLine("Число в двоичной системе счисления: " + binaryNumber);

        while (binaryNumber.Length < 9)
        {
            binaryNumber = '0' + binaryNumber;
        }
        binaryNumber = binaryNumber.Substring(0, binaryNumber.Length - 9) + binaryNumber.Substring(binaryNumber.Length - 3, 3) + binaryNumber.Substring(binaryNumber.Length - 6, 3) + binaryNumber.Substring(binaryNumber.Length - 9, 3);
        Console.WriteLine("\n" + "Число после замены триад: " + binaryNumber);

        int newDecimalNumber = BinaryToDecimal(binaryNumber);
        Console.WriteLine("Число в десятичной системе счисления после замены триад: " + newDecimalNumber + "\n");

        Console.WriteLine("Новое значение в двоичной системе счисления: " + binaryNumber);
        Console.WriteLine("Новое значение в десятичной системе счисления: " + newDecimalNumber  + "\n");
        
        Console.WriteLine("\nНажмите на любую клавишу, чтобы продолжить\n");
        Console.ReadKey();
    }
}
