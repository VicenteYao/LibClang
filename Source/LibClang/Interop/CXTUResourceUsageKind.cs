namespace LibClang.Intertop
{
    /**
            * Categorizes how memory is being used by a translation unit.
            */
    public enum CXTUResourceUsageKind
    {
        /// <summary>
        /// Defines the CXTUResourceUsage_AST
        /// </summary>
        CXTUResourceUsage_AST = 1,
        /// <summary>
        /// Defines the CXTUResourceUsage_Identifiers
        /// </summary>
        CXTUResourceUsage_Identifiers = 2,
        /// <summary>
        /// Defines the CXTUResourceUsage_Selectors
        /// </summary>
        CXTUResourceUsage_Selectors = 3,
        /// <summary>
        /// Defines the CXTUResourceUsage_GlobalCompletionResults
        /// </summary>
        CXTUResourceUsage_GlobalCompletionResults = 4,
        /// <summary>
        /// Defines the CXTUResourceUsage_SourceManagerContentCache
        /// </summary>
        CXTUResourceUsage_SourceManagerContentCache = 5,
        /// <summary>
        /// Defines the CXTUResourceUsage_AST_SideTables
        /// </summary>
        CXTUResourceUsage_AST_SideTables = 6,
        /// <summary>
        /// Defines the CXTUResourceUsage_SourceManager_Membuffer_Malloc
        /// </summary>
        CXTUResourceUsage_SourceManager_Membuffer_Malloc = 7,
        /// <summary>
        /// Defines the CXTUResourceUsage_SourceManager_Membuffer_MMap
        /// </summary>
        CXTUResourceUsage_SourceManager_Membuffer_MMap = 8,
        /// <summary>
        /// Defines the CXTUResourceUsage_ExternalASTSource_Membuffer_Malloc
        /// </summary>
        CXTUResourceUsage_ExternalASTSource_Membuffer_Malloc = 9,
        /// <summary>
        /// Defines the CXTUResourceUsage_ExternalASTSource_Membuffer_MMap
        /// </summary>
        CXTUResourceUsage_ExternalASTSource_Membuffer_MMap = 10,
        /// <summary>
        /// Defines the CXTUResourceUsage_Preprocessor
        /// </summary>
        CXTUResourceUsage_Preprocessor = 11,
        /// <summary>
        /// Defines the CXTUResourceUsage_PreprocessingRecord
        /// </summary>
        CXTUResourceUsage_PreprocessingRecord = 12,
        /// <summary>
        /// Defines the CXTUResourceUsage_SourceManager_DataStructures
        /// </summary>
        CXTUResourceUsage_SourceManager_DataStructures = 13,
        /// <summary>
        /// Defines the CXTUResourceUsage_Preprocessor_HeaderSearch
        /// </summary>
        CXTUResourceUsage_Preprocessor_HeaderSearch = 14,
        /// <summary>
        /// Defines the CXTUResourceUsage_MEMORY_IN_BYTES_BEGIN
        /// </summary>
        CXTUResourceUsage_MEMORY_IN_BYTES_BEGIN = CXTUResourceUsage_AST,
        /// <summary>
        /// Defines the CXTUResourceUsage_MEMORY_IN_BYTES_END
        /// </summary>
        CXTUResourceUsage_MEMORY_IN_BYTES_END =
          CXTUResourceUsage_Preprocessor_HeaderSearch,
        /// <summary>
        /// Defines the CXTUResourceUsage_First
        /// </summary>
        CXTUResourceUsage_First = CXTUResourceUsage_AST,
        /// <summary>
        /// Defines the CXTUResourceUsage_Last
        /// </summary>
        CXTUResourceUsage_Last = CXTUResourceUsage_Preprocessor_HeaderSearch
    }
}
