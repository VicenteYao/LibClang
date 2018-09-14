using LibClang.Intertop;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang
{
    public class Type : ClangObject
    {
        protected internal override ValueType Value { get { return this.m_value; } }


        internal Type(CXType type)
        {
            this.m_value = type;
        }

        private CXType m_value;

        private uint _addressSpace;
        public uint AddressSpace
        {
            get
            {
                this._addressSpace = clang.clang_getAddressSpace(this.m_value);
                return this._addressSpace;
            }
        }
        
        private CXCursor_ExceptionSpecificationKind? exceptionSpecificationType;

        public CXCursor_ExceptionSpecificationKind ExceptionSpecificationType
        {
            get
            {
                if (!this.exceptionSpecificationType.HasValue)
                {
                    int type = clang.clang_getExceptionSpecificationType(this.m_value);
                    if (type == -1)
                    {
                        this.exceptionSpecificationType = (CXCursor_ExceptionSpecificationKind)CXCursor_ExceptionSpecificationKind.CXCursor_ExceptionSpecificationKind_None;
                    }
                    else
                    {
                        this.exceptionSpecificationType = (CXCursor_ExceptionSpecificationKind)type;
                    }
                }
                return this.exceptionSpecificationType.Value;
            }
        }

        private CXCallingConv callingConv;
        public CXCallingConv FunctionTypeCallingConversation
        {
            get
            {
                this.callingConv = clang.clang_getFunctionTypeCallingConv(this.m_value);
                return this.callingConv;
            }
        }

        

        private Type _arrayElementType;
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

        private long arraySize;
        public long ArraySize
        {
            get
            {
                this.arraySize = clang.clang_getArraySize(this.m_value);
                return this.arraySize;
            }
        }

        private Type[] _arguments;

        public Type[] Arguments
        {
            get
            {
                if (this._arguments == null)
                {
                    uint argumentCount = (uint)clang.clang_getNumArgTypes(this.m_value);
                    this._arguments = new Type[argumentCount];
                    for (uint i = 0; i < argumentCount; i++)
                    {
                        this._arguments[i] = new Type(clang.clang_getArgType(this.m_value, i));
                    }
                }
                return this.Arguments;
            }
        }

        private Type _canonicalType;
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

        private Type _classType;
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

        private Cursor typeDeclaration;
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

        private string _typedefName;

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

        private string _spelling;
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

        private Type resultType;
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

        private Type pointeeType;
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

        public static string GetTypeKindSpelling(CXTypeKind typeKind)
        {
            return clang.clang_getTypeKindSpelling(typeKind).ToStringAndDispose();
        }

        protected override bool EqualsCore(ClangObject clangObject)
        {
            return clang.clang_equalTypes(this.m_value, (CXType)clangObject.Value) > 0;
        }


        public long SizeOf
        {
            get
            {
                return clang.clang_Type_getSizeOf(this.m_value);
            }
        }

        public long Align
        {
            get
            {
                return clang.clang_Type_getAlignOf(this.m_value);
            }
        }

        public long OffsetOf(string fieldName)
        {
            return clang.clang_Type_getOffsetOf(this.m_value, fieldName);
        }


      
    }
}
