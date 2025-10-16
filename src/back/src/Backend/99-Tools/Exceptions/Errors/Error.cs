﻿namespace Tools.Exceptions.Errors
{
    public sealed record Error(
        ErrorCode Code,
        string Description,
        ErrorKind Kind,
        Dictionary<string, string> AdditionalData,
        Dictionary<string, string> Values
    )
    {
        public static readonly Error None = new Error(
            ErrorCode.None,
            string.Empty,
            ErrorKind.None,
            [],
            []
        );

        public static readonly Error ObfuscatedError =
            new(
                ErrorCode.GenereicServerError,
                "The server encountered an unexpected error.",
                ErrorKind.Technical,
                [],
                []
            );
    }
}
