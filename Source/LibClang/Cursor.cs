namespace LibClang
{
    using LibClang.Intertop;
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Defines the <see cref="Cursor" />
    /// </summary>
    public class Cursor : ClangObject
    {
        /// <summary>
        /// Initializes static members of the <see cref="Cursor"/> class.
        /// </summary>
        static Cursor()
        {
            Cursor.Null = new Cursor(clang.clang_getNullCursor());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cursor"/> class.
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        internal Cursor(CXCursor cursor)
        {
            this.m_value = cursor;
        }

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private CXCursor m_value;

        /// <summary>
        /// Defines the _translationUnit
        /// </summary>
        private TranslationUnit _translationUnit;

        /// <summary>
        /// Gets the TranslationUnit
        /// </summary>
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

        /// <summary>
        /// Defines the platformAvailibility
        /// </summary>
        private ClangList<PlatformAvailibility> platformAvailibility;

        /// <summary>
        /// Gets the PlatformAvailibility
        /// </summary>
        public ClangList<PlatformAvailibility> PlatformAvailibility
        {
            get
            {
                if (this.platformAvailibility == null)
                {

                    this.platformAvailibility = this.GetPlatformAvailibility();
                }
                return this.platformAvailibility;
            }
        }

        /// <summary>
        /// The GetPlatformAvailibility
        /// </summary>
        /// <param name="alwaysDeprecated">The alwaysDeprecated<see cref="bool"/></param>
        /// <param name="deprecatedMessage">The deprecatedMessage<see cref="string"/></param>
        /// <param name="alwaysUnavailable">The alwaysUnavailable<see cref="bool"/></param>
        /// <param name="unavailableMessage">The unavailableMessage<see cref="string"/></param>
        /// <returns>The <see cref="PlatformAvailibilityList[]"/></returns>
        public unsafe ClangList<PlatformAvailibility> GetPlatformAvailibility(out bool alwaysDeprecated,
            out string deprecatedMessage, out bool alwaysUnavailable, out string unavailableMessage)
        {
            alwaysDeprecated = false;
            deprecatedMessage = null;
            alwaysUnavailable = false;
            unavailableMessage = null;
            if (this.platformAvailibility == null)
            {
                int always_deprecated;
                CXString deprecated_message;
                int always_unavailable;
                CXString unavailable_message;
                CXPlatformAvailability* pAvailability;
                int availability_size = clang.clang_getCursorPlatformAvailability(this.m_value,
                    out always_deprecated,
                    out deprecated_message,
                    out always_unavailable,
                    out unavailable_message,
                    out pAvailability,
                    0);
                int length = clang.clang_getCursorPlatformAvailability(this.m_value,
                     out always_deprecated,
                     out deprecated_message,
                     out always_unavailable,
                     out unavailable_message,
                     out pAvailability,
                     availability_size);
                alwaysDeprecated = always_deprecated > 0;
                deprecatedMessage = deprecated_message.ToStringAndDispose();
                alwaysUnavailable = always_unavailable > 0;
                unavailableMessage = unavailable_message.ToStringAndDispose();
                this.platformAvailibility = new PlatformAvailibilityList(pAvailability, length);
            }
            return this.platformAvailibility;
        }

        /// <summary>
        /// The GetPlatformAvailibility
        /// </summary>
        /// <returns>The <see cref="PlatformAvailibilityList"/></returns>
        public unsafe ClangList<PlatformAvailibility> GetPlatformAvailibility()
        {
            if (this.platformAvailibility == null)
            {
                int always_deprecated;
                CXString deprecated_message;
                int always_unavailable;
                CXString unavailable_message;
                CXPlatformAvailability* pAvailability;
                int availability_size = clang.clang_getCursorPlatformAvailability(this.m_value,
                    out always_deprecated,
                    out deprecated_message,
                    out always_unavailable,
                    out unavailable_message,
                    out pAvailability,
                    0);
                int length = clang.clang_getCursorPlatformAvailability(this.m_value,
                     out always_deprecated,
                     out deprecated_message,
                     out always_unavailable,
                     out unavailable_message,
                     out pAvailability,
                     availability_size);
                this.platformAvailibility = new PlatformAvailibilityList(pAvailability, length);
            }
            return this.platformAvailibility;
        }

        /// <summary>
        /// The FindReferencesInFiles
        /// </summary>
        /// <param name="file">The file<see cref="File"/></param>
        /// <param name="searchFunc">The searchFunc<see cref="Func{Cursor, SourceRange, bool}"/></param>
        /// <returns>The <see cref="CXResult"/></returns>
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

        /// <summary>
        /// Gets the Null
        /// </summary>
        public static Cursor Null { get; private set; }

        /// <summary>
        /// Gets a value indicating whether IsNull
        /// </summary>
        public bool IsNull
        {
            get
            {
                return clang.clang_Cursor_isNull(this.m_value) > 0;
            }
        }

        /// <summary>
        /// Gets a value indicating whether IsAnonymous
        /// </summary>
        public bool IsAnonymous
        {
            get
            {
                return clang.clang_Cursor_isAnonymous(this.m_value) > 0;
            }
        }

        /// <summary>
        /// Gets a value indicating whether IsDynamicCall
        /// </summary>
        public bool IsDynamicCall
        {
            get
            {
                return clang.clang_Cursor_isDynamicCall(this.m_value) > 0;
            }
        }

        /// <summary>
        /// Gets a value indicating whether IsFunctionInlined
        /// </summary>
        public bool IsFunctionInlined
        {
            get
            {
                return clang.clang_Cursor_isFunctionInlined(this.m_value) > 0;
            }
        }

        /// <summary>
        /// Defines the cursorKind
        /// </summary>
        private CXCursorKind cursorKind;

        /// <summary>
        /// Gets the CursorKind
        /// </summary>
        public CXCursorKind CursorKind
        {
            get
            {
                this.cursorKind = clang.clang_getCursorKind(this.m_value);
                return this.cursorKind;
            }
        }

        /// <summary>
        /// Defines the _arguments
        /// </summary>
        private Cursor[] _arguments;

        /// <summary>
        /// Gets the Arguments
        /// </summary>
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

        /// <summary>
        /// Defines the overridesCursors
        /// </summary>
        private ClangList<Cursor> overridesCursors;

        /// <summary>
        /// Gets the OverridesCursors
        /// </summary>
        public unsafe ClangList<Cursor> OverridesCursors
        {
            get
            {
                if (this.overridesCursors == null)
                {
                    this.overridesCursors = new OverriddenCursorList(this.m_value);
                }
                return overridesCursors;
            }
        }

        /// <summary>
        /// Defines the templateArguments
        /// </summary>
        private ClangList<TemplateArgument> templateArguments;

        /// <summary>
        /// Gets the TemplateArguments
        /// </summary>
        public ClangList<TemplateArgument> TemplateArguments
        {
            get
            {
                if (this.templateArguments == null)
                {
                    this.templateArguments = new CursorTemplateArgumentList(this.m_value);
                }
                return this.templateArguments;
            }
        }

        /// <summary>
        /// Defines the _recieverType
        /// </summary>
        private Type _recieverType;

        /// <summary>
        /// Gets the RecieverType
        /// </summary>
        public Type RecieverType
        {
            get
            {
                if (this._recieverType == null)
                {
                    CXCursorKind cursorKind = this.m_value.kind;
                    if (cursorKind == CXCursorKind.CXCursor_CXXMethod ||
                        cursorKind == CXCursorKind.CXCursor_ObjCMessageExpr ||
                        cursorKind == CXCursorKind.CXCursor_ObjCProtocolRef)
                    {
                        CXType receiverType = clang.clang_Cursor_getReceiverType(this.m_value);

                        this._recieverType = new Type(receiverType);
                    }

                }
                return this._recieverType;
            }
        }

        /// <summary>
        /// Defines the _module
        /// </summary>
        private Module _module;

        /// <summary>
        /// Gets the Module
        /// </summary>
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

        /// <summary>
        /// Defines the _displayName
        /// </summary>
        private string _displayName;

        /// <summary>
        /// Gets the DisplayName
        /// </summary>
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

        /// <summary>
        /// Defines the _typedefDeclUnderlyingType
        /// </summary>
        private Type _typedefDeclUnderlyingType;

        /// <summary>
        /// Gets the TypedefDeclUnderlyingType
        /// </summary>
        public Type TypedefDeclUnderlyingType
        {
            get
            {
                if (this._typedefDeclUnderlyingType == null && this.CursorKind == CXCursorKind.CXCursor_TypedefDecl)
                {
                    this._typedefDeclUnderlyingType = new Type(clang.clang_getTypedefDeclUnderlyingType(this.m_value));
                }
                return this._typedefDeclUnderlyingType;
            }
        }

        /// <summary>
        /// Defines the _commentRange
        /// </summary>
        private SourceRange _commentRange;

        /// <summary>
        /// Gets the CommentRange
        /// </summary>
        public SourceRange CommentRange
        {
            get
            {
                if (this._commentRange == null)
                {
                    this._commentRange = new SourceRange(clang.clang_Cursor_getCommentRange(this.m_value));
                }
                return this._commentRange;
            }
        }

        /// <summary>
        /// Defines the _sourceLocation
        /// </summary>
        private SourceLocation _sourceLocation;

        /// <summary>
        /// Gets the SourceLocation
        /// </summary>
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

        /// <summary>
        /// Defines the _includedFile
        /// </summary>
        private File _includedFile;

        /// <summary>
        /// Gets the IncludedFile
        /// </summary>
        public File IncludedFile
        {
            get
            {
                if (this._includedFile == null)
                {
                    IntPtr pFile = clang.clang_getIncludedFile(this.m_value);
                    this._includedFile = new File(pFile);
                }
                return this._includedFile;
            }
        }

        /// <summary>
        /// Defines the _CXXManglings
        /// </summary>
        private string[] _CXXManglings;

        /// <summary>
        /// Gets the CXXManglings
        /// </summary>
        public unsafe string[] CXXManglings
        {
            get
            {
                if (this._CXXManglings == null)
                {
                    this._CXXManglings = NativeMethodsHelper.ToStringArrayAndDispose(clang.clang_Cursor_getCXXManglings(this.m_value));
                }
                return this._CXXManglings;
            }
        }

        /// <summary>
        /// Defines the _mangling
        /// </summary>
        private string _mangling;

        /// <summary>
        /// Gets the Mangling
        /// </summary>
        public string Mangling
        {
            get
            {
                if (this._mangling == null)
                {
                    this._mangling = clang.clang_Cursor_getMangling(this.m_value).ToStringAndDispose();
                }
                return this._mangling;
            }
        }

        /// <summary>
        /// Defines the _briefCommentText
        /// </summary>
        private string _briefCommentText;

        /// <summary>
        /// Gets the BriefCommentText
        /// </summary>
        public string BriefCommentText
        {
            get
            {
                if (this._briefCommentText == null)
                {
                    this._briefCommentText = clang.clang_Cursor_getBriefCommentText(this.m_value).ToStringAndDispose();
                }
                return this._briefCommentText;
            }
        }

        /// <summary>
        /// Defines the _rawCommentText
        /// </summary>
        private string _rawCommentText;

        /// <summary>
        /// Gets the RawCommentText
        /// </summary>
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

        /// <summary>
        /// Defines the _storageClass
        /// </summary>
        private CX_StorageClass _storageClass;

        /// <summary>
        /// Gets the StorageClass
        /// </summary>
        public CX_StorageClass StorageClass
        {
            get
            {
                this._storageClass = clang.clang_Cursor_getStorageClass(this.m_value);
                return this._storageClass;
            }
        }

        /// <summary>
        /// Defines the _languageKind
        /// </summary>
        private CXLanguageKind _languageKind;

        /// <summary>
        /// Gets the LanguageKind
        /// </summary>
        public CXLanguageKind LanguageKind
        {
            get
            {
                this._languageKind = clang.clang_getCursorLanguage(this.m_value);
                return this._languageKind;
            }
        }

        /// <summary>
        /// Defines the _visibility
        /// </summary>
        private CXVisibilityKind _visibility;

        /// <summary>
        /// Gets the Visibility
        /// </summary>
        public CXVisibilityKind Visibility
        {
            get
            {
                this._visibility = clang.clang_getCursorVisibility(this.m_value);
                return this._visibility;
            }
        }

        /// <summary>
        /// Defines the tlsKind
        /// </summary>
        private CXTLSKind tlsKind;

        /// <summary>
        /// Gets the TlsKind
        /// </summary>
        public CXTLSKind TlsKind
        {
            get
            {
                if (this.IsNull || this.CursorKind != CXCursorKind.CXCursor_VarDecl)
                {
                    return CXTLSKind.CXTLS_None;
                }
                this.tlsKind = clang.clang_getCursorTLSKind(this.m_value);
                return this.tlsKind;
            }
        }

        /// <summary>
        /// Defines the hasAttributes
        /// </summary>
        private bool hasAttributes;

        /// <summary>
        /// Gets a value indicating whether HasAttributes
        /// </summary>
        public bool HasAttributes
        {
            get
            {
                this.hasAttributes = clang.clang_Cursor_hasAttrs(this.m_value) > 0;
                return this.hasAttributes;
            }
        }

        /// <summary>
        /// Defines the isInvalidDeclaration
        /// </summary>
        private bool isInvalidDeclaration;

        /// <summary>
        /// Gets a value indicating whether IsInvalidDeclaration
        /// </summary>
        public bool IsInvalidDeclaration
        {
            get
            {
                this.isInvalidDeclaration = clang.clang_isInvalidDeclaration(this.m_value) > 0;
                return this.isInvalidDeclaration;
            }
        }

        /// <summary>
        /// Defines the _availability
        /// </summary>
        private CXAvailabilityKind _availability;

        /// <summary>
        /// Gets the Availability
        /// </summary>
        public CXAvailabilityKind Availability
        {
            get
            {
                this._availability = clang.clang_getCursorAvailability(this.m_value);
                return this._availability;
            }
        }

        /// <summary>
        /// Defines the _linkage
        /// </summary>
        private CXLinkageKind _linkage;

        /// <summary>
        /// Gets the Linkage
        /// </summary>
        public CXLinkageKind Linkage
        {
            get
            {
                this._linkage = clang.clang_getCursorLinkage(this.m_value);
                return this._linkage;
            }
        }

        /// <summary>
        /// Defines the _evalResult
        /// </summary>
        private EvalResult _evalResult;

        /// <summary>
        /// Gets the EvalResult
        /// </summary>
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
                    if (this.m_value.kind == CXCursorKind.CXCursor_CXXMethod)
                    {
                        CXType cxResultType = clang.clang_getCursorResultType(this.m_value);
                        this.resultType = new Type(cxResultType);
                    }
                }
                return this.resultType;
            }
        }

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value
        {
            get { return this.m_value; }
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        protected override void DisposeCore()
        {
            clang.clang_Cursor_Evaluate(this.m_value);
        }

        /// <summary>
        /// The EqualsCore
        /// </summary>
        /// <param name="clangObject">The clangObject<see cref="ClangObject"/></param>
        /// <returns>The <see cref="bool"/></returns>
        protected override bool EqualsCore(ClangObject clangObject)
        {
            return clang.clang_equalCursors(this.m_value, (CXCursor)clangObject.Value) > 0;
        }

        /// <summary>
        /// The ToString
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public override string ToString()
        {
            return string.Format("{0}{1}", this.DisplayName, this.SourceLocation);
        } 
    }
}
