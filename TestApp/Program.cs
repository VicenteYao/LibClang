using LibClang;
using System;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Index index = new Index(true, true);
            LibClang.TranslationUnit translationUnit = index.CreateTranslationUnit(@"D:\clang.ast");

            var indexAction = index.CreateIndexAction(new IndexActionEventHandler());


            foreach (var item in translationUnit.ResourceUsages)
            {
                Console.WriteLine("{0}:{1}", item.Name,item.Amount);
            }

            indexAction.Index(translationUnit, LibClang.Intertop.CXIndexOptFlags.CXIndexOpt_IndexFunctionLocalSymbols);
            Console.ReadLine();
        }
    }
}
