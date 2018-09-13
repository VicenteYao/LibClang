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

        private void EnsurenInstantiationLocationInfo()
        {
            if (this.instantiationLocation == null)
            {
                IntPtr filePtr = IntPtr.Zero;
                uint line;
                uint column;
                uint offset;
                clang.clang_getInstantiationLocation(this.Value, out filePtr, out line, out column, out offset);
                File file = new File(filePtr);
                this.instantiationLocation = new InstantiationLocation(file, line, column, offset);
            }
        }

        protected override bool EqualsCore(ClangObject<CXSourceLocation> clangObject)
        {
            return clang.clang_equalLocations(this.Value, clangObject.Value) > 0;
        }

        private InstantiationLocation instantiationLocation;

        public InstantiationLocation InstantiationLocation
        {
            get
            {
                if (this.instantiationLocation==null)
                {
                    this.EnsurenInstantiationLocationInfo();
                }
                return this.instantiationLocation;
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
                this.presumedLocation = new PresumedLocation(ptrFileName.ToStringAndDispose(), line, column);
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
            return string.Format("{0}:{1},{2}", this.InstantiationLocation.File.FileName,this.PresumedLocation.Line,this.PresumedLocation.Column);
        }

    }
}
