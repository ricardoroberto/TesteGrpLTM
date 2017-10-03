namespace Estoque.Domain.Dto.Commands.Usuarios
{
    public class UsuarioRegistroCommand
    {
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}
