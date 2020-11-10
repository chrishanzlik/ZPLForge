using System.Diagnostics;

namespace ZPLForge.XmlSerialization
{
    internal static class VersionProvider
    {
        private static string productVersion;
        internal static string ProductVersion => productVersion ?? (productVersion =
            FileVersionInfo.GetVersionInfo(typeof(VersionProvider).Assembly.Location)
                .ProductVersion);
    }
}
