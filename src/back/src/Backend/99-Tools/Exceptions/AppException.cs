﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Exceptions.Errors;

namespace Tools.Exceptions
{
    public class AppException : Exception
    {
        public ErrorCode Code { get; }
        public ErrorKind Kind { get; }
        public Dictionary<string, string> AdditionalData { get; protected set; }
        public Dictionary<string, string> Values { get; protected set; }

        public AppException(
            ErrorCode code,
            ErrorKind kind,
            string? message,
            Dictionary<string, string>? additionalData = null,
            Dictionary<string, string>? values = null
        )
            : base(message)
        {
            Code = code;
            Kind = kind;
            AdditionalData = additionalData ?? [];
            Values = values ?? [];
        }

        protected AppException(
            ErrorCode code,
            ErrorKind kind,
            string? message,
            Exception? innerException,
            Dictionary<string, string>? additionalData = null,
            Dictionary<string, string>? values = null
        )
            : base(message, innerException)
        {
            Code = code;
            Kind = kind;
            AdditionalData = additionalData ?? [];
            Values = values ?? [];
        }

        public Error ToError() => new(Code, Message, Kind, AdditionalData, Values);

        public void UpdateAdditionalData(Dictionary<string, string> additionalData)
        {
            this.AdditionalData = additionalData;
        }
    }
}
