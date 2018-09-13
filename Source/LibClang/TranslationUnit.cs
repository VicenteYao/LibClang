﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using LibClang.Intertop;
using System.Linq;

namespace LibClang
{
    public class TranslationUnit : ClangObject<IntPtr>, IDisposable
    {
        internal TranslationUnit(IntPtr pTranlationUnit)
        {
            this.Value = pTranlationUnit;
        }

        public unsafe CodeCompleteResults CodeCompleteAt(string completeFileName, uint completeline, uint completeColumn, UnsavedFile[] unsavedFiles, CXCodeComplete_Flags flags)
        {
            if (unsavedFiles==null)
            {
                unsavedFiles = new UnsavedFile[0];
            }
            CXCodeCompleteResults* pCodeComplete = clang.clang_codeCompleteAt(this.Value, completeFileName, completeline, completeColumn, unsavedFiles.Select(x => x.Value).ToArray(), (uint)unsavedFiles.Length, (uint)flags);
            return new CodeCompleteResults((IntPtr)pCodeComplete);
        }

        public void Suspend()
        {
            clang.clang_suspendTranslationUnit(this.Value);
        }

        public void Save(string fileName)
        {
            clang.clang_saveTranslationUnit(this.Value, fileName, 0);
        }

        private Cursor _cursor;

        public Cursor Cursor
        {
            get
            {
                CXCursor cursor = clang.clang_getTranslationUnitCursor(this.Value);
                this._cursor = new Cursor(cursor);
                return this._cursor;
            }
        }

        private TargetInfo _targetInfo;
        public TargetInfo TargetInfo
        {
            get
            {
                if (this._targetInfo == null)
                {
                    IntPtr value = clang.clang_getTranslationUnitTargetInfo(this.Value);
                    if (value != IntPtr.Zero)
                    {
                        this._targetInfo = new TargetInfo(value);
                    }
                }
                return this._targetInfo;
            }
        }

        private Diagnostic[] _diagnostics;
        public Diagnostic[] Diagnostics
        {
            get
            {
                if (_diagnostics==null)
                {
                    uint diagnosticCount = clang.clang_getNumDiagnostics(this.Value);
                    this._diagnostics = new Diagnostic[diagnosticCount];
                    for (uint i = 0; i < diagnosticCount; i++)
                    {
                        this._diagnostics[i] = new Diagnostic(clang.clang_getDiagnostic(this.Value, i));
                    }
                }
                return this._diagnostics;
            }
        }

        private DiagnosticSet _diagnosticSet;
        public DiagnosticSet DiagnosticSet
        {
            get
            {
               
                if (this._diagnosticSet == null)
                {
                    this._diagnosticSet = new DiagnosticSet(clang.clang_getDiagnosticSetFromTU(this.Value));
                }
                return this._diagnosticSet;
            }
        }

        


        protected override void Dispose()
        {
            clang.clang_disposeTranslationUnit(this.Value);
        }

        public unsafe Token[]  Tokenize(SourceRange sourceRange)
        {
            Token[] tokens = null;
            CXToken* pToken = null;
            uint tokenCount = 0;
            clang.clang_tokenize(this.Value, sourceRange.Value, out pToken, out tokenCount);
            tokens = new Token[tokenCount];
            CXTokenObject cXTokenObject = new CXTokenObject();
            for (int i = 0; i < tokenCount; i++)
            {
                Marshal.PtrToStructure((IntPtr)(pToken + i), cXTokenObject);
                CXToken cXToken = default(CXToken);
                cXToken.int_data1 = cXTokenObject.int_data1;
                cXToken.int_data2 = cXTokenObject.int_data2;
                cXToken.int_data3 = cXTokenObject.int_data3;
                cXToken.int_data4 = cXTokenObject.int_data4;
                cXToken.ptr_data = cXTokenObject.ptr_data;
                tokens[i] = new Token(this, cXToken);
            }
            //clang.clang_disposeTokens(this.Value, pToken, tokenCount);
            return tokens;
        }

        public Cursor GetCursor(SourceLocation sourceLocation)
        {
            return new Cursor(clang.clang_getCursor(this.Value, sourceLocation.Value));
        }

        public SourceLocation GetSourceLocation(File file, uint line, uint column)
        {
            return new SourceLocation(clang.clang_getLocation(this.Value, file.Value, line, column));
        }

        public SourceLocation GetSourceLocation(File file, uint offset)
        {
            return new SourceLocation(clang.clang_getLocationForOffset(this.Value, file.Value, offset));
        }

        public SourceRange GetSourceRange(File file, uint beginLine, uint beginColumn, uint endLine, uint endColumn)
        {
            var begin = this.GetSourceLocation(file, beginLine, beginColumn);
            var end = this.GetSourceLocation(file, endLine, endColumn);
            return new SourceRange(begin, end);
        }

        public SourceRange GetSourceRange(File file)
        {
            var begin = this.GetSourceLocation(file, 1, 1);
            var end = this.GetSourceLocation(file, (uint)file.Lines.Length, (uint)file.Lines[file.Lines.Length - 1].Length);
            return new SourceRange(begin, end);
        }

        public File GetFile(string fileName)
        {
            IntPtr pFile = clang.clang_getFile(this.Value, fileName);
            if (pFile == IntPtr.Zero)
            {
                return null;
            }
            File file = new File(pFile);
            return file;
        }

        public unsafe string GetFileContents(File file)
        {
            uint size = 0;
            string contents = new string(clang.clang_getFileContents(this.Value, file.Value, out size), 0, (int)size);
            return contents;
        }

        public Module GetModule(File file)
        {
            IntPtr pModule = clang.clang_getModuleForFile(this.Value, file.Value);
            if (pModule == IntPtr.Zero)
            {
                return null;
            }
            Module module = new Module(pModule);
            return module;
        }


        public File[] GetTopLeverHeaders(Module module)
        {
            uint topleverHeadersCount = clang.clang_Module_getNumTopLevelHeaders(this.Value, module.Value);
            File[] topleverHeaders = new File[topleverHeadersCount];
            for (uint i = 0; i < topleverHeadersCount; i++)
            {
                topleverHeaders[i] = new File(clang.clang_Module_getTopLevelHeader(this.Value, module.Value, i));
            }
            return topleverHeaders;
        }


        protected override bool EqualsCore(ClangObject<IntPtr> clangObject)
        {
            return this.Value == clangObject.Value;
        }
    }
}
