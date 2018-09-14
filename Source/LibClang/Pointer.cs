using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LibClang
{
    internal class Pointer<T> : IDisposable
    {
        internal Pointer(T[] array)
        {
            this.m_arrayLength = array.Length;
            this.Size = Marshal.SizeOf(Marshal.SizeOf(typeof(T)) * array.Length);
            this.m_ptr = Marshal.AllocHGlobal(this.Size);
            for (int i = 0; i < array.Length; i++)
            {
                Marshal.StructureToPtr(array.GetValue(i), (this.m_ptr + i), false);
            }
        }

        public int Size { get; private set; }

        private T[] m_arrayValue;
        private T m_value;

        private int m_arrayLength;

        internal Pointer(T obj)
        {
            this.m_arrayLength = 0;
            this.Size = Marshal.SizeOf(typeof(T));
            this.m_ptr = Marshal.AllocHGlobal(this.Size);
            Marshal.StructureToPtr(obj, this.m_ptr, false);
        }

        public TResult Cast<TResult>(Func<T, TResult> castFunc)
        {
            return castFunc(this.m_value);
        }

        public TResult Cast<TResult>(Func<T[], TResult> castFunc)
        {
            return castFunc(this.m_arrayValue);
        }


        public void Dispose()
        {
            for (int i = 0; i < this.m_arrayLength; i++)
            {
                Marshal.FreeHGlobal(this.m_ptr + i);
            }
            Marshal.FreeHGlobal(this.m_ptr);
        }

        private IntPtr m_ptr;
        
        public static implicit operator IntPtr(Pointer<T> pointer)
        {
            return pointer.m_ptr;
        }
    }
}
