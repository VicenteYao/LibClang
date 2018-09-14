using System;
using System.Runtime.InteropServices;
using LibClang.Intertop;
using System.Linq;

namespace LibClang
{
    public unsafe class Index : ClangObject
    {
        public Index(bool excludeDeclarationsFromPCH, bool displayDiagnostics)
        {
            this.m_value = clang.clang_createIndex(excludeDeclarationsFromPCH ? 1 : 0, excludeDeclarationsFromPCH ? 1 : 0);
        }

        private CXGlobalOptFlags _globalOptFlags;
        private IntPtr m_value;

        public CXGlobalOptFlags GlobalOptFlags
        {
            get { return _globalOptFlags = (CXGlobalOptFlags)clang.clang_CXIndex_getGlobalOptions(this.m_value); }
            set
            {

                _globalOptFlags = value;
                clang.clang_CXIndex_setGlobalOptions(this.m_value, (uint)value);
            }
        }

        protected internal override ValueType Value => throw new NotImplementedException();

        public TranslationUnit CreateTranslationUnit(string astFileName)
        {
            IntPtr pTranslationUnit = clang.clang_createTranslationUnit(this.m_value, astFileName);
            if (pTranslationUnit == IntPtr.Zero)
            {
                return null;
            }
            return new TranslationUnit(pTranslationUnit);
        }

        public TranslationUnit CreateTranslationUnit(string astFileName, out CXErrorCode errorCode)
        {
            IntPtr pTranslationUnit = IntPtr.Zero;
            errorCode = clang.clang_createTranslationUnit2(this.m_value, astFileName, out pTranslationUnit);
            if (pTranslationUnit == IntPtr.Zero)
            {
                return null;
            }
            return new TranslationUnit(pTranslationUnit);
        }

        public TranslationUnit CreateTranslationUnit(string sourceFileName, string[] cmdArgs, UnsavedFile[] unsavedFiles)
        {
            IntPtr pTranslationUnit = IntPtr.Zero;
            if (cmdArgs == null)
            {
                cmdArgs = new string[0];
            }
            if (unsavedFiles == null)
            {
                unsavedFiles = new UnsavedFile[0];
            }
            pTranslationUnit = clang.clang_createTranslationUnitFromSourceFile(this.m_value, sourceFileName, cmdArgs.Length, cmdArgs, (uint)unsavedFiles.Length, unsavedFiles.Select(x => (CXUnsavedFile)x.Value).ToArray());
            if (pTranslationUnit == IntPtr.Zero)
            {
                return null;
            }
            return new TranslationUnit(pTranslationUnit);
        }

        public TranslationUnit Parse(string sourceFileName, CXGlobalOptFlags globalOptFlags, string[] cmdLineArgs, UnsavedFile[] unsavedFiles)
        {
            IntPtr pTranslationUnit = IntPtr.Zero;
            if (cmdLineArgs == null)
            {
                cmdLineArgs = new string[0];
            }
            if (unsavedFiles == null)
            {
                unsavedFiles = new UnsavedFile[0];
            }
            pTranslationUnit = clang.clang_parseTranslationUnit(this.m_value, sourceFileName, cmdLineArgs, cmdLineArgs.Length, unsavedFiles.Select(x =>(CXUnsavedFile) x.Value).ToArray(), (uint)unsavedFiles.Length, (uint)globalOptFlags);
            if (pTranslationUnit == IntPtr.Zero)
            {
                return null;
            }
            return new TranslationUnit(pTranslationUnit);
        }

        public TranslationUnit Parse(string sourceFileName, CXGlobalOptFlags globalOptFlags, string[] cmdLineArgs, UnsavedFile[] unsavedFiles, out CXErrorCode errorCode)
        {
            IntPtr pTranslationUnit = IntPtr.Zero;
            if (cmdLineArgs == null)
            {
                cmdLineArgs = new string[0];
            }
            if (unsavedFiles == null)
            {
                unsavedFiles = new UnsavedFile[0];
            }
            errorCode = clang.clang_parseTranslationUnit2(this.m_value, sourceFileName, cmdLineArgs, cmdLineArgs.Length, unsavedFiles.Select(x => (CXUnsavedFile)x.Value).ToArray(), (uint)unsavedFiles.Length, (uint)globalOptFlags, out pTranslationUnit);
            if (pTranslationUnit == IntPtr.Zero)
            {
                return null;
            }
            return new TranslationUnit(pTranslationUnit);
        }

        public TranslationUnit ParseWithFullArguments(string sourceFileName, CXGlobalOptFlags globalOptFlags, string[] cmdLineArgs, UnsavedFile[] unsavedFiles, out CXErrorCode errorCode)
        {
            IntPtr pTranslationUnit = IntPtr.Zero;
            if (cmdLineArgs == null)
            {
                cmdLineArgs = new string[0];
            }
            if (unsavedFiles == null)
            {
                unsavedFiles = new UnsavedFile[0];
            }
            errorCode = clang.clang_parseTranslationUnit2FullArgv(this.m_value, sourceFileName, cmdLineArgs, cmdLineArgs.Length, unsavedFiles.Select(x => (CXUnsavedFile)x.Value).ToArray(), (uint)unsavedFiles.Length, (uint)globalOptFlags, out pTranslationUnit);
            if (pTranslationUnit == IntPtr.Zero)
            {
                return null;
            }
            return new TranslationUnit(pTranslationUnit);
        }





        public IndexAction CreateIndexAction(IIndexActionEventHandler indexActionEventHandler)
        {
            IntPtr pIndexAction = clang.clang_IndexAction_create(this.m_value);
            if (pIndexAction == IntPtr.Zero)
            {
                return null;
            }
            return new IndexAction(indexActionEventHandler, pIndexAction);
        }


        protected override void Dispose()
        {
            clang.clang_disposeIndex(this.m_value);
        }

    }
}
