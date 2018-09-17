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
            string includes = @"-ID:\llvm\build\tools\clang\tools\driver -ID:\llvm\tools\clang\tools\driver -ID:\llvm\tools\clang\include -ID:\llvm\build\tools\clang\include -ID:\llvm\build\include -ID:\llvm\include";
            var splitedStringArrays = includes.Split(' ');

            //indexAction.Index(tu, LibClang.Intertop.CXIndexOptFlags.CXIndexOpt_IndexFunctionLocalSymbols);

            this.task = new Task(() =>
            {
                this.index = new Index(true, true);
                this.index.GlobalOptFlags = LibClang.Intertop.CXGlobalOptFlags.CXGlobalOpt_ThreadBackgroundPriorityForEditing;
                CXErrorCode xErrorCode = CXErrorCode.CXError_Success;
                this.translationUnit = index.Parse(this._sourceCodeName, splitedStringArrays, null, LibClang.Intertop.CXTranslationUnit_Flags.CXTranslationUnit_CacheCompletionResults|
                    CXTranslationUnit_Flags.CXTranslationUnit_DetailedPreprocessingRecord| CXTranslationUnit_Flags.CXTranslationUnit_SingleFileParse, out xErrorCode);

                while (true)
                {

                    this.autoResetEvent.WaitOne();
                    //this.translationUnit.Reparse(new UnsavedFile[] { new UnsavedFile(this._sourceCodeName, this.code) }, LibClang.Intertop.CXReparse_Flags.CXReparse_None);

                    codeCompleteResults = this.translationUnit.CodeCompleteAt(this._sourceCodeName,
                         (uint)this.line,
                         (uint)this.column,
                        new UnsavedFile[] { new UnsavedFile(this._sourceCodeName, this.code) },
                         LibClang.Intertop.CXCodeComplete_Flags.CXCodeComplete_IncludeCodePatterns);
                    this.autoResetEvent.Reset();

                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        this.completions.Clear();

                        foreach (var item in codeCompleteResults.CompletionResults)
                        {
                            foreach (var chunk in item.CompletionChunks)
                            {
                                this.completions.Add(chunk.Text);
                            }
                        }
                        this.CodeEditor.ContextMenu.IsOpen = true;
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
            if (this.translationUnit == null)
            {
                return;
            }

            if (this.completions == null)
            {
                this.CodeEditor.ContextMenu = new ContextMenu();
                this.completions = new ObservableCollection<string>();
                this.CodeEditor.ContextMenu.ItemsSource = this.completions;

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
