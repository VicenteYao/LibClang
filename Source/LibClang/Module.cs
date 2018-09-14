using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class Module : ClangObject
    {
        internal Module(IntPtr value)
        {
            this.m_value = value;
        }

        private string _name;
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

        private string _fullName;
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

        private File _Astfile;
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


        private Module _parent;
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

        private bool? _isSystem;
        private IntPtr m_value;

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

        protected internal override ValueType Value { get { return this.m_value; } }

        protected override void Dispose()
        {
        
        }

    }
}
