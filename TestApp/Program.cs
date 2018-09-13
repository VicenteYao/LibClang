using LibClang;
using System;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Index index = new Index(true, true);
            index.GlobalOptFlags = LibClang.Intertop.CXGlobalOptFlags.CXGlobalOpt_ThreadBackgroundPriorityForAll;
            LibClang.TranslationUnit translationUnit = index.CreateTranslationUnit(@"D:\llvm\tools\clang\tools\driver\driver.cpp", null, null);

            var indexAction = index.CreateIndexAction(new IndexActionEventHandler());
            indexAction.Index(translationUnit, LibClang.Intertop.CXIndexOptFlags.CXIndexOpt_IndexFunctionLocalSymbols);
            Console.ReadLine();
        }
    }
}
