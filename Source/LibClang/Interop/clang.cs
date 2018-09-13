using System;
using System.Runtime.InteropServices;
/**
 * An "index" that consists of a set of translation units that would
 * typically be linked together into an executable or library.
 */
using CXIndex = System.IntPtr;

/**
 * An opaque type representing target information for a given translation
 * unit.
 */
using CXTargetInfo = System.IntPtr;

/**
 * A single translation unit, which resides in an index.
 */
using CXTranslationUnit = System.IntPtr;

/**
 * Opaque pointer representing client data that will be passed through
 * to various callbacks and visitors.
 */
using CXClientData = System.IntPtr;

/**
 * \defgroup CINDEX_FILES File manipulation routines
 *
 * @{
 */

/**
 * A particular source file that is part of a translation unit.
 */
using CXFile = System.IntPtr;

/**
 * A single diagnostic, containing the diagnostic's severity,
 * location, text, source ranges, and fix-it hints.
 */
using CXDiagnostic = System.IntPtr;

/**
 * A group of CXDiagnostics.
 */
using CXDiagnosticSet = System.IntPtr;

/**
 * A fast container representing a set of CXCursors.
 */
using CXCursorSet=System.IntPtr;

/**
 * Opaque pointer representing a policy that controls pretty printing
 * for \c clang_getCursorPrettyPrinted.
 */
using CXPrintingPolicy = System.IntPtr;

/**
 * @}
 */

/**
 * \defgroup CINDEX_MODULE Module introspection
 *
 * The functions in this group provide access to information about modules.
 *
 * @{
 */

using CXModule = System.IntPtr;

/**
 * @}
 */

/**
 * \defgroup CINDEX_CODE_COMPLET Code completion
 *
 * Code completion involves taking an (incomplete) source file, along with
 * knowledge of where the user is actively editing that file, and suggesting
 * syntactically- and semantically-valid constructs that the user might want to
 * use at that particular point in the source code. These data structures and
 * routines provide support for code completion.
 *
 * @{
 */

/**
 * A semantic string that describes a code-completion result.
 *
 * A semantic string that describes the formatting of a code-completion
 * result as a single "template" of text that should be inserted into the
 * source buffer when a particular code-completion result is selected.
 * Each semantic string is made up of some number of "chunks", each of which
 * contains some text along with a description of what that text means, e.g.,
 * the name of the entity being referenced, whether the text chunk is part of
 * the template, or whether it is a "placeholder" that the user should replace
 * with actual code,of a specific kind. See \c CXCompletionChunkKind for a
 * description of the different kinds of chunks.
 */
using CXCompletionString = System.IntPtr;


/**
 * Evaluation result of a cursor
 */
using CXEvalResult = System.IntPtr;

/**
 * @}
 */

/** \defgroup CINDEX_REMAPPING Remapping functions
 *
 * @{
 */

/**
 * A remapping of original source files and their translated files.
 */
using CXRemapping=System.IntPtr;

/**
 * The client's data object that is associated with a CXFile.
 */
using CXIdxClientFile = System.IntPtr;

/**
 * The client's data object that is associated with a semantic entity.
 */
using CXIdxClientEntity = System.IntPtr;

/**
 * The client's data object that is associated with a semantic container
 * of entities.
 */
using CXIdxClientContainer = System.IntPtr;

/**
 * The client's data object that is associated with an AST file (PCH
 * or module).
 */
using CXIdxClientASTFile = System.IntPtr;

/**
 * An indexing action/session, to be applied to one or multiple
 * translation units.
 */
using CXIndexAction = System.IntPtr;


namespace LibClang.Intertop
{
    /*===-- clang-c/Index.h - Indexing Public C Interface -------------*- C -*-===*\
    |*                                                                            *|
    |*                     The LLVM Compiler Infrastructure                       *|
    |*                                                                            *|
    |* This file is distributed under the University of Illinois Open Source      *|
    |* License. See LICENSE.TXT for details.                                      *|
    |*                                                                            *|
    |*===----------------------------------------------------------------------===*|
    |*                                                                            *|
    |* This header provides a public interface to a Clang library for extracting  *|
    |* high-level symbol information from source files without exposing the full  *|
    |* Clang C++ API.                                                             *|
    |*                                                                            *|
    \*===----------------------------------------------------------------------===*/



    /** \defgroup CINDEX libclang: C Interface to Clang
     *
     * The C Interface to Clang provides a relatively small API that exposes
     * facilities for parsing source code into an abstract syntax tree (AST),
     * loading already-parsed ASTs, traversing the AST, associating
     * physical source locations with elements within the AST, and other
     * facilities that support Clang-based development tools.
     *
     * This C interface to Clang will never provide all of the information
     * representation stored in Clang's C++ AST, nor should it: the intent is to
     * maintain an API that is relatively stable from one release to the next,
     * providing only the basic functionality needed to support development tools.
     *
     * To avoid namespace pollution, data types are prefixed with "CX" and
     * functions are prefixed with "clang_".
     *
     * @{
     */



    internal static unsafe class clang
    {

        /**
* \defgroup CINDEX_STRING String manipulation routines
* \ingroup CINDEX
*
* @{
*/





        /**
         * Retrieve the character data associated with the given string.
         */
        [DllImport("libclang.dll")] internal static unsafe extern sbyte* clang_getCString(CXString cxString);

        /**
         * Free the given string.
         */
        [DllImport("libclang.dll")] internal static extern void clang_disposeString(CXString cxString);

        /**
         * Free the given string set.
         */
        [DllImport("libclang.dll")] internal static extern void clang_disposeStringSet(CXStringSet* set);


        /**
         * Provides a shared context for creating translation units.
         *
         * It provides two options:
         *
         * - excludeDeclarationsFromPCH: When non-zero, allows enumeration of "local"
         * declarations (when loading any new translation units). A "local" declaration
         * is one that belongs in the translation unit itself and not in a precompiled
         * header that was used by the translation unit. If zero, all declarations
         * will be enumerated.
         *
         * Here is an example:
         *
         * \code
         *   // excludeDeclsFromPCH = 1, displayDiagnostics=1
         *   Idx = clang_createIndex(1, 1);
         *
         *   // IndexTest.pch was produced with the following command:
         *   // "clang -x c IndexTest.h -emit-ast -o IndexTest.pch"
         *   TU = clang_createTranslationUnit(Idx, "IndexTest.pch");
         *
         *   // This will load all the symbols from 'IndexTest.pch'
         *   clang_visitChildren(clang_getTranslationUnitCursor(TU),
         *                       TranslationUnitVisitor, 0);
         *   clang_disposeTranslationUnit(TU);
         *
         *   // This will load all the symbols from 'IndexTest.c', excluding symbols
         *   // from 'IndexTest.pch'.
         *   char *args[] = { "-Xclang", "-include-pch=IndexTest.pch" };
         *   TU = clang_createTranslationUnitFromSourceFile(Idx, "IndexTest.c", 2, args,
         *                                                  0, 0);
         *   clang_visitChildren(clang_getTranslationUnitCursor(TU),
         *                       TranslationUnitVisitor, 0);
         *   clang_disposeTranslationUnit(TU);
         * \endcode
         *
         * This process of creating the 'pch', loading it separately, and using it (via
         * -include-pch) allows 'excludeDeclsFromPCH' to remove redundant callbacks
         * (which gives the indexer the same performance benefit as the compiler).
         */
        [DllImport("libclang.dll")] internal static extern CXIndex clang_createIndex(int excludeDeclarationsFromPCH,
                                                int displayDiagnostics);

        /**
         * Destroy the given index.
         *
         * The index must not be destroyed until all of the translation units created
         * within that index have been destroyed.
         */
        [DllImport("libclang.dll")] internal static extern void clang_disposeIndex(CXIndex index);

     

        /**
         * Sets general options associated with a CXIndex.
         *
         * For example:
         * \code
         * CXIndex idx = ...;
         * clang_CXIndex_setGlobalOptions(idx,
         *     clang_CXIndex_getGlobalOptions(idx) |
         *     CXGlobalOpt_ThreadBackgroundPriorityForIndexing);
         * \endcode
         *
         * \param options A bitmask of options, a bitwise OR of CXGlobalOpt_XXX flags.
         */
        [DllImport("libclang.dll")] internal static extern void clang_CXIndex_setGlobalOptions(CXIndex index, uint options);

        /**
         * Gets the general options associated with a CXIndex.
         *
         * \returns A bitmask of options, a bitwise OR of CXGlobalOpt_XXX flags that
         * are associated with the given CXIndex object.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_CXIndex_getGlobalOptions(CXIndex index);

        /**
         * Sets the invocation emission path option in a CXIndex.
         *
         * The invocation emission path specifies a path which will contain log
         * files for certain libclang invocations. A null value (default) implies that
         * libclang invocations are not logged..
         */
        [DllImport("libclang.dll")]
        internal static extern void clang_CXIndex_setInvocationEmissionPathOption(CXIndex index, string Path);



        /**
         * Retrieve the complete file and path name of the given file.
         */
        [DllImport("libclang.dll")] internal static extern CXString clang_getFileName(CXFile SFile);

        /**
         * Retrieve the last modification time of the given file.
         */
        [DllImport("libclang.dll")] internal static extern ulong clang_getFileTime(CXFile SFile);




        /**
         * Retrieve the unique ID for the given \c file.
         *
         * \param file the file to get the ID for.
         * \param outID stores the returned CXFileUniqueID.
         * \returns If there was a failure getting the unique ID, returns non-zero,
         * otherwise returns 0.
*/
        [DllImport("libclang.dll")] internal static extern int clang_getFileUniqueID(CXFile file, out CXFileUniqueID outID);

        /**
         * Determine whether the given header is guarded against
         * multiple inclusions, either with the conventional
         * \#ifndef/\#define/\#endif macro guards or with \#pragma once.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_isFileMultipleIncludeGuarded(CXTranslationUnit tu, CXFile file);

        /**
         * Retrieve a file handle within the given translation unit.
         *
         * \param tu the translation unit
         *
         * \param file_name the name of the file.
         *
         * \returns the file handle for the named file in the translation unit \p tu,
         * or a NULL file handle if the file was not a part of this translation unit.
         */
        [DllImport("libclang.dll")] internal static extern CXFile clang_getFile(CXTranslationUnit tu, string file_name);

        /**
         * Retrieve the buffer associated with the given file.
         *
         * \param tu the translation unit
         *
         * \param file the file for which to retrieve the buffer.
         *
         * \param size [out] if non-NULL, will be set to the size of the buffer.
         *
         * \returns a pointer to the buffer in memory that holds the contents of
         * \p file, or a NULL pointer when the file is not loaded.
         */
        [DllImport("libclang.dll")]
        internal static extern sbyte* clang_getFileContents(CXTranslationUnit tu, CXFile file, out uint size);

        /**
         * Returns non-zero if the \c file1 and \c file2 point to the same file,
         * or they are both NULL.
         */
        [DllImport("libclang.dll")] internal static extern int clang_File_isEqual(CXFile file1, CXFile file2);

        /**
         * Returns the real path name of \c file.
         *
         * An empty string may be returned. Use \c clang_getFileName() in that case.
         */
        [DllImport("libclang.dll")] internal static extern CXString clang_File_tryGetRealPathName(CXFile file);





        /**
         * Retrieve a NULL (invalid) source location.
         */
        [DllImport("libclang.dll")] internal static extern CXSourceLocation clang_getNullLocation();

        /**
         * Determine whether two source locations, which must refer into
         * the same translation unit, refer to exactly the same point in the source
         * code.
         *
         * \returns non-zero if the source locations refer to the same location, zero
         * if they refer to different locations.
         */
        [DllImport("libclang.dll")]
        internal static extern uint clang_equalLocations(CXSourceLocation loc1, CXSourceLocation loc2);

        /**
         * Retrieves the source location associated with a given file/line/column
         * in a particular translation unit.
         */
        [DllImport("libclang.dll")]
        internal static extern CXSourceLocation clang_getLocation(CXTranslationUnit tu, CXFile file, uint line, uint column);
        /**
         * Retrieves the source location associated with a given character offset
         * in a particular translation unit.
         */
        [DllImport("libclang.dll")]
        internal static extern CXSourceLocation clang_getLocationForOffset(CXTranslationUnit tu, CXFile file, uint offset);

        /**
         * Returns non-zero if the given source location is in a system header.
         */
        [DllImport("libclang.dll")] internal static extern int clang_Location_isInSystemHeader(CXSourceLocation location);

        /**
         * Returns non-zero if the given source location is in the main file of
         * the corresponding translation unit.
         */
        [DllImport("libclang.dll")] internal static extern int clang_Location_isFromMainFile(CXSourceLocation location);

        /**
         * Retrieve a NULL (invalid) source range.
         */
        [DllImport("libclang.dll")] internal static extern CXSourceRange clang_getNullRange();

        /**
         * Retrieve a source range given the beginning and ending source
         * locations.
         */
        [DllImport("libclang.dll")] internal static extern CXSourceRange clang_getRange(CXSourceLocation begin, CXSourceLocation end);

        /**
         * Determine whether two ranges are equivalent.
         *
         * \returns non-zero if the ranges are the same, zero if they differ.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_equalRanges(CXSourceRange range1, CXSourceRange range2);

        /**
         * Returns non-zero if \p range is null.
         */
        [DllImport("libclang.dll")] internal static extern int clang_Range_isNull(CXSourceRange range);

        /**
         * Retrieve the file, line, column, and offset represented by
         * the given source location.
         *
         * If the location refers into a macro expansion, retrieves the
         * location of the macro expansion.
         *
         * \param location the location within a source file that will be decomposed
         * into its parts.
         *
         * \param file [out] if non-NULL, will be set to the file to which the given
         * source location points.
         *
         * \param line [out] if non-NULL, will be set to the line to which the given
         * source location points.
         *
         * \param column [out] if non-NULL, will be set to the column to which the given
         * source location points.
         *
         * \param offset [out] if non-NULL, will be set to the offset into the
         * buffer to which the given source location points.
         */
        [DllImport("libclang.dll")]
        internal static extern void clang_getExpansionLocation(CXSourceLocation location,
                                                      out CXFile file,
                                                      out uint line,
                                                      out uint column,
                                                      out uint offset);

        /**
         * Retrieve the file, line and column represented by the given source
         * location, as specified in a # line directive.
         *
         * Example: given the following source code in a file somefile.c
         *
         * \code
         * #123 "dummy.c" 1
         *
         * internal static int func()
         * {
         *     return 0;
         * }
         * \endcode
         *
         * the location information returned by this function would be
         *
         * File: dummy.c Line: 124 Column: 12
         *
         * whereas clang_getExpansionLocation would have returned
         *
         * File: somefile.c Line: 3 Column: 12
         *
         * \param location the location within a source file that will be decomposed
         * into its parts.
         *
         * \param filename [out] if non-NULL, will be set to the filename of the
         * source location. Note that filenames returned will be for "virtual" files,
         * which don't necessarily exist on the machine running clang - e.g. when
         * parsing preprocessed output obtained from a different environment. If
         * a non-NULL value is passed in, remember to dispose of the returned value
         * using \c clang_disposeString() once you've finished with it. For an invalid
         * source location, an empty string is returned.
         *
         * \param line [out] if non-NULL, will be set to the line number of the
         * source location. For an invalid source location, zero is returned.
         *
         * \param column [out] if non-NULL, will be set to the column number of the
         * source location. For an invalid source location, zero is returned.
         */
        [DllImport("libclang.dll")]
        internal static extern void clang_getPresumedLocation(CXSourceLocation location,
                                                     out CXString filename,
                                                     out uint line,
                                                     out uint column);

