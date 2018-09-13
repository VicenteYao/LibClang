using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang
{
    public class FixIt
    {
        internal FixIt(string text,SourceRange sourceRange)
        {
            this.Text = text;
            this.SourceRange = sourceRange;
        }

        public string Text { get; private set; }

        public SourceRange SourceRange { get; private set; }
    }
}
