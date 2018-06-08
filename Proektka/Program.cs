using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proektka
{
    class Program
    {
        static double[][] mass = new double[N][];
        public static int N, M;
        static void ReadFromFile(string path)
        {
            FileStream File = new FileStream(path, FileMode.Open); //создание нового файла
            StreamReader reader = new StreamReader(File);
            N = Convert.ToInt32(reader.ReadLine());
            M = Convert.ToInt32(reader.ReadLine());
            Array.Resize<double[]>(ref mass, M);
            for (int i = 0; i < M; i++)
            {
                Array.Resize(ref mass[i], N);
            }
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    mass[i][j] = Convert.ToDouble(reader.ReadLine());
                }
            }
            reader.Close();
        }
        public static void Randomgen(int A, int B)
        {
            Random rand1 = new Random();
            Array.Resize<double[]>(ref mass, M);
            for (int i = 0; i < M; i++)
            {
                Array.Resize(ref mass[i], N);
            }
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    mass[i][j] = rand1.NextDouble() * (B-A) - A;
                }
            }
        }
        static void WriteToFile(string path)
        {
            FileStream File = new FileStream(path, FileMode.CreateNew); //создание нового файла
            StreamWriter writer = new StreamWriter(File);
            writer.WriteLine(N);
            writer.WriteLine(M);
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    writer.WriteLine(mass[i][j]);
                }
            }
            writer.Close();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите способ задания входных данных\n1 - Случайная генерация, 2 - чтение из файла, 3 - случ. ген. и запись в файл");
            int a = Convert.ToInt32(Console.ReadLine());
            switch (a)
            {
                case 1:
                    Console.WriteLine("Введите четыре переменных (кажд. в отд. строку):\nКоличество элементов в диск. процессе, верхняя, нижняя границы значений, количество повторений процесса");
                    int CA, B;
                    N = Convert.ToInt32(Console.ReadLine());
                    M = Convert.ToInt32(Console.ReadLine());
                    CA = Convert.ToInt32(Console.ReadLine());
                    B = Convert.ToInt32(Console.ReadLine());
                    Randomgen(CA, B);
                    for (int i = 0; i < M; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            Console.Write(mass[i][j]);
                        }
                        Console.WriteLine();
                    }
                    break;
                case 2:
                    Console.WriteLine("Введите путь к файлу ебать мой лысый хуй");
                    string path = Console.ReadLine();
                    ReadFromFile(path);
                    Console.WriteLine("{0}, {0}", N, M);
                    for (int i = 0; i < M; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            Console.Write(mass[i][j]);
                        }
                        Console.WriteLine();
                    }
                    break;
                case 3:
                    //string path;
                    Console.WriteLine("Введите четыре переменных (кажд. в отд. строку):\nКоличество элементов в диск. процессе, верхняя, нижняя границы значений, количество повторений процесса");
                    N = Convert.ToInt32(Console.ReadLine());
                    M = Convert.ToInt32(Console.ReadLine());
                    CA = Convert.ToInt32(Console.ReadLine());
                    B = Convert.ToInt32(Console.ReadLine());
                    Randomgen(CA, B);
                    for (int i = 0; i < M; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            Console.Write(mass[i][j]);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("Введите путь к файлу ебать мой лысый хуй");
                    path = Console.ReadLine();
                    WriteToFile(path);
                    break;
            }
            Console.ReadLine();
        }
    }
}