        /**
         * Legacy API to retrieve the file, line, column, and offset represented
         * by the given source location.
         *
         * This interface has been replaced by the newer interface
         * #clang_getExpansionLocation(). See that interface's documentation for
         * details.
         */
        [DllImport("libclang.dll")]
        internal static extern void clang_getInstantiationLocation(CXSourceLocation location,
                                                          out CXFile file,
                                                          out uint line,
                                                          out uint column,
                                                          out uint offset);

        /**
         * Retrieve the file, line, column, and offset represented by
         * the given source location.
         *
         * If the location refers into a macro instantiation, return where the
         * location was originally spelled in the source file.
         *
         * \param location the location within a source file that will be decomposed
         * into its parts.
         *
         * \param file [out] if non-NULL, will be set to the file to which the given
         * source location points.
         *
         * \param line [out] if non-NULL, will be set to the line to which the given
         * source location points.
         *
         * \param column [out] if non-NULL, will be set to the column to which the given
         * source location points.
         *
         * \param offset [out] if non-NULL, will be set to the offset into the
         * buffer to which the given source location points.
         */
        [DllImport("libclang.dll")]
        internal static extern void clang_getSpellingLocation(CXSourceLocation location,
                                                     out CXFile file,
                                                     out uint line,
                                                     out uint column,
                                                     out uint offset);

        /**
         * Retrieve the file, line, column, and offset represented by
         * the given source location.
         *
         * If the location refers into a macro expansion, return where the macro was
         * expanded or where the macro argument was written, if the location points at
         * a macro argument.
         *
         * \param location the location within a source file that will be decomposed
         * into its parts.
         *
         * \param file [out] if non-NULL, will be set to the file to which the given
         * source location points.
         *
         * \param line [out] if non-NULL, will be set to the line to which the given
         * source location points.
         *
         * \param column [out] if non-NULL, will be set to the column to which the given
         * source location points.
         *
         * \param offset [out] if non-NULL, will be set to the offset into the
         * buffer to which the given source location points.
         */
        [DllImport("libclang.dll")]
        internal static extern void clang_getFileLocation(CXSourceLocation location,
                                                 out CXFile file,
                                                 out uint line,
                                                 out uint column,
                                                 out uint offset);

        /**
         * Retrieve a source location representing the first character within a
         * source range.
         */
        [DllImport("libclang.dll")] internal static extern CXSourceLocation clang_getRangeStart(CXSourceRange range);

        /**
         * Retrieve a source location representing the last character within a
         * source range.
         */
        [DllImport("libclang.dll")] internal static extern CXSourceLocation clang_getRangeEnd(CXSourceRange range);



        /**
         * Retrieve all ranges that were skipped by the preprocessor.
         *
         * The preprocessor will skip lines when they are surrounded by an
         * if/ifdef/ifndef directive whose condition does not evaluate to true.
         */
        [DllImport("libclang.dll")]internal static extern /*CXSourceRangeList*/IntPtr clang_getSkippedRanges(CXTranslationUnit tu,
                                                                CXFile file);

        /**
         * Retrieve all ranges from all files that were skipped by the
         * preprocessor.
         *
         * The preprocessor will skip lines when they are surrounded by an
         * if/ifdef/ifndef directive whose condition does not evaluate to true.
         */
        [DllImport("libclang.dll")] internal static extern /*CXSourceRangeList*/IntPtr clang_getAllSkippedRanges(CXTranslationUnit tu);

        /**
         * Destroy the given \c CXSourceRangeList.
         */
        [DllImport("libclang.dll")] internal static extern void clang_disposeSourceRangeList(/*CXSourceRangeList*/IntPtr ranges);

     



        /**
         * Determine the number of diagnostics in a CXDiagnosticSet.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_getNumDiagnosticsInSet(CXDiagnosticSet Diags);

        /**
         * Retrieve a diagnostic associated with the given CXDiagnosticSet.
         *
         * \param Diags the CXDiagnosticSet to query.
         * \param Index the zero-based diagnostic number to retrieve.
         *
         * \returns the requested diagnostic. This diagnostic must be freed
         * via a call to \c clang_disposeDiagnostic().
         */
        [DllImport("libclang.dll")]
        internal static extern CXDiagnostic clang_getDiagnosticInSet(CXDiagnosticSet Diags,
                                                            uint Index);

     

        /**
         * Deserialize a set of diagnostics from a Clang diagnostics bitcode
         * file.
         *
         * \param file The name of the file to deserialize.
         * \param error A pointer to a enum value recording if there was a problem
         *        deserializing the diagnostics.
         * \param errorString A pointer to a CXString for recording the error string
         *        if the file was not successfully loaded.
         *
         * \returns A loaded CXDiagnosticSet if successful, and NULL otherwise.  These
         * diagnostics should be released using clang_disposeDiagnosticSet().
         */
        [DllImport("libclang.dll")]
        internal static extern CXDiagnosticSet clang_loadDiagnostics(string file,
                                                          out CXLoadDiag_Error error,
                                                         out CXString errorString);

        /**
         * Release a CXDiagnosticSet and all of its contained diagnostics.
         */
        [DllImport("libclang.dll")] internal static extern void clang_disposeDiagnosticSet(CXDiagnosticSet Diags);

        /**
         * Retrieve the child diagnostics of a CXDiagnostic.
         *
         * This CXDiagnosticSet does not need to be released by
         * clang_disposeDiagnosticSet.
         */
        [DllImport("libclang.dll")] internal static extern CXDiagnosticSet clang_getChildDiagnostics(CXDiagnostic D);

        /**
         * Determine the number of diagnostics produced for the given
         * translation unit.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_getNumDiagnostics(CXTranslationUnit Unit);

        /**
         * Retrieve a diagnostic associated with the given translation unit.
         *
         * \param Unit the translation unit to query.
         * \param Index the zero-based diagnostic number to retrieve.
         *
         * \returns the requested diagnostic. This diagnostic must be freed
         * via a call to \c clang_disposeDiagnostic().
         */
        [DllImport("libclang.dll")]
        internal static extern CXDiagnostic clang_getDiagnostic(CXTranslationUnit Unit,
                                                       uint Index);

        /**
         * Retrieve the complete set of diagnostics associated with a
         *        translation unit.
         *
         * \param Unit the translation unit to query.
         */
        [DllImport("libclang.dll")]
        internal static extern CXDiagnosticSet
         clang_getDiagnosticSetFromTU(CXTranslationUnit Unit);

        /**
         * Destroy a diagnostic.
         */
        [DllImport("libclang.dll")] internal static extern void clang_disposeDiagnostic(CXDiagnostic Diagnostic);

       
        /**
         * Format the given diagnostic in a manner that is suitable for display.
         *
         * This routine will format the given diagnostic to a string, rendering
         * the diagnostic according to the various options given. The
         * \c clang_defaultDiagnosticDisplayOptions() function returns the set of
         * options that most closely mimics the behavior of the clang compiler.
         *
         * \param Diagnostic The diagnostic to print.
         *
         * \param Options A set of options that control the diagnostic display,
         * created by combining \c CXDiagnosticDisplayOptions values.
         *
         * \returns A new string containing for formatted diagnostic.
         */
        [DllImport("libclang.dll")]
        internal static extern CXString clang_formatDiagnostic(CXDiagnostic Diagnostic,
                                                      uint Options);

        /**
         * Retrieve the set of display options most similar to the
         * default behavior of the clang compiler.
         *
         * \returns A set of display options suitable for use with \c
         * clang_formatDiagnostic().
         */
        [DllImport("libclang.dll")] internal static extern uint clang_defaultDiagnosticDisplayOptions();

        /**
         * Determine the severity of the given diagnostic.
         */
        [DllImport("libclang.dll")]
        internal static extern CXDiagnosticSeverity
       clang_getDiagnosticSeverity(CXDiagnostic CXDiagnostic);

        /**
         * Retrieve the source location of the given diagnostic.
         *
         * This location is where Clang would print the caret ('^') when
         * displaying the diagnostic on the command line.
         */
        [DllImport("libclang.dll")] internal static extern CXSourceLocation clang_getDiagnosticLocation(CXDiagnostic diagnostic);

        /**
         * Retrieve the text of the given diagnostic.
         */
        [DllImport("libclang.dll")] internal static extern CXString clang_getDiagnosticSpelling(CXDiagnostic diagnostic);

        /**
         * Retrieve the name of the command-line option that enabled this
         * diagnostic.
         *
         * \param Diag The diagnostic to be queried.
         *
         * \param Disable If non-NULL, will be set to the option that disables this
         * diagnostic (if any).
         *
         * \returns A string that contains the command-line option used to enable this
         * warning, such as "-Wconversion" or "-pedantic".
         */
        [DllImport("libclang.dll")]
        internal static extern CXString clang_getDiagnosticOption(CXDiagnostic Diag,
                                                         out CXString Disable);

        /**
         * Retrieve the category number for this diagnostic.
         *
         * Diagnostics can be categorized into groups along with other, related
         * diagnostics (e.g., diagnostics under the same warning flag). This routine
         * retrieves the category number for the given diagnostic.
         *
         * \returns The number of the category that contains this diagnostic, or zero
         * if this diagnostic is uncategorized.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_getDiagnosticCategory(CXDiagnostic diagnostic);

        /**
         * Retrieve the name of a particular diagnostic category.  This
         *  is now deprecated.  Use clang_getDiagnosticCategoryText()
         *  instead.
         *
         * \param Category A diagnostic category number, as returned by
         * \c clang_getDiagnosticCategory().
         *
         * \returns The name of the given diagnostic category.
         */
        [Obsolete]
        [DllImport("libclang.dll")]internal static extern CXString clang_getDiagnosticCategoryName(uint Category);

        /**
         * Retrieve the diagnostic category text for a given diagnostic.
         *
         * \returns The text of the given diagnostic category.
         */
        [DllImport("libclang.dll")] internal static extern CXString clang_getDiagnosticCategoryText(CXDiagnostic diagnostic);

        /**
         * Determine the number of source ranges associated with the given
         * diagnostic.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_getDiagnosticNumRanges(CXDiagnostic diagnostic);

        /**
         * Retrieve a source range associated with the diagnostic.
         *
         * A diagnostic's source ranges highlight important elements in the source
         * code. On the command line, Clang displays source ranges by
         * underlining them with '~' characters.
         *
         * \param Diagnostic the diagnostic whose range is being extracted.
         *
         * \param Range the zero-based index specifying which range to
         *
         * \returns the requested source range.
         */
        [DllImport("libclang.dll")]
        internal static extern CXSourceRange clang_getDiagnosticRange(CXDiagnostic Diagnostic,
                                                             uint Range);

        /**
         * Determine the number of fix-it hints associated with the
         * given diagnostic.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_getDiagnosticNumFixIts(CXDiagnostic Diagnostic);

        /**
         * Retrieve the replacement information for a given fix-it.
         *
         * Fix-its are described in terms of a source range whose contents
         * should be replaced by a string. This approach generalizes over
         * three kinds of operations: removal of source code (the range covers
         * the code to be removed and the replacement string is empty),
         * replacement of source code (the range covers the code to be
         * replaced and the replacement string provides the new code), and
         * insertion (both the start and end of the range point at the
         * insertion location, and the replacement string provides the text to
         * insert).
         *
         * \param Diagnostic The diagnostic whose fix-its are being queried.
         *
         * \param FixIt The zero-based index of the fix-it.
         *
         * \param ReplacementRange The source range whose contents will be
         * replaced with the returned replacement string. Note that source
         * ranges are half-open ranges [a, b), so the source code should be
         * replaced from a and up to (but not including) b.
         *
         * \returns A string containing text that should be replace the source
         * code indicated by the \c ReplacementRange.
         */
        [DllImport("libclang.dll")]
        internal static extern CXString clang_getDiagnosticFixIt(CXDiagnostic Diagnostic,
                                                        uint FixIt,
                                                      out CXSourceRange ReplacementRange);

        /**
         * @}
         */

        /**
         * \defgroup CINDEX_TRANSLATION_UNIT Translation unit manipulation
         *
         * The routines in this group provide the ability to create and destroy
         * translation units from files, either by parsing the contents of the files or
         * by reading in a serialized representation of a translation unit.
         *
         * @{
         */

        /**
         * Get the original translation unit source file name.
         */
        [DllImport("libclang.dll")]
        internal static extern CXString
       clang_getTranslationUnitSpelling(CXTranslationUnit CTUnit);

        /**
         * Return the CXTranslationUnit for a given source file and the provided
         * command line arguments one would pass to the compiler.
         *
         * Note: The 'source_filename' argument is optional.  If the caller provides a
         * NULL pointer, the name of the source file is expected to reside in the
         * specified command line arguments.
         *
         * Note: When encountered in 'clang_command_line_args', the following options
         * are ignored:
         *
         *   '-c'
         *   '-emit-ast'
         *   '-fsyntax-only'
         *   '-o \<output file>'  (both '-o' and '\<output file>' are ignored)
         *
         * \param CIdx The index object with which the translation unit will be
         * associated.
         *
         * \param source_filename The name of the source file to load, or NULL if the
         * source file is included in \p clang_command_line_args.
         *
         * \param num_clang_command_line_args The number of command-line arguments in
         * \p clang_command_line_args.
         *
         * \param clang_command_line_args The command-line arguments that would be
         * passed to the \c clang executable if it were being invoked out-of-process.
         * These command-line options will be parsed and will affect how the translation
         * unit is parsed. Note that the following options are ignored: '-c',
         * '-emit-ast', '-fsyntax-only' (which is the default), and '-o \<output file>'.
         *
         * \param num_unsaved_files the number of unsaved file entries in \p
         * unsaved_files.
         *
         * \param unsaved_files the files that have not yet been saved to disk
         * but may be required for code completion, including the contents of
         * those files.  The contents and name of these files (as specified by
         * CXUnsavedFile) are copied when necessary, so the client only needs to
         * guarantee their validity until the call to this function returns.
         */
        [DllImport("libclang.dll")]
        internal static extern CXTranslationUnit clang_createTranslationUnitFromSourceFile(
                                                CXIndex CIdx,
                                                string source_filename,
                                                int num_clang_command_line_args,
                                          sbyte** clang_command_line_args,
                                                uint num_unsaved_files,
                                                 CXUnsavedFile* unsaved_files);

        /**
         * Same as \c clang_createTranslationUnit2, but returns
         * the \c CXTranslationUnit instead of an error code.  In case of an error this
         * routine returns a \c NULL \c CXTranslationUnit, without further detailed
         * error codes.
         */
        [DllImport("libclang.dll")]
        internal static extern CXTranslationUnit clang_createTranslationUnit(
           CXIndex CIdx,
           string ast_filename);

        /**
         * Create a translation unit from an AST file (\c -emit-ast).
         *
         * \param[out] out_TU A non-NULL pointer to store the created
         * \c CXTranslationUnit.
         *
         * \returns Zero on success, otherwise returns an error code.
         */
        [DllImport("libclang.dll")]
        internal static extern CXErrorCode clang_createTranslationUnit2(
           CXIndex CIdx,
           string ast_filename,
           out CXTranslationUnit out_TU);

      

        /**
         * Returns the set of flags that is suitable for parsing a translation
         * unit that is being edited.
         *
         * The set of flags returned provide options for \c clang_parseTranslationUnit()
         * to indicate that the translation unit is likely to be reparsed many times,
         * either explicitly (via \c clang_reparseTranslationUnit()) or implicitly
         * (e.g., by code completion (\c clang_codeCompletionAt())). The returned flag
         * set contains an unspecified set of optimizations (e.g., the precompiled
         * preamble) geared toward improving the performance of these routines. The
         * set of optimizations enabled may change from one version to the next.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_defaultEditingTranslationUnitOptions();

        /**
         * Same as \c clang_parseTranslationUnit2, but returns
         * the \c CXTranslationUnit instead of an error code.  In case of an error this
         * routine returns a \c NULL \c CXTranslationUnit, without further detailed
         * error codes.
         */
        [DllImport("libclang.dll")]
        internal static extern CXTranslationUnit
       clang_parseTranslationUnit(CXIndex CIdx,
                                  string source_filename,
                                  string command_line_args,
                                  int num_command_line_args,
                                  out CXUnsavedFile unsaved_files,
                                  uint num_unsaved_files,
                                  uint options);

