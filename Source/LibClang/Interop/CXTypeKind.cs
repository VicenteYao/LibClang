﻿using System;
using System.Collections.Generic;
using System.Text;

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
        CXType_Bool = 3,
        CXType_Char_U = 4,
        CXType_UChar = 5,
        CXType_Char16 = 6,
        CXType_Char32 = 7,
        CXType_UShort = 8,
        CXType_UInt = 9,
        CXType_ULong = 10,
        CXType_ULongLong = 11,
        CXType_UInt128 = 12,
        CXType_Char_S = 13,
        CXType_SChar = 14,
        CXType_WChar = 15,
        CXType_Short = 16,
        CXType_Int = 17,
        CXType_Long = 18,
        CXType_LongLong = 19,
        CXType_Int128 = 20,
        CXType_Float = 21,
        CXType_Double = 22,
        CXType_LongDouble = 23,
        CXType_NullPtr = 24,
        CXType_Overload = 25,
        CXType_Dependent = 26,
        CXType_ObjCId = 27,
        CXType_ObjCClass = 28,
        CXType_ObjCSel = 29,
        CXType_Float128 = 30,
        CXType_Half = 31,
        CXType_Float16 = 32,
        CXType_ShortAccum = 33,
        CXType_Accum = 34,
        CXType_LongAccum = 35,
        CXType_UShortAccum = 36,
        CXType_UAccum = 37,
        CXType_ULongAccum = 38,
        CXType_FirstBuiltin = CXType_Void,
        CXType_LastBuiltin = CXType_ULongAccum,

        CXType_Complex = 100,
        CXType_Pointer = 101,
        CXType_BlockPointer = 102,
        CXType_LValueReference = 103,
        CXType_RValueReference = 104,
        CXType_Record = 105,
        CXType_Enum = 106,
        CXType_Typedef = 107,
        CXType_ObjCInterface = 108,
        CXType_ObjCObjectPointer = 109,
        CXType_FunctionNoProto = 110,
        CXType_FunctionProto = 111,
        CXType_ConstantArray = 112,
        CXType_Vector = 113,
        CXType_IncompleteArray = 114,
        CXType_VariableArray = 115,
        CXType_DependentSizedArray = 116,
        CXType_MemberPointer = 117,
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
        CXType_OCLImage1dArrayRO = 122,
        CXType_OCLImage1dBufferRO = 123,
        CXType_OCLImage2dRO = 124,
        CXType_OCLImage2dArrayRO = 125,
        CXType_OCLImage2dDepthRO = 126,
        CXType_OCLImage2dArrayDepthRO = 127,
        CXType_OCLImage2dMSAARO = 128,
        CXType_OCLImage2dArrayMSAARO = 129,
        CXType_OCLImage2dMSAADepthRO = 130,
        CXType_OCLImage2dArrayMSAADepthRO = 131,
        CXType_OCLImage3dRO = 132,
        CXType_OCLImage1dWO = 133,
        CXType_OCLImage1dArrayWO = 134,
        CXType_OCLImage1dBufferWO = 135,
        CXType_OCLImage2dWO = 136,
        CXType_OCLImage2dArrayWO = 137,
        CXType_OCLImage2dDepthWO = 138,
        CXType_OCLImage2dArrayDepthWO = 139,
        CXType_OCLImage2dMSAAWO = 140,
        CXType_OCLImage2dArrayMSAAWO = 141,
        CXType_OCLImage2dMSAADepthWO = 142,
        CXType_OCLImage2dArrayMSAADepthWO = 143,
        CXType_OCLImage3dWO = 144,
        CXType_OCLImage1dRW = 145,
        CXType_OCLImage1dArrayRW = 146,
        CXType_OCLImage1dBufferRW = 147,
        CXType_OCLImage2dRW = 148,
        CXType_OCLImage2dArrayRW = 149,
        CXType_OCLImage2dDepthRW = 150,
        CXType_OCLImage2dArrayDepthRW = 151,
        CXType_OCLImage2dMSAARW = 152,
        CXType_OCLImage2dArrayMSAARW = 153,
        CXType_OCLImage2dMSAADepthRW = 154,
        CXType_OCLImage2dArrayMSAADepthRW = 155,
        CXType_OCLImage3dRW = 156,
        CXType_OCLSampler = 157,
        CXType_OCLEvent = 158,
        CXType_OCLQueue = 159,
        CXType_OCLReserveID = 160
    }


}
