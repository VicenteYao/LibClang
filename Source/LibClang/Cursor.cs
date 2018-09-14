using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class Cursor : ClangObject
    {
        static Cursor()
        {
            Cursor.Null = new Cursor(clang.clang_getNullCursor());
        }

        internal Cursor(CXCursor cursor)
        {
            this.m_value = cursor;
        }

        private CXCursor m_value;

        private TranslationUnit _translationUnit;
        protected TranslationUnit TranslationUnit 
        {
            get
            {
                if (this._translationUnit == null)
                {
                    this._translationUnit = new TranslationUnit(clang.clang_Cursor_getTranslationUnit(this.m_value));
                }
                return this._translationUnit;
            }
        }


        public CXResult FindReferencesInFiles(File file, Func<Cursor, SourceRange, bool> searchFunc)
        {
            CXCursorAndRangeVisitor cursorAndRangeVisitor = default(CXCursorAndRangeVisitor);
            cursorAndRangeVisitor.Visit = Marshal.GetFunctionPointerForDelegate(new visit((context, cxCursor, cxRange) =>
            {
                if (searchFunc != null)
                {
                    Cursor cursor = new Cursor(cxCursor);
                    SourceRange sourceRange = new SourceRange(cxRange);
                    bool result = searchFunc(cursor, sourceRange);
                    return result ? CXVisitorResult.CXVisit_Continue : CXVisitorResult.CXVisit_Break;
                }
                return CXVisitorResult.CXVisit_Break;
            }));
            return clang.clang_findReferencesInFile(this.m_value, (IntPtr)file.Value, cursorAndRangeVisitor);
        }

        public static Cursor Null { get; private set; }

        public bool IsNull
        {
            get
            {
                return clang.clang_Cursor_isNull(this.m_value) > 0;
            }
        }

        public bool IsAnonymous
        {
            get
            {
              return  clang.clang_Cursor_isAnonymous(this.m_value) > 0;
            }
        }

        public bool IsDynamicCall
        {
            get
            {
                return clang.clang_Cursor_isDynamicCall(this.m_value) > 0;
            }
        }

        public bool IsFunctionInlined
        {
            get
            {
                return clang.clang_Cursor_isFunctionInlined(this.m_value) > 0;
            }
        }

        private CXCursorKind cursorKind;
        public CXCursorKind CursorKind
        {
            get
            {
                this.cursorKind = clang.clang_getCursorKind(this.m_value);
                return this.cursorKind;
            }
        }

        private Cursor[] _arguments;
        public Cursor[] Arguments
        {
            get
            {
                if (this._arguments == null)
                {
                    int argumentsCount = clang.clang_Cursor_getNumArguments(this.m_value);
                    if (argumentsCount == -1)
                    {
                        this._arguments = new Cursor[0];
                    }
                    else
                    {
                        this._arguments = new Cursor[argumentsCount];
                        for (uint i = 0; i < argumentsCount; i++)
                        {
                            CXCursor argument = clang.clang_Cursor_getArgument(this.m_value, i);
                            this._arguments[i] = new Cursor(argument);
                        }
                    }

                }
                return this._arguments;
            }
        }

        private OverriddenCursors overridesCursors;
        public unsafe OverriddenCursors OverridesCursors
        {
            get
            {
                if (this.overridesCursors == null)
                {
                    this.overridesCursors = new OverriddenCursors(this.m_value);
                }
                return overridesCursors;
            }
        }

        private CursorTemplateArguments templateArguments;
        public CursorTemplateArguments TemplateArguments
        {
            get
            {
                if (this.templateArguments==null)
                {
                    this.templateArguments = new CursorTemplateArguments(this.m_value);
                }
                return this.templateArguments;
            }
        }

        private Type _recieverType;
        public Type RecieverType
        {
            get
            {
                if (this._recieverType == null)
                {
                    if (this.m_value.kind== CXCursorKind.CXCursor_CXXMethod)
                    {
                        CXType receiverType = clang.clang_Cursor_getReceiverType(this.m_value);

                        this._recieverType = new Type(receiverType);
                    }

                }
                return this._recieverType;
            }
        }


        private Module _module;

        public Module Module
        {
            get
            {
                if (this._module == null)
                {
                    IntPtr module = clang.clang_Cursor_getModule(this.m_value);
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
                    this._displayName = clang.clang_getCursorDisplayName(this.m_value).ToStringAndDispose();
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
                    this._typedefDeclUnderlyingType = new Type(clang.clang_getTypedefDeclUnderlyingType(this.m_value));
                }
                return this._typedefDeclUnderlyingType;
            }
        }

        private SourceRange _commentRange;
        public SourceRange CommentRange
        {
            get
            {
                if (this._commentRange==null)
                {
                    this._commentRange = new SourceRange(clang.clang_Cursor_getCommentRange(this.m_value));
                }
                return this._commentRange;
            }
        }

        private SourceLocation _sourceLocation;
        public SourceLocation SourceLocation
        {
            get
            {
                if (this._sourceLocation == null)
                {
                    this._sourceLocation = new SourceLocation(clang.clang_getCursorLocation(this.m_value));
                }
                return this._sourceLocation;
            }
        }

        private File _includedFile;
        public File IncludedFile
        {
            get
            {
                if (this._includedFile==null)
                {
                    IntPtr pFile = clang.clang_getIncludedFile(this.m_value);
                    this._includedFile = new File(pFile);
                }
                return this._includedFile;
            }
        }

        private string[] _CXXManglings;

        public unsafe string[] CXXManglings
        {
            get
            {
                if (this._CXXManglings==null)
                {
                    this._CXXManglings = NativeMethodsHelper.ToStringArrayAndDispose(clang.clang_Cursor_getCXXManglings(this.m_value));
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
                    this._mangling = clang.clang_Cursor_getMangling(this.m_value).ToStringAndDispose();
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
                    this._briefCommentText = clang.clang_Cursor_getBriefCommentText(this.m_value).ToStringAndDispose();
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
                    this._rawCommentText = clang.clang_Cursor_getRawCommentText(this.m_value).ToStringAndDispose();
                }
                return this._rawCommentText;
            }
        }


        private CX_StorageClass _storageClass;
        public CX_StorageClass StorageClass
        {
            get
            {
                this._storageClass = clang.clang_Cursor_getStorageClass(this.m_value);
                return this._storageClass;
            }
        }

        private CXLanguageKind _languageKind;

        public CXLanguageKind LanguageKind
        {
            get
            {
                this._languageKind = clang.clang_getCursorLanguage(this.m_value);
                return this._languageKind;
            }
        }

        private CXVisibilityKind _visibility;
        public CXVisibilityKind Visibility
        {
            get
            {
                this._visibility = clang.clang_getCursorVisibility(this.m_value);
                return this._visibility;
            }
        }

        private CXAvailabilityKind _availability;
        public CXAvailabilityKind Availability
        {
            get
            {
                this._availability = clang.clang_getCursorAvailability(this.m_value);
                return this._availability;
            }
        }

        private CXLinkageKind _linkage;
        public CXLinkageKind  Linkage
        {
            get
            {
                this._linkage = clang.clang_getCursorLinkage(this.m_value);
                return this._linkage;
            }
        }

        private EvalResult _evalResult;

        public EvalResult EvalResult
        {
            get
            {
                if (this._evalResult == null)
                {
                    this._evalResult = new EvalResult(clang.clang_Cursor_Evaluate(this.m_value));
                }
                return this._evalResult;
            }
        }




        private Type resultType;
        public Type ResultType
        {
            get
            {
                if (this.resultType==null)
                {
                    if (this.m_value.kind== CXCursorKind.CXCursor_CXXMethod)
                    {
                        CXType cxResultType = clang.clang_getCursorResultType(this.m_value);
                        this.resultType = new Type(cxResultType);
                    }
                }
                return this.resultType;
            }
        }

        protected internal override ValueType Value { get { return this.m_value; } }

        protected override void Dispose()
        {
            clang.clang_Cursor_Evaluate(this.m_value);
        }

        protected override bool EqualsCore(ClangObject clangObject)
        {
            return clang.clang_equalCursors(this.m_value, (CXCursor)clangObject.Value) > 0;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", this.DisplayName, this.SourceLocation);
        }
    }
}
