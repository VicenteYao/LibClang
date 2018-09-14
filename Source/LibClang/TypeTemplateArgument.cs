using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang
{
    public  class TypeTemplateArgument
    {
        internal TypeTemplateArgument(Type type)
        {
            this.Type = type;
        }

        internal TypeTemplateArgument(uint uintValue)
        {
            this.UIntValue = uintValue;
        }

        internal TypeTemplateArgument(long longValue)
        {
            this.LongValue = longValue;
        }


        public Type Type { get; private set; }

        public uint UIntValue { get; private set; }

        public long LongValue { get; private set; }

    }
}
