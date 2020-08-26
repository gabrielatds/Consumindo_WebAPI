using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consumindo_WebAPI.Models
{
    public class EstadoFazenda
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string UF { get; set; }
        public int ValorMax { get; set; }
        public int ValorMin { get; set; }
    }
}
