namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="IndexCXXClassDeclInfo" />
    /// </summary>
    public class IndexCXXClassDeclInfo : ClangObject
    {
        /// <summary>
        /// Defines the m_value
        /// </summary>
        private CXIdxCXXClassDeclInfo m_value;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexCXXClassDeclInfo"/> class.
        /// </summary>
        /// <param name="classDeclInfo">The classDeclInfo<see cref="CXIdxCXXClassDeclInfo"/></param>
        internal IndexCXXClassDeclInfo(CXIdxCXXClassDeclInfo classDeclInfo)
        {
            this.m_value = classDeclInfo;
        }

        /// <summary>
        /// Defines the declInfo
        /// </summary>
        private IndexDeclInfo declInfo;

        /// <summary>
        /// Gets the DeclInfo
        /// </summary>
        public unsafe IndexDeclInfo DeclInfo
        {
            get
            {
                if (this.declInfo == null)
                {
                    this.declInfo = new IndexDeclInfo(*this.m_value.declInfo);
                }
                return this.declInfo;
            }
        }

        /// <summary>
        /// Defines the bases
        /// </summary>
        private IndexDeclInfo[] bases;

        /// <summary>
        /// Gets the Bases
        /// </summary>
        public unsafe IndexDeclInfo[] Bases
        {
            get
            {
                if (this.bases == null)
                {
                    this.bases = new IndexDeclInfo[this.m_value.numBases];
                    for (uint i = 0; i < this.m_value.numBases; i++)
                    {
                        this.bases[i] = new IndexDeclInfo(this.m_value.bases[i]);
                    }
                }
                return this.bases;
            }
        }

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value
        {
            get { return this.m_value; }
        }
    }
}
