namespace LibClang.Intertop
{
    /**
     * Describes a single piece of text within a code-completion string.
     *
     * Each "chunk" within a code-completion string (\c CXCompletionString) is
     * either a piece of text with a specific "kind" that describes how that text
     * should be interpreted by the client or is another completion string.
     */
    public enum CXCompletionChunkKind
    {
        /**
                         * A code-completion string that describes "optional" text that
                         * could be a part of the template (but is not required).
                         *
                         * The Optional chunk is the only kind of chunk that has a code-completion
                         * string for its representation, which is accessible via
                         * \c clang_getCompletionChunkCompletionString(). The code-completion string
                         * describes an additional part of the template that is completely optional.
                         * For example, optional chunks can be used to describe the placeholders for
                         * arguments that match up with defaulted function parameters, e.g. given:
                         *
                         * \code
                         * void f(int x, float y = 3.14, double z = 2.71828);
                         * \endcode
                         *
                         * The code-completion string for this function would contain:
                         *   - a TypedText chunk for "f".
                         *   - a LeftParen chunk for "(".
                         *   - a Placeholder chunk for "int x"
                         *   - an Optional chunk containing the remaining defaulted arguments, e.g.,
                         *       - a Comma chunk for ","
                         *       - a Placeholder chunk for "float y"
                         *       - an Optional chunk containing the last defaulted argument:
                         *           - a Comma chunk for ","
                         *           - a Placeholder chunk for "double z"
                         *   - a RightParen chunk for ")"
                         *
                         * There are many ways to handle Optional chunks. Two simple approaches are:
                         *   - Completely ignore optional chunks, in which case the template for the
                         *     function "f" would only include the first parameter ("int x").
                         *   - Fully expand all optional chunks, in which case the template for the
                         *     function "f" would have all of the parameters.
                         */
        CXCompletionChunk_Optional,
        /**
         * Text that a user would be expected to type to get this
         * code-completion result.
         *
         * There will be exactly one "typed text" chunk in a semantic string, which
         * will typically provide the spelling of a keyword or the name of a
         * declaration that could be used at the current code point. Clients are
         * expected to filter the code-completion results based on the text in this
         * chunk.
         */
        CXCompletionChunk_TypedText,
        /**
         * Text that should be inserted as part of a code-completion result.
         *
         * A "text" chunk represents text that is part of the template to be
         * inserted into user code should this particular code-completion result
         * be selected.
         */
        CXCompletionChunk_Text,
        /**
         * Placeholder text that should be replaced by the user.
         *
         * A "placeholder" chunk marks a place where the user should insert text
         * into the code-completion template. For example, placeholders might mark
         * the function parameters for a function declaration, to indicate that the
         * user should provide arguments for each of those parameters. The actual
         * text in a placeholder is a suggestion for the text to display before
         * the user replaces the placeholder with real code.
         */
        CXCompletionChunk_Placeholder,
        /**
         * Informative text that should be displayed but never inserted as
         * part of the template.
         *
         * An "informative" chunk contains annotations that can be displayed to
         * help the user decide whether a particular code-completion result is the
         * right option, but which is not part of the actual template to be inserted
         * by code completion.
         */
        CXCompletionChunk_Informative,
        /**
         * Text that describes the current parameter when code-completion is
         * referring to function call, message send, or template specialization.
         *
         * A "current parameter" chunk occurs when code-completion is providing
         * information about a parameter corresponding to the argument at the
         * code-completion point. For example, given a function
         *
         * \code
         * int add(int x, int y);
         * \endcode
         *
         * and the source code \c add(, where the code-completion point is after the
         * "(", the code-completion string will contain a "current parameter" chunk
         * for "int x", indicating that the current argument will initialize that
         * parameter. After typing further, to \c add(17, (where the code-completion
         * point is after the ","), the code-completion string will contain a
         * "current parameter" chunk to "int y".
         */
        CXCompletionChunk_CurrentParameter,
        /**
         * A left parenthesis ('('), used to initiate a function call or
         * signal the beginning of a function parameter list.
         */
        CXCompletionChunk_LeftParen,
        /**
         * A right parenthesis (')'), used to finish a function call or
         * signal the end of a function parameter list.
         */
        CXCompletionChunk_RightParen,
        /**
         * A left bracket ('[').
         */
        CXCompletionChunk_LeftBracket,
        /**
         * A right bracket (']').
         */
        CXCompletionChunk_RightBracket,
        /**
         * A left brace ('{').
         */
        CXCompletionChunk_LeftBrace,
        /**
         * A right brace ('}').
         */
        CXCompletionChunk_RightBrace,
        /**
         * A left angle bracket ('<').
         */
        CXCompletionChunk_LeftAngle,
        /**
         * A right angle bracket ('>').
         */
        CXCompletionChunk_RightAngle,
        /**
         * A comma separator (',').
         */
        CXCompletionChunk_Comma,
        /**
         * Text that specifies the result type of a given result.
         *
         * This special kind of informative chunk is not meant to be inserted into
         * the text buffer. Rather, it is meant to illustrate the type that an
         * expression using the given completion string would have.
         */
        CXCompletionChunk_ResultType,
        /**
         * A colon (':').
         */
        CXCompletionChunk_Colon,
        /**
         * A semicolon (';').
         */
        CXCompletionChunk_SemiColon,
        /**
         * An '=' sign.
         */
        CXCompletionChunk_Equal,
        /**
         * Horizontal space (' ').
         */
        CXCompletionChunk_HorizontalSpace,
        /**
         * Vertical space ('\\n'), after which it is generally a good idea to
         * perform indentation.
         */
        CXCompletionChunk_VerticalSpace
    }
}
