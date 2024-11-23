using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back.Modelos
{
    public class Produto
    {
        public int ID { get; set; }
        public string? nome { get; set; }
        public int? precoVenda { get; set; }
        public int? precoCusto { get; set; }
        public int? quantidade { get; set; }
    }
}