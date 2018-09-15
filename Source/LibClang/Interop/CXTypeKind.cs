namespace LibClang.Intertop
{
    /**
             * @}
             */

    /**
     * \defgroup CINDEX_TYPES Type information for CXCursors
     *
     * @{
     */

    /**
     * Describes the kind of type
     */
    public enum CXTypeKind
    {
        /**
                                 * Represents an invalid type (e.g., where no type is available).
                                 */
        CXType_Invalid = 0,
        /**
         * A type whose specific kind is not exposed via this
         * interface.
         */
        CXType_Unexposed = 1,
        /* Builtin types */
        CXType_Void = 2,
        /// <summary>
        /// Defines the CXType_Bool
        /// </summary>
        CXType_Bool = 3,
        /// <summary>
        /// Defines the CXType_Char_U
        /// </summary>
        CXType_Char_U = 4,
        /// <summary>
        /// Defines the CXType_UChar
        /// </summary>
        CXType_UChar = 5,
        /// <summary>
        /// Defines the CXType_Char16
        /// </summary>
        CXType_Char16 = 6,
        /// <summary>
        /// Defines the CXType_Char32
        /// </summary>
        CXType_Char32 = 7,
        /// <summary>
        /// Defines the CXType_UShort
        /// </summary>
        CXType_UShort = 8,
        /// <summary>
        /// Defines the CXType_UInt
        /// </summary>
        CXType_UInt = 9,
        /// <summary>
        /// Defines the CXType_ULong
        /// </summary>
        CXType_ULong = 10,
        /// <summary>
        /// Defines the CXType_ULongLong
        /// </summary>
        CXType_ULongLong = 11,
        /// <summary>
        /// Defines the CXType_UInt128
        /// </summary>
        CXType_UInt128 = 12,
        /// <summary>
        /// Defines the CXType_Char_S
        /// </summary>
        CXType_Char_S = 13,
        /// <summary>
        /// Defines the CXType_SChar
        /// </summary>
        CXType_SChar = 14,
        /// <summary>
        /// Defines the CXType_WChar
        /// </summary>
        CXType_WChar = 15,
        /// <summary>
        /// Defines the CXType_Short
        /// </summary>
        CXType_Short = 16,
        /// <summary>
        /// Defines the CXType_Int
        /// </summary>
        CXType_Int = 17,
        /// <summary>
        /// Defines the CXType_Long
        /// </summary>
        CXType_Long = 18,
        /// <summary>
        /// Defines the CXType_LongLong
        /// </summary>
        CXType_LongLong = 19,
        /// <summary>
        /// Defines the CXType_Int128
        /// </summary>
        CXType_Int128 = 20,
        /// <summary>
        /// Defines the CXType_Float
        /// </summary>
        CXType_Float = 21,
        /// <summary>
        /// Defines the CXType_Double
        /// </summary>
        CXType_Double = 22,
        /// <summary>
        /// Defines the CXType_LongDouble
        /// </summary>
        CXType_LongDouble = 23,
        /// <summary>
        /// Defines the CXType_NullPtr
        /// </summary>
        CXType_NullPtr = 24,
        /// <summary>
        /// Defines the CXType_Overload
        /// </summary>
        CXType_Overload = 25,
        /// <summary>
        /// Defines the CXType_Dependent
        /// </summary>
        CXType_Dependent = 26,
        /// <summary>
        /// Defines the CXType_ObjCId
        /// </summary>
        CXType_ObjCId = 27,
        /// <summary>
        /// Defines the CXType_ObjCClass
        /// </summary>
        CXType_ObjCClass = 28,
        /// <summary>
        /// Defines the CXType_ObjCSel
        /// </summary>
        CXType_ObjCSel = 29,
        /// <summary>
        /// Defines the CXType_Float128
        /// </summary>
        CXType_Float128 = 30,
        /// <summary>
        /// Defines the CXType_Half
        /// </summary>
        CXType_Half = 31,
        /// <summary>
        /// Defines the CXType_Float16
        /// </summary>
        CXType_Float16 = 32,
        /// <summary>
        /// Defines the CXType_ShortAccum
        /// </summary>
        CXType_ShortAccum = 33,
        /// <summary>
        /// Defines the CXType_Accum
        /// </summary>
        CXType_Accum = 34,
        /// <summary>
        /// Defines the CXType_LongAccum
        /// </summary>
        CXType_LongAccum = 35,
        /// <summary>
        /// Defines the CXType_UShortAccum
        /// </summary>
        CXType_UShortAccum = 36,
        /// <summary>
        /// Defines the CXType_UAccum
        /// </summary>
        CXType_UAccum = 37,
        /// <summary>
        /// Defines the CXType_ULongAccum
        /// </summary>
        CXType_ULongAccum = 38,
        /// <summary>
        /// Defines the CXType_FirstBuiltin
        /// </summary>
        CXType_FirstBuiltin = CXType_Void,
        /// <summary>
        /// Defines the CXType_LastBuiltin
        /// </summary>
        CXType_LastBuiltin = CXType_ULongAccum,
        /// <summary>
        /// Defines the CXType_Complex
        /// </summary>
        CXType_Complex = 100,
        /// <summary>
        /// Defines the CXType_Pointer
        /// </summary>
        CXType_Pointer = 101,
        /// <summary>
        /// Defines the CXType_BlockPointer
        /// </summary>
        CXType_BlockPointer = 102,
        /// <summary>
        /// Defines the CXType_LValueReference
        /// </summary>
        CXType_LValueReference = 103,
        /// <summary>
        /// Defines the CXType_RValueReference
        /// </summary>
        CXType_RValueReference = 104,
        /// <summary>
        /// Defines the CXType_Record
        /// </summary>
        CXType_Record = 105,
        /// <summary>
        /// Defines the CXType_Enum
        /// </summary>
        CXType_Enum = 106,
        /// <summary>
        /// Defines the CXType_Typedef
        /// </summary>
        CXType_Typedef = 107,
        /// <summary>
        /// Defines the CXType_ObjCInterface
        /// </summary>
        CXType_ObjCInterface = 108,
        /// <summary>
        /// Defines the CXType_ObjCObjectPointer
        /// </summary>
        CXType_ObjCObjectPointer = 109,
        /// <summary>
        /// Defines the CXType_FunctionNoProto
        /// </summary>
        CXType_FunctionNoProto = 110,
        /// <summary>
        /// Defines the CXType_FunctionProto
        /// </summary>
        CXType_FunctionProto = 111,
        /// <summary>
        /// Defines the CXType_ConstantArray
        /// </summary>
        CXType_ConstantArray = 112,
        /// <summary>
        /// Defines the CXType_Vector
        /// </summary>
        CXType_Vector = 113,
        /// <summary>
        /// Defines the CXType_IncompleteArray
        /// </summary>
        CXType_IncompleteArray = 114,
        /// <summary>
        /// Defines the CXType_VariableArray
        /// </summary>
        CXType_VariableArray = 115,
        /// <summary>
        /// Defines the CXType_DependentSizedArray
        /// </summary>
        CXType_DependentSizedArray = 116,
        /// <summary>
        /// Defines the CXType_MemberPointer
        /// </summary>
        CXType_MemberPointer = 117,
        /// <summary>
        /// Defines the CXType_Auto
        /// </summary>
        CXType_Auto = 118,
        /**
         * Represents a type that was referred to using an elaborated type keyword.
         *
         * E.g., struct S, or via a qualified name, e.g., N::M::type, or both.
         */
        CXType_Elaborated = 119,
        /* OpenCL PipeType. */
        CXType_Pipe = 120,
        /* OpenCL builtin types. */
        CXType_OCLImage1dRO = 121,
        /// <summary>
        /// Defines the CXType_OCLImage1dArrayRO
        /// </summary>
        CXType_OCLImage1dArrayRO = 122,
        /// <summary>
        /// Defines the CXType_OCLImage1dBufferRO
        /// </summary>
        CXType_OCLImage1dBufferRO = 123,
        /// <summary>
        /// Defines the CXType_OCLImage2dRO
        /// </summary>
        CXType_OCLImage2dRO = 124,
        /// <summary>
        /// Defines the CXType_OCLImage2dArrayRO
        /// </summary>
        CXType_OCLImage2dArrayRO = 125,
        /// <summary>
        /// Defines the CXType_OCLImage2dDepthRO
        /// </summary>
        CXType_OCLImage2dDepthRO = 126,
        /// <summary>
        /// Defines the CXType_OCLImage2dArrayDepthRO
        /// </summary>
        CXType_OCLImage2dArrayDepthRO = 127,
        /// <summary>
        /// Defines the CXType_OCLImage2dMSAARO
        /// </summary>
        CXType_OCLImage2dMSAARO = 128,
        /// <summary>
        /// Defines the CXType_OCLImage2dArrayMSAARO
        /// </summary>
        CXType_OCLImage2dArrayMSAARO = 129,
        /// <summary>
        /// Defines the CXType_OCLImage2dMSAADepthRO
        /// </summary>
        CXType_OCLImage2dMSAADepthRO = 130,
        /// <summary>
        /// Defines the CXType_OCLImage2dArrayMSAADepthRO
        /// </summary>
        CXType_OCLImage2dArrayMSAADepthRO = 131,
        /// <summary>
        /// Defines the CXType_OCLImage3dRO
        /// </summary>
        CXType_OCLImage3dRO = 132,
        /// <summary>
        /// Defines the CXType_OCLImage1dWO
        /// </summary>
        CXType_OCLImage1dWO = 133,
        /// <summary>
        /// Defines the CXType_OCLImage1dArrayWO
        /// </summary>
        CXType_OCLImage1dArrayWO = 134,
        /// <summary>
        /// Defines the CXType_OCLImage1dBufferWO
        /// </summary>
        CXType_OCLImage1dBufferWO = 135,
        /// <summary>
        /// Defines the CXType_OCLImage2dWO
        /// </summary>
        CXType_OCLImage2dWO = 136,
        /// <summary>
        /// Defines the CXType_OCLImage2dArrayWO
        /// </summary>
        CXType_OCLImage2dArrayWO = 137,
        /// <summary>
        /// Defines the CXType_OCLImage2dDepthWO
        /// </summary>
        CXType_OCLImage2dDepthWO = 138,
        /// <summary>
        /// Defines the CXType_OCLImage2dArrayDepthWO
        /// </summary>
        CXType_OCLImage2dArrayDepthWO = 139,
        /// <summary>
        /// Defines the CXType_OCLImage2dMSAAWO
        /// </summary>
        CXType_OCLImage2dMSAAWO = 140,
        /// <summary>
        /// Defines the CXType_OCLImage2dArrayMSAAWO
        /// </summary>
        CXType_OCLImage2dArrayMSAAWO = 141,
        /// <summary>
        /// Defines the CXType_OCLImage2dMSAADepthWO
        /// </summary>
        CXType_OCLImage2dMSAADepthWO = 142,
        /// <summary>
        /// Defines the CXType_OCLImage2dArrayMSAADepthWO
        /// </summary>
        CXType_OCLImage2dArrayMSAADepthWO = 143,
        /// <summary>
        /// Defines the CXType_OCLImage3dWO
        /// </summary>
        CXType_OCLImage3dWO = 144,
        /// <summary>
        /// Defines the CXType_OCLImage1dRW
        /// </summary>
        CXType_OCLImage1dRW = 145,
        /// <summary>
        /// Defines the CXType_OCLImage1dArrayRW
        /// </summary>
        CXType_OCLImage1dArrayRW = 146,
        /// <summary>
        /// Defines the CXType_OCLImage1dBufferRW
        /// </summary>
        CXType_OCLImage1dBufferRW = 147,
        /// <summary>
        /// Defines the CXType_OCLImage2dRW
        /// </summary>
        CXType_OCLImage2dRW = 148,
        /// <summary>
        /// Defines the CXType_OCLImage2dArrayRW
        /// </summary>
        CXType_OCLImage2dArrayRW = 149,
        /// <summary>
        /// Defines the CXType_OCLImage2dDepthRW
        /// </summary>
        CXType_OCLImage2dDepthRW = 150,
        /// <summary>
        /// Defines the CXType_OCLImage2dArrayDepthRW
        /// </summary>
        CXType_OCLImage2dArrayDepthRW = 151,
        /// <summary>
        /// Defines the CXType_OCLImage2dMSAARW
        /// </summary>
        CXType_OCLImage2dMSAARW = 152,
        /// <summary>
        /// Defines the CXType_OCLImage2dArrayMSAARW
        /// </summary>
        CXType_OCLImage2dArrayMSAARW = 153,
        /// <summary>
        /// Defines the CXType_OCLImage2dMSAADepthRW
        /// </summary>
        CXType_OCLImage2dMSAADepthRW = 154,
        /// <summary>
        /// Defines the CXType_OCLImage2dArrayMSAADepthRW
        /// </summary>
        CXType_OCLImage2dArrayMSAADepthRW = 155,
        /// <summary>
        /// Defines the CXType_OCLImage3dRW
        /// </summary>
        CXType_OCLImage3dRW = 156,
        /// <summary>
        /// Defines the CXType_OCLSampler
        /// </summary>
        CXType_OCLSampler = 157,
        /// <summary>
        /// Defines the CXType_OCLEvent
        /// </summary>
        CXType_OCLEvent = 158,
        /// <summary>
        /// Defines the CXType_OCLQueue
        /// </summary>
        CXType_OCLQueue = 159,
        /// <summary>
        /// Defines the CXType_OCLReserveID
        /// </summary>
        CXType_OCLReserveID = 160
    }
}
