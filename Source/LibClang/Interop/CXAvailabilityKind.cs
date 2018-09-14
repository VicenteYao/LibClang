namespace LibClang.Intertop
{
    /**
         * Describes the availability of a particular entity, which indicates
         * whether the use of this entity will result in a warning or error due to
         * it being deprecated or unavailable.
         */
    public enum CXAvailabilityKind
    {
        /**
                         * The entity is available.
                         */
        CXAvailability_Available,
        /**
         * The entity is available, but has been deprecated (and its use is
         * not recommended).
         */
        CXAvailability_Deprecated,
        /**
         * The entity is not available; any use of it will be an error.
         */
        CXAvailability_NotAvailable,
        /**
         * The entity is available, but not accessible; any use of it will be
         * an error.
         */
        CXAvailability_NotAccessible
    }
}
