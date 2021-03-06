﻿using LibClang;
using LibClang.Intertop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace CodeCompleteDemo
{
    public class CodeEditor:RichTextBox
    {
        public CodeEditor()
        {
            this._sourceCodeName = @"D:\llvm\tools\clang\tools\driver\driver.cpp";
            this.code = System.IO.File.ReadAllText(this._sourceCodeName);
            this.AppendText(code);

            //var indexAction = index.CreateIndexAction(new IndexActionEventHandler());
            string includes = @"-ID:\llvm\build\tools\clang\tools\driver -ID:\llvm\tools\clang\tools\driver -ID:\llvm\tools\clang\include -ID:\llvm\build\tools\clang\include -ID:\llvm\build\include -ID:\llvm\include -emit-ast";
            var splitedStringArrays = includes.Split(' ');
            string astFileName = "d:\test.ast";
            //indexAction.Index(tu, LibClang.Intertop.CXIndexOptFlags.CXIndexOpt_IndexFunctionLocalSymbols);

            this.task = new Task(() =>
            {
                this.index = new Index(true, true);
                this.index.GlobalOptFlags = LibClang.Intertop.CXGlobalOptFlags.CXGlobalOpt_ThreadBackgroundPriorityForEditing;
                CXErrorCode xErrorCode = CXErrorCode.CXError_Success;
                if (System.IO.File.Exists(astFileName))
                {
                    this.translationUnit = index.CreateTranslationUnit(astFileName);
                }
                else
                {
                    this.translationUnit = index.Parse(this._sourceCodeName, splitedStringArrays, null,
CXTranslationUnit_Flags.CXTranslationUnit_DetailedPreprocessingRecord |
CXTranslationUnit_Flags.CXTranslationUnit_Incomplete |
CXTranslationUnit_Flags.CXTranslationUnit_IncludeBriefCommentsInCodeCompletion |
CXTranslationUnit_Flags.CXTranslationUnit_CreatePreambleOnFirstParse |
CXTranslationUnit_Flags.CXTranslationUnit_KeepGoing |
Clang.DefaultEditingTranslationUnitOptions

,
    out xErrorCode);

                    this.translationUnit.Save(astFileName, CXSaveTranslationUnit_Flags.CXSaveTranslationUnit_None);
                }

                while (true)
                {

                    this.autoResetEvent.WaitOne();
                    var unsavedFile = new UnsavedFile[] { new UnsavedFile(this._sourceCodeName, this.code) };
                    this.translationUnit.Reparse(unsavedFile, LibClang.Intertop.CXReparse_Flags.CXReparse_None);
                    CodeCompleteResults codeCompleteResults = this.translationUnit.CodeCompleteAt(this._sourceCodeName,
                                             (uint)this.line,
                                             (uint)this.column,
                                        unsavedFile,
                                    Clang.DefaultCodeCompleteFlags |
                      CXCodeComplete_Flags.CXCodeComplete_IncludeBriefComments |
                      CXCodeComplete_Flags.CXCodeComplete_IncludeCodePatterns |
                      CXCodeComplete_Flags.CXCodeComplete_IncludeCompletionsWithFixIts
                                             );
                    codeCompleteResults.Sort();
                    this.autoResetEvent.Reset();

                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        this.completions.Clear();
                        foreach (var item in codeCompleteResults.CompletionResults)
                        {

                            foreach (var chunk in item.Chunks)
                            {
                                this.completions.Add(chunk.CompletionChunkKind + ":" + chunk.Text);
                                foreach (var cChunk in chunk.Chunks)
                                {
                                    this.completions.Add(cChunk.Text);
                                }
                            }
                            this.completions.Add("-------------------------------------------------------------------------");

                        }
                    }));
                }

            });
            this.task.Start();
        }

        private string code;

        Task task;

        Index index = null;

        private TranslationUnit translationUnit;

        private AutoResetEvent autoResetEvent = new AutoResetEvent(false);

        private string _sourceCodeName;
        private uint line;
        private uint column;

        private ObservableCollection<string> completions;
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            if (this.completions == null)
            {
                this.completions = new ObservableCollection<string>();
            }
            var textRange = new TextRange(this.Document.ContentStart, this.Document.ContentEnd);
            this.code = textRange.Text;
            TextPointer caretLineStart = this.CaretPosition.GetLineStartPosition(0);
            TextPointer p = this.Document.ContentStart.GetLineStartPosition(0);
            int value = this.CaretPosition.GetLineStartPosition(0).GetOffsetToPosition(this.CaretPosition);
            this.column = (uint)value;
            this.line = 0;

            while (true)
            {
                if (caretLineStart.CompareTo(p) < 0)
                {
                    break;
                }
                int result;
                p = p.GetLineStartPosition(1, out result);
                if (result == 0)
                {
                    break;
                }
                this.line++;
            }
            this.autoResetEvent.Set();
            base.OnTextChanged(e);
        }
    }
}