        /**
         * Parse the given source file and the translation unit corresponding
         * to that file.
         *
         * This routine is the main entry point for the Clang C API, providing the
         * ability to parse a source file into a translation unit that can then be
         * queried by other functions in the API. This routine accepts a set of
         * command-line arguments so that the compilation can be configured in the same
         * way that the compiler is configured on the command line.
         *
         * \param CIdx The index object with which the translation unit will be
         * associated.
         *
         * \param source_filename The name of the source file to load, or NULL if the
         * source file is included in \c command_line_args.
         *
         * \param command_line_args The command-line arguments that would be
         * passed to the \c clang executable if it were being invoked out-of-process.
         * These command-line options will be parsed and will affect how the translation
         * unit is parsed. Note that the following options are ignored: '-c',
         * '-emit-ast', '-fsyntax-only' (which is the default), and '-o \<output file>'.
         *
         * \param num_command_line_args The number of command-line arguments in
         * \c command_line_args.
         *
         * \param unsaved_files the files that have not yet been saved to disk
         * but may be required for parsing, including the contents of
         * those files.  The contents and name of these files (as specified by
         * CXUnsavedFile) are copied when necessary, so the client only needs to
         * guarantee their validity until the call to this function returns.
         *
         * \param num_unsaved_files the number of unsaved file entries in \p
         * unsaved_files.
         *
         * \param options A bitmask of options that affects how the translation unit
         * is managed but not its compilation. This should be a bitwise OR of the
         * CXTranslationUnit_XXX flags.
         *
         * \param[out] out_TU A non-NULL pointer to store the created
         * \c CXTranslationUnit, describing the parsed code and containing any
         * diagnostics produced by the compiler.
         *
         * \returns Zero on success, otherwise returns an error code.
         */
        [DllImport("libclang.dll")]
        internal static extern CXErrorCode
       clang_parseTranslationUnit2(CXIndex CIdx,
                                   string source_filename,
                                   string command_line_args,
                                   int num_command_line_args,
                                   out CXUnsavedFile unsaved_files,
                                   uint num_unsaved_files,
                                   uint options,
                                   out CXTranslationUnit out_TU);

        /**
         * Same as clang_parseTranslationUnit2 but requires a full command line
         * for \c command_line_args including argv[0]. This is useful if the standard
         * library paths are relative to the binary.
         */
        [DllImport("libclang.dll")]
        internal static extern CXErrorCode clang_parseTranslationUnit2FullArgv(
           CXIndex CIdx, string source_filename,
           string command_line_args, int num_command_line_args,
           out CXUnsavedFile unsaved_files, uint num_unsaved_files,
           uint options, out CXTranslationUnit out_TU);

     

        /**
         * Returns the set of flags that is suitable for saving a translation
         * unit.
         *
         * The set of flags returned provide options for
         * \c clang_saveTranslationUnit() by default. The returned flag
         * set contains an unspecified set of options that save translation units with
         * the most commonly-requested data.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_defaultSaveOptions(CXTranslationUnit TU);

   

        /**
         * Saves a translation unit into a serialized representation of
         * that translation unit on disk.
         *
         * Any translation unit that was parsed without error can be saved
         * into a file. The translation unit can then be deserialized into a
         * new \c CXTranslationUnit with \c clang_createTranslationUnit() or,
         * if it is an incomplete translation unit that corresponds to a
         * header, used as a precompiled header when parsing other translation
         * units.
         *
         * \param TU The translation unit to save.
         *
         * \param FileName The file to which the translation unit will be saved.
         *
         * \param options A bitmask of options that affects how the translation unit
         * is saved. This should be a bitwise OR of the
         * CXSaveTranslationUnit_XXX flags.
         *
         * \returns A value that will match one of the enumerators of the CXSaveError
         * enumeration. Zero (CXSaveError_None) indicates that the translation unit was
         * saved successfully, while a non-zero value indicates that a problem occurred.
         */
        [DllImport("libclang.dll")]
        internal static extern int clang_saveTranslationUnit(CXTranslationUnit TU,
                                                    string FileName,
                                                    uint options);

        /**
         * Suspend a translation unit in order to free memory associated with it.
         *
         * A suspended translation unit uses significantly less memory but on the other
         * side does not support any other calls than \c clang_reparseTranslationUnit
         * to resume it or \c clang_disposeTranslationUnit to dispose it completely.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_suspendTranslationUnit(CXTranslationUnit cXTranslationUnit);

        /**
         * Destroy the specified CXTranslationUnit object.
         */
        [DllImport("libclang.dll")] internal static extern void clang_disposeTranslationUnit(CXTranslationUnit cXTranslationUnit);


        /**
         * Returns the set of flags that is suitable for reparsing a translation
         * unit.
         *
         * The set of flags returned provide options for
         * \c clang_reparseTranslationUnit() by default. The returned flag
         * set contains an unspecified set of optimizations geared toward common uses
         * of reparsing. The set of optimizations enabled may change from one version
         * to the next.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_defaultReparseOptions(CXTranslationUnit TU);

        /**
         * Reparse the source files that produced this translation unit.
         *
         * This routine can be used to re-parse the source files that originally
         * created the given translation unit, for example because those source files
         * have changed (either on disk or as passed via \p unsaved_files). The
         * source code will be reparsed with the same command-line options as it
         * was originally parsed.
         *
         * Reparsing a translation unit invalidates all cursors and source locations
         * that refer into that translation unit. This makes reparsing a translation
         * unit semantically equivalent to destroying the translation unit and then
         * creating a new translation unit with the same command-line arguments.
         * However, it may be more efficient to reparse a translation
         * unit using this routine.
         *
         * \param TU The translation unit whose contents will be re-parsed. The
         * translation unit must originally have been built with
         * \c clang_createTranslationUnitFromSourceFile().
         *
         * \param num_unsaved_files The number of unsaved file entries in \p
         * unsaved_files.
         *
         * \param unsaved_files The files that have not yet been saved to disk
         * but may be required for parsing, including the contents of
         * those files.  The contents and name of these files (as specified by
         * CXUnsavedFile) are copied when necessary, so the client only needs to
         * guarantee their validity until the call to this function returns.
         *
         * \param options A bitset of options composed of the flags in CXReparse_Flags.
         * The function \c clang_defaultReparseOptions() produces a default set of
         * options recommended for most uses, based on the translation unit.
         *
         * \returns 0 if the sources could be reparsed.  A non-zero error code will be
         * returned if reparsing was impossible, such that the translation unit is
         * invalid. In such cases, the only valid call for \c TU is
         * \c clang_disposeTranslationUnit(TU).  The error codes returned by this
         * routine are described by the \c CXErrorCode enum.
         */
        [DllImport("libclang.dll")]
        internal static extern int clang_reparseTranslationUnit(CXTranslationUnit TU,
                                                       uint num_unsaved_files,
                                                 out /*CXUnsavedFile*/IntPtr unsaved_files,
                                                       uint options);

      
        /**
          * Returns the human-readable null-terminated C string that represents
          *  the name of the memory category.  This string should never be freed.
          */
        [DllImport("libclang.dll")]
        internal static extern string clang_getTUResourceUsageName(CXTUResourceUsageKind kind);


    

        /**
          * Return the memory usage of a translation unit.  This object
          *  should be released with clang_disposeCXTUResourceUsage().
          */
        [DllImport("libclang.dll")] internal static extern CXTUResourceUsage clang_getCXTUResourceUsage(CXTranslationUnit TU);

        [DllImport("libclang.dll")] internal static extern void clang_disposeCXTUResourceUsage(CXTUResourceUsage usage);

        /**
         * Get target information for this translation unit.
         *
         * The CXTargetInfo object cannot outlive the CXTranslationUnit object.
         */
        [DllImport("libclang.dll")] internal static extern CXTargetInfo  clang_getTranslationUnitTargetInfo(CXTranslationUnit CTUnit);

        /**
         * Destroy the CXTargetInfo object.
         */
        [DllImport("libclang.dll")] internal static extern void clang_TargetInfo_dispose(CXTargetInfo Info);

        /**
         * Get the normalized target triple as a string.
         *
         * Returns the empty string in case of any error.
         */
        [DllImport("libclang.dll")] internal static extern CXString clang_TargetInfo_getTriple(CXTargetInfo Info);

        /**
         * Get the pointer width of the target in bits.
         *
         * Returns -1 in case of error.
         */
        [DllImport("libclang.dll")] internal static extern int clang_TargetInfo_getPointerWidth(CXTargetInfo Info);

    


        /**
         * \defgroup CINDEX_CURSOR_MANIP Cursor manipulations
         *
         * @{
         */

        /**
         * Retrieve the NULL cursor, which represents no entity.
         */
        [DllImport("libclang.dll")] internal static extern CXCursor clang_getNullCursor();

        /**
         * Retrieve the cursor that represents the given translation unit.
         *
         * The translation unit cursor can be used to start traversing the
         * various declarations within the given translation unit.
         */
        [DllImport("libclang.dll")] internal static extern CXCursor clang_getTranslationUnitCursor(CXTranslationUnit cXTranslationUnit);

        /**
         * Determine whether two cursors are equivalent.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_equalCursors(CXCursor cXCursor1, CXCursor cXCursor2);

        /**
         * Returns non-zero if \p cursor is null.
         */
        [DllImport("libclang.dll")] internal static extern int clang_Cursor_isNull(CXCursor cursor);

        /**
         * Compute a hash value for the given cursor.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_hashCursor(CXCursor cursor);

        /**
         * Retrieve the kind of the given cursor.
         */
        [DllImport("libclang.dll")] internal static extern CXCursorKind clang_getCursorKind(CXCursor cursor);

        /**
         * Determine whether the given cursor kind represents a declaration.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_isDeclaration(CXCursorKind cXCursorKind);

        /**
         * Determine whether the given declaration is invalid.
         *
         * A declaration is invalid if it could not be parsed successfully.
         *
         * \returns non-zero if the cursor represents a declaration and it is
         * invalid, otherwise NULL.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_isInvalidDeclaration(CXCursor cursor);

        /**
         * Determine whether the given cursor kind represents a simple
         * reference.
         *
         * Note that other kinds of cursors (such as expressions) can also refer to
         * other cursors. Use clang_getCursorReferenced() to determine whether a
         * particular cursor refers to another entity.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_isReference(CXCursorKind cXCursorKind);

        /**
         * Determine whether the given cursor kind represents an expression.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_isExpression(CXCursorKind cXCursorKind);

        /**
         * Determine whether the given cursor kind represents a statement.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_isStatement(CXCursorKind cXCursorKind);

        /**
         * Determine whether the given cursor kind represents an attribute.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_isAttribute(CXCursorKind cXCursorKind);

        /**
         * Determine whether the given cursor has any attributes.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_Cursor_hasAttrs(CXCursor C);

        /**
         * Determine whether the given cursor kind represents an invalid
         * cursor.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_isInvalid(CXCursorKind cXCursorKind);

        /**
         * Determine whether the given cursor kind represents a translation
         * unit.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_isTranslationUnit(CXCursorKind cXCursorKind);

        /***
         * Determine whether the given cursor represents a preprocessing
         * element, such as a preprocessor directive or macro instantiation.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_isPreprocessing(CXCursorKind cXCursorKind);

        /***
         * Determine whether the given cursor represents a currently
         *  unexposed piece of the AST (e.g., CXCursor_UnexposedStmt).
         */
        [DllImport("libclang.dll")] internal static extern uint clang_isUnexposed(CXCursorKind cXCursorKind);



        /**
         * Determine the linkage of the entity referred to by a given cursor.
         */
        [DllImport("libclang.dll")] internal static extern CXLinkageKind clang_getCursorLinkage(CXCursor cursor);



        /**
         * Describe the visibility of the entity referred to by a cursor.
         *
         * This returns the default visibility if not explicitly specified by
         * a visibility attribute. The default visibility may be changed by
         * commandline arguments.
         *
         * \param cursor The cursor to query.
         *
         * \returns The visibility of the cursor.
         */
        [DllImport("libclang.dll")] internal static extern CXVisibilityKind clang_getCursorVisibility(CXCursor cursor);

        /**
         * Determine the availability of the entity that this cursor refers to,
         * taking the current target platform into account.
         *
         * \param cursor The cursor to query.
         *
         * \returns The availability of the cursor.
         */
        [DllImport("libclang.dll")]
        internal static extern CXAvailabilityKind
       clang_getCursorAvailability(CXCursor cursor);

      

        /**
         * Determine the availability of the entity that this cursor refers to
         * on any platforms for which availability information is known.
         *
         * \param cursor The cursor to query.
         *
         * \param always_deprecated If non-NULL, will be set to indicate whether the
         * entity is deprecated on all platforms.
         *
         * \param deprecated_message If non-NULL, will be set to the message text
         * provided along with the unconditional deprecation of this entity. The client
         * is responsible for deallocating this string.
         *
         * \param always_unavailable If non-NULL, will be set to indicate whether the
         * entity is unavailable on all platforms.
         *
         * \param unavailable_message If non-NULL, will be set to the message text
         * provided along with the unconditional unavailability of this entity. The
         * client is responsible for deallocating this string.
         *
         * \param availability If non-NULL, an array of CXPlatformAvailability instances
         * that will be populated with platform availability information, up to either
         * the number of platforms for which availability information is available (as
         * returned by this function) or \c availability_size, whichever is smaller.
         *
         * \param availability_size The number of elements available in the
         * \c availability array.
         *
         * \returns The number of platforms (N) for which availability information is
         * available (which is unrelated to \c availability_size).
         *
         * Note that the client is responsible for calling
         * \c clang_disposeCXPlatformAvailability to free each of the
         * platform-availability structures returned. There are
         * \c min(N, availability_size) such structures.
         */
        [DllImport("libclang.dll")]
        internal static extern int
       clang_getCursorPlatformAvailability(CXCursor cursor,
                                           out int always_deprecated,
                                           out CXString deprecated_message,
                                           out int always_unavailable,
                                           out CXString unavailable_message,
                                           out CXPlatformAvailability availability,
                                           int availability_size);

        /**
         * Free the memory associated with a \c CXPlatformAvailability structure.
         */
        [DllImport("libclang.dll")]
        internal static extern void
       clang_disposeCXPlatformAvailability(CXPlatformAvailability availability);


        /**
         * Determine the "language" of the entity referred to by a given cursor.
         */
        [DllImport("libclang.dll")] internal static extern CXLanguageKind clang_getCursorLanguage(CXCursor cursor);



        /**
         * Determine the "thread-local storage (TLS) kind" of the declaration
         * referred to by a cursor.
         */
        [DllImport("libclang.dll")] internal static extern CXTLSKind clang_getCursorTLSKind(CXCursor cursor);

        /**
         * Returns the translation unit that a cursor originated from.
         */
        [DllImport("libclang.dll")] internal static extern CXTranslationUnit clang_Cursor_getTranslationUnit(CXCursor cursor);



        /**
         * Creates an empty CXCursorSet.
         */
        [DllImport("libclang.dll")] internal static extern CXCursorSet clang_createCXCursorSet();

        /**
         * Disposes a CXCursorSet and releases its associated memory.
         */
        [DllImport("libclang.dll")] internal static extern void clang_disposeCXCursorSet(CXCursorSet cset);

        /**
         * Queries a CXCursorSet to see if it contains a specific CXCursor.
         *
         * \returns non-zero if the set contains the specified cursor.
*/
        [DllImport("libclang.dll")]
        internal static extern uint clang_CXCursorSet_contains(CXCursorSet cset,
                                                          CXCursor cursor);

