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
            var tu= index.Parse(@"D:\llvm\tools\clang\tools\driver\cc1as_main.cpp",
               LibClang.Intertop.CXGlobalOptFlags.CXGlobalOpt_ThreadBackgroundPriorityForEditing, null, null);
            var file = tu.GetFile(@"D:\llvm\tools\clang\tools\driver\cc1as_main.cpp");
            var sourceLocation = tu.GetSourceLocation(file, 88, 6);
            var cursor = tu.GetCursor(sourceLocation);

            var tlsKind = cursor.TlsKind;
            indexAction.Index(tu, LibClang.Intertop.CXIndexOptFlags.CXIndexOpt_IndexFunctionLocalSymbols);
            Console.ReadLine();
        }
    }
}
