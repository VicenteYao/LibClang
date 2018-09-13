using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class FileRemapping : ClangObject<IntPtr>
    {
        public FileRemapping(string path)
        {
            this.Value = clang.clang_getRemappings(path);
        }

        public FileRemapping(string[] fileNames)
        {
            this.Value = clang.clang_getRemappingsFromFileList(fileNames, (uint)fileNames.Length);
        }


        private (string, string)[] _mappings;
        public (string,string)[] Mappings
        {
            get
            {
                if (this._mappings==null)
                {
                    uint mappingsCount = clang.clang_remap_getNumFiles(this.Value);
                    this._mappings = new (string, string)[mappingsCount];
                    for (uint i = 0; i < mappingsCount; i++)
                    {
                        CXString xOriginal;
                        CXString xTransformed;
                        clang.clang_remap_getFilenames(this.Value, i, out xOriginal, out xTransformed);
                        this._mappings[i] = (xOriginal.ToStringAndDispose(), xTransformed.ToStringAndDispose());
                    }
                }
                return this._mappings;
            }
        }

        protected override void Dispose()
        {
            clang.clang_remap_dispose(this.Value);
        }

        protected override bool EqualsCore(ClangObject<IntPtr> clangObject)
        {
            return this.Value == clangObject.Value;
        }
    }
}
