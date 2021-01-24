using System;

namespace FuncionalTest.Domain.Exceptions
{
    [Serializable]
    public class AccountException : Exception
    {
        public AccountException() { }

        public AccountException(string message)
            : base(message) { }              
    }
}
