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

        private class LocationInfo
        {
            public File File;
            public uint Column;
            public uint Line;
            public uint Offset;
        }

        private void EnsureLocationInfo()
        {
            if (this.locationInfo == null)
            {
                this.locationInfo = new LocationInfo();
                IntPtr filePtr = IntPtr.Zero;
                uint line;
                uint column;
                uint offset;
                clang.clang_getInstantiationLocation(this.Value, out filePtr, out line, out column, out offset);
                this.locationInfo.Line = line;
                this.locationInfo.Column = column;
                this.locationInfo.Offset = offset;
            }
        }

        protected override bool EqualsCore(ClangObject<CXSourceLocation> clangObject)
        {
            return clang.clang_equalLocations(this.Value, clangObject.Value) > 0;
        }

        private LocationInfo locationInfo;

        public uint Column
        {
            get
            {
                this.EnsureLocationInfo();
                return locationInfo.Column;
            }
        }

        public uint Line
        {
            get
            {
                this.EnsureLocationInfo();
                return locationInfo.Line;
            }
        }

        public uint Offset
        {
            get
            {
                this.EnsureLocationInfo();
                return locationInfo.Offset;
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
            return string.Format("{0},{1}", this.Line, this.Column);
        }

    }
}
