using Commom.Domain.App;
using Estoque.Domain.Valids.Usuarios;

namespace Estoque.Domain.Dto.Commands.Usuarios
{
    public class UsuarioLoginCommand : ACommandValidate
    {
        public string IdEmpresa { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }

        public override void AddValidattions()
        {
            this.AddValidation(LoginUsuarioValid.Get(Usuario));
            this.AddValidation(SenhaUsuarioValid.Get(Senha));
        }
    }
}
