using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using LibClang;

namespace LibClangUnitTest
{
    public class IndexActionEventHandler : IIndexActionEventHandler
    {
        public void OnDiagnostic(DiagnosticSet diagnostics)
        {

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

        }

        public void OnIndexEntityRefInfo(IndexEntityRefInfo indexEntityRefInfo)
        {

        }

        public void OnQueryContinue(CancelEventArgs e)
        {
            e.Cancel = false;
        }

        public void OnStartTranslationUnit()
        {

        }
    }
}
