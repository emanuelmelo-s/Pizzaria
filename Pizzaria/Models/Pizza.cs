using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaria.Models
{
    public class Pizza : IEntidade
    {
        /*https://pizzariaatividade.azurewebsites.net*/

        public Pizza(string nome, decimal preco, string fotoURL)
        {
            Nome = nome;
            Preco = preco;
            FotoURL = fotoURL;
        }

        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }

        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string FotoURL { get; set; }

        #region relacionamentos

        public int SaborId { get; set; }
        public Sabor Sabor { get; set; }

        public int TamanhoId { get; set; }
        public Tamanho Tamanho { get; set; }


        public List<PizzaSabor> PizzasSabores { get; set; }

        #endregion

    }
}
