namespace LibClang.Intertop
{
    using System;

    /// <summary>
    /// The visit
    /// </summary>
    /// <param name="context">The context<see cref="IntPtr"/></param>
    /// <param name="cXCursor">The cXCursor<see cref="CXCursor"/></param>
    /// <param name="cXSourceRange">The cXSourceRange<see cref="CXSourceRange"/></param>
    /// <returns>The <see cref="CXVisitorResult"/></returns>
    public delegate CXVisitorResult visit(IntPtr context, CXCursor cXCursor, CXSourceRange cXSourceRange);

    /// <summary>
    /// Defines the <see cref="CXCursorAndRangeVisitor" />
    /// </summary>
    public unsafe struct CXCursorAndRangeVisitor
    {
        /// <summary>
        /// Defines the context
        /// </summary>
        public IntPtr context;

        /// <summary>
        /// Defines the Visit
        /// </summary>
        public IntPtr Visit;
    }
}
