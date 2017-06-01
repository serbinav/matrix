﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Напишите консольную программу на языке C#, на вход которой подаётся матрица размером M*N.
M - количество строк, N - количество столбцов.
Числа M, N и строки матрицы вводятся с клавиатуры.
Строка матрицы - N символов (char), разделённые пробелами. Ввод каждой из M строк матрицы завершается нажатием Enter.
M, N - целые положительные числа.

Программа должна найти и вывести все последовательности из 2 и более одинаковых символов подряд в любой вертикали, горизонтали и диагонали.
Порядок вывода последовательностей не важен.
Нумерация столбцов и строк ведётся с единицы, слева направо и сверху вниз, соответственно.

Формат вывода одной найденной последовательности:
<line type> [<start row number> <start column number>] <symbol> <sequence length>
где<line type>:
'-' для горизонтали
'|' для вертикали
'\' для диагонали
'/' для диагонали

<start row number> - номер строки самого левого верхнего элемента найденной последовательности (для диагонали - самого верхнего элемента);
<start column number> - номер столбца самого левого верхнего элемента найденной последовательности(для диагонали - самого верхнего элемента);
<symbol> - элемент матрицы, из которой состоит последовательность;
<sequence length> - длина найденной последовательности.

Пример ввода:
M=4
N=5
b = = = b
1 b 2 b a
c 4 b a +
5 c a b +

Пример вывода:
- [1 2] = 3
| [3 5] + 2
\ [1 1] b 4
\ [3 1] c 2
/ [2 5] a 3
/ [1 5] b 3
*/

namespace Matrix
{
    public class ConsoleApp
    {
        public int m, n;
        public char[,] arr;
        public static int first, second, fourth;
        public static char third;
        //public static List<string> output;

        //-------------------------------------------------------------
        public string findCondition(int i, int j, char symbol, char[,] arr)
        {
            string ret = "";
            if (fourth == 0)
            {
                first = i + 1;
                second = j + 1;


                third = arr[i, j];
                fourth = 1;
            }
            else if (third == arr[i, j])
            {
                fourth = fourth + 1;
            }
            else if (third != arr[i, j])
            {
                if (fourth > 1)
                {
                    ret = printLimit(symbol);
                }
                first = i + 1;
                second = j + 1;
                third = arr[i, j];
                fourth = 1;
            }
            return ret;
        }
        //-------------------------------------------------------------
        public string printLimit(char symbol)
        {
            string str = string.Format("{0} [{1} {2}] {3} {4}", symbol, first, second, third, fourth);
            return str;
        }

