using Commom.Domain.ValidateReturns;

namespace Estoque.Domain.Valids.Usuarios
{
    public class UsuarioDeveEstarAtivoValid
    {
        public static ValidateReturn Get(bool ativo)
        {
            return new ValidateReturn { Message = "Usuário inativado!", Ok = ativo };
        }
    }
}
