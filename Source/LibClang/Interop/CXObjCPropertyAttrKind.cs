namespace LibClang.Intertop
{
    /**
          * Property attributes for a \c CXCursor_ObjCPropertyDecl.
          */
    public enum CXObjCPropertyAttrKind
    {
        /// <summary>
        /// Defines the CXObjCPropertyAttr_noattr
        /// </summary>
        CXObjCPropertyAttr_noattr = 0x00,
        /// <summary>
        /// Defines the CXObjCPropertyAttr_readonly
        /// </summary>
        CXObjCPropertyAttr_readonly = 0x01,
        /// <summary>
        /// Defines the CXObjCPropertyAttr_getter
        /// </summary>
        CXObjCPropertyAttr_getter = 0x02,
        /// <summary>
        /// Defines the CXObjCPropertyAttr_assign
        /// </summary>
        CXObjCPropertyAttr_assign = 0x04,
        /// <summary>
        /// Defines the CXObjCPropertyAttr_readwrite
        /// </summary>
        CXObjCPropertyAttr_readwrite = 0x08,
        /// <summary>
        /// Defines the CXObjCPropertyAttr_retain
        /// </summary>
        CXObjCPropertyAttr_retain = 0x10,
        /// <summary>
        /// Defines the CXObjCPropertyAttr_copy
        /// </summary>
        CXObjCPropertyAttr_copy = 0x20,
        /// <summary>
        /// Defines the CXObjCPropertyAttr_nonatomic
        /// </summary>
        CXObjCPropertyAttr_nonatomic = 0x40,
        /// <summary>
        /// Defines the CXObjCPropertyAttr_setter
        /// </summary>
        CXObjCPropertyAttr_setter = 0x80,
        /// <summary>
        /// Defines the CXObjCPropertyAttr_atomic
        /// </summary>
        CXObjCPropertyAttr_atomic = 0x100,
        /// <summary>
        /// Defines the CXObjCPropertyAttr_weak
        /// </summary>
        CXObjCPropertyAttr_weak = 0x200,
        /// <summary>
        /// Defines the CXObjCPropertyAttr_strong
        /// </summary>
        CXObjCPropertyAttr_strong = 0x400,
        /// <summary>
        /// Defines the CXObjCPropertyAttr__unretained
        /// </summary>
        CXObjCPropertyAttr__unretained = 0x800,
        /// <summary>
        /// Defines the CXObjCPropertyAttr_class
        /// </summary>
        CXObjCPropertyAttr_class = 0x1000
    }
}
