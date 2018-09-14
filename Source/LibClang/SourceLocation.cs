using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class SourceLocation : ClangObject<CXSourceLocation>
    {

        static SourceLocation()
        {
            SourceLocation.Null = new SourceLocation(clang.clang_getNullLocation());
        }

        public static SourceLocation Null { get; private set; }

        internal SourceLocation(CXSourceLocation sourceLocation)
        {
            this.Value = sourceLocation;
        }

        private void EnsurenExpansionLocation()
        {
            if (this.expansionLocation == null)
            {
                IntPtr filePtr = IntPtr.Zero;
                uint line;
                uint column;
                uint offset;
                clang.clang_getExpansionLocation(this.Value, out filePtr, out line, out column, out offset);
                File file = new File(filePtr);
                this.expansionLocation = new ExpansionLocation(file, line, column, offset);
            }
        }

        protected override bool EqualsCore(ClangObject<CXSourceLocation> clangObject)
        {
            return clang.clang_equalLocations(this.Value, clangObject.Value) > 0;
        }

        private class ExpansionLocation
        {
            internal ExpansionLocation(File file, uint line, uint column, uint offset)
            {
                this.File = file;
                this.Line = line;
                this.Column = column;
                this.Offset = offset;
            }

            public File File;
            public uint Line;
            public uint Column;
            public uint Offset;
        }

        private ExpansionLocation expansionLocation;

        public File File
        {
            get
            {
                this.EnsurenExpansionLocation();
                return this.expansionLocation.File;
            }
        }
        public uint Column
        {
            get
            {
                this.EnsurenExpansionLocation();
                return this.expansionLocation.Column;
            }
        }
        public uint Line
        {
            get
            {
                this.EnsurenExpansionLocation();
                return this.expansionLocation.Line;
            }
        }
        public uint Offset
        {
            get
            {
                this.EnsurenExpansionLocation();
                return this.expansionLocation.Offset;
            }
        }



        private PresumedLocation presumedLocation;

        public PresumedLocation PresumedLocation
        {
            get
            {
                if (this.presumedLocation==null)
                {
                    this.EnsurePresumedLocation();
                }
                return this.presumedLocation;
            }
        }

        private void EnsurePresumedLocation()
        {
            if (this.presumedLocation == null)
            {
                CXString ptrFileName;
                uint column;
                uint line;
                clang.clang_getPresumedLocation(this.Value, out ptrFileName, out line, out column);
                this.presumedLocation = new  PresumedLocation(ptrFileName.ToStringAndDispose(), line, column);
            }
        }

        private bool? isFromMainFile;

        public bool IsFromMainFile
        {

            get
            {
                if (!this.isFromMainFile.HasValue)
                {
                    this.isFromMainFile = clang.clang_Location_isFromMainFile(this.Value) > 0;
                }
                return this.isFromMainFile.Value;
            }
        }


        private bool? isInSystemHeader;
        public bool IsInSystemHeader
        {
            get
            {
                if (!this.isInSystemHeader.HasValue)
                {
                    this.isInSystemHeader = clang.clang_Location_isInSystemHeader(this.Value) > 0;
                }
                return this.isInSystemHeader.Value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}:{1},{2}", this.File, this.Line, this.Column);
        }

    }
}
