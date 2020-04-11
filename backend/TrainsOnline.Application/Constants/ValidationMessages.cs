namespace TrainsOnline.Application.Constants
{
    public static class ValidationMessages
    {
        public static class Auth
        {
            public const string EmailOrPasswordIsIncorrect = "e-mail or password is incorrect";
        }

        public static class Email
        {
            public const string IsEmpty = "e-mail must not be empty";
            public const string HasWrongFormat = "e-mail must have a valid format";

            public const string IsInUse = "e-mail is already in use";
        }

        public static class Username
        {
            public const string IsEmpty = "Username must not be empty";
            public const string IsTooShort = "Username must have at least {0} characters";

            public const string IsInUse = "Username is already in use";
        }

        public static class Password
        {
            public const string IsEmpty = "Password must not be empty";
            public const string IsTooShort = "Password must have at least {0} characters";

            //public const string NewIsEqualToOld = "New password must not equal to old password";
            public const string OldIsIncorrect = "Old password is incorrect";
        }

        public static class User
        {
            public const string IsVolumeNotWithinRange = "Volume is not within [0, 1]";
        }

        public static class Id
        {
            public const string IsIncorrectUser = "Id of User is incorrect";
            public const string IsIncorrectGameSave = "Id of GameSave is incorrect";
        }
    }
}
