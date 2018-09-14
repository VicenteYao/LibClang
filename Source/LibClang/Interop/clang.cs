namespace LibClang.Intertop
{
    using System;
    using System.Runtime.InteropServices;
    using CXClientData = System.IntPtr;
    using CXCompletionString = System.IntPtr;
    using CXCursorSet = System.IntPtr;
    using CXDiagnostic = System.IntPtr;
    using CXDiagnosticSet = System.IntPtr;
    using CXEvalResult = System.IntPtr;
    using CXFile = System.IntPtr;
    using CXIdxClientContainer = System.IntPtr;
    using CXIdxClientEntity = System.IntPtr;
    using CXIdxClientFile = System.IntPtr;
    using CXIndex = System.IntPtr;
    using CXIndexAction = System.IntPtr;
    using CXModule = System.IntPtr;
    using CXPrintingPolicy = System.IntPtr;
    using CXRemapping = System.IntPtr;
    using CXTargetInfo = System.IntPtr;
    using CXTranslationUnit = System.IntPtr;

    /// <summary>
    /// Defines the <see cref="clang" />
    /// </summary>
    internal static unsafe class clang
    {
        /// <summary>
        /// Defines the Lib
        /// </summary>
        private const string Lib = "LibClang.dll";

        /// <summary>
        /// The clang_getCString
        /// </summary>
        /// <param name="cxString">The cxString<see cref="CXString"/></param>
        /// <returns>The <see cref="sbyte*"/></returns>
        [DllImport(Lib)] internal static unsafe extern sbyte* clang_getCString(CXString cxString);

        /// <summary>
        /// The clang_disposeString
        /// </summary>
        /// <param name="cxString">The cxString<see cref="CXString"/></param>
        [DllImport(Lib)] internal static extern void clang_disposeString(CXString cxString);

        /// <summary>
        /// The clang_disposeStringSet
        /// </summary>
        /// <param name="set">The set<see cref="CXStringSet*"/></param>
        [DllImport(Lib)] internal static extern void clang_disposeStringSet(CXStringSet* set);

        /// <summary>
        /// The clang_createIndex
        /// </summary>
        /// <param name="excludeDeclarationsFromPCH">The excludeDeclarationsFromPCH<see cref="int"/></param>
        /// <param name="displayDiagnostics">The displayDiagnostics<see cref="int"/></param>
        /// <returns>The <see cref="CXIndex"/></returns>
        [DllImport(Lib)]
        internal static extern CXIndex clang_createIndex(int excludeDeclarationsFromPCH,
                                                int displayDiagnostics);

        /// <summary>
        /// The clang_disposeIndex
        /// </summary>
        /// <param name="index">The index<see cref="CXIndex"/></param>
        [DllImport(Lib)] internal static extern void clang_disposeIndex(CXIndex index);

        /// <summary>
        /// The clang_CXIndex_setGlobalOptions
        /// </summary>
        /// <param name="index">The index<see cref="CXIndex"/></param>
        /// <param name="options">The options<see cref="uint"/></param>
        [DllImport(Lib)] internal static extern void clang_CXIndex_setGlobalOptions(CXIndex index, uint options);

        /// <summary>
        /// The clang_CXIndex_getGlobalOptions
        /// </summary>
        /// <param name="index">The index<see cref="CXIndex"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_CXIndex_getGlobalOptions(CXIndex index);

        /// <summary>
        /// The clang_CXIndex_setInvocationEmissionPathOption
        /// </summary>
        /// <param name="index">The index<see cref="CXIndex"/></param>
        /// <param name="Path">The Path<see cref="string"/></param>
        [DllImport(Lib)]
        internal static extern void clang_CXIndex_setInvocationEmissionPathOption(CXIndex index, string Path);

        /// <summary>
        /// The clang_getFileName
        /// </summary>
        /// <param name="SFile">The SFile<see cref="CXFile"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)] internal static extern CXString clang_getFileName(CXFile SFile);

        /// <summary>
        /// The clang_getFileTime
        /// </summary>
        /// <param name="SFile">The SFile<see cref="CXFile"/></param>
        /// <returns>The <see cref="ulong"/></returns>
        [DllImport(Lib)] internal static extern ulong clang_getFileTime(CXFile SFile);

        /// <summary>
        /// The clang_getFileUniqueID
        /// </summary>
        /// <param name="file">The file<see cref="CXFile"/></param>
        /// <param name="outID">The outID<see cref="CXFileUniqueID"/></param>
        /// <returns>The <see cref="int"/></returns>
        [DllImport(Lib)] internal static extern int clang_getFileUniqueID(CXFile file, out CXFileUniqueID outID);

        /// <summary>
        /// The clang_isFileMultipleIncludeGuarded
        /// </summary>
        /// <param name="tu">The tu<see cref="CXTranslationUnit"/></param>
        /// <param name="file">The file<see cref="CXFile"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_isFileMultipleIncludeGuarded(CXTranslationUnit tu, CXFile file);

        /// <summary>
        /// The clang_getFile
        /// </summary>
        /// <param name="tu">The tu<see cref="CXTranslationUnit"/></param>
        /// <param name="file_name">The file_name<see cref="string"/></param>
        /// <returns>The <see cref="CXFile"/></returns>
        [DllImport(Lib)] internal static extern CXFile clang_getFile(CXTranslationUnit tu, string file_name);

        /// <summary>
        /// The clang_getFileContents
        /// </summary>
        /// <param name="tu">The tu<see cref="CXTranslationUnit"/></param>
        /// <param name="file">The file<see cref="CXFile"/></param>
        /// <param name="size">The size<see cref="uint"/></param>
        /// <returns>The <see cref="sbyte*"/></returns>
        [DllImport(Lib)]
        internal static extern sbyte* clang_getFileContents(CXTranslationUnit tu, CXFile file, out uint size);

        /// <summary>
        /// The clang_File_isEqual
        /// </summary>
        /// <param name="file1">The file1<see cref="CXFile"/></param>
        /// <param name="file2">The file2<see cref="CXFile"/></param>
        /// <returns>The <see cref="int"/></returns>
        [DllImport(Lib)] internal static extern int clang_File_isEqual(CXFile file1, CXFile file2);

        /// <summary>
        /// The clang_File_tryGetRealPathName
        /// </summary>
        /// <param name="file">The file<see cref="CXFile"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)] internal static extern CXString clang_File_tryGetRealPathName(CXFile file);

        /// <summary>
        /// The clang_getNullLocation
        /// </summary>
        /// <returns>The <see cref="CXSourceLocation"/></returns>
        [DllImport(Lib)] internal static extern CXSourceLocation clang_getNullLocation();

        /// <summary>
        /// The clang_equalLocations
        /// </summary>
        /// <param name="loc1">The loc1<see cref="CXSourceLocation"/></param>
        /// <param name="loc2">The loc2<see cref="CXSourceLocation"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)]
        internal static extern uint clang_equalLocations(CXSourceLocation loc1, CXSourceLocation loc2);

        /// <summary>
        /// The clang_getLocation
        /// </summary>
        /// <param name="tu">The tu<see cref="CXTranslationUnit"/></param>
        /// <param name="file">The file<see cref="CXFile"/></param>
        /// <param name="line">The line<see cref="uint"/></param>
        /// <param name="column">The column<see cref="uint"/></param>
        /// <returns>The <see cref="CXSourceLocation"/></returns>
        [DllImport(Lib)]
        internal static extern CXSourceLocation clang_getLocation(CXTranslationUnit tu, CXFile file, uint line, uint column);

        /// <summary>
        /// The clang_getLocationForOffset
        /// </summary>
        /// <param name="tu">The tu<see cref="CXTranslationUnit"/></param>
        /// <param name="file">The file<see cref="CXFile"/></param>
        /// <param name="offset">The offset<see cref="uint"/></param>
        /// <returns>The <see cref="CXSourceLocation"/></returns>
        [DllImport(Lib)]
        internal static extern CXSourceLocation clang_getLocationForOffset(CXTranslationUnit tu, CXFile file, uint offset);

        /// <summary>
        /// The clang_Location_isInSystemHeader
        /// </summary>
        /// <param name="location">The location<see cref="CXSourceLocation"/></param>
        /// <returns>The <see cref="int"/></returns>
        [DllImport(Lib)] internal static extern int clang_Location_isInSystemHeader(CXSourceLocation location);

        /// <summary>
        /// The clang_Location_isFromMainFile
        /// </summary>
        /// <param name="location">The location<see cref="CXSourceLocation"/></param>
        /// <returns>The <see cref="int"/></returns>
        [DllImport(Lib)] internal static extern int clang_Location_isFromMainFile(CXSourceLocation location);

        /// <summary>
        /// The clang_getNullRange
        /// </summary>
        /// <returns>The <see cref="CXSourceRange"/></returns>
        [DllImport(Lib)] internal static extern CXSourceRange clang_getNullRange();

        /// <summary>
        /// The clang_getRange
        /// </summary>
        /// <param name="begin">The begin<see cref="CXSourceLocation"/></param>
        /// <param name="end">The end<see cref="CXSourceLocation"/></param>
        /// <returns>The <see cref="CXSourceRange"/></returns>
        [DllImport(Lib)] internal static extern CXSourceRange clang_getRange(CXSourceLocation begin, CXSourceLocation end);

        /// <summary>
        /// The clang_equalRanges
        /// </summary>
        /// <param name="range1">The range1<see cref="CXSourceRange"/></param>
        /// <param name="range2">The range2<see cref="CXSourceRange"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_equalRanges(CXSourceRange range1, CXSourceRange range2);

        /// <summary>
        /// The clang_Range_isNull
        /// </summary>
        /// <param name="range">The range<see cref="CXSourceRange"/></param>
        /// <returns>The <see cref="int"/></returns>
        [DllImport(Lib)] internal static extern int clang_Range_isNull(CXSourceRange range);

        /// <summary>
        /// The clang_getExpansionLocation
        /// </summary>
        /// <param name="location">The location<see cref="CXSourceLocation"/></param>
        /// <param name="file">The file<see cref="CXFile"/></param>
        /// <param name="line">The line<see cref="uint"/></param>
        /// <param name="column">The column<see cref="uint"/></param>
        /// <param name="offset">The offset<see cref="uint"/></param>
        [DllImport(Lib)]
        internal static extern void clang_getExpansionLocation(CXSourceLocation location,
                                                      out CXFile file,
                                                      out uint line,
                                                      out uint column,
                                                      out uint offset);

        /// <summary>
        /// The clang_getPresumedLocation
        /// </summary>
        /// <param name="location">The location<see cref="CXSourceLocation"/></param>
        /// <param name="filename">The filename<see cref="CXString"/></param>
        /// <param name="line">The line<see cref="uint"/></param>
        /// <param name="column">The column<see cref="uint"/></param>
        [DllImport(Lib)]
        internal static extern void clang_getPresumedLocation(CXSourceLocation location,
                                                     out CXString filename,
                                                     out uint line,
                                                     out uint column);

        /// <summary>
        /// The clang_getInstantiationLocation
        /// </summary>
        /// <param name="location">The location<see cref="CXSourceLocation"/></param>
        /// <param name="file">The file<see cref="CXFile"/></param>
        /// <param name="line">The line<see cref="uint"/></param>
        /// <param name="column">The column<see cref="uint"/></param>
        /// <param name="offset">The offset<see cref="uint"/></param>
        [DllImport(Lib)]
        internal static extern void clang_getInstantiationLocation(CXSourceLocation location,
                                                          out CXFile file,
                                                          out uint line,
                                                          out uint column,
                                                          out uint offset);

        /// <summary>
        /// The clang_getSpellingLocation
        /// </summary>
        /// <param name="location">The location<see cref="CXSourceLocation"/></param>
        /// <param name="file">The file<see cref="CXFile"/></param>
        /// <param name="line">The line<see cref="uint"/></param>
        /// <param name="column">The column<see cref="uint"/></param>
        /// <param name="offset">The offset<see cref="uint"/></param>
        [DllImport(Lib)]
        internal static extern void clang_getSpellingLocation(CXSourceLocation location,
                                                     out CXFile file,
                                                     out uint line,
                                                     out uint column,
                                                     out uint offset);

        /// <summary>
        /// The clang_getFileLocation
        /// </summary>
        /// <param name="location">The location<see cref="CXSourceLocation"/></param>
        /// <param name="file">The file<see cref="CXFile"/></param>
        /// <param name="line">The line<see cref="uint"/></param>
        /// <param name="column">The column<see cref="uint"/></param>
        /// <param name="offset">The offset<see cref="uint"/></param>
        [DllImport(Lib)]
        internal static extern void clang_getFileLocation(CXSourceLocation location,
                                                 out CXFile file,
                                                 out uint line,
                                                 out uint column,
                                                 out uint offset);

        /// <summary>
        /// The clang_getRangeStart
        /// </summary>
        /// <param name="range">The range<see cref="CXSourceRange"/></param>
        /// <returns>The <see cref="CXSourceLocation"/></returns>
        [DllImport(Lib)] internal static extern CXSourceLocation clang_getRangeStart(CXSourceRange range);

        /// <summary>
        /// The clang_getRangeEnd
        /// </summary>
        /// <param name="range">The range<see cref="CXSourceRange"/></param>
        /// <returns>The <see cref="CXSourceLocation"/></returns>
        [DllImport(Lib)] internal static extern CXSourceLocation clang_getRangeEnd(CXSourceRange range);

        /// <summary>
        /// The clang_getSkippedRanges
        /// </summary>
        /// <param name="tu">The tu<see cref="CXTranslationUnit"/></param>
        /// <param name="file">The file<see cref="CXFile"/></param>
        /// <returns>The <see cref="IntPtr"/></returns>
        [DllImport(Lib)]
        internal static extern /*CXSourceRangeList*/IntPtr clang_getSkippedRanges(CXTranslationUnit tu,
                                                                CXFile file);

        /// <summary>
        /// The clang_getAllSkippedRanges
        /// </summary>
        /// <param name="tu">The tu<see cref="CXTranslationUnit"/></param>
        /// <returns>The <see cref="IntPtr"/></returns>
        [DllImport(Lib)] internal static extern /*CXSourceRangeList*/IntPtr clang_getAllSkippedRanges(CXTranslationUnit tu);

        /// <summary>
        /// The clang_disposeSourceRangeList
        /// </summary>
        /// <param name="ranges">The ranges<see cref="IntPtr"/></param>
        [DllImport(Lib)] internal static extern void clang_disposeSourceRangeList(/*CXSourceRangeList*/IntPtr ranges);

        /// <summary>
        /// The clang_getNumDiagnosticsInSet
        /// </summary>
        /// <param name="Diags">The Diags<see cref="CXDiagnosticSet"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_getNumDiagnosticsInSet(CXDiagnosticSet Diags);

        /// <summary>
        /// The clang_getDiagnosticInSet
        /// </summary>
        /// <param name="Diags">The Diags<see cref="CXDiagnosticSet"/></param>
        /// <param name="Index">The Index<see cref="uint"/></param>
        /// <returns>The <see cref="CXDiagnostic"/></returns>
        [DllImport(Lib)]
        internal static extern CXDiagnostic clang_getDiagnosticInSet(CXDiagnosticSet Diags,
                                                            uint Index);

        /// <summary>
        /// The clang_loadDiagnostics
        /// </summary>
        /// <param name="file">The file<see cref="string"/></param>
        /// <param name="error">The error<see cref="CXLoadDiag_Error"/></param>
        /// <param name="errorString">The errorString<see cref="CXString"/></param>
        /// <returns>The <see cref="CXDiagnosticSet"/></returns>
        [DllImport(Lib)]
        internal static extern CXDiagnosticSet clang_loadDiagnostics(string file,
                                                          out CXLoadDiag_Error error,
                                                         out CXString errorString);

        /// <summary>
        /// The clang_disposeDiagnosticSet
        /// </summary>
        /// <param name="Diags">The Diags<see cref="CXDiagnosticSet"/></param>
        [DllImport(Lib)] internal static extern void clang_disposeDiagnosticSet(CXDiagnosticSet Diags);

        /// <summary>
        /// The clang_getChildDiagnostics
        /// </summary>
        /// <param name="D">The D<see cref="CXDiagnostic"/></param>
        /// <returns>The <see cref="CXDiagnosticSet"/></returns>
        [DllImport(Lib)] internal static extern CXDiagnosticSet clang_getChildDiagnostics(CXDiagnostic D);

        /// <summary>
        /// The clang_getNumDiagnostics
        /// </summary>
        /// <param name="Unit">The Unit<see cref="CXTranslationUnit"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_getNumDiagnostics(CXTranslationUnit Unit);

        /// <summary>
        /// The clang_getDiagnostic
        /// </summary>
        /// <param name="Unit">The Unit<see cref="CXTranslationUnit"/></param>
        /// <param name="Index">The Index<see cref="uint"/></param>
        /// <returns>The <see cref="CXDiagnostic"/></returns>
        [DllImport(Lib)]
        internal static extern CXDiagnostic clang_getDiagnostic(CXTranslationUnit Unit,
                                                       uint Index);

        /// <summary>
        /// The clang_getDiagnosticSetFromTU
        /// </summary>
        /// <param name="Unit">The Unit<see cref="CXTranslationUnit"/></param>
        /// <returns>The <see cref="CXDiagnosticSet"/></returns>
        [DllImport(Lib)]
        internal static extern CXDiagnosticSet clang_getDiagnosticSetFromTU(CXTranslationUnit Unit);

        /// <summary>
        /// The clang_disposeDiagnostic
        /// </summary>
        /// <param name="Diagnostic">The Diagnostic<see cref="CXDiagnostic"/></param>
        [DllImport(Lib)] internal static extern void clang_disposeDiagnostic(CXDiagnostic Diagnostic);

        /// <summary>
        /// The clang_formatDiagnostic
        /// </summary>
        /// <param name="Diagnostic">The Diagnostic<see cref="CXDiagnostic"/></param>
        /// <param name="Options">The Options<see cref="uint"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)]
        internal static extern CXString clang_formatDiagnostic(CXDiagnostic Diagnostic,
                                                      uint Options);

        /// <summary>
        /// The clang_defaultDiagnosticDisplayOptions
        /// </summary>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_defaultDiagnosticDisplayOptions();

        /// <summary>
        /// The clang_getDiagnosticSeverity
        /// </summary>
        /// <param name="CXDiagnostic">The CXDiagnostic<see cref="CXDiagnostic"/></param>
        /// <returns>The <see cref="CXDiagnosticSeverity"/></returns>
        [DllImport(Lib)]
        internal static extern CXDiagnosticSeverity clang_getDiagnosticSeverity(CXDiagnostic CXDiagnostic);

        /// <summary>
        /// The clang_getDiagnosticLocation
        /// </summary>
        /// <param name="diagnostic">The diagnostic<see cref="CXDiagnostic"/></param>
        /// <returns>The <see cref="CXSourceLocation"/></returns>
        [DllImport(Lib)] internal static extern CXSourceLocation clang_getDiagnosticLocation(CXDiagnostic diagnostic);

        /// <summary>
        /// The clang_getDiagnosticSpelling
        /// </summary>
        /// <param name="diagnostic">The diagnostic<see cref="CXDiagnostic"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)] internal static extern CXString clang_getDiagnosticSpelling(CXDiagnostic diagnostic);

        /// <summary>
        /// The clang_getDiagnosticOption
        /// </summary>
        /// <param name="Diag">The Diag<see cref="CXDiagnostic"/></param>
        /// <param name="Disable">The Disable<see cref="CXString"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)]
        internal static extern CXString clang_getDiagnosticOption(CXDiagnostic Diag,
                                                         out CXString Disable);

        /// <summary>
        /// The clang_getDiagnosticCategory
        /// </summary>
        /// <param name="diagnostic">The diagnostic<see cref="CXDiagnostic"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_getDiagnosticCategory(CXDiagnostic diagnostic);

        /// <summary>
        /// The clang_getDiagnosticCategoryName
        /// </summary>
        /// <param name="Category">The Category<see cref="uint"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [Obsolete]
        [DllImport(Lib)] internal static extern CXString clang_getDiagnosticCategoryName(uint Category);

        /// <summary>
        /// The clang_getDiagnosticCategoryText
        /// </summary>
        /// <param name="diagnostic">The diagnostic<see cref="CXDiagnostic"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)] internal static extern CXString clang_getDiagnosticCategoryText(CXDiagnostic diagnostic);

        /// <summary>
        /// The clang_getDiagnosticNumRanges
        /// </summary>
        /// <param name="diagnostic">The diagnostic<see cref="CXDiagnostic"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_getDiagnosticNumRanges(CXDiagnostic diagnostic);

        /// <summary>
        /// The clang_getDiagnosticRange
        /// </summary>
        /// <param name="Diagnostic">The Diagnostic<see cref="CXDiagnostic"/></param>
        /// <param name="Range">The Range<see cref="uint"/></param>
        /// <returns>The <see cref="CXSourceRange"/></returns>
        [DllImport(Lib)]
        internal static extern CXSourceRange clang_getDiagnosticRange(CXDiagnostic Diagnostic,
                                                             uint Range);

        /// <summary>
        /// The clang_getDiagnosticNumFixIts
        /// </summary>
        /// <param name="Diagnostic">The Diagnostic<see cref="CXDiagnostic"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_getDiagnosticNumFixIts(CXDiagnostic Diagnostic);

        /// <summary>
        /// The clang_getDiagnosticFixIt
        /// </summary>
        /// <param name="Diagnostic">The Diagnostic<see cref="CXDiagnostic"/></param>
        /// <param name="FixIt">The FixIt<see cref="uint"/></param>
        /// <param name="ReplacementRange">The ReplacementRange<see cref="CXSourceRange"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)]
        internal static extern CXString clang_getDiagnosticFixIt(CXDiagnostic Diagnostic,
                                                        uint FixIt,
                                                      out CXSourceRange ReplacementRange);

        /// <summary>
        /// The clang_getTranslationUnitSpelling
        /// </summary>
        /// <param name="CTUnit">The CTUnit<see cref="CXTranslationUnit"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)]
        internal static extern CXString clang_getTranslationUnitSpelling(CXTranslationUnit CTUnit);

        /// <summary>
        /// The clang_createTranslationUnitFromSourceFile
        /// </summary>
        /// <param name="CIdx">The CIdx<see cref="CXIndex"/></param>
        /// <param name="source_filename">The source_filename<see cref="string"/></param>
        /// <param name="num_clang_command_line_args">The num_clang_command_line_args<see cref="int"/></param>
        /// <param name="clang_command_line_args">The clang_command_line_args<see cref="string[]"/></param>
        /// <param name="num_unsaved_files">The num_unsaved_files<see cref="uint"/></param>
        /// <param name="unsaved_files">The unsaved_files<see cref="CXUnsavedFile[]"/></param>
        /// <returns>The <see cref="CXTranslationUnit"/></returns>
        [DllImport(Lib)]
        internal static extern CXTranslationUnit clang_createTranslationUnitFromSourceFile(
                                                CXIndex CIdx,
                                                string source_filename,
                                                int num_clang_command_line_args,
                                          string[] clang_command_line_args,
                                                uint num_unsaved_files,
                                                 CXUnsavedFile[] unsaved_files);

        /// <summary>
        /// The clang_createTranslationUnit
        /// </summary>
        /// <param name="CIdx">The CIdx<see cref="CXIndex"/></param>
        /// <param name="ast_filename">The ast_filename<see cref="string"/></param>
        /// <returns>The <see cref="CXTranslationUnit"/></returns>
        [DllImport(Lib)]
        internal static extern CXTranslationUnit clang_createTranslationUnit(
           CXIndex CIdx,
           string ast_filename);

        /// <summary>
        /// The clang_createTranslationUnit2
        /// </summary>
        /// <param name="CIdx">The CIdx<see cref="CXIndex"/></param>
        /// <param name="ast_filename">The ast_filename<see cref="string"/></param>
        /// <param name="out_TU">The out_TU<see cref="CXTranslationUnit"/></param>
        /// <returns>The <see cref="CXErrorCode"/></returns>
        [DllImport(Lib)]
        internal static extern CXErrorCode clang_createTranslationUnit2(
           CXIndex CIdx,
           string ast_filename,
           out CXTranslationUnit out_TU);

        /// <summary>
        /// The clang_defaultEditingTranslationUnitOptions
        /// </summary>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_defaultEditingTranslationUnitOptions();

        /// <summary>
        /// The clang_parseTranslationUnit
        /// </summary>
        /// <param name="CIdx">The CIdx<see cref="CXIndex"/></param>
        /// <param name="source_filename">The source_filename<see cref="string"/></param>
        /// <param name="command_line_args">The command_line_args<see cref="string[]"/></param>
        /// <param name="num_command_line_args">The num_command_line_args<see cref="int"/></param>
        /// <param name="unsaved_files">The unsaved_files<see cref="CXUnsavedFile[]"/></param>
        /// <param name="num_unsaved_files">The num_unsaved_files<see cref="uint"/></param>
        /// <param name="options">The options<see cref="uint"/></param>
        /// <returns>The <see cref="CXTranslationUnit"/></returns>
        [DllImport(Lib)]
        internal static extern CXTranslationUnit
       clang_parseTranslationUnit(CXIndex CIdx,
                                  string source_filename,
                                  string[] command_line_args,
                                  int num_command_line_args,
                                  CXUnsavedFile[] unsaved_files,
                                  uint num_unsaved_files,
                                  uint options);

        /// <summary>
        /// The clang_parseTranslationUnit2
        /// </summary>
        /// <param name="CIdx">The CIdx<see cref="CXIndex"/></param>
        /// <param name="source_filename">The source_filename<see cref="string"/></param>
        /// <param name="command_line_args">The command_line_args<see cref="string[]"/></param>
        /// <param name="num_command_line_args">The num_command_line_args<see cref="int"/></param>
        /// <param name="unsaved_files">The unsaved_files<see cref="CXUnsavedFile[]"/></param>
        /// <param name="num_unsaved_files">The num_unsaved_files<see cref="uint"/></param>
        /// <param name="options">The options<see cref="uint"/></param>
        /// <param name="out_TU">The out_TU<see cref="CXTranslationUnit"/></param>
        /// <returns>The <see cref="CXErrorCode"/></returns>
        [DllImport(Lib)]
        internal static extern CXErrorCode
       clang_parseTranslationUnit2(CXIndex CIdx,
                                   string source_filename,
                                   string[] command_line_args,
                                   int num_command_line_args,
                                   CXUnsavedFile[] unsaved_files,
                                   uint num_unsaved_files,
                                   uint options,
                                   out CXTranslationUnit out_TU);

        /// <summary>
        /// The clang_parseTranslationUnit2FullArgv
        /// </summary>
        /// <param name="CIdx">The CIdx<see cref="CXIndex"/></param>
        /// <param name="source_filename">The source_filename<see cref="string"/></param>
        /// <param name="command_line_args">The command_line_args<see cref="string[]"/></param>
        /// <param name="num_command_line_args">The num_command_line_args<see cref="int"/></param>
        /// <param name="unsaved_files">The unsaved_files<see cref="CXUnsavedFile[]"/></param>
        /// <param name="num_unsaved_files">The num_unsaved_files<see cref="uint"/></param>
        /// <param name="options">The options<see cref="uint"/></param>
        /// <param name="out_TU">The out_TU<see cref="CXTranslationUnit"/></param>
        /// <returns>The <see cref="CXErrorCode"/></returns>
        [DllImport(Lib)]
        internal static extern CXErrorCode clang_parseTranslationUnit2FullArgv(
           CXIndex CIdx, string source_filename,
           string[] command_line_args, int num_command_line_args,
           CXUnsavedFile[] unsaved_files, uint num_unsaved_files,
           uint options, out CXTranslationUnit out_TU);

        /// <summary>
        /// The clang_defaultSaveOptions
        /// </summary>
        /// <param name="TU">The TU<see cref="CXTranslationUnit"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_defaultSaveOptions(CXTranslationUnit TU);

        /// <summary>
        /// The clang_saveTranslationUnit
        /// </summary>
        /// <param name="TU">The TU<see cref="CXTranslationUnit"/></param>
        /// <param name="FileName">The FileName<see cref="string"/></param>
        /// <param name="options">The options<see cref="uint"/></param>
        /// <returns>The <see cref="int"/></returns>
        [DllImport(Lib)]
        internal static extern int clang_saveTranslationUnit(CXTranslationUnit TU,
                                                    string FileName,
                                                    uint options);

        /// <summary>
        /// The clang_suspendTranslationUnit
        /// </summary>
        /// <param name="cXTranslationUnit">The cXTranslationUnit<see cref="CXTranslationUnit"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_suspendTranslationUnit(CXTranslationUnit cXTranslationUnit);

        /// <summary>
        /// The clang_disposeTranslationUnit
        /// </summary>
        /// <param name="cXTranslationUnit">The cXTranslationUnit<see cref="CXTranslationUnit"/></param>
        [DllImport(Lib)] internal static extern void clang_disposeTranslationUnit(CXTranslationUnit cXTranslationUnit);

        /// <summary>
        /// The clang_defaultReparseOptions
        /// </summary>
        /// <param name="TU">The TU<see cref="CXTranslationUnit"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_defaultReparseOptions(CXTranslationUnit TU);

        /// <summary>
        /// The clang_reparseTranslationUnit
        /// </summary>
        /// <param name="TU">The TU<see cref="CXTranslationUnit"/></param>
        /// <param name="num_unsaved_files">The num_unsaved_files<see cref="uint"/></param>
        /// <param name="unsaved_files">The unsaved_files<see cref="CXUnsavedFile[]"/></param>
        /// <param name="options">The options<see cref="uint"/></param>
        /// <returns>The <see cref="int"/></returns>
        [DllImport(Lib)]
        internal static extern int clang_reparseTranslationUnit(CXTranslationUnit TU,
                                                       uint num_unsaved_files,
                                                  CXUnsavedFile[] unsaved_files,
                                                       uint options);

        /// <summary>
        /// The clang_getTUResourceUsageName
        /// </summary>
        /// <param name="kind">The kind<see cref="CXTUResourceUsageKind"/></param>
        /// <returns>The <see cref="IntPtr"/></returns>
        [DllImport(Lib)]
        internal static extern IntPtr clang_getTUResourceUsageName(CXTUResourceUsageKind kind);

        /// <summary>
        /// The clang_getCXTUResourceUsage
        /// </summary>
        /// <param name="TU">The TU<see cref="CXTranslationUnit"/></param>
        /// <returns>The <see cref="CXTUResourceUsage"/></returns>
        [DllImport(Lib)] internal static extern CXTUResourceUsage clang_getCXTUResourceUsage(CXTranslationUnit TU);

        /// <summary>
        /// The clang_disposeCXTUResourceUsage
        /// </summary>
        /// <param name="usage">The usage<see cref="CXTUResourceUsage"/></param>
        [DllImport(Lib)] internal static extern void clang_disposeCXTUResourceUsage(CXTUResourceUsage usage);

        /// <summary>
        /// The clang_getTranslationUnitTargetInfo
        /// </summary>
        /// <param name="CTUnit">The CTUnit<see cref="CXTranslationUnit"/></param>
        /// <returns>The <see cref="CXTargetInfo"/></returns>
        [DllImport(Lib)] internal static extern CXTargetInfo clang_getTranslationUnitTargetInfo(CXTranslationUnit CTUnit);

        /// <summary>
        /// The clang_TargetInfo_dispose
        /// </summary>
        /// <param name="Info">The Info<see cref="CXTargetInfo"/></param>
        [DllImport(Lib)] internal static extern void clang_TargetInfo_dispose(CXTargetInfo Info);

        /// <summary>
        /// The clang_TargetInfo_getTriple
        /// </summary>
        /// <param name="Info">The Info<see cref="CXTargetInfo"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)] internal static extern CXString clang_TargetInfo_getTriple(CXTargetInfo Info);

        /// <summary>
        /// The clang_TargetInfo_getPointerWidth
        /// </summary>
        /// <param name="Info">The Info<see cref="CXTargetInfo"/></param>
        /// <returns>The <see cref="int"/></returns>
        [DllImport(Lib)] internal static extern int clang_TargetInfo_getPointerWidth(CXTargetInfo Info);

        /// <summary>
        /// The clang_getNullCursor
        /// </summary>
        /// <returns>The <see cref="CXCursor"/></returns>
        [DllImport(Lib)] internal static extern CXCursor clang_getNullCursor();

        /// <summary>
        /// The clang_getTranslationUnitCursor
        /// </summary>
        /// <param name="cXTranslationUnit">The cXTranslationUnit<see cref="CXTranslationUnit"/></param>
        /// <returns>The <see cref="CXCursor"/></returns>
        [DllImport(Lib)] internal static extern CXCursor clang_getTranslationUnitCursor(CXTranslationUnit cXTranslationUnit);

        /// <summary>
        /// The clang_equalCursors
        /// </summary>
        /// <param name="cXCursor1">The cXCursor1<see cref="CXCursor"/></param>
        /// <param name="cXCursor2">The cXCursor2<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_equalCursors(CXCursor cXCursor1, CXCursor cXCursor2);

        /// <summary>
        /// The clang_Cursor_isNull
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="int"/></returns>
        [DllImport(Lib)] internal static extern int clang_Cursor_isNull(CXCursor cursor);

        /// <summary>
        /// The clang_hashCursor
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_hashCursor(CXCursor cursor);

        /// <summary>
        /// The clang_getCursorKind
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXCursorKind"/></returns>
        [DllImport(Lib)] internal static extern CXCursorKind clang_getCursorKind(CXCursor cursor);

        /// <summary>
        /// The clang_isDeclaration
        /// </summary>
        /// <param name="cXCursorKind">The cXCursorKind<see cref="CXCursorKind"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_isDeclaration(CXCursorKind cXCursorKind);

        /// <summary>
        /// The clang_isInvalidDeclaration
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_isInvalidDeclaration(CXCursor cursor);

        /// <summary>
        /// The clang_isReference
        /// </summary>
        /// <param name="cXCursorKind">The cXCursorKind<see cref="CXCursorKind"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_isReference(CXCursorKind cXCursorKind);

        /// <summary>
        /// The clang_isExpression
        /// </summary>
        /// <param name="cXCursorKind">The cXCursorKind<see cref="CXCursorKind"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_isExpression(CXCursorKind cXCursorKind);

        /// <summary>
        /// The clang_isStatement
        /// </summary>
        /// <param name="cXCursorKind">The cXCursorKind<see cref="CXCursorKind"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_isStatement(CXCursorKind cXCursorKind);

        /// <summary>
        /// The clang_isAttribute
        /// </summary>
        /// <param name="cXCursorKind">The cXCursorKind<see cref="CXCursorKind"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_isAttribute(CXCursorKind cXCursorKind);

        /// <summary>
        /// The clang_Cursor_hasAttrs
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_Cursor_hasAttrs(CXCursor C);

        /// <summary>
        /// The clang_isInvalid
        /// </summary>
        /// <param name="cXCursorKind">The cXCursorKind<see cref="CXCursorKind"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_isInvalid(CXCursorKind cXCursorKind);

        /// <summary>
        /// The clang_isTranslationUnit
        /// </summary>
        /// <param name="cXCursorKind">The cXCursorKind<see cref="CXCursorKind"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_isTranslationUnit(CXCursorKind cXCursorKind);

        /// <summary>
        /// The clang_isPreprocessing
        /// </summary>
        /// <param name="cXCursorKind">The cXCursorKind<see cref="CXCursorKind"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_isPreprocessing(CXCursorKind cXCursorKind);

        /// <summary>
        /// The clang_isUnexposed
        /// </summary>
        /// <param name="cXCursorKind">The cXCursorKind<see cref="CXCursorKind"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_isUnexposed(CXCursorKind cXCursorKind);

        /// <summary>
        /// The clang_getCursorLinkage
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXLinkageKind"/></returns>
        [DllImport(Lib)] internal static extern CXLinkageKind clang_getCursorLinkage(CXCursor cursor);

        /// <summary>
        /// The clang_getCursorVisibility
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXVisibilityKind"/></returns>
        [DllImport(Lib)] internal static extern CXVisibilityKind clang_getCursorVisibility(CXCursor cursor);

        /// <summary>
        /// The clang_getCursorAvailability
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXAvailabilityKind"/></returns>
        [DllImport(Lib)]
        internal static extern CXAvailabilityKind clang_getCursorAvailability(CXCursor cursor);

        /// <summary>
        /// The clang_getCursorPlatformAvailability
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <param name="always_deprecated">The always_deprecated<see cref="int"/></param>
        /// <param name="deprecated_message">The deprecated_message<see cref="CXString"/></param>
        /// <param name="always_unavailable">The always_unavailable<see cref="int"/></param>
        /// <param name="unavailable_message">The unavailable_message<see cref="CXString"/></param>
        /// <param name="availability">The availability<see cref="CXPlatformAvailability[]"/></param>
        /// <param name="availability_size">The availability_size<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        [DllImport(Lib)]
        internal static extern int
       clang_getCursorPlatformAvailability(CXCursor cursor,
                                           out int always_deprecated,
                                           out CXString deprecated_message,
                                           out int always_unavailable,
                                           out CXString unavailable_message,
                                           out CXPlatformAvailability[] availability,
                                           int availability_size);

        /// <summary>
        /// The clang_disposeCXPlatformAvailability
        /// </summary>
        /// <param name="availability">The availability<see cref="CXPlatformAvailability[]"/></param>
        [DllImport(Lib)]
        internal static extern void clang_disposeCXPlatformAvailability(CXPlatformAvailability[] availability);

        /// <summary>
        /// The clang_getCursorLanguage
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXLanguageKind"/></returns>
        [DllImport(Lib)] internal static extern CXLanguageKind clang_getCursorLanguage(CXCursor cursor);

        /// <summary>
        /// The clang_getCursorTLSKind
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXTLSKind"/></returns>
        [DllImport(Lib)] internal static extern CXTLSKind clang_getCursorTLSKind(CXCursor cursor);

        /// <summary>
        /// The clang_Cursor_getTranslationUnit
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXTranslationUnit"/></returns>
        [DllImport(Lib)] internal static extern CXTranslationUnit clang_Cursor_getTranslationUnit(CXCursor cursor);

        /// <summary>
        /// The clang_createCXCursorSet
        /// </summary>
        /// <returns>The <see cref="CXCursorSet"/></returns>
        [DllImport(Lib)] internal static extern CXCursorSet clang_createCXCursorSet();

        /// <summary>
        /// The clang_disposeCXCursorSet
        /// </summary>
        /// <param name="cset">The cset<see cref="CXCursorSet"/></param>
        [DllImport(Lib)] internal static extern void clang_disposeCXCursorSet(CXCursorSet cset);

        /// <summary>
        /// The clang_CXCursorSet_contains
        /// </summary>
        /// <param name="cset">The cset<see cref="CXCursorSet"/></param>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)]
        internal static extern uint clang_CXCursorSet_contains(CXCursorSet cset,
                                                          CXCursor cursor);

        /// <summary>
        /// The clang_CXCursorSet_insert
        /// </summary>
        /// <param name="cset">The cset<see cref="CXCursorSet"/></param>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)]
        internal static extern uint clang_CXCursorSet_insert(CXCursorSet cset,
                                                        CXCursor cursor);

        /// <summary>
        /// The clang_getCursorSemanticParent
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXCursor"/></returns>
        [DllImport(Lib)] internal static extern CXCursor clang_getCursorSemanticParent(CXCursor cursor);

        /// <summary>
        /// The clang_getCursorLexicalParent
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXCursor"/></returns>
        [DllImport(Lib)] internal static extern CXCursor clang_getCursorLexicalParent(CXCursor cursor);

        /// <summary>
        /// The clang_getOverriddenCursors
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <param name="overridden">The overridden<see cref="CXCursor*"/></param>
        /// <param name="num_overridden">The num_overridden<see cref="uint"/></param>
        [DllImport(Lib)]
        internal static extern void clang_getOverriddenCursors(CXCursor cursor,
                                                      out CXCursor* overridden,
                                                      out uint num_overridden);

        /// <summary>
        /// The clang_disposeOverriddenCursors
        /// </summary>
        /// <param name="overridden">The overridden<see cref="CXCursor*"/></param>
        [DllImport(Lib)] internal static extern void clang_disposeOverriddenCursors(CXCursor* overridden);

        /// <summary>
        /// The clang_getIncludedFile
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXFile"/></returns>
        [DllImport(Lib)] internal static extern CXFile clang_getIncludedFile(CXCursor cursor);

        /// <summary>
        /// The clang_getCursor
        /// </summary>
        /// <param name="cXTranslationUnit">The cXTranslationUnit<see cref="CXTranslationUnit"/></param>
        /// <param name="cXSourceLocation">The cXSourceLocation<see cref="CXSourceLocation"/></param>
        /// <returns>The <see cref="CXCursor"/></returns>
        [DllImport(Lib)] internal static extern CXCursor clang_getCursor(CXTranslationUnit cXTranslationUnit, CXSourceLocation cXSourceLocation);

        /// <summary>
        /// The clang_getCursorLocation
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXSourceLocation"/></returns>
        [DllImport(Lib)] internal static extern CXSourceLocation clang_getCursorLocation(CXCursor cursor);

        /// <summary>
        /// The clang_getCursorExtent
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXSourceRange"/></returns>
        [DllImport(Lib)] internal static extern CXSourceRange clang_getCursorExtent(CXCursor cursor);

        /// <summary>
        /// The clang_getCursorType
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXType"/></returns>
        [DllImport(Lib)] internal static extern CXType clang_getCursorType(CXCursor C);

        /// <summary>
        /// The clang_getTypeSpelling
        /// </summary>
        /// <param name="CT">The CT<see cref="CXType"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)] internal static extern CXString clang_getTypeSpelling(CXType CT);

        /// <summary>
        /// The clang_getTypedefDeclUnderlyingType
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXType"/></returns>
        [DllImport(Lib)] internal static extern CXType clang_getTypedefDeclUnderlyingType(CXCursor C);

        /// <summary>
        /// The clang_getEnumDeclIntegerType
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXType"/></returns>
        [DllImport(Lib)] internal static extern CXType clang_getEnumDeclIntegerType(CXCursor C);

        /// <summary>
        /// The clang_getEnumConstantDeclValue
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="long"/></returns>
        [DllImport(Lib)] internal static extern long clang_getEnumConstantDeclValue(CXCursor C);

        /// <summary>
        /// The clang_getEnumConstantDecluintValue
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="ulong"/></returns>
        [DllImport(Lib)] internal static extern ulong clang_getEnumConstantDecluintValue(CXCursor C);

        /// <summary>
        /// The clang_getFieldDeclBitWidth
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="int"/></returns>
        [DllImport(Lib)] internal static extern int clang_getFieldDeclBitWidth(CXCursor C);

        /// <summary>
        /// The clang_Cursor_getNumArguments
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="int"/></returns>
        [DllImport(Lib)] internal static extern int clang_Cursor_getNumArguments(CXCursor C);

        /// <summary>
        /// The clang_Cursor_getArgument
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <param name="i">The i<see cref="uint"/></param>
        /// <returns>The <see cref="CXCursor"/></returns>
        [DllImport(Lib)] internal static extern CXCursor clang_Cursor_getArgument(CXCursor C, uint i);

        /// <summary>
        /// The clang_Cursor_getNumTemplateArguments
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="int"/></returns>
        [DllImport(Lib)] internal static extern int clang_Cursor_getNumTemplateArguments(CXCursor C);

        /// <summary>
        /// The clang_Cursor_getTemplateArgumentKind
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <param name="I">The I<see cref="uint"/></param>
        /// <returns>The <see cref="CXTemplateArgumentKind"/></returns>
        [DllImport(Lib)]
        internal static extern CXTemplateArgumentKind clang_Cursor_getTemplateArgumentKind(
           CXCursor C, uint I);

        /// <summary>
        /// The clang_Cursor_getTemplateArgumentType
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <param name="I">The I<see cref="uint"/></param>
        /// <returns>The <see cref="CXType"/></returns>
        [DllImport(Lib)]
        internal static extern CXType clang_Cursor_getTemplateArgumentType(CXCursor C,
                                                                  uint I);

        /// <summary>
        /// The clang_Cursor_getTemplateArgumentValue
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <param name="I">The I<see cref="uint"/></param>
        /// <returns>The <see cref="long"/></returns>
        [DllImport(Lib)]
        internal static extern long clang_Cursor_getTemplateArgumentValue(CXCursor C,
                                                                      uint I);

        /// <summary>
        /// The clang_Cursor_getTemplateArgumentuintValue
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <param name="I">The I<see cref="uint"/></param>
        /// <returns>The <see cref="ulong"/></returns>
        [DllImport(Lib)]
        internal static extern ulong clang_Cursor_getTemplateArgumentuintValue(
           CXCursor C, uint I);

        /// <summary>
        /// The clang_equalTypes
        /// </summary>
        /// <param name="A">The A<see cref="CXType"/></param>
        /// <param name="B">The B<see cref="CXType"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_equalTypes(CXType A, CXType B);

        /// <summary>
        /// The clang_getCanonicalType
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <returns>The <see cref="CXType"/></returns>
        [DllImport(Lib)] internal static extern CXType clang_getCanonicalType(CXType T);

        /// <summary>
        /// The clang_isConstQualifiedType
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_isConstQualifiedType(CXType T);

        /// <summary>
        /// The clang_Cursor_isMacroFunctionLike
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_Cursor_isMacroFunctionLike(CXCursor C);

        /// <summary>
        /// The clang_Cursor_isMacroBuiltin
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_Cursor_isMacroBuiltin(CXCursor C);

        /// <summary>
        /// The clang_Cursor_isFunctionInlined
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_Cursor_isFunctionInlined(CXCursor C);

        /// <summary>
        /// The clang_isVolatileQualifiedType
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_isVolatileQualifiedType(CXType T);

        /// <summary>
        /// The clang_isRestrictQualifiedType
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_isRestrictQualifiedType(CXType T);

        /// <summary>
        /// The clang_getAddressSpace
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_getAddressSpace(CXType T);

        /// <summary>
        /// The clang_getTypedefName
        /// </summary>
        /// <param name="CT">The CT<see cref="CXType"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)] internal static extern CXString clang_getTypedefName(CXType CT);

        /// <summary>
        /// The clang_getPointeeType
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <returns>The <see cref="CXType"/></returns>
        [DllImport(Lib)] internal static extern CXType clang_getPointeeType(CXType T);

        /// <summary>
        /// The clang_getTypeDeclaration
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <returns>The <see cref="CXCursor"/></returns>
        [DllImport(Lib)] internal static extern CXCursor clang_getTypeDeclaration(CXType T);

        /// <summary>
        /// The clang_getDeclObjCTypeEncoding
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)] internal static extern CXString clang_getDeclObjCTypeEncoding(CXCursor C);

        /// <summary>
        /// The clang_Type_getObjCEncoding
        /// </summary>
        /// <param name="type">The type<see cref="CXType"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)] internal static extern CXString clang_Type_getObjCEncoding(CXType type);

        /// <summary>
        /// The clang_getTypeKindSpelling
        /// </summary>
        /// <param name="K">The K<see cref="CXTypeKind"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)] internal static extern CXString clang_getTypeKindSpelling(CXTypeKind K);

        /// <summary>
        /// The clang_getFunctionTypeCallingConv
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <returns>The <see cref="CXCallingConv"/></returns>
        [DllImport(Lib)] internal static extern CXCallingConv clang_getFunctionTypeCallingConv(CXType T);

        /// <summary>
        /// The clang_getResultType
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <returns>The <see cref="CXType"/></returns>
        [DllImport(Lib)] internal static extern CXType clang_getResultType(CXType T);

        /// <summary>
        /// The clang_getExceptionSpecificationType
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <returns>The <see cref="int"/></returns>
        [DllImport(Lib)] internal static extern int clang_getExceptionSpecificationType(CXType T);

        /// <summary>
        /// The clang_getNumArgTypes
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <returns>The <see cref="int"/></returns>
        [DllImport(Lib)] internal static extern int clang_getNumArgTypes(CXType T);

        /// <summary>
        /// The clang_getArgType
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <param name="i">The i<see cref="uint"/></param>
        /// <returns>The <see cref="CXType"/></returns>
        [DllImport(Lib)] internal static extern CXType clang_getArgType(CXType T, uint i);

        /// <summary>
        /// The clang_isFunctionTypeVariadic
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_isFunctionTypeVariadic(CXType T);

        /// <summary>
        /// The clang_getCursorResultType
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXType"/></returns>
        [DllImport(Lib)] internal static extern CXType clang_getCursorResultType(CXCursor C);

        /// <summary>
        /// The clang_getCursorExceptionSpecificationType
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="int"/></returns>
        [DllImport(Lib)] internal static extern int clang_getCursorExceptionSpecificationType(CXCursor C);

        /// <summary>
        /// The clang_isPODType
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_isPODType(CXType T);

        /// <summary>
        /// The clang_getElementType
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <returns>The <see cref="CXType"/></returns>
        [DllImport(Lib)] internal static extern CXType clang_getElementType(CXType T);

        /// <summary>
        /// The clang_getNumElements
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <returns>The <see cref="long"/></returns>
        [DllImport(Lib)] internal static extern long clang_getNumElements(CXType T);

        /// <summary>
        /// The clang_getArrayElementType
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <returns>The <see cref="CXType"/></returns>
        [DllImport(Lib)] internal static extern CXType clang_getArrayElementType(CXType T);

        /// <summary>
        /// The clang_getArraySize
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <returns>The <see cref="long"/></returns>
        [DllImport(Lib)] internal static extern long clang_getArraySize(CXType T);

        /// <summary>
        /// The clang_Type_getNamedType
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <returns>The <see cref="CXType"/></returns>
        [DllImport(Lib)] internal static extern CXType clang_Type_getNamedType(CXType T);

        /// <summary>
        /// The clang_Type_isTransparentTagTypedef
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_Type_isTransparentTagTypedef(CXType T);

        /// <summary>
        /// The clang_Type_getAlignOf
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <returns>The <see cref="long"/></returns>
        [DllImport(Lib)] internal static extern long clang_Type_getAlignOf(CXType T);

        /// <summary>
        /// The clang_Type_getClassType
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <returns>The <see cref="CXType"/></returns>
        [DllImport(Lib)] internal static extern CXType clang_Type_getClassType(CXType T);

        /// <summary>
        /// The clang_Type_getSizeOf
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <returns>The <see cref="long"/></returns>
        [DllImport(Lib)] internal static extern long clang_Type_getSizeOf(CXType T);

        /// <summary>
        /// The clang_Type_getOffsetOf
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <param name="S">The S<see cref="string"/></param>
        /// <returns>The <see cref="long"/></returns>
        [DllImport(Lib)] internal static extern long clang_Type_getOffsetOf(CXType T, string S);

        /// <summary>
        /// The clang_Cursor_getOffsetOfField
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="long"/></returns>
        [DllImport(Lib)] internal static extern long clang_Cursor_getOffsetOfField(CXCursor C);

        /// <summary>
        /// The clang_Cursor_isAnonymous
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_Cursor_isAnonymous(CXCursor C);

        /// <summary>
        /// The clang_Type_getNumTemplateArguments
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <returns>The <see cref="int"/></returns>
        [DllImport(Lib)] internal static extern int clang_Type_getNumTemplateArguments(CXType T);

        /// <summary>
        /// The clang_Type_getTemplateArgumentAsType
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <param name="i">The i<see cref="uint"/></param>
        /// <returns>The <see cref="CXType"/></returns>
        [DllImport(Lib)] internal static extern CXType clang_Type_getTemplateArgumentAsType(CXType T, uint i);

        /// <summary>
        /// The clang_Type_getCXXRefQualifier
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <returns>The <see cref="CXRefQualifierKind"/></returns>
        [DllImport(Lib)] internal static extern CXRefQualifierKind clang_Type_getCXXRefQualifier(CXType T);

        /// <summary>
        /// The clang_Cursor_isBitField
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_Cursor_isBitField(CXCursor C);

        /// <summary>
        /// The clang_isVirtualBase
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_isVirtualBase(CXCursor cursor);

        /// <summary>
        /// The clang_getCXXAccessSpecifier
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CX_CXXAccessSpecifier"/></returns>
        [DllImport(Lib)] internal static extern CX_CXXAccessSpecifier clang_getCXXAccessSpecifier(CXCursor cursor);

        /// <summary>
        /// The clang_Cursor_getStorageClass
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CX_StorageClass"/></returns>
        [DllImport(Lib)] internal static extern CX_StorageClass clang_Cursor_getStorageClass(CXCursor cursor);

        /// <summary>
        /// The clang_getNumOverloadedDecls
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_getNumOverloadedDecls(CXCursor cursor);

        /// <summary>
        /// The clang_getOverloadedDecl
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <param name="index">The index<see cref="uint"/></param>
        /// <returns>The <see cref="CXCursor"/></returns>
        [DllImport(Lib)]
        internal static extern CXCursor clang_getOverloadedDecl(CXCursor cursor,
                                                       uint index);

        /// <summary>
        /// The clang_getIBOutletCollectionType
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXType"/></returns>
        [DllImport(Lib)] internal static extern CXType clang_getIBOutletCollectionType(CXCursor cursor);

        /**
         * Visitor invoked for each cursor found by a traversal.
         *
         * This visitor function will be invoked for each cursor found by
         * clang_visitCursorChildren(). Its first argument is the cursor being
         * visited, its second argument is the parent visitor for that cursor,
         * and its third argument is the client data provided to
         * clang_visitCursorChildren().
         *
         * The visitor should return one of the \c CXChildVisitResult values
         * to direct clang_visitCursorChildren().
         */
        public delegate CXChildVisitResult CXCursorVisitor(CXCursor cursor,
                                                             CXCursor parent,
                                                             CXClientData client_data);

        /// <summary>
        /// The clang_visitChildren
        /// </summary>
        /// <param name="parent">The parent<see cref="CXCursor"/></param>
        /// <param name="visitor">The visitor<see cref="CXCursorVisitor"/></param>
        /// <param name="client_data">The client_data<see cref="CXClientData"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)]
        internal static extern uint clang_visitChildren(CXCursor parent,
                                                   CXCursorVisitor visitor,
                                                   CXClientData client_data);

        /**
         * Visitor invoked for each cursor found by a traversal.
         *
         * This visitor block will be invoked for each cursor found by
         * clang_visitChildrenWithBlock(). Its first argument is the cursor being
         * visited, its second argument is the parent visitor for that cursor.
         *
         * The visitor should return one of the \c CXChildVisitResult values
         * to direct clang_visitChildrenWithBlock().
         */
        public delegate CXChildVisitResult CXCursorVisitorBlock(CXCursor cursor, CXCursor parent);

        /// <summary>
        /// The clang_visitChildrenWithBlock
        /// </summary>
        /// <param name="parent">The parent<see cref="CXCursor"/></param>
        /// <param name="block">The block<see cref="CXCursorVisitorBlock"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_visitChildrenWithBlock(CXCursor parent, CXCursorVisitorBlock block);

        /// <summary>
        /// The clang_getCursorUSR
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)] internal static extern CXString clang_getCursorUSR(CXCursor cursor);

        /// <summary>
        /// The clang_constructUSR_ObjCClass
        /// </summary>
        /// <param name="class_name">The class_name<see cref="string"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)] internal static extern CXString clang_constructUSR_ObjCClass(string class_name);

        /// <summary>
        /// The clang_constructUSR_ObjCCategory
        /// </summary>
        /// <param name="class_name">The class_name<see cref="string"/></param>
        /// <param name="category_name">The category_name<see cref="string"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)]
        internal static extern CXString
         clang_constructUSR_ObjCCategory(string class_name,
                                        string category_name);

        /// <summary>
        /// The clang_constructUSR_ObjCProtocol
        /// </summary>
        /// <param name="protocol_name">The protocol_name<see cref="string"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)]
        internal static extern CXString
         clang_constructUSR_ObjCProtocol(string protocol_name);

        /// <summary>
        /// The clang_constructUSR_ObjCIvar
        /// </summary>
        /// <param name="name">The name<see cref="string"/></param>
        /// <param name="classUSR">The classUSR<see cref="CXString"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)]
        internal static extern CXString clang_constructUSR_ObjCIvar(string name,
                                                           CXString classUSR);

        /// <summary>
        /// The clang_constructUSR_ObjCMethod
        /// </summary>
        /// <param name="name">The name<see cref="string"/></param>
        /// <param name="isInstanceMethod">The isInstanceMethod<see cref="uint"/></param>
        /// <param name="classUSR">The classUSR<see cref="CXString"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)]
        internal static extern CXString clang_constructUSR_ObjCMethod(string name,
                                                             uint isInstanceMethod,
                                                             CXString classUSR);

        /// <summary>
        /// The clang_constructUSR_ObjCProperty
        /// </summary>
        /// <param name="property">The property<see cref="string"/></param>
        /// <param name="classUSR">The classUSR<see cref="CXString"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)]
        internal static extern CXString clang_constructUSR_ObjCProperty(string property,
                                                               CXString classUSR);

        /// <summary>
        /// The clang_getCursorSpelling
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)] internal static extern CXString clang_getCursorSpelling(CXCursor cursor);

        /// <summary>
        /// The clang_Cursor_getSpellingNameRange
        /// </summary>
        /// <param name="cXCursor">The cXCursor<see cref="CXCursor"/></param>
        /// <param name="pieceIndex">The pieceIndex<see cref="uint"/></param>
        /// <param name="options">The options<see cref="uint"/></param>
        /// <returns>The <see cref="CXSourceRange"/></returns>
        [DllImport(Lib)]
        internal static extern CXSourceRange clang_Cursor_getSpellingNameRange(CXCursor cXCursor,
                                                                 uint pieceIndex,
                                                                 uint options);

        /// <summary>
        /// The clang_PrintingPolicy_getProperty
        /// </summary>
        /// <param name="Policy">The Policy<see cref="CXPrintingPolicy"/></param>
        /// <param name="Property">The Property<see cref="CXPrintingPolicyProperty"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)]
        internal static extern uint
       clang_PrintingPolicy_getProperty(CXPrintingPolicy Policy,
                                         CXPrintingPolicyProperty Property);

        /// <summary>
        /// The clang_PrintingPolicy_setProperty
        /// </summary>
        /// <param name="Policy">The Policy<see cref="CXPrintingPolicy"/></param>
        /// <param name="Property">The Property<see cref="CXPrintingPolicyProperty"/></param>
        /// <param name="Value">The Value<see cref="uint"/></param>
        [DllImport(Lib)]
        internal static extern void clang_PrintingPolicy_setProperty(CXPrintingPolicy Policy,
                                                             CXPrintingPolicyProperty Property,
                                                            uint Value);

        /// <summary>
        /// The clang_getCursorPrintingPolicy
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXPrintingPolicy"/></returns>
        [DllImport(Lib)] internal static extern CXPrintingPolicy clang_getCursorPrintingPolicy(CXCursor cursor);

        /// <summary>
        /// The clang_PrintingPolicy_dispose
        /// </summary>
        /// <param name="Policy">The Policy<see cref="CXPrintingPolicy"/></param>
        [DllImport(Lib)] internal static extern void clang_PrintingPolicy_dispose(CXPrintingPolicy Policy);

        /// <summary>
        /// The clang_getCursorPrettyPrinted
        /// </summary>
        /// <param name="Cursor">The Cursor<see cref="CXCursor"/></param>
        /// <param name="Policy">The Policy<see cref="CXPrintingPolicy"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)]
        internal static extern CXString clang_getCursorPrettyPrinted(CXCursor Cursor,
                                                            CXPrintingPolicy Policy);

        /// <summary>
        /// The clang_getCursorDisplayName
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)] internal static extern CXString clang_getCursorDisplayName(CXCursor cursor);

        /// <summary>
        /// The clang_getCursorReferenced
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXCursor"/></returns>
        [DllImport(Lib)] internal static extern CXCursor clang_getCursorReferenced(CXCursor cursor);

        /// <summary>
        /// The clang_getCursorDefinition
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXCursor"/></returns>
        [DllImport(Lib)] internal static extern CXCursor clang_getCursorDefinition(CXCursor cursor);

        /// <summary>
        /// The clang_isCursorDefinition
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_isCursorDefinition(CXCursor cursor);

        /// <summary>
        /// The clang_getCanonicalCursor
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXCursor"/></returns>
        [DllImport(Lib)] internal static extern CXCursor clang_getCanonicalCursor(CXCursor cursor);

        /// <summary>
        /// The clang_Cursor_getObjCSelectorIndex
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="int"/></returns>
        [DllImport(Lib)] internal static extern int clang_Cursor_getObjCSelectorIndex(CXCursor cursor);

        /// <summary>
        /// The clang_Cursor_isDynamicCall
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="int"/></returns>
        [DllImport(Lib)] internal static extern int clang_Cursor_isDynamicCall(CXCursor C);

        /// <summary>
        /// The clang_Cursor_getReceiverType
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXType"/></returns>
        [DllImport(Lib)] internal static extern CXType clang_Cursor_getReceiverType(CXCursor C);

        /// <summary>
        /// The clang_Cursor_getObjCPropertyAttributes
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <param name="reserved">The reserved<see cref="uint"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)]
        internal static extern uint clang_Cursor_getObjCPropertyAttributes(CXCursor C,
                                                                    uint reserved);

        /// <summary>
        /// The clang_Cursor_getObjCDeclQualifiers
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_Cursor_getObjCDeclQualifiers(CXCursor C);

        /// <summary>
        /// The clang_Cursor_isObjCOptional
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_Cursor_isObjCOptional(CXCursor C);

        /// <summary>
        /// The clang_Cursor_isVariadic
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_Cursor_isVariadic(CXCursor C);

        /// <summary>
        /// The clang_Cursor_isExternalSymbol
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <param name="language">The language<see cref="CXString"/></param>
        /// <param name="definedIn">The definedIn<see cref="CXString"/></param>
        /// <param name="isGenerated">The isGenerated<see cref="uint"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)]
        internal static extern uint clang_Cursor_isExternalSymbol(CXCursor C,
                                              out CXString language, out CXString definedIn,
                                              out uint isGenerated);

        /// <summary>
        /// The clang_Cursor_getCommentRange
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXSourceRange"/></returns>
        [DllImport(Lib)] internal static extern CXSourceRange clang_Cursor_getCommentRange(CXCursor C);

        /// <summary>
        /// The clang_Cursor_getRawCommentText
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)] internal static extern CXString clang_Cursor_getRawCommentText(CXCursor C);

        /// <summary>
        /// The clang_Cursor_getBriefCommentText
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)] internal static extern CXString clang_Cursor_getBriefCommentText(CXCursor C);

        /// <summary>
        /// The clang_Cursor_getMangling
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)] internal static extern CXString clang_Cursor_getMangling(CXCursor cursor);

        /// <summary>
        /// The clang_Cursor_getCXXManglings
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXStringSet*"/></returns>
        [DllImport(Lib)] internal static extern CXStringSet* clang_Cursor_getCXXManglings(CXCursor cursor);

        /// <summary>
        /// The clang_Cursor_getObjCManglings
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXStringSet*"/></returns>
        [DllImport(Lib)] internal static extern CXStringSet* clang_Cursor_getObjCManglings(CXCursor cursor);

        /// <summary>
        /// The clang_Cursor_getModule
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXModule"/></returns>
        [DllImport(Lib)] internal static extern CXModule clang_Cursor_getModule(CXCursor C);

        /// <summary>
        /// The clang_getModuleForFile
        /// </summary>
        /// <param name="unit">The unit<see cref="CXTranslationUnit"/></param>
        /// <param name="file">The file<see cref="CXFile"/></param>
        /// <returns>The <see cref="CXModule"/></returns>
        [DllImport(Lib)] internal static extern CXModule clang_getModuleForFile(CXTranslationUnit unit, CXFile file);

        /// <summary>
        /// The clang_Module_getASTFile
        /// </summary>
        /// <param name="Module">The Module<see cref="CXModule"/></param>
        /// <returns>The <see cref="CXFile"/></returns>
        [DllImport(Lib)] internal static extern CXFile clang_Module_getASTFile(CXModule Module);

        /// <summary>
        /// The clang_Module_getParent
        /// </summary>
        /// <param name="Module">The Module<see cref="CXModule"/></param>
        /// <returns>The <see cref="CXModule"/></returns>
        [DllImport(Lib)] internal static extern CXModule clang_Module_getParent(CXModule Module);

        /// <summary>
        /// The clang_Module_getName
        /// </summary>
        /// <param name="Module">The Module<see cref="CXModule"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)] internal static extern CXString clang_Module_getName(CXModule Module);

        /// <summary>
        /// The clang_Module_getFullName
        /// </summary>
        /// <param name="Module">The Module<see cref="CXModule"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)] internal static extern CXString clang_Module_getFullName(CXModule Module);

        /// <summary>
        /// The clang_Module_isSystem
        /// </summary>
        /// <param name="Module">The Module<see cref="CXModule"/></param>
        /// <returns>The <see cref="int"/></returns>
        [DllImport(Lib)] internal static extern int clang_Module_isSystem(CXModule Module);

        /// <summary>
        /// The clang_Module_getNumTopLevelHeaders
        /// </summary>
        /// <param name="unit">The unit<see cref="CXTranslationUnit"/></param>
        /// <param name="Module">The Module<see cref="CXModule"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)]
        internal static extern uint clang_Module_getNumTopLevelHeaders(CXTranslationUnit unit,
                                                                  CXModule Module);

        /// <summary>
        /// The clang_Module_getTopLevelHeader
        /// </summary>
        /// <param name="unit">The unit<see cref="CXTranslationUnit"/></param>
        /// <param name="Module">The Module<see cref="CXModule"/></param>
        /// <param name="Index">The Index<see cref="uint"/></param>
        /// <returns>The <see cref="CXFile"/></returns>
        [DllImport(Lib)]
        internal static extern
       CXFile clang_Module_getTopLevelHeader(CXTranslationUnit unit,
                                             CXModule Module, uint Index);

        /// <summary>
        /// The clang_CXXConstructor_isConvertingConstructor
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_CXXConstructor_isConvertingConstructor(CXCursor C);

        /// <summary>
        /// The clang_CXXConstructor_isCopyConstructor
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_CXXConstructor_isCopyConstructor(CXCursor C);

        /// <summary>
        /// The clang_CXXConstructor_isDefaultConstructor
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_CXXConstructor_isDefaultConstructor(CXCursor C);

        /// <summary>
        /// The clang_CXXConstructor_isMoveConstructor
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_CXXConstructor_isMoveConstructor(CXCursor C);

        /// <summary>
        /// The clang_CXXField_isMutable
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_CXXField_isMutable(CXCursor C);

        /// <summary>
        /// The clang_CXXMethod_isDefaulted
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_CXXMethod_isDefaulted(CXCursor C);

        /// <summary>
        /// The clang_CXXMethod_isPureVirtual
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_CXXMethod_isPureVirtual(CXCursor C);

        /// <summary>
        /// The clang_CXXMethod_isStatic
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_CXXMethod_isStatic(CXCursor C);

        /// <summary>
        /// The clang_CXXMethod_isVirtual
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_CXXMethod_isVirtual(CXCursor C);

        /// <summary>
        /// The clang_CXXRecord_isAbstract
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_CXXRecord_isAbstract(CXCursor C);

        /// <summary>
        /// The clang_EnumDecl_isScoped
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_EnumDecl_isScoped(CXCursor C);

        /// <summary>
        /// The clang_CXXMethod_isConst
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_CXXMethod_isConst(CXCursor C);

        /// <summary>
        /// The clang_getTemplateCursorKind
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXCursorKind"/></returns>
        [DllImport(Lib)] internal static extern CXCursorKind clang_getTemplateCursorKind(CXCursor C);

        /// <summary>
        /// The clang_getSpecializedCursorTemplate
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXCursor"/></returns>
        [DllImport(Lib)] internal static extern CXCursor clang_getSpecializedCursorTemplate(CXCursor C);

        /// <summary>
        /// The clang_getCursorReferenceNameRange
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <param name="NameFlags">The NameFlags<see cref="uint"/></param>
        /// <param name="PieceIndex">The PieceIndex<see cref="uint"/></param>
        /// <returns>The <see cref="CXSourceRange"/></returns>
        [DllImport(Lib)]
        internal static extern CXSourceRange clang_getCursorReferenceNameRange(CXCursor C,
                                                       uint NameFlags,
                                                       uint PieceIndex);

        /// <summary>
        /// The clang_getToken
        /// </summary>
        /// <param name="TU">The TU<see cref="CXTranslationUnit"/></param>
        /// <param name="Location">The Location<see cref="CXSourceLocation"/></param>
        /// <returns>The <see cref="CXToken"/></returns>
        [DllImport(Lib)]
        internal static extern CXToken clang_getToken(CXTranslationUnit TU,
                                              CXSourceLocation Location);

        /// <summary>
        /// The clang_getTokenKind
        /// </summary>
        /// <param name="token">The token<see cref="CXToken"/></param>
        /// <returns>The <see cref="CXTokenKind"/></returns>
        [DllImport(Lib)] internal static extern CXTokenKind clang_getTokenKind(CXToken token);

        /// <summary>
        /// The clang_getTokenSpelling
        /// </summary>
        /// <param name="unit">The unit<see cref="CXTranslationUnit"/></param>
        /// <param name="token">The token<see cref="CXToken"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)] internal static extern CXString clang_getTokenSpelling(CXTranslationUnit unit, CXToken token);

        /// <summary>
        /// The clang_getTokenLocation
        /// </summary>
        /// <param name="unit">The unit<see cref="CXTranslationUnit"/></param>
        /// <param name="token">The token<see cref="CXToken"/></param>
        /// <returns>The <see cref="CXSourceLocation"/></returns>
        [DllImport(Lib)]
        internal static extern CXSourceLocation clang_getTokenLocation(CXTranslationUnit unit,
                                                              CXToken token);

        /// <summary>
        /// The clang_getTokenExtent
        /// </summary>
        /// <param name="unit">The unit<see cref="CXTranslationUnit"/></param>
        /// <param name="token">The token<see cref="CXToken"/></param>
        /// <returns>The <see cref="CXSourceRange"/></returns>
        [DllImport(Lib)] internal static extern CXSourceRange clang_getTokenExtent(CXTranslationUnit unit, CXToken token);

        /// <summary>
        /// The clang_tokenize
        /// </summary>
        /// <param name="TU">The TU<see cref="CXTranslationUnit"/></param>
        /// <param name="Range">The Range<see cref="CXSourceRange"/></param>
        /// <param name="Tokens">The Tokens<see cref="CXToken*"/></param>
        /// <param name="NumTokens">The NumTokens<see cref="uint"/></param>
        [DllImport(Lib)]
        internal static extern void clang_tokenize(CXTranslationUnit TU, CXSourceRange Range,
                                          out CXToken* Tokens, out uint NumTokens);

        /// <summary>
        /// The clang_annotateTokens
        /// </summary>
        /// <param name="TU">The TU<see cref="CXTranslationUnit"/></param>
        /// <param name="Tokens">The Tokens<see cref="CXToken[]"/></param>
        /// <param name="NumTokens">The NumTokens<see cref="uint"/></param>
        /// <param name="Cursors">The Cursors<see cref="CXCursor[]"/></param>
        [DllImport(Lib)]
        internal static extern void clang_annotateTokens(CXTranslationUnit TU,
                                                CXToken[] Tokens, uint NumTokens,
                                                CXCursor[] Cursors);

        /// <summary>
        /// The clang_disposeTokens
        /// </summary>
        /// <param name="TU">The TU<see cref="CXTranslationUnit"/></param>
        /// <param name="Tokens">The Tokens<see cref="CXToken*"/></param>
        /// <param name="NumTokens">The NumTokens<see cref="uint"/></param>
        [DllImport(Lib)]
        internal static extern void clang_disposeTokens(CXTranslationUnit TU,
                                               CXToken* Tokens, uint NumTokens);

        /// <summary>
        /// The clang_getCursorKindSpelling
        /// </summary>
        /// <param name="Kind">The Kind<see cref="CXCursorKind"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)] internal static extern CXString clang_getCursorKindSpelling(CXCursorKind Kind);

        /// <summary>
        /// The clang_getDefinitionSpellingAndExtent
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <param name="startBuf">The startBuf<see cref="string"/></param>
        /// <param name="endBuf">The endBuf<see cref="string"/></param>
        /// <param name="startLine">The startLine<see cref="uint"/></param>
        /// <param name="startColumn">The startColumn<see cref="uint"/></param>
        /// <param name="endLine">The endLine<see cref="uint"/></param>
        /// <param name="endColumn">The endColumn<see cref="uint"/></param>
        [DllImport(Lib)]
        internal static extern void clang_getDefinitionSpellingAndExtent(CXCursor cursor,
                                                 out string startBuf,
                                                 out string endBuf,
                                                 out uint startLine,
                                                 out uint startColumn,
                                                 out uint endLine,
                                                 out uint endColumn);

        /// <summary>
        /// The clang_enableStackTraces
        /// </summary>
        [DllImport(Lib)] internal static extern void clang_enableStackTraces();

        /// <summary>
        /// The fn
        /// </summary>
        /// <param name="ptr">The ptr<see cref="IntPtr"/></param>
        public delegate void fn(IntPtr ptr);

        /// <summary>
        /// The clang_executeOnThread
        /// </summary>
        /// <param name="fn">The fn<see cref="fn"/></param>
        /// <param name="user_data">The user_data<see cref="IntPtr"/></param>
        /// <param name="stack_size">The stack_size<see cref="uint"/></param>
        [DllImport(Lib)] internal static extern void clang_executeOnThread(fn fn, IntPtr user_data, uint stack_size);

        /// <summary>
        /// The clang_getCompletionChunkKind
        /// </summary>
        /// <param name="completion_string">The completion_string<see cref="CXCompletionString"/></param>
        /// <param name="chunk_number">The chunk_number<see cref="uint"/></param>
        /// <returns>The <see cref="CXCompletionChunkKind"/></returns>
        [DllImport(Lib)]
        internal static extern CXCompletionChunkKind
       clang_getCompletionChunkKind(CXCompletionString completion_string,
                                    uint chunk_number);

        /// <summary>
        /// The clang_getCompletionChunkText
        /// </summary>
        /// <param name="completion_string">The completion_string<see cref="CXCompletionString"/></param>
        /// <param name="chunk_number">The chunk_number<see cref="uint"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)]
        internal static extern CXString
       clang_getCompletionChunkText(CXCompletionString completion_string,
                                    uint chunk_number);

        /// <summary>
        /// The clang_getCompletionChunkCompletionString
        /// </summary>
        /// <param name="completion_string">The completion_string<see cref="CXCompletionString"/></param>
        /// <param name="chunk_number">The chunk_number<see cref="uint"/></param>
        /// <returns>The <see cref="CXCompletionString"/></returns>
        [DllImport(Lib)]
        internal static extern CXCompletionString
       clang_getCompletionChunkCompletionString(CXCompletionString completion_string,
                                                uint chunk_number);

        /// <summary>
        /// The clang_getNumCompletionChunks
        /// </summary>
        /// <param name="completion_string">The completion_string<see cref="CXCompletionString"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)]
        internal static extern uint
       clang_getNumCompletionChunks(CXCompletionString completion_string);

        /// <summary>
        /// The clang_getCompletionPriority
        /// </summary>
        /// <param name="completion_string">The completion_string<see cref="CXCompletionString"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)]
        internal static extern uint
       clang_getCompletionPriority(CXCompletionString completion_string);

        /// <summary>
        /// The clang_getCompletionAvailability
        /// </summary>
        /// <param name="completion_string">The completion_string<see cref="CXCompletionString"/></param>
        /// <returns>The <see cref="CXAvailabilityKind"/></returns>
        [DllImport(Lib)]
        internal static extern CXAvailabilityKind
       clang_getCompletionAvailability(CXCompletionString completion_string);

        /// <summary>
        /// The clang_getCompletionNumAnnotations
        /// </summary>
        /// <param name="completion_string">The completion_string<see cref="CXCompletionString"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)]
        internal static extern uint
       clang_getCompletionNumAnnotations(CXCompletionString completion_string);

        /// <summary>
        /// The clang_getCompletionAnnotation
        /// </summary>
        /// <param name="completion_string">The completion_string<see cref="CXCompletionString"/></param>
        /// <param name="annotation_number">The annotation_number<see cref="uint"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)]
        internal static extern CXString
       clang_getCompletionAnnotation(CXCompletionString completion_string,
                                     uint annotation_number);

        /// <summary>
        /// The clang_getCompletionParent
        /// </summary>
        /// <param name="completion_string">The completion_string<see cref="CXCompletionString"/></param>
        /// <param name="kind">The kind<see cref="CXCursorKind"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)]
        internal static extern CXString
       clang_getCompletionParent(CXCompletionString completion_string,
                                 out CXCursorKind kind);

        /// <summary>
        /// The clang_getCompletionBriefComment
        /// </summary>
        /// <param name="completion_string">The completion_string<see cref="CXCompletionString"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)]
        internal static extern CXString
       clang_getCompletionBriefComment(CXCompletionString completion_string);

        /// <summary>
        /// The clang_getCursorCompletionString
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXCompletionString"/></returns>
        [DllImport(Lib)]
        internal static extern CXCompletionString
       clang_getCursorCompletionString(CXCursor cursor);

        /// <summary>
        /// The clang_getCompletionNumFixIts
        /// </summary>
        /// <param name="results">The results<see cref="CXCodeCompleteResults*"/></param>
        /// <param name="completion_index">The completion_index<see cref="uint"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)]
        internal static extern uint clang_getCompletionNumFixIts(CXCodeCompleteResults* results, uint completion_index);

        /// <summary>
        /// The clang_getCompletionFixIt
        /// </summary>
        /// <param name="results">The results<see cref="CXCodeCompleteResults*"/></param>
        /// <param name="completion_index">The completion_index<see cref="uint"/></param>
        /// <param name="fixit_index">The fixit_index<see cref="uint"/></param>
        /// <param name="replacement_range">The replacement_range<see cref="CXSourceRange"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)]
        internal static extern CXString clang_getCompletionFixIt(
           CXCodeCompleteResults* results, uint completion_index,
           uint fixit_index, out CXSourceRange replacement_range);

        /// <summary>
        /// The clang_defaultCodeCompleteOptions
        /// </summary>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_defaultCodeCompleteOptions();

        /// <summary>
        /// The clang_codeCompleteAt
        /// </summary>
        /// <param name="TU">The TU<see cref="CXTranslationUnit"/></param>
        /// <param name="complete_filename">The complete_filename<see cref="string"/></param>
        /// <param name="complete_line">The complete_line<see cref="uint"/></param>
        /// <param name="complete_column">The complete_column<see cref="uint"/></param>
        /// <param name="unsaved_files">The unsaved_files<see cref="CXUnsavedFile[]"/></param>
        /// <param name="num_unsaved_files">The num_unsaved_files<see cref="uint"/></param>
        /// <param name="options">The options<see cref="uint"/></param>
        /// <returns>The <see cref="CXCodeCompleteResults*"/></returns>
        [DllImport(Lib)]
        internal static extern
       CXCodeCompleteResults* clang_codeCompleteAt(CXTranslationUnit TU,
                                                   string complete_filename,
                                                   uint complete_line,
                                                   uint complete_column,
                                                   CXUnsavedFile[] unsaved_files,
                                                   uint num_unsaved_files,
                                                   uint options);

        /// <summary>
        /// The clang_sortCodeCompletionResults
        /// </summary>
        /// <param name="Results">The Results<see cref="CXCompletionResult*"/></param>
        /// <param name="NumResults">The NumResults<see cref="uint"/></param>
        [DllImport(Lib)]
        internal static extern
       void clang_sortCodeCompletionResults(CXCompletionResult* Results,
                                            uint NumResults);

        /// <summary>
        /// The clang_disposeCodeCompleteResults
        /// </summary>
        /// <param name="Results">The Results<see cref="CXCodeCompleteResults*"/></param>
        [DllImport(Lib)]
        internal static extern
       void clang_disposeCodeCompleteResults(CXCodeCompleteResults* Results);

        /// <summary>
        /// The clang_codeCompleteGetNumDiagnostics
        /// </summary>
        /// <param name="Results">The Results<see cref="CXCodeCompleteResults*"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)]
        internal static extern
       uint clang_codeCompleteGetNumDiagnostics(CXCodeCompleteResults* Results);

        /// <summary>
        /// The clang_codeCompleteGetDiagnostic
        /// </summary>
        /// <param name="Results">The Results<see cref="CXCodeCompleteResults*"/></param>
        /// <param name="Index">The Index<see cref="uint"/></param>
        /// <returns>The <see cref="CXDiagnostic"/></returns>
        [DllImport(Lib)]
        internal static extern
       CXDiagnostic clang_codeCompleteGetDiagnostic(CXCodeCompleteResults* Results,
                                                    uint Index);

        /// <summary>
        /// The clang_codeCompleteGetContexts
        /// </summary>
        /// <param name="Results">The Results<see cref="CXCodeCompleteResults*"/></param>
        /// <returns>The <see cref="ulong"/></returns>
        [DllImport(Lib)]
        internal static extern
       ulong clang_codeCompleteGetContexts(CXCodeCompleteResults* Results);

        /// <summary>
        /// The clang_codeCompleteGetContainerKind
        /// </summary>
        /// <param name="Results">The Results<see cref="CXCodeCompleteResults*"/></param>
        /// <param name="IsIncomplete">The IsIncomplete<see cref="uint"/></param>
        /// <returns>The <see cref="CXCursorKind"/></returns>
        [DllImport(Lib)]
        internal static extern
        CXCursorKind clang_codeCompleteGetContainerKind(
                                                        CXCodeCompleteResults* Results,
                                                            out uint IsIncomplete);

        /// <summary>
        /// The clang_codeCompleteGetContainerUSR
        /// </summary>
        /// <param name="Results">The Results<see cref="CXCodeCompleteResults*"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)]
        internal static extern
       CXString clang_codeCompleteGetContainerUSR(CXCodeCompleteResults* Results);

        /// <summary>
        /// The clang_codeCompleteGetObjCSelector
        /// </summary>
        /// <param name="Results">The Results<see cref="CXCodeCompleteResults*"/></param>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)]
        internal static extern
       CXString clang_codeCompleteGetObjCSelector(CXCodeCompleteResults* Results);

        /// <summary>
        /// The clang_getClangVersion
        /// </summary>
        /// <returns>The <see cref="CXString"/></returns>
        [DllImport(Lib)] internal static extern CXString clang_getClangVersion();

        /// <summary>
        /// The clang_toggleCrashRecovery
        /// </summary>
        /// <param name="isEnabled">The isEnabled<see cref="uint"/></param>
        [DllImport(Lib)] internal static extern void clang_toggleCrashRecovery(uint isEnabled);

        /**
         * Visitor invoked for each file in a translation unit
         *        (used with clang_getInclusions()).
         *
         * This visitor function will be invoked by clang_getInclusions() for each
         * file included (either at the top-level or by \#include directives) within
         * a translation unit.  The first argument is the file being included, and
         * the second and third arguments provide the inclusion stack.  The
         * array is sorted in order of immediate inclusion.  For example,
         * the first element refers to the location that included 'included_file'.
         */
        public delegate void CXInclusionVisitor(CXFile included_file,
                                             CXSourceLocation inclusion_stack,
                                             uint include_len,
                                             CXClientData client_data);

        /// <summary>
        /// The clang_getInclusions
        /// </summary>
        /// <param name="tu">The tu<see cref="CXTranslationUnit"/></param>
        /// <param name="visitor">The visitor<see cref="CXInclusionVisitor"/></param>
        /// <param name="client_data">The client_data<see cref="CXClientData"/></param>
        [DllImport(Lib)]
        internal static extern void clang_getInclusions(CXTranslationUnit tu,
                                               CXInclusionVisitor visitor,
                                               CXClientData client_data);

        /// <summary>
        /// The clang_Cursor_Evaluate
        /// </summary>
        /// <param name="C">The C<see cref="CXCursor"/></param>
        /// <returns>The <see cref="CXEvalResult"/></returns>
        [DllImport(Lib)] internal static extern CXEvalResult clang_Cursor_Evaluate(CXCursor C);

        /// <summary>
        /// The clang_EvalResult_getKind
        /// </summary>
        /// <param name="E">The E<see cref="CXEvalResult"/></param>
        /// <returns>The <see cref="CXEvalResultKind"/></returns>
        [DllImport(Lib)] internal static extern CXEvalResultKind clang_EvalResult_getKind(CXEvalResult E);

        /// <summary>
        /// The clang_EvalResult_getAsInt
        /// </summary>
        /// <param name="E">The E<see cref="CXEvalResult"/></param>
        /// <returns>The <see cref="int"/></returns>
        [DllImport(Lib)] internal static extern int clang_EvalResult_getAsInt(CXEvalResult E);

        /// <summary>
        /// The clang_EvalResult_getAsLongLong
        /// </summary>
        /// <param name="E">The E<see cref="CXEvalResult"/></param>
        /// <returns>The <see cref="long"/></returns>
        [DllImport(Lib)] internal static extern long clang_EvalResult_getAsLongLong(CXEvalResult E);

        /// <summary>
        /// The clang_EvalResult_isuintInt
        /// </summary>
        /// <param name="E">The E<see cref="CXEvalResult"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_EvalResult_isuintInt(CXEvalResult E);

        /// <summary>
        /// The clang_EvalResult_getAsuint
        /// </summary>
        /// <param name="E">The E<see cref="CXEvalResult"/></param>
        /// <returns>The <see cref="ulong"/></returns>
        [DllImport(Lib)] internal static extern ulong clang_EvalResult_getAsuint(CXEvalResult E);

        /// <summary>
        /// The clang_EvalResult_getAsDouble
        /// </summary>
        /// <param name="E">The E<see cref="CXEvalResult"/></param>
        /// <returns>The <see cref="double"/></returns>
        [DllImport(Lib)] internal static extern double clang_EvalResult_getAsDouble(CXEvalResult E);

        /// <summary>
        /// The clang_EvalResult_getAsStr
        /// </summary>
        /// <param name="E">The E<see cref="CXEvalResult"/></param>
        /// <returns>The <see cref="sbyte*"/></returns>
        [DllImport(Lib)] internal static extern sbyte* clang_EvalResult_getAsStr(CXEvalResult E);

        /// <summary>
        /// The clang_EvalResult_dispose
        /// </summary>
        /// <param name="E">The E<see cref="CXEvalResult"/></param>
        [DllImport(Lib)] internal static extern void clang_EvalResult_dispose(CXEvalResult E);

        /// <summary>
        /// The clang_getRemappings
        /// </summary>
        /// <param name="path">The path<see cref="string"/></param>
        /// <returns>The <see cref="CXRemapping"/></returns>
        [DllImport(Lib)] internal static extern CXRemapping clang_getRemappings(string path);

        /// <summary>
        /// The clang_getRemappingsFromFileList
        /// </summary>
        /// <param name="filePaths">The filePaths<see cref="string[]"/></param>
        /// <param name="numFiles">The numFiles<see cref="uint"/></param>
        /// <returns>The <see cref="CXRemapping"/></returns>
        [DllImport(Lib)]
        internal static extern
       CXRemapping clang_getRemappingsFromFileList(string[] filePaths,
                                                   uint numFiles);

        /// <summary>
        /// The clang_remap_getNumFiles
        /// </summary>
        /// <param name="cXRemapping">The cXRemapping<see cref="CXRemapping"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_remap_getNumFiles(CXRemapping cXRemapping);

        /// <summary>
        /// The clang_remap_getFilenames
        /// </summary>
        /// <param name="cXRemapping">The cXRemapping<see cref="CXRemapping"/></param>
        /// <param name="index">The index<see cref="uint"/></param>
        /// <param name="original">The original<see cref="CXString"/></param>
        /// <param name="transformed">The transformed<see cref="CXString"/></param>
        [DllImport(Lib)]
        internal static extern void clang_remap_getFilenames(CXRemapping cXRemapping, uint index,
                                            out CXString original, out CXString transformed);

        /// <summary>
        /// The clang_remap_dispose
        /// </summary>
        /// <param name="cXRemapping">The cXRemapping<see cref="CXRemapping"/></param>
        [DllImport(Lib)] internal static extern void clang_remap_dispose(CXRemapping cXRemapping);

        /// <summary>
        /// The clang_findReferencesInFile
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <param name="file">The file<see cref="CXFile"/></param>
        /// <param name="visitor">The visitor<see cref="CXCursorAndRangeVisitor"/></param>
        /// <returns>The <see cref="CXResult"/></returns>
        [DllImport(Lib)]
        internal static extern CXResult clang_findReferencesInFile(CXCursor cursor, CXFile file,
                                                      CXCursorAndRangeVisitor visitor);

        /// <summary>
        /// The clang_findIncludesInFile
        /// </summary>
        /// <param name="TU">The TU<see cref="CXTranslationUnit"/></param>
        /// <param name="file">The file<see cref="CXFile"/></param>
        /// <param name="visitor">The visitor<see cref="CXCursorAndRangeVisitor"/></param>
        /// <returns>The <see cref="CXResult"/></returns>
        [DllImport(Lib)]
        internal static extern CXResult clang_findIncludesInFile(CXTranslationUnit TU,
                                                        CXFile file,
                                                     CXCursorAndRangeVisitor visitor);

        /// <summary>
        /// The CXCursorAndRangeVisitorBlock
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <param name="range">The range<see cref="CXSourceRange"/></param>
        /// <returns>The <see cref="CXVisitorResult"/></returns>
        public delegate CXVisitorResult
    CXCursorAndRangeVisitorBlock(CXCursor cursor, CXSourceRange range);

        /// <summary>
        /// The clang_findReferencesInFileWithBlock
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        /// <param name="file">The file<see cref="CXFile"/></param>
        /// <param name="cXCursorAndRangeVisitorBlock">The cXCursorAndRangeVisitorBlock<see cref="CXCursorAndRangeVisitorBlock"/></param>
        /// <returns>The <see cref="CXResult"/></returns>
        [DllImport(Lib)]
        internal static extern
       CXResult clang_findReferencesInFileWithBlock(CXCursor cursor, CXFile file,
                                                    CXCursorAndRangeVisitorBlock cXCursorAndRangeVisitorBlock);

        /// <summary>
        /// The clang_findIncludesInFileWithBlock
        /// </summary>
        /// <param name="cXTranslationUnit">The cXTranslationUnit<see cref="CXTranslationUnit"/></param>
        /// <param name="file">The file<see cref="CXFile"/></param>
        /// <param name="cXCursor">The cXCursor<see cref="CXCursorAndRangeVisitorBlock"/></param>
        /// <returns>The <see cref="CXResult"/></returns>
        [DllImport(Lib)]
        internal static extern
       CXResult clang_findIncludesInFileWithBlock(CXTranslationUnit cXTranslationUnit, CXFile file,
                                                  CXCursorAndRangeVisitorBlock cXCursor);

        /// <summary>
        /// The clang_index_isEntityObjCContainerKind
        /// </summary>
        /// <param name="entityKind">The entityKind<see cref="CXIdxEntityKind"/></param>
        /// <returns>The <see cref="int"/></returns>
        [DllImport(Lib)] internal static extern int clang_index_isEntityObjCContainerKind(CXIdxEntityKind entityKind);

        /// <summary>
        /// The clang_index_getObjCContainerDeclInfo
        /// </summary>
        /// <param name="info">The info<see cref="IntPtr"/></param>
        /// <returns>The <see cref="IntPtr"/></returns>
        [DllImport(Lib)] internal static extern /*CXIdxObjCContainerDeclInfo*/ IntPtr clang_index_getObjCContainerDeclInfo(/*CXIdxDeclInfo*/ IntPtr info);

        /// <summary>
        /// The clang_index_getObjCInterfaceDeclInfo
        /// </summary>
        /// <param name="declInfo">The declInfo<see cref="IntPtr"/></param>
        /// <returns>The <see cref="IntPtr"/></returns>
        [DllImport(Lib)] internal static extern  /*CXIdxObjCInterfaceDeclInfo*/IntPtr clang_index_getObjCInterfaceDeclInfo(/*CXIdxDeclInfo*/ IntPtr declInfo);

        /// <summary>
        /// The clang_index_getObjCCategoryDeclInfo
        /// </summary>
        /// <param name="declInfo">The declInfo<see cref="IntPtr"/></param>
        /// <returns>The <see cref="IntPtr"/></returns>
        [DllImport(Lib)]
        internal static extern
