namespace Tools.Exceptions.Errors
{
    public enum ErrorCode
    {
        None = 0,

        //Common
        Validation,
        NotFound,
        GenereicServerError,

        //Auth
        AccessRights,
        AuthenticationFailed,

        //Tech
        ConfigurationMissing,
        DataSeeding,
        Storage,
        Export,
    }
}
