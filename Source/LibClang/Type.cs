using LibClang.Intertop;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang
{
    public class Type : ClangObject<CXType>
    {
        internal Type(CXType type)
        {
            this.Value = type;
        }

        private uint _addressSpace;
        public uint AddressSpace
        {
            get
            {
                this._addressSpace = clang.clang_getAddressSpace(this.Value);
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
                    int type = clang.clang_getExceptionSpecificationType(this.Value);
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
                this.callingConv = clang.clang_getFunctionTypeCallingConv(this.Value);
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
                    this._arrayElementType = new Type(clang.clang_getArrayElementType(this.Value));
                }
                return this._arrayElementType;
            }
        }

        private long arraySize;
        public long ArraySize
        {
            get
            {
                this.arraySize = clang.clang_getArraySize(this.Value);
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
                    uint argumentCount = (uint)clang.clang_getNumArgTypes(this.Value);
                    this._arguments = new Type[argumentCount];
                    for (uint i = 0; i < argumentCount; i++)
                    {
                        this._arguments[i] = new Type(clang.clang_getArgType(this.Value, i));
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
                    this._canonicalType = new Type(clang.clang_getCanonicalType(this.Value));
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
                    this._classType = new Type(clang.clang_Type_getClassType(this.Value));
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
                    this.typeDeclaration = new Cursor(clang.clang_getTypeDeclaration(this.Value));
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
                    this._typedefName = clang.clang_getTypedefName(this.Value).ToStringAndDispose();
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
                    this._spelling = clang.clang_getTypeSpelling(this.Value).ToStringAndDispose();
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
                    CXType cxResultType = clang.clang_getResultType(this.Value);
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
                    CXType cxPointeeType = clang.clang_getPointeeType(this.Value);
                    this.pointeeType = new Type(cxPointeeType);
                }
                return this.pointeeType;
            }
        }

        public static string GetTypeKindSpelling(CXTypeKind typeKind)
        {
            return clang.clang_getTypeKindSpelling(typeKind).ToStringAndDispose();
        }

        protected override bool EqualsCore(ClangObject<CXType> clangObject)
        {
            return clang.clang_equalTypes(this.Value, clangObject.Value) > 0;
        }


        public long SizeOf
        {
            get
            {
                return clang.clang_Type_getSizeOf(this.Value);
            }
        }

        public long Align
        {
            get
            {
                return clang.clang_Type_getAlignOf(this.Value);
            }
        }

        public long OffsetOf(string fieldName)
        {
            return clang.clang_Type_getOffsetOf(this.Value, fieldName);
        }


      
    }
}
