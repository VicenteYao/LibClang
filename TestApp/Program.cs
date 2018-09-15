using LibClang;
using System;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Index index = new Index(true, true);
            string sourceFileName = null;
            var indexAction = index.CreateIndexAction(new IndexActionEventHandler());
            var tu = index.CreateTranslationUnit(@"d:\clang.ast");

            indexAction.Index(tu, LibClang.Intertop.CXIndexOptFlags.CXIndexOpt_IndexFunctionLocalSymbols);
            Console.ReadLine();
        }
    }
}
