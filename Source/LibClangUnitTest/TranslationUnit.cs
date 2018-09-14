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
            LibClang.TranslationUnit translationUnit = index.CreateTranslationUnit(@"D:\clang.ast");
            foreach (var diagnostic in translationUnit.Diagnostics)
            {
                foreach (var item in diagnostic.ChildDiagnostics)
                {
                    Console.WriteLine(item.Category.ToString(), item.CategoryText, item.Spelling, item.SourceLocation);
                    foreach (var sourceRange in item.SourceRanges)
                    {
                        Console.WriteLine(sourceRange);
                    }
                }
            }

            var indexAction = index.CreateIndexAction(new IndexActionEventHandler());
            indexAction.Index(translationUnit, LibClang.Intertop.CXIndexOptFlags.CXIndexOpt_IndexFunctionLocalSymbols);
            Console.ReadLine();
        }
    }
}
