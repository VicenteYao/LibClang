namespace LibClang.Intertop
{
    /// <summary>
    /// Defines the CXEvalResultKind
    /// </summary>
    public enum CXEvalResultKind
    {
        /// <summary>
        /// Defines the CXEval_Int
        /// </summary>
        CXEval_Int = 1,
        /// <summary>
        /// Defines the CXEval_Float
        /// </summary>
        CXEval_Float = 2,
        /// <summary>
        /// Defines the CXEval_ObjCStrLiteral
        /// </summary>
        CXEval_ObjCStrLiteral = 3,
        /// <summary>
        /// Defines the CXEval_StrLiteral
        /// </summary>
        CXEval_StrLiteral = 4,
        /// <summary>
        /// Defines the CXEval_CFStr
        /// </summary>
        CXEval_CFStr = 5,
        /// <summary>
        /// Defines the CXEval_Other
        /// </summary>
        CXEval_Other = 6,
        /// <summary>
        /// Defines the CXEval_UnExposed
        /// </summary>
        CXEval_UnExposed = 0
    }
}
