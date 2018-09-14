using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang
{
    public  class TemplateArgument
    {
        internal TemplateArgument(Type type)
        {
            this.Type = type;
        }

        internal TemplateArgument(uint uintValue)
        {
            this.UIntValue = uintValue;
        }

        internal TemplateArgument(long longValue)
        {
            this.LongValue = longValue;
        }


        public Type Type { get; private set; }

        public uint UIntValue { get; private set; }

        public long LongValue { get; private set; }

    }
}
