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
