using System;

namespace Commom.Domain.ValidateReturns
{
    public class ValidateReturn
    {
        public ValidateReturn()
        {
            this.Ok = true;
            this.Message = "";
            this.CustomException = null;
        }

        public Exception CustomException { get; set; }
        public string Message { get; set; }
        public bool Ok { get; set; }
    }
}
