using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public unsafe class File : ClangObject<IntPtr>
    {
        internal File(IntPtr file)
        {
            this.Value = file;
        }

        private string _fileName;
        public string FileName
        {
            get
            {
                if (this._fileName == null)
                {
                    this._fileName = clang.clang_getFileName(this.Value).ToStringAndDispose();
                }
                return this._fileName;
            }
        }

        private string realPathName;
        public string RealPathName
        {
            get
            {
                if (this.realPathName==null)
                {
                    this.realPathName = clang.clang_File_tryGetRealPathName(this.Value).ToStringAndDispose();
                }
                return this.realPathName;
            }
        }

        private string[] lines;
        public string[] Lines
        {
            get
            {
                if (this.lines==null)
                {
                    this.lines = System.IO.File.ReadAllLines(this.FileName);
                }
                return this.lines;
            }
        }

        protected override bool EqualsCore(ClangObject<IntPtr> clangObject)
        {
            return this.Value == clangObject.Value;
        }


    }
}
