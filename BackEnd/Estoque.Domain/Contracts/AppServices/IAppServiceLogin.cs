using Estoque.Domain.Dto.Commands.Usuarios;
using Estoque.Domain.Dto.Returns;

namespace Estoque.Domain.Contracts.AppServices
{
    public interface IAppServiceLogin
    {
        UsuarioLogadoReturn Login(UsuarioLoginCommand login);
        void Registrar(UsuarioRegistroCommand registro);
    }
}
