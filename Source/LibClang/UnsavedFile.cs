using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class UnsavedFile : ClangObject<CXUnsavedFile>
    {
        public UnsavedFile(string fileName)
        {
            string contents = System.IO.File.ReadAllText(fileName);
            this.Value = new CXUnsavedFile()
            {
                Filename = Marshal.StringToHGlobalUni(fileName),
                Contents = Marshal.StringToHGlobalUni(contents),
                Length = (uint)contents.Length,
            };
        }

        protected override void Dispose()
        {
            Marshal.FreeHGlobal(this.Value.Filename);
            Marshal.FreeHGlobal(this.Value.Contents);
        }

        protected override bool EqualsCore(ClangObject<CXUnsavedFile> clangObject)
        {
            return false;
        }
    }
}
