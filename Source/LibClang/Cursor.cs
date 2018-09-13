using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class Cursor : ClangObject<CXCursor>
    {
        static Cursor()
        {
            
            Cursor.Null = new Cursor(clang.clang_getNullCursor());
        }

        internal Cursor(CXCursor cursor)
        {
            this.Value = cursor;
        }

        private TranslationUnit _translationUnit;
        protected TranslationUnit TranslationUnit 
        {
            get
            {
                if (this._translationUnit == null)
                {
                    this._translationUnit = new TranslationUnit(clang.clang_Cursor_getTranslationUnit(this.Value));
                }
                return this._translationUnit;
            }
        }

        public static Cursor Null { get; private set; }

        public bool IsNull
        {
            get
            {
                return clang.clang_Cursor_isNull(this.Value) > 0;
            }
        }

        public bool IsAnonymous
        {
            get
            {
              return  clang.clang_Cursor_isAnonymous(this.Value) > 0;
            }
        }

        public bool IsDynamicCall
        {
            get
            {
                return clang.clang_Cursor_isDynamicCall(this.Value) > 0;
            }
        }

        public bool IsFunctionInlined
        {
            get
            {
                return clang.clang_Cursor_isFunctionInlined(this.Value) > 0;
            }
        }

        private Cursor[] _arguments;
        public Cursor[] Arguments
        {
            get
            {
                if (this._arguments == null)
                {
                    int argumentsCount = clang.clang_Cursor_getNumArguments(this.Value);
                    if (argumentsCount == -1)
                    {
                        this._arguments = new Cursor[0];
                    }
                    else
                    {
                        this._arguments = new Cursor[argumentsCount];
                        for (uint i = 0; i < argumentsCount; i++)
                        {
                            CXCursor argument = clang.clang_Cursor_getArgument(this.Value, i);
                            this._arguments[i] = new Cursor(argument);
                        }
                    }

                }
                return this._arguments;
            }
        }

        public Type[] TemplateArguments
        {
            get;
            private set;
        }


        private Module _module;

        public Module Module
        {
            get
            {
                if (this._module == null)
                {
                    IntPtr module = clang.clang_Cursor_getModule(this.Value);
                    this._module = new Module(module);
                }
                return this._module;
            }
        }


        private string _displayName;

        public string DisplayName
        {
            get
            {
                if (this._displayName == null)
                {
                    this._displayName = clang.clang_getCursorDisplayName(this.Value).ToStringAndDispose();
                }
                return _displayName;
            }
        }

        private Type _typedefDeclUnderlyingType;
        public Type TypedefDeclUnderlyingType
        {
            get
            {
                if (this._typedefDeclUnderlyingType == null)
                {
                    this._typedefDeclUnderlyingType = new Type(clang.clang_getTypedefDeclUnderlyingType(this.Value));
                }
                return this._typedefDeclUnderlyingType;
            }
        }

        private SourceRange _sourceRange;
        public SourceRange SourceRange
        {
            get
            {
                if (this._sourceRange==null)
                {
                    this._sourceRange = new SourceRange(clang.clang_Cursor_getCommentRange(this.Value));
                }
                return this._sourceRange;
            }
        }

        private string[] _CXXManglings;

        public unsafe string[] CXXManglings
        {
            get
            {
                if (this._CXXManglings==null)
                {
                    this._CXXManglings = NativeMethodsHelper.ToStringArrayAndDispose(clang.clang_Cursor_getCXXManglings(this.Value));
                }
                return this._CXXManglings;
            }
        }

        private string _mangling;
        public string Mangling
        {
            get {
                if (this._mangling==null)
                {
                    this._mangling = clang.clang_Cursor_getMangling(this.Value).ToStringAndDispose();
                }
                return this._mangling;
            }
        }

        private string _briefCommentText;
        public string BriefCommentText
        {
            get
            {
                if (this._briefCommentText==null)
                {
                    this._briefCommentText = clang.clang_Cursor_getBriefCommentText(this.Value).ToStringAndDispose();
                }
                return this._briefCommentText;
            }
        }

        private string _rawCommentText;
        public string RawCommentText
        {
            get
            {
                if (this._rawCommentText == null)
                {
                    this._rawCommentText = clang.clang_Cursor_getRawCommentText(this.Value).ToStringAndDispose();
                }
                return this._rawCommentText;
            }
        }


        private CX_StorageClass? _storageClass;
        public CX_StorageClass StorageClass
        {
            get
            {
                if (!this._storageClass.HasValue)
                {
                    this._storageClass = clang.clang_Cursor_getStorageClass(this.Value);
                }
                return this._storageClass.Value;
            }
        }

        private EvalResult _evalResult;

        public EvalResult EvalResult
        {
            get
            {
                if (this._evalResult == null)
                {
                    this._evalResult = new EvalResult(clang.clang_Cursor_Evaluate(this.Value));
                }
                return this._evalResult;
            }
        }


        protected override void Dispose()
        {
            clang.clang_Cursor_Evaluate(this.Value);
        }

        protected override bool EqualsCore(ClangObject<CXCursor> clangObject)
        {
            return clang.clang_equalCursors(this.Value, clangObject.Value) > 0;
        }
    }
}
