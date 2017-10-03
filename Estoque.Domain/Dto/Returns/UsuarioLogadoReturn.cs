using Commom.Domain.App;
using Estoque.Domain.Entities;
using Estoque.Domain.Valids.Usuarios;
using System.Collections.Generic;

namespace Estoque.Domain.Dto.Returns
{
    //Só pode ser usado como retorno do Login devido a validação!
    public class UsuarioLogadoReturn : ACommandValidate
    {
        public string Id { get; set; }
        public string Nome { get; set; }

        //Ideal criptografar. Mas não neste momento
        public string Senha { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Permissao> Permissoes { get; set; }

        public UsuarioLogadoReturn(Usuario usuario)
        {
            this.Id = usuario.Id;
            this.Nome = usuario.Nome;
            this.Senha = usuario.Senha;
            this.Permissoes = usuario.Permissoes;
            this.Ativo = usuario.Ativo;
            this.ValidateAndThrow();
        }

        public override void AddValidattions()
        {
            this.AddValidation(UsuarioDeveEstarAtivoValid.Get(this.Ativo));
        }
    }
}
