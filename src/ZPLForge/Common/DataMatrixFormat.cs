namespace ZPLForge.Common
{
    public enum DataMatrixFormat
    {
        Numeric = 1, // field data is numeric + space (0..9,”) – No \&’’
        UppercaseAlphanumericPlusSpaceNoAnd = 2, // field data is uppercase alphanumeric + space (A..Z,’’) – No \&’’
        UppercaseAlphanumericPlusSpacePeriodCommaDashSlash = 3,  // field data is uppercase alphanumeric + space, period, comma, dash, and slash (0..9, A..Z,“.-/”)
        UppercaseAlphanumericPlusSpace = 4, //field data is upper-case alphanumeric + space (0..9,A..Z,’’) – no \&’’
        ASCIII128 = 5, // field data is full 128 ASCII 7-bit set
        ISO256 = 6 // field data is full 256 ISO 8-bit set
    }
}
