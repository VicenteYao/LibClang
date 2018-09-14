namespace LibClang.Intertop
{
    /**
        * Describes the calling convention of a function type
        */
    public enum CXCallingConv
    {
        /// <summary>
        /// Defines the CXCallingConv_Default
        /// </summary>
        CXCallingConv_Default = 0,
        /// <summary>
        /// Defines the CXCallingConv_C
        /// </summary>
        CXCallingConv_C = 1,
        /// <summary>
        /// Defines the CXCallingConv_X86StdCall
        /// </summary>
        CXCallingConv_X86StdCall = 2,
        /// <summary>
        /// Defines the CXCallingConv_X86FastCall
        /// </summary>
        CXCallingConv_X86FastCall = 3,
        /// <summary>
        /// Defines the CXCallingConv_X86ThisCall
        /// </summary>
        CXCallingConv_X86ThisCall = 4,
        /// <summary>
        /// Defines the CXCallingConv_X86Pascal
        /// </summary>
        CXCallingConv_X86Pascal = 5,
        /// <summary>
        /// Defines the CXCallingConv_AAPCS
        /// </summary>
        CXCallingConv_AAPCS = 6,
        /// <summary>
        /// Defines the CXCallingConv_AAPCS_VFP
        /// </summary>
        CXCallingConv_AAPCS_VFP = 7,
        /// <summary>
        /// Defines the CXCallingConv_X86RegCall
        /// </summary>
        CXCallingConv_X86RegCall = 8,
        /// <summary>
        /// Defines the CXCallingConv_IntelOclBicc
        /// </summary>
        CXCallingConv_IntelOclBicc = 9,
        /// <summary>
        /// Defines the CXCallingConv_Win64
        /// </summary>
        CXCallingConv_Win64 = 10,
        /* Alias for compatibility with older versions of API. */
        CXCallingConv_X86_64Win64 = CXCallingConv_Win64,
        /// <summary>
        /// Defines the CXCallingConv_X86_64SysV
        /// </summary>
        CXCallingConv_X86_64SysV = 11,
        /// <summary>
        /// Defines the CXCallingConv_X86VectorCall
        /// </summary>
        CXCallingConv_X86VectorCall = 12,
        /// <summary>
        /// Defines the CXCallingConv_Swift
        /// </summary>
        CXCallingConv_Swift = 13,
        /// <summary>
        /// Defines the CXCallingConv_PreserveMost
        /// </summary>
        CXCallingConv_PreserveMost = 14,
        /// <summary>
        /// Defines the CXCallingConv_PreserveAll
        /// </summary>
        CXCallingConv_PreserveAll = 15,
        /// <summary>
        /// Defines the CXCallingConv_Invalid
        /// </summary>
        CXCallingConv_Invalid = 100,
        /// <summary>
        /// Defines the CXCallingConv_Unexposed
        /// </summary>
        CXCallingConv_Unexposed = 200
    }
}
