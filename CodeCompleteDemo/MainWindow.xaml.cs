using LibClang;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibClang.Intertop;

namespace CodeCompleteDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this._sourceCodeName = @"D:\llvm\tools\clang\tools\driver\driver.cpp";
            this.code = System.IO.File.ReadAllText(this._sourceCodeName);
            this.CodeEditor.AppendText(code);

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
                    foreach (var item in this.translationUnit.DiagnosticSet)
                    {
                        Console.WriteLine(item.CategoryText);
                    }

                    this.translationUnit.Save(astFileName, CXSaveTranslationUnit_Flags.CXSaveTranslationUnit_None);
                }

                while (true)
                {

                    this.autoResetEvent.WaitOne();
                    var unsavedFile = new UnsavedFile[] { new UnsavedFile(this._sourceCodeName, this.code) };
                    this.translationUnit.Reparse(unsavedFile, LibClang.Intertop.CXReparse_Flags.CXReparse_None);

                    codeCompleteResults = this.translationUnit.CodeCompleteAt(this._sourceCodeName,
                         (uint)this.line,
                         (uint)this.column,
                    unsavedFile,
                Clang.DefaultCodeCompleteFlags|
  CXCodeComplete_Flags.CXCodeComplete_IncludeBriefComments
                         );
                    this.autoResetEvent.Reset();

                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        this.completions.Clear();

                        foreach (var item in codeCompleteResults.CompletionResults)
                        {
                            foreach (var chunk in item.Chunks.Where(x=>x.CompletionChunkKind== CXCompletionChunkKind.CXCompletionChunk_TypedText))
                            {
                                this.completions.Add(chunk.Text);
                                foreach (var cChunk in chunk.Chunks)
                                {
                                    this.completions.Add(cChunk.Text);
                                }
                            }

                        }
                    }));

                }

            });
            this.task.Start();
        }

        private string code;

        Task task;

        CodeCompleteResults codeCompleteResults;

        Index index = null;

        private TranslationUnit translationUnit;

        private AutoResetEvent autoResetEvent = new AutoResetEvent(false);

        private string _sourceCodeName;
        private uint line;
        private uint column;

        private ObservableCollection<string> completions;

        private void CodeEditor_TextInput(object sender, TextCompositionEventArgs e)
        {
           
        }

       

        private void CodeEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextRange textRange = new TextRange(this.CodeEditor.Document.ContentStart, this.CodeEditor.Document.ContentEnd);
            this.code = textRange.Text;
            if (this.translationUnit == null)
            {
                return;
            }

            if (this.completions == null)
            {
                this.completions = new ObservableCollection<string>();
                this.ListCodeCompletion.ItemsSource = this.completions;
            }

            this.completions.Clear();
            TextPointer caretLineStart = this.CodeEditor.CaretPosition.GetLineStartPosition(0);
            TextPointer p = this.CodeEditor.Document.ContentStart.GetLineStartPosition(0);
            int value = this.CodeEditor.CaretPosition.GetLineStartPosition(0).GetOffsetToPosition(this.CodeEditor.CaretPosition);
            this.column = (uint)value;
            this.line = 1;

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

        }

    }
}