        // TODO после тестирования удалить
        //-------------------------------------------------------------
        public string printDobLimit(char symbol)
        {
            string str =  string.Format("{0}{1} [{2} {3}] {4} {5}", symbol, symbol, first, second, third, fourth);
            return str;
        }
        //-------------------------------------------------------------
        public List<string> horisontalFind(int m, int n, char[,] arr, char symbol)
        {
            List<string> ret = new List<string>();
            for (int i = 0; i < m; i++)
            {
                first = default(int);
                second = default(int);
                third = new char();
                fourth = 0;

                for (int j = 0; j < n; j++)
                {
                    string find = findCondition(i, j, symbol, arr);
                    if (find != "")
                        ret.Add(find);

                    if (fourth > 1 && j + 1 == n)
                    {
                        ret.Add(printDobLimit(symbol));
                    }
                }
            }
            return ret;
        }
        //-------------------------------------------------------------
        public List<string> verticalFind(int m, int n, char[,] arr, char symbol)
        {
            List<string> ret = new List<string>();
            for (int j = 0; j < n; j++)
            {
                first = default(int);
                second = default(int);
                third = new char();
                fourth = 0;

                for (int i = 0; i < m; i++)
                {
                    string find = findCondition(i, j, symbol, arr);
                    if (find != "")
                        ret.Add(find);

                    if (fourth > 1 && i + 1 == m)
                    {
                        ret.Add(printDobLimit(symbol));
                    }
                }
            }
            return ret;

        }
        //-------------------------------------------------------------
        public List<string> backslash(int m, int n, char[,] arr, char symbol)
        {
            //var 2
            //string diagonal = "";
            List<string> ret = new List<string>();
            for (int k = m; k >= -m; k--)
            {
                first = default(int);
                second = default(int);
                third = new char();
                fourth = 0;
                for (int j = 0; j < n - k; j++)
                {
                    int i = k + j;
                    //Console.WriteLine("arr[" + j + " ," + i + "]");

                    if (i < n && j < m && i >= 0 && j >= 0)
                    {
                        //diagonal += arr[j, i] + " ";

                        string find = findCondition(j, i, symbol, arr);
                        if (find != "")
                            ret.Add(find);

                        if (fourth > 1 && j + 1 == n - k)
                        {
                            ret.Add(printDobLimit(symbol));
                        }
                    }
                    else
                    {
                        if (fourth > 1)
                        {
                            ret.Add(printDobLimit(symbol));
                            break;
                        }
                    }
                }
                //Console.WriteLine(diagonal);
                //diagonal = "";
            }
            return ret;
        }
        //-------------------------------------------------------------
        public List<string> slash(int m, int n, char[,] arr, char symbol) {
            //var 1
            //string diagonal = "";
            List<string> ret = new List<string>();
            for (int k = 0; k < m * 2; k++)
            {
                first = default(int);
                second = default(int);
                third = new char();
                fourth = 0;

                for (int j = 0; j <= k; j++)
                {
                    int i = k - j;
                    //Console.WriteLine("arr[" + j + " ," + i + "]");
                    if (i < n && j < m)
                    {
                        //diagonal += arr[j, i] + " ";

                        string find = findCondition(j, i, symbol, arr);
                        if (find != "")
                            ret.Add(find);

                        if (fourth > 1 && j + 1 > k)
                        {
                            ret.Add(printDobLimit(symbol));
                        }
                    }
                    else
                    {
                        if (fourth > 1)
                        {
                            ret.Add(printDobLimit(symbol));
                            break;
                        }
                    }
                }
                //Console.WriteLine(diagonal);
                //diagonal = "";
            }
            return ret;
        }
        //-------------------------------------------------------------
        static void Main(string[] args)
        {
            // TODO протестировать определение начальной точки
            // TODO протестировать на кирилице 
            // TODO добавить проверки на соответствие типов данных

            ConsoleApp work = new ConsoleApp();
            /*
            Console.WriteLine("Введите размеры матрицы: ");
            Console.Write("M = ");
            work.m = int.Parse(Console.ReadLine());
            Console.Write("N = ");
            work.n = int.Parse(Console.ReadLine());

            work.arr = new char[work.m, work.n];

            Console.WriteLine("Вводите символы: ");
            for (int i = 0; i < work.m; i++)
            {
                for (int j = 0; j < work.n; j++)
                {
                    work.arr[i, j] = Console.ReadKey().KeyChar;
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            */

            work.m = 4;
            work.n = 5;

            work.arr = new char[4, 5]{
            { 'f', 'f', 'f', 'f', 'f' },
            { 'f', 'f', 'f', 'f', 'f' },
            { 'f', 'f', 'f', 'f', 'f' },
            { 'f', 'f', 'f', 'f', 'f' }
            };

            Console.WriteLine("");     
            Console.WriteLine("Наши результаты: ");

            foreach (string str in work.horisontalFind(work.m, work.n, work.arr, '-'))
            {
                Console.WriteLine(str);
            }
            foreach (string str in work.verticalFind(work.m, work.n, work.arr, '|'))
            {
                Console.WriteLine(str);
            }
            foreach (string str in work.backslash(work.m, work.n, work.arr, '\\'))
            {
                Console.WriteLine(str);
            }
            foreach (string str in work.slash(work.m, work.n, work.arr, '/'))
            {
                Console.WriteLine(str);
            }

            Console.ReadKey();
        }
    }
}
