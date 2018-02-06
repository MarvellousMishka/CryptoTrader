using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAP_PowerMining.Core.Enums
{
    public enum UserDataResult
    {
        NameUpdated = 1,
        PasswordUpdated,
        OldPasswordWrong,
        NewPasswordsDifferent,
        NameAndPasswordUpdated,
        NameUpdatedPasswordFailed,
    }
}