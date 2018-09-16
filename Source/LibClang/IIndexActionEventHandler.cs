namespace LibClang
{
    /// <summary>
    /// Defines the <see cref="IIndexActionEventHandler" />
    /// </summary>
    public interface IIndexActionEventHandler
    {
        /// <summary>
        /// The OnQueryAbort
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        bool OnQueryAbort();

        /// <summary>
        /// The OnDiagnostic
        /// </summary>
        /// <param name="diagnostics">The diagnostics<see cref="DiagnosticSet"/></param>
        void OnDiagnostic(ClangList<Diagnostic> diagnostics);

        /// <summary>
        /// The OnEnteredMainFile
        /// </summary>
        /// <param name="file">The file<see cref="File"/></param>
        /// <returns>The <see cref="File"/></returns>
        File OnEnteredMainFile(File file);

        /// <summary>
        /// The OnIncludeFile
        /// </summary>
        /// <param name="indexIncludedFileInfo">The indexIncludedFileInfo<see cref="IndexIncludedFileInfo"/></param>
        /// <returns>The <see cref="File"/></returns>
        File OnIncludeFile(IndexIncludedFileInfo indexIncludedFileInfo);

        /// <summary>
        /// The OnIndexDeclaration
        /// </summary>
        /// <param name="indexDeclInfo">The indexDeclInfo<see cref="IndexDeclInfo"/></param>
        void OnIndexDeclaration(IndexDeclInfo indexDeclInfo);

        /// <summary>
        /// The OnIndexEntityRefInfo
        /// </summary>
        /// <param name="indexEntityRefInfo">The indexEntityRefInfo<see cref="IndexEntityRefInfo"/></param>
        void OnIndexEntityRefInfo(IndexEntityRefInfo indexEntityRefInfo);

        /// <summary>
        /// The OnStartTranslationUnit
        /// </summary>
        void OnStartTranslationUnit();
    }
}
