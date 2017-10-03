﻿using Estoque.Domain.Contracts.AppServices;
using Estoque.Domain.Contracts.Repositories;
using Estoque.Domain.Dto.Commands.Usuarios;
using Estoque.Domain.Dto.Returns;
using System;

namespace Estoque.Service
{
    public class AppServiceLogin : IAppServiceLogin
    {
        private readonly IRepositoryUsuario _repUsuario;

        public AppServiceLogin(IRepositoryUsuario repUsuario)
        {
            this._repUsuario = repUsuario;
        }

        public UsuarioLogadoReturn Login(UsuarioLoginCommand login)
        {
            UsuarioLogadoReturn ret = null;
            login.ValidateAndThrow();

            var usr = _repUsuario.GetByLogin(login.Usuario, login.Senha);
            if (usr != null)
                ret = new UsuarioLogadoReturn(usr);

            return ret;
        }

        public void Registrar(UsuarioRegistroCommand registro)
        {
            throw new NotImplementedException();
        }
    }
}
