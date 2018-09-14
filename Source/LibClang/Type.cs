namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="Type" />
    /// </summary>
    public class Type : ClangObject
    {
        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value
        {
            get { return this.m_value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Type"/> class.
        /// </summary>
        /// <param name="type">The type<see cref="CXType"/></param>
        internal Type(CXType type)
        {
            this.m_value = type;
        }

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private CXType m_value;

        /// <summary>
        /// Defines the _addressSpace
        /// </summary>
        private uint _addressSpace;

        /// <summary>
        /// Gets the AddressSpace
        /// </summary>
        public uint AddressSpace
        {
            get
            {
                this._addressSpace = clang.clang_getAddressSpace(this.m_value);
                return this._addressSpace;
            }
        }

        /// <summary>
        /// Defines the refQualifierKind
        /// </summary>
        private CXRefQualifierKind refQualifierKind;

        /// <summary>
        /// Gets the RefQualifierKind
        /// </summary>
        public CXRefQualifierKind RefQualifierKind
        {
            get
            {
                this.refQualifierKind = clang.clang_Type_getCXXRefQualifier(this.m_value);
                return this.refQualifierKind;
            }
        }

        /// <summary>
        /// Defines the exceptionSpecificationType
        /// </summary>
        private CXCursor_ExceptionSpecificationKind exceptionSpecificationType;

        /// <summary>
        /// Gets the ExceptionSpecificationType
        /// </summary>
        public CXCursor_ExceptionSpecificationKind ExceptionSpecificationType
        {
            get
            {
                int type = clang.clang_getExceptionSpecificationType(this.m_value);
                if (type == -1)
                {
                    this.exceptionSpecificationType = CXCursor_ExceptionSpecificationKind.CXCursor_ExceptionSpecificationKind_None;
                }
                else
                {
                    this.exceptionSpecificationType = (CXCursor_ExceptionSpecificationKind)type;
                }
                return this.exceptionSpecificationType;
            }
        }

        /// <summary>
        /// Defines the callingConv
        /// </summary>
        private CXCallingConv callingConv;

        /// <summary>
        /// Gets the FunctionTypeCallingConversation
        /// </summary>
        public CXCallingConv FunctionTypeCallingConversation
        {
            get
            {
                this.callingConv = clang.clang_getFunctionTypeCallingConv(this.m_value);
                return this.callingConv;
            }
        }

        /// <summary>
        /// Defines the _arrayElementType
        /// </summary>
        private Type _arrayElementType;

        /// <summary>
        /// Gets the ArrayElementType
        /// </summary>
        public Type ArrayElementType
        {
            get
            {
                if (this._arrayElementType == null)
                {
                    this._arrayElementType = new Type(clang.clang_getArrayElementType(this.m_value));
                }
                return this._arrayElementType;
            }
        }

        /// <summary>
        /// Defines the arraySize
        /// </summary>
        private long arraySize;

        /// <summary>
        /// Gets the ArraySize
        /// </summary>
        public long ArraySize
        {
            get
            {
                this.arraySize = clang.clang_getArraySize(this.m_value);
                return this.arraySize;
            }
        }

        /// <summary>
        /// Defines the _arguments
        /// </summary>
        private Type[] _arguments;

        /// <summary>
        /// Gets the Arguments
        /// </summary>
        public Type[] Arguments
        {
            get
            {
                if (this._arguments == null)
                {
                    int argumentCount = clang.clang_getNumArgTypes(this.m_value);
                    this._arguments = new Type[argumentCount];
                    for (uint i = 0; i < argumentCount; i++)
                    {
                        this._arguments[i] = new Type(clang.clang_getArgType(this.m_value, i));
                    }
                }
                return this.Arguments;
            }
        }

        /// <summary>
        /// Defines the _canonicalType
        /// </summary>
        private Type _canonicalType;

        /// <summary>
        /// Gets the CanonicalType
        /// </summary>
        public Type CanonicalType
        {
            get
            {
                if (this._canonicalType == null)
                {
                    this._canonicalType = new Type(clang.clang_getCanonicalType(this.m_value));
                }
                return this._canonicalType;
            }
        }

        /// <summary>
        /// Defines the _classType
        /// </summary>
        private Type _classType;

        /// <summary>
        /// Gets the ClassType
        /// </summary>
        public Type ClassType
        {
            get
            {
                if (this._classType == null)
                {
                    this._classType = new Type(clang.clang_Type_getClassType(this.m_value));
                }
                return this._canonicalType;
            }
        }

        /// <summary>
        /// Defines the typeDeclaration
        /// </summary>
        private Cursor typeDeclaration;

        /// <summary>
        /// Gets the TypeDeclaration
        /// </summary>
        public Cursor TypeDeclaration
        {
            get
            {
                if (this.typeDeclaration == null)
                {
                    this.typeDeclaration = new Cursor(clang.clang_getTypeDeclaration(this.m_value));
                }
                return this.typeDeclaration;
            }
        }

        /// <summary>
        /// Defines the templateArguments
        /// </summary>
        private TypeTemplateArguments templateArguments;

        /// <summary>
        /// Gets the TemplateArguments
        /// </summary>
        public TypeTemplateArguments TemplateArguments
        {
            get
            {
                if (this.templateArguments == null)
                {
                    this.templateArguments = new TypeTemplateArguments(this.m_value);
                }
                return this.templateArguments;
            }
        }

        /// <summary>
        /// Defines the _typedefName
        /// </summary>
        private string _typedefName;

        /// <summary>
        /// Gets the TypedefName
        /// </summary>
        public string TypedefName
        {
            get
            {
                if (this._typedefName == null)
                {
                    this._typedefName = clang.clang_getTypedefName(this.m_value).ToStringAndDispose();
                }

                return this._typedefName;
            }
        }

        /// <summary>
        /// Defines the _spelling
        /// </summary>
        private string _spelling;

        /// <summary>
        /// Gets the Spelling
        /// </summary>
        public string Spelling
        {
            get
            {
                if (this._spelling == null)
                {
                    this._spelling = clang.clang_getTypeSpelling(this.m_value).ToStringAndDispose();
                }
                return this._spelling;
            }
        }

        /// <summary>
        /// Defines the resultType
        /// </summary>
        private Type resultType;

        /// <summary>
        /// Gets the ResultType
        /// </summary>
        public Type ResultType
        {
            get
            {
                if (this.resultType == null)
                {
                    CXType cxResultType = clang.clang_getResultType(this.m_value);
                    this.resultType = new Type(cxResultType);
                }
                return this.resultType;
            }
        }

        /// <summary>
        /// Defines the pointeeType
        /// </summary>
        private Type pointeeType;

        /// <summary>
        /// Gets the PointeeType
        /// </summary>
        public Type PointeeType
        {
            get
            {
                if (this.pointeeType == null)
                {
                    CXType cxPointeeType = clang.clang_getPointeeType(this.m_value);
                    this.pointeeType = new Type(cxPointeeType);
                }
                return this.pointeeType;
            }
        }

        /// <summary>
        /// The GetTypeKindSpelling
        /// </summary>
        /// <param name="typeKind">The typeKind<see cref="CXTypeKind"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string GetTypeKindSpelling(CXTypeKind typeKind)
        {
            return clang.clang_getTypeKindSpelling(typeKind).ToStringAndDispose();
        }

        /// <summary>
        /// The EqualsCore
        /// </summary>
        /// <param name="clangObject">The clangObject<see cref="ClangObject"/></param>
        /// <returns>The <see cref="bool"/></returns>
        protected override bool EqualsCore(ClangObject clangObject)
        {
            return clang.clang_equalTypes(this.m_value, (CXType)clangObject.Value) > 0;
        }

        /// <summary>
        /// Gets the Size
        /// </summary>
        public long Size
        {
            get
            {
                return clang.clang_Type_getSizeOf(this.m_value);
            }
        }

        /// <summary>
        /// Gets the Alignment
        /// </summary>
        public long Alignment
        {
            get
            {
                return clang.clang_Type_getAlignOf(this.m_value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether IsRestrict
        /// </summary>
        public bool IsRestrict
        {
            get
            {
                return clang.clang_isRestrictQualifiedType(this.m_value) > 0;
            }
        }

        /// <summary>
        /// Gets a value indicating whether IsVolatile
        /// </summary>
        public bool IsVolatile
        {
            get
            {
                return clang.clang_isVolatileQualifiedType(this.m_value) > 0;
            }
        }

        /// <summary>
        /// Gets a value indicating whether IsFunctionTypeVariadic
        /// </summary>
        public bool IsFunctionTypeVariadic
        {
            get
            {
                return clang.clang_isFunctionTypeVariadic(this.m_value) > 0;
            }
        }

        /// <summary>
        /// Gets a value indicating whether IsConst
        /// </summary>
        public bool IsConst
        {
            get
            {
                return clang.clang_isConstQualifiedType(this.m_value) > 0;
            }
        }

        /// <summary>
        /// Gets a value indicating whether IsTransparentTagTypedef
        /// </summary>
        public bool IsTransparentTagTypedef
        {
            get
            {
                return clang.clang_Type_isTransparentTagTypedef(this.m_value) > 0;
            }
        }

        /// <summary>
        /// Gets the ObjCEncoding
        /// </summary>
        public string ObjCEncoding
        {
            get
            {
                return clang.clang_Type_getObjCEncoding(this.m_value).ToStringAndDispose();
            }
        }

        /// <summary>
        /// Defines the namedType
        /// </summary>
        private Type namedType;

        /// <summary>
        /// Gets the NamedType
        /// </summary>
        public Type NamedType
        {
            get
            {
                if (this.namedType == null)
                {
                    CXType type = clang.clang_Type_getNamedType(this.m_value);
                    this.namedType = new Type(type);
                }
                return this.namedType;
            }
        }

        /// <summary>
        /// Gets a value indicating whether IsPOD
        /// </summary>
        public bool IsPOD
        {
            get
            {
                return clang.clang_isPODType(this.m_value) > 0;
            }
        }

        /// <summary>
        /// The OffsetOf
        /// </summary>
        /// <param name="fieldName">The fieldName<see cref="string"/></param>
        /// <returns>The <see cref="long"/></returns>
        public long OffsetOf(string fieldName)
        {
            long value = clang.clang_Type_getOffsetOf(this.m_value, fieldName);
            if (value < 0)
            {
                CXTypeLayoutError layoutError = (CXTypeLayoutError)value;
                switch (layoutError)
                {
                    case CXTypeLayoutError.CXTypeLayoutError_Invalid:
                        break;
                    case CXTypeLayoutError.CXTypeLayoutError_Incomplete:
                        break;
                    case CXTypeLayoutError.CXTypeLayoutError_Dependent:
                        break;
                    case CXTypeLayoutError.CXTypeLayoutError_NotConstantSize:
                        break;
                    case CXTypeLayoutError.CXTypeLayoutError_InvalidFieldName:
                        break;
                    default:
                        break;
                }
            }
            return value;
        }
    }
}
