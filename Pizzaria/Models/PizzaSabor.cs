using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaria.Models
{
    public class PizzaSabor
    {
        public PizzaSabor(int pizzaid, int saborid)
        {
            PizzaId = pizzaid;
            SaborId = saborid;

        }

        [Key]
        public int PizzaId { get;private set; }
        public Pizza Pizza { get; set; }
       

        [Key]
        public int SaborId { get;private set; }
        public Sabor Sabor { get; set; }
 
    }
}
