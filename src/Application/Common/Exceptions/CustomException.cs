﻿using Defender.Common.Errors;
using Defender.Common.Exceptions;

namespace Defender.BudgetTracker.Application.Common.Exceptions;

public class CustomException : ServiceException
{
    public CustomException()
        : base(ErrorCodeHelper.GetErrorCode(ErrorCode.UnhandledError))
    {
    }
}
