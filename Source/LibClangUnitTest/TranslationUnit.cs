using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibClang;
using System;

namespace LibClangUnitTest
{
    [TestClass]
    public class TranslationUnit
    {
        [TestMethod]
        public void TestMethod1()
        {
            Index index = new Index(true, true);

            string includes = @"-ID:\llvm\build\tools\clang\tools\driver 
-ID:\llvm\tools\clang\tools\driver 
-ID:\llvm\tools\clang\include
-ID:\llvm\build\tools\clang\include
-ID:\llvm\build\include 
-ID:\llvm\include";

            var splitedStringArrays = includes.Split(' ');

            string sourceFileName = @"D:\llvm\tools\clang\tools\driver\driver.cpp";

            var tu = index.Parse(sourceFileName,
               LibClang.Intertop.CXGlobalOptFlags.CXGlobalOpt_None, splitedStringArrays, null);
            tu.Reparse(null, LibClang.Intertop.CXReparse_Flags.CXReparse_None);

            var result = tu.CodeCompleteAt(sourceFileName, 106, 5, null, LibClang.Intertop.CXCodeComplete_Flags.CXCodeComplete_IncludeCodePatterns);
            foreach (var completionResult in result.CompletionResults)
            {
                foreach (var completionChunk in completionResult.CompletionChunks)
                {
                    Console.WriteLine(completionChunk.Text);
                }
            }

            var file = tu.GetFile(sourceFileName);
            var sourceRange = tu.GetSourceRange(file, 15, 1, 48, 42);

           var tokens = tu.Tokenize(sourceRange);

            foreach (var item in tokens)
            {
                Console.WriteLine(item.TokenKind);
                Console.WriteLine(item.Spelling);
                Console.WriteLine(item.SourceLocation);
                Console.WriteLine(item.SourceRange);
            }

            foreach (var item in tu.ResourceUsages)
            {
                Console.WriteLine("{0}:{1}", item.Name,item.Amount);
            }
            Console.WriteLine(tu.TargetInfo);

            foreach (var item in tu.GetAllSkippedRanges())
            {
                Console.WriteLine(item);
            }
        }
    }
}
