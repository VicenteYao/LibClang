using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class Module : ClangObject<IntPtr>
    {
        internal Module(IntPtr value)
        {
            this.Value = value;
        }

        private string _name;
        public string Name
        {
            get
            {
                if (this._name == null)
                {
                    this._name = clang.clang_Module_getName(this.Value).ToStringAndDispose();
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
                    this._fullName = clang.clang_Module_getFullName(this.Value).ToStringAndDispose();
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
                    IntPtr file = clang.clang_Module_getASTFile(this.Value);
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
                    this._parent = new Module(clang.clang_Module_getParent(this.Value));
                }
                return this._parent;
            }
        }

        private bool? _isSystem;
        public bool IsSystem
        {
            get
            {
                if (!this._isSystem.HasValue)
                {
                    this._isSystem = clang.clang_Module_isSystem(this.Value) > 0;
                }
                return this._isSystem.Value;
            }
        }


        protected override void Dispose()
        {
        
        }

        protected override bool EqualsCore(ClangObject<IntPtr> clangObject)
        {
            return this.Value == clangObject.Value;
        }
    }
}
