using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang
{
    public class InstantiationLocation
    {
        internal InstantiationLocation(File file, uint line, uint column, uint offset)
        {
            this.File = file;
            this.Line = line;
            this.Column = column;
            this.Offset = offset;
        }

        public File File { get; private set; }
        public uint Column { get; private set; }
        public uint Line { get; private set; }
        public uint Offset { get; private set; }

    }
}
