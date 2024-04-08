using System.Runtime.Serialization.Formatters.Binary;

namespace newlab25
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Лабораторная работа №5. Выполнил студент 6103-020302D группы Сидоров Артемий");
            while (true)
            {
                Console.WriteLine("\nВыберите один из пунтов меню");
                Console.WriteLine("1 - Input/Output Vectors");
                Console.WriteLine("2 - Write/Read Vectors");
                Console.WriteLine("3 - Сериализация");
                Console.WriteLine("4 - Запуск меню 4ой лаборторной работы");
                Console.WriteLine("5 - Завершение работы");
                string selectedAction = Console.ReadLine();

                switch (selectedAction)
                {
                    case "1":
                        {
                            string fileName = "test-io-vectors.bin";

                            IVectorable[] vectors = Utility.GetRadnomVectors();
                            Console.WriteLine("Исходный массив векторов:");
                            for (int i = 0; i < vectors.Length; i++)
                            {
                                Console.WriteLine(i + ") " + vectors[i]);
                            }

                            FileStream outputStream = File.Create(fileName);

                            Vectors.OutputVectors(vectors, outputStream);
                            outputStream.Close();

                            FileStream inputStream = File.OpenRead(fileName);
                            IVectorable[] newVectors = Vectors.InputVectors(inputStream);
                            inputStream.Close();

                            Console.WriteLine();
                            Utility.TestVectorsEquality(vectors, newVectors);
                            break;
                        }
                    case "2":
                        {
                            string fileName = "test-wr-vectors.txt";

                            IVectorable[] vectors = Utility.GetRadnomVectors();
                            Console.WriteLine("Исходный массив векторов:");
                            for (int i = 0; i < vectors.Length; i++)
                            {
                                Console.WriteLine(i + ") " + vectors[i]);
                            }

                            StreamWriter streamWriter = File.CreateText(fileName);
                            Vectors.WriteVectors(vectors, streamWriter);
                            streamWriter.Close();

                            StreamReader streamReader = File.OpenText(fileName);
                            IVectorable[] newVectors = Vectors.ReadVectors(streamReader);
                            streamReader.Close();

                            Console.WriteLine();
                            Utility.TestVectorsEquality(vectors, newVectors);
                            break;
                        }
                    case "3":
                        {
                            string fileNameAV = "test-serialization-av.bat";
                            string fileNameLLV = "test-serialization-llv.bat";

                            IVectorable vectorA = Utility.GetRandomAV();
                            IVectorable vectorLL = Utility.GetRandomLLV();
                            Console.WriteLine("Исходный ArrayVectror: " + vectorA);
                            Console.WriteLine("Исходный LinkedListVector: " + vectorLL);

                            FileStream fileStreamA = File.Create(fileNameAV);
                            FileStream fileStreamLL = File.Create(fileNameLLV);

                            BinaryFormatter serializerA = new BinaryFormatter();
                            BinaryFormatter serializerLL = new BinaryFormatter();

                            serializerA.Serialize(fileStreamA, vectorA);
                            serializerLL.Serialize(fileStreamLL, vectorLL);

                            fileStreamA.Close();
                            fileStreamLL.Close();

                            fileStreamA = File.OpenRead(fileNameAV);
                            fileStreamLL = File.OpenRead(fileNameLLV);

                            IVectorable newVectorA = (IVectorable)serializerA.Deserialize(fileStreamA)!;
                            IVectorable newVectorLL = (IVectorable)serializerA.Deserialize(fileStreamLL)!;

                            fileStreamA.Close();
                            fileStreamLL.Close();

                            Console.WriteLine("Десериализованный ArrayVectror: " + newVectorA);
                            Console.WriteLine("Десериализованный LinkedListVector: " + newVectorLL);

                            Utility.TestVectorsEquality(new IVectorable[] { vectorA, vectorLL }, new IVectorable[] { newVectorA, newVectorLL });
                            break;
                        }
                    case "4":
                        Run4LabMenu();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Не выбран ни один пункт меню");
                        break;
                }
            }
        }

        private static void Run4LabMenu()
        {
            while (true)
            {
                Console.WriteLine("\nСеместр 2, Лабораторная работа 4, выполнил студент Артемий Сидоров\n");
                Console.WriteLine("1 - использование класса ArrayVector");
                Console.WriteLine("2 - использование класса LinkedListVector");
                Console.WriteLine("3 - использование класса Vectors");
                Console.WriteLine("4 - сравнение векторов");
                Console.WriteLine("5 - клонирование векторов");
                Console.WriteLine("6 - завершение работы\n");
                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        {
                            Console.WriteLine("Введите координаты вектора через пробел");
                            string[] temp = Console.ReadLine().Split(" ");
                            ArrayVector vector = new ArrayVector(temp.Length);

                            for (int i = 0; i < temp.Length; i++)
                            {
                                vector[i + 1] = int.Parse(temp[i]);
                            }

                            Console.WriteLine("Модуль вектора: " + vector.GetNorm());
                            Console.WriteLine("Размерность вектора: ", vector.Length);

                            try
                            {
                                Console.Write("Ведите индекс элемента вектора, который хотите вывести: ");
                                int j = int.Parse(Console.ReadLine());
                                Console.WriteLine("Элемент с индексом " + j + ": " + vector[j]);
                            }
                            catch
                            {
                                Console.WriteLine("значение индекса выходит за предел");
                            }
                            double d = vector.GetNorm();
                            Console.WriteLine("Модуль вектора: " + d);
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Введите элементы списка через пробел: ");
                            string[] temp = Console.ReadLine().Split(" ");

                            var list = new LinkedListVector(temp.Length);

                            for (int i = 0; i < temp.Length; i++)
                            {
                                list[i + 1] = int.Parse(temp[i]);
                            }

                            Console.WriteLine("Список: " + list);

                            bool alive2 = true;
                            while (alive2 == true)
                            {


                                Console.WriteLine("0 - вернуться в предыдущее меню");
                                Console.WriteLine("1 - вывод списка и размерности");
                                Console.WriteLine("2 - вставка в начало");
                                Console.WriteLine("3 - удаление из начала");
                                Console.WriteLine("4 - вставка в конец");
                                Console.WriteLine("5 - удаление из конца");
                                Console.WriteLine("6 - вставка по индексу");
                                Console.WriteLine("7 - удаление по индексу");
                                Console.WriteLine("8 - модуль списка");
                                Console.WriteLine("9 - получение элемента по индексу");
                                Console.WriteLine("10 - изменение элемента по индексу");
                                string menu2 = Console.ReadLine()!;

                                try
                                {
                                    switch (menu2)
                                    {
                                        case "0":
                                            {
                                                alive2 = false;
                                                break;
                                            }
                                        case "1":
                                            {
                                                Console.WriteLine("Вывод списка и размерности:");
                                                Console.WriteLine("Список: " + list);
                                                Console.WriteLine("Размерность: " + list.Length);
                                                break;
                                            }
                                        case "2":
                                            {
                                                Console.WriteLine("Вставка в начало");
                                                Console.Write("Введите число, которое вставить: ");
                                                int num = int.Parse(Console.ReadLine()!);
                                                list.InsertStart(num);
                                                Console.WriteLine("Список: " + list);
                                                Console.WriteLine("Размерность списка: " + list.Length);
                                                break;
                                            }
                                        case "3":
                                            {
                                                Console.WriteLine("Удаление из начала");
                                                list.DeleteStart();
                                                Console.WriteLine("Список: " + list);
                                                Console.WriteLine("Размерность списка: " + list.Length);
                                                break;
                                            }
                                        case "4":
                                            {
                                                Console.WriteLine("Вставка в конец");
                                                Console.Write("Введите число, которое вставить: ");
                                                int num = int.Parse(Console.ReadLine()!);
                                                list.InsertEnd(num);
                                                Console.WriteLine("Список: " + list);
                                                Console.WriteLine("Размерность списка: " + list.Length);
                                                break;
                                            }
                                        case "5":
                                            {
                                                Console.WriteLine("Удаление с конца");
                                                list.DeleteEnd();
                                                Console.WriteLine("Список: " + list);
                                                Console.WriteLine("Размерность списка: " + list.Length);
                                                break;
                                            }
                                        case "6":
                                            {
                                                Console.WriteLine("Вставка по индексу");
                                                Console.Write("Введите индекс: ");
                                                var index = int.Parse(Console.ReadLine()!);

                                                Console.WriteLine("Найден элемент с индексом " + index + ": " + list[index]);

                                                Console.Write("Введите значение (целое число): ");
                                                var value = int.Parse(Console.ReadLine()!);
                                                list.InsertByIndex(index, value);

                                                Console.WriteLine("Вставка произошла успешно, новый список: " + list);
                                                break;
                                            }
                                        case "7":
                                            {
                                                Console.WriteLine("Удаление по индексу");
                                                Console.Write("Введите индекс: ");
                                                var index = int.Parse(Console.ReadLine()!);
                                                list.DeleteByIndex(index);
                                                Console.WriteLine("Удаление произошла успешно, новый список: " + list);
                                                break;
                                            }
                                        case "8":
                                            {
                                                Console.WriteLine("Модуль списка");
                                                Console.WriteLine("Модуль списка: " + list.GetNorm());
                                                break;
                                            }
                                        case "9":
                                            {
                                                Console.WriteLine("Получение элемента по индексу");
                                                Console.Write("Введите индекс элемента, который хотите получить: ");
                                                int index = int.Parse(Console.ReadLine()!);
                                                Console.WriteLine("Элемент с индексом " + index + ": " + list[index]);
                                                break;
                                            }
                                        case "10":
                                            {
                                                Console.WriteLine("Изменение элемента по индексу");
                                                Console.WriteLine("Введите индекс элемента, который хотите изменить");
                                                var index = int.Parse(Console.ReadLine()!);

                                                Console.WriteLine("Найден элемент с индексом " + index + ": " + list[index]);

                                                Console.WriteLine("Введите значение (целое число), на которое хотите изменить");
                                                var value = int.Parse(Console.ReadLine()!);

                                                list[index] = value;

                                                Console.WriteLine("Значение изменено, теперь список выглядит так: " + list);
                                                break;
                                            }
                                        default:
                                            {
                                                Console.WriteLine("\nПовторите ввод\n");
                                                break;
                                            }
                                    }
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    Console.WriteLine("Ошибка: индекс вышел за переделы");
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Ошибка: " + e.Message);
                                }
                            }
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Введите координаты вектора класса ArrayVector через пробел");
                            string[] temp1 = Console.ReadLine().Split(" ");
                            ArrayVector vector1 = new ArrayVector(temp1.Length);

                            for (int i = 0; i < temp1.Length; i++)
                            {
                                vector1[i + 1] = int.Parse(temp1[i]);
                            }

                            Console.WriteLine("Введите координаты вектора класса LinkedListVector через пробел");
                            string[] temp2 = Console.ReadLine().Split(" ");
                            LinkedListVector vector2 = new LinkedListVector(temp2.Length);

                            for (int i = 0; i < temp2.Length; i++)
                            {
                                vector2[i + 1] = int.Parse(temp2[i]);
                            }

                            try
                            {
                                IVectorable sum = Vectors.Sum(vector1, vector2);
                                double scalar = Vectors.Scalar(vector1, vector2);
                                Console.WriteLine("Сумма векторов: " + sum);
                                Console.WriteLine("Скалярное произведение: " + scalar);

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        }
                    case "4":
                        {
                            IVectorable vector1 = new ArrayVector(3);
                            vector1[1] = 10;
                            vector1[2] = 20;
                            vector1[3] = 30;

                            IVectorable vector2 = new ArrayVector(4);
                            vector2[1] = 1;
                            vector2[2] = 2;
                            vector2[3] = 3;
                            vector2[4] = 40;

                            IVectorable vector3 = new LinkedListVector(2);
                            vector3[1] = 100;
                            vector3[2] = 200;

                            IVectorable vector4 = new LinkedListVector(7);
                            vector4[1] = 1;
                            vector4[2] = 2;
                            vector4[3] = 3;
                            vector4[4] = 4;
                            vector4[5] = 5;
                            vector4[6] = 6;
                            vector4[7] = 7;

                            IVectorable vector5 = new ArrayVector(6);
                            vector5[1] = 2;
                            vector5[2] = 4;
                            vector5[3] = 6;
                            vector5[4] = 8;
                            vector5[5] = 10;
                            vector5[6] = 12;

                            IVectorable vector6 = new LinkedListVector(2);
                            vector6[1] = 1;
                            vector6[2] = 3;

                            IVectorable vector7 = new LinkedListVector(7);
                            vector7[1] = 1;
                            vector7[2] = 3;
                            vector7[3] = 5;
                            vector7[4] = 7;
                            vector7[5] = 9;
                            vector7[6] = 11;
                            vector7[7] = 13;

                            IVectorable[] vectors = new IVectorable[]
                            {
                                vector1,
                                vector2,
                                vector3,
                                vector4,
                                vector5,
                                vector6,
                                vector7
                            };

                            IVectorable minCoordinatesVector = vectors[0];

                            for (int i = 0; i < vectors.Length; i++)
                            {
                                if (vectors[i].CompareTo(minCoordinatesVector) < 0)
                                {
                                    minCoordinatesVector = vectors[i];
                                }
                            }

                            List<IVectorable> minCoordinates = new List<IVectorable>();

                            for (int i = 0; i < vectors.Length; i++)
                            {
                                if (vectors[i].Length == minCoordinatesVector.Length)
                                {
                                    minCoordinates.Add(vectors[i]);
                                }
                            }

                            Console.WriteLine("Вектора с минимальным числом координат: ");
                            for (int i = 0; i < minCoordinates.Count; i++)
                            {
                                Console.WriteLine(i + 1 + ") " + minCoordinates[i]);
                            }


                            IVectorable maxCoordinatesVector = vectors[0];

                            for (int i = 0; i < vectors.Length; i++)
                            {
                                if (vectors[i].CompareTo(maxCoordinatesVector) > 0)
                                {
                                    maxCoordinatesVector = vectors[i];
                                }
                            }

                            List<IVectorable> maxCoordinates = new List<IVectorable>();

                            for (int i = 0; i < vectors.Length; i++)
                            {

                                if (vectors[i].Length == maxCoordinatesVector.Length)
                                {
                                    maxCoordinates.Add(vectors[i]);
                                }
                            }

                            Console.WriteLine("Вектора с максимальным числом координат: ");
                            for (int i = 0; i < maxCoordinates.Count; i++)
                            {
                                Console.WriteLine(i + 1 + ") " + maxCoordinates[i]);
                            }
                            Array.Sort(vectors, new VectorAscComparer());

                            Console.WriteLine("Отсортированный по возрастанию модуля массив векторов: ");
                            for (int i = 0; i < vectors.Length; i++)
                            {
                                Console.WriteLine("Вектор: " + vectors[i] + "; Модуль: " + vectors[i].GetNorm());
                            }
                            Console.WriteLine();
                            break;
                        }
                    case "5":
                        {
                            ArrayVector vector = new ArrayVector(3);
                            vector[1] = 1;
                            vector[2] = 2;
                            vector[3] = 3;

                            IVectorable clone = vector.Clone() as IVectorable;

                            Console.WriteLine("Вектор: " + vector + "; " + "клон: " + clone);
                            Console.WriteLine("Сравнение оригинала и клона с помощью == выдает: " + (vector == clone));
                            Console.WriteLine("Сравнение оригинала и клона с помощью Equals(): " + vector.Equals(clone));

                            clone[1] = -1;
                            Console.WriteLine("Вектор: " + vector + "; " + "клон: " + clone);
                            Console.WriteLine("Сравнение оригинала и измененного клона с помощью == выдает: " + (vector == clone));
                            Console.WriteLine("Сравнение оригинала и измененного клона с помощью Equals(): " + vector.Equals(clone));
                            break;
                        }
                    case "6":
                        {
                            Console.WriteLine("\nВы завершили работу программы\n");
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("\nПовторите ввод\n");
                            break;
                        }
                }
                Console.WriteLine("\n\nНажмите на любую клавишу, чтобы продолжить\n");
                Console.ReadKey();
            }
        }

        private static class Utility
        {
            public static void FillVectorRandomValues(IVectorable vector)
            {
                Random random = new Random();

                for (int i = 0; i < vector.Length; i++)
                {
                    vector[i + 1] = random.Next(-1000, 1001);
                }
            }

            public static IVectorable[] GetRadnomVectors()
            {
                IVectorable vector1 = new ArrayVector(3);
                FillVectorRandomValues(vector1);
                IVectorable vector2 = new ArrayVector(4);
                FillVectorRandomValues(vector2);
                IVectorable vector3 = new LinkedListVector(2);
                FillVectorRandomValues(vector3);
                IVectorable vector4 = new LinkedListVector(7);
                FillVectorRandomValues(vector4);
                IVectorable vector5 = new ArrayVector(6);
                FillVectorRandomValues(vector5);
                IVectorable vector6 = new LinkedListVector(2);
                FillVectorRandomValues(vector6);
                IVectorable vector7 = new LinkedListVector(7);
                FillVectorRandomValues(vector7);
                return new IVectorable[]
                {
                    vector1,
                    vector2,
                    vector3,
                    vector4,
                    vector5,
                    vector6,
                    vector7
                };
            }

            public static IVectorable[] GetVectorsArray()
            {
                IVectorable vector1 = new ArrayVector(3);
                vector1[1] = -1000;
                vector1[2] = 2000;
                vector1[3] = 3000;

                IVectorable vector2 = new ArrayVector(4);
                vector2[1] = 1;
                vector2[2] = 2;
                vector2[3] = 3;
                vector2[4] = 40;

                IVectorable vector3 = new LinkedListVector(2);
                vector3[1] = 100;
                vector3[2] = 200;

                IVectorable vector4 = new LinkedListVector(7);
                vector4[1] = 1;
                vector4[2] = 2;
                vector4[3] = 3;
                vector4[4] = 4;
                vector4[5] = 5;
                vector4[6] = 6;
                vector4[7] = 7;

                IVectorable vector5 = new ArrayVector(6);
                vector5[1] = 2;
                vector5[2] = 4;
                vector5[3] = 6;
                vector5[4] = 8;
                vector5[5] = 10;
                vector5[6] = 12;

                IVectorable vector6 = new LinkedListVector(2);
                vector6[1] = 1;
                vector6[2] = 3;

                IVectorable vector7 = new LinkedListVector(7);
                vector7[1] = 1;
                vector7[2] = 3;
                vector7[3] = 5;
                vector7[4] = 7;
                vector7[5] = 9;
                vector7[6] = 11;
                vector7[7] = 13;

                return new IVectorable[]
                {
                    vector1,
                    vector2,
                    vector3,
                    vector4,
                    vector5,
                    vector6,
                    vector7
                };
            }

            public static LinkedListVector GetRandomLLV()
            {
                LinkedListVector vector = new LinkedListVector(7);
                FillVectorRandomValues(vector);
                return vector;
            }

            public static ArrayVector GetRandomAV()
            {
                ArrayVector vector = new ArrayVector(5);
                FillVectorRandomValues(vector);
                return vector;
            }

            public static void TestVectorsEquality(IVectorable[] vectors, IVectorable[] newVectors)
            {
                for (int i = 0; i < vectors.Length; i++)
                {
                    if (vectors[i].Equals(newVectors[i]))
                    {
                        Console.WriteLine(i + ") (+) " + "Вектор { " + newVectors[i] + " } прошел проверку методом Equals после чтения из файла");
                    }
                    else
                    {
                        Console.WriteLine(i + ") (-) " + "Вектор { " + newVectors[i] + " } не прошел проверку методом Equals после чтения из файла");
                    }
                }
            }
        }
    }
}