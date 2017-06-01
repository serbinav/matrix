using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Matrix.Tests
{
    [TestClass]
    public class ConsoleAppTests
    {
        int m = 4;
        int n = 5;

        char[,] exampl = new char[4, 5]{
            { 'b', '=', '=', '=', 'b' },
            { '1', 'b', '2', 'b', 'a' },
            { 'c', '4', 'b', 'a', '+' },
            { '5', 'c', 'a', 'b', '+' }
        };

        char[,] myYes = new char[4, 5]{
            { 'f', 'f', 'f', 'f', 'f' },
            { 'f', 'f', 'f', 'f', 'f' },
            { 'f', 'f', 'f', 'f', 'f' },
            { 'f', 'f', 'f', 'f', 'f' }
        };

        char[,] myNo = new char[4, 5]{
            { 'a', 'b', 'c', 'd', 'e' },
            { 'f', 'g', 'h', 'i', 'j' },
            { 'k', 'l', 'm', 'n', 'o' },
            { 'p', 'q', 'r', 's', 't' }
        };

        //-------------------------------------------------------------

        [TestMethod]
        public void horisontalFindPositive1()
        {
            ConsoleApp con = new Matrix.ConsoleApp();

            List<string> test = new List<string>() { "- [1 2] = 3" };
            List<string> prog = con.horisontalFind(m, n, exampl, '-');

            CollectionAssert.AreEqual(con.horisontalFind(m, n, exampl, '-'), test);
        }

        [TestMethod]
        public void verticalFindPositive1()
        {
            ConsoleApp con = new Matrix.ConsoleApp();

            List<string> test = new List<string>() { "|| [3 5] + 2" };
            List<string> prog = con.verticalFind(m, n, exampl, '|');

            CollectionAssert.AreEqual(con.verticalFind(m, n, exampl, '|'), test);
        }

        [TestMethod]
        public void backslashFindPositive1()
        {
            ConsoleApp con = new Matrix.ConsoleApp();
            List<string> test = new List<string>() { "\\ [1 1] b 4", "\\ [3 1] c 2" };
            List<string> prog = con.backslash(m, n, exampl, '\\');

            CollectionAssert.AreEqual(con.backslash(m, n, exampl, '\\'), test);
        }

        [TestMethod]
        public void slashFindPositive1()
        {
            ConsoleApp con = new Matrix.ConsoleApp();
            List<string> test = new List<string>() { "/ [1 5] b 3", "/ [2 5] a 3" };
            List<string> prog = con.slash(m, n, exampl, '/');

            CollectionAssert.AreEqual(con.slash(m, n, exampl, '/'), test);
        }

        //-------------------------------------------------------------

        [TestMethod]
        public void horisontalFindPositive2()
        {
            ConsoleApp con = new Matrix.ConsoleApp();

            List<string> test = new List<string>() { "-- [1 1] f 5", "-- [2 1] f 5",
                "-- [3 1] f 5", "-- [4 1] f 5" };
            List<string> prog = con.horisontalFind(m, n, myYes, '-');

            CollectionAssert.AreEqual(con.horisontalFind(m, n, myYes, '-'), test);
        }

        [TestMethod]
        public void verticalFindPositive2()
        {
            ConsoleApp con = new Matrix.ConsoleApp();
            List<string> test = new List<string>() { "|| [1 1] f 4" ,"|| [1 2] f 4",
            "|| [1 3] f 4", "|| [1 4] f 4", "|| [1 5] f 4"};
            List<string> prog = con.verticalFind(m, n, myYes, '|');

            CollectionAssert.AreEqual(con.verticalFind(m, n, myYes, '|'), test);
        }

        [TestMethod]
        public void backslashFindPositive2()
        {
            ConsoleApp con = new Matrix.ConsoleApp();
            List<string> test = new List<string>() { "\\\\ [1 1] b 4", "\\\\ [3 1] c 2",
            "\\\\ [3 1] c 2", "\\\\ [3 1] c 2", "\\\\ [3 1] c 2", "\\\\ [3 1] c 2"};
            List<string> prog = con.backslash(m, n, myYes, '\\');

            CollectionAssert.AreEqual(con.backslash(m, n, myYes, '\\'), test);
        }

        [TestMethod]
        public void slashFindPositive2()
        {
            ConsoleApp con = new Matrix.ConsoleApp();
            List<string> test = new List<string>() { "// [1 5] b 3", "/ [2 5] a 3",
            "/ [3 1] c 2","// [3 1] c 2","// [3 1] c 2","// [3 1] c 2",};
            List<string> prog = con.slash(m, n, myYes, '/');

            CollectionAssert.AreEqual(con.slash(m, n, myYes, '/'), test);
        }

        //-------------------------------------------------------------

        [TestMethod]
        public void horisontalFindNegative1()
        {
            ConsoleApp con = new Matrix.ConsoleApp();

            List<string> test = new List<string>();
            List<string> prog = con.horisontalFind(m, n, myNo, '-');

            CollectionAssert.AreEqual(con.horisontalFind(m, n, myNo, '-'), test);
        }

        [TestMethod]
        public void verticalFindNegative1()
        {
            ConsoleApp con = new Matrix.ConsoleApp();

            List<string> test = new List<string>();
            List<string> prog = con.verticalFind(m, n, myNo, '|');

            CollectionAssert.AreEqual(con.verticalFind(m, n, myNo, '|'), test);
        }

        [TestMethod]
        public void backslashFindNegative1()
        {
            ConsoleApp con = new Matrix.ConsoleApp();
            List<string> test = new List<string>();
            List<string> prog = con.backslash(m, n, myNo, '\\');

            CollectionAssert.AreEqual(con.backslash(m, n, myNo, '\\'), test);
        }

        [TestMethod]
        public void slashFindNegative1()
        {
            ConsoleApp con = new Matrix.ConsoleApp();
            List<string> test = new List<string>();
            List<string> prog = con.slash(m, n, myNo, '/');

            CollectionAssert.AreEqual(con.slash(m, n, myNo, '/'), test);
        }
    }
}