/* CXIdxObjCCategoryDeclInfo*/
IntPtr clang_index_getObjCCategoryDeclInfo(/* CXIdxDeclInfo*/ IntPtr declInfo);

        /// <summary>
        /// The clang_index_getObjCProtocolRefListInfo
        /// </summary>
        /// <param name="declInfo">The declInfo<see cref="IntPtr"/></param>
        /// <returns>The <see cref="IntPtr"/></returns>
        [DllImport(Lib)]
        internal static extern /* CXIdxObjCProtocolRefListInfo*/
IntPtr clang_index_getObjCProtocolRefListInfo(/* CXIdxDeclInfo*/ IntPtr declInfo);

        /// <summary>
        /// The clang_index_getObjCPropertyDeclInfo
        /// </summary>
        /// <param name="declInfo">The declInfo<see cref="IntPtr"/></param>
        /// <returns>The <see cref="IntPtr"/></returns>
        [DllImport(Lib)]
        internal static extern /* CXIdxObjCPropertyDeclInfo*/
IntPtr clang_index_getObjCPropertyDeclInfo(/*CXIdxDeclInfo*/ IntPtr declInfo);

        /// <summary>
        /// The clang_index_getIBOutletCollectionAttrInfo
        /// </summary>
        /// <param name="attrInfo">The attrInfo<see cref="IntPtr"/></param>
        /// <returns>The <see cref="IntPtr"/></returns>
        [DllImport(Lib)]
        internal static extern /* CXIdxIBOutletCollectionAttrInfo*/
