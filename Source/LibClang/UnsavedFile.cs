using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class UnsavedFile : ClangObject
    {
        public UnsavedFile(string fileName)
        {
            string contents = System.IO.File.ReadAllText(fileName);
            this.m_value = new CXUnsavedFile()
            {
                Filename = Marshal.StringToHGlobalUni(fileName),
                Contents = Marshal.StringToHGlobalUni(contents),
                Length = (uint)contents.Length,
            };
        }

        private CXUnsavedFile m_value;

        protected override void Dispose()
        {
            Marshal.FreeHGlobal(this.m_value.Filename);
            Marshal.FreeHGlobal(this.m_value.Contents);
        }

        protected internal override ValueType Value { get { return this.m_value; } }


    }
}
