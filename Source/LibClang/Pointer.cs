namespace LibClang
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Defines the <see cref="Pointer{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Pointer<T> : IDisposable
    {
        /// <summary>
        /// Gets the Size
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private T m_value;

        /// <summary>
        /// Defines the m_arrayLength
        /// </summary>
        private int m_arrayLength;

        /// <summary>
        /// Initializes a new instance of the <see cref="Pointer{T}"/> class.
        /// </summary>
        /// <param name="obj">The obj<see cref="T"/></param>
        internal Pointer(T obj)
        {
            this.m_arrayLength = 0;
            this.Size = Marshal.SizeOf(typeof(T));
            this.m_ptr = Marshal.AllocHGlobal(this.Size);
            Marshal.StructureToPtr(obj, this.m_ptr, false);
        }

        /// <summary>
        /// The Cast
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="castFunc">The castFunc<see cref="Func{T, TResult}"/></param>
        /// <returns>The <see cref="TResult"/></returns>
        public TResult Cast<TResult>(Func<T, TResult> castFunc)
        {
            return castFunc(this.m_value);
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        public void Dispose()
        {
            for (int i = 0; i < this.m_arrayLength; i++)
            {
                Marshal.FreeHGlobal(this.m_ptr + i);
            }
            Marshal.FreeHGlobal(this.m_ptr);
        }

        /// <summary>
        /// Defines the m_ptr
        /// </summary>
        private IntPtr m_ptr;



        public static implicit operator IntPtr(Pointer<T> pointer)
        {
            return pointer.m_ptr;
        }
    }
}
