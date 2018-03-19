
namespace DungeonsandDragons.Models
{
    //Global Variables
    public static class VersionGlobals
    {
        //major data version
        public const int VersionDataMajor = 1;
        //minor data version
        public const int VersionDataMinor = 1;

        //major code version
        public const int VersionCodeMajor = 1;
        //minor code version
        public const int VersionCodeMinor = 1;

        //fetch code version
        public static string GetCodeVersion()
        {
            return VersionCodeMajor + "." + VersionCodeMinor;
        }

        //fetch data version
        public static string GetDataVersion()
        {
            return VersionCodeMajor + "." + VersionCodeMinor;
        }

        //fetch code and data version
        public static string GetCombinedVersion()
        {
            return "Version: " + GetCodeVersion() + " Data: " + GetDataVersion();
        }
    }
}
