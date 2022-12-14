using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaria.Models
{
    public abstract class Sabor : IEntidade
    {
        public Sabor(string nome, string fotoURL)
        {
            Nome = nome;
            FotoURL = fotoURL;
        }


        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }

        public string Nome { get; set; }
        public string FotoURL { get; set; }

        #region relacionamento
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }

        public List<PizzaSabor> PizzasSabores { get; set; }
        #endregion


    }
}
