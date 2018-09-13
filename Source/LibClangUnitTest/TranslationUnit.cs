using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibClang;
using System;

namespace LibClangUnitTest
{
    [TestClass]
    public class TranslationUnit
    {
        [TestMethod]
        public void TestMethod1()
        {
            Index index = new Index(false, true);
            LibClang.TranslationUnit translationUnit=   index.CreateTranslationUnit(@"D:\llvm\tools\clang\tools\driver\driver.cpp", null, null);

            var indexAction = index.CreateIndexAction(new IndexActionEventHandler());
            indexAction.Index(translationUnit, LibClang.Intertop.CXIndexOptFlags.CXIndexOpt_IndexFunctionLocalSymbols);
            Console.ReadLine();
        }
    }
}
