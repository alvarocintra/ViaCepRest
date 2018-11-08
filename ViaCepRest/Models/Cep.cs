using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViaCepRest.Models
{
    public class Cep
    {
        public string rua { get; set; }

        public string bairro { get; set; }

        public string cidade { get; set; }

        public string uf { get; set; }
    }
}
