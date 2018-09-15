﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibClang;
using System;

namespace LibClangUnitTest
{
    [TestClass]
    public class IndexUnit
    {
        [TestMethod]
        public void TestMethod1()
        {
            Index index = new Index(true, true);
            string sourceFileName = null;
            var indexAction = index.CreateIndexAction(new IndexActionEventHandler());
            string includes = @"-ID:\llvm\build\tools\clang\tools\driver -ID:\llvm\tools\clang\tools\driver -ID:\llvm\tools\clang\include -ID:\llvm\build\tools\clang\include -ID:\llvm\build\include -ID:\llvm\include";
            var splitedStringArrays = includes.Split(' ');
            var tu = index.Parse(@"D:\llvm\tools\clang\tools\driver\driver.cpp",
               LibClang.Intertop.CXGlobalOptFlags.CXGlobalOpt_None, splitedStringArrays, null);
            indexAction.Index(tu, LibClang.Intertop.CXIndexOptFlags.CXIndexOpt_IndexFunctionLocalSymbols);
        }
    }
}