        /**
         * Inserts a CXCursor into a CXCursorSet.
         *
         * \returns zero if the CXCursor was already in the set, and non-zero otherwise.
*/
        [DllImport("libclang.dll")]
        internal static extern uint clang_CXCursorSet_insert(CXCursorSet cset,
                                                        CXCursor cursor);

        /**
         * Determine the semantic parent of the given cursor.
         *
         * The semantic parent of a cursor is the cursor that semantically contains
         * the given \p cursor. For many declarations, the lexical and semantic parents
         * are equivalent (the lexical parent is returned by
         * \c clang_getCursorLexicalParent()). They diverge when declarations or
         * definitions are provided out-of-line. For example:
         *
         * \code
         * class C {
         *  void f();
         * };
         *
         * void C::f() { }
         * \endcode
         *
         * In the out-of-line definition of \c C::f, the semantic parent is
         * the class \c C, of which this function is a member. The lexical parent is
         * the place where the declaration actually occurs in the source code; in this
         * case, the definition occurs in the translation unit. In general, the
         * lexical parent for a given entity can change without affecting the semantics
         * of the program, and the lexical parent of different declarations of the
         * same entity may be different. Changing the semantic parent of a declaration,
         * on the other hand, can have a major impact on semantics, and redeclarations
         * of a particular entity should all have the same semantic context.
         *
         * In the example above, both declarations of \c C::f have \c C as their
         * semantic context, while the lexical context of the first \c C::f is \c C
         * and the lexical context of the second \c C::f is the translation unit.
         *
         * For global declarations, the semantic parent is the translation unit.
         */
        [DllImport("libclang.dll")] internal static extern CXCursor clang_getCursorSemanticParent(CXCursor cursor);

        /**
         * Determine the lexical parent of the given cursor.
         *
         * The lexical parent of a cursor is the cursor in which the given \p cursor
         * was actually written. For many declarations, the lexical and semantic parents
         * are equivalent (the semantic parent is returned by
         * \c clang_getCursorSemanticParent()). They diverge when declarations or
         * definitions are provided out-of-line. For example:
         *
         * \code
         * class C {
         *  void f();
         * };
         *
         * void C::f() { }
         * \endcode
         *
         * In the out-of-line definition of \c C::f, the semantic parent is
         * the class \c C, of which this function is a member. The lexical parent is
         * the place where the declaration actually occurs in the source code; in this
         * case, the definition occurs in the translation unit. In general, the
         * lexical parent for a given entity can change without affecting the semantics
         * of the program, and the lexical parent of different declarations of the
         * same entity may be different. Changing the semantic parent of a declaration,
         * on the other hand, can have a major impact on semantics, and redeclarations
         * of a particular entity should all have the same semantic context.
         *
         * In the example above, both declarations of \c C::f have \c C as their
         * semantic context, while the lexical context of the first \c C::f is \c C
         * and the lexical context of the second \c C::f is the translation unit.
         *
         * For declarations written in the global scope, the lexical parent is
         * the translation unit.
         */
        [DllImport("libclang.dll")] internal static extern CXCursor clang_getCursorLexicalParent(CXCursor cursor);

        /**
         * Determine the set of methods that are overridden by the given
         * method.
         *
         * In both Objective-C and C++, a method (aka virtual member function,
         * in C++) can override a virtual method in a base class. For
         * Objective-C, a method is said to override any method in the class's
         * base class, its protocols, or its categories' protocols, that has the same
         * selector and is of the same kind (class or instance).
         * If no such method exists, the search continues to the class's superclass,
         * its protocols, and its categories, and so on. A method from an Objective-C
         * implementation is considered to override the same methods as its
         * corresponding method in the interface.
         *
         * For C++, a virtual member function overrides any virtual member
         * function with the same signature that occurs in its base
         * classes. With multiple inheritance, a virtual member function can
         * override several virtual member functions coming from different
         * base classes.
         *
         * In all cases, this function determines the immediate overridden
         * method, rather than all of the overridden methods. For example, if
         * a method is originally declared in a class A, then overridden in B
         * (which in inherits from A) and also in C (which inherited from B),
         * then the only overridden method returned from this function when
         * invoked on C's method will be B's method. The client may then
         * invoke this function again, given the previously-found overridden
         * methods, to map out the complete method-override set.
         *
         * \param cursor A cursor representing an Objective-C or C++
         * method. This routine will compute the set of methods that this
         * method overrides.
         *
         * \param overridden A pointer whose pointee will be replaced with a
         * pointer to an array of cursors, representing the set of overridden
         * methods. If there are no overridden methods, the pointee will be
         * set to NULL. The pointee must be freed via a call to
         * \c clang_disposeOverriddenCursors().
         *
         * \param num_overridden A pointer to the number of overridden
         * functions, will be set to the number of overridden functions in the
         * array pointed to by \p overridden.
         */
        [DllImport("libclang.dll")]
        internal static extern void clang_getOverriddenCursors(CXCursor cursor,
                                                      out CXCursor overridden,
                                                      out uint num_overridden);

        /**
         * Free the set of overridden cursors returned by \c
         * clang_getOverriddenCursors().
         */
        [DllImport("libclang.dll")] internal static extern void clang_disposeOverriddenCursors(CXCursor overridden);

        /**
         * Retrieve the file that is included by the given inclusion directive
         * cursor.
         */
        [DllImport("libclang.dll")] internal static extern CXFile clang_getIncludedFile(CXCursor cursor);

        /**
         * @}
         */

        /**
         * \defgroup CINDEX_CURSOR_SOURCE Mapping between cursors and source code
         *
         * Cursors represent a location within the Abstract Syntax Tree (AST). These
         * routines help map between cursors and the physical locations where the
         * described entities occur in the source code. The mapping is provided in
         * both directions, so one can map from source code to the AST and back.
         *
         * @{
         */

        /**
         * Map a source location to the cursor that describes the entity at that
         * location in the source code.
         *
         * clang_getCursor() maps an arbitrary source location within a translation
         * unit down to the most specific cursor that describes the entity at that
         * location. For example, given an expression \c x + y, invoking
         * clang_getCursor() with a source location pointing to "x" will return the
         * cursor for "x"; similarly for "y". If the cursor points anywhere between
         * "x" or "y" (e.g., on the + or the whitespace around it), clang_getCursor()
         * will return a cursor referring to the "+" expression.
         *
         * \returns a cursor representing the entity at the given source location, or
         * a NULL cursor if no such entity can be found.
         */
        [DllImport("libclang.dll")] internal static extern CXCursor clang_getCursor(CXTranslationUnit cXTranslationUnit, CXSourceLocation cXSourceLocation);

        /**
         * Retrieve the physical location of the source constructor referenced
         * by the given cursor.
         *
         * The location of a declaration is typically the location of the name of that
         * declaration, where the name of that declaration would occur if it is
         * unnamed, or some keyword that introduces that particular declaration.
         * The location of a reference is where that reference occurs within the
         * source code.
         */
        [DllImport("libclang.dll")] internal static extern CXSourceLocation clang_getCursorLocation(CXCursor cursor);

        /**
         * Retrieve the physical extent of the source construct referenced by
         * the given cursor.
         *
         * The extent of a cursor starts with the file/line/column pointing at the
         * first character within the source construct that the cursor refers to and
         * ends with the last character within that source construct. For a
         * declaration, the extent covers the declaration itself. For a reference,
         * the extent covers the location of the reference (e.g., where the referenced
         * entity was actually used).
         */
        [DllImport("libclang.dll")] internal static extern CXSourceRange clang_getCursorExtent(CXCursor cursor);

        


        /**
         * Retrieve the type of a CXCursor (if any).
         */
        [DllImport("libclang.dll")] internal static extern CXType clang_getCursorType(CXCursor C);

        /**
         * Pretty-print the underlying type using the rules of the
         * language of the translation unit from which it came.
         *
         * If the type is invalid, an empty string is returned.
         */
        [DllImport("libclang.dll")] internal static extern CXString clang_getTypeSpelling(CXType CT);

        /**
         * Retrieve the underlying type of a typedef declaration.
         *
         * If the cursor does not reference a typedef declaration, an invalid type is
         * returned.
         */
        [DllImport("libclang.dll")] internal static extern CXType clang_getTypedefDeclUnderlyingType(CXCursor C);

        /**
         * Retrieve the integer type of an enum declaration.
         *
         * If the cursor does not reference an enum declaration, an invalid type is
         * returned.
         */
        [DllImport("libclang.dll")] internal static extern CXType clang_getEnumDeclIntegerType(CXCursor C);

        /**
         * Retrieve the integer value of an enum constant declaration as a signed
         *  long.
         *
         * If the cursor does not reference an enum constant declaration, LLONG_MIN is returned.
         * Since this is also potentially a valid constant value, the kind of the cursor
         * must be verified before calling this function.
         */
        [DllImport("libclang.dll")] internal static extern long clang_getEnumConstantDeclValue(CXCursor C);

        /**
         * Retrieve the integer value of an enum constant declaration as an uint
         *  long.
         *
         * If the cursor does not reference an enum constant declaration, ULLONG_MAX is returned.
         * Since this is also potentially a valid constant value, the kind of the cursor
         * must be verified before calling this function.
         */
        [DllImport("libclang.dll")] internal static extern ulong clang_getEnumConstantDecluintValue(CXCursor C);

        /**
         * Retrieve the bit width of a bit field declaration as an integer.
         *
         * If a cursor that is not a bit field declaration is passed in, -1 is returned.
         */
        [DllImport("libclang.dll")] internal static extern int clang_getFieldDeclBitWidth(CXCursor C);

        /**
         * Retrieve the number of non-variadic arguments associated with a given
         * cursor.
         *
         * The number of arguments can be determined for calls as well as for
         * declarations of functions or methods. For other cursors -1 is returned.
         */
        [DllImport("libclang.dll")] internal static extern int clang_Cursor_getNumArguments(CXCursor C);

        /**
         * Retrieve the argument cursor of a function or method.
         *
         * The argument cursor can be determined for calls as well as for declarations
         * of functions or methods. For other cursors and for invalid indices, an
         * invalid cursor is returned.
         */
        [DllImport("libclang.dll")] internal static extern CXCursor clang_Cursor_getArgument(CXCursor C, uint i);

       

        /**
         *Returns the number of template args of a function decl representing a
         * template specialization.
         *
         * If the argument cursor cannot be converted into a template function
         * declaration, -1 is returned.
         *
         * For example, for the following declaration and specialization:
         *   template <typename T, int kInt, bool kBool>
         *   void foo() { ... }
         *
         *   template <>
         *   void foo<float, -7, true>();
         *
         * The value 3 would be returned from this call.
         */
        [DllImport("libclang.dll")] internal static extern int clang_Cursor_getNumTemplateArguments(CXCursor C);

        /**
         * Retrieve the kind of the I'th template argument of the CXCursor C.
         *
         * If the argument CXCursor does not represent a FunctionDecl, an invalid
         * template argument kind is returned.
         *
         * For example, for the following declaration and specialization:
         *   template <typename T, int kInt, bool kBool>
         *   void foo() { ... }
         *
         *   template <>
         *   void foo<float, -7, true>();
         *
         * For I = 0, 1, and 2, Type, Integral, and Integral will be returned,
         * respectively.
         */
        [DllImport("libclang.dll")]
        internal static extern CXTemplateArgumentKind clang_Cursor_getTemplateArgumentKind(
           CXCursor C, uint I);

        /**
         * Retrieve a CXType representing the type of a TemplateArgument of a
         *  function decl representing a template specialization.
         *
         * If the argument CXCursor does not represent a FunctionDecl whose I'th
         * template argument has a kind of CXTemplateArgKind_Integral, an invalid type
         * is returned.
         *
         * For example, for the following declaration and specialization:
         *   template <typename T, int kInt, bool kBool>
         *   void foo() { ... }
         *
         *   template <>
         *   void foo<float, -7, true>();
         *
         * If called with I = 0, "float", will be returned.
         * Invalid types will be returned for I == 1 or 2.
         */
        [DllImport("libclang.dll")]
        internal static extern CXType clang_Cursor_getTemplateArgumentType(CXCursor C,
                                                                  uint I);

        /**
         * Retrieve the value of an Integral TemplateArgument (of a function
         *  decl representing a template specialization) as a signed long.
         *
         * It is undefined to call this function on a CXCursor that does not represent a
         * FunctionDecl or whose I'th template argument is not an integral value.
         *
         * For example, for the following declaration and specialization:
         *   template <typename T, int kInt, bool kBool>
         *   void foo() { ... }
         *
         *   template <>
         *   void foo<float, -7, true>();
         *
         * If called with I = 1 or 2, -7 or true will be returned, respectively.
         * For I == 0, this function's behavior is undefined.
         */
        [DllImport("libclang.dll")]
        internal static extern long clang_Cursor_getTemplateArgumentValue(CXCursor C,
                                                                      uint I);

        /**
         * Retrieve the value of an Integral TemplateArgument (of a function
         *  decl representing a template specialization) as an ulong.
         *
         * It is undefined to call this function on a CXCursor that does not represent a
         * FunctionDecl or whose I'th template argument is not an integral value.
         *
         * For example, for the following declaration and specialization:
         *   template <typename T, int kInt, bool kBool>
         *   void foo() { ... }
         *
         *   template <>
         *   void foo<float, 2147483649, true>();
         *
         * If called with I = 1 or 2, 2147483649 or true will be returned, respectively.
         * For I == 0, this function's behavior is undefined.
         */
        [DllImport("libclang.dll")]
        internal static extern ulong clang_Cursor_getTemplateArgumentuintValue(
           CXCursor C, uint I);

        /**
         * Determine whether two CXTypes represent the same type.
         *
         * \returns non-zero if the CXTypes represent the same type and
         *          zero otherwise.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_equalTypes(CXType A, CXType B);

        /**
         * Return the canonical type for a CXType.
         *
         * Clang's type system explicitly models typedefs and all the ways
         * a specific type can be represented.  The canonical type is the underlying
         * type with all the "sugar" removed.  For example, if 'T' is a typedef
         * for 'int', the canonical type for 'T' would be 'int'.
         */
        [DllImport("libclang.dll")] internal static extern CXType clang_getCanonicalType(CXType T);

        /**
         * Determine whether a CXType has the "const" qualifier set,
         * without looking through typedefs that may have added "const" at a
         * different level.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_isConstQualifiedType(CXType T);

        /**
         * Determine whether a  CXCursor that is a macro, is
         * function like.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_Cursor_isMacroFunctionLike(CXCursor C);

        /**
         * Determine whether a  CXCursor that is a macro, is a
         * builtin one.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_Cursor_isMacroBuiltin(CXCursor C);

        /**
         * Determine whether a  CXCursor that is a function declaration, is an
         * inline declaration.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_Cursor_isFunctionInlined(CXCursor C);

        /**
         * Determine whether a CXType has the "volatile" qualifier set,
         * without looking through typedefs that may have added "volatile" at
         * a different level.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_isVolatileQualifiedType(CXType T);

        /**
         * Determine whether a CXType has the "restrict" qualifier set,
         * without looking through typedefs that may have added "restrict" at a
         * different level.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_isRestrictQualifiedType(CXType T);

        /**
         * Returns the address space of the given type.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_getAddressSpace(CXType T);

        /**
         * Returns the typedef name of the given type.
         */
        [DllImport("libclang.dll")] internal static extern CXString clang_getTypedefName(CXType CT);

        /**
         * For pointer types, returns the type of the pointee.
         */
        [DllImport("libclang.dll")] internal static extern CXType clang_getPointeeType(CXType T);

        /**
         * Return the cursor for the declaration of the given type.
         */
        [DllImport("libclang.dll")] internal static extern CXCursor clang_getTypeDeclaration(CXType T);

