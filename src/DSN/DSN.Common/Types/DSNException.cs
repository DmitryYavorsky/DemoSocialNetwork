using System;
using System.Collections.Generic;
using System.Text;

namespace DSN.Common.Types
{
    public class DSNException: Exception
    {
        public string Code { get; }

        public DSNException()
        {
            
        }

        public DSNException(string code)
        {
            Code = code;
        }
        public DSNException(string message, params object[] args)
            : this(string.Empty, message, args)
        {

        }

        public DSNException(string code, string message, params object[] args): this(null,code,message,args)
        {

        }

        public DSNException(Exception innerException, string message, params object[] args) : this(innerException,
            string.Empty, message, args)
        {

        }
        //Main constructor
        public DSNException(Exception innerException, string code, string message, params object[] args) : base(
            string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
