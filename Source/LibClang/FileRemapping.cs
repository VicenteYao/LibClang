using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class FileRemapping : ClangObject
    {
        public FileRemapping(string path)
        {
            this.m_value = clang.clang_getRemappings(path);
        }

        public FileRemapping(string[] fileNames)
        {
            this.m_value = clang.clang_getRemappingsFromFileList(fileNames, (uint)fileNames.Length);
        }


        private (string, string)[] _mappings;
        private IntPtr m_value;

        public (string,string)[] Mappings
        {
            get
            {
                if (this._mappings==null)
                {
                    uint mappingsCount = clang.clang_remap_getNumFiles(this.m_value);
                    this._mappings = new (string, string)[mappingsCount];
                    for (uint i = 0; i < mappingsCount; i++)
                    {
                        CXString xOriginal;
                        CXString xTransformed;
                        clang.clang_remap_getFilenames(this.m_value, i, out xOriginal, out xTransformed);
                        this._mappings[i] = (xOriginal.ToStringAndDispose(), xTransformed.ToStringAndDispose());
                    }
                }
                return this._mappings;
            }
        }

        protected internal override ValueType Value
        {
            get
            {
                return this.m_value;
            }
        }

        protected override void Dispose()
        {
            clang.clang_remap_dispose(this.m_value);
        }
    }
}
