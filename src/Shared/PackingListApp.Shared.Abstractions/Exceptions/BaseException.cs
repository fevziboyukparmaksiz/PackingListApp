﻿namespace PackingListApp.Shared.Abstractions.Exceptions;
public abstract class BaseException : Exception
{
    protected BaseException(string message) : base(message)
    {
        
    }
}
