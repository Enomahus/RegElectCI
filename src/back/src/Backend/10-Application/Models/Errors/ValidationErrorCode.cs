using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Errors
{
    public enum ValidationErrorCode
    {
        Required = 0,
        MinLength,
        MaxLength,
        Unique,
        PositiveNumber,
        InvalidEmail,
        UserMustExist
    }
}
