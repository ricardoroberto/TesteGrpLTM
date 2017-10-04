using Commom.Domain.ValidateReturns;
using System;

namespace Estoque.Domain.Valids.Usuarios
{
    public class LoginUsuarioValid
    {
        public static ValidateReturn Get(string usuario)
        {
            return new ValidateReturn { Message = "Usuario inválido! Não coloque espaços!", Ok = !String.IsNullOrEmpty(usuario) && !usuario.Contains(" ") };
        }
    }
}
