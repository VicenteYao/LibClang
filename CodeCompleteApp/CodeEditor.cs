using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using LibClang;
using System.Threading;

namespace CodeCompleteApp
{
    public class CodeEditor :RichTextBox
    {
        public CodeEditor()
        {
            this.SnapsToDevicePixels = true;
            this.FontSize = 12;
            this.typeface = this.FontFamily.GetTypefaces().FirstOrDefault(x => x.Style == FontStyles.Normal);
        }


        public void SetFileName(string fileName)
        {
            this.line = 1;
            this.fileName = fileName;
            this.index = new Index(false, false);
            this.translationUnit = this.index.CreateTranslationUnit(this.fileName, null, null);
            this.sourceCode = System.IO.File.ReadAllText(fileName);
            this.file = this.translationUnit.GetFile(fileName);
            this.tokens= this.translationUnit.Tokenize(this.translationUnit.GetSourceRange(this.file));
            this.AppendText(this.sourceCode);
            this.InvalidateVisual();
        }

        private string sourceCode;

        private Typeface typeface;
        private Index index;
        private TranslationUnit translationUnit;
        private string fileName;

        public string FileName { get { return this.fileName; } set { this.SetFileName(value); } }

        File file;

        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            tokens = this.translationUnit.Tokenize(this.translationUnit.GetSourceRange(this.file));
            this.InvalidateVisual();
            base.OnPreviewTextInput(e);
        }


        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            tokens = this.translationUnit.Tokenize(this.translationUnit.GetSourceRange(this.file));
            this.InvalidateVisual();
            base.OnPreviewKeyDown(e);
        }

        private TokenList tokens;


        private int line;
        protected override void OnPreviewMouseWheel(MouseWheelEventArgs e)
        {
            if (e.Delta>0)
            {
                this.line-=3;
            }
            else
            {
                this.line+=3;

            }
            if (this.line<0)
            {
                this.line = 1;
            }
            this.InvalidateVisual();
            base.OnPreviewMouseWheel(e);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (this.tokens != null)
            {
                double y = 0;
                double x = 0;
                uint lastLine = 0;
                uint lineColumn = 0;
                foreach (var item in tokens)
                {
                    if (item.SourceLocation.InstantiationLocation.Line < this.line)
                    {
                        continue;
                    }
                    Brush brush = Brushes.Black;

                    switch (item.TokenKind)
                    {
                        case LibClang.Intertop.CXTokenKind.CXToken_Punctuation:
                            brush = Brushes.DodgerBlue;
                            break;
                        case LibClang.Intertop.CXTokenKind.CXToken_Keyword:
                            brush = Brushes.Blue;
                            break;
                        case LibClang.Intertop.CXTokenKind.CXToken_Identifier:
                            brush = Brushes.Black;
                            break;
                        case LibClang.Intertop.CXTokenKind.CXToken_Literal:
                            brush = Brushes.Red;
                            break;
                        case LibClang.Intertop.CXTokenKind.CXToken_Comment:
                            brush = Brushes.Green;
                            break;
                        default:
                            break;
                    }
                    FormattedText formattedText = new FormattedText(item.Spelling,
        Thread.CurrentThread.CurrentCulture,
        FlowDirection.LeftToRight,
        this.typeface,
        this.FontSize,
        brush);
                    InstantiationLocation instantiationLocation = item.SourceLocation.InstantiationLocation;
                    if (instantiationLocation.Line != lastLine)
                    {
                        y += formattedText.Height;
                        if (y > this.ActualHeight)
                        {
                            break;
                        }
                        if (item.Spelling == "using")
                        {

                        }
                        lastLine = instantiationLocation.Line;
                        lineColumn = instantiationLocation.Column;
                        x = 0;
                    }
                    StringBuilder stringBuilder = new StringBuilder();
                    if (instantiationLocation.Column > 1)
                    {
                        uint offset = 0;
                        while (true)
                        {
                            offset++;
                            char ch = this.sourceCode.ElementAtOrDefault((int)(instantiationLocation.Offset - offset));
                            if (ch == '\t' ||
                            ch == ' ')
                            {
                                stringBuilder.Append("_");

                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    if (stringBuilder.Length > 0)
                    {
                        FormattedText formattedWhiteSpaceText = new FormattedText(stringBuilder.ToString(),
Thread.CurrentThread.CurrentCulture,
FlowDirection.LeftToRight,
this.typeface,
this.FontSize,
brush);
                        x += formattedWhiteSpaceText.Width;
                    }

                    drawingContext.DrawText(formattedText, new Point(x, y));
                    x += formattedText.Width;



                }
            }

            base.OnRender(drawingContext);
        }

    }
}
