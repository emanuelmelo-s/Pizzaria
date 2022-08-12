using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaria.Models
{
    public class Tamanho : IEntidade
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }

        public string Nome { get; set; }

        #region relacionamento
        public List<Pizza> Pizzas { get; set; }
        #endregion
    }
}
