namespace LibClang.Intertop
{
    /**
           * Bits that represent the context under which completion is occurring.
           *
           * The enumerators in this enumeration may be bitwise-OR'd together if multiple
           * contexts are occurring simultaneously.
           */
    public enum CXCompletionContext
    {
        /**
                                 * The context for completions is unexposed, as only Clang results
                                 * should be included. (This is equivalent to having no context bits set.)
                                 */
        CXCompletionContext_Unexposed = 0,
        /**
         * Completions for any possible type should be included in the results.
         */
        CXCompletionContext_AnyType = 1 << 0,
        /**
         * Completions for any possible value (variables, function calls, etc.)
         * should be included in the results.
         */
        CXCompletionContext_AnyValue = 1 << 1,
        /**
         * Completions for values that resolve to an Objective-C object should
         * be included in the results.
         */
        CXCompletionContext_ObjCObjectValue = 1 << 2,
        /**
         * Completions for values that resolve to an Objective-C selector
         * should be included in the results.
         */
        CXCompletionContext_ObjCSelectorValue = 1 << 3,
        /**
         * Completions for values that resolve to a C++ class type should be
         * included in the results.
         */
        CXCompletionContext_CXXClassTypeValue = 1 << 4,
        /**
         * Completions for fields of the member being accessed using the dot
         * operator should be included in the results.
         */
        CXCompletionContext_DotMemberAccess = 1 << 5,
        /**
         * Completions for fields of the member being accessed using the arrow
         * operator should be included in the results.
         */
        CXCompletionContext_ArrowMemberAccess = 1 << 6,
        /**
         * Completions for properties of the Objective-C object being accessed
         * using the dot operator should be included in the results.
         */
        CXCompletionContext_ObjCPropertyAccess = 1 << 7,
        /**
         * Completions for enum tags should be included in the results.
         */
        CXCompletionContext_EnumTag = 1 << 8,
        /**
         * Completions for union tags should be included in the results.
         */
        CXCompletionContext_UnionTag = 1 << 9,
        /**
         * Completions for struct tags should be included in the results.
         */
        CXCompletionContext_StructTag = 1 << 10,
        /**
         * Completions for C++ class names should be included in the results.
         */
        CXCompletionContext_ClassTag = 1 << 11,
        /**
         * Completions for C++ namespaces and namespace aliases should be
         * included in the results.
         */
        CXCompletionContext_Namespace = 1 << 12,
        /**
         * Completions for C++ nested name specifiers should be included in
         * the results.
         */
        CXCompletionContext_NestedNameSpecifier = 1 << 13,
        /**
         * Completions for Objective-C interfaces (classes) should be included
         * in the results.
         */
        CXCompletionContext_ObjCInterface = 1 << 14,
        /**
         * Completions for Objective-C protocols should be included in
         * the results.
         */
        CXCompletionContext_ObjCProtocol = 1 << 15,
        /**
         * Completions for Objective-C categories should be included in
         * the results.
         */
        CXCompletionContext_ObjCCategory = 1 << 16,
        /**
         * Completions for Objective-C instance messages should be included
         * in the results.
         */
        CXCompletionContext_ObjCInstanceMessage = 1 << 17,
        /**
         * Completions for Objective-C class messages should be included in
         * the results.
         */
        CXCompletionContext_ObjCClassMessage = 1 << 18,
        /**
         * Completions for Objective-C selector names should be included in
         * the results.
         */
        CXCompletionContext_ObjCSelectorName = 1 << 19,
        /**
         * Completions for preprocessor macro names should be included in
         * the results.
         */
        CXCompletionContext_MacroName = 1 << 20,
        /**
         * Natural language completions should be included in the results.
         */
        CXCompletionContext_NaturalLanguage = 1 << 21,
        /**
         * The current context is unknown, so set all contexts.
         */
        CXCompletionContext_Unknown = ((1 << 22) - 1)
    }
}
