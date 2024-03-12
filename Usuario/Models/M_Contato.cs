using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.Models
{
    [Serializable]
    public class M_Contato
    {
        public int id { get; set; }
        public string telefone { get; set; }
        public int usuarioID { get; set;}
    }
}
