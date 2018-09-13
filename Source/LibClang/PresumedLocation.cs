using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang
{
    public  class PresumedLocation
    {
        internal PresumedLocation(string fileName, uint line, uint column)
        {
            this.FileName = fileName;
            this.Line = line;
            this.Column = column;
        }

        public string FileName { get; private set; }

        public uint Column { get; private set; }

        public uint Line { get; private set; }


    }
}
