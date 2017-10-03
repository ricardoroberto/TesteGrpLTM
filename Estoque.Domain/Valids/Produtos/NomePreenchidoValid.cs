using Commom.Domain.ValidateReturns;
using System;

namespace Estoque.Domain.Valids.Produtos
{
    public class NomePreenchidoValid
    {
        public static ValidateReturn Get(string nomeProduto)
        {
            return new ValidateReturn { Message = "Nome do produto inválido", Ok = !String.IsNullOrEmpty(nomeProduto) };
        }
    }
}