        /**
         * Returns the Objective-C type encoding for the specified declaration.
         */
        [DllImport("libclang.dll")] internal static extern CXString clang_getDeclObjCTypeEncoding(CXCursor C);

        /**
         * Returns the Objective-C type encoding for the specified CXType.
         */
        [DllImport("libclang.dll")] internal static extern CXString clang_Type_getObjCEncoding(CXType type);

        /**
         * Retrieve the spelling of a given CXTypeKind.
         */
        [DllImport("libclang.dll")] internal static extern CXString clang_getTypeKindSpelling(CXTypeKind K);

        /**
         * Retrieve the calling convention associated with a function type.
         *
         * If a non-function type is passed in, CXCallingConv_Invalid is returned.
         */
        [DllImport("libclang.dll")] internal static extern CXCallingConv clang_getFunctionTypeCallingConv(CXType T);

        /**
         * Retrieve the return type associated with a function type.
         *
         * If a non-function type is passed in, an invalid type is returned.
         */
        [DllImport("libclang.dll")] internal static extern CXType clang_getResultType(CXType T);

        /**
         * Retrieve the exception specification type associated with a function type.
         * This is a value of type CXCursor_ExceptionSpecificationKind.
         *
         * If a non-function type is passed in, an error code of -1 is returned.
         */
        [DllImport("libclang.dll")] internal static extern int clang_getExceptionSpecificationType(CXType T);

        /**
         * Retrieve the number of non-variadic parameters associated with a
         * function type.
         *
         * If a non-function type is passed in, -1 is returned.
         */
        [DllImport("libclang.dll")] internal static extern int clang_getNumArgTypes(CXType T);

        /**
         * Retrieve the type of a parameter of a function type.
         *
         * If a non-function type is passed in or the function does not have enough
         * parameters, an invalid type is returned.
         */
        [DllImport("libclang.dll")] internal static extern CXType clang_getArgType(CXType T, uint i);

        /**
         * Return 1 if the CXType is a variadic function type, and 0 otherwise.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_isFunctionTypeVariadic(CXType T);

        /**
         * Retrieve the return type associated with a given cursor.
         *
         * This only returns a valid type if the cursor refers to a function or method.
         */
        [DllImport("libclang.dll")] internal static extern CXType clang_getCursorResultType(CXCursor C);

        /**
         * Retrieve the exception specification type associated with a given cursor.
         * This is a value of type CXCursor_ExceptionSpecificationKind.
         *
         * This only returns a valid result if the cursor refers to a function or method.
         */
        [DllImport("libclang.dll")] internal static extern int clang_getCursorExceptionSpecificationType(CXCursor C);

        /**
         * Return 1 if the CXType is a POD (plain old data) type, and 0
         *  otherwise.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_isPODType(CXType T);

        /**
         * Return the element type of an array, complex, or vector type.
         *
         * If a type is passed in that is not an array, complex, or vector type,
         * an invalid type is returned.
         */
        [DllImport("libclang.dll")] internal static extern CXType clang_getElementType(CXType T);

        /**
         * Return the number of elements of an array or vector type.
         *
         * If a type is passed in that is not an array or vector type,
         * -1 is returned.
         */
        [DllImport("libclang.dll")] internal static extern long clang_getNumElements(CXType T);

        /**
         * Return the element type of an array type.
         *
         * If a non-array type is passed in, an invalid type is returned.
         */
        [DllImport("libclang.dll")] internal static extern CXType clang_getArrayElementType(CXType T);

        /**
         * Return the array size of a constant array.
         *
         * If a non-array type is passed in, -1 is returned.
         */
        [DllImport("libclang.dll")] internal static extern long clang_getArraySize(CXType T);

        /**
         * Retrieve the type named by the qualified-id.
         *
         * If a non-elaborated type is passed in, an invalid type is returned.
         */
        [DllImport("libclang.dll")] internal static extern CXType clang_Type_getNamedType(CXType T);

        /**
         * Determine if a typedef is 'transparent' tag.
         *
         * A typedef is considered 'transparent' if it shares a name and spelling
         * location with its underlying tag type, as is the case with the NS_ENUM macro.
         *
         * \returns non-zero if transparent and zero otherwise.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_Type_isTransparentTagTypedef(CXType T);

     

        /**
         * Return the alignment of a type in bytes as per C++[expr.alignof]
         *   standard.
         *
         * If the type declaration is invalid, CXTypeLayoutError_Invalid is returned.
         * If the type declaration is an incomplete type, CXTypeLayoutError_Incomplete
         *   is returned.
         * If the type declaration is a dependent type, CXTypeLayoutError_Dependent is
         *   returned.
         * If the type declaration is not a constant size type,
         *   CXTypeLayoutError_NotConstantSize is returned.
         */
        [DllImport("libclang.dll")] internal static extern long clang_Type_getAlignOf(CXType T);

        /**
         * Return the class type of an member pointer type.
         *
         * If a non-member-pointer type is passed in, an invalid type is returned.
         */
        [DllImport("libclang.dll")] internal static extern CXType clang_Type_getClassType(CXType T);

        /**
         * Return the size of a type in bytes as per C++[expr.sizeof] standard.
         *
         * If the type declaration is invalid, CXTypeLayoutError_Invalid is returned.
         * If the type declaration is an incomplete type, CXTypeLayoutError_Incomplete
         *   is returned.
         * If the type declaration is a dependent type, CXTypeLayoutError_Dependent is
         *   returned.
         */
        [DllImport("libclang.dll")] internal static extern long clang_Type_getSizeOf(CXType T);

        /**
         * Return the offset of a field named S in a record of type T in bits
         *   as it would be returned by __offsetof__ as per C++11[18.2p4]
         *
         * If the cursor is not a record field declaration, CXTypeLayoutError_Invalid
         *   is returned.
         * If the field's type declaration is an incomplete type,
         *   CXTypeLayoutError_Incomplete is returned.
         * If the field's type declaration is a dependent type,
         *   CXTypeLayoutError_Dependent is returned.
         * If the field's name S is not found,
         *   CXTypeLayoutError_InvalidFieldName is returned.
         */
        [DllImport("libclang.dll")] internal static extern long clang_Type_getOffsetOf(CXType T, string S);

        /**
         * Return the offset of the field represented by the Cursor.
         *
         * If the cursor is not a field declaration, -1 is returned.
         * If the cursor semantic parent is not a record field declaration,
         *   CXTypeLayoutError_Invalid is returned.
         * If the field's type declaration is an incomplete type,
         *   CXTypeLayoutError_Incomplete is returned.
         * If the field's type declaration is a dependent type,
         *   CXTypeLayoutError_Dependent is returned.
         * If the field's name S is not found,
         *   CXTypeLayoutError_InvalidFieldName is returned.
         */
        [DllImport("libclang.dll")] internal static extern long clang_Cursor_getOffsetOfField(CXCursor C);

        /**
         * Determine whether the given cursor represents an anonymous record
         * declaration.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_Cursor_isAnonymous(CXCursor C);

      

        /**
         * Returns the number of template arguments for given template
         * specialization, or -1 if type \c T is not a template specialization.
         */
        [DllImport("libclang.dll")] internal static extern int clang_Type_getNumTemplateArguments(CXType T);

        /**
         * Returns the type template argument of a template class specialization
         * at given index.
         *
         * This function only returns template type arguments and does not handle
         * template template arguments or variadic packs.
         */
        [DllImport("libclang.dll")] internal static extern CXType clang_Type_getTemplateArgumentAsType(CXType T, uint i);

        /**
         * Retrieve the ref-qualifier kind of a function or method.
         *
         * The ref-qualifier is returned for C++ functions or methods. For other types
         * or non-C++ declarations, CXRefQualifier_None is returned.
         */
        [DllImport("libclang.dll")] internal static extern CXRefQualifierKind clang_Type_getCXXRefQualifier(CXType T);

        /**
         * Returns non-zero if the cursor specifies a Record member that is a
         *   bitfield.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_Cursor_isBitField(CXCursor C);

        /**
         * Returns 1 if the base class specified by the cursor with kind
         *   CX_CXXBaseSpecifier is virtual.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_isVirtualBase(CXCursor cursor);



        /**
         * Returns the access control level for the referenced object.
         *
         * If the cursor refers to a C++ declaration, its access control level within its
         * parent scope is returned. Otherwise, if the cursor refers to a base specifier or
         * access specifier, the specifier itself is returned.
         */
        [DllImport("libclang.dll")] internal static extern CX_CXXAccessSpecifier clang_getCXXAccessSpecifier(CXCursor cursor);



        /**
         * Returns the storage class for a function or variable declaration.
         *
         * If the passed in Cursor is not a function or variable declaration,
         * CX_SC_Invalid is returned else the storage class.
         */
        [DllImport("libclang.dll")] internal static extern CX_StorageClass clang_Cursor_getStorageClass(CXCursor cursor);

        /**
         * Determine the number of overloaded declarations referenced by a
         * \c CXCursor_OverloadedDeclRef cursor.
         *
         * \param cursor The cursor whose overloaded declarations are being queried.
         *
         * \returns The number of overloaded declarations referenced by \c cursor. If it
         * is not a \c CXCursor_OverloadedDeclRef cursor, returns 0.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_getNumOverloadedDecls(CXCursor cursor);

        /**
         * Retrieve a cursor for one of the overloaded declarations referenced
         * by a \c CXCursor_OverloadedDeclRef cursor.
         *
         * \param cursor The cursor whose overloaded declarations are being queried.
         *
         * \param index The zero-based index into the set of overloaded declarations in
         * the cursor.
         *
         * \returns A cursor representing the declaration referenced by the given
         * \c cursor at the specified \c index. If the cursor does not have an
         * associated set of overloaded declarations, or if the index is out of bounds,
         * returns \c clang_getNullCursor();
         */
        [DllImport("libclang.dll")]
        internal static extern CXCursor clang_getOverloadedDecl(CXCursor cursor,
                                                       uint index);

        /**
         * @}
         */

        /**
         * \defgroup CINDEX_ATTRIBUTES Information for attributes
         *
         * @{
         */

        /**
         * For cursors representing an iboutletcollection attribute,
         *  this function returns the collection element type.
         *
         */
        [DllImport("libclang.dll")] internal static extern CXType clang_getIBOutletCollectionType(CXCursor cursor);


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

        /**
         * Visit the children of a particular cursor.
         *
         * This function visits all the direct children of the given cursor,
         * invoking the given \p visitor function with the cursors of each
         * visited child. The traversal may be recursive, if the visitor returns
         * \c CXChildVisit_Recurse. The traversal may also be ended prematurely, if
         * the visitor returns \c CXChildVisit_Break.
         *
         * \param parent the cursor whose child may be visited. All kinds of
         * cursors can be visited, including invalid cursors (which, by
         * definition, have no children).
         *
         * \param visitor the visitor function that will be invoked for each
         * child of \p parent.
         *
         * \param client_data pointer data supplied by the client, which will
         * be passed to the visitor each time it is invoked.
         *
         * \returns a non-zero value if the traversal was terminated
         * prematurely by the visitor returning \c CXChildVisit_Break.
         */
        [DllImport("libclang.dll")]
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

        /**
         * Visits the children of a cursor using the specified block.  Behaves
         * identically to clang_visitChildren() in all other respects.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_visitChildrenWithBlock(CXCursor parent, CXCursorVisitorBlock block);


        /**
         * @}
         */

        /**
         * \defgroup CINDEX_CURSOR_XREF Cross-referencing in the AST
         *
         * These routines provide the ability to determine references within and
         * across translation units, by providing the names of the entities referenced
         * by cursors, follow reference cursors to the declarations they reference,
         * and associate declarations with their definitions.
         *
         * @{
         */

        /**
         * Retrieve a Unified Symbol Resolution (USR) for the entity referenced
         * by the given cursor.
         *
         * A Unified Symbol Resolution (USR) is a string that identifies a particular
         * entity (function, class, variable, etc.) within a program. USRs can be
         * compared across translation units to determine, e.g., when references in
         * one translation refer to an entity defined in another translation unit.
         */
        [DllImport("libclang.dll")] internal static extern CXString clang_getCursorUSR(CXCursor cursor);

        /**
         * Construct a USR for a specified Objective-C class.
         */
        [DllImport("libclang.dll")] internal static extern CXString clang_constructUSR_ObjCClass(string class_name);

        /**
         * Construct a USR for a specified Objective-C category.
         */
        [DllImport("libclang.dll")]
        internal static extern CXString
         clang_constructUSR_ObjCCategory(string class_name,
                                        string category_name);

        /**
         * Construct a USR for a specified Objective-C protocol.
         */
        [DllImport("libclang.dll")]
        internal static extern CXString
         clang_constructUSR_ObjCProtocol(string protocol_name);

        /**
         * Construct a USR for a specified Objective-C instance variable and
         *   the USR for its containing class.
         */
        [DllImport("libclang.dll")]
        internal static extern CXString clang_constructUSR_ObjCIvar(string name,
                                                           CXString classUSR);

        /**
         * Construct a USR for a specified Objective-C method and
         *   the USR for its containing class.
         */
        [DllImport("libclang.dll")]
        internal static extern CXString clang_constructUSR_ObjCMethod(string name,
                                                             uint isInstanceMethod,
                                                             CXString classUSR);

        /**
         * Construct a USR for a specified Objective-C property and the USR
         *  for its containing class.
         */
        [DllImport("libclang.dll")]
        internal static extern CXString clang_constructUSR_ObjCProperty(string property,
                                                               CXString classUSR);

        /**
         * Retrieve a name for the entity referenced by this cursor.
         */
        [DllImport("libclang.dll")] internal static extern CXString clang_getCursorSpelling(CXCursor cursor);

        /**
         * Retrieve a range for a piece that forms the cursors spelling name.
         * Most of the times there is only one range for the complete spelling but for
         * Objective-C methods and Objective-C message expressions, there are multiple
         * pieces for each selector identifier.
         *
         * \param pieceIndex the index of the spelling name piece. If this is greater
         * than the actual number of pieces, it will return a NULL (invalid) range.
         *
         * \param options Reserved.
         */
        [DllImport("libclang.dll")]
        internal static extern CXSourceRange clang_Cursor_getSpellingNameRange(CXCursor cXCursor,
                                                                 uint pieceIndex,
                                                                 uint options);



      
        /**
         * Get a property value for the given printing policy.
         */
        [DllImport("libclang.dll")]
        internal static extern uint
       clang_PrintingPolicy_getProperty(CXPrintingPolicy Policy,
                                         CXPrintingPolicyProperty Property);

        /**
         * Set a property value for the given printing policy.
         */
        [DllImport("libclang.dll")]
        internal static extern void clang_PrintingPolicy_setProperty(CXPrintingPolicy Policy,
                                                             CXPrintingPolicyProperty Property,
                                                            uint Value);

        /**
         * Retrieve the default policy for the cursor.
         *
         * The policy should be released after use with \c
         * clang_PrintingPolicy_dispose.
         */
        [DllImport("libclang.dll")] internal static extern CXPrintingPolicy clang_getCursorPrintingPolicy(CXCursor cursor);

        /**
         * Release a printing policy.
         */
        [DllImport("libclang.dll")] internal static extern void clang_PrintingPolicy_dispose(CXPrintingPolicy Policy);

        /**
         * Pretty print declarations.
         *
         * \param Cursor The cursor representing a declaration.
         *
         * \param Policy The policy to control the entities being printed. If
         * NULL, a default policy is used.
         *
         * \returns The pretty printed declaration or the empty string for
         * other cursors.
         */
        [DllImport("libclang.dll")]
        internal static extern CXString clang_getCursorPrettyPrinted(CXCursor Cursor,
                                                            CXPrintingPolicy Policy);

