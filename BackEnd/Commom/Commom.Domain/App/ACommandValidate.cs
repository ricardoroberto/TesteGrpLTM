using Commom.Domain.Contracts.Validate;
using Commom.Domain.ValidateReturns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Commom.Domain.App
{
    public abstract class ACommandValidate : IValidateCommand
    {
        protected object command = null;
        protected Validations dations = new Validations();
        string message = "";

        public bool Ok
        {
            get
            {
                return dations.Ok;
            }
        }

        public List<ValidateReturn> Itens
        {
            get
            {
                return dations.Itens;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }
        }

        public virtual void AddValidation(ValidateReturn validation)
        {
            dations.Add(validation);
        }

        public abstract void AddValidattions();

        public string ValidateWithMessages()
        {
            AddValidattions();

            var message = "";
            if (dations.Count > 0) message = dations.Message;
            return message;
        }

        public void Validate()
        {
            AddValidattions();

            if (dations.Count > 0) message = dations.Message;
        }

        public void ValidateAndThrow()
        {
            AddValidattions();

            if (dations.Count > 0) message = dations.Message;

            if (!String.IsNullOrEmpty(message))
            {
                if (dations.Any(a => a.CustomException != null && !a.Ok))
                {
                    var err = dations.First(a => a.CustomException != null && !a.Ok);
                    throw err.CustomException;
                }
                else
                {
                    throw new ValidationException(message);
                }
            }
        }
    }
}