IntPtr clang_index_getIBOutletCollectionAttrInfo(/* CXIdxAttrInfo*/ IntPtr attrInfo);

        /// <summary>
        /// The clang_index_getCXXClassDeclInfo
        /// </summary>
        /// <param name="declInfo">The declInfo<see cref="IntPtr"/></param>
        /// <returns>The <see cref="IntPtr"/></returns>
        [DllImport(Lib)]
        internal static extern /* CXIdxCXXClassDeclInfo*/IntPtr clang_index_getCXXClassDeclInfo(/* CXIdxDeclInfo*/ IntPtr declInfo);

        /// <summary>
        /// The clang_index_getClientContainer
        /// </summary>
        /// <param name="containerInfo">The containerInfo<see cref="IntPtr"/></param>
        /// <returns>The <see cref="CXIdxClientContainer"/></returns>
        [DllImport(Lib)]
        internal static extern CXIdxClientContainer
       clang_index_getClientContainer(/*CXIdxContainerInfo*/IntPtr containerInfo);

        /// <summary>
        /// The clang_index_setClientContainer
        /// </summary>
        /// <param name="containerInfo">The containerInfo<see cref="IntPtr"/></param>
        /// <param name="container">The container<see cref="CXIdxClientContainer"/></param>
        [DllImport(Lib)]
        internal static extern void
       clang_index_setClientContainer(/*CXIdxContainerInfo*/ IntPtr containerInfo, CXIdxClientContainer container);

        /// <summary>
        /// The clang_index_getClientEntity
        /// </summary>
        /// <param name="entityInfo">The entityInfo<see cref="IntPtr"/></param>
        /// <returns>The <see cref="CXIdxClientEntity"/></returns>
        [DllImport(Lib)]
        internal static extern CXIdxClientEntity
       clang_index_getClientEntity(/*CXIdxEntityInfo*/ IntPtr entityInfo);

        /// <summary>
        /// The clang_index_setClientEntity
        /// </summary>
        /// <param name="entityInfo">The entityInfo<see cref="IntPtr"/></param>
        /// <param name="entity">The entity<see cref="CXIdxClientEntity"/></param>
        [DllImport(Lib)]
        internal static extern void clang_index_setClientEntity(/*CXIdxEntityInfo*/ IntPtr entityInfo, CXIdxClientEntity entity);

        /// <summary>
        /// The clang_IndexAction_create
        /// </summary>
        /// <param name="CIdx">The CIdx<see cref="CXIndex"/></param>
        /// <returns>The <see cref="CXIndexAction"/></returns>
        [DllImport(Lib)] internal static extern CXIndexAction clang_IndexAction_create(CXIndex CIdx);

        /// <summary>
        /// The clang_IndexAction_dispose
        /// </summary>
        /// <param name="indexAction">The indexAction<see cref="CXIndexAction"/></param>
        [DllImport(Lib)] internal static extern void clang_IndexAction_dispose(CXIndexAction indexAction);

        /// <summary>
        /// The clang_indexSourceFile
        /// </summary>
        /// <param name="indexAction">The indexAction<see cref="CXIndexAction"/></param>
        /// <param name="client_data">The client_data<see cref="CXClientData"/></param>
        /// <param name="index_callbacks">The index_callbacks<see cref="IntPtr"/></param>
        /// <param name="index_callbacks_size">The index_callbacks_size<see cref="uint"/></param>
        /// <param name="index_options">The index_options<see cref="uint"/></param>
        /// <param name="source_filename">The source_filename<see cref="string"/></param>
        /// <param name="command_line_args">The command_line_args<see cref="string[]"/></param>
        /// <param name="num_command_line_args">The num_command_line_args<see cref="int"/></param>
        /// <param name="unsaved_files">The unsaved_files<see cref="CXUnsavedFile[]"/></param>
        /// <param name="num_unsaved_files">The num_unsaved_files<see cref="uint"/></param>
        /// <param name="out_TU">The out_TU<see cref="CXTranslationUnit"/></param>
        /// <param name="TU_options">The TU_options<see cref="uint"/></param>
        /// <returns>The <see cref="int"/></returns>
        [DllImport(Lib)]
        internal static extern int clang_indexSourceFile(CXIndexAction indexAction,
                                                CXClientData client_data,
                                                /*IndexerCallbacks*/IntPtr index_callbacks,
                                                uint index_callbacks_size,
                                                uint index_options,
                                                string source_filename,
                                                string[] command_line_args,
                                                int num_command_line_args,
                                                CXUnsavedFile[] unsaved_files,
                                                uint num_unsaved_files,
                                                out CXTranslationUnit out_TU,
                                                uint TU_options);

        /// <summary>
        /// The clang_indexSourceFileFullArgv
        /// </summary>
        /// <param name="indexAction">The indexAction<see cref="CXIndexAction"/></param>
        /// <param name="client_data">The client_data<see cref="CXClientData"/></param>
        /// <param name="index_callbacks">The index_callbacks<see cref="IntPtr"/></param>
        /// <param name="index_callbacks_size">The index_callbacks_size<see cref="uint"/></param>
        /// <param name="index_options">The index_options<see cref="uint"/></param>
        /// <param name="source_filename">The source_filename<see cref="string"/></param>
        /// <param name="command_line_args">The command_line_args<see cref="string"/></param>
        /// <param name="num_command_line_args">The num_command_line_args<see cref="int"/></param>
        /// <param name="unsaved_files">The unsaved_files<see cref="CXUnsavedFile"/></param>
        /// <param name="num_unsaved_files">The num_unsaved_files<see cref="uint"/></param>
        /// <param name="out_TU">The out_TU<see cref="CXTranslationUnit*"/></param>
        /// <param name="TU_options">The TU_options<see cref="uint"/></param>
        /// <returns>The <see cref="int"/></returns>
        [DllImport(Lib)]
        internal static extern int clang_indexSourceFileFullArgv(
           CXIndexAction indexAction, CXClientData client_data, /*IndexerCallbacks*/IntPtr index_callbacks,
           uint index_callbacks_size, uint index_options,
           string source_filename, string command_line_args,
           int num_command_line_args, out CXUnsavedFile unsaved_files,
           uint num_unsaved_files, CXTranslationUnit* out_TU, uint TU_options);

        /// <summary>
        /// The clang_indexTranslationUnit
        /// </summary>
        /// <param name="indexAction">The indexAction<see cref="CXIndexAction"/></param>
        /// <param name="client_data">The client_data<see cref="CXClientData"/></param>
        /// <param name="index_callbacks">The index_callbacks<see cref="IntPtr"/></param>
        /// <param name="index_callbacks_size">The index_callbacks_size<see cref="uint"/></param>
        /// <param name="index_options">The index_options<see cref="uint"/></param>
        /// <param name="unit">The unit<see cref="CXTranslationUnit"/></param>
        /// <returns>The <see cref="int"/></returns>
        [DllImport(Lib)]
        internal static extern int clang_indexTranslationUnit(CXIndexAction indexAction,
                                                     CXClientData client_data,
                                                     /*IndexerCallbacks*/IntPtr index_callbacks,
                                                     uint index_callbacks_size,
                                                     uint index_options,
                                                     CXTranslationUnit unit);

        /// <summary>
        /// The clang_indexLoc_getFileLocation
        /// </summary>
        /// <param name="loc">The loc<see cref="CXIdxLoc"/></param>
        /// <param name="indexFile">The indexFile<see cref="CXIdxClientFile"/></param>
        /// <param name="file">The file<see cref="CXFile"/></param>
        /// <param name="line">The line<see cref="uint"/></param>
        /// <param name="column">The column<see cref="uint"/></param>
        /// <param name="offset">The offset<see cref="uint"/></param>
        [DllImport(Lib)]
        internal static extern void clang_indexLoc_getFileLocation(CXIdxLoc loc,
                                                          out CXIdxClientFile indexFile,
                                                          out CXFile file,
                                                          out uint line,
                                                          out uint column,
                                                          out uint offset);

        /// <summary>
        /// The clang_indexLoc_getCXSourceLocation
        /// </summary>
        /// <param name="loc">The loc<see cref="CXIdxLoc"/></param>
        /// <returns>The <see cref="CXSourceLocation"/></returns>
        [DllImport(Lib)] internal static extern CXSourceLocation clang_indexLoc_getCXSourceLocation(CXIdxLoc loc);

        /**
         * Visitor invoked for each field found by a traversal.
         *
         * This visitor function will be invoked for each field found by
         * \c clang_Type_visitFields. Its first argument is the cursor being
         * visited, its second argument is the client data provided to
         * \c clang_Type_visitFields.
         *
         * The visitor should return one of the \c CXVisitorResult values
         * to direct \c clang_Type_visitFields.
         */
        public delegate CXVisitorResult CXFieldVisitor(CXCursor C, CXClientData client_data);

        /// <summary>
        /// The clang_Type_visitFields
        /// </summary>
        /// <param name="T">The T<see cref="CXType"/></param>
        /// <param name="visitor">The visitor<see cref="CXFieldVisitor"/></param>
        /// <param name="client_data">The client_data<see cref="CXClientData"/></param>
        /// <returns>The <see cref="uint"/></returns>
        [DllImport(Lib)] internal static extern uint clang_Type_visitFields(CXType T, CXFieldVisitor visitor, CXClientData client_data);
    }
}