        /**
         * Retrieve the display name for the entity referenced by this cursor.
         *
         * The display name contains extra information that helps identify the cursor,
         * such as the parameters of a function or template or the arguments of a
         * class template specialization.
         */
        [DllImport("libclang.dll")] internal static extern CXString clang_getCursorDisplayName(CXCursor cursor);

        /** For a cursor that is a reference, retrieve a cursor representing the
         * entity that it references.
         *
         * Reference cursors refer to other entities in the AST. For example, an
         * Objective-C superclass reference cursor refers to an Objective-C class.
         * This function produces the cursor for the Objective-C class from the
         * cursor for the superclass reference. If the input cursor is a declaration or
         * definition, it returns that declaration or definition unchanged.
         * Otherwise, returns the NULL cursor.
         */
        [DllImport("libclang.dll")] internal static extern CXCursor clang_getCursorReferenced(CXCursor cursor);

        /**
         *  For a cursor that is either a reference to or a declaration
         *  of some entity, retrieve a cursor that describes the definition of
         *  that entity.
         *
         *  Some entities can be declared multiple times within a translation
         *  unit, but only one of those declarations can also be a
         *  definition. For example, given:
         *
         *  \code
         *  int f(int, int);
         *  int g(int x, int y) { return f(x, y); }
         *  int f(int a, int b) { return a + b; }
         *  int f(int, int);
         *  \endcode
         *
         *  there are three declarations of the function "f", but only the
         *  second one is a definition. The clang_getCursorDefinition()
         *  function will take any cursor pointing to a declaration of "f"
         *  (the first or fourth lines of the example) or a cursor referenced
         *  that uses "f" (the call to "f' inside "g") and will return a
         *  declaration cursor pointing to the definition (the second "f"
         *  declaration).
         *
         *  If given a cursor for which there is no corresponding definition,
         *  e.g., because there is no definition of that entity within this
         *  translation unit, returns a NULL cursor.
         */
        [DllImport("libclang.dll")] internal static extern CXCursor clang_getCursorDefinition(CXCursor cursor);

        /**
         * Determine whether the declaration pointed to by this cursor
         * is also a definition of that entity.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_isCursorDefinition(CXCursor cursor);

        /**
         * Retrieve the canonical cursor corresponding to the given cursor.
         *
         * In the C family of languages, many kinds of entities can be declared several
         * times within a single translation unit. For example, a structure type can
         * be forward-declared (possibly multiple times) and later defined:
         *
         * \code
         * struct X;
         * struct X;
         * struct X {
         *   int member;
         * };
         * \endcode
         *
         * The declarations and the definition of \c X are represented by three
         * different cursors, all of which are declarations of the same underlying
         * entity. One of these cursor is considered the "canonical" cursor, which
         * is effectively the representative for the underlying entity. One can
         * determine if two cursors are declarations of the same underlying entity by
         * comparing their canonical cursors.
         *
         * \returns The canonical cursor for the entity referred to by the given cursor.
         */
        [DllImport("libclang.dll")] internal static extern CXCursor clang_getCanonicalCursor(CXCursor cursor);

        /**
         * If the cursor points to a selector identifier in an Objective-C
         * method or message expression, this returns the selector index.
         *
         * After getting a cursor with #clang_getCursor, this can be called to
         * determine if the location points to a selector identifier.
         *
         * \returns The selector index if the cursor is an Objective-C method or message
         * expression and the cursor is pointing to a selector identifier, or -1
         * otherwise.
         */
        [DllImport("libclang.dll")] internal static extern int clang_Cursor_getObjCSelectorIndex(CXCursor cursor);

        /**
         * Given a cursor pointing to a C++ method call or an Objective-C
         * message, returns non-zero if the method/message is "dynamic", meaning:
         *
         * For a C++ method: the call is virtual.
         * For an Objective-C message: the receiver is an object instance, not 'super'
         * or a specific class.
         *
         * If the method/message is "static" or the cursor does not point to a
         * method/message, it will return zero.
         */
        [DllImport("libclang.dll")] internal static extern int clang_Cursor_isDynamicCall(CXCursor C);

        /**
         * Given a cursor pointing to an Objective-C message or property
         * reference, or C++ method call, returns the CXType of the receiver.
         */
        [DllImport("libclang.dll")] internal static extern CXType clang_Cursor_getReceiverType(CXCursor C);

     

        /**
         * Given a cursor that represents a property declaration, return the
         * associated property attributes. The bits are formed from
         * \c CXObjCPropertyAttrKind.
         *
         * \param reserved Reserved for future use, pass 0.
         */
        [DllImport("libclang.dll")]
        internal static extern uint clang_Cursor_getObjCPropertyAttributes(CXCursor C,
                                                                    uint reserved);



        /**
         * Given a cursor that represents an Objective-C method or parameter
         * declaration, return the associated Objective-C qualifiers for the return
         * type or the parameter respectively. The bits are formed from
         * CXObjCDeclQualifierKind.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_Cursor_getObjCDeclQualifiers(CXCursor C);

        /**
         * Given a cursor that represents an Objective-C method or property
         * declaration, return non-zero if the declaration was affected by "\@optional".
         * Returns zero if the cursor is not such a declaration or it is "\@required".
         */
        [DllImport("libclang.dll")] internal static extern uint clang_Cursor_isObjCOptional(CXCursor C);

        /**
         * Returns non-zero if the given cursor is a variadic function or method.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_Cursor_isVariadic(CXCursor C);

        /**
         * Returns non-zero if the given cursor points to a symbol marked with
         * external_source_symbol attribute.
         *
         * \param language If non-NULL, and the attribute is present, will be set to
         * the 'language' string from the attribute.
         *
         * \param definedIn If non-NULL, and the attribute is present, will be set to
         * the 'definedIn' string from the attribute.
         *
         * \param isGenerated If non-NULL, and the attribute is present, will be set to
         * non-zero if the 'generated_declaration' is set in the attribute.
         */
        [DllImport("libclang.dll")]
        internal static extern uint clang_Cursor_isExternalSymbol(CXCursor C,
                                              out CXString language, out CXString definedIn,
                                              out uint isGenerated);

        /**
         * Given a cursor that represents a declaration, return the associated
         * comment's source range.  The range may include multiple consecutive comments
         * with whitespace in between.
         */
        [DllImport("libclang.dll")] internal static extern CXSourceRange clang_Cursor_getCommentRange(CXCursor C);

        /**
         * Given a cursor that represents a declaration, return the associated
         * comment text, including comment markers.
         */
        [DllImport("libclang.dll")] internal static extern CXString clang_Cursor_getRawCommentText(CXCursor C);

        /**
         * Given a cursor that represents a documentable entity (e.g.,
         * declaration), return the associated \paragraph; otherwise return the
         * first paragraph.
         */
        [DllImport("libclang.dll")] internal static extern CXString clang_Cursor_getBriefCommentText(CXCursor C);

        /**
         * @}
         */

        /** \defgroup CINDEX_MANGLE Name Mangling API Functions
         *
         * @{
         */

        /**
         * Retrieve the CXString representing the mangled name of the cursor.
         */
        [DllImport("libclang.dll")] internal static extern CXString clang_Cursor_getMangling(CXCursor cursor);

        /**
         * Retrieve the CXStrings representing the mangled symbols of the C++
         * constructor or destructor at the cursor.
         */
        [DllImport("libclang.dll")] internal static extern CXStringSet* clang_Cursor_getCXXManglings(CXCursor cursor);

        /**
         * Retrieve the CXStrings representing the mangled symbols of the ObjC
         * class interface or implementation at the cursor.
         */
        [DllImport("libclang.dll")] internal static extern CXStringSet* clang_Cursor_getObjCManglings(CXCursor cursor);



        /**
         * Given a CXCursor_ModuleImportDecl cursor, return the associated module.
         */
        [DllImport("libclang.dll")] internal static extern CXModule clang_Cursor_getModule(CXCursor C);

        /**
         * Given a CXFile header file, return the module that contains it, if one
         * exists.
         */
        [DllImport("libclang.dll")] internal static extern CXModule clang_getModuleForFile(CXTranslationUnit unit, CXFile file);

        /**
         * \param Module a module object.
         *
         * \returns the module file where the provided module object came from.
         */
        [DllImport("libclang.dll")] internal static extern CXFile clang_Module_getASTFile(CXModule Module);

        /**
         * \param Module a module object.
         *
         * \returns the parent of a sub-module or NULL if the given module is top-level,
         * e.g. for 'std.vector' it will return the 'std' module.
         */
        [DllImport("libclang.dll")] internal static extern CXModule clang_Module_getParent(CXModule Module);

        /**
         * \param Module a module object.
         *
         * \returns the name of the module, e.g. for the 'std.vector' sub-module it
         * will return "vector".
         */
        [DllImport("libclang.dll")] internal static extern CXString clang_Module_getName(CXModule Module);

        /**
         * \param Module a module object.
         *
         * \returns the full name of the module, e.g. "std.vector".
         */
        [DllImport("libclang.dll")] internal static extern CXString clang_Module_getFullName(CXModule Module);

        /**
         * \param Module a module object.
         *
         * \returns non-zero if the module is a system one.
         */
        [DllImport("libclang.dll")] internal static extern int clang_Module_isSystem(CXModule Module);

        /**
         * \param Module a module object.
         *
         * \returns the number of top level headers associated with this module.
         */
        [DllImport("libclang.dll")]
        internal static extern uint clang_Module_getNumTopLevelHeaders(CXTranslationUnit unit,
                                                                  CXModule Module);

        /**
         * \param Module a module object.
         *
         * \param Index top level header index (zero-based).
         *
         * \returns the specified top level header associated with the module.
         */
        [DllImport("libclang.dll")]
        internal static extern
       CXFile clang_Module_getTopLevelHeader(CXTranslationUnit unit,
                                             CXModule Module, uint Index);

        /**
         * @}
         */

        /**
         * \defgroup CINDEX_CPP C++ AST introspection
         *
         * The routines in this group provide access information in the ASTs specific
         * to C++ language features.
         *
         * @{
         */

        /**
         * Determine if a C++ constructor is a converting constructor.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_CXXConstructor_isConvertingConstructor(CXCursor C);

        /**
         * Determine if a C++ constructor is a copy constructor.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_CXXConstructor_isCopyConstructor(CXCursor C);

        /**
         * Determine if a C++ constructor is the default constructor.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_CXXConstructor_isDefaultConstructor(CXCursor C);

        /**
         * Determine if a C++ constructor is a move constructor.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_CXXConstructor_isMoveConstructor(CXCursor C);

        /**
         * Determine if a C++ field is declared 'mutable'.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_CXXField_isMutable(CXCursor C);

        /**
         * Determine if a C++ method is declared '= default'.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_CXXMethod_isDefaulted(CXCursor C);

        /**
         * Determine if a C++ member function or member function template is
         * pure virtual.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_CXXMethod_isPureVirtual(CXCursor C);

        /**
         * Determine if a C++ member function or member function template is
         * declared 'static'.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_CXXMethod_isStatic(CXCursor C);

        /**
         * Determine if a C++ member function or member function template is
         * explicitly declared 'virtual' or if it overrides a virtual method from
         * one of the base classes.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_CXXMethod_isVirtual(CXCursor C);

        /**
         * Determine if a C++ record is abstract, i.e. whether a class or struct
         * has a pure virtual member function.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_CXXRecord_isAbstract(CXCursor C);

        /**
         * Determine if an enum declaration refers to a scoped enum.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_EnumDecl_isScoped(CXCursor C);

        /**
         * Determine if a C++ member function or member function template is
         * declared 'const'.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_CXXMethod_isConst(CXCursor C);

        /**
         * Given a cursor that represents a template, determine
         * the cursor kind of the specializations would be generated by instantiating
         * the template.
         *
         * This routine can be used to determine what flavor of function template,
         * class template, or class template partial specialization is stored in the
         * cursor. For example, it can describe whether a class template cursor is
         * declared with "struct", "class" or "union".
         *
         * \param C The cursor to query. This cursor should represent a template
         * declaration.
         *
         * \returns The cursor kind of the specializations that would be generated
         * by instantiating the template \p C. If \p C is not a template, returns
         * \c CXCursor_NoDeclFound.
         */
        [DllImport("libclang.dll")] internal static extern CXCursorKind clang_getTemplateCursorKind(CXCursor C);

        /**
         * Given a cursor that may represent a specialization or instantiation
         * of a template, retrieve the cursor that represents the template that it
         * specializes or from which it was instantiated.
         *
         * This routine determines the template involved both for explicit
         * specializations of templates and for implicit instantiations of the template,
         * both of which are referred to as "specializations". For a class template
         * specialization (e.g., \c std::vector<bool>), this routine will return
         * either the primary template (\c std::vector) or, if the specialization was
         * instantiated from a class template partial specialization, the class template
         * partial specialization. For a class template partial specialization and a
         * function template specialization (including instantiations), this
         * this routine will return the specialized template.
         *
         * For members of a class template (e.g., member functions, member classes, or
         * internal static data members), returns the specialized or instantiated member.
         * Although not strictly "templates" in the C++ language, members of class
         * templates have the same notions of specializations and instantiations that
         * templates do, so this routine treats them similarly.
         *
         * \param C A cursor that may be a specialization of a template or a member
         * of a template.
         *
         * \returns If the given cursor is a specialization or instantiation of a
         * template or a member thereof, the template or member that it specializes or
         * from which it was instantiated. Otherwise, returns a NULL cursor.
         */
        [DllImport("libclang.dll")] internal static extern CXCursor clang_getSpecializedCursorTemplate(CXCursor C);

        /**
         * Given a cursor that references something else, return the source range
         * covering that reference.
         *
         * \param C A cursor pointing to a member reference, a declaration reference, or
         * an operator call.
         * \param NameFlags A bitset with three independent flags:
         * CXNameRange_WantQualifier, CXNameRange_WantTemplateArgs, and
         * CXNameRange_WantSinglePiece.
         * \param PieceIndex For contiguous names or when passing the flag
         * CXNameRange_WantSinglePiece, only one piece with index 0 is
         * available. When the CXNameRange_WantSinglePiece flag is not passed for a
         * non-contiguous names, this index can be used to retrieve the individual
         * pieces of the name. See also CXNameRange_WantSinglePiece.
         *
         * \returns The piece of the name pointed to by the given cursor. If there is no
         * name, or if the PieceIndex is out-of-range, a null-cursor will be returned.
         */
        [DllImport("libclang.dll")]
        internal static extern CXSourceRange clang_getCursorReferenceNameRange(CXCursor C,
                                                       uint NameFlags,
                                                       uint PieceIndex);




        /**
         * Get the raw lexical token starting with the given location.
         *
         * \param TU the translation unit whose text is being tokenized.
         *
         * \param Location the source location with which the token starts.
         *
         * \returns The token starting with the given location or NULL if no such token
         * exist. The returned pointer must be freed with clang_disposeTokens before the
         * translation unit is destroyed.
         */
        [DllImport("libclang.dll")]
        internal static extern CXToken clang_getToken(CXTranslationUnit TU,
                                              CXSourceLocation Location);

        /**
         * Determine the kind of the given token.
         */
        [DllImport("libclang.dll")] internal static extern CXTokenKind clang_getTokenKind(CXToken token);

        /**
         * Determine the spelling of the given token.
         *
         * The spelling of a token is the textual representation of that token, e.g.,
         * the text of an identifier or keyword.
         */
        [DllImport("libclang.dll")] internal static extern CXString clang_getTokenSpelling(CXTranslationUnit unit, CXToken token);

        /**
         * Retrieve the source location of the given token.
         */
        [DllImport("libclang.dll")]
        internal static extern CXSourceLocation clang_getTokenLocation(CXTranslationUnit unit,
                                                              CXToken token);

        /**
         * Retrieve a source range that covers the given token.
         */
        [DllImport("libclang.dll")] internal static extern CXSourceRange clang_getTokenExtent(CXTranslationUnit unit, CXToken token);

