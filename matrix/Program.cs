using System;
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

namespace matrix
{
    class Program
    {
        public static int m, n;
        public static char[,] arr;
        public static int first, second, fourth;
        public static char third;
        //
        public static List<string> output;

        //-------------------------------------------------------------
        public static void testData()
        {
            Console.WriteLine("Тестовые данные: ");

            m = 4;
            Console.WriteLine("M = " + m);
            n = 5;
            Console.WriteLine("N = "+n);

            arr = new char[m, n];

            arr[0, 0] = 'b';
            arr[0, 1] = '=';
            arr[0, 2] = '=';
            arr[0, 3] = '=';
            arr[0, 4] = 'b';

            arr[1,0] = '1';
            arr[1,1] = 'b';
            arr[1,2] = '2';
            arr[1,3] = 'b';
            arr[1,4] = 'a';

            arr[2,0] = 'c';
            arr[2,1] = '4';
            arr[2,2] = 'b';
            arr[2,3] = 'a';
            arr[2,4] = '+';

            arr[3, 0] = '5';
            arr[3, 1] = 'c';
            arr[3, 2] = 'a';
            arr[3, 3] = 'b';
            arr[3, 4] = '+';

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("");
            Console.WriteLine("- [1 2] = 3");
            Console.WriteLine("| [3 5] + 2");
            Console.WriteLine("\\ [1 1] b 4");
            Console.WriteLine("\\ [3 1] c 2");
            Console.WriteLine("/ [2 5] a 3");
            Console.WriteLine("/ [1 5] b 3");
        }
        //-------------------------------------------------------------

        public static void testFFFF()
        {
            Console.WriteLine("Тестовые данные: ");

            m = 4;
            Console.WriteLine("M = " + m);
            n = 5;
            Console.WriteLine("N = " + n);

            arr = new char[m, n];

            arr[0, 0] = 'f';
            arr[0, 1] = 'f';
            arr[0, 2] = 'f';
            arr[0, 3] = 'f';
            arr[0, 4] = 'f';

            arr[1, 0] = 'f';
            arr[1, 1] = 'f';
            arr[1, 2] = 'f';
            arr[1, 3] = 'f';
            arr[1, 4] = 'f';

            arr[2, 0] = 'f';
            arr[2, 1] = 'f';
            arr[2, 2] = 'f';
            arr[2, 3] = 'f';
            arr[2, 4] = 'f';

            arr[3, 0] = 'f';
            arr[3, 1] = 'f';
            arr[3, 2] = 'f';
            arr[3, 3] = 'f';
            arr[3, 4] = 'f';

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }

        }

            //-------------------------------------------------------------
            public static void writeKeyboard()
        {
            Console.WriteLine("Введите размеры матрицы: ");
            Console.Write("M = ");
            m = int.Parse(Console.ReadLine());
            Console.Write("N = ");
            n = int.Parse(Console.ReadLine());

            arr = new char[m, n];

            Console.WriteLine("Вводите символы: ");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = Console.ReadKey().KeyChar;
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        ///////////////////////////////////////////////////////////////
        public static void findCondition(int i, int j, char symbol)
        {
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
                    printLimit(symbol);
                }
                first = i + 1;
                second = j + 1;
                third = arr[i, j];
                fourth = 1;
            }
        }
        //-------------------------------------------------------------
        public static void printLimit(char symbol)
        {
            string dash = string.Format("{0} [{1} {2}] {3} {4}", symbol, first, second, third, fourth);
            Console.WriteLine(dash);
        }

        // TODO после тестирования удалить
        //-------------------------------------------------------------
        public static void printDobLimit(char symbol)
        {
            string dash = string.Format("{0}{1} [{2} {3}] {4} {5}", symbol, symbol, first, second, third, fourth);
            Console.WriteLine(dash);
        }
        //-------------------------------------------------------------
        public static void horisontalFind(char symbol)
        {
            for (int i = 0; i < m; i++)
            {
                first = default(int);
                second = default(int);
                third = new char();
                fourth = 0;

                for (int j = 0; j < n; j++)
                {
                    findCondition(i, j, symbol);
                    if (fourth > 1 && j + 1 == n)
                    {
                        printDobLimit(symbol);
                    }
                }
            }
        }
        //-------------------------------------------------------------
        public static void verticalFind(char symbol)
        {
            for (int j = 0; j < n; j++)
            {
                first = default(int);
                second = default(int);
                third = new char();
                fourth = 0;

                for (int i = 0; i < m; i++)
                {
                    findCondition(i, j, symbol);
                    if (fourth > 1 && i + 1 == m)
                    {
                        printDobLimit(symbol);
                    }
                }
            }
        }
        //-------------------------------------------------------------
        public static void backslash(char symbol) {
            //var 2
            string diagonal = "";
            for (int k = m; k >= -m; k--)
            {
                first = default(int);
                second = default(int);
                third = new char();
                fourth = 0;
                for (int j = 0; j < n - k; j++)
                {
                    int i = k + j;
                    Console.WriteLine("arr[" + j + " ," + i + "]");

                    if (i < n && j < m && i >= 0 && j >= 0)
                    {
                        diagonal += arr[j, i] + " ";
                        findCondition(j, i, symbol);
                    }
                    else
                    {
                        if (fourth > 1)
                        {
                            printDobLimit(symbol);
                            break;
                        }
                    }
                }
                Console.WriteLine(diagonal);
                diagonal = "";
            }
        }
        //-------------------------------------------------------------
        public static void slash(char symbol) {
            //var 1
            //string diagonal = "";
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
                        findCondition(j, i, symbol);
                    }
                    else
                    {
                        if (fourth > 1)
                        {
                            printDobLimit(symbol);
                            break;
                        }
                    }
                }
                //Console.WriteLine(diagonal);
                //diagonal = "";
            }
        }
        //-------------------------------------------------------------
        static void Main(string[] args)
        {
            // если нужно работать с реальными данными закомментировать
            //testData();
            testFFFF();

            // TODO протестировать на всех одинаковых символах
            // TODO протестировать на кирилице 
            // TODO добавить проверки на соответствие типов данных

            // если нужно работать с реальными данными раскомментировать
            //writeKeyboard();

            Console.WriteLine("");     
            Console.WriteLine("Наши результаты: ");

            //horisontalFind('-');
            //verticalFind('|');
            backslash('\\');
            //slash('/');

            Console.ReadKey();
        }
    }
}
