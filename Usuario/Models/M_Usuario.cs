
using System;
using System.Collections.Generic;

namespace Usuario.Models
{
    [Serializable]
    public class M_Usuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public DateTime dataNascimento { get; set; }
        public List<M_Contato> contatos { get; set; }
        public M_PerfilUsuario perfil { get; set; }
        public M_Endereco endereco { get; set; }

        public DateTime dataCriacao { get; set; }

        public DateTime dataAlteracao { get; set; }

        public M_Usuario()
        {
            contatos = new List<M_Contato>();
            perfil = new M_PerfilUsuario();
            endereco = new M_Endereco();
        }
    }
}
