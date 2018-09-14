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
            string[] cmdArgs = new string[0];
            LibClang.TranslationUnit translationUnit = index.Parse("")

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
