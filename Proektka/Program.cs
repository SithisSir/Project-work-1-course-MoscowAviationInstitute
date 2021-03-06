﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proektka
{
    class Program
    {
        public static double[][] mass = new double[N][];
        public static int N, M;
        public static double mathexpectation1, mathexpectation2, correlfunction;
        static void ReadFromFile(string path)
        {
            FileStream File = new FileStream(path, FileMode.Open); //открытие файла на чтение
            StreamReader reader = new StreamReader(File);
            N = Int32.Parse(reader.ReadLine());
            M = Int32.Parse(reader.ReadLine());
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
                    mass[i][j] = rand1.NextDouble() * (B-A) + A;
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
        static double mathexpectation(int number)
        {
            double mathexpect = 0;
            for (int i = 0; i<N; i++)
            {
                mathexpect += mass[number][i];
            }
            mathexpect = mathexpect / M;
            return mathexpect;
        }
        static double correlationfuntion(int number1, int number2)
        {
            double cor = 0;
            for (int i = 0; i < N; i++)
            {
                cor += (mass[number1][i] - mathexpectation1) * (mass[number2][i] - mathexpectation2);
            }
            cor = cor / (M-1);
            return cor;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите способ задания входных данных\n1 - Случайная генерация, 2 - чтение из файла, 3 - случ. ген. и запись в файл");
            int a = Convert.ToInt32(Console.ReadLine());
            switch (a)
            {
                case 1:
                    Console.WriteLine("Введите четыре переменных (кажд. в отд. строку):\nКоличество элементов в диск. процессе, количество повторений процесса, нижняя, верхняя границы значений");
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
                            Console.Write("{0}\t", mass[i][j]);
                        }
                        Console.WriteLine();
                    }
                    break;
                case 2:
                    Console.WriteLine("Введите путь к файлу для чтения");
                    string path = Console.ReadLine();
                    ReadFromFile(path);
                    Console.WriteLine("{0}, {1}", N, M);
                    for (int i = 0; i < M; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            Console.Write("{0} ", mass[i][j]);
                        }
                        Console.WriteLine();
                    }
                    break;
                case 3:
                    Console.WriteLine("Введите четыре переменных (кажд. в отд. строку):\nКоличество элементов в диск. процессе, количество повторений процесса, нижняя, верхняя границы значений");
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
                    Console.WriteLine("Введите путь к файлу для сохранения");
                    path = Console.ReadLine();
                    WriteToFile(path);
                    break;
            }
            Console.WriteLine("Массив сгенерирован. Введите номера элементов, для которых считать корелляционную функцию");
            int n1, n2;
            n1 = Convert.ToInt32(Console.ReadLine());
            n2 = Convert.ToInt32(Console.ReadLine());
            mathexpectation1 = mathexpectation(n1);
            mathexpectation2 = mathexpectation(n2);
            correlfunction= correlationfuntion(n1, n2);
            Console.WriteLine("{0}, {1}", mathexpectation1, mathexpectation2);
            Console.WriteLine(correlfunction);
            Console.ReadLine();
        }
    }
}