        /**
         * Tokenize the source code described by the given range into raw
         * lexical tokens.
         *
         * \param TU the translation unit whose text is being tokenized.
         *
         * \param Range the source range in which text should be tokenized. All of the
         * tokens produced by tokenization will fall within this source range,
         *
         * \param Tokens this pointer will be set to point to the array of tokens
         * that occur within the given source range. The returned pointer must be
         * freed with clang_disposeTokens() before the translation unit is destroyed.
         *
         * \param NumTokens will be set to the number of tokens in the \c *Tokens
         * array.
         *
         */
        [DllImport("libclang.dll")]
        internal static extern void clang_tokenize(CXTranslationUnit TU, CXSourceRange Range,
                                          out CXToken* Tokens, out uint NumTokens);

        /**
         * Annotate the given set of tokens by providing cursors for each token
         * that can be mapped to a specific entity within the abstract syntax tree.
         *
         * This token-annotation routine is equivalent to invoking
         * clang_getCursor() for the source locations of each of the
         * tokens. The cursors provided are filtered, so that only those
         * cursors that have a direct correspondence to the token are
         * accepted. For example, given a function call \c f(x),
         * clang_getCursor() would provide the following cursors:
         *
         *   * when the cursor is over the 'f', a DeclRefExpr cursor referring to 'f'.
         *   * when the cursor is over the '(' or the ')', a CallExpr referring to 'f'.
         *   * when the cursor is over the 'x', a DeclRefExpr cursor referring to 'x'.
         *
         * Only the first and last of these cursors will occur within the
         * annotate, since the tokens "f" and "x' directly refer to a function
         * and a variable, respectively, but the parentheses are just a small
         * part of the full syntax of the function call expression, which is
         * not provided as an annotation.
         *
         * \param TU the translation unit that owns the given tokens.
         *
         * \param Tokens the set of tokens to annotate.
         *
         * \param NumTokens the number of tokens in \p Tokens.
         *
         * \param Cursors an array of \p NumTokens cursors, whose contents will be
         * replaced with the cursors corresponding to each token.
         */
        [DllImport("libclang.dll")]
        internal static extern void clang_annotateTokens(CXTranslationUnit TU,
                                                CXToken[] Tokens, uint NumTokens,
                                                CXCursor[] Cursors);

        /**
         * Free the given set of tokens.
         */
        [DllImport("libclang.dll")]
        internal static extern void clang_disposeTokens(CXTranslationUnit TU,
                                               CXToken* Tokens, uint NumTokens);

        /**
         * @}
         */

        /**
         * \defgroup CINDEX_DEBUG Debugging facilities
         *
         * These routines are used for testing and debugging, only, and should not
         * be relied upon.
         *
         * @{
         */

        /* for debug/testing */
        [DllImport("libclang.dll")] internal static extern CXString clang_getCursorKindSpelling(CXCursorKind Kind);
        [DllImport("libclang.dll")]
        internal static extern void clang_getDefinitionSpellingAndExtent(CXCursor cursor,
                                                 out string startBuf,
                                                 out string endBuf,
                                                 out uint startLine,
                                                 out uint startColumn,
                                                 out uint endLine,
                                                 out uint endColumn);
        [DllImport("libclang.dll")] internal static extern void clang_enableStackTraces();



        public delegate void fn(IntPtr ptr);

        [DllImport("libclang.dll")] internal static extern void clang_executeOnThread(fn fn, IntPtr user_data, uint stack_size);





        /**
         * Determine the kind of a particular chunk within a completion string.
         *
         * \param completion_string the completion string to query.
         *
         * \param chunk_number the 0-based index of the chunk in the completion string.
         *
         * \returns the kind of the chunk at the index \c chunk_number.
         */
        [DllImport("libclang.dll")]
        internal static extern CXCompletionChunkKind
       clang_getCompletionChunkKind(CXCompletionString completion_string,
                                    uint chunk_number);

        /**
         * Retrieve the text associated with a particular chunk within a
         * completion string.
         *
         * \param completion_string the completion string to query.
         *
         * \param chunk_number the 0-based index of the chunk in the completion string.
         *
         * \returns the text associated with the chunk at index \c chunk_number.
         */
        [DllImport("libclang.dll")]
        internal static extern CXString
       clang_getCompletionChunkText(CXCompletionString completion_string,
                                    uint chunk_number);

        /**
         * Retrieve the completion string associated with a particular chunk
         * within a completion string.
         *
         * \param completion_string the completion string to query.
         *
         * \param chunk_number the 0-based index of the chunk in the completion string.
         *
         * \returns the completion string associated with the chunk at index
         * \c chunk_number.
         */
        [DllImport("libclang.dll")]
        internal static extern CXCompletionString
       clang_getCompletionChunkCompletionString(CXCompletionString completion_string,
                                                uint chunk_number);

        /**
         * Retrieve the number of chunks in the given code-completion string.
         */
        [DllImport("libclang.dll")]
        internal static extern uint
       clang_getNumCompletionChunks(CXCompletionString completion_string);

        /**
         * Determine the priority of this code completion.
         *
         * The priority of a code completion indicates how likely it is that this
         * particular completion is the completion that the user will select. The
         * priority is selected by various internal heuristics.
         *
         * \param completion_string The completion string to query.
         *
         * \returns The priority of this completion string. Smaller values indicate
         * higher-priority (more likely) completions.
         */
        [DllImport("libclang.dll")]
        internal static extern uint
       clang_getCompletionPriority(CXCompletionString completion_string);

        /**
         * Determine the availability of the entity that this code-completion
         * string refers to.
         *
         * \param completion_string The completion string to query.
         *
         * \returns The availability of the completion string.
         */
        [DllImport("libclang.dll")]
        internal static extern CXAvailabilityKind
       clang_getCompletionAvailability(CXCompletionString completion_string);

        /**
         * Retrieve the number of annotations associated with the given
         * completion string.
         *
         * \param completion_string the completion string to query.
         *
         * \returns the number of annotations associated with the given completion
         * string.
         */
        [DllImport("libclang.dll")]
        internal static extern uint
       clang_getCompletionNumAnnotations(CXCompletionString completion_string);

        /**
         * Retrieve the annotation associated with the given completion string.
         *
         * \param completion_string the completion string to query.
         *
         * \param annotation_number the 0-based index of the annotation of the
         * completion string.
         *
         * \returns annotation string associated with the completion at index
         * \c annotation_number, or a NULL string if that annotation is not available.
         */
        [DllImport("libclang.dll")]
        internal static extern CXString
       clang_getCompletionAnnotation(CXCompletionString completion_string,
                                     uint annotation_number);

        /**
         * Retrieve the parent context of the given completion string.
         *
         * The parent context of a completion string is the semantic parent of
         * the declaration (if any) that the code completion represents. For example,
         * a code completion for an Objective-C method would have the method's class
         * or protocol as its context.
         *
         * \param completion_string The code completion string whose parent is
         * being queried.
         *
         * \param kind DEPRECATED: always set to CXCursor_NotImplemented if non-NULL.
         *
         * \returns The name of the completion parent, e.g., "NSObject" if
         * the completion string represents a method in the NSObject class.
         */
        [DllImport("libclang.dll")]
        internal static extern CXString
       clang_getCompletionParent(CXCompletionString completion_string,
                                 out CXCursorKind kind);

        /**
         * Retrieve the brief documentation comment attached to the declaration
         * that corresponds to the given completion string.
         */
        [DllImport("libclang.dll")]
        internal static extern CXString
       clang_getCompletionBriefComment(CXCompletionString completion_string);

        /**
         * Retrieve a completion string for an arbitrary declaration or macro
         * definition cursor.
         *
         * \param cursor The cursor to query.
         *
         * \returns A non-context-sensitive completion string for declaration and macro
         * definition cursors, or NULL for other kinds of cursors.
         */
        [DllImport("libclang.dll")]
        internal static extern CXCompletionString
       clang_getCursorCompletionString(CXCursor cursor);



        /**
         * Retrieve the number of fix-its for the given completion index.
         *
         * Calling this makes sense only if CXCodeComplete_IncludeCompletionsWithFixIts
         * option was set.
         *
         * \param results The structure keeping all completion results
         *
         * \param completion_index The index of the completion
         *
         * \return The number of fix-its which must be applied before the completion at
         * completion_index can be applied
         */
        [DllImport("libclang.dll")]
        internal static extern uint clang_getCompletionNumFixIts(CXCodeCompleteResults* results, uint completion_index);

        /**
         * Fix-its that *must* be applied before inserting the text for the
         * corresponding completion.
         *
         * By default, clang_codeCompleteAt() only returns completions with empty
         * fix-its. Extra completions with non-empty fix-its should be explicitly
         * requested by setting CXCodeComplete_IncludeCompletionsWithFixIts.
         *
         * For the clients to be able to compute position of the cursor after applying
         * fix-its, the following conditions are guaranteed to hold for
         * replacement_range of the stored fix-its:
         *  - Ranges in the fix-its are guaranteed to never contain the completion
         *  point (or identifier under completion point, if any) inside them, except
         *  at the start or at the end of the range.
         *  - If a fix-it range starts or ends with completion point (or starts or
         *  ends after the identifier under completion point), it will contain at
         *  least one character. It allows to unambiguously recompute completion
         *  point after applying the fix-it.
         *
         * The intuition is that provided fix-its change code around the identifier we
         * complete, but are not allowed to touch the identifier itself or the
         * completion point. One example of completions with corrections are the ones
         * replacing '.' with '->' and vice versa:
         *
         * std::unique_ptr<std::vector<int>> vec_ptr;
         * In 'vec_ptr.^', one of the completions is 'push_back', it requires
         * replacing '.' with '->'.
         * In 'vec_ptr->^', one of the completions is 'release', it requires
         * replacing '->' with '.'.
         *
         * \param results The structure keeping all completion results
         *
         * \param completion_index The index of the completion
         *
         * \param fixit_index The index of the fix-it for the completion at
         * completion_index
         *
         * \param replacement_range The fix-it range that must be replaced before the
         * completion at completion_index can be applied
         *
         * \returns The fix-it string that must replace the code at replacement_range
         * before the completion at completion_index can be applied
         */
        [DllImport("libclang.dll")]
        internal static extern CXString clang_getCompletionFixIt(
           CXCodeCompleteResults[] results, uint completion_index,
           uint fixit_index, out CXSourceRange replacement_range);

       

      
        /**
         * Returns a default set of code-completion options that can be
         * passed to\c clang_codeCompleteAt().
         */
        [DllImport("libclang.dll")] internal static extern uint clang_defaultCodeCompleteOptions();

        /**
         * Perform code completion at a given location in a translation unit.
         *
         * This function performs code completion at a particular file, line, and
         * column within source code, providing results that suggest potential
         * code snippets based on the context of the completion. The basic model
         * for code completion is that Clang will parse a complete source file,
         * performing syntax checking up to the location where code-completion has
         * been requested. At that point, a special code-completion token is passed
         * to the parser, which recognizes this token and determines, based on the
         * current location in the C/Objective-C/C++ grammar and the state of
         * semantic analysis, what completions to provide. These completions are
         * returned via a new \c CXCodeCompleteResults structure.
         *
         * Code completion itself is meant to be triggered by the client when the
         * user types punctuation characters or whitespace, at which point the
         * code-completion location will coincide with the cursor. For example, if \c p
         * is a pointer, code-completion might be triggered after the "-" and then
         * after the ">" in \c p->. When the code-completion location is after the ">",
         * the completion results will provide, e.g., the members of the struct that
         * "p" points to. The client is responsible for placing the cursor at the
         * beginning of the token currently being typed, then filtering the results
         * based on the contents of the token. For example, when code-completing for
         * the expression \c p->get, the client should provide the location just after
         * the ">" (e.g., pointing at the "g") to this code-completion hook. Then, the
         * client can filter the results based on the current token text ("get"), only
         * showing those results that start with "get". The intent of this interface
         * is to separate the relatively high-latency acquisition of code-completion
         * results from the filtering of results on a per-character basis, which must
         * have a lower latency.
         *
         * \param TU The translation unit in which code-completion should
         * occur. The source files for this translation unit need not be
         * completely up-to-date (and the contents of those source files may
         * be overridden via \p unsaved_files). Cursors referring into the
         * translation unit may be invalidated by this invocation.
         *
         * \param complete_filename The name of the source file where code
         * completion should be performed. This filename may be any file
         * included in the translation unit.
         *
         * \param complete_line The line at which code-completion should occur.
         *
         * \param complete_column The column at which code-completion should occur.
         * Note that the column should point just after the syntactic construct that
         * initiated code completion, and not in the middle of a lexical token.
         *
         * \param unsaved_files the Files that have not yet been saved to disk
         * but may be required for parsing or code completion, including the
         * contents of those files.  The contents and name of these files (as
         * specified by CXUnsavedFile) are copied when necessary, so the
         * client only needs to guarantee their validity until the call to
         * this function returns.
         *
         * \param num_unsaved_files The number of unsaved file entries in \p
         * unsaved_files.
         *
         * \param options Extra options that control the behavior of code
         * completion, expressed as a bitwise OR of the enumerators of the
         * CXCodeComplete_Flags enumeration. The
         * \c clang_defaultCodeCompleteOptions() function returns a default set
         * of code-completion options.
         *
         * \returns If successful, a new \c CXCodeCompleteResults structure
         * containing code-completion results, which should eventually be
         * freed with \c clang_disposeCodeCompleteResults(). If code
         * completion fails, returns NULL.
         */
        [DllImport("libclang.dll")]
        internal static extern
       CXCodeCompleteResults* clang_codeCompleteAt(CXTranslationUnit TU,
                                                   string complete_filename,
                                                   uint complete_line,
                                                   uint complete_column,
                                                   /*CXUnsavedFile*/IntPtr unsaved_files,
                                                   uint num_unsaved_files,
                                                   uint options);

        /**
         * Sort the code-completion results in case-insensitive alphabetical
         * order.
         *
         * \param Results The set of results to sort.
         * \param NumResults The number of results in \p Results.
         */
        [DllImport("libclang.dll")]
        internal static extern
       void clang_sortCodeCompletionResults(CXCompletionResult* Results,
                                            uint NumResults);

        /**
         * Free the given set of code-completion results.
         */
        [DllImport("libclang.dll")]
        internal static extern
       void clang_disposeCodeCompleteResults(CXCodeCompleteResults* Results);

        /**
         * Determine the number of diagnostics produced prior to the
         * location where code completion was performed.
         */
        [DllImport("libclang.dll")]
        internal static extern
       uint clang_codeCompleteGetNumDiagnostics(CXCodeCompleteResults* Results);

        /**
         * Retrieve a diagnostic associated with the given code completion.
         *
         * \param Results the code completion results to query.
         * \param Index the zero-based diagnostic number to retrieve.
         *
         * \returns the requested diagnostic. This diagnostic must be freed
         * via a call to \c clang_disposeDiagnostic().
         */
        [DllImport("libclang.dll")]
        internal static extern
       CXDiagnostic clang_codeCompleteGetDiagnostic(CXCodeCompleteResults* Results,
                                                    uint Index);

        /**
         * Determines what completions are appropriate for the context
         * the given code completion.
         *
         * \param Results the code completion results to query
         *
         * \returns the kinds of completions that are appropriate for use
         * along with the given code completion results.
         */
        [DllImport("libclang.dll")]
        internal static extern
       ulong clang_codeCompleteGetContexts(CXCodeCompleteResults* Results);

