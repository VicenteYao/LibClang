namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="Module" />
    /// </summary>
    public class Module : ClangObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Module"/> class.
        /// </summary>
        /// <param name="value">The value<see cref="IntPtr"/></param>
        internal Module(IntPtr value)
        {
            this.m_value = value;
        }

        /// <summary>
        /// Defines the _name
        /// </summary>
        private string _name;

        /// <summary>
        /// Gets the Name
        /// </summary>
        public string Name
        {
            get
            {
                if (this._name == null)
                {
                    this._name = clang.clang_Module_getName(this.m_value).ToStringAndDispose();
                }
                return this._name;
            }
        }

        /// <summary>
        /// Defines the _fullName
        /// </summary>
        private string _fullName;

        /// <summary>
        /// Gets the FullName
        /// </summary>
        public string FullName
        {
            get
            {
                if (this._fullName == null)
                {
                    this._fullName = clang.clang_Module_getFullName(this.m_value).ToStringAndDispose();
                }
                return this._fullName;
            }
        }

        /// <summary>
        /// Defines the _Astfile
        /// </summary>
        private File _Astfile;

        /// <summary>
        /// Gets the AstFile
        /// </summary>
        public File AstFile
        {
            get
            {
                if (this._Astfile == null)
                {
                    IntPtr file = clang.clang_Module_getASTFile(this.m_value);
                    if (file != IntPtr.Zero)
                    {
                        this._Astfile = new File(file);
                    }
                }
                return this._Astfile;
            }
        }

        /// <summary>
        /// Defines the _parent
        /// </summary>
        private Module _parent;

        /// <summary>
        /// Gets the Parent
        /// </summary>
        public Module Parent
        {
            get
            {
                if (this._parent == null)
                {
                    this._parent = new Module(clang.clang_Module_getParent(this.m_value));
                }
                return this._parent;
            }
        }

        /// <summary>
        /// Defines the _isSystem
        /// </summary>
        private bool? _isSystem;

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private IntPtr m_value;

        /// <summary>
        /// Gets a value indicating whether IsSystem
        /// </summary>
        public bool IsSystem
        {
            get
            {
                if (!this._isSystem.HasValue)
                {
                    this._isSystem = clang.clang_Module_isSystem(this.m_value) > 0;
                }
                return this._isSystem.Value;
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
        protected override void Dispose()
        {
        }
    }
}
