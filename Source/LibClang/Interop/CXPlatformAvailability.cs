using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    /**
           * Describes the availability of a given entity on a particular platform, e.g.,
           * a particular class might only be available on Mac OS 10.7 or newer.
           */
    public struct CXPlatformAvailability
    {
        /**
         * A string that describes the platform for which this structure
         * provides availability information.
         *
         * Possible values are "ios" or "macos".
         */
       public  CXString Platform;
        /**
         * The version number in which this entity was introduced.
         */
        public CXVersion Introduced;
        /**
         * The version number in which this entity was deprecated (but is
         * still available).
         */
        public CXVersion Deprecated;
        /**
         * The version number in which this entity was obsoleted, and therefore
         * is no longer available.
         */
        public CXVersion Obsoleted;
        /**
         * Whether the entity is unconditionally unavailable on this platform.
         */
        public int Unavailable;
        /**
         * An optional message to provide to a user of this API, e.g., to
         * suggest replacement APIs.
         */
        public CXString Message;
    }
}
