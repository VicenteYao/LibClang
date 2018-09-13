using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibClang;


namespace LibClangUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Index index = new Index(false, true);
            TranslationUnit translationUnit=   index.CreateTranslationUnit(@"D:\llvm\tools\clang\tools\driver\driver.cpp", null, null);

            var indexAction = index.CreateIndexAction(new IndexActionEventHandler());
            indexAction.Index(translationUnit, LibClang.Intertop.CXIndexOptFlags.CXIndexOpt_IndexFunctionLocalSymbols);
            var sourceRange = translationUnit.GetFile(translationUnit.Cursor.DisplayName);

            CodeCompleteResults codeCompleteResults=  translationUnit.CodeCompleteAt(@"D:\llvm\tools\clang\tools\driver\driver.cpp", 70, 10, null, LibClang.Intertop.CXCodeComplete_Flags.CXCodeComplete_IncludeCompletionsWithFixIts);

            foreach (var item in codeCompleteResults.CompletionResults)
            {
                foreach (var completionString in item.CompletionStrings)
                {
                    Assert.AreNotEqual(completionString, null);
                }
            }

            Assert.AreNotEqual(sourceRange, null);
            foreach (var item in translationUnit.Tokenize(translationUnit.GetSourceRange(sourceRange)))
            {
                Assert.AreNotEqual(item, null);
            }
        }
    }
}
