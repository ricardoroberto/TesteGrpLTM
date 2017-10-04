using Commom.Domain.ValidateReturns;

namespace Commom.Domain.Contracts.Validate
{
    public interface IValidateCommand
    {
        void AddValidattions();
        void AddValidation(ValidateReturn validation);
        string ValidateWithMessages();
        void Validate();
    }
}
