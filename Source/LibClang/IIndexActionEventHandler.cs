using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LibClang
{
    public interface IIndexActionEventHandler
    {


        void OnQueryContinue(CancelEventArgs e);

        void OnDiagnostic(DiagnosticSet diagnostics);

        File OnEnteredMainFile(File file);

        File OnIncludeFile(IndexIncludedFileInfo indexIncludedFileInfo);

        void OnIndexDeclaration(IndexDeclInfo indexDeclInfo);

        void OnIndexEntityRefInfo(IndexEntityRefInfo indexEntityRefInfo);

        void OnStartTranslationUnit();
    }
}
