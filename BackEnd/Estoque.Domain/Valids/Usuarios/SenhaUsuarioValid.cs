using Commom.Domain.ValidateReturns;

namespace Estoque.Domain.Valids.Usuarios
{
    public class SenhaUsuarioValid
    {
        public static ValidateReturn Get(string senha)
        {
            return new ValidateReturn { Message = "Senha vazia! Preencha a senha corretamente", Ok = !string.IsNullOrEmpty(senha) };
        }
    }
}
