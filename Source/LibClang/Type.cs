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

        private uint? _addressSpace;
        public uint AddressSpace
        {
            get
            {
                if (!this._addressSpace.HasValue)
                {
                    this._addressSpace = clang.clang_getAddressSpace(this.Value);
                }
                return this._addressSpace.Value;
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

        public long? arraySize;
        public long ArraySize
        {
            get
            {
                if (!this.arraySize.HasValue)
                {
                    this.arraySize = clang.clang_getArraySize(this.Value);
                }
                return this.arraySize.Value;
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

        public string _typedefName;

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

        protected override bool EqualsCore(ClangObject<CXType> clangObject)
        {
            return clang.clang_equalTypes(this.Value, clangObject.Value) > 0;
        }
    }
}
