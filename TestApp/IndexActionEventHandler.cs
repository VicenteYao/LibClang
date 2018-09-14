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

        private List<IndexDeclInfo> indexDeclInfos = new List<IndexDeclInfo>();

        public void OnIndexDeclaration(IndexDeclInfo indexDeclInfo)
        {

        }

        public void OnIndexEntityRefInfo(IndexEntityRefInfo indexEntityRefInfo)
        {
            if (indexEntityRefInfo.Cursor.CursorKind == LibClang.Intertop.CXCursorKind.CXCursor_FunctionDecl)
            {
                foreach (var item in indexEntityRefInfo.Cursor.TemplateArguments)
                {

                }
            }
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
