using System;
using System.Runtime.InteropServices;
using LibClang.Intertop;

namespace LibClang
{
    public unsafe class Index : ClangObject<IntPtr>, IDisposable
    {
        public Index()
        {
            this.Value = clang.clang_createIndex(0, 1);
        }

        private CXGlobalOptFlags _GlobalOptFlags;

        public CXGlobalOptFlags GlobalOptFlags
        {
            get { return _GlobalOptFlags = (CXGlobalOptFlags)clang.clang_CXIndex_getGlobalOptions(this.Value); }
            set
            {

                _GlobalOptFlags = value;
                clang.clang_CXIndex_setGlobalOptions(this.Value, (uint)value);
            }
        }

        public TranslationUnit CreateTranslationUnit(string astFileName)
        {
            IntPtr pTranslationUnit = clang.clang_createTranslationUnit(this.Value, astFileName);
            if (pTranslationUnit == IntPtr.Zero)
            {
                return null;
            }
            return new TranslationUnit(pTranslationUnit);

        }

        public TranslationUnit CreateTranslationUnit(string astFileName, out CXErrorCode errorCode)
        {
            IntPtr pTranslationUnit = IntPtr.Zero;
            errorCode = clang.clang_createTranslationUnit2(this.Value, astFileName, out pTranslationUnit);
            if (pTranslationUnit == IntPtr.Zero)
            {
                return null;
            }
            return new TranslationUnit(pTranslationUnit);

        }

        public TranslationUnit CreateTranslationUnit(string sourceFileName,string[] cmdArgs, UnsavedFile[] unsavedFiles)
        {
            IntPtr pTranslationUnit = IntPtr.Zero;
            if (cmdArgs==null)
            {
                cmdArgs = new string[1];
                cmdArgs[0] = string.Empty;
            }
            if (unsavedFiles==null)
            {
                unsavedFiles = new UnsavedFile[0];
            }
            sbyte** pCmdArgs = cmdArgs.ToPointer();
            CXUnsavedFile* pUnsavedFile = unsavedFiles.ToPointer();
            pTranslationUnit = clang.clang_createTranslationUnitFromSourceFile(this.Value, sourceFileName, cmdArgs.Length, pCmdArgs, (uint)unsavedFiles.Length, pUnsavedFile);

            if ((IntPtr)pCmdArgs!=IntPtr.Zero)
            {
                for (int i = 0; i < cmdArgs.Length; i++)
                {
                    Marshal.FreeHGlobal((IntPtr)pCmdArgs[i]);
                }
                Marshal.FreeHGlobal((IntPtr)pCmdArgs);
            }
            if ((IntPtr)pUnsavedFile!=IntPtr.Zero)
            {
                Marshal.FreeHGlobal((IntPtr)pUnsavedFile);

            }

            if (pTranslationUnit==IntPtr.Zero)
            {
                return null;
            }
            return new TranslationUnit(pTranslationUnit);
        }





        public IndexAction CreateIndexAction(IIndexActionEventHandler indexActionEventHandler)
        {
            IntPtr pIndexAction = clang.clang_IndexAction_create(this.Value);
            if (pIndexAction == IntPtr.Zero)
            {
                return null;
            }
            return new IndexAction(indexActionEventHandler, pIndexAction);
        }


        protected override void Dispose()
        {
            clang.clang_disposeIndex(this.Value);
        }

        protected override bool EqualsCore(ClangObject<IntPtr> clangObject)
        {
            return this.Value == clangObject.Value;
        }
    }
}
