using System.Collections.Generic;
using System.Linq;

namespace Commom.Domain.ValidateReturns
{
    public class Validations
    {
        public List<ValidateReturn> Itens { get; set; }

        public void Add(ValidateReturn item)
        {
            if (Itens == null) Itens = new List<ValidateReturn>();
            Itens.Add(item);
        }

        public bool Any(System.Func<ValidateReturn, bool> expression) => (Itens != null ? Itens.Any(expression) : false);

        public ValidateReturn First(System.Func<ValidateReturn, bool> expression) => (Itens != null ? Itens.First(expression) : null);

        public int Count
        {
            get
            {
                return Itens !=null ? Itens.Count : 0;
            }
        }

        public string Message
        {
            get
            {
                if (!this.Ok) return null;
                return string.Join("\n", Itens.Where(s => !s.Ok).Select(s => s.Message));
            }
        }

        public bool Ok
        {
            get
            {
                return Itens.Select(s => s.Ok).Any(s => !s);

            }
        }
    }
}
