using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public  class File : ClangObject
    {
        internal File(IntPtr file)
        {
            this.m_value = file;
        }

        private IntPtr m_value;

        private string _fileName;
        public string FileName
        {
            get
            {
                if (this._fileName == null)
                {
                    this._fileName = clang.clang_getFileName(this.m_value).ToStringAndDispose();
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
                    this.realPathName = clang.clang_File_tryGetRealPathName(this.m_value).ToStringAndDispose();
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

        protected internal override ValueType Value
        {
            get { return this.m_value; }
        }

        protected override bool EqualsCore(ClangObject clangObject)
        {
            return clang.clang_File_isEqual(this.m_value, (IntPtr)clangObject.Value) > 0;
        }


        public override string ToString()
        {
            return this.FileName;
        }

    }
}
