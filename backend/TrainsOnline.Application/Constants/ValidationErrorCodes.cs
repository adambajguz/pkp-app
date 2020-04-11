namespace TrainsOnline.Application.Constants
{
    public static class ValidationErrorCodes
    {
        public static class Auth
        {
            public const string EmailOrPasswordIsIncorrect = "ERR_AU-01-01";
        }

        public static class Email
        {
            public const string IsEmpty = "ERR_EM-02-01";
            public const string HasWrongFormat = "ERR_EM-02-02";

            public const string IsInUse = "ERR_EM-02-03";
        }

        public static class Username
        {
            public const string IsEmpty = "ERR_UN-03-01";
            public const string IsTooShort = "ERR_UN-03-02";

            public const string IsInUse = "ERR_UN-03-04";
        }

        public static class Password
        {
            public const string IsEmpty = "ERR_PD-04-01";
            public const string IsTooShort = "ERR_PD-04-02";

            //public const string NewIsEqualToOld = "ERR_PD-04-03";
            public const string OldIsIncorrect = "ERR_PD-04-03";
        }

        public static class User
        {
            public const string IsVolumeNotWithinRange = "ERR_UR-05-01";
        }

        public static class Id
        {
            public const string IsIncorrectUser = "ERR_ID-06-01";
            public const string IsIncorrectGameSave = "ERR_ID-06-02";
        }

        public static class MapSeed
        {
            public const string IsMapSeedEmpty = "ERR_MS-07-01";
        }

        public static class Score
        {
            public const string IsPlayTimeEmpty = "ERR_SC-08-01";
        }

        public static class GameSave
        {
            public const string IsNameEmpty = "ERR_GS-09-01";
            public const string IsPlayTimeEmpty = "ERR_GS-09-02";
            public const string IsCompressionTypeInEnum = "ERR_GS-09-03";
            public const string IsSaveEmpty = "ERR_GS-09-04";
            public const string IsGameVersionEmpty = "ERR_GS-09-05";
            public const string IsHashEmpty = "ERR_GS-09-06";
        }
    }
}
