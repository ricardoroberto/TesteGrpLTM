using Commom.Domain.Contracts.UserValidate;
using Estoque.Domain.Contracts.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Estoque.Service
{
    public class UserServiceValidate : IUserValidate
    {
        private readonly IRepositoryUsuario _repUsuario;

        public UserServiceValidate(IRepositoryUsuario repUsuario)
        {
            this._repUsuario = repUsuario;
        }

        public string GetName(string username)
        {
            string name = null;
            var usr = _repUsuario.GetById(username);
            if (usr != null) name = usr.Nome;
            return name;
        }

        public IList<string> GetRoles(string username)
        {
            IList<string> permissoes = null;
            var usr = _repUsuario.GetById(username);
            if (usr != null && usr.Permissoes != null) permissoes = usr.Permissoes.Select(s => s.NomePermissao).ToList();
            return permissoes;
        }

        public bool ValidateUser(string username, string password)
        {
            var usr = _repUsuario.GetByLogin(username, password);
            return usr != null;
        }
    }
}
