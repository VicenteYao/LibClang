using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using LibClang;

namespace CodeCompleteDemo
{
    public class IndexActionEventHandler : IIndexActionEventHandler
    {
        public void OnDiagnostic(ClangList<Diagnostic> diagnostics,object param)
        {

        }

        public File OnEnteredMainFile(File file, object param)
        {
            return file;
        }

        public void OnImportedASTFileInfo(ImportedAstFileInfo astFileInfo, object param)
        {

        }

        public File OnIncludeFile(IndexIncludedFileInfo indexIncludedFileInfo, object param)
        {
            return indexIncludedFileInfo.File;
        }

        public void OnIndexDeclaration(IndexDeclInfo indexDeclInfo, object param)
        {

        }

        public void OnIndexEntityRefInfo(IndexEntityRefInfo indexEntityRefInfo, object param)
        {

        }

        public bool OnQueryAbort(object param)
        {
            return false;
        }


        public void OnStartTranslationUnit(object param)
        {

        }
    }
}
