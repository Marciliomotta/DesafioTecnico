using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.Models
{
    [Serializable]
    public class M_Endereco
    {
        public int id { get; set; }
        public int usuarioID { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string numero { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string pais { get; set; }
        public string cep { get; set; }
       
    }
}