        /**
         * Returns the cursor kind for the container for the current code
         * completion context. The container is only guaranteed to be set for
         * contexts where a container exists (i.e. member accesses or Objective-C
         * message sends); if there is not a container, this function will return
         * CXCursor_InvalidCode.
         *
         * \param Results the code completion results to query
         *
         * \param IsIncomplete on return, this value will be false if Clang has complete
         * information about the container. If Clang does not have complete
         * information, this value will be true.
         *
         * \returns the container kind, or CXCursor_InvalidCode if there is not a
         * container
         */
        [DllImport("libclang.dll")]
        internal static extern
        CXCursorKind clang_codeCompleteGetContainerKind(
                                                        CXCodeCompleteResults* Results,
                                                            out uint IsIncomplete);

        /**
         * Returns the USR for the container for the current code completion
         * context. If there is not a container for the current context, this
         * function will return the empty string.
         *
         * \param Results the code completion results to query
         *
         * \returns the USR for the container
         */
        [DllImport("libclang.dll")]
        internal static extern
       CXString clang_codeCompleteGetContainerUSR(CXCodeCompleteResults* Results);

        /**
         * Returns the currently-entered selector for an Objective-C message
         * send, formatted like "initWithFoo:bar:". Only guaranteed to return a
         * non-empty string for CXCompletionContext_ObjCInstanceMessage and
         * CXCompletionContext_ObjCClassMessage.
         *
         * \param Results the code completion results to query
         *
         * \returns the selector (or partial selector) that has been entered thus far
         * for an Objective-C message send.
         */
        [DllImport("libclang.dll")]
        internal static extern
       CXString clang_codeCompleteGetObjCSelector(CXCodeCompleteResults* Results);

        /**
         * @}
         */

        /**
         * \defgroup CINDEX_MISC Miscellaneous utility functions
         *
         * @{
         */

        /**
         * Return a version string, suitable for showing to a user, but not
         *        intended to be parsed (the format is not guaranteed to be stable).
         */
        [DllImport("libclang.dll")] internal static extern CXString clang_getClangVersion();

        /**
         * Enable/disable crash recovery.
         *
         * \param isEnabled Flag to indicate if crash recovery is enabled.  A non-zero
         *        value enables crash recovery, while 0 disables it.
         */
        [DllImport("libclang.dll")] internal static extern void clang_toggleCrashRecovery(uint isEnabled);

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

        /**
         * Visit the set of preprocessor inclusions in a translation unit.
         *   The visitor function is called with the provided data for every included
         *   file.  This does not include headers included by the PCH file (unless one
         *   is inspecting the inclusions in the PCH file itself).
         */
        [DllImport("libclang.dll")]
        internal static extern void clang_getInclusions(CXTranslationUnit tu,
                                               CXInclusionVisitor visitor,
                                               CXClientData client_data);



        /**
         * If cursor is a statement declaration tries to evaluate the
         * statement and if its variable, tries to evaluate its initializer,
         * into its corresponding type.
         */
        [DllImport("libclang.dll")] internal static extern CXEvalResult clang_Cursor_Evaluate(CXCursor C);

        /**
         * Returns the kind of the evaluated result.
         */
        [DllImport("libclang.dll")] internal static extern CXEvalResultKind clang_EvalResult_getKind(CXEvalResult E);

        /**
         * Returns the evaluation result as integer if the
         * kind is Int.
         */
        [DllImport("libclang.dll")] internal static extern int clang_EvalResult_getAsInt(CXEvalResult E);

        /**
         * Returns the evaluation result as a long integer if the
         * kind is Int. This prevents overflows that may happen if the result is
         * returned with clang_EvalResult_getAsInt.
         */
        [DllImport("libclang.dll")] internal static extern long clang_EvalResult_getAsLongLong(CXEvalResult E);

        /**
         * Returns a non-zero value if the kind is Int and the evaluation
         * result resulted in an uint integer.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_EvalResult_isuintInt(CXEvalResult E);

        /**
         * Returns the evaluation result as an uint integer if
         * the kind is Int and clang_EvalResult_isuintInt is non-zero.
         */
        [DllImport("libclang.dll")] internal static extern ulong clang_EvalResult_getAsuint(CXEvalResult E);

        /**
         * Returns the evaluation result as double if the
         * kind is double.
         */
        [DllImport("libclang.dll")] internal static extern double clang_EvalResult_getAsDouble(CXEvalResult E);

        /**
         * Returns the evaluation result as a constant string if the
         * kind is other than Int or float. User must not free this pointer,
         * instead call clang_EvalResult_dispose on the CXEvalResult returned
         * by clang_Cursor_Evaluate.
         */
        [DllImport("libclang.dll")] internal static extern sbyte* clang_EvalResult_getAsStr(CXEvalResult E);

        /**
         * Disposes the created Eval memory.
         */
        [DllImport("libclang.dll")] internal static extern void clang_EvalResult_dispose(CXEvalResult E);


        /**
         * Retrieve a remapping.
         *
         * \param path the path that contains metadata about remappings.
         *
         * \returns the requested remapping. This remapping must be freed
         * via a call to \c clang_remap_dispose(). Can return NULL if an error occurred.
         */
        [DllImport("libclang.dll")] internal static extern CXRemapping clang_getRemappings(string path);

        /**
         * Retrieve a remapping.
         *
         * \param filePaths pointer to an array of file paths containing remapping info.
         *
         * \param numFiles number of file paths.
         *
         * \returns the requested remapping. This remapping must be freed
         * via a call to \c clang_remap_dispose(). Can return NULL if an error occurred.
         */
        [DllImport("libclang.dll")]
        internal static extern
       CXRemapping clang_getRemappingsFromFileList(string[] filePaths,
                                                   uint numFiles);

        /**
         * Determine the number of remappings.
         */
        [DllImport("libclang.dll")] internal static extern uint clang_remap_getNumFiles(CXRemapping cXRemapping);

        /**
         * Get the original and the associated filename from the remapping.
         *
         * \param original If non-NULL, will be set to the original filename.
         *
         * \param transformed If non-NULL, will be set to the filename that the original
         * is associated with.
         */
        [DllImport("libclang.dll")]
        internal static extern void clang_remap_getFilenames(CXRemapping cXRemapping, uint index,
                                            out CXString original, out CXString transformed);

        /**
         * Dispose the remapping.
         */
        [DllImport("libclang.dll")] internal static extern void clang_remap_dispose(CXRemapping cXRemapping);

  





        /**
         * Find references of a declaration in a specific file.
         *
         * \param cursor pointing to a declaration or a reference of one.
         *
         * \param file to search for references.
         *
         * \param visitor callback that will receive pairs of CXCursor/CXSourceRange for
         * each reference found.
         * The CXSourceRange will point inside the file; if the reference is inside
         * a macro (and not a macro argument) the CXSourceRange will be invalid.
         *
         * \returns one of the CXResult enumerators.
         */
        [DllImport("libclang.dll")]
        internal static extern CXResult clang_findReferencesInFile(CXCursor cursor, CXFile file,
                                                      CXCursorAndRangeVisitor visitor);

        /**
         * Find #import/#include directives in a specific file.
         *
         * \param TU translation unit containing the file to query.
         *
         * \param file to search for #import/#include directives.
         *
         * \param visitor callback that will receive pairs of CXCursor/CXSourceRange for
         * each directive found.
         *
         * \returns one of the CXResult enumerators.
         */
        [DllImport("libclang.dll")]
        internal static extern CXResult clang_findIncludesInFile(CXTranslationUnit TU,
                                                        CXFile file,
                                                     CXCursorAndRangeVisitor visitor);

        public delegate CXVisitorResult
    CXCursorAndRangeVisitorBlock(CXCursor cursor, CXSourceRange range);

        [DllImport("libclang.dll")]
        internal static extern
       CXResult clang_findReferencesInFileWithBlock(CXCursor cursor, CXFile file,
                                                    CXCursorAndRangeVisitorBlock cXCursorAndRangeVisitorBlock);

        [DllImport("libclang.dll")]
        internal static extern
       CXResult clang_findIncludesInFileWithBlock(CXTranslationUnit cXTranslationUnit, CXFile file,
                                                  CXCursorAndRangeVisitorBlock cXCursor);


       
       

        [DllImport("libclang.dll")] internal static extern int clang_index_isEntityObjCContainerKind(CXIdxEntityKind entityKind);
        [DllImport("libclang.dll")] internal static extern /*CXIdxObjCContainerDeclInfo*/ IntPtr clang_index_getObjCContainerDeclInfo(/*CXIdxDeclInfo*/ IntPtr info);

        [DllImport("libclang.dll")] internal static extern  /*CXIdxObjCInterfaceDeclInfo*/IntPtr clang_index_getObjCInterfaceDeclInfo(/*CXIdxDeclInfo*/ IntPtr declInfo);

        [DllImport("libclang.dll")]
        internal static extern
/* CXIdxObjCCategoryDeclInfo*/
IntPtr clang_index_getObjCCategoryDeclInfo(/* CXIdxDeclInfo*/ IntPtr declInfo);

        [DllImport("libclang.dll")]
        internal static extern /* CXIdxObjCProtocolRefListInfo*/
IntPtr clang_index_getObjCProtocolRefListInfo(/* CXIdxDeclInfo*/ IntPtr declInfo);

        [DllImport("libclang.dll")]
        internal static extern /* CXIdxObjCPropertyDeclInfo*/
IntPtr clang_index_getObjCPropertyDeclInfo(/*CXIdxDeclInfo*/ IntPtr declInfo);

        [DllImport("libclang.dll")]
        internal static extern /* CXIdxIBOutletCollectionAttrInfo*/
IntPtr clang_index_getIBOutletCollectionAttrInfo(/* CXIdxAttrInfo*/ IntPtr attrInfo);

        [DllImport("libclang.dll")]
        internal static extern /* CXIdxCXXClassDeclInfo*/
IntPtr clang_index_getCXXClassDeclInfo(/* CXIdxDeclInfo*/ IntPtr declInfo);

        /**
         * For retrieving a custom CXIdxClientContainer attached to a
         * container.
         */
        [DllImport("libclang.dll")]
        internal static extern CXIdxClientContainer
       clang_index_getClientContainer(/*CXIdxContainerInfo*/IntPtr containerInfo);

        /**
         * For setting a custom CXIdxClientContainer attached to a
         * container.
         */
        [DllImport("libclang.dll")]
        internal static extern void
       clang_index_setClientContainer(/*CXIdxContainerInfo*/ IntPtr containerInfo, CXIdxClientContainer container);

        /**
         * For retrieving a custom CXIdxClientEntity attached to an entity.
         */
        [DllImport("libclang.dll")]
        internal static extern CXIdxClientEntity
       clang_index_getClientEntity(/*CXIdxEntityInfo*/ IntPtr entityInfo);

        /**
         * For setting a custom CXIdxClientEntity attached to an entity.
         */
        [DllImport("libclang.dll")]
        internal static extern void
       clang_index_setClientEntity(/*CXIdxEntityInfo*/ IntPtr entityInfo, CXIdxClientEntity entity);


        /**
         * An indexing action/session, to be applied to one or multiple
         * translation units.
         *
         * \param CIdx The index object with which the index action will be associated.
         */
        [DllImport("libclang.dll")] internal static extern CXIndexAction clang_IndexAction_create(CXIndex CIdx);

        /**
         * Destroy the given index action.
         *
         * The index action must not be destroyed until all of the translation units
         * created within that index action have been destroyed.
         */
        [DllImport("libclang.dll")] internal static extern void clang_IndexAction_dispose(CXIndexAction indexAction);

       

        /**
         * Index the given source file and the translation unit corresponding
         * to that file via callbacks implemented through #IndexerCallbacks.
         *
         * \param client_data pointer data supplied by the client, which will
         * be passed to the invoked callbacks.
         *
         * \param index_callbacks Pointer to indexing callbacks that the client
         * implements.
         *
         * \param index_callbacks_size Size of #IndexerCallbacks structure that gets
         * passed in index_callbacks.
         *
         * \param index_options A bitmask of options that affects how indexing is
         * performed. This should be a bitwise OR of the CXIndexOpt_XXX flags.
         *
         * \param[out] out_TU pointer to store a \c CXTranslationUnit that can be
         * reused after indexing is finished. Set to \c NULL if you do not require it.
         *
         * \returns 0 on success or if there were errors from which the compiler could
         * recover.  If there is a failure from which there is no recovery, returns
         * a non-zero \c CXErrorCode.
         *
         * The rest of the parameters are the same as #clang_parseTranslationUnit.
         */
        [DllImport("libclang.dll")]
        internal static extern int clang_indexSourceFile(CXIndexAction indexAction,
                                                CXClientData client_data,
                                                /*IndexerCallbacks*/IntPtr index_callbacks,
                                                uint index_callbacks_size,
                                                uint index_options,
                                                string source_filename,
                                                string command_line_args,
                                                int num_command_line_args,
                                                out CXUnsavedFile unsaved_files,
                                                uint num_unsaved_files,
                                                out CXTranslationUnit out_TU,
                                                uint TU_options);

        /**
         * Same as clang_indexSourceFile but requires a full command line
         * for \c command_line_args including argv[0]. This is useful if the standard
         * library paths are relative to the binary.
         */
        [DllImport("libclang.dll")]
        internal static extern int clang_indexSourceFileFullArgv(
           CXIndexAction indexAction, CXClientData client_data, /*IndexerCallbacks*/IntPtr index_callbacks,
           uint index_callbacks_size, uint index_options,
           string source_filename, string command_line_args,
           int num_command_line_args, out CXUnsavedFile unsaved_files,
           uint num_unsaved_files, CXTranslationUnit* out_TU, uint TU_options);

        /**
         * Index the given translation unit via callbacks implemented through
         * #IndexerCallbacks.
         *
         * The order of callback invocations is not guaranteed to be the same as
         * when indexing a source file. The high level order will be:
         *
         *   -Preprocessor callbacks invocations
         *   -Declaration/reference callbacks invocations
         *   -Diagnostic callback invocations
         *
         * The parameters are the same as #clang_indexSourceFile.
         *
         * \returns If there is a failure from which there is no recovery, returns
         * non-zero, otherwise returns 0.
         */
        [DllImport("libclang.dll")]
        internal static extern int clang_indexTranslationUnit(CXIndexAction indexAction,
                                                     CXClientData client_data,
                                                     /*IndexerCallbacks*/IntPtr index_callbacks,
                                                     uint index_callbacks_size,
                                                     uint index_options,
                                                     CXTranslationUnit unit);

        /**
         * Retrieve the CXIdxFile, file, line, column, and offset represented by
         * the given CXIdxLoc.
         *
         * If the location refers into a macro expansion, retrieves the
         * location of the macro expansion and if it refers into a macro argument
         * retrieves the location of the argument.
         */
        [DllImport("libclang.dll")]
        internal static extern void clang_indexLoc_getFileLocation(CXIdxLoc loc,
                                                          out CXIdxClientFile indexFile,
                                                          out CXFile file,
                                                          out uint line,
                                                          out uint column,
                                                          out uint offset);

        /**
         * Retrieve the CXSourceLocation represented by the given CXIdxLoc.
         */
        [DllImport("libclang.dll")] internal static extern CXSourceLocation clang_indexLoc_getCXSourceLocation(CXIdxLoc loc);

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

        /**
         * Visit the fields of a particular type.
         *
         * This function visits all the direct fields of the given cursor,
         * invoking the given \p visitor function with the cursors of each
         * visited field. The traversal may be ended prematurely, if
         * the visitor returns \c CXFieldVisit_Break.
         *
         * \param T the record type whose field may be visited.
         *
         * \param visitor the visitor function that will be invoked for each
         * field of \p T.
         *
         * \param client_data pointer data supplied by the client, which will
         * be passed to the visitor each time it is invoked.
         *
         * \returns a non-zero value if the traversal was terminated
         * prematurely by the visitor returning \c CXFieldVisit_Break.
         */
        [DllImport("libclang.dll")]
        internal static extern uint clang_Type_visitFields(CXType T, CXFieldVisitor visitor, CXClientData client_data);

        /**
         * @}
         */

        /**
         * @}
         */
    }
}
