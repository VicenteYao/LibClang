namespace LibClang.Intertop
{
    /// <summary>
    /// Defines the CXRefQualifierKind
    /// </summary>
    public enum CXRefQualifierKind
    {
        /** No ref-qualifier was provided. */
        CXRefQualifier_None = 0,
        /** An lvalue ref-qualifier was provided (\c &). */
        CXRefQualifier_LValue,
        /** An rvalue ref-qualifier was provided (\c &&). */
        CXRefQualifier_RValue
    }
}
