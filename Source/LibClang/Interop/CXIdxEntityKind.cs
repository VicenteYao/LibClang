namespace LibClang.Intertop
{
    /// <summary>
    /// Defines the CXIdxEntityKind
    /// </summary>
    public enum CXIdxEntityKind
    {
        /// <summary>
        /// Defines the CXIdxEntity_Unexposed
        /// </summary>
        CXIdxEntity_Unexposed = 0,
        /// <summary>
        /// Defines the CXIdxEntity_Typedef
        /// </summary>
        CXIdxEntity_Typedef = 1,
        /// <summary>
        /// Defines the CXIdxEntity_Function
        /// </summary>
        CXIdxEntity_Function = 2,
        /// <summary>
        /// Defines the CXIdxEntity_Variable
        /// </summary>
        CXIdxEntity_Variable = 3,
        /// <summary>
        /// Defines the CXIdxEntity_Field
        /// </summary>
        CXIdxEntity_Field = 4,
        /// <summary>
        /// Defines the CXIdxEntity_EnumConstant
        /// </summary>
        CXIdxEntity_EnumConstant = 5,
        /// <summary>
        /// Defines the CXIdxEntity_ObjCClass
        /// </summary>
        CXIdxEntity_ObjCClass = 6,
        /// <summary>
        /// Defines the CXIdxEntity_ObjCProtocol
        /// </summary>
        CXIdxEntity_ObjCProtocol = 7,
        /// <summary>
        /// Defines the CXIdxEntity_ObjCCategory
        /// </summary>
        CXIdxEntity_ObjCCategory = 8,
        /// <summary>
        /// Defines the CXIdxEntity_ObjCInstanceMethod
        /// </summary>
        CXIdxEntity_ObjCInstanceMethod = 9,
        /// <summary>
        /// Defines the CXIdxEntity_ObjCClassMethod
        /// </summary>
        CXIdxEntity_ObjCClassMethod = 10,
        /// <summary>
        /// Defines the CXIdxEntity_ObjCProperty
        /// </summary>
        CXIdxEntity_ObjCProperty = 11,
        /// <summary>
        /// Defines the CXIdxEntity_ObjCIvar
        /// </summary>
        CXIdxEntity_ObjCIvar = 12,
        /// <summary>
        /// Defines the CXIdxEntity_Enum
        /// </summary>
        CXIdxEntity_Enum = 13,
        /// <summary>
        /// Defines the CXIdxEntity_Struct
        /// </summary>
        CXIdxEntity_Struct = 14,
        /// <summary>
        /// Defines the CXIdxEntity_Union
        /// </summary>
        CXIdxEntity_Union = 15,
        /// <summary>
        /// Defines the CXIdxEntity_CXXClass
        /// </summary>
        CXIdxEntity_CXXClass = 16,
        /// <summary>
        /// Defines the CXIdxEntity_CXXNamespace
        /// </summary>
        CXIdxEntity_CXXNamespace = 17,
        /// <summary>
        /// Defines the CXIdxEntity_CXXNamespaceAlias
        /// </summary>
        CXIdxEntity_CXXNamespaceAlias = 18,
        /// <summary>
        /// Defines the CXIdxEntity_CXXStaticVariable
        /// </summary>
        CXIdxEntity_CXXStaticVariable = 19,
        /// <summary>
        /// Defines the CXIdxEntity_CXXStaticMethod
        /// </summary>
        CXIdxEntity_CXXStaticMethod = 20,
        /// <summary>
        /// Defines the CXIdxEntity_CXXInstanceMethod
        /// </summary>
        CXIdxEntity_CXXInstanceMethod = 21,
        /// <summary>
        /// Defines the CXIdxEntity_CXXConstructor
        /// </summary>
        CXIdxEntity_CXXConstructor = 22,
        /// <summary>
        /// Defines the CXIdxEntity_CXXDestructor
        /// </summary>
        CXIdxEntity_CXXDestructor = 23,
        /// <summary>
        /// Defines the CXIdxEntity_CXXConversionFunction
        /// </summary>
        CXIdxEntity_CXXConversionFunction = 24,
        /// <summary>
        /// Defines the CXIdxEntity_CXXTypeAlias
        /// </summary>
        CXIdxEntity_CXXTypeAlias = 25,
        /// <summary>
        /// Defines the CXIdxEntity_CXXInterface
        /// </summary>
        CXIdxEntity_CXXInterface = 26
    }
}
