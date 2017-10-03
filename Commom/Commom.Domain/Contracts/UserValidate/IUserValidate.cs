using System.Collections.Generic;

namespace Commom.Domain.Contracts.UserValidate
{
    public interface IUserValidate
    {
        bool ValidateUser(string username, string password);
        IList<string> GetRoles(string username);
        string GetName(string username);
    }
}
