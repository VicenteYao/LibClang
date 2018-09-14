using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using LibClang;

namespace TestApp
{
    public class IndexActionEventHandler : IIndexActionEventHandler
    {
        public void OnDiagnostic(DiagnosticSet diagnostics)
        {
            foreach (var item in diagnostics)
            {
                Console.WriteLine(item.Spelling);
            }

        }

        public File OnEnteredMainFile(File file)
        {
            return file;
        }

        public File OnIncludeFile(IndexIncludedFileInfo indexIncludedFileInfo)
        {
            return indexIncludedFileInfo.File;
        }

        public void OnIndexDeclaration(IndexDeclInfo indexDeclInfo)
        {
            Console.WriteLine(indexDeclInfo.IndexLocation);
            Console.WriteLine(indexDeclInfo.EntityInfo);
            Console.WriteLine(indexDeclInfo.Flags);
        }

        public void OnIndexEntityRefInfo(IndexEntityRefInfo indexEntityRefInfo)
        {
            Console.WriteLine(indexEntityRefInfo.IndexLocation);
            Console.WriteLine(indexEntityRefInfo.EntityRefKind);
            Console.WriteLine(indexEntityRefInfo.ReferencedEntity);
        }

        public bool OnQueryAbort()
        {
            return false;
        }

        public void OnStartTranslationUnit()
        {

        }
    }
}
