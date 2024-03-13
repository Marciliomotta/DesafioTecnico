using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuario.Controller;
using Usuario.Models;

namespace DesafioTecnico.Tests
{

    [TestClass]
    public class UserTests
    {
        #region Atributos
        private const string cpfUser = "858.332.095-01";

        #endregion

        [TestMethod]
        public void GetAllUsersAsync()
        {
            var controller = new C_Usuario();
            var result = controller.listagem();
            Assert.IsNotNull(result);
            Assert.AreEqual(result.GetType(), typeof(List<M_Usuario>));

        }

        [TestMethod]
        public void InsertUser()
        {

            var controller = new C_Usuario();

            M_Usuario newUser = CadastraUsuario();

            M_Usuario user = controller.BuscarPorCPF(cpfUser);
            Assert.AreEqual(user.nome, newUser.nome);
            Assert.AreEqual(user.senha, newUser.senha);
            Assert.AreEqual(user.dataNascimento, newUser.dataNascimento);

            DeletaUsuario(user.id);

        }

        [TestMethod]
        public void UpdateUser()
        {
            var controller = new C_Usuario();
            CadastraUsuario();

            M_Usuario editUser = controller.BuscarPorCPF(cpfUser);
            editUser.nome = "JOAO PEDRO";
            editUser.senha = "JOAO123";
            controller.EditarUsuario(editUser);

            M_Usuario user = controller.BuscarPorCPF(cpfUser);
            Assert.AreEqual(user.nome, editUser.nome);
            Assert.AreEqual(user.senha, editUser.senha);
            Assert.AreEqual(user.dataNascimento, editUser.dataNascimento);

            DeletaUsuario(user.id);
        }

        [TestMethod]
        public void InsertContact()
        {
            var controller = new C_Usuario();

            M_Usuario newUser = CadastraUsuario();

            M_Contato telefoneFixo = new M_Contato
            {
                telefone = "(71) 3458-7488",
                usuarioID = newUser.id
            };

            controller.CadastrarContato(telefoneFixo);
            M_Usuario user = controller.BuscarPorCPF(cpfUser);
            var elemento = user.contatos.Select(x => x.telefone == telefoneFixo.telefone);
            Assert.AreEqual(elemento.Contains(true), true);

            DeletaUsuario(user.id);
        }

        [TestMethod]
        public void UpdateAddress()
        {
            var controller = new C_Usuario();

            M_Usuario newUser = CadastraUsuario();

            #region Cria Endereço
            M_Endereco editEndereco = new M_Endereco
            {
                logradouro = "Rua da Juventude",
                complemento = "BLOCO A",
                numero = "12",
                cidade = "CICERO DANTAS",
                estado = "BA",
                pais = "Brasil",
                cep = "40.230-160",
                usuarioID = newUser.id
            };
            #endregion



            controller.EditarEndereco(editEndereco);
            M_Usuario editUser = controller.BuscarPorCPF(cpfUser);

            Assert.AreNotEqual(newUser.endereco, editUser.endereco);

            DeletaUsuario(editUser.id);

        }

        [TestMethod]
        public void GetUserByID()
        {
            var controller = new C_Usuario();

            M_Usuario newUser = CadastraUsuario();
            M_Usuario User = controller.BuscarPorID(newUser.id);

            Assert.AreEqual(User.id, newUser.id);
            Assert.AreEqual(User.nome, newUser.nome);
            Assert.AreEqual(User.senha, newUser.senha);
            Assert.AreEqual(User.dataNascimento, newUser.dataNascimento);
            Assert.AreEqual(User.cpf, newUser.cpf);
            Assert.AreEqual(User.email, newUser.email);

            DeletaUsuario(newUser.id);
        }

        private M_Usuario CadastraUsuario()
        {
            var controller = new C_Usuario();

            #region Cria contato
            M_Contato telefoneFixo = new M_Contato
            {
                telefone = "(71) 3215-7488"
            };
            M_Contato telefoneMovel = new M_Contato
            {
                telefone = "(71) 99514-7283"
            };
            List<M_Contato> contatosList = new List<M_Contato>();
            contatosList.Add(telefoneFixo);
            contatosList.Add(telefoneMovel);
            #endregion

            #region Cria Perfil
            M_PerfilUsuario newPerfil = new M_PerfilUsuario
            {
                ID = 1
            };
            #endregion

            #region Cria Endereço
            M_Endereco newEndereco = new M_Endereco
            {
                logradouro = "Rua das Neves",
                complemento = "apto. 301",
                numero = "09",
                cidade = "Salvador",
                estado = "BA",
                pais = "Brasil",
                cep = "40.180-000"
            };
            #endregion

            #region Cria Usuario
            M_Usuario newUser = new M_Usuario
            {
                nome = "Marcilio Motta",
                cpf = cpfUser,
                email = "mmota@gmail.com",
                senha = "marcilio123",
                dataNascimento = DateTime.Now,
                contatos = contatosList,
                perfil = newPerfil,
                endereco = newEndereco,
                dataCriacao = DateTime.Now,
                dataAlteracao = DateTime.Now,
            };
            #endregion

            controller.Cadastrar(newUser);
            M_Usuario user = controller.BuscarPorCPF(cpfUser);
            return user;
        }

        private void DeletaUsuario(int usuarioID)
        {
            var controller = new C_Usuario();

            controller.DeletarEnderecoPorUsuario(usuarioID);
            controller.DeletarContatoPorUsuario(usuarioID);
            controller.DeletarUsuario(usuarioID);
        }
    }
}
