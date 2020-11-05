using System.Diagnostics;

namespace ZPLForge.XmlSerialization.Helpers
{
    internal static class VersionProvider
    {
        private static string productVersion;
        internal static string ProductVersion => productVersion ?? (productVersion =
            FileVersionInfo.GetVersionInfo(typeof(VersionProvider).Assembly.Location)
                .ProductVersion);
    }
}
