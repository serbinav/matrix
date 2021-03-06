﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Matrix.Tests
{
    [TestClass]
    public class ConsoleAppTests
    {
        uint m = 4;
        uint n = 5;
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

        uint i = 4;
        uint j = 4;
        char[,] myNo = new char[4, 4]{
            { 'a', 'b', 'c', 'd' },
            { 'e', 'f', 'g', 'h' },
            { 'i', 'j', 'k', 'l' },
            { 'm', 'n', 'o', 'p' }  
        };

        char[,] myYesCiril = new char[4, 4]{
            { 'х', 'о', 'ч', 'у' },
            { 'у', 'х', 'о', 'ч' },
            { 'ч', 'у', 'х', 'о' },
            { 'о', 'ч', 'у', 'х' }
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
            List<string> test = new List<string>() { "\\\\ [1 1] b 4", "\\\\ [3 1] c 2" };
            List<string> prog = con.backslash(m, n, exampl, '\\');

            CollectionAssert.AreEqual(con.backslash(m, n, exampl, '\\'), test);
        }

        [TestMethod]
        public void slashFindPositive1()
        {
            ConsoleApp con = new Matrix.ConsoleApp();
            List<string> test = new List<string>() { "/ [1 5] b 3", "// [2 5] a 3" };
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
            List<string> test = new List<string>() { "\\\\ [1 4] f 2", "\\\\ [1 3] f 3",
            "\\\\ [1 2] f 4", "\\\\ [1 1] f 4", "\\\\ [2 1] f 3", "\\\\ [3 1] f 2"};
            List<string> prog = con.backslash(m, n, myYes, '\\');

            CollectionAssert.AreEqual(con.backslash(m, n, myYes, '\\'), test);
        }

        [TestMethod]
        public void slashFindPositive2()
        {
            ConsoleApp con = new Matrix.ConsoleApp();
            List<string> test = new List<string>() { "// [1 2] f 2", "// [1 3] f 3",
            "// [1 4] f 4","// [1 5] f 4","// [2 5] f 3","// [3 5] f 2",};
            List<string> prog = con.slash(m, n, myYes, '/');

            CollectionAssert.AreEqual(con.slash(m, n, myYes, '/'), test);
        }

        //-------------------------------------------------------------

        [TestMethod]
        public void horisontalFindNegative1()
        {
            ConsoleApp con = new Matrix.ConsoleApp();

            List<string> test = new List<string>();
            List<string> prog = con.horisontalFind(i, j, myNo, '-');

            CollectionAssert.AreEqual(con.horisontalFind(i, j, myNo, '-'), test);
        }

        [TestMethod]
        public void verticalFindNegative1()
        {
            ConsoleApp con = new Matrix.ConsoleApp();

            List<string> test = new List<string>();
            List<string> prog = con.verticalFind(i, j, myNo, '|');

            CollectionAssert.AreEqual(con.verticalFind(i, j, myNo, '|'), test);
        }

        [TestMethod]
        public void backslashFindNegative1()
        {
            ConsoleApp con = new Matrix.ConsoleApp();
            List<string> test = new List<string>();
            List<string> prog = con.backslash(i, j, myNo, '\\');

            CollectionAssert.AreEqual(con.backslash(i, j, myNo, '\\'), test);
        }

        [TestMethod]
        public void slashFindNegative1()
        {
            ConsoleApp con = new Matrix.ConsoleApp();
            List<string> test = new List<string>();
            List<string> prog = con.slash(i, j, myNo, '/');

            CollectionAssert.AreEqual(con.slash(i, j, myNo, '/'), test);
        }

        //-------------------------------------------------------------

        [TestMethod]
        public void horisontalFindCirilPositive1()
        {
            ConsoleApp con = new Matrix.ConsoleApp();

            List<string> test = new List<string>();
            List<string> prog = con.horisontalFind(i, j, myYesCiril, '-');

            CollectionAssert.AreEqual(con.horisontalFind(i, j, myYesCiril, '-'), test);
        }

        [TestMethod]
        public void verticalFindCirilPositive1()
        {
            ConsoleApp con = new Matrix.ConsoleApp();

            List<string> test = new List<string>();
            List<string> prog = con.verticalFind(i, j, myYesCiril, '|');

            CollectionAssert.AreEqual(con.verticalFind(i, j, myYesCiril, '|'), test);
        }

        [TestMethod]
        public void backslashFindCirilPositive1()
        {
            ConsoleApp con = new Matrix.ConsoleApp();
            List<string> test = new List<string>() { "\\\\ [1 3] ч 2", "\\\\ [1 2] о 3",
            "\\\\ [1 1] х 4", "\\\\ [2 1] у 3", "\\\\ [3 1] ч 2"};
            List<string> prog = con.backslash(i, j, myYesCiril, '\\');

            CollectionAssert.AreEqual(con.backslash(i, j, myYesCiril, '\\'), test);
        }

        [TestMethod]
        public void slashFindCirilPositive1()
        {
            ConsoleApp con = new Matrix.ConsoleApp();
            List<string> test = new List<string>() ;
            List<string> prog = con.slash(i, j, myYesCiril, '/');

            CollectionAssert.AreEqual(con.slash(i, j, myYesCiril, '/'), test);
        }
    }
}
