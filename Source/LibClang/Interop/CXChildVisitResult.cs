namespace LibClang.Intertop
{
    /**
     * @}
     */

    /**
     * \defgroup CINDEX_CURSOR_TRAVERSAL Traversing the AST with cursors
     *
     * These routines provide the ability to traverse the abstract syntax tree
     * using cursors.
     *
     * @{
     */

    /**
     * Describes how the traversal of the children of a particular
     * cursor should proceed after visiting a particular child cursor.
     *
     * A value of this enumeration type should be returned by each
     * \c CXCursorVisitor to indicate how clang_visitChildren() proceed.
     */
    public enum CXChildVisitResult
    {
        /**
                                 * Terminates the cursor traversal.
                                 */
        CXChildVisit_Break,
        /**
         * Continues the cursor traversal with the next sibling of
         * the cursor just visited, without visiting its children.
         */
        CXChildVisit_Continue,
        /**
         * Recursively traverse the children of this cursor, using
         * the same visitor and client data.
         */
        CXChildVisit_Recurse
    }
}
